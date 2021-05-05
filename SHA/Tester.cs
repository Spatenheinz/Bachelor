using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static SHA.SHAConfig;
using System.Linq;

namespace SHA
{
    public class Tester : SimpleProcess
    {
        [InputBus]
        public IMessage Message;

        [OutputBus]
        public IDigest Digest = Scope.CreateBus<IDigest>();

        private readonly string[] MESSAGES;

        private static int testsize = 1;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();


        private System.Security.Cryptography.SHA256 Target = System.Security.Cryptography.SHA256.Create();
        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArguementNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) { randomString[i] = RandomString((i+1) * 2000); }
                MESSAGES = randomStrings;
            }
            else {
                MESSAGES = messages;
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

        public async override Task Run() {
            await ClockAsync();
            foreach (string message in MESSAGES) {
                int buffersize = 0;
                Message.MessageSize = message.Length;
                Message.Head = true;
                Message.Set = false;
                Message.Last = false;
                for (int i = 0; i <= message.Length; i+=MAX_BUFFER_SIZE) {
                    int current_blocksize = message.Lenght - i;
                } // Mangler lidt ;)
            }
        }
    }
}
