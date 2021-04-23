using SME;
using System;
// using MD5.opt1;

namespace MD5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var md5 = new MD5();
                // Nice to be able to test buffer sizes
                // Console.WriteLine(str);
                var tester = new Tester("");
                // opt1
                // var formatter = new MessageFormat();
                // formatter.Message = tester.Message;
                // var converter = new FormatConverter();
                // converter.paddedBuffer = formatter.paddedBuffer;
                // var roundF    = new RoundF();
                // roundF.block = converter.block;
                // roundF.IV    = tester.optDigest;
                // var roundG    = new RoundG();
                // roundG.F     = roundF.Out;
                // roundG.block = converter.block;
                // var roundH    = new RoundH();
                // roundH.G     = roundG.Out;
                // roundH.block = converter.block;
                // var roundI    = new RoundI();
                // roundI.H     = roundH.Out;
                // roundI.block = converter.block;
                // var combinator = new Combiner();
                // combinator.I = roundI.Out;
                // combinator.IV = tester.optDigest;
                // tester.Digest2 = combinator.Out;
                //

                md5.Message = tester.Message;
                md5.out_o = tester.res_o;
                tester.Digest = md5.Digest;
                tester.in_o = md5.in_o;
                    sim.AddTopLevelInputs(md5.Message, md5.out_o)
                        .AddTopLevelOutputs(md5.Digest, md5.in_o)
                       //  sim.AddTopLevelInputs(tester.optDigest, tester.Message)
                       // .AddTopLevelOutputs(combinator.Out)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
                // System.Console.WriteLine(md5.counter);
            }
        }
    }
}
