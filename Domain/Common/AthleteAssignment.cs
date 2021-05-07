﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEU.Data.Common;
using SportEU.Domain;
using SportEU.Domain.Repos;

namespace SportEU.Domain.Common
{
    public abstract class AthleteAssignment<TData> : BaseEntity<TData>
        where TData : AthleteAssignmentData, new()
    {
        protected AthleteAssignment() : this(null) { }
        protected AthleteAssignment(TData d) : base(d) =>
            athlete = getLazy<Athlete,IAthletesRepo>(x => x?.Get(AthleteId));
        public string AthleteId => Data?.AthleteId ?? "Unspecified";

        public Athlete Athlete => athlete.Value;
        internal Lazy<Athlete> athlete { get; }
    }
}

