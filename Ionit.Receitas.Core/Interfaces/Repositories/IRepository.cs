namespace Ionit.Receitas.Core.Interfaces.Repositories
{
    using System.Collections.Generic;

    /// <summary>
    /// Definição da interface do repositório.
    /// </summary>
    public interface IRepository<Entity>
    {
        #region Métodos

        /// <summary>
        /// Consultar Entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade para consultar.</param>
        /// <returns>Retorna uma entidade com o id passado ou null.</returns>
        Entity Consultar(int id);

        /// <summary>
        /// Lista de Entidades.
        /// </summary>
        /// <returns>Retorna uma lista de entidades.</returns>
        IEnumerable<Entity> Listar();

        /// <summary>
        /// Realizar a inserção da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        int Inserir(Entity entity);

        /// <summary>
        /// Realizar a alteração da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser alterada.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        int Alterar(Entity entity);

        #endregion
    }
}
