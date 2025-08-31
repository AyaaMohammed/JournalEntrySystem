using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "v1";
        public const string Rule = $"{root}/{version}";

        public static class AccountRouting
        {
            public const string Prefix = $"{Rule}/Account";
            public const string GetAll = $"{Prefix}/GetAll";
        }
        public static class UserRouting
        {
            public const string Prefix = $"{Rule}/User";
            public const string GetAll = $"{Prefix}/GetAll";
        }
        public static class JournalRouting
        {
            public const string Prefix = $"{Rule}/Journal";
            public const string Add = $"{Prefix}/Add";
            public const string Print = $"{Prefix}/Print/{{journalId}}";
        }

    }
}
