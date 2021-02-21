using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static MD5.MD5Config;

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
                var tester = new Tester();
                md5.Message = tester.Message;
                tester.Digest = md5.Digest;
                    sim.AddTopLevelInputs(md5.Message)
                        .AddTopLevelOutputs(md5.Digest)
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
