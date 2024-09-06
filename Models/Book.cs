using Microsoft.Identity.Client;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int PageCount { get; set; }

        public long LetterId { get; set; }

        public long LanguageId { get; set; }

        public long BindingId { get; set; }

        public long FormatId { get; set; }

        public long PublisherId { get; set; }

        public string ISBN { get; set; }

        public long QuantityCount { get; set; }

        public long RentedCount { get; set; }

        public long ReservedCount { get; set; }

        public string Body { get; set; }

    }
}
