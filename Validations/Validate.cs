namespace RotatePdf.Validations;

internal static class Validate
{
    internal static void IsArgsNullOrEmpty(string[] args)
    {
        // Verifica se o argumento é NULL ou VAZIO
        if (args.Length == 0)
        {
            LogError("Nenhum argumento fornecido! Comando: dotnet run [meu_arquivo.pdf]");
        }
    }

    internal static void IsFileExist(string args)
    {
        // Verifica se o arquivo EXISTE
        if (!File.Exists(args))
        {
            LogError($"Arquivo {args} não encontrado.");
        }
    }


    private static void LogError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[ERRO] {msg} \n");
        Console.ReadKey();
        Console.ResetColor();
        Environment.Exit(0);
    }
}