using FluentValidation;

namespace BooksLibrary.Application.Books.Queries.GetBorrowedBooks
{
    public class GetBorrowedBooksQueryValidator : AbstractValidator<GetBorrowedBooksQuery>
    {
        public GetBorrowedBooksQueryValidator()
        {
            When(b => !string.IsNullOrEmpty(b.ReaderName), () =>
            {
                RuleFor(b => b.ReaderName).MaximumLength(500);
            });

            When(b => !string.IsNullOrEmpty(b.ReaderName), () =>
            {
                RuleFor(b => b.ReaderName).MaximumLength(500);
            });

            When(b => !string.IsNullOrEmpty(b.Title), () =>
            {
                RuleFor(b => b.Title).MaximumLength(500);
            });
        }
    }
}
