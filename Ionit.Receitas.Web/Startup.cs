using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ionit.Receitas.Core.Context;
using Microsoft.EntityFrameworkCore;
using Ionit.Receitas.Core.Repositories;
using Ionit.Receitas.Core.Entities;
using Ionit.Receitas.Core.Interfaces.Repositories;
using Ionit.Receitas.Core.Interfaces.Services.Domain;
using Ionit.Receitas.Core.Interfaces.Services.Application;
using Ionit.Receitas.Core.Services.Application;
using Ionit.Receitas.Core.Services.Domain;
using Ionit.Receitas.Core.Configs;

namespace Ionit.Receitas.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppOption>(Configuration.GetSection("AppOptions"));
            services.AddEntityFrameworkSqlServer().AddDbContext<ContextMasterChef>(ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            services.AddScoped<ICommandRepository<Receita>, CommandRepositoryReceita>();
            services.AddScoped<IDomainService<Receita>, ReceitaService>();
            services.AddScoped<IReceitaAppService, ReceitaAppService>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Receitas}/{action=Index}/{id?}");
            });
        }
    }
}
