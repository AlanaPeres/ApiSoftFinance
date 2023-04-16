namespace ApiSoftFinance.Domain
{
    public class ContaBancaria
    {
        public ContaBancaria()
        {
            Contas = new List<ContaBancaria>();
        }
        public int Agencia { get; set; }
        public int NumeroDaContaId { get; set; }
        public Cliente? Cliente { get; set; }
        public string? Senha { get; set; }
        public decimal Saldo { get; set; }

        public ICollection<ContaBancaria> Contas { get; set; }

    }
}
