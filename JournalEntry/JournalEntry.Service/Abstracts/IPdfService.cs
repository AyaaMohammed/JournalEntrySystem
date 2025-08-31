using JournalEntry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Service.Abstracts
{
    public interface IPdfService
    {
        byte[] GenerateJournalPdf(JournalHeader journal);
    }
}
