using System;
using ExemploApiEF.Contexto;

namespace ExemploApiEF.Infraestrutura.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       AplicacaoContexto AplicacaoContextoApp { get; }

        public new void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            AplicacaoContextoApp.SaveChanges();
        }
    }
}