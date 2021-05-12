using SportEU.Core;

namespace SportEU.Facade {
    public abstract class BaseView : UniqueItem, IBaseEntityView
    {
        public byte[] RowVersion { get; set; }
    }
}




