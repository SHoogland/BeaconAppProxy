using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BeaconAppProxy {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ClassRoomSchedule",
                url: "classroomschedule/{classRoom}",
                defaults: new { controller = "Home", action = "ClassRoomSchedule", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Beacons",
                url: "beacons",
                defaults: new { controller = "Home", action = "Beacons", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
