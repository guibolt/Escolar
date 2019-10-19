using CadastroEscolar.Model;
using CadastroTurma;
using Core.Util;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
            var nossaEscola = new Escola();
            Arquivo.Recuperar();
            Operacoes.MenuCentral(nossaEscola);
        }
    }
}
    