using ApiSoftFinance.Context;
using ApiSoftFinance.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ApiSoftFinance.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExtratoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExtratoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{cpf}")]
        public async Task<ActionResult<IEnumerable<Extrato>>> GetExtrato(string cpf, string mesAno)
        {
            var sql = $@"SELECT  e.id, e.cpf, e.contaorigem, e.cpfdestino, 
		     e.contadestino, e.tipotransacao, e.data,
             (CASE
                WHEN (e.tipotransacao = 'P') THEN COALESCE(e.Valor, 0) * -(1)
                WHEN (e.tipotransacao = 'R') THEN COALESCE(e.Valor, 0)
                WHEN (e.tipotransacao = 'T' and e.cpf = {cpf}) THEN COALESCE(e.Valor, 0) * -(1)
                WHEN (e.tipotransacao = 'T' and e.cpfDestino = {cpf}) THEN COALESCE(e.Valor, 0)
            END) AS valor 
            FROM extrato e 
            where (e.Cpf = {cpf} or e.CpfDestino = {cpf}) and DATE_FORMAT(e.datahora,'%m-%Y') = '{mesAno}' ";


            var extrato = await _context.Extrato
                .FromSqlInterpolated(FormattableStringFactory.Create(sql))
                .ToListAsync();

            return extrato.Select(t => new Extrato
            {
                Id = t.Id,
                ContaOrigem = t.ContaOrigem,
                ContaDestino = t.ContaDestino,
                Data= t.Data,
                Valor = t.Valor
            }).ToList();
        }
    }
}
