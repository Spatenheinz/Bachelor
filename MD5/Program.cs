using System;
using System.Text;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static MD5.MD5Config;

namespace MD5
{

    public static class MD5Config {
        public const int MAX_BUFFER_SIZE = 1024;
        public const int DIGEST_SIZE = 4;
    }
    public class Tester : SimulationProcess {
        [InputBus]
        public IDigest Digest;
        [OutputBus]
        public IMessage Message = Scope.CreateBus<IMessage>();

        private readonly string[] MESSAGES;

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(messages), "No images to send?");
            MESSAGES = messages;
        }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                for(int i = 0 ; i < message.Length; i++)
                    Message.Message[i] = (byte)message[i];
                Message.Size = message.Length;
                Message.Valid = true;
                await ClockAsync();
                Message.Valid = false;
            }
            Debug.Assert(Digest.Valid, "failed to produce output");
        }
    }

    public interface IMessage : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(MAX_BUFFER_SIZE)]
        IFixedArray<byte> Message { get; set; }
        int Size { get; set; }
        bool Overflow { get; set; }
    }

    public interface IDigest : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(DIGEST_SIZE)]
        IFixedArray<uint> Digest { get; set; }
    }

    class MD5 : SimpleProcess {
        [InputBus]
        public IMessage Message;

        [OutputBus]
        public IDigest Digest = Scope.CreateBus<IDigest>();

        protected override void OnTick() {
            if (Message.Valid)
            {
                var tmp = calculateMD5(Message.Message, Message.Size);
                for (int i = 0; i < DIGEST_SIZE; i++)
                {
                    Console.WriteLine(tmp[i].ToString("x8"));
                    Digest.Digest[i] = tmp[i];
                }
                Digest.Valid = true;
            }
        }

        // This is the s array, which we can optimize since it has a lot of repetition.
        private readonly static int [] Round = new int[64]
            { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22
            , 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20
            , 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23
            , 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
            };
        // This is the K array which store sthe sines of integers part
        private readonly static uint [] Tab = new uint[64]
            { 0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee
			, 0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501
            , 0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be
            , 0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821
			, 0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa
            , 0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8
            , 0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed
			, 0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a
            , 0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c
            , 0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70
            , 0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05
			, 0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665
            , 0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039
            , 0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1
            , 0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1
			, 0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
            };

        // The 4 32bit parts of the digest.
        private uint A = 0x67452301;
        private uint B = 0xefcdab89;
        private uint C = 0x98badcfe;
        private uint D = 0x10325476;

        // This works as the temporary buffer in which we store each of the 32bit
        // words in the 512 bit chunk
        private uint[] block = new uint[16];

        // The main function to calculate MD
        public uint[] calculateMD5(IFixedArray<byte> mes, int size)
        {
            //preprocess
            byte[] msgB = preprocess(mes, size);
            // break up chunks and process.
            uint blocks = (uint)(msgB.Length * 8) >> 5;
            for (uint i = 0; i < blocks >> 4; i++)
            {
                fetchBlock(msgB, i);
                processBlock();
            }
            //format
            return new[] { reverseByte(A), reverseByte(B), reverseByte(C), reverseByte(D) };
        }

        public byte[] preprocess(IFixedArray<byte> mes, int size)
        {
            // Preprocessing
            int temp = (448 - ((size * 8) % 512));
            // the amount of padding 448 mod 512
            uint padding = (uint)((temp + 512 + 1) % 512);
            // the size of the digest buffer
            uint buffSize = (uint)(size + (padding >> 3) + 8);
            // the size of the message
            ulong inpSize = (ulong)(size << 3);
            //buffer for the working buffer
            byte[] buff = new byte[buffSize];
            //copy over the message to the working buffer
            for (int i = 0; i < size; i++)
            {
                buff[i] = (byte)mes[i];
            }
            // add 1 to padding
            buff[size] = 0x80;
            // add the length to the padding
            for (int i = 8; i > 0; i--)
            {
                buff[buffSize - i] = (byte)(inpSize >> ((8 - i) << 3) & 0x00000000000000ff);
            }
            return buff;
        }

        #region Digest calculation
        // this will move the b block into the smaller buffer block
        // will be called 16 times.
        private void fetchBlock(byte[] buff, uint b) {
			b=b<<6;
			for (uint j=0; j<61;j+=4) {
				block[j>>2]=(((uint) buff[b+(j+3)]) <<24 ) |
						    (((uint) buff[b+(j+2)]) <<16 ) |
						    (((uint) buff[b+(j+1)]) <<8 ) |
						    (((uint) buff[b+(j)]) ) ;
			}
        }
        // the loop in the algorithm, might be interesting to unfold the loop as
        // RFC explains it and see which is faster
        private void processBlock(){
            uint a = A, b = B, c = C, d = D;
            for (uint i = 0; i < 64; i++) {
                uint f = 0, g = 0;
                if (i < 16) {
                    f = F(b,c,d);
                    g = i;
                } else if (15 < i && i < 32) {
                    f = G(b,c,d);
                    g = (5 * i + 1) % 16;
                } else if (31 < i && i < 48) {
                    f = H(b, c, d);
                    g = (3 * i + 5) % 16;
                } else if (47 < i && i < 64) {
                    f = I(b, c, d);
                    g = (7 * i) % 16;
                }
                f = f + a + Tab[i] + block[g];
                a = d;
                d = c;
                c = b;
                b = b + LeftRotate(f, Round[i]);
            }
            A += a;
            B += b;
            C += c;
            D += d;
        }
        #endregion

        #region bitwise operators
        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint I(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int c) {
            return ((x << c) | (x >> (32 - c)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        #endregion
    }
class Program
    {
        static void Main(string[] args)
        {
            using (var sim = new Simulation()) {
                var md5 = new MD5();
                var tester = new Tester("hello world");
                md5.Message = tester.Message;
                tester.Digest = md5.Digest;
                    sim.AddTopLevelInputs(md5.Message)
                        .AddTopLevelOutputs(md5.Digest)
                        .BuildCSVFile()
                        .BuildGraph()
                        // .BuildVHDL()
                        .Run();
            }
            // var md = new MD5();
            // byte[] buffer = new byte[1024];
            // string str = "hello world";
            // for (int i = 0; i < str.Length; i++) {
            //     Console.WriteLine(str[i]);
            //     buffer[i] = (byte)str[i];
            // }
            // Console.WriteLine(buffer);
            // var res = md.calculateMD5(buffer, str.Length);
            // for (int i = 0; i < res.Length; i++) {
            //     Console.Write(res[i].ToString("x8"));
            // }
        }
    }
}
