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

        public virtual Cliente Inserir(Cliente entidade)
        {
            return _unitOfWork.AplicacaoContextoApp.Set<Cliente>().Add(entidade).Entity;
        }

        public virtual Cliente Obter(int id)
        {
            return _unitOfWork.AplicacaoContextoApp.Set<Cliente>().Find(id);
        }
    }
}