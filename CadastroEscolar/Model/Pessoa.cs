using System;
using System.Text.RegularExpressions;

namespace CadastroEscolar.Model
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public int Matricula { get; set; } = new Random().Next(0000, 9999);

        //Método virtual base para a realização do cadastro.
        public virtual void CadastrarPessoa(Escola escola)
        {
            Operacoes.MudarBack();
            char sexo;
 
            Console.WriteLine("Pressione enter para o proximo item do cadastro ou esc para sair\n");
            Operacoes.VoltarMenu(Console.ReadKey(), escola);

            Console.WriteLine($"Digite o nome \n");
            Nome = Console.ReadLine();

            while (!Regex.IsMatch(Nome.ToLower(), "^[a-z áéíóúàèìòùâêîôûãõç]+$") || Nome.Length < 3)
            {
                Console.WriteLine("Nome deve conter somenente letras e ter no minimo 3 de tamanho !\n");
                Nome = Console.ReadLine();
            }

            Console.WriteLine("Pressione enter para o proximo item do cadastro ou esc  para sair\n");
            Operacoes.VoltarMenu(Console.ReadKey(), escola);

            Console.WriteLine($"Digite o sexo do {Nome}");
            while (!char.TryParse(Console.ReadLine(), out sexo) || sexo.ToString().ToUpper() != "F" && sexo.ToString().ToUpper() != "M")
                Console.WriteLine("Sexo inválido, digite f ou m!\n");

            Sexo = sexo;
        }
    }
}
