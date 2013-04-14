using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreeQ_WA.Helpers;
using System.Web.Security;
using FreeQ_WA.Classes;

namespace FreeQ_WA.Views
{
    public partial class ShowList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string qID = Request.QueryString["id"];

            this.invalidQueue.Visible = false;

            if (!string.IsNullOrEmpty(qID))
            {
                Guid qGUI = Guid.Parse(qID);

                HelperClass_Queue hcq = new HelperClass_Queue();

                Queue q = hcq.GetQueue(qGUI);

                if (Membership.GetUser() != null && q.Queue_UserID == (Guid)Membership.GetUser().ProviderUserKey)
                {
                    List<Participant> lp = hcq.GetParticipants(qGUI);

                    this.GridView_Participants.DataSource = lp;
                    this.GridView_Participants.DataBind();

                    return;
                }

            }

            this.invalidQueue.Visible = true;
            //this.adminDiv.Visible = false;
        }
    }
}