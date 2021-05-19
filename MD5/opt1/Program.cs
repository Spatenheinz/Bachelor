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
                // var tester = new Tester("7KJYSSCIDDT2BI5OJXHNVEMWPRMZ981CXU5HMYP00N7U7GZTZN4TGNW27WIAGMIEMQEQNXBVHQXIH1ZI22AVDI5K8CK0POUNE2IQCIGBMJL00NUF6AINLXBEU3RKNLF35JEPTJFTV9J36FUVRE3PFHBR0E5J05YBES4QJFVX4Z1MNHHPJ62IR0XYHWYPN62Z");
                // opt1
                var formatter = new MessageFormat();
                formatter.Message = tester.Message;
                tester.axi_Message = formatter.axi_mes;
                var converter = new FormatConverter();
                converter.paddedBuffer = formatter.paddedBuffer;
                formatter.axi_pad = converter.axi_pad;
                var roundF    = new RoundF();
                roundF.I = converter.Out;
                converter.axi_out = roundF.axi_i;
                // roundF.IV    = tester.State;
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
                // combinator.flag = roundI.flag;
                // combinator.IV = roundF.IV_Out;
                // roundF.axi_iv_out = combinator.axi_iv;
                // roundF.IV = combinator.Out;
                tester.Digest = combinator.Final;
                // combinator.axi_out = roundF.axi_iv;
                combinator.axi_final = tester.axi_Digest;
                // tester.Digest = combinator.Final;
                // combinator.axi_final = tester.axi_digest;
                sim.AddTopLevelInputs(tester.Message, formatter.axi_mes)
                       .AddTopLevelOutputs(combinator.Final, tester.axi_Digest)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
