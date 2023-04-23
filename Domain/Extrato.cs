namespace ApiSoftFinance.Domain
{
    public class Extrato
    {
        public int Id { get; set; }
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public decimal Valor { get; set; }
        public DateOnly Data { get; set; }
    }

}
