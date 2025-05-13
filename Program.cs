using PdfSharpCore.Pdf.IO;
using RotatePdf.Validations;

namespace RotatePdf;

internal static class Program
{
    private static void Main(string[] args)
    { 
        //Verifica argumentos se null ou vazio
        Validate.IsArgsNullOrEmpty(args);
        Validate.IsFileExist(args[0]);

        var input = args[0];
        Console.Clear();

        // [DEBUG] Testes de simulacao do arrasto de arquivo para o executavel
        //args[0] = "C:\\Users\\bruno\\source\\RotatePdf\\arquivo-pdf.pdf"; 

        var inputFileName = Path.GetFileName(input);
        var inputFolderName = Path.GetDirectoryName(input);
        var outputFileName = "OUTPUT_" + inputFileName;
        var outputFilePath = Path.Combine(inputFolderName!, outputFileName);

        Console.WriteLine($"[DEBUG] ..........input: [{input}]");
        Console.WriteLine($"[DEBUG] ..inputFileName: [{inputFileName}]");
        Console.WriteLine($"[DEBUG] inputFolderName: [{inputFolderName}]");
        Console.WriteLine($"[DEBUG] .outputFileName: [{outputFileName}]");
        Console.WriteLine($"[DEBUG] .outputFilePath: [{outputFilePath}]");

        try
        {
            // Lê arquivo PDF
            using (var document = PdfReader.Open(inputFileName, PdfDocumentOpenMode.Modify))
            {
                // Gira cada página do documento PDF em 180º
                foreach (var page in document.Pages)
                {
                    page.Rotate = (page.Rotate + 180) % 360;
                }

                // Salvar
                document.Save(outputFileName);
            }

            Console.WriteLine($"\nArquivo PDF girado com sucesso! {outputFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERRO] Erro ao processar arquivo: {ex.Message}");
        }

        Console.ReadKey();
    }
}