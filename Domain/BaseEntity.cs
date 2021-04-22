﻿using System;
using SportEU.Aids;
using SportEU.Core;

namespace SportEU.Domain {
    public abstract class BaseEntity<TData>: IBaseEntity 
    where TData: class, IEntityData, new() {
        protected readonly TData data;

        protected BaseEntity() :this(null) { }
        protected BaseEntity(TData d) => data = d;

        public TData Data => Copy.Members(data, new TData());

        public int Id => data?.Id ?? -1;
        public byte[] RowVersion => data?.RowVersion ?? Array.Empty<byte>();
    }
}




