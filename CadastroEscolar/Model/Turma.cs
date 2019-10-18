using CadastroEscolar.Model;
using System.Collections.Generic;

namespace CadastroTurma.Model
{
    public class Turma
    {
        public int CodigoTurma { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public Coordenador Coordenador { get; set; }
        public int QtdMax { get; set; }
      

        public Turma(int codigoTurma, Professor professor, List<Aluno> alunos, int qtdmax)
        {
            CodigoTurma = codigoTurma;
            Professor = professor;
            Alunos = alunos;
            QtdMax = qtdmax;
        }
        
    }
}
