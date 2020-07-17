using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Presiding { get; set; }
        public string Conducting { get; set; }
        public string SpecialNotes { get; set; }
        public string OpeningHymn { get; set; }
        public string Invocation { get; set; }
        public string SacamentHymn { get; set; }
        public ICollection<SpeakerAssignment> SpeakerAssigments { get; set; }
        public string IntermediateHymn { get; set; }
        public string ClosingHymn { get; set; }
        public string Benediction { get; set; }

      
    }
}
