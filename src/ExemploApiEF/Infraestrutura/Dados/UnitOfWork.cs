using ExemploApiEF.Contexto;
using ExemploApiEF.Infraestrutura.Interfaces;

namespace ExemploApiEF.Infraestrutura.Dados
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AplicacaoContexto context)
        {
            AplicacaoContextoApp = context;
        }

        public AplicacaoContexto AplicacaoContextoApp { get; }

        public void Commit()
        {
            AplicacaoContextoApp.SaveChanges();
        }

        public void Dispose()
        {
            AplicacaoContextoApp.Dispose();
        }
    }
}