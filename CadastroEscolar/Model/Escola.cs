using CadastroTurma.Model;
using System;
using System.Collections.Generic;

namespace CadastroEscolar.Model
{
    public class Escola
    {
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public List<Turma> Turmas { get; set; }  = new List<Turma>();
        public List<Professor> Professores { get; set; }  = new List<Professor>();
        public List<Coordenador> Coordenadores { get; set; } = new List<Coordenador>();
    }
}
