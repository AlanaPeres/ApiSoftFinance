namespace ApiSoftFinance.Domain
{
    public class Cliente
    {
        public string?  Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Endereco? Endereco { get; set; }

        public ContaBancaria? ContaBancaria { get; set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string email, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Endereco = endereco;

        }


    }
}
