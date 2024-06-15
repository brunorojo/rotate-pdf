using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatePdf
{
    internal class Validate
    {
        internal void IsArgsNullOrEmpty(string[] args)
        {
            // Verifica se o argumento é NULL ou VAZIO
            if (args.Length == 0)
            {
                LogError("Nenhum argumento fornecido! Utilize: dotnet run [meu_arquivo.pdf]");
            }
        }

        internal void IsFileExist(string args)
        {
            // Verifica se o arquivo EXISTE
            if (!File.Exists(args))
            {
                LogError($"Arquivo {args} não encontrado.");
            }
        }



        private void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERRO] {msg} \n");
            Console.ReadKey();
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
