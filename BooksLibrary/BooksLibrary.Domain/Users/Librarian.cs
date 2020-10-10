using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.Domain.Entities
{
    public class Librarian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
