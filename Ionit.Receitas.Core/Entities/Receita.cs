namespace Ionit.Receitas.Core.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Definição da receita
    /// </summary>
    public class Receita
    {
        public Receita()
        {

        }

        #region Propriedades

        /// <summary>
        /// Define o id da receita.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define o título da receita.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Define o tempo de preparo em minutos.
        /// </summary>
        public int TempoPreparo { get; set; }

        /// <summary>
        /// Define o rendimento em porções da receita.
        /// </summary>
        public int RendimentoPorcao { get; set; }

        /// <summary>
        /// Define a categoria da receita.
        /// </summary>
        public ReceitaCategoria Categoria { get; set; }

        /// <summary>
        /// Define a lista de ingredientes.
        /// </summary>
        public IEnumerable<ReceitaIngrediente> Ingredientes { get; set; }

        /// <summary>
        /// Define a lista de tags.
        /// </summary>
        public IEnumerable<ReceitaTag> Tags { get; set; }

        /// <summary>
        /// Define a lista de curtidas.
        /// </summary>
        public IEnumerable<ReceitaCurtida> Curtidas { get; set; }

        #endregion
    }
}
