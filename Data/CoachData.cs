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
        public int Salary { get; set; }

        public ICollection<GroupData> Groups { get; set; }
    }
}
