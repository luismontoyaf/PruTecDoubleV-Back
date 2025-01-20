using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using MyBack.Services;
using MyBack.Models;

namespace MyBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clienteService;

        public ClientsController(IClientService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            List<Client> clientes = _clienteService.GetAllClientes();

            return Ok(clientes);
        }
    }
}
