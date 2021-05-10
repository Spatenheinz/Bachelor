using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static opt2.MD5Config;
using System.Linq;

namespace opt2
{
    public class Tester : SimulationProcess
    {

        [InputBus]
        public IRound Digest;

        [OutputBus] public IMessage Message = Scope.CreateBus<IMessage>();

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
                    randomStrings[i] = RandomString((i+1) * 1);
                }
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }
        }

        bool was_valid = false;
        bool was_ready = false;
        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                int buffersize = 0;
                Message.MessageSize = message.Length;
                Message.Set = false;
                Message.Last = false;
                Message.Head = true;
                // for-loop to feed the processes with a message;
                for(int i = 0; i <= message.Length; i+=MAX_BUFFER_SIZE) {
                    int current_blocksize = message.Length - i;
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
                    Message.BufferSize = Math.Min(current_blocksize, MAX_BUFFER_SIZE);
                    for(int j = 0 ; j < MAX_BUFFER_SIZE; j++) {
                        if (j < buffersize)
                        {
                            Message.Message[j] = (byte)message[MAX_BUFFER_SIZE * (i >> 6)  + j];
                        } else {
                            Message.Message[j] = 0;
                        }
                    }
                    Message.Valid = was_valid = true;
                    await ClockAsync();
                    Message.Head = false;
                    Message.Valid = was_valid = false;
                }
                Console.WriteLine("wtf");
                    Message.Valid = was_valid = false;
                // res_o.Ready = true;
                await ClockAsync();
                await ClockAsync();
                await ClockAsync();
                await ClockAsync();
                await ClockAsync();
                await ClockAsync();
                await ClockAsync();
                Console.WriteLine(targetHash(message));
                // if (Digest.Valid) {
                // string str = "";
                string str2 = "";
                str2 += Digest.A.ToString("X8");
                str2 += Digest.B.ToString("X8");
                str2 += Digest.C.ToString("X8");
                str2 += Digest.D.ToString("X8");
                Debug.Assert(str2 == targetHash(message), $"String2 {message} with Hash nr. {0} - {str2} doesnt match the MS library {targetHash(message)}");
                // }
            }
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
