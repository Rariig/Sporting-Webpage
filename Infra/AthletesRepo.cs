
using System.Linq;
using SportEU.Data;
using SportEU.Domain.Repos;
using SportEU.Domain;
using SportEU.Infra;
using SportEU.Infra.Common;

namespace SportEU.Infra
{
    public sealed class AthletesRepo : PagedRepo<Athlete, AthleteData>, IAthletesRepo
    {
        public AthletesRepo() : this(null) { }
        public AthletesRepo(ApplicationDbContext c) : base(c, c?.Athletes) { }

        protected internal override Athlete toEntity(AthleteData d) => new(d);

        protected internal override AthleteData toData(Athlete e) => e?.Data ?? new AthleteData();

        protected internal override IQueryable<AthleteData> applyFilters(IQueryable<AthleteData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.FirstMidName.Contains(SearchString) ||
                     x.LastName.Contains(SearchString) ||
                     x.Strength.ToString().Contains(SearchString)||
                     (x.ValidFrom != null && x.ValidFrom.ToString().Contains(SearchString)) ||
                     (x.ValidTo != null && x.ValidFrom.ToString().Contains(SearchString)));
        }
    } 
}
