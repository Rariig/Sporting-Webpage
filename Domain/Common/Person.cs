using SportEU.Data.Common;
using SportEU.Core;
using SportEU.Domain;

namespace SportEU.Domain.Common
{ 
    public interface IPersonEntity : IBaseEntity
    {
        public string LastName { get; }
        public string FirstMidName { get; }
        public string FullName { get; }
        public int Age { get; }
    }
    public abstract class Person<TData> : BaseEntity<TData>, IPersonEntity
        where TData : PersonData, new()
    {
        protected Person() : this(null) { }
        protected Person(TData d) : base(d) { }
        public string LastName => Data?.LastName ?? "Unspecified";
        public string FirstMidName => Data?.FirstMidName ?? "Unspecified";
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public int Age => Data?.Age ?? 20;
    }
}
