using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploApiEF.Dominio.Modelo
{
    public class Cliente
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
    }
}