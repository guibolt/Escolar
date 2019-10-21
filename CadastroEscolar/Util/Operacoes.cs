using System;
using System.IO;
using System.Linq;
using CadastroEscolar.Model;
using Newtonsoft.Json;

namespace CadastroTurma
{
    public static class Operacoes
    {
        public static string arquivoDb = AppDomain.CurrentDomain.BaseDirectory + "escola.json";

        //Método para prevenir a repetição do random
        public static int ChecaId(string tipo, int Matricula, Escola escola)
        {
            switch (tipo.ToUpper())
            {
                case "PROFESSOR":
                    while (escola.Professores.Any(c => c.Matricula == Matricula) || escola.Turmas.Any(c => c.Professor.Matricula == Matricula)) 
                        return new Random().Next(0000, 9999);
                    break;

                case "COORDENADOR":
                    while (escola.Coordenadores.Any(c => c.Matricula == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                case "ALUNO":
                    while (escola.Alunos.Any(c => c.Matricula == Matricula) || escola.Turmas.Any(e => e.Alunos.Any(a => a.Matricula == Matricula )))
                        return new Random().Next(0000, 9999);
                    break;

                case "TURMA":
                    while (escola.Turmas.Any(c => c.CodigoTurma == Matricula))
                        return new Random().Next(0000, 9999);
                    break;

                default:
                    break;

            }
            return 0;
        }
        //Método para a validação da string do nome
        public static bool ChecaString(string nome)
        {
            foreach (var letra in nome)
            {
                if (int.TryParse(letra.ToString(), out int result))
                    return false;
            }

            return true;
        }

        public static bool ValidaOpcao(string opcao)
        {
            if (opcao.ToUpper() == "SIM" || opcao.ToUpper() == "NÃO" || opcao.ToUpper() == "NAO")
                return true;

            return false;
        }

        //método para realizar a deserialazação
        public static Escola Recuperar()
        {
            try { return JsonConvert.DeserializeObject<Escola>(File.ReadAllText(arquivoDb)); }
            catch (Exception) { return default; }
        }
        //Método para escrever o arquivo json
        public static void Salvar(Escola Arquivo)
        {
            try { File.WriteAllText(arquivoDb, JsonConvert.SerializeObject(Arquivo)); }
            catch (JsonException ex)

            { throw ex; }
        }

    }
}