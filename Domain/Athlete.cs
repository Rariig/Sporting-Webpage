using System;
using Data;
using Domain.Common;

namespace SportEU.Domain
{
    public sealed class Athlete : Person<AthleteData>
    {
        public Athlete() : this(null) { }

        public Athlete(AthleteData d) : base(d)
        {

        }


        public DateTime StartingDate => Data?.ValidFrom ?? DateTime.MinValue;
        public int Strength => Data?.Strength ?? 0;
        public string GroupId { get; set; }
        public string CoachId { get; set; }
    }
}
