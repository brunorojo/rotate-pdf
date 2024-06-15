using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using RotatePdf;

class Program
{
    static void Main(string[] args)
    {
        //Verifica argumentos se null ou vazio

        var validate = new Validate();
        validate.IsArgsNullOrEmpty(args);
        validate.IsFileExist(args[0]);

        string input = args[0].ToString();
        Console.Clear();

        //args[0] = "C:\\Users\\bruno\\source\\RotatePdf\\arquivo-pdf.pdf";//simulando arrasto de arquivo



        string inputFileName = Path.GetFileName(input);
        string inputFolderName = Path.GetDirectoryName(input);
        string outputFileName = "OUTPUT_" + inputFileName;
        string outputFilePath = Path.Combine(inputFolderName, outputFileName);

        Console.WriteLine($"[INFO] ..........input: [{input}]");
        Console.WriteLine($"[INFO] ..inputFileName: [{inputFileName}]");
        Console.WriteLine($"[INFO] inputFolderName: [{inputFolderName}]");
        Console.WriteLine($"[INFO] .outputFileName: [{outputFileName}]");
        Console.WriteLine($"[INFO] .outputFilePath: [{outputFilePath}]");


        try
        {
            // Leia o arquivo PDF
            using (PdfDocument document = PdfReader.Open(inputFileName, PdfDocumentOpenMode.Modify))
            {
                // Girar cada página do documento PDF em 180º
                foreach (PdfPage page in document.Pages)
                {
                    page.Rotate = (page.Rotate + 180) % 360;
                }

                // Salve o documento alterado
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
