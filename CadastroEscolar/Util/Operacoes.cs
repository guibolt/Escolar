using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CadastroEscolar.Model;
using CadastroTurma.Model;
using Core.Util;

namespace CadastroTurma
{
    public static class Operacoes
    {
        //Menu central da aplicacao, contendo as opcoes para os outros menus
        public static void MenuCentral(Escola escola)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDigite 1 para menu de cadastros\n2 para menu de exibiçao\n3 para atribuir aluno a turma \n4 para atribuir professor \n5 para atrubir coodenador!\n6 para sair! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        CadastroDePessoas(escola);
                        break;
                    case "2":
                        MenuDeExibicao(escola);
                        break;

                    case "3":
                        AtribuiAlunoaTurma(escola);
                        break;

                    case "4":
                        AtribuiProfessorTurma(escola);
                        break;

                    case "5":
                        AtribuiCoodenador(escola);
                        break;

                    case "6":
                        Console.WriteLine("Obrigado e Até logo!");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }

        public static void CadastroDePessoas(Escola escola)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nDigite 1 para realizar o cadastro de um Aluno,\n2 para professores \n3 para coordenador \n4 para turmas! \n5 para voltar o menu principal! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        var novoAluno = new Aluno();
                        novoAluno.CadastrarPessoa(escola);
                        escola.Alunos.Add(novoAluno);
                        Arquivo.Salvar(escola);
                        break;

                    case "2":
                        var novoProfessor = new Professor();
                        novoProfessor.CadastrarPessoa(escola);
                        escola.Professores.Add(novoProfessor);
                        Arquivo.Salvar(escola);
                        break;

                    case "3":
                        var novoCoordenador = new Coordenador();
                        novoCoordenador.CadastrarPessoa(escola);
                        escola.Coordenadores.Add(novoCoordenador);
                        Arquivo.Salvar(escola);
                        break;
                    case "4":
                        var novaTurma = new Turma();
                        novaTurma.CadastrarTurma(escola);
                        escola.Turmas.Add(novaTurma);
                        Arquivo.Salvar(escola);
                        break;

