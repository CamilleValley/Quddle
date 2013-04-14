using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeQ_WA.Queues
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.viewLinks.Visible = (Request.QueryString["view"] == "1");
            this.confirmationCreation.Visible = !(Request.QueryString["view"] == "1");
        }
    }
}