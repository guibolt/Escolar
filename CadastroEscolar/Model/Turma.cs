using CadastroEscolar;
using CadastroEscolar.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroTurma.Model
{
    public class Turma
    {
        public int CodigoTurma { get; set; } = new Random().Next(0000, 9999);
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }  = new List<Aluno>();
        public int CapacidadeMax { get;  set; }
        public Coordenador Coordenador { get; set; }

        public Turma() { }

        public void CadastrarTurma(Escola escola)
        {
            Operacoes.MudarBack();
 
            int quantidade;
            Console.WriteLine("Pressione enter para o proximo item do cadastro ou esc para sair\n");
            Operacoes.VoltarMenu(Console.ReadKey(), escola);

            if(escola.Coordenadores.Count() == 0)
            {
                Console.WriteLine("Não há coordenadores diponiveis!");
                Console.ReadLine();
                View.MenuDeCadastro(escola);
            }
            Console.WriteLine("Escolha um coordenador válido!");
            Console.WriteLine("Coordenadores:\n");
            escola.Coordenadores.ForEach(e => Console.WriteLine(e));

            var oCoodenador = Operacoes.RetornaCoordenador(escola);

            Console.WriteLine("Pressione enter para o proximo item do cadastro ou esc para sair\n");
            Operacoes.VoltarMenu(Console.ReadKey(), escola);

            Console.WriteLine("Digite a quantiade maxima da turma!\n");
            while (!int.TryParse(Console.ReadLine(), out quantidade))
                Console.WriteLine("quantidade inválida, digite novamente!\n");

            oCoodenador.CodTurmas.Add(CodigoTurma);
            Coordenador = oCoodenador;
            CapacidadeMax = quantidade;


            Console.Clear();
            Console.WriteLine($"Turma cadastrada com sucesso! codigo da turma: n° {CodigoTurma} \n Enter para voltar ao menu");
            Console.ReadLine();
        }

        public override string ToString()
        {
            if (Professor == null)
                return $"CodTurma: {CodigoTurma} Nome do Coordenador! {Coordenador.Nome} Capacidade da turma: {CapacidadeMax}\n";


            return $"CodTurma: {CodigoTurma} Nome do professor: {Professor.Nome} Nome do Coordenador: {Coordenador.Nome} Capacidade da turma: {CapacidadeMax}\n";
        }

    }
}
