using System;
using System.Collections.Generic;
using System.Linq;
using BooksLibrary.Application.Books.Models;
using BooksLibrary.Domain.Books.Enums;

namespace BooksLibrary.Application.Books.Extensions
{
    public static class ListBookResponseDtoExtensions
    {
        public static Dictionary<string, List<BookResponseDto>> GroupBy(
            this List<BookResponseDto> source, BookFilter? groupBy)
        {
            if (!groupBy.HasValue)
            {
                return new Dictionary<string, List<BookResponseDto>>
                {
                    {string.Empty, source}
                };
            }

            var groupByFunc = GetGroupByFunc();

            return source
                .GroupBy(groupByFunc)
                .ToDictionary(g => g.Key, g => g.ToList());

            Func<BookResponseDto, string> GetGroupByFunc()
            {
                switch (groupBy.Value)
                {
                    case BookFilter.Author:
                        return book => book.AuthorName;
                    case BookFilter.Genre:
                        return book => book.GenreId.ToString();
                    case BookFilter.Year:
                        return book => book.PublishedYear.ToString("dd/MM/yyyy");
                    default:
                        throw new ArgumentOutOfRangeException(nameof(groupBy), groupBy, null);
                }
            }
        }
    }
}
