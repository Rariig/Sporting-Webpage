using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class GroupView :NamedEntityView
    {
        [DisplayName("Coach")]
        public int CoachId { get; set; }
        [DisplayName("Coach")]
        public int AthleteId { get; set; }

        [Display(Name = "Coach")]
        public string CoachName { get; set; }
        [Display(Name = "Athlete")]
        public string AthleteName { get; set; }
    }
}
