using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ver1.IDevice;
using ver1;

namespace Zadanie_3;

public class MultifunctionalDevice : Copier, IFax
{
    public void Fax(IDocument document, string recipientNumber)
    {
        if (GetState() == State.on)
        {
            Console.WriteLine($"{DateTime.Now} Fax: {document.GetFileName()} to {recipientNumber}");
        }
    }
}
