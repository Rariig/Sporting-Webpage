using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Athlete : Person<AthleteData>
    {
        public Athlete() : this(null) { }

        public Athlete(AthleteData d) : base(d)
        {
             //group = getLazy<Group, IGroupsRepo>(x => x?.Get(GroupId));
        }

        //public string GroupId => Data?.GroupId ?? "Unspecified";

        //public Group Group => group.Value;
        //internal Lazy<Group> group { get; } gruppe peaks saama ikka tickboxiga lisada siin vist

        public DateTime StartingDate => Data?.ValidFrom ?? DateTime.MinValue;
        public int Strength => Data?.Strength ?? 0;
        public string CoachId => Data?.CoachId ?? "Unspecified";

    }
}
