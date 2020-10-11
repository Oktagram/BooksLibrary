using FluentValidation;

namespace BooksLibrary.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBooksQueryValidator()
        {
            When(b => !string.IsNullOrEmpty(b.AuthorName), () =>
            {
                RuleFor(b => b.AuthorName).MaximumLength(500);
            });

            When(b => b.BookGenreId.HasValue, () =>
            {
                RuleFor(b => b.BookGenreId.Value).NotEmpty();
            });

            When(b => b.PublishedYear.HasValue, () =>
            {
                RuleFor(b => b.PublishedYear.Value).NotEmpty();
            });

            When(b => !string.IsNullOrEmpty(b.Title), () =>
            {
                RuleFor(b => b.Title).MaximumLength(500);
            });
        }
    }
}
