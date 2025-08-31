using JournalEntry.Core.Features.Journal.Commands.Models;
using JournalEntry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Mapping.JournalMapping
{
    public partial class JournalProfile
    {
        public  void DetailsJournalCommandMapping()
        {
            CreateMap<AddJournalCommand, JournalHeader>()
                .ForMember(dest => dest.JournalID, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType))
                .ForMember(dest => dest.Creation_Date, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));

        }
    }
}
