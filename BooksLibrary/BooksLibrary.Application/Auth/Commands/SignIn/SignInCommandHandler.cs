using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Application.Exceptions;
using BooksLibrary.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, User>
    {
        private readonly IApplicationDbContext _dbContext;

        public SignInCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(
                u => u.Login == request.Login
                     && u.Password == request.Password,
                cancellationToken);

            if (user is null)
                throw new UnauthorizedException();

            return user;
        }
    }
}
