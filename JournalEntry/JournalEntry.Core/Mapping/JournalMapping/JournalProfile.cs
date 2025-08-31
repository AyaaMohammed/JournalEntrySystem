using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Mapping.JournalMapping
{
    public partial class JournalProfile:Profile
    {
        public JournalProfile()
        {
            AddJournalCommandMapping();
            DetailsJournalCommandMapping();
        }
    }
}
