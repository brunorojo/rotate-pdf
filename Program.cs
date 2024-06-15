using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

class Program
{
    static void Main(string[] args)
    {
        const int MaxFileLength = 128;

        // Verifica quantidade de argumentos
        if (args.Length != 1)
        {
            Console.WriteLine("\n[ERRO] Comando inválido! Utilize: dotnet run [meu_arquivo.pdf]");
            return;
        }

        //Verifica tamanho do arquivo
        if (args[0].Length > MaxFileLength)
        {
            Console.WriteLine($"\n[Erro] O arquivo '{args}' excede o limite máximo de {MaxFileLength} caracteres.");
            return;
        }

        string inputFilePath = args[0];
        string outputFilePath = "OUTPUT_" + inputFilePath;

        try
        {
            // Leia o arquivo PDF
            using (PdfDocument document = PdfReader.Open(inputFilePath, PdfDocumentOpenMode.Modify))
            {
                // Girar cada página do documento PDF em 180º
                foreach (PdfPage page in document.Pages)
                {
                    page.Rotate = (page.Rotate + 180) % 360;
                }

                // Salve o documento alterado
                document.Save(outputFilePath);
            }


            Console.WriteLine($"\nArquivo PDF girado com sucesso! {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERRO] Erro ao processar o arquivo: {ex.Message}");
        }
    }
}
