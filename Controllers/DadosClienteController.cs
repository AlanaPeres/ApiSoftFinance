using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSoftFinance.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DadosClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DadosClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DadosCliente>> Get()
        {
            try
            {
                var dadosClientes = _context.dadosCliente.ToList();
                if (dadosClientes is null) return NotFound("Clientes não encontrados.");
                return dadosClientes;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
    }
}
