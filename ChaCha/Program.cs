using SME;

namespace ChaCha
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var chacha = new ChaCha20();
                var tester = new Tester();
                chacha.Input = tester.State;
                tester.HashStream = chacha.Output;
                    sim.AddTopLevelInputs(chacha.Input)
                        .AddTopLevelOutputs(chacha.Output)
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
