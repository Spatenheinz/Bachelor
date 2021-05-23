using System;
using SME;
using static opt5.Statics;

namespace opt5
{
    [ClockedProcess]
    class RoundH1 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + H(IN.B, IN.C, IN.D) + IN.buffer[5] + 0xfffa3942, 4));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH2 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + H(IN.A, IN.B, IN.C) + IN.buffer[8] + 0x8771f681, 11));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH3 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + H(IN.D, IN.A, IN.B) + IN.buffer[11] + 0x6d9d6122, 16));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH4 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + H(IN.C, IN.D, IN.A) + IN.buffer[14] + 0xfde5380c, 23));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint B;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH5 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + H(IN.B, IN.C, IN.D) + IN.buffer[1] + 0xa4beea44, 4));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH6 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + H(IN.A, IN.B, IN.C) + IN.buffer[4] + 0x4bdecfa9, 11));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH7 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + H(IN.D, IN.A, IN.B) + IN.buffer[7] + 0xf6bb4b60, 16));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH8 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + H(IN.C, IN.D, IN.A) + IN.buffer[10] + 0xbebfbc70, 23));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint B;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH9 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + H(IN.B, IN.C, IN.D) + IN.buffer[13] + 0x289b7ec6, 4));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH10 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + H(IN.A, IN.B, IN.C) + IN.buffer[0] + 0xeaa127fa, 11));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH11 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + H(IN.D, IN.A, IN.B) + IN.buffer[3] + 0xd4ef3085, 16));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH12 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + H(IN.C, IN.D, IN.A) + IN.buffer[6] + 0x04881d05, 23));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint B;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH13 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + H(IN.B, IN.C, IN.D) + IN.buffer[9] + 0xd9d4d039, 4));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH14 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + H(IN.A, IN.B, IN.C) + IN.buffer[12] + 0xe6db99e5, 11));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH15 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + H(IN.D, IN.A, IN.B) + IN.buffer[15] + 0x1fa27cf8, 16));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundH16 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + H(IN.C, IN.D, IN.A) + IN.buffer[2] + 0xc4ac5665, 23));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint B;

        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
}
