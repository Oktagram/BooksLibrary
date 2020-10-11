using System.Collections.Generic;
using System.Threading.Tasks;
using BooksLibrary.Application.Books.Commands.AddBook;
using BooksLibrary.Application.Books.Commands.AddBookOrder;
using BooksLibrary.Application.Books.Commands.RemoveBook;
using BooksLibrary.Application.Books.Models;
using BooksLibrary.Application.Books.Queries.GetBooks;
using BooksLibrary.Application.Books.Queries.GetBorrowedBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<BookResponseDto>> Get(GetBooksQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("/books/borrowed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<BookResponseDto>> GetBorrowed(GetBorrowedBooksQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("/books")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddBook(AddBookCommand request)
        {
            var bookId = await _mediator.Send(request);
            return CreatedAtAction(nameof(AddBook), new { id = bookId });
        }

        [HttpPost("/books/order")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> BookOrder(AddBookOrderCommand request)
        {
            var bookOrderId = await _mediator.Send(request);
            return CreatedAtAction(nameof(BookOrder), new { id = bookOrderId });
        }

        [HttpDelete("/books/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _mediator.Send(new RemoveBookCommand(id));
            return NoContent();
        }
    }
}
