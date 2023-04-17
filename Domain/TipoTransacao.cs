using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    [NotMapped]
    public class TipoTransacao
    {
        public bool Deposito { get; set; }
        public bool Transferencia { get; set; }
    }
}
