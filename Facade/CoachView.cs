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
        public decimal Salary { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        public string Speciality { get; set; }
    }
}
