using SME;
﻿using System;

namespace opt1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var tester = new Tester();
                var formatter = new MessageFormat();
                formatter.Message = tester.Message;
                tester.axi_Message = formatter.axi_mes;
                var converter = new FormatConverter();
                converter.paddedBuffer = formatter.paddedBuffer;
                formatter.axi_pad = converter.axi_pad;
                var round1 = new Round1();
                round1.In = converter.Out;
                converter.axi_out = round1.axi_in;
                var round2 = new Round2();
                round2.In = round1.Out;
                round1.axi_out = round2.axi_in;
                var round3 = new Round3();
                round3.In = round2.Out;
                round2.axi_out = round3.axi_in;
                var round4 = new Round4();
                round4.In = round3.Out;
                round3.axi_out = round4.axi_in;
                var combinator = new Combiner();
                combinator.In = round4.Out;
                round4.axi_out = combinator.axi_in;
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
