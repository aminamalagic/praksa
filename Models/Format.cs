namespace Library.Models
{
    public class Format
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
