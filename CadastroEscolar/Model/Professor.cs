using CadastroEscolar.Model;
using System;

namespace CadastroTurma.Model
{
    public class Professor : Pessoa
    {
        public Coordenador Coordenador { get; set; }
        public int QuantidadeTurmas { get; set; }
        public Professor() { }
        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Matricula: {Matricula} Quantidade de Turmas: {QuantidadeTurmas}\n";

        public override void CadastrarPessoa(Escola escola)
        {
            base.CadastrarPessoa(escola);
            if(Idade < 24)
            {
                Console.WriteLine("É necessario ter ao menos 24 anos para realizar o cadastro de um professor! \n Aperte enter para cadatrar novamente!");
                Console.ReadLine();
                CadastrarPessoa(escola);
            }

            var numValida = Operacoes.ChecaId("professor", Matricula, escola);

            if (numValida != 0)
                Matricula = numValida;

            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n");
        }
            
    }
}
