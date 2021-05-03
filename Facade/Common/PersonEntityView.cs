using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SportEU.Facade;

namespace Facade.Common
{
    public class PersonEntityView : BaseEntityView
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

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "New Photo")]
        public IFormFile Photo { get; set; }

        [Display(Name = "Current Photo")]
        public string PhotoAsString { get; set; }
    }
}
