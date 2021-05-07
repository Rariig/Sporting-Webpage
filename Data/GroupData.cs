using SportEU.Data.Common;


namespace SportEU.Data
{
    public class GroupData : NamedData
    {

        public string CoachId { get; set; }
        public string AthleteId { get; set; }


        /* public CoachData Coach { get; set; }
        public ICollection<AthleteData> Athlete { get; set; } */
    }
}
