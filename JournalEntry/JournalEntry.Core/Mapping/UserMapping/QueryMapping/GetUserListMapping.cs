using JournalEntry.Core.Features.User.Queries.Results;
using JournalEntry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace JournalEntry.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {
        private void GetUserListMapping()
        {
            CreateMap<User, GetUserListResponse>();
        }
    }
}
