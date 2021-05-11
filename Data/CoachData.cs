using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportEU.Data.Common;

namespace SportEU.Data
{
    public class CoachData : PersonData
    {

        public int Salary { get; set; }
        public string Speciality { get; set; }

    }
}
