using System;
using System.IO;
using System.Reflection;

namespace ExemploApiEF.Integracao.Testes
{
    public class DiretorioSolution
    {
        public static string ObterCaminhoDaSolution()
        {
            var diretorio = new DirectoryInfo(ObterDiretorioDosAssemblys());

            while (diretorio != null && diretorio.GetFiles("*.sln").Length == 0)
            {
                diretorio = diretorio.Parent;
            }

            if (diretorio == null)
                throw new DirectoryNotFoundException();

            return diretorio.FullName;
        }

        public static string ObterDiretorioDosAssemblys()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static string[] NomesDosArquivosNaPasta(string caminho, string extensaoDosArquivos)
        {
            var files = Directory.GetFiles(caminho, extensaoDosArquivos);
            for (var i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }
    }
}