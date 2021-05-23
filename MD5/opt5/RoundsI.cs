using System;
using SME;
using static opt5.Statics;

namespace opt5
{
    [ClockedProcess]
    class RoundI1 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + Ia(IN.B, IN.C, IN.D) + IN.buffer[0] + 0xf4292244, 6));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI2 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + Ia(IN.A, IN.B, IN.C) + IN.buffer[7] + 0x432aff97, 10));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI3 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + Ia(IN.D, IN.A, IN.B) + IN.buffer[14] + 0xab9423a7, 15));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI4 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + Ia(IN.C, IN.D, IN.A) + IN.buffer[5] + 0xfc93a039, 21));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI5 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + Ia(IN.B, IN.C, IN.D) + IN.buffer[12] + 0x655b59c3, 6));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI6 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + Ia(IN.A, IN.B, IN.C) + IN.buffer[3] + 0x8f0ccc92, 10));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI7 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + Ia(IN.D, IN.A, IN.B) + IN.buffer[10] + 0xffeff47d, 15));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI8 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + Ia(IN.C, IN.D, IN.A) + IN.buffer[1] + 0x85845dd1, 21));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI9 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + Ia(IN.B, IN.C, IN.D) + IN.buffer[8] + 0x6fa87e4f, 6));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI10 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + Ia(IN.A, IN.B, IN.C) + IN.buffer[15] + 0xfe2ce6e0, 10));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI11 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + Ia(IN.D, IN.A, IN.B) + IN.buffer[6] + 0xa3014314, 15));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI12 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + Ia(IN.C, IN.D, IN.A) + IN.buffer[13] + 0x4e0811a1, 21));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI13 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + Ia(IN.B, IN.C, IN.D) + IN.buffer[4] + 0xf7537e82, 6));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI14 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + Ia(IN.A, IN.B, IN.C) + IN.buffer[11] + 0xbd3af235, 10));
                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI15 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + Ia(IN.D, IN.A, IN.B) + IN.buffer[2] + 0x2ad7d2bb, 15));
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

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundI16 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IIV Out = Scope.CreateBus<IIV>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + Ia(IN.C, IN.D, IN.A) + IN.buffer[9] + 0xeb86d391, 21));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Final = IN.Last;
                Out.Valid = was_valid = true;
            }  else {
                Out.Final = IN.Last;
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint B;

        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
}
