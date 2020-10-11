using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrary.Application.Books.Models;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;

namespace BooksLibrary.Application.Books.Extensions
{
    public static class QueryableBookExtensions
    {
        public static IQueryable<Book> OrderBy(this IQueryable<Book> source, BookFilter orderBy, bool isDesc)
        {
            switch (orderBy)
            {
                case BookFilter.Author:
                    return isDesc
                        ? source.OrderByDescending(b => b.Author.Name)
                        : source.OrderBy(b => b.Author.Name);

                case BookFilter.Genre:
                    return isDesc
                        ? source.OrderByDescending(b => b.Genre.Name)
                        : source.OrderBy(b => b.Genre.Name);

                case BookFilter.Year:
                    return isDesc
                        ? source.OrderByDescending(b => b.PublishedYear)
                        : source.OrderBy(b => b.PublishedYear);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBy), orderBy, null);
            }
        }
    }
}
