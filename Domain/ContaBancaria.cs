using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class ContaBancaria 
    {
        public int Agencia { get; set; }
        [Key]
        public int ContaBancariaId { get; set; }
        public string? Nome { get; set; }
        [ForeignKey("Cpf")]
        public string? Cpf { get; set; }
        public decimal? Saldo { get; set; }
        
    }

}
