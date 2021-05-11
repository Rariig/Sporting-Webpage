using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SportEU.Facade.Common;

namespace SportEU.Facade
{
    public class CoachView : PersonView
    {



        [DataType(DataType.Currency)]
        [Range(1, 15000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [DisplayName("Salary")]
        public decimal Salary { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }
    }
}
