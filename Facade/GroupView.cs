using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SportEU.Facade.Common;

namespace SportEU.Facade
{
    public sealed class GroupView :NamedView
    {
        [DisplayName("Coach")]
        public string CoachId { get; set; }

        [Display(Name = "Coach")]
        public string CoachName { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

    }
}
