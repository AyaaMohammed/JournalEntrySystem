using AutoMapper;
using JournalEntry.Core.Bases;
using JournalEntry.Core.Features.Account.Queries.Models;
using JournalEntry.Core.Features.Account.Queries.Results;
using JournalEntry.Core.Features.User.Queries.Models;
using JournalEntry.Core.Features.User.Queries.Results;
using JournalEntry.Data.Models;
using JournalEntry.Infrastructure.InfrastructureBases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Account.Queries.Handlers
{
    public class AccountListHandlers : IRequestHandler<GetAccountListQuery, Response<List<GetAccountListResponse>>>
    {
        IMapper _mapper;
        IGenericRepositoryAsync<AccountsChart> _userRepository;
        public AccountListHandlers(IMapper mapper, IGenericRepositoryAsync<AccountsChart> genericRepository)
        {
            _mapper = mapper;
            _userRepository = genericRepository;
        }
        public async Task<Response<List<GetAccountListResponse>>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            var accounts = _userRepository.GetTableNoTracking().ToList();
            var mappedaccounts = _mapper.Map<List<GetAccountListResponse>>(accounts);
            return new Response<List<GetAccountListResponse>>(mappedaccounts);
        }
    }
}
