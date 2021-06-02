using System;
using SME;

namespace opt2
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
                var round5 = new Round5();
                round5.In = round4.Out;
                round4.axi_out = round5.axi_in;
                var round6 = new Round6();
                round6.In = round5.Out;
                round5.axi_out = round6.axi_in;
                var round7 = new Round7();
                round7.In = round6.Out;
                round6.axi_out = round7.axi_in;
                var round8 = new Round8();
                round8.In = round7.Out;
                round7.axi_out = round8.axi_in;
                var round9 = new Round9();
                round9.In = round8.Out;
                round8.axi_out = round9.axi_in;
                var round10 = new Round10();
                round10.In = round9.Out;
                round9.axi_out = round10.axi_in;
                var round11 = new Round11();
                round11.In = round10.Out;
                round10.axi_out = round11.axi_in;
                tester.Cipher = round11.Out;
                round11.axi_out = tester.axi_Cipher;
                    sim.AddTopLevelInputs(tester.PlainText, round11.axi_out)
                        .AddTopLevelOutputs(round11.Out, tester.axi_Text)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        // .BuildCSVFile()
                        // .BuildGraph()
                        // .BuildVHDL()
                        .Run();
            }
        }
    }
}
