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

        [InputBus] public IIV Digest;
        [OutputBus] public axi_r axi_Digest = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_Message;
        [OutputBus] public IMessage Message = Scope.CreateBus<IMessage>();

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
                    randomStrings[i] = RandomString(55);
                }
                MESSAGES = randomStrings;
            } else { MESSAGES = messages; }
        }


        bool was_valid = false;
        bool was_ready = false;
        int i = 0, j = 0, ii = 0, jj = 0;
        public async override Task Run() {
        string [] results = new string [MESSAGES.Length];
            await ClockAsync();
            // string str2 = "";
            while (j < MESSAGES.Length) {
                // message = MESSAGES[i];
                if (was_valid && axi_Message.Ready) {
                    was_valid = false;
                    Console.WriteLine("oy");
                }
                if (was_ready && Digest.Valid) {
                results[j] += Digest.A.ToString("X8");
                results[j] += Digest.B.ToString("X8");
                results[j] += Digest.C.ToString("X8");
                results[j++] += Digest.D.ToString("X8");
                Console.WriteLine("done!!!!!!!");
                was_ready = false;
                }
                if (i < MESSAGES.Length) {
                    Console.WriteLine(i);
                    if (ii < MESSAGES[i].Length) {
                        Console.WriteLine($"ii {ii} {MESSAGES[i]}");
                    int buffersize = 0;
                    int current_blocksize = MESSAGES[i].Length - ii;
                    Console.WriteLine($"buffersize: {current_blocksize}");
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
                    ii+= MESSAGES[i].Length == 0 ? 1 : buffersize;
                    Message.Valid = was_valid = true;
                        // break;
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
                // if (j++ == 10)
                //     break;
                    await ClockAsync();
                }
                for (int k = 0; k < MESSAGES.Length; k++) {
                    Debug.Assert(results[k] == targetHash(MESSAGES[k]), $"String2 {MESSAGES[k]} with Hash nr. {k} - {results[k]} doesnt match the MS library {targetHash(MESSAGES[k])}");
                }
        }
            // foreach (string message in MESSAGES) {
            //     int buffersize = 0;
            //     Message.MessageSize = message.Length;
            //     Message.Head = true;
            //     Message.Set = false;
            //     Message.Last = false;
            //     // for-loop to feed the processes with a message;
            //     for(int i = 0; i <= message.Length; i+=MAX_BUFFER_SIZE) {
            //         Console.WriteLine(i);
            //         Console.WriteLine(message.Length);
            //         int current_blocksize = message.Length - i;
            //         // if we have less than 56 chars we are in the last block
            //         if (current_blocksize < 56) {
            //             Message.Last = true;
            //         }
            //         // if the current blocksize is less than the max buffer size,
            //         // we need to set the 1 in the padding.
            //         else if (current_blocksize < MAX_BUFFER_SIZE) {
            //             Message.Set = true;
            //         }
            //         // set the buffer size according to the sizes
            //         Message.BufferSize = buffersize = Math.Min(current_blocksize, MAX_BUFFER_SIZE);
            //         string str = "";
            //         for(int j = 0 ; j < MAX_BUFFER_SIZE; j++) {
            //             if (j < buffersize)
            //             {
            //                 str += Message.Message[j] = (byte)message[MAX_BUFFER_SIZE * (i >> 6)  + j];
            //             } else {
            //                 Message.Message[j] = 0;
            //             }
            //         }
            //         Console.WriteLine(str);
            //         Message.Valid = was_valid = true;
            //         await ClockAsync();
            //         Message.Head = false;
            //         // Message.Valid = was_valid = false;
            //     }
            //         // Message.Valid = was_valid = false;
            //     // ready and result is valid
            //     //
            //     //
            //     // while(!Digest.Final) {
            //     axi_Digest.Ready = true;
            //     for (int i = 0; i < 20; i++) {
            //         await ClockAsync();
            //     }
            //         // await ClockAsync();
            //         // await ClockAsync();
            //         // await ClockAsync();
            //         // await ClockAsync();
            //         // await ClockAsync();
            //         // await ClockAsync();
            //         // await ClockAsync();
            //     // }
            //         // Digest.Valid = false;
            //         // Message.Valid = false;
            //     // res_o.Ready = true;
            //     // await ClockAsync();
            //     string str2 = "";
            //     str2 += reverseByte(Digest.A).ToString("X8");
            //     str2 += reverseByte(Digest.B).ToString("X8");
            //     str2 += reverseByte(Digest.C).ToString("X8");
            //     str2 += reverseByte(Digest.D).ToString("X8");
                // }
            // }
            // res_o.Ready = false;
            // Debug.Assert(Digest.Valid && Digest.Valid, "failed to produce any output");
            // await ClockAsync();
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
