using System;
using SME;
using static opt3.config;

namespace opt3 {
    [ClockedProcess]
    public class RoundEven_1 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private uint[] tmp = new uint[BLOCK_SIZE];
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
                tmp[i] = In.State[i];
            }
            // Even round
            QR(ref tmp[0], ref tmp[4], ref tmp[ 8], ref tmp[12]); // column 0
            QR(ref tmp[1], ref tmp[5], ref tmp[ 9], ref tmp[13]); // column 1

            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.StateO[i] = In.StateO[i];
                Out.State[i] = tmp[i];
            }
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                chacha();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }
    }

    [ClockedProcess]
    public class RoundEven_2 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private uint[] tmp = new uint[BLOCK_SIZE];
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
                tmp[i] = In.State[i];
            }
            // Even round
            QR(ref tmp[2], ref tmp[6], ref tmp[10], ref tmp[14]); // column 2
            QR(ref tmp[3], ref tmp[7], ref tmp[11], ref tmp[15]); // column 3
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.StateO[i] = In.StateO[i];
                Out.State[i] = tmp[i];
            }
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                chacha();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }
    }
    [ClockedProcess]
    public class RoundOdd_1 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private uint[] tmp = new uint[BLOCK_SIZE];
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
                tmp[i] = In.State[i];
            }
            // Odd round
            QR(ref tmp[0], ref tmp[5], ref tmp[10], ref tmp[15]); // diagonal 1 (main diagonal)
            QR(ref tmp[1], ref tmp[6], ref tmp[11], ref tmp[12]); // diagonal 2

            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.StateO[i] = In.StateO[i];
                Out.State[i] = tmp[i];
            }
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                chacha();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }
    }
    [ClockedProcess]
    public class RoundOdd_2 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private uint[] tmp = new uint[BLOCK_SIZE];
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
                tmp[i] = In.State[i];
            }
            // Odd round
            QR(ref tmp[2], ref tmp[7], ref tmp[ 8], ref tmp[13]); // diagonal 3
            QR(ref tmp[3], ref tmp[4], ref tmp[ 9], ref tmp[14]); // diagonal 4

            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.StateO[i] = In.StateO[i];
                Out.State[i] = tmp[i];
            }
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                chacha();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }
    }
    [ClockedProcess]
    public class RoundCombine : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        private void chacha() {
            for(int i = 0; i < 8; i++)
                Out.State[i] = reverseByte(In.StateO[i] + In.State[i]);
            for(int i = 8; i < BLOCK_SIZE; i++){
                Out.State[i] = In.State[i];
                Out.StateO[i] = In.StateO[i];
            }
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                chacha();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }
    }
    [ClockedProcess]
    public class RoundCombine_2 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        private void chacha() {
            for(int i = 0; i < 8; i++)
                Out.State[i] = In.State[i];
            for(int i = 8; i < BLOCK_SIZE; i++)
                Out.State[i] = reverseByte(In.StateO[i] + In.State[i]);
            for(int i = 0; i< TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                chacha();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }
    }
}
