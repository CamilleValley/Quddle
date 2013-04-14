using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FreeQ_WA.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Helpers.HelperClass_Queue hcq = new Helpers.HelperClass_Queue();
                MembershipUser u = Membership.GetUser(User.Identity.Name);

                this.DropDownList_Queues.DataSource = hcq.GetQueues((Guid)Membership.GetUser().ProviderUserKey);

                this.DropDownList_Queues.DataValueField = "Queue_ID";
                this.DropDownList_Queues.DataTextField  = "Queue_Name";

                this.DropDownList_Queues.DataBind();

                this.QueueList.Visible = (this.DropDownList_Queues.Items.Count > 0);
                this.NoQueue.Visible = !(this.DropDownList_Queues.Items.Count > 0);
            }
        }

        protected void btnQueueSelect_Click(object sender, EventArgs e)
        {
            Helpers.HelperClass_Queue hcq = new Helpers.HelperClass_Queue();

            //List<Queue> lq = new List<Queue>();
            //
            //lq.Add(hcq.GetQueue(Guid.Parse(this.DropDownList_Queues.SelectedItem.Value)));
            //this.DetailsView_Queue.DataSource = lq;
            //this.DetailsView_Queue.DataBind();

            this.Response.Redirect(Page.ResolveUrl("~/queues/ShowWizard.aspx?queueId=" + this.DropDownList_Queues.SelectedItem.Value));
        }

        protected void btnQueueDisable_Click(object sender, EventArgs e)
        {
            Helpers.HelperClass_Queue hcq = new Helpers.HelperClass_Queue();

            hcq.DisableQueue(Guid.Parse(this.DropDownList_Queues.SelectedItem.Value));
        }

        protected void btnQueueView_Click(object sender, EventArgs e)
        {
            Session["NewQueue"] = Guid.Parse(this.DropDownList_Queues.SelectedItem.Value);

            this.Response.Redirect(Page.ResolveUrl("~/queues/Confirmation.aspx?view=1"));
        }

    }
}