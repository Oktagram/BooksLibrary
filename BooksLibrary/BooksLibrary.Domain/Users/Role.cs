using System.Collections.Generic;

namespace BooksLibrary.Domain.Users
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
