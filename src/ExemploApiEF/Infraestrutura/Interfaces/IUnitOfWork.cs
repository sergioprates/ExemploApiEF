using System;
using ExemploApiEF.Contexto;

namespace ExemploApiEF.Infraestrutura.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       ContextoDb ContextoApp { get; }

        public new void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            ContextoApp.SaveChanges();
        }
    }
}