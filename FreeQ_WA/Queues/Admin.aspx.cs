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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string qID = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(qID))
            {
                Guid qGUI = Guid.Parse(qID);

                HelperClass_Queue hcq = new HelperClass_Queue();

                Queue q = hcq.GetQueue(qGUI);

                if (q.Queue_UserID == (Guid)Membership.GetUser().ProviderUserKey)
                {
                    this.invalidQueue.Visible = false;
                    return;
                }
            }

            this.invalidQueue.Visible = true;
            this.adminDiv.Visible = false;
        }
    }
}