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
            groupAssignments = getLazy<GroupAssignment, IGroupAssignmentsRepo>(x => x?.GetByGroupId(Id));
        }

        

        public ICollection<GroupAssignment> GroupAssignments => groupAssignments.Value;
        internal Lazy<ICollection<GroupAssignment>> groupAssignments { get; }



    }
}
