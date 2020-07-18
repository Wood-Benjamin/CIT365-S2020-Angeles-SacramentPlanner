using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacrementPlanner.Models
{
    public class SpeakerAssignment
    {
        public int ID { get; set; }
        public int MeetingID { get; set; }

        [Display(Name = "Speaker Name")]
        public string SpeakerName { get; set; }
        [Display(Name = "Speaker Topic")]
        public string SpeakerTopic { get; set; }
        [Display(Name = "Date")]
        public Meeting Meeting { get; set; }
    }
}
