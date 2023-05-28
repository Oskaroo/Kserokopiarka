using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
//Testy zadanie 2
namespace Kserokopiarka
{
    [TestClass]
    public class MultifunctionalDeviceTests
    {
        [TestMethod]
        public void MultifunctionalDevice_GetState_StateOn()
        {
            var device = new MultifunctionalDevice();
            device.PowerOn();

            Assert.AreEqual(IDevice.State.on, device.GetState());
        }

        [TestMethod]
        public void MultifunctionalDevice_GetState_StateOff()
        {
            var device = new MultifunctionalDevice();
            device.PowerOff();

            Assert.AreEqual(IDevice.State.off, device.GetState());
        }

        [TestMethod]
        public void MultifunctionalDevice_Print()
        {
            var device = new MultifunctionalDevice();
            device.PowerOn();

            var document = new PDFDocument("document.pdf");
            device.Print(document);

            Assert.AreEqual(1, device.PrintCounter);
        }

        [TestMethod]
        public void MultifunctionalDevice_Scan()
        {
            var device = new MultifunctionalDevice();
            device.PowerOn();

            IDocument scannedDocument;
            device.Scan(out scannedDocument);

            Assert.AreEqual(1, device.ScanCounter);
            Assert.IsNotNull(scannedDocument);
        }

        [TestMethod]
        public void MultifunctionalDevice_ScanAndPrint()
        {
            var device = new MultifunctionalDevice();
            device.PowerOn();

            device.ScanAndPrint();

            Assert.AreEqual(1, device.ScanCounter);
            Assert.AreEqual(1, device.PrintCounter);
        }

        [TestMethod]
        public void MultifunctionalDevice_Fax()
        {
            var device = new MultifunctionalDevice();
            device.PowerOn();

            var document = new PDFDocument("document.pdf");
            string recipientNumber = "123456789";
            device.Fax(document, recipientNumber);
        }
    }

}
