using System;
using SportEU.Data;
using SportEU.Domain.Common;
using SportEU.Domain.Repos;

namespace SportEU.Domain
{
    public sealed class Coach: Person<CoachData>
    {
        public Coach() : this(null) { }

        public Coach(CoachData d) : base(d) { }


        public decimal Salary => Data?.Salary ?? 0;
        public string Speciality => Data?.Speciality ?? "No speciality";
        public string PhoneNumber => Data?.PhoneNumber ?? "No phone";

    }
}
