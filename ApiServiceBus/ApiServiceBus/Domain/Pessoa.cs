namespace ApiServiceBus.Domain
{
    public class Pessoa
    {
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Sexo { get; set; }

        public Pessoa(){}

        public Pessoa(string nome, int idade, string sexo)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Sexo = sexo;
        }
    }
}
