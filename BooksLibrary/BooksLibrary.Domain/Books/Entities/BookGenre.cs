using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksLibrary.Domain.Entities
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
