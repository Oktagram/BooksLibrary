using FluentValidation;

namespace BooksLibrary.Application.Books.Commands.AddBook
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(b => b.AuthorId).NotEmpty();
            RuleFor(b => b.BookGenreId).NotEmpty();

            RuleFor(b => b.Title)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(b => b.PagesCount)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(b => b.PublishedYear).NotEmpty();
        }
    }
}
