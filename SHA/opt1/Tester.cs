using System;
using SME;
using System.Threading.Tasks;
using System.Diagnostics;
using static opt1.Statics;
using System.Linq;

namespace opt1
{
    public class Tester : SimulationProcess
    {
        [InputBus] public IDigest Digest;
        [OutputBus] public axi_r axi_Digest = Scope.CreateBus<axi_r>();

        [OutputBus] public IMessage Message = Scope.CreateBus<IMessage>();
        [InputBus] public axi_r axi_Message;

        private readonly string[] MESSAGES;

        private static int testsize = 2;
        private string[] randomStrings = new string[testsize];
        private static Random random = new Random();


        private System.Security.Cryptography.SHA256 Target = System.Security.Cryptography.SHA256.Create();
        public Tester(params string[] messages) {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));
            if (messages.Length == 0) {
                for (int i = 0; i < testsize; i++) {
                    randomStrings[i] = RandomString(55);
                }
                MESSAGES = randomStrings;
            }
            else {
                MESSAGES = messages;
            }
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        bool was_valid = false;
        bool was_ready = false;
        int i = 0, ii = 0, j = 0;
        public async override Task Run() {
        string [] results = new string [MESSAGES.Length];
            await ClockAsync();
            // string str2 = "";
            while (j < MESSAGES.Length) {
                // message = MESSAGES[i];
                if (was_valid && axi_Message.Ready) {
                    was_valid = false;
                }
                if (was_ready && Digest.Valid) {
                    for(int jj = 0; jj < DIGEST_SIZE; jj++) {
                        results[j] += Digest.Digest[jj].ToString("X8");
                    }
                    j++;
                    Console.WriteLine("done!!!!!!!");
                    was_ready = false;
                }
                if (i < MESSAGES.Length) {
                    if (ii < MESSAGES[i].Length) {
                        Console.WriteLine($"ii {ii}");
                        int buffersize = 0;
                        int current_blocksize = MESSAGES[i].Length - ii;
                        // if we have less than 56 chars we are in the last block
                        if (current_blocksize < 56) {
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
                        for(int jj = 0 ; jj < MAX_BUFFER_SIZE; jj++) {
                            if (jj < buffersize)
                            {
                                Message.Message[jj] = (byte)MESSAGES[i][ii + jj];
                            } else {
                                Message.Message[jj] = 0;
                            }
                        }
                        ii+= buffersize;
                        Message.Valid = was_valid = true;
                    } else {
                        i++;
                        ii=0;
                        Message.Valid = was_valid = false;
                    }
                }
                else {
                    Message.Valid = was_valid = false;
                }
                if (j < results.Length) {
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


        private string targetHash(string message) {
            byte[] target = Target.ComputeHash(System.Text.Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(target).Replace("-", string.Empty);
        }
    }
}
