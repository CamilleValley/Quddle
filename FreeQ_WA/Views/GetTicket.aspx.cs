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
    public partial class GetTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                string qID = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(qID))
                {
                    try
                    {
                        Guid qGUI = Guid.Parse(qID);

                        HelperClass_Ticket hct = new HelperClass_Ticket();

                        MembershipUser u = Membership.GetUser(User.Identity.Name);

                        string email = string.Empty;

                        if (u != null)
                            email = u.Email;

                        Ticket t = hct.GenerateNextTicket(qGUI, email);

                        this.lblTicketIncr.Text = t.Ticket_Increment.ToString();
                        this.lblTicketPwd.Text = t.Ticket_Password;

                        Session["lastTicketID"] = t.Ticket_ID;
                    }
                    catch (Exception ex)
                    {
                        this.divGetTicket.InnerText = ex.Message;
                    }
                }
            }
        }

        protected void ButtonAlert_Click(object sender, EventArgs e)
        {
            HelperClass_Ticket hct = new HelperClass_Ticket();
            Guid tID = (Guid)Session["lastTicketID"];

            Ticket t = hct.GetTicket(tID);
            hct.UpdateAlertEmail(tID, this.alertEmailTxtBox.Text);

            this.alertActivated.Visible = true;
        }
    }
}