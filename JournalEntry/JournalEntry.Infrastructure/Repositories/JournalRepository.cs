using JournalEntry.Data.Models;
using JournalEntry.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JournalEntry.Infrastructure.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private readonly dbContext _context;

        public JournalRepository(dbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(JournalHeader header)
        {
            await _context.JournalHeaders.AddAsync(header);
            await _context.SaveChangesAsync();
        }

        public async Task<JournalHeader> GetByIdAsync(Guid id)
        {
            return await _context.JournalHeaders
                .Include(x => x.JournalDetails)
                 .FirstOrDefaultAsync(x => x.JournalID == id);
        }
    }

}
