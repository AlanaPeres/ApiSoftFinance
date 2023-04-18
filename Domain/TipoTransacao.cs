using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSoftFinance.Domain
{
    [NotMapped]
    public class TipoTransacao
    {
        public char Deposito { get; set; }
        public char Transferencia { get; set; }
    }
}
