using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class Transacao
    {
        [ForeignKey("CPF")]
        [StringLength(14, MinimumLength = 11)]       
        public string? Cpf { get; set; }
        [Key]
        public int Id { get; set; }
        [StringLength(14, MinimumLength = 11)]
        public string CpfDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }        
        public char TipoTransacao { get; set; }
    }
}
