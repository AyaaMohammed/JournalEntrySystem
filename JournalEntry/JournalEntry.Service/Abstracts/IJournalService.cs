using JournalEntry.Data.Models;
using JournalEntry.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Service.Abstracts
{
    public interface IJournalService
    {
        Task<ServiceResult> AddAsync(JournalHeader header);
        Task<bool> ExistsUserAsync(long userId);
        Task<bool> ExistsAccountAsync(Guid accountNumber);
    }
}
