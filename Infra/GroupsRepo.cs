using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Domain.Common;
using Domain.Repos;
using Infra.Common;
using SportEU.Domain;
using SportEU.Infra;

namespace Infra
{
    public sealed class GroupsRepo:PagedRepo<Group,GroupData>, IGroupsRepo
    {
        public GroupsRepo() : this(null) { }
        public GroupsRepo(ApplicationDbContext c) : base(c, c?.Groups) { }

        protected internal override Group toEntity(GroupData d) => new(d);

        protected internal override GroupData toData(Group e) => e?.Data ?? new GroupData();

        public List<Group> GetByCoachId(string id)
            => getRelated(x => x.CoachId == id);


       /* internal static async Task addAthlete(Group i)
        {
            if (i is null) return;
            var r = new GetRepo().Instance<IAthletesRepo>();
            foreach (var id in i.NewlyAssignedAthletes)
            {
                if (i.CourseAssignments?
                    .FirstOrDefault(x => x.CourseId == id) is not null) continue;
                var d = new AthleteData { CourseId = id, InstructorId = i.Id };
                await r.Add(new Athlete(d));
            }
        } */

        private static async Task removeAthlete(
            IEnumerable<Athlete> l, ICollection<string> doNotRemove = null)
        {
            if (l is null) return;
            var r = new GetRepo().Instance<IAthletesRepo>();
            foreach (var e in l)
            {
                if (doNotRemove?.Contains(e.Id) ?? false) continue;
                await r.Delete(e);
            }
        }

    }
}
