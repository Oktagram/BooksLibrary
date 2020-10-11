using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Authors;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;
using BooksLibrary.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.API.Controllers
{
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DatabaseController(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("/database/seed")]
        public async Task Seed()
        {
            var user1 = new User
            {
                Login = "librarian",
                Password = "librarian",
                RoleId = 1,
                Librarian = new Librarian
                {
                    Name = "Librarian1"
                }
            };

            var user2 = new User
            {
                Login = "reader",
                Password = "reader",
                RoleId = 2,
                Reader = new Reader
                {
                    Name = "Anton",
                    MemberSince = new DateTime(2001, 1, 1),
                    BookOrders = new List<BookOrder>
                    {
                        new BookOrder
                        {
                            ExpectedDate = new DateTime(2022, 1, 1),
                            Book = new Book
                            {
                                Author = new Author
                                {
                                    Name = "King",
                                    Books = new List<Book>
                                    {
                                        new Book
                                        {
                                            Title = "book5",
                                            Status = BookStatus.InStock,
                                            PublishedYear = new DateTime(2005, 2, 6),
                                            PagesCount = 50,
                                            Genre = new BookGenre
                                            {
                                                Name = "genre2"
                                            }
                                        }
                                    }
                                },
                                Title = "The Dark Tower",
                                Genre = new BookGenre
                                {
                                    Name = "Fantasy"
                                },
                                PublishedYear = new DateTime(1985, 1, 1),
                                PagesCount = 2000,
                                Status = BookStatus.Ordered
                            }
                        },
                        new BookOrder
                        {
                            ExpectedDate = new DateTime(2022, 1, 1),
                            Book = new Book
                            {
                                AuthorId = 1,
                                Title = "book4",
                                GenreId = 1,
                                PublishedYear = new DateTime(1985, 1, 1),
                                PagesCount = 2000,
                                Status = BookStatus.Ordered
                            }
                        }
                    },
                    BorrowedBooks = new List<BorrowedBook>
                    {
                        new BorrowedBook
                        {
                            Book = new Book
                            {
                                Author = new Author
                                {
                                    Name = "Andrzej"
                                },
                                PublishedYear = new DateTime(2001, 2, 4),
                                Title = "The Witcher",
                                GenreId = 1,
                                PagesCount = 2000,
                                Status = BookStatus.Borrowed
                            },
                            LibrarianId = 1
                        },
                        new BorrowedBook
                        {
                            Book = new Book
                            {
                                AuthorId = 2,
                                PublishedYear = new DateTime(2001, 2, 4),
                                Title = "book3",
                                GenreId = 1,
                                PagesCount = 2000,
                                Status = BookStatus.Borrowed
                            },
                            LibrarianId = 1
                        }
                    }
                }
            };

            await _applicationDbContext.Users.AddAsync(user1);
            await _applicationDbContext.Users.AddAsync(user2);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
