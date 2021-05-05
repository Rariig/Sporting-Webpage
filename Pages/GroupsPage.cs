using System.Linq;
using Data;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportEU.Pages.Common;
using SportEU.Aids;
using SportEU.Domain;
using SportEU.Infra;

namespace SportEU.Pages
{
    public class GroupsPage : ViewPage<Group, GroupView>
    {
        public override string PageTitle => "Groups";

        public GroupsPage(ApplicationDbContext c) : this(new GroupsRepo(c), c) { }

        protected internal GroupsPage(IGroupsRepo r, ApplicationDbContext c = null) : base(r, c) { }

        protected internal override GroupView toViewModel(Group g)
        {
            if (isNull(g)) return null;
            var v = Copy.Members(g.Data, new GroupView());
            v.CoachName = g.Coach?.FullName;
            return v;
        }

        protected internal override Group toEntity(GroupView v)
        {
            var d = Copy.Members(v, new GroupData());
            var obj = new Group(d);
            if (v?.Athletes is null) return obj;
            foreach (var c in v.Athletes) obj.AddAthlete(c?.Id);
            return obj;
        }


        public SelectList Coaches =>
            new(context.Coaches.OrderBy(x => x.LastName).AsNoTracking(),
                "Id", "LastName", Item?.CoachId);
        public SelectList Athletes =>
            new(context.Athletes.OrderBy(x => x.LastName).AsNoTracking(),
                "Id", "LastName", Item?.Id);

    }
}
