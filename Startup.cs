using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploApiEF.Contexto;
using ExemploApiEF.Dominio.Repositorio;
using ExemploApiEF.Dominio.Servicos;
using ExemploApiEF.Infraestrutura.Dados;
using ExemploApiEF.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExemploApiEF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{
                    Title = "Cliente",
                    Version = "v1.0"
                });
            });

            services.AddDbContext<ContextoDb>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ClienteRepositorio>();
            services.AddScoped<ClienteServico>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clientes"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
