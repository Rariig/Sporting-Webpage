using System.ComponentModel.DataAnnotations;
using Core;

namespace SportEU.Data.Common
{
    public abstract class BaseData : UniqueItem, IEntityData
    { 
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
