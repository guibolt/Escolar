namespace CadastroTurma.Model
{
    public class Aluno : Pessoa
    {
        public int Ra { get; set; }
        public bool Bolsista { get; set; }

        public Aluno(string nome, int idade, char sexo, long cpf, int ra, bool bolsisa) : base(nome, idade, sexo, cpf)
        {
            Ra = ra;
            Bolsista = bolsisa;
        }

        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Ra: {Ra} Cpf: {Cpf} É Bolsista: {Bolsista}\n";

        public override dynamic CadastrarPessoa()
        {
            throw new System.NotImplementedException();
        }

    }
}
