using System;
using SportEU.Aids;
using SportEU.Core;

namespace SportEU.Domain {
    public abstract class BaseEntity<TData> : IBaseEntity
        where TData : class, IEntityData, new()
    {
        protected readonly TData data;

        protected BaseEntity() : this(null) { }
        protected BaseEntity(TData d) => data = d;

        public TData Data => Copy.Members(data, new TData()) ?? new TData();
        public string Id => Data?.Id ?? "Unspecified";
        public byte[] RowVersion => Data?.RowVersion ?? Array.Empty<byte>();
    }
}




