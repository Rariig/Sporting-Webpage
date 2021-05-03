using Data.Common;

namespace Data
{
    public class AthleteData : PersonData
    {

        // [DisplayFormat(NullDisplayText = "No Strength")] 
        /* [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")] */

        public int Strength { get; set; }
        public int GroupId { get; set; }

        /* public ICollection<GroupData> Groups { get; set; } */
    }

}
