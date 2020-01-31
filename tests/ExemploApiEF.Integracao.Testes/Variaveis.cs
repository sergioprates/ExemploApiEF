using ExemploApiEF.Contexto;
using ExemploApiEF.Infraestrutura.Dados;
using Microsoft.Extensions.Configuration;

namespace ExemploApiEF.Integracao.Testes
{
    public static class Variaveis
    {
        
        public static AplicacaoContexto Contexto;
        public static UnitOfWork UnitOfWork;
        public static IConfigurationRoot Configuration { get; set; }
    }
}