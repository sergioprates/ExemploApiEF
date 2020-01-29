using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace ExemploApiEF.Api.Testes.Controllers
{
    public class ClienteControllerTestes
    {
        [Test]
        public async Task ObterClienteDeveRetornarDadosCorretamente()
        {
            var client = Variaveis.Client;

            var resposta = await client.GetAsync("v1/Cliente");

            var conteudo = await resposta.Content.ReadAsStringAsync();

            conteudo.Should().NotBeNullOrEmpty();
        }
    }
}