using CadastroEscolar.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Core.Util
{
    public static class Arquivo
    {
        public static string arquivoDb = AppDomain.CurrentDomain.BaseDirectory + "escola.json";
        public static Escola Recuperar()
        {
            try { return JsonConvert.DeserializeObject<Escola>(File.ReadAllText(arquivoDb)); }
            catch (Exception) { return default; }
        }
        public static void Salvar(Escola Arquivo)
        {
            try { File.WriteAllText(arquivoDb, JsonConvert.SerializeObject(Arquivo)); }
            catch (JsonException ex)

            {  throw ex; }
        }
    }
}
