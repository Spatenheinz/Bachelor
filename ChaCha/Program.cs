using System;
using SME;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ChaCha
{
    public static class config {
        public const int KEY_SIZE = 256;
        public const int BLOCK_SIZE = 16;
        public const int BUFFER_SIZE = KEY_SIZE >> 5;
    }

    public interface IUIn : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [FixedArrayLength(config.BUFFER_SIZE)]
        IFixedArray<uint> Key { get; set; }

        uint Position { get; set; }
        uint Nonce0   { get; set; }
        uint Nonce1   { get; set; }
        uint Nonce2   { get; set; }

    }

    public interface IStream : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(config.BLOCK_SIZE)]
        IFixedArray<uint> Values { get; set; }
    }

    public class ChaCha : SimpleProcess {
        [InputBus]
        public IUIn Input;

        [OutputBus]
        public IStream Output = Scope.CreateBus<IStream>();
        private readonly uint CONST1 = 0x61707865;
        private readonly uint CONST2 = 0x3320646e;
        private readonly uint CONST3 = 0x79622d32;
        private readonly uint CONST4 = 0x6b206574;

        private uint[] InterState = new uint[config.BLOCK_SIZE];
        private uint[] tmp = new uint[config.BLOCK_SIZE];
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        private void QR(ref uint a, ref uint b, ref uint c, ref uint d) {
            a += b; d ^= a; d = LeftRotate(d, 16);
            c += d; b ^= c; b = LeftRotate(b, 12);
            a += b; d ^= a; d = LeftRotate(d, 8);
            c += d; b ^= c; b = LeftRotate(b, 7);
        }
        private void chacha() {
            for(int i = 0; i < config.BLOCK_SIZE; i++) {
                tmp[i] = InterState[i];
            }
            for(int i = 0; i < 20; i += 2) {
            // Odd round
            QR(ref tmp[0], ref tmp[4], ref tmp[ 8], ref tmp[12]); // column 0
            QR(ref tmp[1], ref tmp[5], ref tmp[ 9], ref tmp[13]); // column 1
            QR(ref tmp[2], ref tmp[6], ref tmp[10], ref tmp[14]); // column 2
            QR(ref tmp[3], ref tmp[7], ref tmp[11], ref tmp[15]); // column 3
            // Even round
            QR(ref tmp[0], ref tmp[5], ref tmp[10], ref tmp[15]); // diagonal 1 (main diagonal)
            QR(ref tmp[1], ref tmp[6], ref tmp[11], ref tmp[12]); // diagonal 2
            QR(ref tmp[2], ref tmp[7], ref tmp[ 8], ref tmp[13]); // diagonal 3
            QR(ref tmp[3], ref tmp[4], ref tmp[ 9], ref tmp[14]); // diagonal 4
            }
            for(int i = 0; i < 16; i++) {
                Console.WriteLine(tmp[i].ToString("X8"));
            }
                Console.WriteLine("\n");

            for(int i = 0; i < config.BLOCK_SIZE; i++) {
                InterState[i] += tmp[i];
                Output.Values[i] = reverseByte(InterState[i]);
            }
        }
        protected override void OnTick() {
            if (Input.Valid) {
                    InterState[0] = CONST1; InterState[1] = CONST2; InterState[2] = CONST3; InterState[3] = CONST4;
                    for (int i = 4; i < 12; i++) {
                        InterState[i] = Input.Key[i-4];
                    }
                    InterState[12] = Input.Position;
                    InterState[13] = Input.Nonce0;
                    InterState[14] = Input.Nonce1;
                    InterState[15] = Input.Nonce2;
                    for(int i = 0; i < 16; i++) {
                        Console.WriteLine(InterState[i].ToString("X8"));
                    }
                        Console.WriteLine("\n");
                    chacha();
                    Console.WriteLine("after chacha:");
                    Output.Valid = true;
                    for(int i = 0; i < 16; i++) {
                        Console.WriteLine(InterState[i].ToString("X8"));
                    }
                        Console.WriteLine("\n");
            }
        }

    }

    public class Tester : SimulationProcess {
        [InputBus]
        public IStream HashStream;
        [OutputBus]
        public IUIn State = Scope.CreateBus<IUIn>();

        public static uint[] StringToArray(string hex) {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 8 == 0)
                .Select(x => Convert.ToUInt32(hex.Substring(x,8), 16))
                .ToArray();
        }
        public static byte[] toByteArray(IFixedArray<uint> arr) {
            byte[] res = new byte[arr.Length*4];
            for(int i=0; i < res.Length; i+=4){
                res[i] = (byte)((arr[i>>2] >> 24) & 0xff);
                res[i+1] = (byte)((arr[i>>2] >> 16) & 0xff);
                res[i+2] = (byte)((arr[i>>2] >> 8) & 0xff);
                res[i+3] = (byte)((arr[i>>2]) & 0xff);
            }
            return res;

        }
        private uint[] testkey = StringToArray("03020100070605040b0a09080f0e0d0c13121110171615141b1a19181f1e1d1c");
        private byte[] plaintext = Encoding.ASCII.GetBytes("Ladies and Gentlemen of the class of '99: If I could offer you only one tip for the future, sunscreen would be it.");
        private string result;

        public async override Task Run() {
            await ClockAsync();
            while(true) {
                State.Valid = true;
                for(int i = 0; i < config.BUFFER_SIZE; i++) {
                    State.Key[i] = testkey[i];
                }
                State.Nonce0 = 0x00000000;
                State.Nonce1 = 0x4a000000;
                State.Nonce2 = 0x00000000;
                uint CurrentPosition = 1;
                while (CurrentPosition < 3){
                    State.Position = CurrentPosition++;
                    await ClockAsync();
                    if (HashStream.Valid) {
                        byte[] tmp = toByteArray(HashStream.Values);
                        for(int i = 0; i < 16<<2; i++) {
                            int offset = (int)(i + (CurrentPosition-2)*(16<<2));
                            if(offset >= plaintext.Length){ break; }
                            result += (tmp[i] ^ plaintext[offset]).ToString("X2");
                        }
                    }
                    Console.WriteLine(result);
                }
                break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var chacha = new ChaCha();
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
