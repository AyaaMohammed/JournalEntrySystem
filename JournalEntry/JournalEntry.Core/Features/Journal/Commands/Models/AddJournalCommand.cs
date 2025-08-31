using JournalEntry.Core.Bases;
using JournalEntry.Data.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Journal.Commands.Models
{
    public class AddJournalCommand : IRequest<Response<string>>
    {
        public string SystemNo { get; set; }
        public DateTime EntryDate { get; set; }
        public string TransactionType { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public long User_ID { get; set; }
        public string FilePath { get; set; }

        public List<JournalDetailDto> JournalDetails { get; set; }
    }
}
