using JournalEntry.Core.Features.Account.Queries.Models;
using JournalEntry.Core.Features.User.Queries.Models;
using JournalEntry.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JournalEntry.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Router.AccountRouting.GetAll)]
        public async Task<IActionResult> GetAccounts()
        {
            var response = await _mediator.Send(new GetAccountListQuery());
            return Ok(response);
        }
    }
}
