using System;
using ver1;

namespace Kserokopiarka
{
    public class Copier : IDevice
    {
        private int printCounter;
        private int scanCounter;
        private int counter;
        private bool powerOn;

        public int PrintCounter => printCounter;
        public int ScanCounter => scanCounter;
        public int Counter => counter;

        public Copier()
        {
            printCounter = 0;
            scanCounter = 0;
            counter = 0;
            powerOn = false;
        }

        public void PowerOn()
        {
            if (!powerOn)
            {
                powerOn = true;
                counter++;
            }
        }

        public void PowerOff()
        {
            if (powerOn)
            {
                powerOn = false;
            }
        }

        public IDevice.State GetState()
        {
            return powerOn ? IDevice.State.on : IDevice.State.off;
        }

        public void Print(in IDocument document)
        {
            if (powerOn)
            {
                printCounter++;
                Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;
            if (powerOn)
            {
                scanCounter++;
                string extension = GetExtensionFromFormatType(formatType);
                string fileName = $"Scan{scanCounter}.{extension}";
                document = CreateDocument(formatType, fileName);
                Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}");
            }
        }

        public void ScanAndPrint()
        {
            if (powerOn)
            {
                scanCounter++;
                string fileName = $"Scan{scanCounter}.jpg";
                var document = CreateDocument(IDocument.FormatType.JPG, fileName);
                Print(document);
                Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}");
            }
        }

        private IDocument CreateDocument(IDocument.FormatType formatType, string fileName)
        {
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    return new PDFDocument(fileName);
                case IDocument.FormatType.JPG:
                    return new ImageDocument(fileName);
                case IDocument.FormatType.TXT:
                    return new TextDocument(fileName);
                default:
                    throw new ArgumentException("Invalid document format type.");
            }
        }

        private string GetExtensionFromFormatType(IDocument.FormatType formatType)
        {
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    return "pdf";
                case IDocument.FormatType.JPG:
                    return "jpg";
                case IDocument.FormatType.TXT:
                    return "txt";
                default:
                    throw new ArgumentException("Invalid document format type.");
            }
        }
    }
}
