using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeQ_WA.Views
{
    public partial class ShowAdminOptions : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Helpers.HelperClass_Queue hcq = new Helpers.HelperClass_Queue();
            Guid queueID = Guid.Parse(Request.QueryString["id"]);

            Queue q = hcq.GetQueue(queueID);

            if (!hcq.IsActive(q)) this.divAdminOptions.Visible = false;
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) this.ProcessTicket(true);
        }

        protected void LinkButtonNext_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) this.ProcessTicket(false);
        }

        private void ProcessTicket(bool isCancel)
        {
            string qID = Request.QueryString["id"];

            try
            {
                if (!string.IsNullOrEmpty(qID))
                {
                    Guid qGUI = Guid.Parse(qID);
                    Helpers.HelperClass_Queue hcq = new Helpers.HelperClass_Queue();

                    hcq.ValidateCurrentTicket(qGUI, isCancel);
                }
            }
            catch (Exception ex)
            {
                this.divAdminOptions.InnerText = ex.Message;
            }
        }
    }
}