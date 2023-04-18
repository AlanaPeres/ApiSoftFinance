using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class Cliente
    {

        [Key]
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string?  Cpf { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Nome { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
       

        public Cliente() { }
        public Cliente(string nome, string cpf, DateTime dataNascimento, string email, string cep, string rua, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;       
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
