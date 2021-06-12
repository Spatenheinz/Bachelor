using SME;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using static opt3.config;

namespace opt3 {
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
        private static byte[] target = new byte[] {
                                 0x6e, 0x2e, 0x35, 0x9a, 0x25, 0x68, 0xf9, 0x80, 0x41, 0xba, 0x07, 0x28, 0xdd, 0x0d, 0x69, 0x81,
                                 0xe9, 0x7e, 0x7a, 0xec, 0x1d, 0x43, 0x60, 0xc2, 0x0a, 0x27, 0xaf, 0xcc, 0xfd, 0x9f, 0xae, 0x0b,
                                 0xf9, 0x1b, 0x65, 0xc5, 0x52, 0x47, 0x33, 0xab, 0x8f, 0x59, 0x3d, 0xab, 0xcd, 0x62, 0xb3, 0x57,
                                 0x16, 0x39, 0xd6, 0x24, 0xe6, 0x51, 0x52, 0xab, 0x8f, 0x53, 0x0c, 0x35, 0x9f, 0x08, 0x61, 0xd8,
                                 0x07, 0xca, 0x0d, 0xbf, 0x50, 0x0d, 0x6a, 0x61, 0x56, 0xa3, 0x8e, 0x08, 0x8a, 0x22, 0xb6, 0x5e,
                                 0x52, 0xbc, 0x51, 0x4d, 0x16, 0xcc, 0xf8, 0x06, 0x81, 0x8c, 0xe9, 0x1a, 0xb7, 0x79, 0x37, 0x36,
                                 0x5a, 0xf9, 0x0b, 0xbf, 0x74, 0xa3, 0x5b, 0xe6, 0xb4, 0x0b, 0x8e, 0xed, 0xf2, 0x78, 0x5e, 0x42,
                                 0x87, 0x4d
        };
        private byte[] result = new byte[target.Length];
        bool was_valid = false;
        bool was_ready = true;
        bool key_set = false;
        int ii = 0; int i=0; int j = 0;
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
            while(result[113] == 0) {
                await ClockAsync();
                if (was_ready && HashStream.Valid) {
                    for (int jj = 0; jj < TEXT_SIZE; jj++) {
                        if(result.Length <= j+jj) break;
                        result[j+jj] = HashStream.Values[jj];
                    }
                    j+=TEXT_SIZE;
                    Console.WriteLine("res length " + result.Length);
                    // was_ready = false;
                }
            }
            for(int i = 0; i < target.Length; i++)
                Debug.Assert(result[i] == target[i], $"{i} -\n{result[i].ToString("x2")}\ndoesnt match the target:\n{target[i].ToString("x2")}");
        }
    }
}
