using SME;
using System;

namespace opt3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                // Nice to be able to test buffer sizes
                // Console.WriteLine(str);
                var tester = new Tester();
                var formatter = new MessageFormat();
                formatter.Message = tester.Message;
                tester.axi_Message = formatter.axi_mes;
                var converter = new FormatConverter();
                converter.paddedBuffer = formatter.paddedBuffer;
                formatter.axi_pad = converter.axi_pad;
                var roundF1    = new RoundF1();
                roundF1.IN = converter.Out;
                converter.axi_out = roundF1.axi_in;
                var roundF2    = new RoundF2();
                roundF2.IN = roundF1.Out;
                roundF1.axi_out = roundF2.axi_in;
                var roundF3    = new RoundF3();
                roundF3.IN = roundF2.Out;
                roundF2.axi_out = roundF3.axi_in;
                var roundF4    = new RoundF4();
                roundF4.IN = roundF3.Out;
                roundF3.axi_out = roundF4.axi_in;
                var roundG1    = new RoundG1();
                roundG1.IN     = roundF4.Out;
                roundF4.axi_out = roundG1.axi_in;
                var roundG2    = new RoundG2();
                roundG2.IN     = roundG1.Out;
                roundG1.axi_out = roundG2.axi_in;
                var roundG3    = new RoundG3();
                roundG3.IN     = roundG2.Out;
                roundG2.axi_out = roundG3.axi_in;
                var roundG4    = new RoundG4();
                roundG4.IN     = roundG3.Out;
                roundG3.axi_out = roundG4.axi_in;
                var roundH1    = new RoundH1();
                roundH1.IN     = roundG4.Out;
                roundG4.axi_out = roundH1.axi_in;
                var roundH2    = new RoundH2();
                roundH2.IN     = roundH1.Out;
                roundH1.axi_out = roundH2.axi_in;
                var roundH3    = new RoundH3();
                roundH3.IN     = roundH2.Out;
                roundH2.axi_out = roundH3.axi_in;
                var roundH4    = new RoundH4();
                roundH4.IN     = roundH3.Out;
                roundH3.axi_out = roundH4.axi_in;
                var roundI1    = new RoundI1();
                roundI1.IN     = roundH4.Out;
                roundH4.axi_out = roundI1.axi_in;
                var roundI2    = new RoundI2();
                roundI2.IN     = roundI1.Out;
                roundI1.axi_out = roundI2.axi_in;
                var roundI3    = new RoundI3();
                roundI3.IN     = roundI2.Out;
                roundI2.axi_out = roundI3.axi_in;
                var roundI4    = new RoundI4();
                roundI4.IN     = roundI3.Out;
                roundI3.axi_out = roundI4.axi_in;
                var combinator = new Combiner();
                combinator.I = roundI4.Out;
                roundI4.axi_out = combinator.axi_in;
                tester.Digest = combinator.Final;
                combinator.axi_final = tester.axi_Digest;
                sim.AddTopLevelInputs(tester.Message, tester.axi_Digest)
                       .AddTopLevelOutputs(combinator.Final, tester.axi_Message)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
