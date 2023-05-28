using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Kserokopiarka
{
    public interface IFax
    {
        void Fax(IDocument document, string recipientNumber);
    }

}
