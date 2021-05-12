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

        private static int testsize = 10;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();

        private System.Security.Cryptography.MD5 Target = System.Security.Cryptography.MD5.Create();

        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString(200);
                    // randomStrings[i] = RandomString((i+1) * 200);
                }
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }
        }

        bool was_valid = false;
        bool was_ready = false;
        int i = 0, ii = 0;
        public async override Task Run() {
        string [] results = new string [MESSAGES.Length];
            await ClockAsync();
            // string str2 = "";
            while (i < MESSAGES.Length) {
                // message = MESSAGES[i];
                if (was_valid && axi_Message.Ready) {
                    was_valid = false;
                }
                if (was_ready && Digest.Valid) {
                results[i] += Digest.Digest[0].ToString("X8");
                results[i] += Digest.Digest[1].ToString("X8");
                results[i] += Digest.Digest[2].ToString("X8");
                results[i] += Digest.Digest[3].ToString("X8");
                i++; ii=0;
                Console.WriteLine("done!!!!!!!");
                was_ready = false;
                }
                if (i < MESSAGES.Length) {
                    if (ii <= MESSAGES[i].Length) {
                        Console.WriteLine($"ii {ii}");
                    int buffersize = 0;
                    int current_blocksize = MESSAGES[i].Length - ii;
                    // if we have less than 56 chars we are in the last block
                    if (current_blocksize < 56) {
                        Console.WriteLine("This has to stop");
                        Message.Last = true;
                    }
                    // if the current blocksize is less than the max buffer size,
                    // we need to set the 1 in the padding.
                    else if (current_blocksize < MAX_BUFFER_SIZE) {
                        Message.Set = true;
                    } else {
                        Message.Last = false;
                        Message.Set = false;
                    }
                    // set the buffer size according to the sizes
                    if (ii > 0) {
                        Message.Head = false;
                    } else{
                        Message.Head = true;
                    }
                    Message.MessageSize = MESSAGES[i].Length;
                    Message.BufferSize = buffersize = Math.Min(current_blocksize, MAX_BUFFER_SIZE);
                    Console.WriteLine($"buffersize {buffersize}");
                    for(int jj = 0 ; jj < MAX_BUFFER_SIZE; jj++) {
                        if (jj < buffersize)
                        {
                            Message.Message[jj] = (byte)MESSAGES[i][ii + jj];
                        } else {
                            Message.Message[jj] = 0;
                        }
                    }
                    ii+=buffersize;
                    Message.Valid = was_valid = true;
                    }
                }
                else {
                    Message.Valid = was_valid = false;
                }
                if (i < MESSAGES.Length) {
                    axi_Digest.Ready = was_ready = true;
                }
                else {
                    axi_Digest.Ready = was_ready = false;
                }
                    Console.WriteLine($"sim: {was_ready}, {was_valid}");
                    await ClockAsync();
                }
                for (int k = 0; k < MESSAGES.Length; k++) {
                    Debug.Assert(results[k] == targetHash(MESSAGES[k]), $"String2 {MESSAGES[k]} with Hash nr. {k} - {results[k]} doesnt match the MS library {targetHash(MESSAGES[k])}");
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
