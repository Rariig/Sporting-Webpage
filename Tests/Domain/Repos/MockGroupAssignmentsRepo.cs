using System.Collections.Generic;
using SportEU.Domain;
using SportEU.Domain.Repos;
using Tests;

namespace SportEU.Tests.Domain.Repos
{
    public class MockGroupAssignmentsRepo : TestRepo<GroupAssignment>, IGroupAssignmentsRepo
    {
        public List<GroupAssignment> GetByGroupId(string id) => getList($"GetByGroupId {id}");

        public List<GroupAssignment> GetByAthleteId(string id) => getList($"GetByAthleteId {id}");

    }
}
