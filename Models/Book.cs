using Humanizer.Localisation;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string CategoryiD { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }


        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }


        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        //izdavac
        public Publisher Publisher { get; set; }

        public DateTime YearOfPublication { get; set; }

        public string Storyline { get; set; }

        public int Quantity { get; set; }

        public int NumberOfPages { get; set; }

        // Pismo
        public int ScriptId { get; set; }
        [ForeignKey("ScriptId")]
        public Script Script { get; set; }

        // Povez
        public int BindingId { get; set; }
        [ForeignKey("BindingId")]
        public Binding Binding { get; set; }

        // Format
        public long FormatId { get; set; }
        [ForeignKey("FormatId")]
        public Format Format { get; set; }

        [Required]       
        public string ISBN { get; set; }
        /*public int AvailableCopies { get; set; }
       
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

        //public string Body { get; set; }*/

    }
}
