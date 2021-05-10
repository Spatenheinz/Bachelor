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
        [InputBus] public IDigest Digest;
        [OutputBus] public Iaxis_o axi_Digest = Scope.CreateBus<Iaxis_o>();

        [OutputBus] public IMessage Message = Scope.CreateBus<IMessage>();
        [InputBus] public Iaxis_o axi_Message;

        private readonly string[] MESSAGES;

        private static int testsize = 2;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();

        private System.Security.Cryptography.MD5 Target = System.Security.Cryptography.MD5.Create();

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString((i+1) * 2000);
                }
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }
        }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                int buffersize = 0;
                Message.MessageSize = message.Length;
                Message.Head = true;
                Message.Set = false;
                Message.Last = false;
                // for-loop to feed the processes with a message;
                for(int i = 0; i <= message.Length; i+=MAX_BUFFER_SIZE) {
                    Console.WriteLine(i);
                    Console.WriteLine(message.Length);
                    int current_blocksize = message.Length - i;
                    // Console.WriteLine($"{i}: {current_blocksize} -- {message.Length}");
                    // if we have less than 56 chars we are in the last block
                    if (current_blocksize < 56) {
                        Message.Last = true;
                    }
                    // if the current blocksize is less than the max buffer size,
                    // we need to set the 1 in the padding.
                    else if (current_blocksize < MAX_BUFFER_SIZE) {
                        Message.Set = true;
                    }
                    // set the buffer size according to the sizes
                    Message.BufferSize = buffersize = Math.Min(current_blocksize, MAX_BUFFER_SIZE);
                    string str = "";
                    for(int j = 0 ; j < MAX_BUFFER_SIZE; j++) {
                        // Console.WriteLine(buffersize);
                        if (j < buffersize)
                        {
                            str += Message.Message[j] = (byte)message[MAX_BUFFER_SIZE * (i >> 6)  + j];
                        } else {
                            Message.Message[j] = 0;
                        }
                    }
                    Console.WriteLine(str);
                    Message.Valid = true;
                    await ClockAsync();
                    Message.Head = false;
                }
                // Message.Valid = false;
                axi_Digest.Ready = true;
                // await ClockAsync();
                if (Digest.Valid) {
                string str = "";
                for(int j = 0; j < 4; j++) {
                    str += Digest.Digest[j].ToString("X8");
                }
                Debug.Assert(str == targetHash(message), $"String {message} with Hash nr. {0} - {str} doesnt match the MS library {targetHash(message)}");
                Console.WriteLine(str);
                }
            }
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
    }
}
