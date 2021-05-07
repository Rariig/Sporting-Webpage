﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportEU.Data.Common;

namespace SportEU.Data
{
    public class CoachData : PersonData
    {
        public DateTime HireDate { get; set; }

        public int Salary { get; set; }

        public string GroupId { get; set; }

        /*  public GroupData Group { get; set; } */
    }
}
