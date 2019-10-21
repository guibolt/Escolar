using CadastroTurma;
using CadastroTurma.Model;
using System;
using System.Collections.Generic;

namespace CadastroEscolar.Model
{
    public class Coordenador : Pessoa
    {
        public Coordenador() {}
        public List<int> CodTurmas { get; set; } = new List<int>();

        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Matricula: {Matricula} Cpf: {Cpf} \n";
        public override void CadastrarPessoa()
        {
            base.CadastrarPessoa();

            //var numValida = Operacoes.ChecaId("coordenador", Matricula, escola);

            //if (numValida != 0)
            //    Matricula = numValida;

            Console.Clear();
            Console.WriteLine($"{Nome} Cadastrado com sucesso! Matricula n° {Matricula} \n");
        }
    }
}
