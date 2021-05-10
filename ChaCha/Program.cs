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
                chacha.seed = tester.State;
                // chacha.text = tester.Text;
                tester.HashStream = chacha.Output;
                    sim.AddTopLevelInputs(chacha.seed)
                        .AddTopLevelOutputs(chacha.Output)
                        .BuildCSVFile()
                        .BuildGraph()
                        .BuildVHDL()
                        .Run();
            }
        }
    }
}
