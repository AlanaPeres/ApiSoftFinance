namespace ApiSoftFinance.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoTransacao? Tipo { get; set; }
    }
}
