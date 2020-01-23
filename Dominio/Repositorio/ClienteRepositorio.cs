using ExemploApiEF.Contexto;
using ExemploApiEF.Dominio.Modelo;
using ExemploApiEF.Infraestrutura.Interfaces;

namespace ExemploApiEF.Dominio.Repositorio
{
    public class ClienteRepositorio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteRepositorio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Cliente Inserir(Cliente entidade)
        {
            return _unitOfWork.ContextoApp.Set<Cliente>().Add(entidade).Entity;
        }
    }
}