using Kserokopiarka;
using ver1;

class Program
{
    static void Main()
        //sprawdzenie zadania 1 
    {
        var xerox = new Copier();
        xerox.PowerOn();
        IDocument doc1 = new PDFDocument("aaa.pdf");
        xerox.Print(in doc1);

        IDocument doc2;
        xerox.Scan(out doc2);

        xerox.ScanAndPrint();
        System.Console.WriteLine(xerox.Counter);
        System.Console.WriteLine(xerox.PrintCounter);
        System.Console.WriteLine(xerox.ScanCounter);

        //sprawdzenie zadania 2 
        MultifunctionalDevice mfd = new MultifunctionalDevice();
        mfd.PowerOn();

        IDocument document = new PDFDocument("document.pdf");
        mfd.Print(document);

        IDocument scannedDocument;
        mfd.Scan(out scannedDocument);

        mfd.ScanAndPrint();

        string recipientNumber = "123456789";
        mfd.Fax(document, recipientNumber);

        mfd.PowerOff();
    }
}