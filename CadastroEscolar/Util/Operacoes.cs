﻿using System;
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
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nDigite 1 para menu  de cadastro de Pessoas, 2 para menu de exibiçao, 3 para atribuir aluno a turma \n  e 4 para atribuir professor, e 5 para atrubir coodenador!  e 6 para sair! \n");
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

        public static void CadastroDePessoas(Escola Escola)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nDigite 1 para realizar o cadastro de um Aluno, 2 para professores, 3 para coordenador, 4 para turmas! e 5 para voltar o menu principal! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        var novoAluno = new Aluno();
                        novoAluno.CadastrarPessoa(Escola);
                        Escola.Alunos.Add(novoAluno);
                        Arquivo.Salvar(Escola);
                        break;

                    case "2":
                        var novoProfessor = new Professor();
                        novoProfessor.CadastrarPessoa(Escola);
                        Escola.Professores.Add(novoProfessor);
                        Arquivo.Salvar(Escola);
                        break;

                    case "3":
                        var novoCoordenador = new Coordenador();
                        novoCoordenador.CadastrarPessoa(Escola);
                        Escola.Coordenadores.Add(novoCoordenador);
                        Arquivo.Salvar(Escola);
                        break;
                    case "4":
                        var novaTurma = new Turma();
                        novaTurma.CadastrarTurma(Escola);
                        Escola.Turmas.Add(novaTurma);
                        Arquivo.Salvar(Escola);
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
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nDigite 1 para  a exbição de Alunos, 2 para professores, 3 para coordenador, 4 para turmas! 5 para voltar o menu principal! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        Console.WriteLine("Alunos Disponiveis!:\n");
                        Escola.Alunos.ForEach(e => Console.WriteLine(e));
                        break;

                    case "2":
                        Console.WriteLine("Professores Disponiveis:\n");
                        foreach (var professor in Escola.Professores)
                        {
                            if (professor.QuantidadeTurmas < 2)
                                Console.WriteLine(professor);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Coordenadores:\n");
                        Escola.Coordenadores.ForEach(e => Console.WriteLine(e));
                        break;
                    case "4":
                        Console.WriteLine("Turmas:\n");
                        Escola.Turmas.ForEach(e => Console.WriteLine(e));
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
                Console.WriteLine("Coordenador inválido, digite novamente!\n");

                Console.WriteLine("Digite a matricula do aluno!\n");
                while (!int.TryParse(Console.ReadLine(), out matriculaAluno))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                oAluno = escola.Alunos.FirstOrDefault(c => c.Matricula == matriculaAluno);
            }

            Console.WriteLine("Turmas disponiveis");
            escola.Turmas.ForEach(e => Console.WriteLine(e));

            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Turma inválida, digite novamente!\n");

                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = escola.Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            if (aTurma.Alunos.Count() == aTurma.Alunos.Capacity)
            {
                Console.WriteLine("A Turma já está cheia, nao é possivel inserir mais alunos!" );
                MenuCentral(escola);
            }

            aTurma.Alunos.Add(oAluno);
            escola.Alunos.Remove(oAluno);

            Arquivo.Salvar(escola);
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

            if(oProfessor.QuantidadeTurmas == 2)
            {
                Console.WriteLine("Este professor ja está em duas turmas, não é possivel inscreve-lo em uma terceira!");
                MenuCentral(escola);
            }

            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Turma inválida, digite novamente!\n");

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

            Arquivo.Salvar(escola);
        }

        public static void AtribuiCoodenador(Escola escola)
        {
            Console.Clear();

            Console.WriteLine("Coodenadores disponiveis!\n");
            escola.Coordenadores.ForEach(e => Console.WriteLine(e));

            int matriculaCoordenador, codTurma;

            Console.WriteLine("Digite 1 para atribuir coodernador na turma e 2 para atribuir a um professor");
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

                    Arquivo.Salvar(escola);
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

            Console.WriteLine("Digite 1 para remover aluno da turma e 2 para remover professor e 3 para remover Coordenador");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    Aluno oAluno = null;

                    while (oAluno == null)
                    {
                        Console.WriteLine("aluno inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oAluno = escola.Alunos.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }

                    aTurma.Alunos.Remove(oAluno);
                    Arquivo.Salvar(escola);
                    break;

                case "2":
                    Professor oProfessor = null;

                    while (oProfessor == null)
                    {
                        Console.WriteLine("aluno inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oProfessor = escola.Professores.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }

                    aTurma.Professor = null;
                    Arquivo.Salvar(escola);
                    break;

                case "3":
                    Coordenador Coordenador = null;

                    while (Coordenador == null)
                    {
                        Console.WriteLine("Coordenador inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        Coordenador = escola.Coordenadores.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }
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

        
        public static bool ValidaOpcao(string opcao)
        {
            if (opcao.ToUpper() == "SIM" || opcao.ToUpper() == "NÃO" || opcao.ToUpper() == "NAO")
                return true;

            return false;
        }

        //Método para prevenir a repetição do random
        public static int ChecaId(string tipo, int Matricula, Escola escola)
        {
            switch (tipo.ToUpper())
            {
                case "PROFESSOR":
                        while (escola.Professores.Any(c => c.Matricula == Matricula))
                            return new Random().Next(0000, 9999);
                    break;

                case "COORDENADOR":
                        while (escola.Coordenadores.Any(c => c.Matricula == Matricula))
                            return new Random().Next(0000, 9999);
                    break;

                case "ALUNO":
                    while (escola.Alunos.Any(c => c.Matricula == Matricula))
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

        public static void VoltarAoMenu(string voltar , Escola escola)
        {
            if (voltar.ToUpper().StartsWith("V"))
                MenuCentral(escola);
        }

    }
}