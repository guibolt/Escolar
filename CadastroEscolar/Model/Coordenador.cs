using CadastroTurma;
using CadastroTurma.Model;
using System;
using System.Collections.Generic;

namespace CadastroEscolar.Model
{
    public class Coordenador : Pessoa
    {
        public Coordenador() {}
        public List<int> CodTurmas { get; set; } = new List<int>();

        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Matricula: {Matricula}  \n";
        public override void CadastrarPessoa(Escola escola)
        {
            int idadePessoa;

            Operacoes.MudarBack();

            Console.WriteLine($"Digite a idade do {Nome}!\n");
            while (!int.TryParse(Console.ReadLine(), out idadePessoa) || idadePessoa < 24 || idadePessoa > 60)
                Console.WriteLine("Idade inválida, a idade deve estar entre 24 e 60 anos!\n");

            Idade = idadePessoa;

            base.CadastrarPessoa(escola);
            if (Idade <27)
            {
                Console.WriteLine("é necessario ter ao menos 28 anos para cadastrar um coodernador! \n Aperte enter para voltar ao menu de cadastros");
                Console.ReadLine();
                View.MenuDeCadastro(escola);
            }

            var numValida = Operacoes.ChecaId("coordenador", Matricula, escola);

            if (numValida != 0)
                Matricula = numValida;


            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n Enter para voltar ao menu");
            Console.ReadLine();
        }
    }
}
