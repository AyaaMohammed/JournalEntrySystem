using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Journal.Commands.Models
{
    public class JournalDetailDto
    {
        public Guid AccountID { get; set; }         
        public string AccountNumber { get; set; }    
        public string AccountName { get; set; }
        public string LineDescription { get; set; }
        public string ReportDescription { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
