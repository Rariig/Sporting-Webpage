using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Facade;
using SportEU.Facade.Common;

namespace SportEU.Facade
{
    public class AthleteView :PersonView
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Started training")]
        public DateTime StartingDate { get; set; }

        [DisplayFormat(NullDisplayText = "No Strength")] 
        [Range(0, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Strength { get; set; }

        [Display(Name = "Groups")] public List<GroupAssignmentView> AthleteGroups { get; set; }
    }
}
