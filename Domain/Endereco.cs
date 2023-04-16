namespace ApiSoftFinance.Domain
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco() { }

        public Endereco(string cep, string rua, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;

        }
    }
}
