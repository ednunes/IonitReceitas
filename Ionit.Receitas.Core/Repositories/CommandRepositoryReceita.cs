namespace Ionit.Receitas.Core.Repositories
{
    using Ionit.Receitas.Core.Context;
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Repositories;
    using System.Collections.Generic;

    /// <summary>
    /// Definição da interface do repositório.
    /// </summary>
    public class CommandRepositoryReceita : ICommandRepository<Receita>
    {
        #region Variáveis

        /// <summary>
        /// Define o context do banco de dados. 
        /// </summary>
        protected readonly ContextMasterChef _context;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o contexto da Receita.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>

        public CommandRepositoryReceita(ContextMasterChef context)
        {
            _context = context;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consultar Entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade para consultar.</param>
        /// <returns>Retorna uma entidade com o id passado ou null.</returns>
        public Receita Consultar(int id)
        {
            return _context.Find<Receita>(id);
        }

        /// <summary>
        /// Lista de Entidades.
        /// </summary>
        /// <returns>Retorna uma lista de entidades.</returns>
        public IEnumerable<Receita> Listar()
        {
            return _context.Set<Receita>();
        }

        /// <summary>
        /// Realizar a inserção da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public int Inserir(Receita entity)
        {
            return _context.Add(entity)?.Entity?.Id ?? 0;
        }

        /// <summary>
        /// Realizar a alteração da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser alterada.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public int Alterar(Receita entity)
        {
            return _context.Update(entity)?.Entity?.Id ?? 0;
        }

        #endregion
    }
}
