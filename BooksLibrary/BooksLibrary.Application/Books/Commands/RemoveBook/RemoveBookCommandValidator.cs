using FluentValidation;

namespace BooksLibrary.Application.Books.Commands.RemoveBook
{
    public class RemoveBookCommandValidator : AbstractValidator<RemoveBookCommand>
    {
        public RemoveBookCommandValidator()
        {
            RuleFor(rb => rb.BookId).NotEmpty();
        }
    }
}
