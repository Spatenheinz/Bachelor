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
                var tester = new Tester("7KJYSSCIDDT2BI5OJXHNVEMWPRMZ981CXU5HMYP00N7U7GZTZN4TGNW27WIAGMIEMQEQNXBVHQXIH1ZI22AVDI5K8CK0POUNE2IQCIGBMJL00NUF6AINLXBEU3RKNLF35JEPTJFTV9J36FUVRE3PFHBR0E5J05YBES4QJFVX4Z1MNHHPJ62IR0XYHWYPN62Z");
                md5.Message = tester.Message;
                md5.axi_Digest = tester.axi_Digest;
                tester.Digest = md5.Digest;
                tester.axi_Message = md5.axi_Message;
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
