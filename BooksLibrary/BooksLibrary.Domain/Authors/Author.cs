﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksLibrary.Domain.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
