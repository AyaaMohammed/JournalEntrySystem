using JournalEntry.Core.Bases;
using JournalEntry.Core.Features.Account.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Account.Queries.Models
{
    public class GetAccountListQuery:IRequest<Response<List<GetAccountListResponse>>>
    {

    }
}
