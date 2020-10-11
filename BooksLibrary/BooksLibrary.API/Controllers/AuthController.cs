using System.Collections.Generic;
using System.Threading.Tasks;
using BooksLibrary.API.Auth;
using BooksLibrary.Application.Auth.Commands.SignIn;
using BooksLibrary.Application.Auth.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/auth/sign-in")]
        public async Task<AuthResponseDto> SignIn([FromQuery] SignInCommand request)
        {
            var user = await _mediator.Send(request);

            var token = new JwtTokenAuth().GetToken(user);

            var response = new AuthResponseDto
            {
                AccessToken = token,
                Login = user.Login
            };

            return response;
        }
    }
}
