using AutoMapper;
using JournalEntry.Core.Bases;
using JournalEntry.Core.Features.Journal.Commands.Models;
using JournalEntry.Data.Models;
using JournalEntry.Service.Abstracts;
using MediatR;
using System.Reflection.PortableExecutable;


namespace JournalEntry.Core.Features.Journal.Commands.Handlers
{
    public class JournalCommandHandler : IRequestHandler<AddJournalCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IJournalService _journalService;

        public JournalCommandHandler(IMapper mapper, IJournalService journalService)
        {
            _mapper = mapper;
            _journalService = journalService;
        }

        public async Task<Response<string>> Handle(AddJournalCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<JournalHeader>(request);
            entity.JournalDetails = _mapper.Map<List<JournalDetail>>(request.JournalDetails);


            var result = await _journalService.AddAsync(entity);

            if (!result.Success)
            {
                return new Response<string>
                {
                    Data = string.Empty,
                    Message = result.ErrorMessage,
                    Succeeded = false
                };
            }
            return new Response<string>
            {
                Data = entity.JournalID.ToString(), 
                Message = "Journal created successfully",
                Succeeded = true
            };
        }
    }
}
//{
//    "systemNo": "string",
//  "entryDate": "2025-08-31T00:42:51.987Z",
//  "transactionType": "string",
//  "documentNo": "string",
//  "description": "string",
//  "user_ID": 1,  
//  "filePath": "string",
//  "journalDetails": [
//    {
//        "accountID": "18c5331a-0c2d-467d-95c7-0523d9eaad63",
//      "accountNumber": "string",
//      "accountName": "string",
//      "lineDescription": "string",
//      "reportDescription": "string",
//      "debit": 10,
//      "credit": 0
//    },
//    {
//        "accountID": "4959b1ab-e31c-4163-9db4-05aed93f01d5",
//      "accountNumber": "string",
//      "accountName": "string",
//      "lineDescription": "string",
//      "reportDescription": "string",
//      "debit": 0,
//      "credit": 10
//    }
//  ]
//}
