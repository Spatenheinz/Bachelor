using SME;
using System;

namespace opt2
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
                var round1 = new RoundOdd();
                round1.In = setup.Out;
                setup.axi_out = round1.axi_in;
                var round2 = new RoundEven();
                round2.In = round1.Out;
                round1.axi_out = round2.axi_in;
                var round3 = new RoundOdd();
                round3.In = round2.Out;
                round2.axi_out = round3.axi_in;
                var round4 = new RoundEven();
                round4.In = round3.Out;
                round3.axi_out = round4.axi_in;
                var round5 = new RoundOdd();
                round5.In = round4.Out;
                round4.axi_out = round5.axi_in;
                var round6 = new RoundEven();
                round6.In = round5.Out;
                round5.axi_out = round6.axi_in;
                var round7 = new RoundOdd();
                round7.In = round6.Out;
                round6.axi_out = round7.axi_in;
                var round8 = new RoundEven();
                round8.In = round7.Out;
                round7.axi_out = round8.axi_in;
                var round9 = new RoundOdd();
                round9.In = round8.Out;
                round8.axi_out = round9.axi_in;
                var round10 = new RoundEven();
                round10.In = round9.Out;
                round9.axi_out = round10.axi_in;
                var round11 = new RoundOdd();
                round11.In = round10.Out;
                round10.axi_out = round11.axi_in;
                var round12 = new RoundEven();
                round12.In = round11.Out;
                round11.axi_out = round12.axi_in;
                var round13 = new RoundOdd();
                round13.In = round12.Out;
                round12.axi_out = round13.axi_in;
                var round14 = new RoundEven();
                round14.In = round13.Out;
                round13.axi_out = round14.axi_in;
                var round15 = new RoundOdd();
                round15.In = round14.Out;
                round14.axi_out = round15.axi_in;
                var round16 = new RoundEven();
                round16.In = round15.Out;
                round15.axi_out = round16.axi_in;
                var round17 = new RoundOdd();
                round17.In = round16.Out;
                round16.axi_out = round17.axi_in;
                var round18 = new RoundEven();
                round18.In = round17.Out;
                round17.axi_out = round18.axi_in;
                var round19 = new RoundOdd();
                round19.In = round18.Out;
                round18.axi_out = round19.axi_in;
                var roundC = new RoundCombine();
                roundC.In = round19.Out;
                round19.axi_out = roundC.axi_in;
                var XOR = new RoundXOR();
                XOR.In = roundC.Out;
                roundC.axi_out = XOR.axi_in;
                tester.HashStream = XOR.Out;
                tester.axi_State = setup.axi_in;
                XOR.axi_out = tester.axi_Stream;
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
