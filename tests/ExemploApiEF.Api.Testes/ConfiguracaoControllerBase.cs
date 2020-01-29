using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace ExemploApiEF.Api.Testes
{
    [SetUpFixture]
    public class ConfiguracaoControllerBase
    {
        [OneTimeSetUp]
        public void Inicializar()
        {
            var hostBuilder = new WebApplicationFactory<Startup>();

            Variaveis.Client = hostBuilder.CreateDefaultClient();
        }
    }
}