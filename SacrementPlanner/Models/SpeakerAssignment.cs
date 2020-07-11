using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class SpeakerAssignment
    {
        public int MeetingID { get; set; }
        public int SpeakerID { get; set; }
        public Meeting Meeting { get; set; }
        public Speaker Speaker { get; set; }
    }
}
