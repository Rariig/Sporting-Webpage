using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class AthleteView :PersonEntityView
    {
        [DisplayFormat(NullDisplayText = "No Strength")] 
        [Range(1, 100,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Strength { get; set; }

        [DisplayName("Group")] 
        public int GroupId { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }
    }
}
