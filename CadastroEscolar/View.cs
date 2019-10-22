using CadastroEscolar.Model;
using CadastroTurma.Model;
using Core.Util;
using System;
using System.Linq;

namespace CadastroEscolar
{
    public static class View
    {
        public static void MenuCentral(Escola escola)
        {
            while (true)
            {
                Operacoes.MudarBack();
                Console.Clear();

                Console.WriteLine("Digite: \n\n1 para menu de cadastros\n\n2 para menu de exibição\n\n3 para atribuir aluno a uma turma \n\n4 para atribuir um professor a turma \n\n5 para atrubir coodenador a uma turma!\n\n6 para remover pessoas de uma turma \n\n7 para sair! ");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        MenuDeCadastro(escola);
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
                        RemovePessoasTurma(escola);
                        break;

                    case "7":
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

        public static void MenuDeCadastro(Escola escola)
        {
            Operacoes.MudarBack();
          
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\nDigite: \n1 para realizar o cadastro de um Aluno,\n\n2 para professores \n\n3 para coordenador \n\n4 para turmas! \n\n5 para voltar o menu principal! \n\n");

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

        public static void MenuDeExibicao(Escola escola)
        {

            Operacoes.MudarBack();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\nDigite 1 para  a exbição de Alunos \n\n2 para professores \n\n3 para coordenador \n\n4 para turmas! \n\n5 para ver turma por Id \n\n5 para  ver coodernador por id \n\n7 para voltar o menu principal! \n\n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":

                        Console.Clear();
                        if (escola.Alunos.Count() == 0)
                        {
                            Console.WriteLine("Não há professores disponiveis!\n Enter para voltar ao menu principal");
                            Console.ReadLine();
                            MenuCentral(escola);
                        }
                        Console.WriteLine("Alunos Disponiveis!:\n");
                        escola.Alunos.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        if (escola.Professores.Count() == 0)
                        {
                            Console.WriteLine("Não há professores disponiveis!\n Enter para voltar ao menu principal");
                            Console.ReadLine();
                            MenuCentral(escola);
                        }
                        Console.WriteLine("Professores Disponiveis:\n");
                        foreach (var professor in escola.Professores)
                        {
                            if (professor.QuantidadeTurmas < 2)
                                Console.WriteLine(professor);
                        }
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        if (escola.Coordenadores.Count() == 0)
                        {
                            Console.WriteLine("Não há coordenadores disponiveis!\n Enter para voltar ao menu principal");
                            Console.ReadLine();
                            MenuCentral(escola);
                        }
                        Console.WriteLine("Coordenadores:\n");
                        escola.Coordenadores.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        if (escola.Turmas.Count() == 0)
                        {

                            Console.WriteLine("Não há turmas disponiveis!\n Enter para voltar ao menu principal");
                            Console.ReadLine();
                            MenuCentral(escola);
                        }
                        Console.WriteLine("Turmas:\n");
                        escola.Turmas.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();
                        if (escola.Turmas.Count() == 0)
                        {
                            Console.WriteLine("Não há turmas disponiveis!\n Enter para voltar ao menu principal");
                            Console.ReadLine();
                            MenuCentral(escola);
                        }
                        Console.WriteLine("Turmas disponiveis");
                        escola.Turmas.ForEach(c => Console.WriteLine(c));
                        var aTurma = Operacoes.RetornaTurma(escola);
                        Console.WriteLine(aTurma);
                        Console.WriteLine("Alunos desta turma!!\n");
                        aTurma.Alunos.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        if (escola.Coordenadores.Count() == 0)
                        {
                            Console.WriteLine("Não há coodenadores disponiveis!\n Enter para voltar ao menu principal");
                            Console.ReadLine();
                            MenuCentral(escola);
                        }
                        Console.WriteLine("Coodenadores disponiveis");
                        escola.Coordenadores.ForEach(c => Console.WriteLine(c));
                        var oCoodenador = Operacoes.RetornaCoordenador(escola);
                        Console.WriteLine(oCoodenador);
                        Console.WriteLine("Cod das turmas deste coordenador: \n");
                        oCoodenador.CodTurmas.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "7":
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


        public static void AtribuiAlunoaTurma(Escola escola)
        {
            Operacoes.MudarBack();
 
            if (escola.Alunos.Count() == 0)
            {
                Console.WriteLine("Não há alunos disponiveis, aperte enter para voltar ao menu central.");
                Console.ReadLine();
                View.MenuCentral(escola);
            }

            Console.Clear();
            Console.WriteLine("Alunos Disponiveis!:\n");
            escola.Alunos.ForEach(e => Console.WriteLine(e));

            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            var oAluno = Operacoes.RetornaAluno(escola);

            if (escola.Turmas.Count() == 0)
            {
                Console.WriteLine("Não há turmas disponiveis!\n Enter para voltar ao menu principal");
                Console.ReadLine();
                MenuCentral(escola);
            }

            Console.WriteLine("Turmas disponiveis\n");
            escola.Turmas.ForEach(e => Console.WriteLine(e));

            var aTurma = Operacoes.RetornaTurma(escola);

            if (aTurma.Alunos.Count() == aTurma.CapacidadeMax)
            {
                Console.WriteLine("A Turma já está cheia, nao é possivel inserir mais alunos!\n");
                Console.WriteLine("Aperte enter para voltar ao menu principal!");
                Console.ReadLine();
                View.MenuCentral(escola);
            }

            aTurma.Alunos.Add(oAluno);
            escola.Alunos.Remove(oAluno);
            Arquivo.Salvar(escola);
            Console.WriteLine("Aluno atribuido com sucesso, enter para voltar ao menu principal!");
            Console.ReadLine();

        }

        public static void AtribuiProfessorTurma(Escola escola)
        {
            Operacoes.MudarBack();

            if (escola.Professores.Count() == 0)
            {
                Console.WriteLine("Não há professores disponiveis, aperte enter para voltar ao menu central.");
                Console.ReadLine();
                MenuCentral(escola);
            }

            Console.Clear();
            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 

            Console.WriteLine("Professores Disponiveis!\n");
            escola.Professores.ForEach(c => Console.WriteLine(c));

            var oProfessor = Operacoes.RetornaProfessor(escola);

            if (oProfessor.QuantidadeTurmas == 2)
            {
                Console.WriteLine("Este professor ja está em duas turmas, não é possivel inscreve-lo em uma terceira!");
                Console.ReadLine();
                MenuCentral(escola);
            }

            if (escola.Turmas.Count() == 0)
            {
                Console.WriteLine("Não há turmas disponiveis!\n Enter para voltar ao menu principal");
                Console.ReadLine();
                MenuCentral(escola);
            }

            Console.WriteLine("Turmas Disponiveis!\n");
            escola.Turmas.ForEach(c => Console.WriteLine(c));

            var aTurma = Operacoes.RetornaTurma(escola);

            if (aTurma.Professor != null)
            {
                if (aTurma.Professor.Matricula == oProfessor.Matricula)
                {
                    Console.WriteLine("O professor ja está registrado nessa turma!\n aperte enter para voltar ao menu principal!");
                    Console.ReadLine();
                    MenuCentral(escola);
                }

                aTurma.Professor.QuantidadeTurmas--;

                if (!escola.Professores.Contains(aTurma.Professor))
                    escola.Professores.Add(aTurma.Professor);
            }

            if (oProfessor.QuantidadeTurmas == 1)
            {
                escola.Professores.Remove(oProfessor);
                oProfessor.QuantidadeTurmas++;
            }

            oProfessor.QuantidadeTurmas++;
            aTurma.Professor = oProfessor;
            Arquivo.Salvar(escola);
        }

        public static void AtribuiCoodenador(Escola escola)
        {
            Operacoes.MudarBack();

            if (escola.Coordenadores.Count() == 0)
            {
                Console.WriteLine("Não há professores disponiveis, aperte enter para voltar ao menu central.");
                Console.ReadLine();
                MenuCentral(escola);
            }

            Console.Clear();

            Console.WriteLine("Coodenadores disponiveis!\n");
            escola.Coordenadores.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Digite 1 para atribuir coodernador na turma e \n2 para atribuir a um professor");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    if (escola.Turmas.Count() == 0)
                    {
                        Console.WriteLine("Não há turmas disponiveis, aperte enter para voltar ao menu central.");
                        Console.ReadLine();
                        MenuCentral(escola);
                    }
                    Console.WriteLine("Turmas disponiveis");
                    escola.Turmas.ForEach(c => Console.WriteLine(c));
                  

                    // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 

                    var oCoordenador = Operacoes.RetornaCoordenador(escola);

                    var aTurma = Operacoes.RetornaTurma(escola);

                    oCoordenador.CodTurmas.Add(aTurma.CodigoTurma);
                    aTurma.Coordenador = oCoordenador;
                    Arquivo.Salvar(escola);
                    break;

                case "2":
                    if (escola.Professores.Count() == 0)
                    {
                        Console.WriteLine("Não há professores disponiveis, aperte enter para voltar ao menu central.");
                        Console.ReadLine();
                        View.MenuCentral(escola);
                    }
                    Console.WriteLine("Professores Disponiveis!");
                    escola.Professores.ForEach(e => Console.WriteLine(e));

                    var oProfessor = Operacoes.RetornaProfessor(escola);

                    var Coordenador = Operacoes.RetornaCoordenador(escola);

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
            if (escola.Turmas.Count() == 0)
            {
                Console.WriteLine("Não há turmas disponiveis, aperte enter para voltar ao menu central.");
                Console.ReadLine();
                MenuCentral(escola);
            }

            Console.Clear();
            Console.WriteLine("Turmas cadastradas!");
            escola.Turmas.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Escolha a turma pelo ID!");
            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            var aTurma = Operacoes.RetornaTurma(escola);

            Console.WriteLine("Digite 1 para remover aluno da turma e \n2 para remover professor e \n3 para remover Coordenador");
            string Decisao = Console.ReadLine();
            int id;
            switch (Decisao)
            {
                case "1":
                    Console.WriteLine("Alunos dessa turma\n");
                    aTurma.Alunos.ForEach(c => Console.WriteLine(c));

                    Console.WriteLine("Digite a matricula do aluno!");
                    while (!int.TryParse(Console.ReadLine(), out id))
                        Console.WriteLine("matricula inválida, digite novamente!\n");

                    var oAluno = aTurma.Alunos.FirstOrDefault(c => c.Matricula == id);
                    if (oAluno == null)
                    {
                        Console.WriteLine("Aluno inválido, enter para voltar ao menu!");
                        Console.ReadLine();
                        RemovePessoasTurma(escola);
                    }

                    aTurma.Alunos.Remove(oAluno);
                    escola.Alunos.Add(oAluno);
                    break;

                case "2":
                    if (aTurma.Professor.QuantidadeTurmas == 2)
                    {
                        aTurma.Professor.QuantidadeTurmas--;
                        escola.Professores.Add(aTurma.Professor);
                    }

                    aTurma.Professor = null;
                    Arquivo.Salvar(escola);
                    break;

                case "3":
                    var coodernador = Operacoes.RetornaCoordenador(escola);
                    aTurma.Coordenador = null;
                    Arquivo.Salvar(escola);
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

    }
}
