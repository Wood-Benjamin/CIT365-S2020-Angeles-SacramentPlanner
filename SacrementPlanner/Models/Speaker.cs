using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class Speaker
    {
        public int ID { get; set; }
        public string SpeakerName { get; set; }
        public string Topic { get; set; }
        public Meeting Meeting { get; set; }
        public ICollection<SpeakerAssignment> SpeakerAssigments { get; set; }
    }
}
