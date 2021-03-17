using System;
using SME;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var aes = new naive();
                // Nice to be able to test buffer sizes
                var tester = new Tester();
                aes.Message = tester.Message;
                tester.Cypher = aes.Cypher;
                    sim.AddTopLevelInputs(aes.Message)
                        .AddTopLevelOutputs(aes.Cypher)
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
