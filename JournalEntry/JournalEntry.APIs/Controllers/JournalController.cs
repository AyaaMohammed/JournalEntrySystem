using JournalEntry.Core.Features.Journal.Commands.Models;
using JournalEntry.Data.Models;
using JournalEntry.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace JournalEntry.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly dbContext _context;

        public JournalController(IMediator mediator, dbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddJournal([FromBody] AddJournalCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result); 

            return Ok(result);
        }
        [HttpGet("test")]
        public IActionResult TestConnection()
        {
            var users = _context.Users.ToList();
            return Ok(new { Count = users.Count });
        }

      
    }
}
