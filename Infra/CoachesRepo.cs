using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEU.Data;
using SportEU.Domain.Repos;
using SportEU.Domain;
using SportEU.Infra;
using SportEU.Infra.Common;

namespace SportEU.Infra
{
    public sealed class CoachesRepo : PagedRepo<Coach, CoachData>, ICoachesRepo
    {
        public CoachesRepo() : this(null) { }
        public CoachesRepo(ApplicationDbContext c) : base(c, c?.Coaches) { }

        protected internal override Coach toEntity(CoachData d) => new(d);

        protected internal override CoachData toData(Coach e) => e?.Data ?? new CoachData();

    }
}
