using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace SportEU.Domain
{
    public class CoachEntity: BaseEntity<CoachData>
    {
        public CoachEntity() : this(null) { }

        public CoachEntity(CoachData d) : base(d) { }

        public decimal Salary => Data?.Salary ?? 0M;

    }
}
