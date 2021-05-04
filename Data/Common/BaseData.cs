using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Common
{
    public abstract class BaseData : IEntityData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
