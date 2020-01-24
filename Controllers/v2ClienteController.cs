using ExemploApiEF.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ExemploApiEF.Controllers
{
    public partial class ClienteController 
    {
        [HttpGet]
        [MapToApiVersion( "2.0" )]
        public IActionResult ObterV2()
        {
            return Ok(new { id = 20});
        }
    }
}