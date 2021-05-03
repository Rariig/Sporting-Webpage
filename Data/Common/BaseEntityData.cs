using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEU.Core;

namespace Data.Common
{
    public abstract class BaseEntityData : IEntityData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
