using System.Linq;
using Data;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pages.Common;
using SportEU.Aids;
using SportEU.Domain;
using SportEU.Infra;

namespace Pages
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
            return new Group(d);
        }

        public SelectList Coaches =>
            new(context.Coaches.OrderBy(x => x.LastName).AsNoTracking(),
                "Id", "LastName", Item?.CoachId);
    }
}
