using System;
using NUnit.Framework;
using ExemploApiEF.Contexto;
using ExemploApiEF.Infraestrutura.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploApiEF.Integracao.Testes
{
    [SetUpFixture]
    public class TesteRepositorio
    {
        [OneTimeSetUp]
        public void InicializarInfraestrutura()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            Variaveis.Configuration = new ConfigurationBuilder()
                .SetBasePath(DiretorioSolution.ObterDiretorioDosAssemblys())
                .AddJsonFile("appsettings.Testing.json").Build();
            
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AplicacaoContexto>();
            dbContextOptionsBuilder
                .UseSqlServer(Variaveis.Configuration.GetConnectionString("DefaultConnection").Replace("BANCO", $"Mercado_{Guid.NewGuid()}"))
                .UseInternalServiceProvider(serviceProvider);
            
            Variaveis.Contexto = new AplicacaoContexto(dbContextOptionsBuilder.Options);
            Variaveis.UnitOfWork = new UnitOfWork(Variaveis.Contexto);
            Variaveis.Contexto.Database.Migrate();
        }

        [OneTimeTearDown]
        public void FinalizarInfraestrutura()
        {
            Variaveis.Contexto.Database.EnsureDeleted();
        }
    }
}