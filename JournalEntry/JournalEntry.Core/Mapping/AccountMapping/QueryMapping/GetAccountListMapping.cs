using JournalEntry.Core.Features.Account.Queries.Results;
using JournalEntry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace JournalEntry.Core.Mapping.AccountMapping
{
    public partial class AccountProfile
    {
        private void GetAccountListMapping()
        {
            CreateMap<AccountsChart, GetAccountListResponse>();
        }
    }
}
