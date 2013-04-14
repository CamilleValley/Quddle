using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreeQ_WA.Helpers;
using System.Web.Security;

namespace FreeQ_WA.Views
{
    public partial class ShowCurrentTicket : System.Web.UI.UserControl
    {
        protected void Timer_PM_Tick(object sender, EventArgs e)
        {
            UpdatePanel_PM.Update();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string qID = Request.QueryString["id"];
            string showDetails = Request.QueryString["showDetails"];

            if (!string.IsNullOrEmpty(qID))
            {
                try
                {
                    Guid qGUI = Guid.Parse(qID);

                    HelperClass_Queue hcq = new HelperClass_Queue();
                    HelperClass_Ticket hct = new HelperClass_Ticket();

                    Queue q = hcq.GetQueue(qGUI);

                    this.queueName.InnerText = q.Queue_Name;
                    if (q.Queue_Current_Ticket_ID != null) this.currentTicketNumber.InnerText = hct.GetTicket((Guid)q.Queue_Current_Ticket_ID).Ticket_Increment.ToString();
                    else this.currentTicketNumber.InnerText = "--";
                    if (q.Queue_ExpectedHandlingTime != null) this.expectedHandlingTime.InnerText = "Estimated processing time per ticket: " + q.Queue_ExpectedHandlingTime.ToString() + " min.";

                    this.invalidQueue.Visible = false;
                    this.TicketDetails.Visible = false;
                    this.activeDateOver.Visible = false;

                    if (showDetails == "1")
                    {
                        if (q.Queue_UserID == (Guid)Membership.GetUser().ProviderUserKey)
                        {
                            this.TicketDetails.Visible = true;
                        }
                    }

                    if (!hcq.IsActive(q)) this.activeDateOver.Visible = true;

                    return;
                }
                catch { }
            }

            this.invalidQueue.Visible = true;
        }
    }
}