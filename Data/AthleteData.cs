using System;
using Data.Common;

namespace Data
{
    public class AthleteData : PersonEntityData
    {

        // [DisplayFormat(NullDisplayText = "No Strength")] 
        /* [Range(0, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")] */

        public DateTime StartingDate { get; set; }
        public int Strength { get; set; }
        public string GroupId { get; set; }
        public string CoachId { get; set; }

        /* public ICollection<GroupData> Groups { get; set; } */
    }

}
