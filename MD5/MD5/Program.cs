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
                var tester = new Tester();
                md5.Message = tester.Message;
                md5.axi_Digest = tester.axi_Digest;
                tester.Digest = md5.Digest;
                tester.axi_Digest = md5.axi_Digest;
                    sim.AddTopLevelInputs(md5.Message, md5.axi_Digest)
                        .AddTopLevelOutputs(md5.Digest, md5.axi_Message)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
