using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class SaldoConta
    {

        [Key]
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string? Cpf { get; set; }
        public decimal? Saldo { get; set; }


        public SaldoConta() { }
        public SaldoConta(string cpf, decimal saldo)
        {
            Cpf = cpf;
            Saldo = saldo;
        }
    }
}
