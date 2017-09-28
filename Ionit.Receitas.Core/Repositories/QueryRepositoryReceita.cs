using Ionit.Receitas.Core.Configs;
using Ionit.Receitas.Core.Entities;
using Ionit.Receitas.Core.Interfaces.Repositories;
using Ionit.Receitas.Core.Repositories.Base;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Ionit.Receitas.Core.Repositories
{
    public class QueryRepositoryReceita : QueryRepositoryBase, IQueryRepository<Receita>
    {
        private readonly string MongoCollection = "receitas";

        public QueryRepositoryReceita(IOptions<DbConfig> dbConfig)
            :base(dbConfig)  {}

        public async Task<Receita> Consultar(int id)
        {
            var filter = new BsonDocument("Id", id);
            List<Receita> receitas = await MongoDatabase.GetCollection<Receita>(MongoCollection).Find(filter).Limit(1).ToListAsync();
            return receitas.FirstOrDefault();
        }

        public async Task<IEnumerable<Receita>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
