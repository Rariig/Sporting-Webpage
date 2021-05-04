using Data.Common;
using SportEU.Core;
using SportEU.Domain;

namespace Domain.Common
{ 
    public interface IPersonEntity : IBaseEntity
    {
        public string LastName { get; }
        public string FirstMidName { get; }
        public string FullName { get; }
    }
    public abstract class Person<TData> : BaseEntity<TData>, IPersonEntity
        where TData : PersonEntityData, new()
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
    }
}
