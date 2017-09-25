namespace Ionit.Receitas.Core.Context
{
    using Ionit.Receitas.Core.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public class ContextMasterChef : DbContext
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Receita> Receitas { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ContextMasterChef(DbContextOptions<ContextMasterChef> options) : base(options)
        {
        }

        #endregion

        #region Métodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>().ToTable("Receita");
        }

        #endregion
    }
}
