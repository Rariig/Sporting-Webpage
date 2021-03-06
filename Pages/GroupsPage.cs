using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportEU.Data;
using SportEU.Domain.Repos;
using SportEU.Facade;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportEU.Pages.Common;
using SportEU.Aids;
using SportEU.Domain;
using SportEU.Domain.Common;
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
            v.Speciality = g.Coach?.Speciality;
            return v;
        }

        protected internal override Group toEntity(GroupView v)
        {
            var d = Copy.Members(v, new GroupData());
            return new Group(d);
        }

        public SelectList Coaches //TODO panna kahe elemendiga list tööle
        {
            get
            {
                var l = new GetRepo().Instance<ICoachesRepo>().Get();

                return new SelectList(l, "Id", "Speciality", Item?.CoachId);
            }
        }

    }
}
