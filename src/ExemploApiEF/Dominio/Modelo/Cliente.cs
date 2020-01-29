using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploApiEF.Dominio.Modelo
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Nome { get; set; }
    }
}