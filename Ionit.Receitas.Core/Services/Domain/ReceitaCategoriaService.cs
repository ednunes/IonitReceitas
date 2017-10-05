namespace Ionit.Receitas.Core.Services.Domain
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Repositories;
    using Ionit.Receitas.Core.Interfaces.Services.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define a interface de serviço privada para Categoria da receita.
    /// </summary>
    public class ReceitaCategoriaService : IDomainService<ReceitaCategoria>
    {
        #region Variáveis

        /// <summary>
        /// Domínio de serviços 
        /// </summary>
        protected readonly ICommandRepository<ReceitaCategoria> _repository;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o repositório de Categoria da receita.
        /// </summary>
        /// <param name="repository">Repositório dos dados.</param>

        public ReceitaCategoriaService(ICommandRepository<ReceitaCategoria> repository)
        {
            _repository = repository;
        }

        #endregion

        /// <summary>
        /// Consultar Receita pelo id.
        /// </summary>
        /// <param name="id">Id da Receita para consultar.</param>
        /// <returns>Retorna uma Receita com o id passado ou null.</returns>
        public async Task<ReceitaCategoria> Consultar(int id)
        {
            return await _repository.Consultar(id);
        }

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de Receitas.</returns>
        public async Task<IEnumerable<ReceitaCategoria>> Listar()
        {
            return await _repository.Listar();
        }

        /// <summary>
        /// Realizar a inserção da Receita no banco de dados.
        /// </summary>
        /// <param name="entity">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da Receita.</returns>
        public async Task<int> Inserir(ReceitaCategoria entity)
        {
            return await _repository.Inserir(entity);
        }

        /// <summary>
        /// Realizar a alteração da Receita no banco de dados.
        /// </summary>
        /// <param name="entity">Receita a ser alterada.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da Receita.</returns>
        public async Task<int> Alterar(ReceitaCategoria entity)
        {
            return await _repository.Alterar(entity);
        }
    }
}