                    case "5":
                        Console.WriteLine("Enter para voltar ao menu principal");
                        Console.ReadLine();
                        MenuCentral(escola);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }

        public static void MenuDeExibicao(Escola Escola)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDigite 1 para  a exbição de Alunos \n2 para professores \n3 para coordenador \n4 para turmas! \n5 para ver turma por Id \n5 para  ver coodernador por id \n7 para voltar o menu principal! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":

                        Console.Clear();
                        Console.WriteLine("Alunos Disponiveis!:\n");
                        Escola.Alunos.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Professores Disponiveis:\n");
                        foreach (var professor in Escola.Professores)
                        {
                            if (professor.QuantidadeTurmas < 2)
                                Console.WriteLine(professor);
                        }
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Coordenadores:\n");
                        Escola.Coordenadores.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Turmas:\n");
                        Escola.Turmas.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Turmas disponiveis");
                        Escola.Turmas.ForEach(c => Console.WriteLine(c));
                        var aTurma = RetornaTurma(Escola);
                        Console.WriteLine(aTurma);
                        Console.WriteLine("Alunos desta turma!!\n");
                        aTurma.Alunos.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Coodenadores disponiveis");
                        Escola.Coordenadores.ForEach(c => Console.WriteLine(c));
                        var oCoodenador = RetornaCoordenador(Escola);
                        Console.WriteLine(oCoodenador);
                        Console.WriteLine("Cod das turmas deste coordenador: \n");
                        oCoodenador.CodTurmas.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Enter para voltar ao menu principal");
                        Console.ReadLine();
                        MenuCentral(Escola);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }

        public static void AtribuiAlunoaTurma(Escola escola)
        {
            Console.Clear();


            Console.WriteLine("Alunos Disponiveis!:\n");
            escola.Alunos.ForEach(e => Console.WriteLine(e));

            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            var oAluno = RetornaAluno(escola);

            Console.WriteLine("Turmas disponiveis\n");
            escola.Turmas.ForEach(e => Console.WriteLine(e));


            var aTurma = RetornaTurma(escola);

            if (aTurma.Alunos.Count() == aTurma.CapacidadeMax)
            {
                Console.WriteLine("A Turma já está cheia, nao é possivel inserir mais alunos!\n");
                Console.WriteLine("Aperte enter para voltar ao menu principal!");
                Console.ReadLine();
                MenuCentral(escola);
            }

            aTurma.Alunos.Add(oAluno);
            escola.Alunos.Remove(oAluno);
            Arquivo.Salvar(escola);
            Console.WriteLine("Aluno atribuido com sucesso, enter para voltar ao menu principal!");
            Console.ReadLine();

        }

        public static void AtribuiProfessorTurma(Escola escola)
        {
            Console.Clear();
            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 

            var oProfessor = RetornaProfessor(escola);

            if (oProfessor.QuantidadeTurmas == 2)
            {
                Console.WriteLine("Este professor ja está em duas turmas, não é possivel inscreve-lo em uma terceira!");
                Console.ReadLine();
                MenuCentral(escola);
            }

            var aTurma = RetornaTurma(escola);

            if (aTurma.Professor != null)
            {
                aTurma.Professor.QuantidadeTurmas--;
                escola.Professores.Add(aTurma.Professor);
            }

            escola.Professores.Remove(oProfessor);
            oProfessor.QuantidadeTurmas++;
            aTurma.Professor = oProfessor;
            Arquivo.Salvar(escola);

        }

        public static void AtribuiCoodenador(Escola escola)
        {
            Console.Clear();

            Console.WriteLine("Coodenadores disponiveis!\n");
            escola.Coordenadores.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Digite 1 para atribuir coodernador na turma e \n2 para atribuir a um professor");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    Console.WriteLine("Turmas disponiveis");
                    escola.Turmas.ForEach(c => Console.WriteLine(c));

                    // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 

                    var oCoordenador = RetornaCoordenador(escola);

                    var aTurma = RetornaTurma(escola);

                    oCoordenador.CodTurmas.Add(aTurma.CodigoTurma);
                    aTurma.Coordenador = oCoordenador;
                    Arquivo.Salvar(escola);
                    break;

                case "2":

                    Console.WriteLine("Professores Disponiveis!");
                    escola.Professores.ForEach(e => Console.WriteLine(e));

                    var oProfessor = RetornaProfessor(escola);

                    var Coordenador = RetornaCoordenador(escola);

                    if (oProfessor.Coordenador != null)
                        escola.Coordenadores.Add(oProfessor.Coordenador);

                    oProfessor.Coordenador = Coordenador;
                    Arquivo.Salvar(escola);
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

        public static void RemovePessoasTurma(Escola escola)
        {
            Console.Clear();

            Console.WriteLine("Turmas cadastradas!");
            escola.Turmas.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Escolha a turma pelo ID!");
            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            var aTurma = RetornaTurma(escola);

            Console.WriteLine("Digite 1 para remover aluno da turma e \n2 para remover professor e \n3 para remover Coordenador");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    var oAluno = RetornaAluno(escola);
                    aTurma.Alunos.Remove(oAluno);
                    escola.Alunos.Add(oAluno);
                    break;

                case "2":
                    var oProfessor = RetornaProfessor(escola);

                    if (oProfessor.QuantidadeTurmas == 2)
                    {
                        oProfessor.QuantidadeTurmas--;
                        escola.Professores.Add(aTurma.Professor);
                    }

                    aTurma.Professor = null;
                    Arquivo.Salvar(escola);
                    break;

                case "3":
                    var coodernador = RetornaCoordenador(escola);
                    aTurma.Coordenador = null;
                    Arquivo.Salvar(escola);
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

        //Método para a validação da string do nome
        public static bool ChecaString(string nome)
        {
            foreach (var letra in nome)
            {
                if (int.TryParse(letra.ToString(), out int result))
                    return false;
            }

            return true;
        }

        //Método para prevenir a repetição do random
        public static int ChecaId(string tipo, int Matricula, Escola escola)
        {
            switch (tipo)
            {
                case "professor":
                    while (escola.Professores.Any(c => c.Matricula == Matricula) || escola.Turmas.Any(c => c.Professor.Matricula == Matricula))
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

        public static void VoltarAoMenu(string voltar, Escola escola)
        {
            if (voltar.StartsWith("1"))
                MenuCentral(escola);
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
                Console.WriteLine("Digite a matricula do aluno!\n");
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
    }
}