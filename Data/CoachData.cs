using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportEU.Data.Common;

namespace SportEU.Data
{
    public class CoachData : PersonData
    {

        public decimal? Salary { get; set; }
        public string Speciality { get; set; }

    }
}
