using System;
using SME;
using static ChaCha.config;

namespace ChaCha {
    [ClockedProcess]
    public class ChaCha20 : SimpleProcess {
        [InputBus] public IState seed;
        [OutputBus] public axi_r axi_seed = Scope.CreateBus<axi_r>();
        [OutputBus] public IStream Output = Scope.CreateBus<IStream>();
        [InputBus] public axi_r axi_O;

        private readonly uint CONST1 = 0x61707865;
        private readonly uint CONST2 = 0x3320646e;
        private readonly uint CONST3 = 0x79622d32;
        private readonly uint CONST4 = 0x6b206574;

        private uint[] InterState = new uint[BLOCK_SIZE];
        private uint[] tmp = new uint[BLOCK_SIZE];
        private byte[] res = new byte[TEXT_SIZE];
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        private void toByteArray(uint[] arr) {
            for(int i=0; i < 61; i+=4){
                res[i] = (byte)((arr[i>>2] >> 24) & 0xff);
                res[i+1] = (byte)((arr[i>>2] >> 16) & 0xff);
                res[i+2] = (byte)((arr[i>>2] >> 8) & 0xff);
                res[i+3] = (byte)((arr[i>>2]) & 0xff);
            }
        }
        private void QR(ref uint a, ref uint b, ref uint c, ref uint d) {
            a += b; d ^= a; d = LeftRotate(d, 16);
            c += d; b ^= c; b = LeftRotate(b, 12);
            a += b; d ^= a; d = LeftRotate(d, 8);
            c += d; b ^= c; b = LeftRotate(b, 7);
        }
        private void chacha() {
            for(int i = 0; i < BLOCK_SIZE; i++) {
                tmp[i] = InterState[i];
            }
            for(int i = 0; i < 20; i += 2) {
            // Odd round
            QR(ref tmp[0], ref tmp[4], ref tmp[ 8], ref tmp[12]); // column 0
            QR(ref tmp[1], ref tmp[5], ref tmp[ 9], ref tmp[13]); // column 1
            QR(ref tmp[2], ref tmp[6], ref tmp[10], ref tmp[14]); // column 2
            QR(ref tmp[3], ref tmp[7], ref tmp[11], ref tmp[15]); // column 3
            // Even round
            QR(ref tmp[0], ref tmp[5], ref tmp[10], ref tmp[15]); // diagonal 1 (main diagonal)
            QR(ref tmp[1], ref tmp[6], ref tmp[11], ref tmp[12]); // diagonal 2
            QR(ref tmp[2], ref tmp[7], ref tmp[ 8], ref tmp[13]); // diagonal 3
            QR(ref tmp[3], ref tmp[4], ref tmp[ 9], ref tmp[14]); // diagonal 4
            }

            for(int i = 0; i < BLOCK_SIZE; i++)
                tmp[i] = reverseByte(InterState[i]+tmp[i]);
            toByteArray(tmp);
            for(int i = 0; i < TEXT_SIZE; i++) {
                // Output.Values[i] = (byte)(text.Text[i] ^ res[i]);
                Output.Values[i] = (byte)(seed.Text[i] ^ res[i]);
            }
        }
        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (seed.ValidSeed) {
                InterState[0] = CONST1; InterState[1] = CONST2; InterState[2] = CONST3; InterState[3] = CONST4;
                for (int i = 4; i < 12; i++) {
                    InterState[i] = seed.Key[i-4];
                }
                InterState[12] = 0;
                InterState[13] = seed.Nonce0;
                InterState[14] = seed.Nonce1;
                InterState[15] = seed.Nonce2;
            } else if (seed.ValidT) {
                InterState[12]++;
                chacha();
                Output.Valid = was_valid = true;
            } else {
                Output.Valid = was_valid = was_valid && !axi_O.ready;
            }
            axi_seed.ready = was_ready = !was_valid;
            Console.WriteLine($"{was_ready}, {was_valid}");
        }

    }

}
