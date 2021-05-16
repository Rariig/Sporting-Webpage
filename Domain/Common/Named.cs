using SportEU.Core;

namespace SportEU.Domain.Common
{
    public abstract class Named<TData> : BaseEntity<TData>
        where TData : class, INamedEntityData, new()
    {
        protected Named() : this(null) { }
        protected Named(TData d) : base(d) { }
        public string Name => Data?.Name ?? string.Empty;
    }
}
