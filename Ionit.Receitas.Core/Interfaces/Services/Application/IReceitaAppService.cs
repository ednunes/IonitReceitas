namespace Ionit.Receitas.Core.Interfaces.Services.Application
{
    using Ionit.Receitas.Core.Dto;
    using System.Collections.Generic;

    /// <summary>
    /// Definição da interface de aplicação pública do serviço de Receita.
    /// </summary>
    public interface IReceitaAppService
    {
        #region Métodos

        /// <summary>
        /// Realizar a inserção da receita no banco de dados.
        /// </summary>
        /// <param name="dto">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        int Inserir(ReceitaDto dto);

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de receitas.</returns>
        IEnumerable<ReceitaConsultaCompletaDto> Listar();

        #endregion
    }
}
