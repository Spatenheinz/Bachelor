using SME;
﻿using System;

namespace opt2
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
                var round5 = new Round5();
                round5.In = round4.Out;
                round4.axi_out = round5.axi_in;
                var round6 = new Round6();
                round6.In = round5.Out;
                round5.axi_out = round6.axi_in;
                var round7 = new Round7();
                round7.In = round6.Out;
                round6.axi_out = round7.axi_in;
                var round8 = new Round8();
                round8.In = round7.Out;
                round7.axi_out = round8.axi_in;
                var round9 = new Round9();
                round9.In = round8.Out;
                round8.axi_out = round9.axi_in;
                var round10 = new Round10();
                round10.In = round9.Out;
                round9.axi_out = round10.axi_in;
                var round11 = new Round11();
                round11.In = round10.Out;
                round10.axi_out = round11.axi_in;
                var round12 = new Round12();
                round12.In = round11.Out;
                round11.axi_out = round12.axi_in;
                var round13 = new Round13();
                round13.In = round12.Out;
                round12.axi_out = round13.axi_in;
                var round14 = new Round14();
                round14.In = round13.Out;
                round13.axi_out = round14.axi_in;
                var round15 = new Round15();
                round15.In = round14.Out;
                round14.axi_out = round15.axi_in;
                var round16 = new Round16();
                round16.In = round15.Out;
                round15.axi_out = round16.axi_in;
                var combinator = new Combiner();
                combinator.In = round16.Out;
                round16.axi_out = combinator.axi_in;
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
