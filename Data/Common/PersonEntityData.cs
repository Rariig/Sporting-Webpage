using System;
using System.ComponentModel.DataAnnotations;


namespace Data.Common
{
    public abstract class PersonEntityData : BaseEntityData
    {
        [StringLength(50)] public string LastName { get; set; }
        [StringLength(50)] public string FirstMidName { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
