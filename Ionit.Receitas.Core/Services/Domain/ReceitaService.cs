namespace Ionit.Receitas.Core.Services.Domain
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Repositories;
    using Ionit.Receitas.Core.Interfaces.Services.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define a interface de serviço privada para Receita.
    /// </summary>
    public class ReceitaService : IDomainService<Receita>
    {
        #region Variáveis

        /// <summary>
        /// Domínio de serviços 
        /// </summary>
        protected ICommandRepository<Receita> _repository;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o repositório de Receita.
        /// </summary>
        /// <param name="repository">Repositório dos dados.</param>

        public ReceitaService(ICommandRepository<Receita> repository)
        {
            _repository = repository;
        }

        #endregion

        /// <summary>
        /// Consultar Receita pelo id.
        /// </summary>
        /// <param name="id">Id da Receita para consultar.</param>
        /// <returns>Retorna uma Receita com o id passado ou null.</returns>
        public async Task<Receita> Consultar(int id)
        {
            return await _repository.Consultar(id);
        }

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de Receitas.</returns>
        public async Task<IEnumerable<Receita>> Listar()
        {
            return await _repository.Listar();
        }

        /// <summary>
        /// Realizar a inserção da Receita no banco de dados.
        /// </summary>
        /// <param name="entity">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da Receita.</returns>
        public async Task<int> Inserir(Receita entity)
        {
            return await _repository.Inserir(entity);
        }

        /// <summary>
        /// Realizar a alteração da Receita no banco de dados.
        /// </summary>
        /// <param name="entity">Receita a ser alterada.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da Receita.</returns>
        public async Task<int> Alterar(Receita entity)
        {
            return await _repository.Alterar(entity);
        }
    }
}
