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
                Arquivo.Salvar(escola);
            }
        }

        public static void CadastroDePessoas(Escola Escola)
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
                        novoAluno.CadastrarPessoa(Escola);
                        Escola.Alunos.Add(novoAluno);
                        break;

                    case "2":
                        var novoProfessor = new Professor();
                        novoProfessor.CadastrarPessoa(Escola);
                        Escola.Professores.Add(novoProfessor);
                        break;

                    case "3":
                        var novoCoordenador = new Coordenador();
                        novoCoordenador.CadastrarPessoa(Escola);
                        Escola.Coordenadores.Add(novoCoordenador);
                        break;
                    case "4":
                        var novaTurma = new Turma();
                        novaTurma.CadastrarTurma(Escola);
                        Escola.Turmas.Add(novaTurma);
                        break;

                    case "5":
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

        public static void MenuDeExibicao(Escola Escola)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDigite 1 para  a exbição de Alunos \n2 para professores \n3 para coordenador \n4 para turmas! \n5 para ver turma por Id \n6 para voltar o menu principal! \n");
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
                        var aTurma = RetornaTurmaPorId(Escola);
                        Console.WriteLine(aTurma);
                        Console.WriteLine("Alunos desta turma!!\n");
                        aTurma.Alunos.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        var oCoodenador = RetornaCoordenadorPorId(Escola);
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

            int matriculaAluno, codTurma;

            Console.WriteLine("Alunos Disponiveis!:\n");
            escola.Alunos.ForEach(e => Console.WriteLine(e));

            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            Aluno oAluno = null;

            while (oAluno == null)
            {
                Console.WriteLine("Digite o numero da matricula do aluno");
                while (!int.TryParse(Console.ReadLine(), out matriculaAluno))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                oAluno = escola.Alunos.FirstOrDefault(c => c.Matricula == matriculaAluno);
            }

            Console.WriteLine("Turmas disponiveis\n");
            escola.Turmas.ForEach(e => Console.WriteLine(e));

            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            if (aTurma.Alunos.Count() == aTurma.CapacidadeMax)
            {
                Console.WriteLine("A Turma já está cheia, nao é possivel inserir mais alunos!\n");
                Console.WriteLine("Aperte enter para voltar ao menu principal!");
                Console.ReadLine();
                MenuCentral(escola);
            }

            aTurma.Alunos.Add(oAluno);
            escola.Alunos.Remove(oAluno);
            Console.WriteLine("Aluno atribuido com sucesso, enter para voltar ao menu principal!");
            Console.ReadLine();

        }

        public static void AtribuiProfessorTurma(Escola escola)
        {
            Console.Clear();
            int matriculaProfessor, codTurma;

            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            Professor oProfessor = null;

            while (oProfessor == null)
            {
                Console.WriteLine("Digite a matricula do professor!\n");
                while (!int.TryParse(Console.ReadLine(), out matriculaProfessor))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                oProfessor = escola.Professores.FirstOrDefault(c => c.Matricula == matriculaProfessor);
            }

            if (oProfessor.QuantidadeTurmas == 2)
            {
                Console.WriteLine("Este professor ja está em duas turmas, não é possivel inscreve-lo em uma terceira!");
                Console.ReadLine();
                MenuCentral(escola);
            }

            Turma aTurma = null;

            while (aTurma == null)
            {

                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            if (aTurma.Professor != null)
            {
                aTurma.Professor.QuantidadeTurmas--;
                escola.Professores.Add(aTurma.Professor);
            }

            escola.Professores.Remove(oProfessor);
            oProfessor.QuantidadeTurmas++;
            aTurma.Professor = oProfessor;

        }

        public static void AtribuiCoodenador(Escola escola)
        {
            Console.Clear();

            Console.WriteLine("Coodenadores disponiveis!\n");
            escola.Coordenadores.ForEach(e => Console.WriteLine(e));

            int matriculaCoordenador, codTurma;

            Console.WriteLine("Digite 1 para atribuir coodernador na turma e \n2 para atribuir a um professor");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    Console.WriteLine("Turmas disponiveis");
                    escola.Turmas.ForEach(c => Console.WriteLine(c));

                    // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
                    Coordenador oCoordenador = null;

                    while (oCoordenador == null)
                    {
                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oCoordenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
                    }

                    Turma aTurma = null;

                    while (aTurma == null)
                    {
                        Console.WriteLine("Digite o Código da turma!\n");
                        while (!int.TryParse(Console.ReadLine(), out codTurma))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        aTurma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
                    }

                    oCoordenador.CodTurmas.Add(aTurma.CodigoTurma);
                    aTurma.Coordenador = oCoordenador;
                    break;

                case "2":
                    int matriculaProfessor;

                    Console.WriteLine("Professores Disponiveis!");
                    escola.Professores.ForEach(e => Console.WriteLine(e));

                    Professor oProfessor = null;

                    while (oProfessor == null)
                    {
                        Console.WriteLine("Coordenador inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaProfessor))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oProfessor = escola.Professores.FirstOrDefault(c => c.Matricula == matriculaProfessor);
                    }

                    Coordenador Coordenador = null;

                    while (Coordenador == null)
                    {
                        Console.WriteLine("Coordenador inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oCoordenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
                    }

                    if (oProfessor.Coordenador != null)
                        escola.Coordenadores.Add(oProfessor.Coordenador);


                    oProfessor.Coordenador = Coordenador;
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

        public static Turma RetornaTurmaPorId(Escola escola)
        {
            int codTurma;
            Console.WriteLine("Turmas disponiveis");
            escola.Turmas.ForEach(c => Console.WriteLine(c));

            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            return aTurma;
        }
        public static Coordenador RetornaCoordenadorPorId(Escola escola)
        {
            int matriculaCoordenador;
            Console.WriteLine("Coodenadores disponiveis");
            escola.Coordenadores.ForEach(c => Console.WriteLine(c));

            Coordenador Coordenador = null;

            while (Coordenador == null)
            {
                Console.WriteLine("Digite a matricula do aluno!\n");
                while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                Coordenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
            }
            return Coordenador;
        }


        public static void RemovePessoasTurma(Escola escola)
        {
            Console.Clear();

            int codTurma, matriculaPessoa;

            Console.WriteLine("Turmas cadastradas!");
            escola.Turmas.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Escolha a turma pelo ID!");
            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            Console.WriteLine("Digite 1 para remover aluno da turma e \n2 para remover professor e \n3 para remover Coordenador");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    Aluno oAluno = null;

                    while (oAluno == null)
                    {
                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oAluno = escola.Alunos.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }

                    aTurma.Alunos.Remove(oAluno);
                    escola.Alunos.Add(oAluno);
                    break;

                case "2":
                    Professor oProfessor = null;

                    while (oProfessor == null)
                    {
                   
                        Console.WriteLine("Digite a matricula do professor!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oProfessor = escola.Professores.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }

                    if (oProfessor.QuantidadeTurmas == 2)
                    {
                        oProfessor.QuantidadeTurmas--;
                        escola.Professores.Add(aTurma.Professor);
                    }

                    aTurma.Professor = null;
                    break;

                case "3":
                    Coordenador Coordenador = null;

                    while (Coordenador == null)
                    {
                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        Coordenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }
                    aTurma.Coordenador = null;
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
            switch (tipo.ToUpper())
            { 
                case "PROFESSOR":
                    while (escola.Professores.Any(c => c.Matricula == Matricula) || escola.Turmas.Any(c => c.Professor.Matricula == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                case "COORDENADOR":
                    while (escola.Coordenadores.Any(c => c.Matricula == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                case "ALUNO":
                    while (escola.Alunos.Any(c => c.Matricula == Matricula) || escola.Turmas.Any(e => e.Alunos.Any(a => a.Matricula == Matricula)))
                        return new Random().Next(0000, 9999);
                    break;

                case "TURMA":
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
    }
}