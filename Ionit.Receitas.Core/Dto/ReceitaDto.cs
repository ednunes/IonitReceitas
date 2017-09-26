namespace Ionit.Receitas.Core.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Definição da receita
    /// </summary>
    public class ReceitaDto
    {
        #region Propriedades

        /// <summary>
        /// Define o id da receita.
        /// </summary>
        public virtual int Id { get; set; }

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
        public ReceitaCategoriaDto Categoria { get; set; }

        /// <summary>
        /// Define a lista de ingredientes.
        /// </summary>
        public IEnumerable<ReceitaIngredienteDto> Ingredientes { get; set; }

        /// <summary>
        /// Define a lista de tags.
        /// </summary>
        public IEnumerable<ReceitaTagDto> Tags { get; set; }

        /// <summary>
        /// Define a lista de curtidas.
        /// </summary>
        public IEnumerable<ReceitaCurtidaDto> Curtidas { get; set; }

        #endregion
    }
}
