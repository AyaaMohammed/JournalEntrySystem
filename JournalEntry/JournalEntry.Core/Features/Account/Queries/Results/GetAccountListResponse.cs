using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Account.Queries.Results
{
    public class GetAccountListResponse
    {
        public Guid ID { get; set; }
        public string NameEN { get; set; }
        public string Number { get; set; }
    }
}
