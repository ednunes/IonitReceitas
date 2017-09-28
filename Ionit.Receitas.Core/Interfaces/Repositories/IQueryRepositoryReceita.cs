using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Interfaces.Repositories
{
    public interface IQueryRepositoryReceita<Entity>
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

        #endregion
    }
}
