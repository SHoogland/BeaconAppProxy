using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BeaconAppProxy.Code;
using Newtonsoft.Json;

namespace BeaconAppProxy.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult ClassRoomSchedule(string classRoom) {
            using (WebClient client = new WebClient()) {
                client.Headers.Add("apiToken:" + WebConfigurationManager.AppSettings["ApiKey"]);
                string classRooms = client.DownloadString("https://mytimetables.inholland.nl/api/v0/timetables?type=location");

                ClassRooms cr = JsonConvert.DeserializeObject<ClassRooms>(classRooms);
                var requiredClassRoom = cr.timetable.FirstOrDefault(c => c.description.ToLower().StartsWith(classRoom.ToLower()));

                int daysToAdd = ((int)DayOfWeek.Saturday - (int)DateTime.Now.DayOfWeek + 7) % 7;
                var endDate = DateTime.Today.AddDays(daysToAdd);

                string classRoomSchedule = client.DownloadString("https://mytimetables.inholland.nl/api/v0/timetables/" + requiredClassRoom.value + "?startDate=today&endDate=" + endDate.ToString("yyyy-MM-dd"));

                var crs = JsonConvert.DeserializeObject<List<ClassRoomSchedule>>(classRoomSchedule);

                var requiredSchedule = new FinalSchedule();
                requiredSchedule.activities = new List<Activity>();
                foreach (var a in crs) {
                    var activity = new Activity {
                        name = a.activityDescription,
                        startDate = a.startDate,
                        endDate = a.endDate,
                        studentSets = a.studentSets
                    };
                    requiredSchedule.activities.Add(activity);
                }
                return Json(requiredSchedule, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Beacons() {
            var beacons = new List<Beacon>();
            beacons.Add(new Beacon {
                Major = "51061",
                Minor = "38039",
                ClassRoom = "HAA-H1-21",
                ImageUrl = "https://beacon-app.azurewebsites.net/Content/photo1.jpg"
            });
            beacons.Add(new Beacon {
                Major = "37461",
                Minor = "17643",
                ClassRoom = "HAA-H1-23",
                ImageUrl = "https://beacon-app.azurewebsites.net/Content/photo2.jpg"
            });
            beacons.Add(new Beacon {
                Major = "29417",
                Minor = "46117",
                ClassRoom = "HAA-H1-14",
                ImageUrl = "https://beacon-app.azurewebsites.net/Content/photo3.jpg"
            });

            return Json(beacons, JsonRequestBehavior.AllowGet);
        }
    }
}
