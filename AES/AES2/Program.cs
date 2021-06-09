using System;
using SME;

namespace AES2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var aes = new AESe();
                var tester = new Tester();
                aes.In = tester.PlainText;
                aes.axi_out = tester.axi_Cipher;
                tester.Cipher = aes.Out;
                tester.axi_Text = aes.axi_in;
                    sim.AddTopLevelInputs(aes.In, aes.axi_out)
                        .AddTopLevelOutputs(aes.Out, aes.axi_in)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        // .BuildCSVFile()
                        // .BuildGraph()
                        // .BuildVHDL()
                        .Run();
            }
        }
    }
}
