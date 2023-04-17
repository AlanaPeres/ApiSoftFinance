using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string?  Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [ForeignKey("ContaBancaria")] 
        public int ContaBancariaId { get; set; }
        public ContaBancaria? ContaBancaria { get; set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string email, ContaBancaria conta, string cep, string rua, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            ContaBancaria = conta;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }


        



    }
}
