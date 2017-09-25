namespace Ionit.Receitas.Core.Data
{
    using Ionit.Receitas.Core.Context;
    using Ionit.Receitas.Core.Entities;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ContextMasterChef context)
        {
            context.Database.EnsureCreated();
            
            if (!context.Receitas.Any())
            {
                context.AddRange(new Receita[]
                {
                    new Receita{ Titulo = "" }
                });

                context.SaveChanges();
            }
        }
    }
}
