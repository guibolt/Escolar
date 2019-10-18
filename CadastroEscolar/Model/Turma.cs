using CadastroEscolar.Model;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroTurma.Model
{
    public class Turma
    {
        public int CodigoTurma { get; set; } = new Random().Next(0000, 9999);
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }
        public Coordenador Coordenador { get; set; }

        public Turma() { }

        public void CadastrarTurma(Escola escola)
        {
            int idCoodenador, qtd;
      
            Console.WriteLine("Digite a matricula do coodernador!\n");
            while (!int.TryParse(Console.ReadLine(), out idCoodenador))
                Console.WriteLine("matricula inválida, digite novamente!\n");

            var oCoodenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == idCoodenador);

            while (oCoodenador == null)
            {
                Console.WriteLine("Coordenador inválido, digite novamente!\n");

                Console.WriteLine("Digite a matricula do coodernador!\n");
                while (!int.TryParse(Console.ReadLine(), out idCoodenador))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                oCoodenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == idCoodenador);
            }

            Console.WriteLine("Digite a quantiade maxima da turma!\n");
            while (!int.TryParse(Console.ReadLine(), out qtd))
                Console.WriteLine("quantidade inválida, digite novamente!\n");

            Coordenador = oCoodenador;
            Alunos = new List<Aluno>(qtd);

        }

        public override string ToString()
        {
            Console.WriteLine("Alunos:\n");
            //foreach percorrendo a lista de alunos da turma especifica
            Alunos.ForEach(a => Console.WriteLine($"{a} \n"));

            return $"CodTurma: {CodigoTurma} Nome do professor: {Professor.Nome} Nome do Coordenador! {Coordenador.Nome}";
        }

    }
}
