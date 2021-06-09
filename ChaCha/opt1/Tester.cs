using SME;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using static opt1.config;
using Process = System.Diagnostics.Process;
using System.IO;
namespace opt1 {
    public class Tester : SimulationProcess {
        [InputBus]
        public IStream HashStream;
        [OutputBus]
        public axi_r axi_Stream = Scope.CreateBus<axi_r>();
        [OutputBus]
        public IState State = Scope.CreateBus<IState>();
        [InputBus]
        public axi_r axi_State;

        public static uint[] StringToArray(string hex) {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 8 == 0)
                .Select(x => Convert.ToUInt32(hex.Substring(x,8), 16))
                .ToArray();
        }

        private uint[] testkey = StringToArray("03020100070605040b0a09080f0e0d0c13121110171615141b1a19181f1e1d1c");
        private byte[] plaintext = Encoding.ASCII.GetBytes("Ladies and Gentlemen of the class of '99: If I could offer you only one tip for the future, sunscreen would be it.");
        private string result = "";

        bool was_valid = false;
        bool was_ready = true;
        bool key_set = false;
        int ii = 0; int i=0;
        public async override Task Run() {

            await ClockAsync();
            State.ValidSeed = key_set = true;

            for(int i = 0; i < BUFFER_SIZE; i++) {
                State.Key[i] = testkey[i];
            }
            State.Nonce0 = 0x00000000;
            State.Nonce1 = 0x4a000000;
            State.Nonce2 = 0x00000000;
            await ClockAsync();
            State.ValidSeed = false;
            State.ValidT = was_valid = true;
            for(int iii = 0; iii < TEXT_SIZE; iii++) {
                if (iii < plaintext.Length) {
                    State.Text[iii] = plaintext[iii];
                } else {
                    State.Text[iii] = 0;
                }
            }
            await ClockAsync();
            for(int iii = 0; iii < TEXT_SIZE; iii++) {
                if (TEXT_SIZE+ iii < plaintext.Length) {
                    State.Text[iii] = plaintext[TEXT_SIZE+iii];
                } else {
                    State.Text[iii] = 0;
                }
            }
            axi_Stream.ready = true;
            while(result.Length < plaintext.Length * 2) {
            await ClockAsync();
                if (was_ready && HashStream.Valid) {
                    for (int jj = 0; jj < TEXT_SIZE; jj++) {
                        result += HashStream.Values[jj].ToString("x2");
                    }
                    Console.WriteLine("res length " + result.Length);
                    // was_ready = false;
                }
            }
            // while (result.Length < plaintext.Length * 2) {
            //     // message = MESSAGES[i];
            //     if (was_valid && axi_State.ready) {
            //         was_valid = false;
            //     }
            //     if (was_ready && HashStream.Valid) {
            //         for (int jj = 0; jj < TEXT_SIZE; jj++) {
            //             result += HashStream.Values[jj].ToString("X2");
            //         }
            //         Console.WriteLine("res length " + result.Length);
            //         // was_ready = false;
            //     }
            //     if (!key_set) {
            //             Console.WriteLine("set");
            //     } else if (ii < plaintext.Length) {
            //             Console.WriteLine(ii);
            //         for(int iii = 0; iii < TEXT_SIZE; iii++) {
            //             if (ii+iii < plaintext.Length) {
            //                 State.Text[iii] = plaintext[ii+iii];
            //             } else {
            //                 State.Text[iii] = 0;
            //             }
            //         }
            //         ii+=TEXT_SIZE;
            //         State.ValidSeed = false;
            //         State.ValidT = was_valid = true;
            //     } else {
            //         State.ValidT = was_valid = false;
            //     }

            // // Console.WriteLine($"ok, {was_ready}, {was_valid_text} {was_valid}");
            //     await ClockAsync();
            // }
            Console.WriteLine(result);
            Console.WriteLine(plaintext.Length);
            for(int i = 0; i < plaintext.Length; i++) {
                Console.Write(plaintext[i].ToString("x2"));
            }
            Console.WriteLine(result.Length);
        }
    }
}
