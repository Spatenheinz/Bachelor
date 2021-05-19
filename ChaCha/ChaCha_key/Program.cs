using SME;
using System;

namespace ChaCha_key
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var chacha = new ChaCha20();
                var tester = new Tester();
                chacha.seed = tester.State;
                chacha.axi_O = tester.axi_Stream;
                tester.HashStream = chacha.Output;
                tester.axi_State = chacha.axi_seed;
                    sim.AddTopLevelInputs(chacha.seed, chacha.axi_O)
                        .AddTopLevelOutputs(chacha.Output, chacha.axi_seed)
                        .AddTicker(s => Console.WriteLine($"Ticks {Scope.Current.Clock.Ticks}"))
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
