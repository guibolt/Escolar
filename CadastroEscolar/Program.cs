using CadastroEscolar.Model;
using CadastroTurma;
using CadastroTurma.Model;
using Core.Util;
using System;
using System.Collections.Generic;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
            var nossaEscola = new Escola();
            nossaEscola = Arquivo.Recuperar();
            Operacoes.MenuCentral(nossaEscola);
        }
    }
}
    