using System;
using System.Collections.Generic;
using SportEU.Data;
using SportEU.Domain.Common;
using SportEU.Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Group : Named<GroupData>
    {

        public Group() : this(null) { }
        public Group(GroupData d) : base(d)
        {
            coach = getLazy<Coach, ICoachesRepo>(x => x?.Get(CoachId));
            groupAssignments = getLazy<GroupAssignment, IGroupAssignmentsRepo>(x => x?.GetByGroupId(Id));
        }
        public string CoachId => Data?.CoachId ?? "Unspecified";
        public Coach Coach => coach.Value;
        internal Lazy<Coach> coach { get; }


        public ICollection<GroupAssignment> GroupAssignments => groupAssignments.Value;
        internal Lazy<ICollection<GroupAssignment>> groupAssignments { get; }

    }
}
