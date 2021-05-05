using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Common;
using SportEU.Domain;

namespace Facade
{
    public class GroupView :NamedView
    {
        [DisplayName("Coach")]
        public int CoachId { get; set; }

        [Display(Name = "Coach")]
        public string CoachName { get; set; }

        [Display(Name = "Athletes")] public List<Athlete> Athletes { get; set; }
    }
}
