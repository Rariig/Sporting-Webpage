using System;
using System.Collections.Generic;
using SportEU.Data;
using SportEU.Domain.Common;
using SportEU.Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Group : Named<GroupData>
    {

        public Group() : this(null) { }
        public Group(GroupData d) : base(d)
        {
            groupAssignments = getLazy<GroupAssignment, IGroupAssignmentsRepo>(x => x?.GetByGroupId(Id));
            coach = getLazy<Coach, ICoachesRepo>(x => x?.GetById(CoachId));
        }



        public ICollection<GroupAssignment> GroupAssignments => groupAssignments.Value;
        internal Lazy<ICollection<GroupAssignment>> groupAssignments { get; }

        public List<string> NewlyAssignedAthletes { get; } = new();


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
