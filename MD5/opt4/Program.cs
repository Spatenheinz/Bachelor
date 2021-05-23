using SME;
using System;

namespace opt4
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
                var roundF5    = new RoundF5();
                roundF5.IN = roundF4.Out;
                roundF4.axi_out = roundF5.axi_in;
                var roundF6    = new RoundF6();
                roundF6.IN = roundF5.Out;
                roundF5.axi_out = roundF6.axi_in;
                var roundF7    = new RoundF7();
                roundF7.IN = roundF6.Out;
                roundF6.axi_out = roundF7.axi_in;
                var roundF8    = new RoundF8();
                roundF8.IN = roundF7.Out;
                roundF7.axi_out = roundF8.axi_in;
                var roundG1    = new RoundG1();
                roundG1.IN     = roundF8.Out;
                roundF8.axi_out = roundG1.axi_in;
                var roundG2    = new RoundG2();
                roundG2.IN     = roundG1.Out;
                roundG1.axi_out = roundG2.axi_in;
                var roundG3    = new RoundG3();
                roundG3.IN     = roundG2.Out;
                roundG2.axi_out = roundG3.axi_in;
                var roundG4    = new RoundG4();
                roundG4.IN     = roundG3.Out;
                roundG3.axi_out = roundG4.axi_in;
                var roundG5    = new RoundG5();
                roundG5.IN     = roundG4.Out;
                roundG4.axi_out = roundG5.axi_in;
                var roundG6    = new RoundG6();
                roundG6.IN     = roundG5.Out;
                roundG5.axi_out = roundG6.axi_in;
                var roundG7    = new RoundG7();
                roundG7.IN     = roundG6.Out;
                roundG6.axi_out = roundG7.axi_in;
                var roundG8    = new RoundG8();
                roundG8.IN     = roundG7.Out;
                roundG7.axi_out = roundG8.axi_in;
                var roundH1    = new RoundH1();
                roundH1.IN     = roundG8.Out;
                roundG8.axi_out = roundH1.axi_in;
                var roundH2    = new RoundH2();
                roundH2.IN     = roundH1.Out;
                roundH1.axi_out = roundH2.axi_in;
                var roundH3    = new RoundH3();
                roundH3.IN     = roundH2.Out;
                roundH2.axi_out = roundH3.axi_in;
                var roundH4    = new RoundH4();
                roundH4.IN     = roundH3.Out;
                roundH3.axi_out = roundH4.axi_in;
                var roundH5    = new RoundH5();
                roundH5.IN     = roundH4.Out;
                roundH4.axi_out = roundH5.axi_in;
                var roundH6    = new RoundH6();
                roundH6.IN     = roundH5.Out;
                roundH5.axi_out = roundH6.axi_in;
                var roundH7    = new RoundH7();
                roundH7.IN     = roundH6.Out;
                roundH6.axi_out = roundH7.axi_in;
                var roundH8    = new RoundH8();
                roundH8.IN     = roundH7.Out;
                roundH7.axi_out = roundH8.axi_in;
                var roundI1    = new RoundI1();
                roundI1.IN     = roundH8.Out;
                roundH8.axi_out = roundI1.axi_in;
                var roundI2    = new RoundI2();
                roundI2.IN     = roundI1.Out;
                roundI1.axi_out = roundI2.axi_in;
                var roundI3    = new RoundI3();
                roundI3.IN     = roundI2.Out;
                roundI2.axi_out = roundI3.axi_in;
                var roundI4    = new RoundI4();
                roundI4.IN     = roundI3.Out;
                roundI3.axi_out = roundI4.axi_in;
                var roundI5    = new RoundI5();
                roundI5.IN     = roundI4.Out;
                roundI4.axi_out = roundI5.axi_in;
                var roundI6    = new RoundI6();
                roundI6.IN     = roundI5.Out;
                roundI5.axi_out = roundI6.axi_in;
                var roundI7    = new RoundI7();
                roundI7.IN     = roundI6.Out;
                roundI6.axi_out = roundI7.axi_in;
                var roundI8    = new RoundI8();
                roundI8.IN     = roundI7.Out;
                roundI7.axi_out = roundI8.axi_in;
                var combinator = new Combiner();
                combinator.I = roundI8.Out;
                roundI8.axi_out = combinator.axi_in;
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
