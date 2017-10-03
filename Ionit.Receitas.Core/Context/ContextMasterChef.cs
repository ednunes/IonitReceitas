namespace Ionit.Receitas.Core.Context
{
    using Ionit.Receitas.Core.Configs;
    using Ionit.Receitas.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class ContextMasterChef : DbContext
    {
        #region Propriedades

        /// <summary>
        /// Gets or sets as Receitas.
        /// </summary>
        public DbSet<Receita> Receitas { get; set; }

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
        /// Configure the model of it's context database.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>().ToTable("Receita");
        }

        /// <summary>
        /// Configure the database of it's context.
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.Write("DIEGO");
            Console.Write(Option.ConnectionString);
            optionsBuilder.UseSqlServer(Option.ConnectionString);
        }

        #endregion
    }
}
