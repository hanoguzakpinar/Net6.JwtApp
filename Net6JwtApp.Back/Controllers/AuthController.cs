using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Net6JwtApp.Back.Infrastructure;
using Net6JwtApp.Back.Infrastructure.Tools;

namespace Net6JwtApp.Back.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var userDto = await _mediator.Send(request);
            if (userDto.IsExist)
            {
                var token = JwtTokenGenerator.GenerateToken(userDto);
                return Created("", token);
            }

            return BadRequest(MessageContent.IncorrectSignIn);
        }

        [HttpGet("[action]")]
        public IActionResult WhoAmI()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string? role = User.FindFirst(ClaimTypes.Role)?.Value;
            string? name = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = new { Name = name, Role = role, UserId = userId };
            return Ok(user);
        }
    }
}
