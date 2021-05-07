using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SportEU.Facade;

namespace SportEU.Facade.Common
{
    public abstract class NamedView : BaseView
    {
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z -']*$")]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
