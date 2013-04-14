using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeQ_WS.Models;
using System.Web.Routing;
using System.Web.Security;

namespace FreeQ_WS.Controllers
{
    public class QueueController : Controller
    {
        public IQueueService queueService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (queueService == null) { queueService = new QueueService(); }

            base.Initialize(requestContext);
        }

        public ActionResult Overview()
        {
            MembershipUser loggedIn = Membership.GetUser();
            if (loggedIn == null)
            {
                ViewBag.Message = "You must be connected to view this page.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(queueService.GetQueues((Guid)loggedIn.ProviderUserKey));
            }
        }
    }
}
