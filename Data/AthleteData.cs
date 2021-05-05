    using System;
using Data.Common;

namespace Data
{
    public class AthleteData : PersonData
    {

        public DateTime StartingDate { get; set; }
        public int Strength { get; set; }
        public string GroupId { get; set; }
        public string CoachId { get; set; }

        /* public ICollection<GroupData> Groups { get; set; } */
    }

}
