using SME;
﻿using System;

namespace SHA
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var sha = new SHA();
                var tester = new Tester("");
                sha.Message = tester.Message;
                sha.axi_Digest = tester.axi_Digest;
                tester.Digest = sha.Digest;
                tester.axi_Digest = sha.axi_Digest;
                sim.AddTopLevelInputs(sha.Message, sha.axi_Digest)
                    .AddTopLevelOutputs(sha.Digest, sha.axi_Message)
                    .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                    // .BuildCSVFile()
                    // .BuildGraph()
                    // .BuildVHDL()
                    .Run();
            }
        }
    }
}
