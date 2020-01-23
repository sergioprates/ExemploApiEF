using ExemploApiEF.Dominio.Modelo;
using ExemploApiEF.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ExemploApiEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
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
    }
}