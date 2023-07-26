using ECommerceBackend.Application.Abstractions.Services;
using ECommerceBackend.Application.Features.Commands.AppUser.CreateUser;
using ECommerceBackend.Application.Features.Commands.AppUser.FacebookLogin;
using ECommerceBackend.Application.Features.Commands.AppUser.GoogleLogin;
using ECommerceBackend.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IMailService _mailService;

        public UsersController(IMediator mediator,IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> ExampleMailTest()
        {
            await _mailService.SendMessageAsync("feyza.kaymakci@gmail.com", "Example Mail", "<strong>This is an example mail.</strong>");
            return Ok();
        }
    }
}
