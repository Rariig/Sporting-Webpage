using System;
using SportEU.Data;
using SportEU.Domain.Common;
using SportEU.Domain.Repos;

namespace SportEU.Domain
{
    public sealed class GroupAssignment : AthleteAssignment<GroupAssignmentData>
    {
        public GroupAssignment() : this(null) { }

        public GroupAssignment(GroupAssignmentData d) : base(d)
        => group = getLazy<Group, IGroupsRepo>(x => x?.Get(GroupId));

        public string GroupId => Data?.GroupId ?? "Unspecified";

        public Group Group => group.Value;
        internal Lazy<Group> group { get; }
    }
}
