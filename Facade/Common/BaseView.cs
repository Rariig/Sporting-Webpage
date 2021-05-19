using SportEU.Core;

namespace SportEU.Facade.Common {
    public abstract class BaseView : UniqueItem, IBaseEntityView
    {
        public byte[] RowVersion { get; set; }
    }
}




