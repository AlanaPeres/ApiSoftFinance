using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSoftFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{cpf}")]
        public ActionResult<Transacao> Get(string cpf)
        {
            try
            {
                var transacao = _context.Transacoes.FirstOrDefault(c => c.Cpf == cpf);
                if (transacao is null) return NotFound("Conta não encontrada");
                return transacao;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }

        [HttpPost]
        public ActionResult Post(Transacao transacao)
        {
            try
            {
                if (transacao is null) return BadRequest("Conta inválida.");
                object value = _context.Transacoes.Add(transacao);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, transacao);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
    }
}
