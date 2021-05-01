using SportEU.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class AthleteData : BaseEntityData, IEntityData
    {

        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }

        // [DisplayFormat(NullDisplayText = "No Strength")] 
        [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Strength { get; set; }

        public int? GroupId { get; set; }
        public ICollection<GroupData> Groups { get; set; }
    }

}
