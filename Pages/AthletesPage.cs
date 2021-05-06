using System.Linq;
using Data;
using Domain.Common;
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
    public class AthletesPage : ViewPage<Athlete,AthleteView>
    {
        public override string PageTitle => "Athletes";

        public AthletesPage(ApplicationDbContext c) : this(new AthletesRepo(c), c) { }

        protected internal AthletesPage(IAthletesRepo r, ApplicationDbContext c = null) : base(r, c) { }
        protected internal override AthleteView toViewModel(Athlete a)
        {
            if (isNull(a)) return null;
            var v = Copy.Members(a.Data, new AthleteView());
            v.FullName = a.FullName;
            //v.GroupName = a.Group?.Name;
            return v;
        }

        protected internal override Athlete toEntity(AthleteView v)
        {
            var d = Copy.Members(v, new AthleteData());
            return new Athlete(d);
        }

        public SelectList Groups =>
            new(context.Groups.OrderBy(x => x.Name).AsNoTracking(),
                "Id", "Name");

        public bool IsAssigned(SelectListItem item)
            => Item?.AthleteGroups?
                .FirstOrDefault(x =>
                    x.CourseId == item.Value) is not null;
    } 
}
