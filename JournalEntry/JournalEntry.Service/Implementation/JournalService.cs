using JournalEntry.Data.Models;
using JournalEntry.Infrastructure;
using JournalEntry.Infrastructure.Abstracts;
using JournalEntry.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Service.Implementation
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
        public class JournalService : IJournalService
    {
        private readonly IJournalRepository _repo;
        private readonly dbContext db;
        public JournalService(IJournalRepository repo,dbContext _dbContext)
        {
            _repo = repo;
            db = _dbContext;
        }

        public async Task<ServiceResult> AddAsync(JournalHeader header)
        {
            if (header == null)
                return new ServiceResult { Success = false, ErrorMessage = "Journal is null." };

            // Check if User exists
            var userExists = await ExistsUserAsync(header.User_ID);
            if (!userExists)
                return new ServiceResult { Success = false, ErrorMessage = $"User with ID {header.User_ID} does not exist." };
            
            await _repo.AddAsync(header);

            return new ServiceResult { Success = true };
        }
        public async Task<bool> ExistsUserAsync(long userId)
        {
            return await db.Users.AnyAsync(u => u.User_ID == userId);
        }

        public async Task<bool> ExistsAccountAsync(Guid accountNumber)
        {
            return await db.AccountsCharts.AnyAsync(a => a.ID == accountNumber);
        }

    }
}
