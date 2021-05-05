using SME;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using static ChaCha.config;
namespace ChaCha {
    public class Tester : SimulationProcess {
        private const bool V = true;
        [InputBus]
        public IStream HashStream;
        [OutputBus]
        public IState State = Scope.CreateBus<IState>();

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
            State.Valid = V;
            State.Head = V;
            for(int i = 0; i < BUFFER_SIZE; i++) {
                State.Key[i] = testkey[i];
            }
            State.Nonce0 = 0x00000000;
            State.Nonce1 = 0x4a000000;
            State.Nonce2 = 0x00000000;
            for(int i = 0; i < plaintext.Length; i += BLOCK_SIZE) {
                for(int j = 0; j < BLOCK_SIZE; j++) {
                Console.WriteLine(i+j);
                    State.Text[j] = plaintext[i+j];
                }
                await ClockAsync();
                if (HashStream.Valid) {
                    for(int j = 0; j < BLOCK_SIZE; j++) {
                    result += HashStream.Values[j].ToString("x8");
                    }
                }
            // while (CurrentPosition < 3){
                // State.Position = CurrentPosition++;
                // await ClockAsync();
                // if (HashStream.Valid) {
                //     byte[] tmp = toByteArray(HashStream.Values);
                //     for(int i = 0; i < 16<<2; i++) {
                //         int offset = (int)(i + (CurrentPosition-2)*(16<<2));
                //         if(offset >= plaintext.Length){ break; }
                //         result += (tmp[i] ^ plaintext[offset]).ToString("X2");
                //     }
                // }
            }
            Console.WriteLine(result);
        }
    }
}
