using Ionit.Receitas.Core.Configs;
using Ionit.Receitas.Core.Entities;
using Ionit.Receitas.Core.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Repositories
{
    public class QueryRepositoryReceita : IQueryRepository<Receita>
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public QueryRepositoryReceita(IOptions<DbConfig> dbConfig)
        {
            _client = new MongoClient(dbConfig.Value.QueryDb.ConnectionString);
            _database = _client.GetDatabase(dbConfig.Value.QueryDb.DatabaseName);
        }

        public Receita Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receita> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
