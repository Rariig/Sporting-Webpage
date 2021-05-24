using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEU.Data;
using SportEU.Domain.Repos;
using SportEU.Domain;
using SportEU.Domain.Common;
using SportEU.Infra.Common;

namespace SportEU.Infra
{
    public sealed class AthletesRepo : PagedRepo<Athlete, AthleteData>, IAthletesRepo
    {
        public AthletesRepo() : this(null) { }
        public AthletesRepo(ApplicationDbContext c) : base(c, c?.Athletes) { }

        protected internal override Athlete toEntity(AthleteData d) => new(d);

        protected internal override AthleteData toData(Athlete e) => e?.Data ?? new AthleteData();


        public override async Task<bool> DeleteAsync(Athlete e)
        {
            await removeGroupAssignments(e?.GroupAssignments, e?.NewlyAssignedGroups);
            var isOk = await base.DeleteAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        public override async Task<bool> AddAsync(Athlete e)
        {
            await updateGroupAssignments(e);
            var isOk = await base.AddAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        public override async Task<bool> UpdateAsync(Athlete e)
        {
            await updateGroupAssignments(e);
            var isOk = await base.UpdateAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        //internal static async Task removeAssignments(Athlete e)
        //{
        //    await removeGroupAssignments(e?.GroupAssignments);
        //}
        //internal static async Task updateAssignments(Athlete i)
        //{
        //    await updateGroupAssignments(i);
        //}
        internal static async Task updateGroupAssignments(Athlete i)
        {
            //await removeGroupAssignments(i?.GroupAssignments, i?.NewlyAssignedGroups);
            await addGroupAssignments(i);
        }
        
        internal static async Task addGroupAssignments(Athlete i)
        {
            if (i is null) return;
            var r = new GetRepo().Instance<IGroupAssignmentsRepo>();
            foreach (var id in i.NewlyAssignedGroups)
            {
                if (i.GroupAssignments?
                    .FirstOrDefault(x => x.GroupId == id) is not null) continue;
                var d = new GroupAssignmentData { GroupId = id, AthleteId = i.Id };
                await r.AddAsync(new GroupAssignment(d));
            }
        }

        private static async Task removeGroupAssignments(
            IEnumerable<GroupAssignment> l, ICollection<string> doNotRemove = null)
        {
            if (l is null) return;
            var r = new GetRepo().Instance<IGroupAssignmentsRepo>();
            foreach (var e in l)
            {
                if (doNotRemove?.Contains(e.GroupId) ?? false) continue;
                await r.DeleteAsync(e);
            }
        }



        protected internal override IQueryable<AthleteData> applyFilters(IQueryable<AthleteData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.FirstMidName.Contains(SearchString) ||
                     x.LastName.Contains(SearchString) ||
                     x.Age.ToString().Contains(SearchString) ||
                     x.Strength.ToString().Contains(SearchString)||
                     (x.ValidFrom != null && x.ValidFrom.ToString().Contains(SearchString)));
        }
    } 
}
