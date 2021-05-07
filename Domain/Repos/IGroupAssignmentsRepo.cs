using System.Collections.Generic;

namespace SportEU.Domain.Repos
{
    public interface IGroupAssignmentsRepo : IRepo<GroupAssignment>
    {
        List<GroupAssignment> GetByGroupId(string id);
        List<GroupAssignment> GetByAthleteId(string id);
    }
}
