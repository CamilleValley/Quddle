using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeQ_WA.Views
{
    public partial class ShowTicketPicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Helpers.HelperClass_Queue hcq = new Helpers.HelperClass_Queue();
            Guid queueID = Guid.Parse(Request.QueryString["id"]);

            Queue q = hcq.GetQueue(queueID);

            if (!hcq.IsActive(q)) this.divTicketP.Visible = false;
        }
    }
}