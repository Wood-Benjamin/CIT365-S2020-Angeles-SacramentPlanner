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
        [Required(ErrorMessage = "Please enter the Speaker's name.")]
        public string SpeakerName { get; set; }
        [Display(Name = "Speaker Topic")]
        [Required(ErrorMessage = "Please enter a Topic.")]
        public string SpeakerTopic { get; set; }
        [Display(Name = "Meeting Date")]
        public Meeting Meeting { get; set; }
    }
}
