using SportEU.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class AthleteData : BaseEntityData, IEntityData
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

        [DisplayFormat(NullDisplayText = "No Strength")]
        // vaja lisada veel mingi atribuut, et 1-100 oleks nt siia
        public int Strength { get; set; }
        public ICollection<GroupData> Groups { get; set; }
    }

}
