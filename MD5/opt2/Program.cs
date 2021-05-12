using SME;
using System;

namespace opt2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                // Nice to be able to test buffer sizes
                // Console.WriteLine(str);
                var tester = new Tester();
                // opt1
                var formatter = new MessageFormat();
                formatter.Message = tester.Message;
                var converter = new FormatConverter();
                converter.paddedBuffer = formatter.paddedBuffer;
                var roundF    = new RoundF();
                roundF.block = converter.block;
                var roundG    = new RoundG();
                roundG.F     = roundF.Out;
                roundG.block = converter.block;
                var roundH    = new RoundH();
                roundH.G     = roundG.Out;
                roundH.block = converter.block;
                var roundI    = new RoundI();
                roundI.H     = roundH.Out;
                roundI.block = converter.block;
                var combinator = new Combiner();
                combinator.I = roundI.Out;
                roundF.IV    = combinator.F;
                // combinator.IV = roundF.IV_Out;
                tester.Digest = combinator.Out;

                combinator.axi_Digest = tester.axi_Digest;
                tester.axi_Message = formatter.axi_Message;
                sim.AddTopLevelInputs(formatter.Message, combinator.axi_Digest)
                       .AddTopLevelOutputs(combinator.Out, formatter.axi_Message)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
