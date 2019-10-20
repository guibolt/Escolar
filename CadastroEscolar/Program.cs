﻿using CadastroEscolar.Model;
using CadastroTurma;
using Core.Util;

namespace CadastroEscolar
{
    class Program
    {
        static void Main(string[] args)
        {
            var nossaEscola = Arquivo.Recuperar();
            nossaEscola = nossaEscola ?? new Escola();
            Operacoes.MenuCentral(nossaEscola);
        }
    }
}
    