namespace BooksLibrary.Domain.Users
{
    public class ReaderRole
    {
        public const int Id = 2;

        public const string Name = nameof(Reader);

        public static bool IsInRole(User user)
            => user.RoleId == Id;
    }
}
