using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SportEU.Facade.Common;

namespace SportEU.Facade
{
    public class CoachView : PersonView
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hiring Date")] 
        public DateTime HireDate { get; set; }


        [DataType(DataType.Currency)]
        [Range(1, 15000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [DisplayName("Salary")]
        public decimal Salary { get; set; }

        [DisplayName("Group")] 
        public int GroupId { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }
    }
}
