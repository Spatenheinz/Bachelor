using SME;
using System;

namespace opt1
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var tester = new Tester();
                var setup = new Round1();
                setup.seed = tester.State;
                setup.axi_out = tester.axi_Stream;
                var round2 = new Round2();
                round2.In = setup.Out;
                setup.axi_out = round2.axi_in;
                var round3 = new Round2();
                round3.In = round2.Out;
                round2.axi_out = round3.axi_in;
                var round4 = new Round2();
                round4.In = round3.Out;
                round3.axi_out = round4.axi_in;
                var round5 = new Round2();
                round5.In = round4.Out;
                round4.axi_out = round5.axi_in;
                var round6 = new Round2();
                round6.In = round5.Out;
                round5.axi_out = round6.axi_in;
                var round7 = new Round2();
                round7.In = round6.Out;
                round6.axi_out = round7.axi_in;
                var round8 = new Round2();
                round8.In = round7.Out;
                round7.axi_out = round8.axi_in;
                var round9 = new Round2();
                round9.In = round8.Out;
                round8.axi_out = round9.axi_in;
                var round10 = new Round10();
                round10.In = round9.Out;
                round9.axi_out = round10.axi_in;
                var combiner = new Round11();
                combiner.In = round10.Out;
                round10.axi_out = combiner.axi_in;
                tester.HashStream = combiner.Out;
                tester.axi_State = setup.axi_in;
                combiner.axi_out = tester.axi_Stream;
                    sim.AddTopLevelInputs(tester.State, tester.axi_Stream)
                        .AddTopLevelOutputs(tester.HashStream, tester.axi_State)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
