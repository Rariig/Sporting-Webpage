using System.ComponentModel.DataAnnotations;
using Core;

namespace Data.Common
{
    public abstract class NamedEntityData : BaseEntityData, INamedEntityData
    {
        [StringLength(50)] public string Name { get; set; }
    }
}
