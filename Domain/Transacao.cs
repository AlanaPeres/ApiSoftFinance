using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey("TipoTransacaoId")]
        public int TipoTransacaoId { get; set; }
        public TipoTransacao? TipoTransacao { get; set; }
    }
}
