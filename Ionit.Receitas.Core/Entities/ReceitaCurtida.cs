namespace Ionit.Receitas.Core.Entities
{
    /// <summary>
    /// Definição da curtida da receita
    /// </summary>
    public class ReceitaCurtida
    {
        #region Propriedades

        /// <summary>
        /// Define o id da receita like.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define o usuário da receita like.
        /// </summary>
        public string Usuario { get; set; }

        #endregion
    }
}
