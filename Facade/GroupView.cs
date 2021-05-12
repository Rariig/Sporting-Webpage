using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SportEU.Domain;
using SportEU.Facade.Common;

namespace SportEU.Facade
{
    public class GroupView :NamedView
    {
        [DisplayName("Coach")]
        public int CoachId { get; set; }

        [Display(Name = "Coach")]
        public string CoachName { get; set; }
    }
}
