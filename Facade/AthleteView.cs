﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class AthleteView :PersonEntityView
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Started training")]
        public DateTime StartingDate { get; set; }

        [DisplayFormat(NullDisplayText = "No Strength")] 
        [Range(0, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Strength { get; set; }

        [DisplayName("Group")] 
        public int GroupId { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }

        [DisplayName("Coach")]
        public string CoachId { get; set; }

        [Display(Name = "Coach")]
        public string CoachName { get; set; }
    }
}
