namespace Ionit.Receitas.Core.Repositories
{
    using Ionit.Receitas.Core.Context;
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Definição da interface do repositório.
    /// </summary>
    public class CommandRepositoryReceitaCategoria : ICommandRepository<ReceitaCategoria>
    {
        #region Variáveis

        /// <summary>
        /// Define o context do banco de dados. 
        /// </summary>
        protected ContextMasterChef _context;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o contexto da Categoria da receita.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>

        public CommandRepositoryReceitaCategoria(ContextMasterChef context)
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
        public async Task<ReceitaCategoria> Consultar(int id)
        {
            return await _context.FindAsync<ReceitaCategoria>(id);
        }

        /// <summary>
        /// Lista de Entidades.
        /// </summary>
        /// <returns>Retorna uma lista de entidades.</returns>
        public async Task<IEnumerable<ReceitaCategoria>> Listar()
        {
            return await _context.Categorias.ToListAsync();
        }

        /// <summary>
        /// Realizar a inserção da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public async Task<int> Inserir(ReceitaCategoria entity)
        {   
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result?.Entity?.Id ?? 0;
        }

        /// <summary>
        /// Realizar a alteração da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser alterada.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public async Task<int> Alterar(ReceitaCategoria entity)
        {
            var result = _context.Update(entity);
            await _context.SaveChangesAsync();

            return result?.Entity?.Id ?? 0;
        }

        #endregion
    }
}
