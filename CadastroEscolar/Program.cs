using CadastroEscolar.Model;
using System;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
          

            //var nossaEscola = Arquivo.Recuperar();
            //nossaEscola nossaescola new Escola();
            var nossaEscola = new Escola();
            View.MenuCentral(nossaEscola);
        }
        
    }
    
}
