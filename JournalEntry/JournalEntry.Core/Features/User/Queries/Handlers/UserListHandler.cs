using AutoMapper;
using JournalEntry.Core.Bases;
using JournalEntry.Core.Features.User.Queries.Models;
using JournalEntry.Core.Features.User.Queries.Results;
using JournalEntry.Infrastructure.InfrastructureBases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.User.Queries.Handlers
{
    public class UserListHandler:IRequestHandler<GetUserListQuery,Response<List<GetUserListResponse>>>
    {
        IMapper _mapper;
        IGenericRepositoryAsync<Data.Models.User> _userRepository;
        public UserListHandler(IMapper mapper,IGenericRepositoryAsync<Data.Models.User> genericRepository)
        {
            _mapper = mapper;
            _userRepository = genericRepository;
        }   
        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetTableNoTracking().ToList();  
            var mappedUsers = _mapper.Map<List<GetUserListResponse>>(users);
            return new Response<List<GetUserListResponse>>(mappedUsers);

        }
    }
}
