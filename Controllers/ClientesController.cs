using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace ApiSoftFinance.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Random _random;
        public ClientesController(AppDbContext context)
        {
            _context = context;
            _random = new Random(DateTime.Now.Millisecond);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            try
            {
                var clientes = _context.Clientes.ToList();
                if (clientes is null) return NotFound("Clientes não encontrados.");
                return clientes;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }

        [HttpGet("{cpf}")]
        public ActionResult<Cliente>Get(string cpf)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Cpf == cpf);
                if (cliente is null) return NotFound("Cliente não encontrado");
                return cliente;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            try
            {
                if (cliente is null) return BadRequest("Dados inválidos.");

                var novaConta = new ContaBancaria();
                int numeroConta;
                
                do
                {
                    numeroConta = _random.Next(100000, 999999); // Gera um número de 6 dígitos
                } while (_context.Contas.Any(c => c.ContaBancariaId == numeroConta)); // Verifica se o número já foi utilizado

                novaConta.Agencia = 1515;
                novaConta.ContaBancariaId = numeroConta;
                novaConta.Cpf = cliente.Cpf;
                novaConta.Nome = cliente.Nome;
                novaConta.Saldo = 000;

                _context.Clientes.Add(cliente);
                _context.Contas.Add(novaConta);              
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua requisição.");
            }
        }

        [HttpPut("{cpf}")]
        public ActionResult Put(string cpf, Cliente cliente)
        {
            try
            {
                if (cpf != cliente.Cpf) return BadRequest("Cliente não encontrado");
                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, cliente);
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
                var cliente = _context.Clientes.FirstOrDefault(c => c.Cpf == cpf);
                if (cliente is null) return BadRequest("Cliente não encontrado");
                _context.Clientes.Remove(cliente);
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
