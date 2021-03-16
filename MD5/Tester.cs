using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static MD5.MD5Config;
using System.Linq;

namespace MD5
{
    public class Tester : SimulationProcess
    {
        [InputBus]
        public IDigest Digest;

        // [InputBus]
        // public IRound Digest2;

        // [OutputBus]
        // public IRound optDigest = Scope.CreateBus<IRound>();
        [OutputBus]
        public IMessage Message = Scope.CreateBus<IMessage>();

        private readonly string[] MESSAGES;

        private static int testsize = 1;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();


        private System.Security.Cryptography.MD5 Target = System.Security.Cryptography.MD5.Create();

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString((i+1) * 129);

                }
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }

        }

        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }


        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string targetHash(string message) {
            byte[] target = Target.ComputeHash(System.Text.Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(target).Replace("-", string.Empty);
        }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                // optDigest.A = 0x67452301;
                // optDigest.B = 0xefcdab89;
                // optDigest.C = 0x98badcfe;
                // optDigest.D = 0x10325476;
                int counter = 0;
                Message.MessageSize = message.Length;
                Message.Head = true;

                int i = message.Length;
                while (i >= 0) {
                // optDigest.Valid = true;
                    int offset = MAX_BUFFER_SIZE;
                    if (i < 56)
                    {
                        Message.BufferSize = i;
                        Message.Last = true;
                        i -= offset;
                    }
                    else
                    {   offset = Math.Min(i, MAX_BUFFER_SIZE);
                        Message.Set = offset < MAX_BUFFER_SIZE;
                        Message.BufferSize = offset;
                        Message.Last = false;
                        i -= offset;
                    }
                    await ClockAsync();
                    for(int j = 0 ; j < MAX_BUFFER_SIZE; j++)
                        if (j < Message.BufferSize)
                        {
                            Message.Message[j] = (byte)message[MAX_BUFFER_SIZE * counter + j];
                        } else {
                            Message.Message[j] = 0;
                        }
                    if (counter++ > 0) { Message.Head = false; }
                    Message.Valid = true;
                    // while (optDigest.Valid)
                        // Console.WriteLine("hey");
                        await ClockAsync();
                        // Console.WriteLine("i am here");
                        // Console.WriteLine($"called cob Out: {Digest2.A}, {Digest2.B}, {Digest2.C}, {Digest2.D}");
                        // Digest2.Valid = false;
                        // Message.Valid = false;
                    // optDigest.A = Digest2.A;
                    // optDigest.B = Digest2.B;
                    // optDigest.C = Digest2.C;
                    // optDigest.D = Digest2.D;
                    // Digest2.Valid = false;
                    Message.Valid = false;
                }
                // await ClockAsync();
                string str = "";
                // string str2 = "";
                // str2 += reverseByte(optDigest.A).ToString("X8");
                // str2 += reverseByte(optDigest.B).ToString("X8");
                // str2 += reverseByte(optDigest.C).ToString("X8");
                // str2 += reverseByte(optDigest.D).ToString("X8");
                for(int j = 0; j < 4; j++) {
                    str += Digest.Digest[j].ToString("X8");
                }
                Debug.Assert(str == targetHash(message), $"String {message} with Hash nr. {0} - {str} doesnt match the MS library {targetHash(message)}");
                // Debug.Assert(str2 == targetHash(message), $"String2 {message} with Hash nr. {0} - {str2} doesnt match the MS library {targetHash(message)}");
            }

            // Debug.Assert(Digest.Valid && optDigest.Valid, "failed to produce any output");
            // await ClockAsync();
        }
    }
}
