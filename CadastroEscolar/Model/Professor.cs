using CadastroEscolar;
using CadastroEscolar.Model;
using System;
using System.Linq;

namespace CadastroTurma.Model
{
    public class Professor : Pessoa
    {
        public Coordenador Coordenador { get; set; }
        public int QuantidadeTurmas { get; set; }
        public Professor() { }
        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Matricula: {Matricula} Quantidade de Turmas: {QuantidadeTurmas}\n";

        public override void CadastrarPessoa(Escola escola)
        {
            Operacoes.MudarBack();
            base.CadastrarPessoa(escola);
            int idadePessoa;

            Operacoes.MudarBack();

            Console.WriteLine($"Digite a idade do {Nome}!\n");
            while (!int.TryParse(Console.ReadLine(), out idadePessoa) || idadePessoa < 24 || idadePessoa > 60)
                Console.WriteLine("Idade inválida, a idade deve estar entre 24 e 60 anos!\n");

            Idade = idadePessoa;
            var numValida = Operacoes.ChecaId("professor", Matricula, escola);

            if (numValida != 0)
                Matricula = numValida;

            if (escola.Coordenadores.Count() == 0)
            {
                Console.WriteLine("Não há coordenadores disponiveis, cadastre um! \n pressione enter para voltar ao menu!");
                Console.ReadLine();
                View.MenuCentral(escola);
            }
            Console.WriteLine("Coordenadores disponiveis!");
            escola.Coordenadores.ForEach(c => Console.WriteLine(c));

            var Ocoordenador = Operacoes.RetornaCoordenador(escola);

            Coordenador = Ocoordenador;

            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n Enter para voltar ao menu");
            Console.ReadLine();
        }
            
    }
}
