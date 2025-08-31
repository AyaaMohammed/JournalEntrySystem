using JournalEntry.Core.Features.User.Queries.Models;
using JournalEntry.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JournalEntry.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Router.UserRouting.GetAll)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetUserListQuery());
            return Ok(response);
        }
    }
}
