using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SportEU.Facade.Common
{
    public abstract class PersonView : BaseView
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Age")]
        [Range(10, 110, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }

        [Display(Name = "Full Name")] public string FullName { get; set; }

        [Display(Name = "New Photo")] public IFormFile Photo { get; set; }

        [Display(Name = "Current Photo")] public string PhotoAsString { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Starting date")]
        public DateTime ValidFrom { get; set; }
    }
}
