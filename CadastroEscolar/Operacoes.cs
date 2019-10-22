using System;
using System.Linq;
using CadastroEscolar.Model;
using CadastroTurma.Model;

namespace CadastroEscolar
{
    public static class Operacoes
    {
        public static void VoltarMenu(ConsoleKeyInfo tecla, Escola escola)
        {
            if (tecla.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\nAperte enter para voltar ao menu principal!\n");
                Console.ReadLine();
                View.MenuCentral(escola);
            }
        }

        //Método para validar e retornar um aluno válido
        public static Aluno RetornaAluno(Escola escola)
        {
            Aluno aluno = null;
            int matriculaAluno;

            while (aluno == null)
            {
                Console.WriteLine("Digite o numero da matricula do aluno");
                while (!int.TryParse(Console.ReadLine(), out matriculaAluno))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aluno = escola.Alunos.FirstOrDefault(c => c.Matricula == matriculaAluno);
            }
            return aluno;
        }

        //Método para validar e retornar um coodenador válido
        public static Coordenador RetornaCoordenador(Escola escola)
        {
            Coordenador coordenador = null;

            int matriculaCoordenador;

            while (coordenador == null)
            {
                Console.WriteLine("Digite a matricula do coordenador!\n");
                while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                coordenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
            }
            return coordenador;

        }

        //Método para validar e retornar um professor válido
        public static Professor RetornaProfessor(Escola escola)
        {
            Professor professor = null;
            int matriculaProfessor;

            while (professor == null)
            {
                Console.WriteLine("Digite a matricula do professor!\n");
                while (!int.TryParse(Console.ReadLine(), out matriculaProfessor))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                professor = escola.Professores.FirstOrDefault(c => c.Matricula == matriculaProfessor);
            }
            return professor;
        }

        //Método para validar e retornar uma turma válida
        public static Turma RetornaTurma(Escola escola)
        {
            Turma turma = null;
            int codTurma;

            while (turma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                turma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }
            return turma;
        }

        //Método para prevenir a repetição do random
        public static int ChecaId(string tipo, int Matricula, Escola escola)
        {
            switch (tipo)
            {
                case "professor":
                    while (escola.Professores.Any(c => c.Matricula == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                case "coordenador":
                    while (escola.Coordenadores.Any(c => c.Matricula == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                case "aluno":
                    while (escola.Alunos.Any(c => c.Matricula == Matricula) || escola.Turmas.Any(e => e.Alunos.Any(a => a.Matricula == Matricula)))
                        return new Random().Next(0000, 9999);
                    break;

                case "turma":
                    while (escola.Turmas.Any(c => c.CodigoTurma == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                default:
                    break;
            }
            return 0;
        }

        public static void MudarBack()
        {
            Console.Title = "CADASTRO ESCOLAR!!";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
        }
        public static  void WriteLineCenter(string a)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a));
        }
      
    }
}