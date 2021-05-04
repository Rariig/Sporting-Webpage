using Data;
using Domain.Repos;
using Facade;
using Infra;
using Pages.Common;
using SportEU.Aids;
using SportEU.Domain;
using SportEU.Facade;
using SportEU.Infra;

namespace Pages
{
    class AthletesPage : ViewPage<Athlete,AthleteView>
    {
        public override string PageTitle => "Athletes";

        public AthletesPage(ApplicationDbContext c) : this(new AthletesRepo(c), c) { }

        protected internal AthletesPage(IAthletesRepo r, ApplicationDbContext c = null) : base(r, c) { }
        protected internal override AthleteView toViewModel(Athlete a)
        {
            if (isNull(a)) return null;
            var v = Copy.Members(a.Data, new AthleteView());
            return v;
        }

        protected internal override Athlete toEntity(AthleteView v)
        {
            var d = Copy.Members(v, new AthleteData());
            return new Athlete(d);
        }
    } 
}
