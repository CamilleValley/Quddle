using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeQ_WS.Models;
using System.Web.Routing;

namespace FreeQ_WS.Controllers
{
    public class MapController : Controller
    {
        public IMapService mapService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (mapService == null) { mapService = new MapService(); }

            base.Initialize(requestContext);
        }

        public ActionResult MapCheck()
        {
            return View();
        }

        public ActionResult Locations()
        {
            List<PushPinModel> pushpins = mapService.GetAddressList();

            //return the list as JSON
            return Json(pushpins);
        }

        public ActionResult HQLocation()
        {
            PushPinModel PushPin = mapService.GetHQLocation();

            //return the list as JSON
            return Json(PushPin);
        }
    }
}
