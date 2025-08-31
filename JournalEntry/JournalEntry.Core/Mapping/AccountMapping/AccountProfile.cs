using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Mapping.AccountMapping
{
    public partial  class AccountProfile:Profile
    {
        public AccountProfile()
        {
            GetAccountListMapping();
        }
    }
}
