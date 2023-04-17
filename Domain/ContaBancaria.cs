using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class ContaBancaria 
    {
        [Key]
        public int Id { get;}
        public int Agencia { get; set; }
        public int ContaBancariaId { get; set; }
        [ForeignKey("ClienteId")] // Atributo diretamente na propriedade de chave estrangeira
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public string? Senha { get; set; }
        public decimal Saldo { get; set; }

      
    }

}
