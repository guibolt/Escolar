using CadastroEscolar.Model;
using Core.Util;
using System;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
            var nossaEscola = Arquivo.Recuperar();
            nossaEscola = nossaEscola ?? new Escola();
            View.MenuCentral(nossaEscola);
        }

    }
}
