using System;
using System.ComponentModel.DataAnnotations;


namespace SportEU.Data.Common
{
    public abstract class PersonData : BaseData
    {
        [StringLength(50)] public string LastName { get; set; }
        [StringLength(50)] public string FirstMidName { get; set; }
        public int Age { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? ValidFrom { get; set; }
    }
}
