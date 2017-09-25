namespace Ionit.Receitas.Core.Entities
{
    /// <summary>
    /// Definição das tags da receita.
    /// </summary>
    public class ReceitaTagDto
    {
        #region Propriedades

        /// <summary>
        /// Define o Id da tag da receita.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define o nome da tag da receita.
        /// </summary>
        public string Nome { get; set; }

        #endregion
    }
}
