using SacrementPlanner.Models.MeetingViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }

        [Display(Name = "Meeting Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a Meeting date, 'MM/DD/YYYY'.")]
        public DateTime MeetingDate { get; set; }
        public string Presiding { get; set; }
        public string Conducting { get; set; }
        [Display(Name = "Special Notes")]
        public string SpecialNotes { get; set; }
        [Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }
        public string Invocation { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public string SacamentHymn { get; set; }
        [Display(Name = "Musical Number")]
        public string IntermediateHymn { get; set; }
        [Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }
        public string Benediction { get; set; }

        public ICollection<SpeakerAssignment> SpeakerAssigments { get; set; }
    }
}
