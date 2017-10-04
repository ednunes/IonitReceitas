namespace Ionit.Receitas.Core.Interfaces.Services.Application
{
    using Ionit.Receitas.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Definição da interface de aplicação pública do serviço de Receita.
    /// </summary>
    public interface IReceitaAppService
    {
        #region Métodos

        /// <summary>
        /// Consultar Entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade para consultar.</param>
        /// <returns>Retorna uma entidade com o id passado ou null.</returns>
        Task<ReceitaDto> Consultar(int id);

        /// <summary>
        /// Realizar a inserção da receita no banco de dados.
        /// </summary>
        /// <param name="dto">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        Task<int> Inserir(ReceitaDto dto);

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de receitas.</returns>
        Task<IEnumerable<ReceitaDto>> Listar();

        #endregion
    }
}
