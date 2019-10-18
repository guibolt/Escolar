using CadastroTurma.Model;
using System;
using System.Collections.Generic;

namespace CadastroEscolar.Model
{
    public class Coordenador : Pessoa
    {
        public int NumeroRegistro { get; set; }
        public List<int> CodTurmas { get; set; } = new List<int>();

      
        public Coordenador(string nome, int idade, char sexo, long cpf, int numeroRegistro, List<int> codturmas) : base(nome, idade, sexo, cpf)
        {
            NumeroRegistro = numeroRegistro;
            CodTurmas = codturmas;
        }

        public override dynamic CadastrarPessoa()
        {
            throw new NotImplementedException();
        }

    }
}
