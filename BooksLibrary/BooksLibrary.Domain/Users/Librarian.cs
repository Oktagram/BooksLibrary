using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Domain.Users
{
    public class Librarian
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
