using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static MD5.MD5Config;

namespace MD5
{
    public class Tester : SimulationProcess
    {
        [InputBus]
        public IDigest Digest;
        [OutputBus]
        public IMessage Message = Scope.CreateBus<IMessage>();

        private readonly string[] MESSAGES;

        private System.Security.Cryptography.MD5 Target = System.Security.Cryptography.MD5.Create();

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(messages), "No message to hash?");
            MESSAGES = messages;
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
                for (int i = message.Length; i > 0; i -= MAX_BUFFER_SIZE){

                    if (i <= MAX_BUFFER_SIZE && i != 56)
                    {
                        Message.BufferSize = i;
                        Message.Last = true;
                    }
                    else
                    {   Message.BufferSize = i == 56 ? i - 1 : MAX_BUFFER_SIZE;
                        Message.Last = false;
                    }
                    await ClockAsync();
                    for(int j = 0 ; j < MAX_BUFFER_SIZE; j++)
                        if (j < Message.BufferSize)
                        {
                            Message.Message[j] = (byte)message[counter * MAX_BUFFER_SIZE + j];
                        } else {
                            Message.Message[j] = 0;
                        }
                    counter++;
                    Message.Valid = true;
                    await ClockAsync();
                    Message.Valid = false;
                }
            await ClockAsync();
            string str = "";
            for(int j = 0; j < 4; j++) {
                str += Digest.Digest[j].ToString("X8");
            }
            Console.WriteLine(str);
            Console.WriteLine(targetHash(message));
            Debug.Assert(str == targetHash(message), "Hash doesnt match the MS library");
            }

            Debug.Assert(Digest.Valid, "failed to produce any output");
            await ClockAsync();
        }
    }
}
