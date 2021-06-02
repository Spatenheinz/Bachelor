using System;
using SME;

namespace opt1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var tester = new Tester();
                var round1 = new Round1();
                round1.PlainText = tester.PlainText;
                tester.axi_Text = round1.axi_in;
                var round2 = new Round2();
                round2.In = round1.Out;
                round1.axi_out = round2.axi_in;
                var round3 = new Round3();
                round3.In = round2.Out;
                round2.axi_out = round3.axi_in;
                var round4 = new Round4();
                round4.In = round3.Out;
                round3.axi_out = round4.axi_in;
                tester.Cipher = round4.Out;
                round4.axi_out = tester.axi_Cipher;
                    sim.AddTopLevelInputs(tester.PlainText, round4.axi_out)
                        .AddTopLevelOutputs(round4.Out, tester.axi_Text)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
