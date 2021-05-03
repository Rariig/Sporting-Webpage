namespace SportEU.Facade {
    public abstract class BaseEntityView :IBaseEntityView {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}




