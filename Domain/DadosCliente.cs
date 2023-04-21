using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class DadosCliente
    {

        [Key]
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public int? Agencia { get; set; }
        public int? ContaBancaria { get; set; }
        public decimal? Saldo { get; set; }


        public DadosCliente() { }
        public DadosCliente(string cpf, string nome, int agencia, int contaBancaria , decimal saldo)
        {
            Cpf = cpf;
            Nome = nome;
            Agencia = agencia;
            ContaBancaria = contaBancaria;           
            Saldo = saldo;
        }
    }
}
