namespace Ionit.Receitas.Core.Context
{
    using Ionit.Receitas.Core.Configs;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System;

    /// <summary>
    /// A context to access the database.
    /// </summary>
    public class ContextMasterChefDesignTime : IDesignTimeDbContextFactory<ContextMasterChef>
    {
        #region Métodos

        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>An instance of ContextMasterChef.</returns>
        public ContextMasterChef CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ContextMasterChef>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            var appOption = new AppOption();
            configuration.GetSection("AppOptions").Bind(appOption);

            return new ContextMasterChef(Options.Create(appOption));
        }

        #endregion
    }
}
