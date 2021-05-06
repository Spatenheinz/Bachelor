using System;
using SME;
using static ChaCha.config;

namespace ChaCha {
    public class ChaCha20 : SimpleProcess {
        [InputBus]
        public IState Input;

        [OutputBus]
        public IStream Output = Scope.CreateBus<IStream>();
        private readonly uint CONST1 = 0x61707865;
        private readonly uint CONST2 = 0x3320646e;
        private readonly uint CONST3 = 0x79622d32;
        private readonly uint CONST4 = 0x6b206574;

        private uint[] InterState = new uint[BLOCK_SIZE];
        private uint[] tmp = new uint[BLOCK_SIZE];
        private byte[] res = new byte[64];
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        private static void toByteArray(uint[] arr) {
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


            for(int i = 0; i < BLOCK_SIZE; i++) {
                // Output.Values[i] = reverseByte(InterState[i]+tmp[i]);
                // if (i < )
                // Output.Values[i] = Input.Text[i] ^ reverseByte(InterState[i]+tmp[i]);
            }
        }
        protected override void OnTick() {
            if (Input.Valid) {
                if (Input.Head) {
                    InterState[0] = CONST1; InterState[1] = CONST2; InterState[2] = CONST3; InterState[3] = CONST4;
                    for (int i = 4; i < 12; i++) {
                        InterState[i] = Input.Key[i-4];
                    }
                    InterState[12] = 0;
                    InterState[13] = Input.Nonce0;
                    InterState[14] = Input.Nonce1;
                    InterState[15] = Input.Nonce2;
                }
                InterState[12]++;
                chacha();
                Output.Valid = true;
            }
        }

    }

}
