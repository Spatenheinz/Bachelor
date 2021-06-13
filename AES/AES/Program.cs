using System;
using SME;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var aes = new AESe();
                var tester = new Tester();
                aes.PlainText = tester.PlainText;
                aes.axi_Cipher = tester.axi_Cipher;
                tester.Cipher = aes.Cipher;
                tester.axi_Text = aes.axi_Text;
                    sim.AddTopLevelInputs(aes.PlainText, aes.axi_Cipher)
                        .AddTopLevelOutputs(aes.Cipher, aes.axi_Text)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
