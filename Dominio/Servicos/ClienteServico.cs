using ExemploApiEF.Dominio.Modelo;
using ExemploApiEF.Dominio.Repositorio;
using ExemploApiEF.Infraestrutura.Interfaces;

namespace ExemploApiEF.Dominio.Servicos
{
    public class ClienteServico
    {
        private IUnitOfWork _unitOfWork;
        private ClienteRepositorio _clienteRepositorio;

        public ClienteServico(IUnitOfWork unitOfWork, ClienteRepositorio clienteRepositorio)
        {
           _unitOfWork = unitOfWork;
           _clienteRepositorio = clienteRepositorio;
        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            var clienteRetorno =_clienteRepositorio.Inserir(cliente);
            _unitOfWork.Commit();
            
            return clienteRetorno;
        }
    }
}