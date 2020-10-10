using FluentValidation;

namespace BooksLibrary.Application.Books.Commands.BookOrder
{
    public class BookOrderCommandValidator : AbstractValidator<BookOrderCommand>
    {
        public BookOrderCommandValidator()
        {
            RuleFor(bo => bo.AuthorId).NotEmpty();
            RuleFor(bo => bo.BookGenreId).NotEmpty();
            RuleFor(bo => bo.Title).NotEmpty();

            RuleFor(bo => bo.PagesCount)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(bo => bo.Year).NotEmpty();
            RuleFor(bo => bo.ExpectedDate).NotEmpty();
            RuleFor(bo => bo.ReaderId).NotEmpty();
        }
    }
}
