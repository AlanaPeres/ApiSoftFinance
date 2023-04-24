using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost("{cpf}")]
        public async Task<ActionResult> Transferencia(Transacao transacao, string cpfDestino, string cpf)
        {
            try
            {
                var sender = await _context.Contas.SingleOrDefaultAsync(c => c.Cpf == cpf);
                var receiver = await _context.Contas.SingleOrDefaultAsync(c => c.Cpf == cpfDestino);

                if (sender == null || receiver == null) return BadRequest("Conta inválida.");
                if (sender.Saldo < transacao.Valor) return BadRequest("Saldo insuficiente");

                sender.Saldo -= transacao.Valor;
                receiver.Saldo += transacao.Valor;

                _context.Entry(sender).State = EntityState.Modified;
                _context.Entry(receiver).State = EntityState.Modified;
                _context.SaveChanges();
                var comprovanteTransacao = new { receiver.Nome, receiver.Agencia, receiver.ContaBancariaId, transacao.Valor };
                return StatusCode(StatusCodes.Status201Created, comprovanteTransacao);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");

            }
        }

        [HttpPost]
        public async Task<ActionResult> Deposito(Transacao transacao, string cpf)
        {
            try
            {
                var cliente = await _context.Contas.SingleOrDefaultAsync(c => c.Cpf == cpf);

                if (cliente is null) return BadRequest("Conta inválida.");

                cliente.Saldo += transacao.Valor;
                object value = _context.Transacoes.Add(transacao);
                _context.SaveChanges();
                var comprovanteDeposito = new { cliente.Agencia, cliente.ContaBancariaId, transacao.Valor };
                return StatusCode(StatusCodes.Status201Created, comprovanteDeposito);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }

        }
    }
}
