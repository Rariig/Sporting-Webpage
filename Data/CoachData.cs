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
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }

        public ICollection<GroupData> Groups { get; set; }
    }
}
