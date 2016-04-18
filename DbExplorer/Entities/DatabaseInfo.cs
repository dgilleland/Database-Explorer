using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExplorer.Entities
{
    public class DatabaseInfo
    {
        public const string Query = "EXEC sp_databases";
        public string DATABASE_NAME { get; set; }
        public int DATABASE_SIZE { get; set; }
        public string REMARKS { get; set; }
    }
}
