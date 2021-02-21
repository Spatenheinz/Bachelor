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
        [OutputBus]
        public IMessage Message = Scope.CreateBus<IMessage>();

        private readonly string[] MESSAGES;

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private System.Security.Cryptography.MD5 Target = System.Security.Cryptography.MD5.Create();

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                string[] randomStrings = new string[21];
                int memSize = 0;
                for (int i = 1; i <= 21; i++) {
                    randomStrings[i-1] = RandomString(i * 100);
                    // Console.WriteLine(randomStrings[i-1]);
                    memSize += i * 100 * 8;
                }
                // Console.WriteLine(memSize);
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }

        }

        private string targetHash(string message) {
            byte[] target = Target.ComputeHash(System.Text.Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(target).Replace("-", string.Empty);
        }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                int counter = 0;
                Message.MessageSize = message.Length;
                Message.Head = true;
                int i = message.Length;
                while (i >= 0) {
                    // Console.WriteLine(i);
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
                            Message.Message[j] = (byte)message[MAX_BUFFER_SIZE*counter + j];
                        } else {
                            Message.Message[j] = 0;
                        }
                    if (counter++ > 0) { Message.Head = false; }
                    Message.Valid = true;
                    await ClockAsync();
                    Message.Valid = false;
                }
                // while (!Digest.Valid)
                await ClockAsync();
                string str = "";
                for(int j = 0; j < 4; j++) {
                    str += Digest.Digest[j].ToString("X8");
                }
                // Console.WriteLine(str);
                // Console.WriteLine(message.Length);
                Debug.Assert(str == targetHash(message), $"String {message} with Hash nr. {counter} - {str} doesnt match the MS library {targetHash(message)}");
            }

            Debug.Assert(Digest.Valid, "failed to produce any output");
            await ClockAsync();
        }
    }
}
