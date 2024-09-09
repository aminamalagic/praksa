namespace Library.Models
{
    public class UserType
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Bibliotekar> Bibliotekari { get; set; }
    }
}
