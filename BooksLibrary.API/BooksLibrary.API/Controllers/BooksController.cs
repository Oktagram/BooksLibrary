using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("/books")]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/books/borrowed")]
        public async Task<IActionResult> GetBorrowed()
        {
            throw new NotImplementedException();
        }

        [HttpPost("/books")]
        public async Task<IActionResult> AddBook()
        {
            throw new NotImplementedException();
        }

        [HttpPost("/books/order")]
        public async Task<IActionResult> BookOrder()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("/books/{id}")]
        public async Task<IActionResult> RemoveBook()
        {
            throw new NotImplementedException();
        }
    }
}
