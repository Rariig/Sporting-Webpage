using System;
using Data;
using Domain.Common;
using Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Coach: Person<CoachData>
    {
        public Coach() : this(null) { }

        public Coach(CoachData d) : base(d)
        {
            group = getLazy<Group, IGroupsRepo>(x => x?.GetById(GroupId));
        }


        public DateTime HireDate => Data?.ValidFrom ?? DateTime.MinValue;
        public decimal Salary => Data?.Salary ?? 0;

        public string GroupId => Data?.GroupId ?? "Unspecified";
        internal Lazy<Group> group { get; }
        public Group Group=> group.Value;
    }
}
