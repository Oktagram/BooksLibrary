using System;
using FluentValidation;

namespace BooksLibrary.Application.Books.Commands.AddBookOrder
{
    public class AddBookOrderCommandValidator : AbstractValidator<AddBookOrderCommand>
    {
        public AddBookOrderCommandValidator()
        {
            RuleFor(bo => bo.AuthorName).NotEmpty().MaximumLength(500);
            RuleFor(bo => bo.BookGenreId).NotEmpty();

            RuleFor(bo => bo.Title)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(bo => bo.PagesCount)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(bo => bo.PublishedYear).NotEmpty();

            RuleFor(bo => bo.ExpectedDate.Date)
                .NotEmpty()
                .GreaterThan(DateTime.Now.Date)
                .WithMessage("Expected date must be future date");

            RuleFor(bo => bo.ReaderId).NotEmpty();
        }
    }
}
