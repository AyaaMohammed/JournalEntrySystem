using JournalEntry.Core.Bases;
using JournalEntry.Core.Features.User.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.User.Queries.Models
{
    public class GetUserListQuery:IRequest<Response<List<GetUserListResponse>>>
    {
    }
}
