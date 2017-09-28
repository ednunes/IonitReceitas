using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Configs
{
    public class DbConfig
    {
        public QueryDbConfig QueryDb { get; set; }
        public CommandDbConfig CommandDb { get; set; }

        public class QueryDbConfig
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public class CommandDbConfig
        {
            public string ConnectionString { get; set; }
        }
    } 
}
