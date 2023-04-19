using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSoftFinance.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ContaBancaria>> Get()
        {
            try
            {
                var contas = _context.Contas.ToList();
                if (contas is null) return NotFound("Contas não encontradas.");
                return contas;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
        [HttpGet("{cpf}")]
        public ActionResult<ContaBancaria> Get(string cpf)
        {
            try
            {
                var conta = _context.Contas.FirstOrDefault(c => c.Cpf == cpf);
                if (conta is null) return NotFound("Conta não encontrada");
                return conta;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }

        [HttpPost]
        public ActionResult Post(ContaBancaria conta)
        {
            try
            {
                if (conta is null) return BadRequest("Conta inválida.");
                _context.Contas.Add(conta);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, conta);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
        [HttpPut("{cpf}")]
        public ActionResult Put(string cpf, ContaBancaria conta)
        {
            try
            {
                if (cpf != conta.Cpf) return BadRequest("Cliente não encontrado");
                _context.Entry(conta).State = EntityState.Modified;
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, conta);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
        [HttpDelete("{cpf}")]
        public ActionResult Delete(string cpf)
        {
            try
            {
                var conta = _context.Contas.FirstOrDefault(c => c.Cpf == cpf);
                if (conta is null) return BadRequest("Cliente não encontrado");
                _context.Contas.Remove(conta);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }
    }


}
