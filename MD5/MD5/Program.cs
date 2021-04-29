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
                var tester = new Tester("");
                md5.Message = tester.Message;
                md5.out_o = tester.res_o;
                tester.Digest = md5.Digest;
                tester.in_o = md5.in_o;
                    sim.AddTopLevelInputs(md5.Message, md5.out_o)
                        .AddTopLevelOutputs(md5.Digest, md5.in_o)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
