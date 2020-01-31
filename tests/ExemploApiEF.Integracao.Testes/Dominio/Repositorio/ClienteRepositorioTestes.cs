using System.Threading.Tasks;
using ExemploApiEF.Dominio.Modelo;
using ExemploApiEF.Dominio.Repositorio;
using ExemploApiEF.Infraestrutura.Dados;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ExemploApiEF.Integracao.Testes.Dominio.Repositorio
{
    public class ClienteRepositorioTestes 
    {
        private ClienteRepositorio _repositorio;

        [SetUp]
        public void Inicializar()
        {
            _repositorio = new ClienteRepositorio(Variaveis.UnitOfWork);
        }
        
        [Test]
        public void InserirDeveCadastrarDadosCorretamente()
        {
            var cliente = new Cliente()
            {
                Nome =  "Sergio"
            };
            
            var retorno =_repositorio.Inserir(cliente);
            Variaveis.UnitOfWork.Commit();

            var clienteCadastrado = _repositorio.Obter(retorno.Id);
            
            clienteCadastrado.Should().NotBeNull();
            clienteCadastrado.Id.Should().Be(retorno.Id);
            clienteCadastrado.Nome.Should().Be(cliente.Nome);
        }
    }
}