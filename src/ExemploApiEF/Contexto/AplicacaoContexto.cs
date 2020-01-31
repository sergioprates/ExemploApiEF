using ExemploApiEF.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ExemploApiEF.Contexto
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable(nameof(Cliente)).HasKey(x=> x.Id);
        }
    }
}