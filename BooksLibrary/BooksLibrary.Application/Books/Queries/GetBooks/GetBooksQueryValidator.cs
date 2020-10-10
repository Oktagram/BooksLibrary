using FluentValidation;

namespace BooksLibrary.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBooksQueryValidator()
        {
            When(b => b.AuthorId.HasValue, () =>
            {
                RuleFor(b => b.AuthorId.Value).NotEmpty();
            });

            When(b => b.BookGenreId.HasValue, () =>
            {
                RuleFor(b => b.BookGenreId.Value).NotEmpty();
            });

            When(b => b.PublishedYear.HasValue, () =>
            {
                RuleFor(b => b.PublishedYear.Value).NotEmpty();
            });
        }
    }
}
