using JournalEntry.Core.Features.Journal.Commands.Models;
using JournalEntry.Data.AppMetaData;
using JournalEntry.Data.Models;
using JournalEntry.Infrastructure;
using JournalEntry.Infrastructure.Abstracts;
using JournalEntry.Service.Abstracts;
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
        private readonly IJournalRepository _journalRepository;
        private readonly IPdfService _pdfService;
        public JournalController(IMediator mediator,IJournalRepository journal,IPdfService pdfService)
        {
            _mediator = mediator;
            _journalRepository = journal;
            _pdfService = pdfService;
        }

        [HttpPost(Router.JournalRouting.Add)]
        public async Task<IActionResult> AddJournal([FromBody] AddJournalCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Succeeded)
                return BadRequest(result); 

            return Ok(result);
        }
        [HttpGet(Router.JournalRouting.Print)]
        public async Task<IActionResult> GetJournalForPrint(Guid journalId)
        {
            var journal = await _journalRepository.GetByIdAsync(journalId);

            if (journal == null) return NotFound();
            var pdfBytes = _pdfService.GenerateJournalPdf(journal);

            return File(pdfBytes, "application/pdf", $"Journal_{journalId}.pdf");
        }
    }
}
