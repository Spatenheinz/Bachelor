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

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(messages), "No message to hash?");
            MESSAGES = messages;
        }

        public async override Task Run() {

            await ClockAsync();
            foreach (string message in MESSAGES) {
                    int counter = 0;
                Message.MessageSize = message.Length;
                for (int i = message.Length; i > 0; i -= MAX_BUFFER_SIZE){
                    if (i <= MAX_BUFFER_SIZE)
                    {
                        Message.BufferSize = i;
                        Message.Last = true;
                    }
                    else
                    {
                        Message.BufferSize = MAX_BUFFER_SIZE;
                        Message.Last = false;
                    }
                await ClockAsync();
                    for(int j = 0 ; j < Message.BufferSize; j++)
                        Message.Message[j] = (byte)message[counter*MAX_BUFFER_SIZE+j];
                counter++;
                Message.Valid = true;
                await ClockAsync();
                Message.Valid = false;
                }
            }
                Debug.Assert(Digest.Valid, "failed to produce output");
        }
    }
}
