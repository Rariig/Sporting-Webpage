using System.Linq;
using SportEU.Data;
using SportEU.Domain.Repos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportEU.Pages.Common;
using SportEU.Aids;
using SportEU.Domain;
using SportEU.Facade;
using SportEU.Infra;

namespace SportEU.Pages
{
    public class CoachesPage : ViewPage<Coach, CoachView>
    {
        public override string PageTitle => "Coaches";

        public CoachesPage(ApplicationDbContext c) : this(new CoachesRepo(c), c) { }

        protected internal CoachesPage(ICoachesRepo r, ApplicationDbContext c = null) : base(r, c) { }

        protected internal override CoachView toViewModel(Coach c)
        {
            if (isNull(c)) return null;
            var v = Copy.Members(c.Data, new CoachView());
            return v;
        }

        protected internal override Coach toEntity(CoachView v)
        {
            var d = Copy.Members(v, new CoachData());
            return new Coach(d);
        }

        public SelectList Groups =>
            new(context.Groups.OrderBy(x => x.Name).AsNoTracking(),
                "Id", "Name", Item?.GroupId);
    }
}
