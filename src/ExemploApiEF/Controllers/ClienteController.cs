using ExemploApiEF.Dominio.Modelo;
using ExemploApiEF.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ExemploApiEF.Controllers
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [ApiVersion( "2.0" )]
    [Route( "v{version:apiVersion}/[controller]" )]
    public partial class ClienteController : ControllerBase
    {
        private ClienteServico _clienteServico;

        public ClienteController(ClienteServico clienteServico)
        {
            _clienteServico = clienteServico;   
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            var clienteRetorno =_clienteServico.CadastrarCliente(cliente);

            return Ok(new {dados = new {id = clienteRetorno.Id}, notificacoes = new string[] {}});
        }

        [HttpGet]
        [MapToApiVersion( "1.0" )]
        public IActionResult Obter()
        {
            return Ok(new { id = 10});
        }
    }
}