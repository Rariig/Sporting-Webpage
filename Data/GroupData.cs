using Data.Common;


namespace Data
{
    public class GroupData : NamedEntityData
    {

        public int CoachId { get; set; }
        public int AthleteId { get; set; }


        /* public CoachData Coach { get; set; }
        public ICollection<AthleteData> Athlete { get; set; } */
    }
}
