﻿namespace Ionit.Receitas.Core.Context
{
    using Ionit.Receitas.Core.Configs;
    using Ionit.Receitas.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Context of Database.
    /// </summary>
    public class ContextMasterChef : DbContext
    {
        #region Propriedades

        /// <summary>
        /// Gets or sets as Receitas.
        /// </summary>
        public DbSet<Receita> Receitas { get; set; }

        /// <summary>
        /// Gets or sets as Categorias.
        /// </summary>
        public DbSet<ReceitaCategoria> Categorias { get; set; }

        /// <summary>
        /// Gets or sets os Ingredientes.
        /// </summary>
        public DbSet<ReceitaIngrediente> Ingredientes { get; set; }

        /// <summary>
        /// Sets the current option.
        /// </summary>
        public AppOption Option { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes the context of database.
        /// </summary>
        /// <param name="option">The option.</param>
        public ContextMasterChef(IOptions<AppOption> option)
        {
            Option = option.Value;
        }

        #endregion

        #region Métodos
        
        /// <summary>
        /// Configure the database of it's context.
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Option.ConnectionString);
        }

        #endregion
    }
}
