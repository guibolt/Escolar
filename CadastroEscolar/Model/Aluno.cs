using CadastroEscolar.Model;
using System;

namespace CadastroTurma.Model
{
    public class Aluno : Pessoa
    {
        public Aluno() {  }
        public bool Bolsista { get; set; }

        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Ra: {Matricula} Cpf: {Cpf} É Bolsista: {Bolsista}\n";

        public  override void  CadastrarPessoa()
        {
            base.CadastrarPessoa();

            //var numValida = Operacoes.ChecaId("aluno", Matricula, escola);

            //if(numValida != 0)
            //    Matricula = numValida;
            

            Console.WriteLine("Digite se o aluno é bolsista, sim ou não?");
            string opcao = Console.ReadLine();
            while (!Operacoes.ValidaOpcao(opcao))
            {
                Console.WriteLine("Opção inválida, digite novamente!");
                opcao = Console.ReadLine();

                if (opcao == "SIM")
                    Bolsista = true;
                else
                    Bolsista = false;
            }

            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n");
        }

    }
}
