using FluentValidation;

namespace BooksLibrary.Application.Auth.Commands.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(s => s.Login).NotEmpty().MinimumLength(5);
            RuleFor(s => s.Password).NotEmpty().MinimumLength(5);
        }
    }
}
