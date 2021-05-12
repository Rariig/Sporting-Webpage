using System.ComponentModel.DataAnnotations;
using SportEU.Core;

namespace SportEU.Data.Common
{
    public abstract class BaseData : UniqueItem, IEntityData
    { 
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
