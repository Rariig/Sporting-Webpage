using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportEU.Facade
{
    public sealed class CoachView : NamedView
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")] public DateTime HireDate { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "money")] public decimal Salary { get; set; }

        [DisplayName("Group")] public int GroupId { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
