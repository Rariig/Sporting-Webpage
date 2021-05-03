using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Data.Common
{
    public abstract class NamedEntityData : BaseEntityData, INamedEntityData
    {
        [StringLength(50)] public string Name { get; set; }
    }
}
