using System;

namespace CadastroEscolar.Model
{
    public class Aluno : Pessoa
    {
        public Aluno() {  }
        public bool Bolsista { get; set; }

        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Ra: {Matricula}  É Bolsista: {Bolsista}\n";

        public  override void  CadastrarPessoa(Escola escola)
        {
            int idadePessoa;
            Operacoes.MudarBack();
            base.CadastrarPessoa(escola);

            var numValida = Operacoes.ChecaId("aluno", Matricula, escola);

            if(numValida != 0)
                Matricula = numValida;

            Console.WriteLine("Pressione enter para o proximo item do cadastro ou esc para sair\n");
            Operacoes.VoltarMenu(Console.ReadKey(), escola);

            Console.WriteLine($"Digite a idade do {Nome}!\n");
            while (!int.TryParse(Console.ReadLine(), out idadePessoa) || idadePessoa < 6 || idadePessoa > 60)
                Console.WriteLine("Idade inválida, a idade deve estar entre 6 e 60 anos!\n");

            Idade = idadePessoa;

            Console.WriteLine("Pressione enter para o proximo item do cadastro ou esc para sair\n");
            Operacoes.VoltarMenu(Console.ReadKey(), escola);

            Console.WriteLine("Digite se o aluno é bolsista, S para sim  ou  N para não?");
            string opcao = Console.ReadLine();
            while (opcao.ToUpper() != "S" && opcao.ToUpper() != "N")
            {
                Console.WriteLine("Opção inválida! escolha entre s e n , digite novamente!");
                opcao = Console.ReadLine();
            }

            Bolsista = opcao == "S";

            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n Enter para voltar ao menu");
            Console.ReadLine();
        }
    }
}
