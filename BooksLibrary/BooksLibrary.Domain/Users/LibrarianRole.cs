namespace BooksLibrary.Domain.Users
{
    public class LibrarianRole
    {
        public const int Id = 1;

        public const string Name = nameof(Librarian);

        public static bool IsInRole(User user)
            => user.RoleId == Id;
    }
}
