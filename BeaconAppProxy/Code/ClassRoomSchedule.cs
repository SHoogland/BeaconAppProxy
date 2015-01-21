using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaconAppProxy.Code {
    public class ClassRoomSchedule {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string moduleCode { get; set; }
        public string activityDescription { get; set; }
        public List<staffMember> staffMembers { get; set; }
        public List<location> locations { get; set; }
        public List<string> studentSets { get; set; }
        public string activityTypeName { get; set; }
        public string activityTypeDescription { get; set; }
        public string notes { get; set; }
        public bool highlighted { get; set; }
        public List<string> timetableKeys { get; set; }
    }
    public class staffMember { }
    public class location {
        public string id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string capacity { get; set; }
        public string url { get; set; }
        public List<avoidConcurrencyLocationId> avoidConcurrencyLocationIds { get; set; }
    }
    public class avoidConcurrencyLocationId{}
}