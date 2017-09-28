namespace Ionit.Receitas.Core.Interfaces.Services.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Definição da interface de domínio do serviço.
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IDomainService<Entity> where Entity : class
    {
        #region Métodos

        /// <summary>
        /// Consultar Entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade para consultar.</param>
        /// <returns>Retorna uma entidade com o id passado ou null.</returns>
        Task<Entity> Consultar(int id);

        /// <summary>
        /// Lista de Entidades.
        /// </summary>
        /// <returns>Retorna uma lista de entidades.</returns>
        Task<IEnumerable<Entity>> Listar();

        /// <summary>
        /// Realizar a inserção da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        Task<int> Inserir(Entity entity);

        /// <summary>
        /// Realizar a alteração da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser alterada.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        Task<int> Alterar(Entity entity);

        #endregion
    }
}
