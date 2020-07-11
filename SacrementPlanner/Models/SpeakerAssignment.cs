using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class SpeakerAssignment
    {
        public int ID { get; set; }
        public int MeetingID { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerTopic { get; set; }
        public Meeting Meeting { get; set; }
    }
}
