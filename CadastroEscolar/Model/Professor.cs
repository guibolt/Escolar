using CadastroEscolar.Model;
using System;

namespace CadastroTurma.Model
{
    public class Professor : Pessoa
    {
        public Coordenador Coordenador { get; set; }
        public int QuantidadeTurmas { get; set; }
        public Professor() { }
        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Matricula: {Matricula} Cpf: {Cpf} \n";

        public override void CadastrarPessoa()
        {
            base.CadastrarPessoa();

            //var numValida = Operacoes.ChecaId("professor", Matricula, escola);

            //if (numValida != 0)
            //    Matricula = numValida;

            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n");
        }
            
    }
}
