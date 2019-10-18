using System;
using System.Collections.Generic;
using System.Text;
using CadastroTurma.Model;

namespace CadastroTurma
{
    public class Operacoes
    {
        public void CadastrarTurma()
        {
            while (true)
            {
                Console.WriteLine("\nDigite 1 para realizar o cadastro e 2 para sair! \n");
                string Decisao = Console.ReadLine();

                switch (Decisao)
                {
                    case "1":
                        Turma umaTurma = new Turma(new Random().Next(000, 999), CadastraProfessor(), CadastraAlunos());
                        Console.WriteLine(MostraTurma(umaTurma));
                        break;

                    case "2":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }
        public List<Aluno> CadastraAlunos()
        {
            List<Aluno> listaAlunos = new List<Aluno>();

            Console.WriteLine("Quantos alunos deseja cadastar?\n");
            int numCadastro, idadeAluno;
            long cpf;
            char sexo;
            string opcao;
            bool bolsa = false;

            while (!int.TryParse(Console.ReadLine(), out numCadastro))
                Console.WriteLine("Numero inválido, digite novamente!\n");

            for (int i = 0; i < numCadastro; i++)
            {
                Console.WriteLine($"Digite o nome do aluno #{i + 1}\n");
                string nomeDoAluno = Console.ReadLine();

                while (!ChecaString(nomeDoAluno) || nomeDoAluno.Length < 3)
                {
                    Console.WriteLine("Nome inválido, digite o nome novamente!\n");
                    nomeDoAluno = Console.ReadLine();
                }

                Console.WriteLine($"Digite a idade do {nomeDoAluno}!\n");
                while (!int.TryParse(Console.ReadLine(), out idadeAluno) || idadeAluno < 6)
                    Console.WriteLine("Idade inválida, digite  novamente!\n");

                Console.WriteLine($"Digite o sexo do {nomeDoAluno}");
                while (!char.TryParse(Console.ReadLine(), out sexo) || sexo.ToString().ToUpper() != "F" && sexo.ToString().ToUpper() != "M")
                    Console.WriteLine("Sexo inválido, realize o cadastro novamente!\n");

                Console.WriteLine($"Digite o CPF do {nomeDoAluno}");
                while (!long.TryParse(Console.ReadLine(), out cpf) || cpf.ToString().Length < 11 || cpf.ToString().Length > 11)
                    Console.WriteLine("Cpf inválido, realize o cadastro novamente!\n");

                Console.WriteLine("Digite se o aluno é bolsista, sim ou não?");
                opcao = Console.ReadLine();
                while (!ValidaOpcao(opcao))
                {
                    Console.WriteLine("Opção inválida, digite novamente!");
                    opcao = Console.ReadLine();

                    if (opcao == "SIM")
                        bolsa = true;
                    else
                        bolsa = false;
                }

                int ra = new Random().Next(00000000, 99999999);

                listaAlunos.Add(new Aluno(nomeDoAluno, idadeAluno, sexo, cpf, ra, bolsa)); ;
                Console.Clear();
                Console.WriteLine($"Aluno {nomeDoAluno} Cadastrado com sucesso! \n");
            }
            return listaAlunos;
        }

        public Professor CadastraProfessor()
        {
            int idadeProfessor;
            long cpf;
            char sexo;

            Console.WriteLine("Digite o nome do Professor\n");
            string nomeDoProfessor = Console.ReadLine();

            //Vallidaçoes usando o try parse e o while para prender o usuario
            while (!ChecaString(nomeDoProfessor) || nomeDoProfessor.Length < 3)
            {
                Console.WriteLine("Nome inválido, digite o nome novamente!\n");
                nomeDoProfessor = Console.ReadLine();
            }

            Console.WriteLine("Digite a idade do Professor!\n");
            while (!int.TryParse(Console.ReadLine(), out idadeProfessor) || idadeProfessor < 18)
                Console.WriteLine("Idade inválida, digite novamente!\n");

            Console.WriteLine("Digite o sexo do Professor\n");
            while (!char.TryParse(Console.ReadLine(), out sexo) || sexo.ToString().ToUpper() != "F" && sexo.ToString().ToUpper() != "M")
                Console.WriteLine("Sexo inválido, realize o cadastro novamente!\n");

            Console.WriteLine("Digite o CPF do Professor\n");
            while (!long.TryParse(Console.ReadLine(), out cpf) || cpf.ToString().Length < 11 || cpf.ToString().Length > 11)
                Console.WriteLine("Cpf inválido, realize o cadastro novamente!\n");

            int matricula = new Random().Next(00000000, 99999999);

            Console.Clear();
            Console.WriteLine("Professor cadastrado com sucesso!\n");
            return new Professor(nomeDoProfessor, idadeProfessor, sexo, cpf, matricula);
        }

        public string MostraTurma(Turma turma)
        {
            Console.WriteLine("Alunos:\n");
            //foreach percorrendo a lista de alunos da turma especifica
            foreach (var Pessoas in turma.Alunos)
                Console.WriteLine($"{Pessoas} \n");

            return $"CodTurma: {turma.CodigoTurma} Nome do professor: {turma.Professor.Nome}";
        }

        //Método para a validação da string do nome
        public bool ChecaString(string nome)
        {
            foreach (var letra in nome)
            {
                if (int.TryParse(letra.ToString(), out int result))
                    return false;
            }

            return true;
        }

        public bool ValidaOpcao(string opcao)
        {
            if (opcao.ToUpper() == "SIM" || opcao.ToUpper() == "NÃO" || opcao.ToUpper() == "NAO")
                return true;

            return false;
        }
    }
}
