using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportEU.Core;

namespace Data
{
    public class CoachData : BaseEntityData, IEntityData
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        [Range(1, 15000,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Salary { get; set; }

        public int GroupId { get; set; }

        public GroupData Groups { get; set; }
    }
}
