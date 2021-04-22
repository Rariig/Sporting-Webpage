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
        // vaja lisada veel mingi atribuut, et 1-100 oleks nt siia. atribuudid siis facade'i
        public int Strength { get; set; }
        public ICollection<GroupData> Groups { get; set; }
    }

}
