namespace SportEU.Core {
    public interface IBaseEntity {
        public int Id { get; }
        public byte[] RowVersion { get; }
    }
}



