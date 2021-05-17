using SME;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using static ChaCha_key.config;
using Process = System.Diagnostics.Process;
using System.IO;
namespace ChaCha_key {
    public class Tester : SimulationProcess {
        [InputBus]
        public IStream HashStream;
        [OutputBus]
        public axi_r axi_Stream = Scope.CreateBus<axi_r>();
        [OutputBus]
        public IState State = Scope.CreateBus<IState>();
        [InputBus]
        public axi_r axi_State;

        public static uint[] StringToArray(string hex) {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 8 == 0)
                .Select(x => Convert.ToUInt32(hex.Substring(x,8), 16))
                .ToArray();
        }
        // private void targetCypher(string val) {
        //     ProcessStartInfo start = new ProcessStartInfo();
        //     start.FileName = "";
        //     // start.Arguments = "ls";
        //     start.Arguments = "echo \'" + val + "\' | openssl enc -chacha20 -nosalt -pass pass:test -p -in /dev/stdin -o /dev/stdout";
        //     start.RedirectStandardOutput = true;
        //     Process p = new Process();
        //     p.StartInfo.FileName = "echo \'" + val + " \'";
        //     p.StartInfo.RedirectStandardInput
        //     using (var process = Process.Start(start)) {
        //         using (StreamReader reader = process.StandardOutput) {
        //             string result = reader.ReadToEnd();
        //             Console.WriteLine(result);
        //         }
        //     }
        // }

        private uint[] testkey = StringToArray("03020100070605040b0a09080f0e0d0c13121110171615141b1a19181f1e1d1c");
        private byte[] plaintext = Encoding.ASCII.GetBytes("Ladies and Gentlemen of the class of '99: If I could offer you only one tip for the future, sunscreen would be it.");
        private string result;

        public async override Task Run() {
            await ClockAsync();
            State.ValidSeed = true;
            for(int i = 0; i < BUFFER_SIZE; i++) {
                State.Key[i] = testkey[i];
            }
            State.Nonce0 = 0x00000000;
            State.Nonce1 = 0x4a000000;
            State.Nonce2 = 0x00000000;
            await ClockAsync();
            State.ValidSeed = false;

            for(int i = 0; i < plaintext.Length; i += TEXT_SIZE) {
                State.ValidT = true;
                await ClockAsync();
                State.ValidT = false;
                await ClockAsync();
                axi_Stream.ready = true;
                // axi_Stream.ready = false;
                if (HashStream.Valid) {
                    for(int j = 0; j < TEXT_SIZE; j++) {
                        if(i+j < plaintext.Length){
                        result += (HashStream.Values[j] ^ plaintext[i+j]).ToString("x2");
                        result += " ";
                        if(j%15== 0 && j!= 0) {
                            result += "\n";
                        }
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
