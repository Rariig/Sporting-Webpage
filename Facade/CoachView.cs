using System.ComponentModel.DataAnnotations;
using SportEU.Facade.Common;

namespace SportEU.Facade
{
    public sealed class CoachView : PersonView
    {

        [DataType(DataType.Currency)]
        [Range(1, 15000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Salary { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        public string Speciality { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{8,10})$", ErrorMessage = "Not a valid phone number. Enter without spaces and country code.")] // panin lihtsa validationi esialgu, need raskemad ei tahtnud toimida nii nagu ma tahtsin
        public string PhoneNumber { get; set; }
    }
}
