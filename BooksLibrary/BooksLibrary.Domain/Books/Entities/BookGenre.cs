using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Domain.Books.Entities
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
