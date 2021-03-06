using System;
using System.Collections.Generic;
using SportEU.Data;
using SportEU.Domain.Common;
using System.Linq;
using SportEU.Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Athlete : Person<AthleteData>
    {

        public List<string> NewlyAssignedGroups { get; } = new();
        public Athlete() : this(null) { }

        public Athlete(AthleteData d) : base(d)
        {
            groupAssignments = getLazy<GroupAssignment, IGroupAssignmentsRepo>(x => x?.GetByAthleteId(Id));
        }

        public DateTime StartingDate => Data?.ValidFrom ?? DateTime.MinValue;
        public int Strength => Data?.Strength ?? 0;


        public ICollection<Group> Groups => GroupAssignments?.Select(x => x.Group).ToList();
        public ICollection<GroupAssignment> GroupAssignments => groupAssignments?.Value;
        internal Lazy<ICollection<GroupAssignment>> groupAssignments { get; }

        public void AddGroup(string groupId)
        {
            if (groupId is not null) NewlyAssignedGroups?.Add(groupId);
        }

 

    }
}
