using System.Collections.Generic;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Repos;
using SportEU.Infra.Common;

namespace SportEU.Infra
{
    public sealed class GroupAssignmentsRepo
        : PagedRepo<GroupAssignment, GroupAssignmentData> ,IGroupAssignmentsRepo
    {
        public GroupAssignmentsRepo() : this(null) { }
        public GroupAssignmentsRepo(ApplicationDbContext c) : base(c, c?.GroupAssignments) { }
        protected internal override GroupAssignment toEntity(GroupAssignmentData d) => new(d);
        protected internal override GroupAssignmentData toData(GroupAssignment s) => s?.Data ?? new GroupAssignmentData();

        public List<GroupAssignment> GetByGroupId(string id)
            => getRelated(x => x.GroupId == id);

        public List<GroupAssignment> GetByAthleteId(string id)
            => getRelated(x => x.AthleteId == id);
    }
}
