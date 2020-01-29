using ExemploApiEF.Dominio.Modelo;
using ExemploApiEF.Dominio.Repositorio;
using ExemploApiEF.Dominio.Servicos;
using ExemploApiEF.Infraestrutura.Interfaces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ExemploApiEF.Testes.Dominio.Servicos
{
    public class ClienteServicoTestes
    {
        private Cliente _cliente;
        private ClienteRepositorio _repositorio;
        private ClienteServico _servico;
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Inicializar()
        {
            _repositorio = A.Fake<ClienteRepositorio>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            _servico = new ClienteServico(_unitOfWork, _repositorio);
            _cliente = new Cliente
            {
                Id = 1,
                Nome = "Teste"
            };
        }

        [Test]
        public void CadastrarClienteDeveChamarInserirEComitarDados()
        {
            A.CallTo(() => _repositorio.Inserir(A<Cliente>.That.IsNotNull())).Returns(_cliente);

            _servico.CadastrarCliente(_cliente);

            A.CallTo(() => _unitOfWork.Commit()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CadastrarClienteDeveRetornarClienteCadastrado()
        {
            A.CallTo(() => _repositorio.Inserir(A<Cliente>.That.IsNotNull())).Returns(_cliente);
            var retorno = _servico.CadastrarCliente(_cliente);

            retorno.Should().Be(_cliente);
        }
    }
}