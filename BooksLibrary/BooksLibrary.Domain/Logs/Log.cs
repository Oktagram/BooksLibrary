using System;
using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Domain.Logs
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Login { get; set; }
        public string CallSite { get; set; }
        public string Exception { get; set; }
    }
}
