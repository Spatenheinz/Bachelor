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
        [OutputBus] public Iaxis_o res_o = Scope.CreateBus<Iaxis_o>();

        [OutputBus] public IMessage Message = Scope.CreateBus<IMessage>();
        [InputBus] public Iaxis_o in_o;

        private readonly string[] MESSAGES;

        private static int testsize = 10;
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
                int counter = 0;
                int buffersize = 0;
                int offset = 0;
                Message.MessageSize = message.Length;
                Message.Head = true;
                int i = message.Length;
                while (i >= 0) {
                    offset = MAX_BUFFER_SIZE;
                    if (i < 56)
                    {
                        Message.BufferSize = buffersize = i;
                        Message.Last = true;
                        i -= offset;
                    }
                    else
                    {   offset = Math.Min(i, MAX_BUFFER_SIZE);
                        Message.Set = offset < MAX_BUFFER_SIZE;
                        Message.BufferSize = buffersize = offset;
                        Message.Last = false;
                        i -= offset;
                    }
                    for(int j = 0 ; j < MAX_BUFFER_SIZE; j++)
                        if (j < buffersize)
                        {
                            Message.Message[j] = (byte)message[MAX_BUFFER_SIZE * counter + j];
                        } else {
                            Message.Message[j] = 0;
                        }
                    if (counter++ > 0) { Message.Head = false; }
                    Message.Valid = true;
                        await ClockAsync();
                        Message.Valid = false;
                }
                res_o.Ready = true;
                await ClockAsync();
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
