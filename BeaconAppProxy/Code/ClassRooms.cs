using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaconAppProxy.Code {
    public class ClassRooms {
        public List<classroom> timetable { get; set; }
    }
    public class classroom {
        public string description { get; set; }
        public string hostKey { get; set; }
        public string locationCapacity { get; set; }
        public string value { get; set; }
    }
}