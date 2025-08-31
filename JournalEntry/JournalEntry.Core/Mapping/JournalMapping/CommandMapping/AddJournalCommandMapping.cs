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
        public void AddJournalCommandMapping()
        {
            CreateMap<JournalDetailDto, JournalDetail>()
                .ForMember(dest => dest.DetailID, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
