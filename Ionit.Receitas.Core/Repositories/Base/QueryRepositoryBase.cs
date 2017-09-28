using Ionit.Receitas.Core.Configs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Repositories.Base
{
    public abstract class QueryRepositoryBase
    {
        public readonly IMongoClient MongoClient;
        public readonly IMongoDatabase MongoDatabase;

        public QueryRepositoryBase(IOptions<DbConfig> dbConfig)
        {
            MongoClient = new MongoClient(dbConfig.Value.QueryDb.ConnectionString);
            MongoDatabase = MongoClient.GetDatabase(dbConfig.Value.QueryDb.DatabaseName);
        }
    }
}
