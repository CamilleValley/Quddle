using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreeQ_WA.Helpers;

namespace FreeQ_WA.Views
{
    public partial class Public : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string qID = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(qID))
                {
                    try
                    {
                        Guid qGUI = Guid.Parse(qID);

                        HelperClass_Queue hcq = new HelperClass_Queue();

                        Queue q = hcq.GetQueue(qGUI);

                        if (!string.IsNullOrEmpty(q.Queue_Address))
                        {
                            HelperClass_Map hcm = new HelperClass_Map();

                            try
                            {
                                geoloc gl = hcm.GeocodeAddress(q.Queue_Address);
                                Session["lat"] = gl.lat;
                                Session["lon"] = gl.lon;

                                this.divMap.Visible = true;
                                this.addressNotFound.Visible = false;

                                return;
                            }
                            catch
                            {
                                this.addressNotFound.Visible = true;
                            }
                        }
                    }
                    catch { }
                }

                this.divMap.Visible = false;
            }
        }
    }
}