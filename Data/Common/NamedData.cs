using System.ComponentModel.DataAnnotations;
using Core;
using SportEU.Core;

namespace SportEU.Data.Common
{
    public abstract class NamedData : BaseData, INamedEntityData
    {
        [StringLength(50)] public string Name { get; set; }
    }
}
