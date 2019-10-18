namespace CadastroTurma.Model
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public long Cpf { get; set; }

        public Pessoa(string nome, int idade, char sexo, long cpf)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Cpf = cpf;
        }

        public abstract dynamic CadastrarPessoa();
    }
}
