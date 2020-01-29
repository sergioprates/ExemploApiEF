using ExemploApiEF.Contexto;
using ExemploApiEF.Infraestrutura.Interfaces;

namespace ExemploApiEF.Infraestrutura.Dados
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ContextoDb context)
        {
            ContextoApp = context;
        }

        public ContextoDb ContextoApp { get; }

        public void Commit()
        {
            ContextoApp.SaveChanges();
        }

        public void Dispose()
        {
            ContextoApp.Dispose();
        }
    }
}