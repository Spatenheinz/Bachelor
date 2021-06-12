using SME;
using System;

namespace opt3
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
                var setup2 = new RoundEven_2();
                setup2.In = setup.Out;
                setup.axi_out = setup2.axi_in;
                var round1 = new RoundOdd_1();
                round1.In = setup2.Out;
                setup2.axi_out = round1.axi_in;
                var round1_2 = new RoundOdd_2();
                round1_2.In = round1.Out;
                round1.axi_out = round1_2.axi_in;
                var round2 = new RoundEven_1();
                round2.In = round1_2.Out;
                round1_2.axi_out = round2.axi_in;
                var round2_2 = new RoundEven_2();
                round2_2.In = round2.Out;
                round2.axi_out = round2_2.axi_in;
                var round3 = new RoundOdd_1();
                round3.In = round2_2.Out;
                round2_2.axi_out = round3.axi_in;
                var round3_2 = new RoundOdd_2();
                round3_2.In = round3.Out;
                round3.axi_out = round3_2.axi_in;
                var round4 = new RoundEven_1();
                round4.In = round3_2.Out;
                round3_2.axi_out = round4.axi_in;
                var round4_2 = new RoundEven_2();
                round4_2.In = round4.Out;
                round4.axi_out = round4_2.axi_in;
                var round5 = new RoundOdd_1();
                round5.In = round4_2.Out;
                round4_2.axi_out = round5.axi_in;
                var round5_2 = new RoundOdd_2();
                round5_2.In = round5.Out;
                round5.axi_out = round5_2.axi_in;
                var round6 = new RoundEven_1();
                round6.In = round5_2.Out;
                round5_2.axi_out = round6.axi_in;
                var round6_2 = new RoundEven_2();
                round6_2.In = round6.Out;
                round6.axi_out = round6_2.axi_in;
                var round7 = new RoundOdd_1();
                round7.In = round6_2.Out;
                round6_2.axi_out = round7.axi_in;
                var round7_2 = new RoundOdd_2();
                round7_2.In = round7.Out;
                round7.axi_out = round7_2.axi_in;
                var round8 = new RoundEven_1();
                round8.In = round7_2.Out;
                round7_2.axi_out = round8.axi_in;
                var round8_2 = new RoundEven_2();
                round8_2.In = round8.Out;
                round8.axi_out = round8_2.axi_in;
                var round9 = new RoundOdd_1();
                round9.In = round8_2.Out;
                round8_2.axi_out = round9.axi_in;
                var round9_2 = new RoundOdd_2();
                round9_2.In = round9.Out;
                round9.axi_out = round9_2.axi_in;
                var round10 = new RoundEven_1();
                round10.In = round9_2.Out;
                round9_2.axi_out = round10.axi_in;
                var round10_2 = new RoundEven_2();
                round10_2.In = round10.Out;
                round10.axi_out = round10_2.axi_in;
                var round11 = new RoundOdd_1();
                round11.In = round10_2.Out;
                round10_2.axi_out = round11.axi_in;
                var round11_2 = new RoundOdd_2();
                round11_2.In = round11.Out;
                round11.axi_out = round11_2.axi_in;
                var round12 = new RoundEven_1();
                round12.In = round11_2.Out;
                round11_2.axi_out = round12.axi_in;
                var round12_2 = new RoundEven_2();
                round12_2.In = round12.Out;
                round12.axi_out = round12_2.axi_in;
                var round13 = new RoundOdd_1();
                round13.In = round12_2.Out;
                round12_2.axi_out = round13.axi_in;
                var round13_2 = new RoundOdd_2();
                round13_2.In = round13.Out;
                round13.axi_out = round13_2.axi_in;
                var round14 = new RoundEven_1();
                round14.In = round13_2.Out;
                round13_2.axi_out = round14.axi_in;
                var round14_2 = new RoundEven_2();
                round14_2.In = round14.Out;
                round14.axi_out = round14_2.axi_in;
                var round15 = new RoundOdd_1();
                round15.In = round14_2.Out;
                round14_2.axi_out = round15.axi_in;
                var round15_2 = new RoundOdd_2();
                round15_2.In = round15.Out;
                round15.axi_out = round15_2.axi_in;
                var round16 = new RoundEven_1();
                round16.In = round15_2.Out;
                round15_2.axi_out = round16.axi_in;
                var round16_2 = new RoundEven_2();
                round16_2.In = round16.Out;
                round16.axi_out = round16_2.axi_in;
                var round17 = new RoundOdd_1();
                round17.In = round16_2.Out;
                round16_2.axi_out = round17.axi_in;
                var round17_2 = new RoundOdd_2();
                round17_2.In = round17.Out;
                round17.axi_out = round17_2.axi_in;
                var round18 = new RoundEven_1();
                round18.In = round17_2.Out;
                round17_2.axi_out = round18.axi_in;
                var round18_2 = new RoundEven_2();
                round18_2.In = round18.Out;
                round18.axi_out = round18_2.axi_in;
                var round19 = new RoundOdd_1();
                round19.In = round18_2.Out;
                round18_2.axi_out = round19.axi_in;
                var round19_2 = new RoundOdd_2();
                round19_2.In = round19.Out;
                round19.axi_out = round19_2.axi_in;
                var roundC = new RoundCombine();
                roundC.In = round19_2.Out;
                round19_2.axi_out = roundC.axi_in;
                var roundC_2 = new RoundCombine_2();
                roundC_2.In = roundC.Out;
                roundC.axi_out = roundC_2.axi_in;
                var XOR = new RoundXOR();
                XOR.In = roundC_2.Out;
                roundC_2.axi_out = XOR.axi_in;
                var XOR_2 = new RoundXOR_2();
                XOR_2.In = XOR.Out;
                XOR.axi_out = XOR_2.axi_in;
                tester.HashStream = XOR_2.Out;
                tester.axi_State = setup.axi_in;
                XOR_2.axi_out = tester.axi_Stream;
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
