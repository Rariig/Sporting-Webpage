using System;
using System.Collections.Generic;
using Data;
using Domain.Common;
using Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Group : Named<GroupData>
    {

        public List<string> NewlyAssignedAthletes { get; } = new();
        public Group() : this(null) { }

        public Group(GroupData d) : base(d)
        {
            coach = getLazy<Coach, ICoachesRepo>(x => x?.GetById(CoachId));
        }


        public string CoachId => Data?.CoachId ?? "Unspecified";
        internal Lazy<Coach> coach { get; }
        public Coach Coach => coach.Value;


          /* public ICollection<Athlete> MovingAthletes => Athletes?.Select(x => x.Group).ToList();
         public ICollection<Athlete> Athletes => athletes?.Value;
         internal Lazy<ICollection<Athlete>> athletes { get; }  */
     

        public void AddAthlete(string athleteId)
        {
            if (athleteId is not null) NewlyAssignedAthletes?.Add(athleteId);
        }



    }
}
