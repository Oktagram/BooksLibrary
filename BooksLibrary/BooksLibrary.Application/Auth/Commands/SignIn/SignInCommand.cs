using BooksLibrary.Domain.Users;
using MediatR;

namespace BooksLibrary.Application.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<User>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
