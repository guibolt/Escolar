using CadastroTurma.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroEscolar.Model
{
    public class Escola
    {
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<Professor> Professores { get; set; } = new List<Professor>();

        public List<Coordenador> Coordenadores { get; set; } = new List<Coordenador>();

        //Menu central da aplicacao, contendo as opcoes para os outros menus
        public void MenuCentral()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDigite 1 para menu  de cadastros, 2 para menu de exibiçao, 3 para atribuir aluno a turma \n  e 4 para atribuir professor, e 5 para atrubir coodenador!  e 6 para sair! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        CadastroDePessoas();
                        break;
                    case "2":
                        MenuDeExibicao();
                        break;

                    case "3":
                        AtribuiAlunoaTurma();
                        break;

                    case "4":
                        AtribuiProfessorTurma();
                        break;

                    case "5":
                        AtribuiCoodenador();
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

        public void CadastroDePessoas()
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
                        novoAluno.CadastrarPessoa();
                        Alunos.Add(novoAluno);

                        break;

                    case "2":
                        var novoProfessor = new Professor();
                        novoProfessor.CadastrarPessoa();
                        Professores.Add(novoProfessor);

                        break;

                    case "3":
                        var novoCoordenador = new Coordenador();
                        novoCoordenador.CadastrarPessoa();
                        Coordenadores.Add(novoCoordenador);

                        break;
                    case "4":
                        var novaTurma = new Turma();
                        novaTurma.CadastrarTurma(Coordenadores);
                        Turmas.Add(novaTurma);
                        ;
                        break;

                    case "5":
                        Console.WriteLine("Enter para voltar ao menu principal");
                        Console.ReadLine();
                        MenuCentral();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }

        public void MenuDeExibicao()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDigite 1 para  a exbição de Alunos, 2 para professores, 3 para coordenador \n, 4 para turmas! 5 para ver turma por Id e 6 para voltar o menu principal! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":

                        Console.Clear();
                        Console.WriteLine("Alunos Disponiveis!:\n");
                        Alunos.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Professores Disponiveis:\n");
                        foreach (var professor in Professores)
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
                        Coordenadores.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Turmas:\n");
                        Turmas.ForEach(e => Console.WriteLine(e));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();
                        var aTurma = RetornaTurmaPorId();
                        Console.WriteLine(aTurma);
                        Console.WriteLine("Alunos desta turma!!\n");
                        aTurma.Alunos.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        var oCoodenador = RetornaCoordenadorPorId();
                        Console.WriteLine(oCoodenador);
                        Console.WriteLine("Cod das turmas deste coordenador: \n");
                        oCoodenador.CodTurmas.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("Enter para voltar ao menu de exibição");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Enter para voltar ao menu principal");
                        Console.ReadLine();
                        MenuCentral();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }

        public void AtribuiAlunoaTurma()
        {
            Console.Clear();

            int matriculaAluno, codTurma;

            Console.WriteLine("Alunos Disponiveis!:\n");
            Alunos.ForEach(e => Console.WriteLine(e));

            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            Aluno oAluno = null;

            while (oAluno == null)
            {
                Console.WriteLine("Digite o numero da matricula do aluno");
                while (!int.TryParse(Console.ReadLine(), out matriculaAluno))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                oAluno = Alunos.FirstOrDefault(c => c.Matricula == matriculaAluno);
            }

            Console.WriteLine("Turmas disponiveis\n");
            Turmas.ForEach(e => Console.WriteLine(e));

            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            if (aTurma.Alunos.Count() == aTurma.CapacidadeMax)
            {
                Console.WriteLine("A Turma já está cheia, nao é possivel inserir mais alunos!\n");
                Console.WriteLine("Aperte enter para voltar ao menu principal!");
                Console.ReadLine();
                MenuCentral();
            }

            aTurma.Alunos.Add(oAluno);
            Alunos.Remove(oAluno);
            Console.WriteLine("Aluno atribuido com sucesso, enter para voltar ao menu principal!");
            Console.ReadLine();

        }

        public void AtribuiProfessorTurma()
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

                oProfessor = Professores.FirstOrDefault(c => c.Matricula == matriculaProfessor);
            }

            if (oProfessor.QuantidadeTurmas == 2)
            {
                Console.WriteLine("Este professor ja está em duas turmas, não é possivel inscreve-lo em uma terceira!");
                Console.ReadLine();
                MenuCentral();
            }

            Turma aTurma = null;

            while (aTurma == null)
            {

                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            if (aTurma.Professor != null)
            {
                aTurma.Professor.QuantidadeTurmas--;
                Professores.Add(aTurma.Professor);
            }

            Professores.Remove(oProfessor);
            oProfessor.QuantidadeTurmas++;
            aTurma.Professor = oProfessor;

        }

        public  void AtribuiCoodenador()
        {
            Console.Clear();

            Console.WriteLine("Coodenadores disponiveis!\n");
           Coordenadores.ForEach(e => Console.WriteLine(e));

            int matriculaCoordenador, codTurma;

            Console.WriteLine("Digite 1 para atribuir coodernador na turma e 2 para atribuir a um professor");
            string Decisao = Console.ReadLine();

            switch (Decisao)
            {
                case "1":
                    Console.WriteLine("Turmas disponiveis");
                    Turmas.ForEach(c => Console.WriteLine(c));

                    // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
                    Coordenador oCoordenador = null;

                    while (oCoordenador == null)
                    {
                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oCoordenador = Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
                    }

                    Turma aTurma = null;

                    while (aTurma == null)
                    {
                        Console.WriteLine("Digite o Código da turma!\n");
                        while (!int.TryParse(Console.ReadLine(), out codTurma))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        aTurma = Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
                    }

                    oCoordenador.CodTurmas.Add(aTurma.CodigoTurma);
                    aTurma.Coordenador = oCoordenador;


                    break;

                case "2":
                    int matriculaProfessor;

                    Console.WriteLine("Professores Disponiveis!");
                    Professores.ForEach(e => Console.WriteLine(e));

                    Professor oProfessor = null;

                    while (oProfessor == null)
                    {
                        Console.WriteLine("Coordenador inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaProfessor))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oProfessor = Professores.FirstOrDefault(c => c.Matricula == matriculaProfessor);
                    }

                    Coordenador Coordenador = null;

                    while (Coordenador == null)
                    {
                        Console.WriteLine("Coordenador inválido, digite novamente!\n");

                        Console.WriteLine("Digite a matricula do aluno!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oCoordenador = Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
                    }

                    if (oProfessor.Coordenador != null)
                        Coordenadores.Add(oProfessor.Coordenador);

                    oProfessor.Coordenador = Coordenador;
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

        public Turma RetornaTurmaPorId()
        {
            int codTurma;
            Console.WriteLine("Turmas disponiveis");
            Turmas.ForEach(c => Console.WriteLine(c));

            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            return aTurma;
        }
        public Coordenador RetornaCoordenadorPorId()
        {
            int matriculaCoordenador;
            Console.WriteLine("Coodenadores disponiveis");
            Coordenadores.ForEach(c => Console.WriteLine(c));

            Coordenador Coordenador = null;

            while (Coordenador == null)
            {
                Console.WriteLine("Digite a matricula do aluno!\n");
                while (!int.TryParse(Console.ReadLine(), out matriculaCoordenador))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                Coordenador = Coordenadores.FirstOrDefault(c => c.Matricula == matriculaCoordenador);
            }
            return Coordenador;
        }


        public void RemovePessoasTurma()
        {
            Console.Clear();

            int codTurma, matriculaPessoa;

            Console.WriteLine("Turmas cadastradas!");
            Turmas.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Escolha a turma pelo ID!");
            // Relização das validaçoes com while para prender o usuario ate ele escrever corretamente 
            Turma aTurma = null;

            while (aTurma == null)
            {
                Console.WriteLine("Digite o Código da turma!\n");
                while (!int.TryParse(Console.ReadLine(), out codTurma))
                    Console.WriteLine("matricula inválida, digite novamente!\n");

                aTurma = Turmas.FirstOrDefault(c => c.CodigoTurma == codTurma);
            }

            Console.WriteLine("Digite 1 para remover aluno da turma e 2 para remover professor e 3 para remover Coordenador");
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

                        oAluno = Alunos.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }

                    aTurma.Alunos.Remove(oAluno);

                    break;

                case "2":
                    Professor oProfessor = null;

                    while (oProfessor == null)
                    {

                        Console.WriteLine("Digite a matricula do professor!\n");
                        while (!int.TryParse(Console.ReadLine(), out matriculaPessoa))
                            Console.WriteLine("matricula inválida, digite novamente!\n");

                        oProfessor = Professores.FirstOrDefault(c => c.Matricula == matriculaPessoa);
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

                        Coordenador = Coordenadores.FirstOrDefault(c => c.Matricula == matriculaPessoa);
                    }
                    aTurma.Coordenador = null;
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

        public  void VoltarAoMenu(string voltar)
        {
            if (voltar.StartsWith("1"))
                MenuCentral();
        }
    }
}
