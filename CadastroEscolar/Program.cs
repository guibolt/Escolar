using CadastroEscolar.Model;
using CadastroTurma;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
            var nossaEscola = Operacoes.Recuperar();
            nossaEscola = nossaEscola ?? new Escola();
            nossaEscola.MenuCentral();
            Operacoes.Salvar(nossaEscola);
        }
    }
}
    