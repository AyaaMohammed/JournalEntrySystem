using JournalEntry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Infrastructure.Abstracts
{
    public interface IJournalRepository
    {
        Task AddAsync(JournalHeader header);
        Task<JournalHeader> GetByIdAsync(Guid id);
    }
}
