using System;
using System.Collections.Generic;
using Data;
using Domain.Common;
using Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Group : Named<GroupData>
    {

        public List<string> NewAthletes { get; } = new();
        public Group() : this(null) { }

        public Group(GroupData d) : base(d)
        {
            coach = getLazy<Coach, ICoachesRepo>(x => x?.GetById(CoachId));
        }


        public string CoachId => Data?.CoachId ?? "Unspecified";
        internal Lazy<Coach> coach { get; }
        public Coach Coach => coach.Value;

        public ICollection<AthleteData> Athlete { get; set; }

       /*  public ICollection<Athlete> Athletes => Groups?.Select(x => x.Group).ToList();
        public ICollection<Group> Groups => groups?.Value;
        internal Lazy<ICollection<Group>> athletes { get; } */

        public void AddAthletes(string athleteId)
        {
            if (athleteId is not null) NewAthletes?.Add(athleteId);
        }
    }
}
