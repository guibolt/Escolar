using System;

namespace CadastroTurma.Model
{
    public class Professor : Pessoa
    {
        public int Matricula { get; set; }

        public Professor(string nome, int idade, char sexo, long cpf,int matricula) : base(nome, idade, sexo, cpf) =>  Matricula = matricula;

        public override string ToString() => $"Nome: {Nome} Idade: {Idade} Sexo: {Sexo.ToString().ToUpper()} Matricula: {Matricula} Cpf: {Cpf} \n";

        public override dynamic CadastrarPessoa()
        {
            throw new NotImplementedException();
        }
    }
}
