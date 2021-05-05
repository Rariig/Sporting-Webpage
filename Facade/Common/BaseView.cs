using System;

namespace SportEU.Facade {
    public abstract class BaseView : IBaseEntityView
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public byte[] RowVersion { get; set; }
    }
}




