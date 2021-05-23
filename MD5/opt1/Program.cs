using SME;
using System;

namespace opt1
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
                var roundF    = new RoundF();
                roundF.I = converter.Out;
                converter.axi_out = roundF.axi_i;
                var roundG    = new RoundG();
                roundG.F     = roundF.Out;
                roundF.axi_out = roundG.axi_F;
                var roundH    = new RoundH();
                roundH.G     = roundG.Out;
                roundG.axi_out = roundH.axi_G;
                var roundI    = new RoundI();
                roundI.H     = roundH.Out;
                roundH.axi_out = roundI.axi_H;
                var combinator = new Combiner();
                combinator.I = roundI.Out;
                roundI.axi_out = combinator.axi_I;
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
