using System;
using SME;
using static opt3.config;

namespace opt3 {
    [ClockedProcess]
    public class Round1 : SimpleProcess {
        [InputBus] public IState seed;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private readonly uint CONST1 = 0x61707865;
        private readonly uint CONST2 = 0x3320646e;
        private readonly uint CONST3 = 0x79622d32;
        private readonly uint CONST4 = 0x6b206574;

        private uint[] tmp = new uint[BLOCK_SIZE];
        private uint[] InterState = new uint[BLOCK_SIZE];
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
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
            // Even round
            QR(ref tmp[0], ref tmp[4], ref tmp[ 8], ref tmp[12]); // column 0
            QR(ref tmp[1], ref tmp[5], ref tmp[ 9], ref tmp[13]); // column 1

            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.StateO[i] = InterState[i];
                Out.State[i] = tmp[i];
            }
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = seed.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        bool key_set = false;
        protected override void OnTick() {
            if (was_ready && seed.ValidSeed) {
                InterState[0] = CONST1; InterState[1] = CONST2; InterState[2] = CONST3; InterState[3] = CONST4;
                for (int i = 4; i < 12; i++) {
                    InterState[i] = seed.Key[i-4];
                }
                InterState[12] = 0;
                InterState[13] = seed.Nonce0;
                InterState[14] = seed.Nonce1;
                InterState[15] = seed.Nonce2;
                key_set = true;
            } else if (was_ready && seed.ValidT) {
                InterState[12]++;
                chacha();
                Out.Valid = was_valid = true;
                Console.WriteLine($"calculating {was_ready}, {was_valid}");
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }

    }

}
