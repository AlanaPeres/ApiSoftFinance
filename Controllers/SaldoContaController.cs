using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSoftFinance.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SaldoContaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaldoContaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaldoConta>> Get()
        {
            try
            {
                var saldo = _context.BuscaSaldo.ToList();
                if (saldo is null) return NotFound("Clientes não encontrados.");
                return saldo;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
    }
}
