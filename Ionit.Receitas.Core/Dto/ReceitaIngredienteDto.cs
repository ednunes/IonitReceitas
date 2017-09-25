namespace Ionit.Receitas.Core.Entities
{
    /// <summary>
    /// Definição do ingrediente da receita.
    /// </summary>
    public class ReceitaIngredienteDto
    {
        #region Propriedades

        /// <summary>
        /// Define o Id do ingrediente da receita.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define a descrição do ingrediente da receita.
        /// </summary>
        public string Descricao { get; set; }

        #endregion
    }
}
