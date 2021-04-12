using System;
using SME;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var aes = new naiveE();
                // var aesD = new naiveD();
                // Nice to be able to test buffer sizes
                var tester = new Tester();
                aes.PlainText = tester.PlainText;
                tester.Cypher = aes.Cypher;
                // aesD.Cypher = tester.CypherDecrypt;
                // tester.PlainDecrypt = aesD.PlainText;
                    // sim.AddTopLevelInputs(aes.PlainText, aesD.Cypher)
                    //     .AddTopLevelOutputs(aes.Cypher, aesD.PlainText)
                    //     .BuildCSVFile()
                    //     .BuildGraph()
                    //     .BuildVHDL()
                    //     .Run();
                    sim.AddTopLevelInputs(aes.PlainText)
                        .AddTopLevelOutputs(aes.Cypher)
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
