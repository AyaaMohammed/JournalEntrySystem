using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.User.Queries.Results
{
    public class GetUserListResponse
    {
        public long User_ID { get; set; }
        public string UserName { get; set; }
    }
}
