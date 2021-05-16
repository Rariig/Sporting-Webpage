using System.Linq;
using SportEU.Data;
using SportEU.Domain.Repos;
using SportEU.Domain;
using SportEU.Infra.Common;

namespace SportEU.Infra
{
    public sealed class GroupsRepo:PagedRepo<Group,GroupData>, IGroupsRepo
    {
        public GroupsRepo() : this(null) { }
        public GroupsRepo(ApplicationDbContext c) : base(c, c?.Groups) { }

        protected internal override Group toEntity(GroupData d) => new(d);

        protected internal override GroupData toData(Group e) => e?.Data ?? new GroupData();


        protected internal override IQueryable<GroupData> applyFilters(IQueryable<GroupData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.Name.Contains(SearchString));
        }

    }
}
