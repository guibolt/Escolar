using CadastroEscolar.Model;
using System;

namespace CadastroTurma.Model
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public long Cpf { get; set; }
        public int Matricula { get; set; } = new Random().Next(0000, 9999);

        //Método virtual base para a realização do cadastro.
        public virtual void CadastrarPessoa(Escola escola)
        {
            int idadePessoa;
            char sexo;
            long cpf;

            Console.WriteLine($"Digite o nome  ou digite V para voltar o menu principal! \n");
            Nome = Console.ReadLine();

            Operacoes.VoltarAoMenu(Nome, escola);

            while (!Operacoes.ChecaString(Nome) || Nome.Length < 3)
            {
                Console.WriteLine("Nome inválido, digite o nome novamente!\n");
                Nome = Console.ReadLine();
            }

            Console.WriteLine($"Digite a idade do {Nome}!\n");
            while (!int.TryParse(Console.ReadLine(), out idadePessoa) || idadePessoa < 6)
                Console.WriteLine("Idade inválida, digite  novamente!\n");

            Idade = idadePessoa;

            Console.WriteLine($"Digite o sexo do {Nome}");
            while (!char.TryParse(Console.ReadLine(), out sexo) || sexo.ToString().ToUpper() != "F" && sexo.ToString().ToUpper() != "M")
                Console.WriteLine("Sexo inválido, realize o cadastro novamente!\n");

            Sexo = sexo;

            Console.WriteLine($"Digite o CPF do {Nome}");
            while (!long.TryParse(Console.ReadLine(), out cpf) || cpf.ToString().Length < 11 || cpf.ToString().Length > 11)
                Console.WriteLine("Cpf inválido, realize o cadastro novamente!\n");

            Cpf = cpf;

        }
    }
}
