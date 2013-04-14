using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FreeQ_WA.Helpers;

namespace FreeQ_WA.Queues
{
    public partial class ShowWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["queueEdit"] = null;

                string queueId = Request.QueryString["queueId"];
                if (queueId != null)
                {
                    HelperClass_Queue hcq = new HelperClass_Queue();

                    Queue q = hcq.GetQueue(Guid.Parse(queueId));
                    Session["queueEdit"] = q;

                    this.title.Text = q.Queue_Name;
                    this.description.Text = q.Queue_Description;
                    this.initiatorAlias.Text = q.Queue_OwnerName;

                    this.minuit.Checked = q.Queue_ResetAtMidnight;
                    this.ticketsmaxopt.Checked = q.Queue_ResetAtMaxReached;
                    if (q.Queue_MaxLimit != null) this.ticketsmax.Text = q.Queue_MaxLimit.ToString();
                    if (q.Queue_ValidTillDate != null)
                    {
                        this.desactivateDate.Text = q.Queue_ValidTillDate.ToString();
                        this.desactiverqueue.Checked = true;
                    }

                    this.editQueue.InnerHtml = "Edit the queue ";

                    if (!q.Queue_IsActive) this.editQueue.InnerHtml += "(Currently disabled)";
                }
            }

            WizardQueue.PreRender += new EventHandler(Wizard1_PreRender);

        }

        protected void Wizard1_PreRender(object sender, EventArgs e)
        {
            Repeater SideBarList = WizardQueue.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            SideBarList.DataSource = WizardQueue.WizardSteps;
            SideBarList.DataBind();

            calendarButtonExtender.SelectedDate = DateTime.Now.AddDays(7);
        }

        protected string GetClassForWizardStep(object wizardStep)
        {
            WizardStep step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }
            int stepIndex = WizardQueue.WizardSteps.IndexOf(step);

            if (stepIndex < WizardQueue.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > WizardQueue.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
            }
        }

        protected void WizardQueue_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Queue q = new Queue();

            if (Session["queueEdit"] != null) q = (Queue)Session["queueEdit"];

            q.Queue_Name = this.title.Text;
            q.Queue_Address = this.location.Text;
            q.Queue_Description = this.description.Text;
            q.Queue_OwnerName = this.initiatorAlias.Text;
            q.Queue_ResetAtMidnight = this.minuit.Checked;
            q.Queue_ResetAtMaxReached = this.ticketsmaxopt.Checked;
            if (!string.IsNullOrEmpty(this.handlingTime.Text)) q.Queue_ExpectedHandlingTime = int.Parse(this.handlingTime.Text);
            if (this.ticketsmaxopt.Checked) q.Queue_MaxLimit = int.Parse(this.ticketsmax.Text);
            if (this.desactiverqueue.Checked) q.Queue_ValidTillDate = DateTime.Parse(this.desactivateDate.Text);
            q.Queue_Next_Increment = 1;
            q.Queue_IsActive = true;
            q.Queue_UserID = (Guid)Membership.GetUser().ProviderUserKey;

            HelperClass_Queue hcq = new HelperClass_Queue();

            if (Session["queueEdit"] == null)
            {
                q.Queue_IsActive = true;
                q = hcq.CreateQueue(q);
            }
            else
                hcq.UpdateQueue(q);

            Session["NewQueue"] = q.Queue_ID;

            this.Response.Redirect(Page.ResolveUrl("~/Queues/Confirmation.aspx"));
        }
    }
}