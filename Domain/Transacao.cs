using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class Transacao
    {
        [ForeignKey("CPF")]
        public string? Cpf { get; set; }
        [Key]
        public int Id { get; set; }
        public string CpfDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }        
        public TipoTransacao? TipoTransacao { get; set; }
    }
}
