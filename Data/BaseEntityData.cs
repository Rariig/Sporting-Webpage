﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data {
    public abstract class BaseEntityData : IEntityData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}






