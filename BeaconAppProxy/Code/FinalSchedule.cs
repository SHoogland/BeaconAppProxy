using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaconAppProxy.Code {
    public class FinalSchedule {
        public List<Activity> activities { get; set; }
    }
    public class Activity {
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public List<string> studentSets { get; set; }
    }
}