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
                string str = "";
                // Nice to be able to test buffer sizes
                for (int i = 65; i > 0; i--){
                    str += 1.ToString();
                }
                    var tester = new Tester(str);
                md5.Message = tester.Message;
                tester.Digest = md5.Digest;
                    sim.AddTopLevelInputs(md5.Message)
                        .AddTopLevelOutputs(md5.Digest)
                        .BuildCSVFile()
                        .BuildGraph()
                        // .BuildVHDL()
                        .Run();
            }
        }
    }
}
