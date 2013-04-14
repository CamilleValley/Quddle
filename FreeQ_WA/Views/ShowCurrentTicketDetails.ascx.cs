using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreeQ_WA.Helpers;

namespace FreeQ_WA.Views
{
    public partial class ShowCurrentTicketDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string qID = Request.QueryString["id"];
            
            if (!string.IsNullOrEmpty(qID))
            {
                try
                {
                    Guid qGUI = Guid.Parse(qID);

                    HelperClass_Queue hcq = new HelperClass_Queue();
                    HelperClass_Ticket hct = new HelperClass_Ticket();

                    Queue q = hcq.GetQueue(qGUI);

                    if (q.Queue_Current_Ticket_ID == null)
                        return;

                    Ticket t = hct.GetTicket((Guid)q.Queue_Current_Ticket_ID);

                    this.lblEmail.Text = t.Ticket_Email;
                    this.lblNumero.Text = t.Ticket_Increment.ToString();
                    this.lblPwd.Text = t.Ticket_Password;
                }
                catch { }
            }
        }
    }
}