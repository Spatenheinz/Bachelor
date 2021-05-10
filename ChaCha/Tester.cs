using SME;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using static ChaCha.config;
namespace ChaCha {
    public class Tester : SimulationProcess {
        [InputBus]
        public IStream HashStream;
        // [OutputBus]
        // public axi_r axi_Stream = Scope.CreateBus<axi_r>();
        [OutputBus]
        public IState State = Scope.CreateBus<IState>();
        // [OutputBus]
        // public IText Text = Scope.CreateBus<IText>();
        // [InputBus]
        // public axi_r axi_State;

        public static uint[] StringToArray(string hex) {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 8 == 0)
                .Select(x => Convert.ToUInt32(hex.Substring(x,8), 16))
                .ToArray();
        }
        // public static byte[] toByteArray(IFixedArray<uint> arr) {
        //     byte[] res = new byte[arr.Length*4];
        //     for(int i=0; i < res.Length; i+=4){
        //         res[i] = (byte)((arr[i>>2] >> 24) & 0xff);
        //         res[i+1] = (byte)((arr[i>>2] >> 16) & 0xff);
        //         res[i+2] = (byte)((arr[i>>2] >> 8) & 0xff);
        //         res[i+3] = (byte)((arr[i>>2]) & 0xff);
        //     }
        //     return res;
        // }
        private uint[] testkey = StringToArray("03020100070605040b0a09080f0e0d0c13121110171615141b1a19181f1e1d1c");
        private byte[] plaintext = Encoding.ASCII.GetBytes("Ladies and Gentlemen of the class of '99: If I could offer you only one tip for the future, sunscreen would be it.");
        private string result;

        public async override Task Run() {

            await ClockAsync();
            State.Valid = true;
            State.Head = true;
            for(int i = 0; i < BUFFER_SIZE; i++) {
                State.Key[i] = testkey[i];
            }
            State.Nonce0 = 0x00000000;
            State.Nonce1 = 0x4a000000;
            State.Nonce2 = 0x00000000;
            for(int i = 0; i < plaintext.Length; i += TEXT_SIZE) {
                byte size = 0;
                for(int j = 0; j < TEXT_SIZE; j++) {
                    if(i + j < plaintext.Length) {
                        State.Text[j] = plaintext[i+j];
                        size++;
                    } else {
                        State.Text[j] = 0;
                    }
                }
                // State.Size = size;
                await ClockAsync();
                State.Head = false;
                // axi_Stream.ready = false;
                if (HashStream.Valid) {
                    for(int j = 0; j < TEXT_SIZE; j++) {
                        if(i+j < plaintext.Length){
                        result += HashStream.Values[j].ToString("x2");
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
