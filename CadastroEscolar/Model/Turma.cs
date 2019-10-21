﻿using CadastroEscolar.Model;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroTurma.Model
{
    public class Turma
    {
        public int CodigoTurma { get; set; } = new Random().Next(0000, 9999);
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }  = new List<Aluno>();
        public int CapacidadeMax { get; private set; }
        public Coordenador Coordenador { get; set; }

        public Turma() { }

        public void CadastrarTurma(Escola escola)
        {
            int quantidade;
            Console.WriteLine("Coordenadores:\n");
            escola.Coordenadores.ForEach(e => Console.WriteLine(e));

            var oCoodenador = Operacoes.RetornaCoordenador(escola);

            Console.WriteLine("Digite a quantiade maxima da turma!\n");
            while (!int.TryParse(Console.ReadLine(), out quantidade))
                Console.WriteLine("quantidade inválida, digite novamente!\n");

            Coordenador = oCoodenador;
            CapacidadeMax = quantidade;

            Arquivo.Salvar(escola);
        }

        public override string ToString()
        {
            if (Professor == null)
                return $"CodTurma: {CodigoTurma} Nome do Coordenador! {Coordenador.Nome} Capacidade da turma: {CapacidadeMax}\n";


            return $"CodTurma: {CodigoTurma} Nome do professor: {Professor.Nome} Nome do Coordenador: {Coordenador.Nome} Capacidade da turma: {CapacidadeMax}\n";
        }

    }
}
