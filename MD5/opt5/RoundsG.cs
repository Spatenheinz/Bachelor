using System;
using SME;
using static opt5.Statics;

namespace opt5
{
    [ClockedProcess]
    class RoundG1 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + G(IN.B, IN.C, IN.D) + IN.buffer[1] + 0xf61e2562, 5));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG2 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + G(IN.A, IN.B, IN.C) + IN.buffer[6] + 0xc040b340, 9));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG3 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + G(IN.D, IN.A, IN.B) + IN.buffer[11] + 0x265e5a51, 14));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG4 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + G(IN.C, IN.D, IN.A) + IN.buffer[0] + 0xe9b6c7aa, 20));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG5 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + G(IN.B, IN.C, IN.D) + IN.buffer[5] + 0xd62f105d, 5));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG6 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + G(IN.A, IN.B, IN.C) + IN.buffer[10] + 0x02441453, 9));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG7 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + G(IN.D, IN.A, IN.B) + IN.buffer[15] + 0xd8a1e681, 14));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG8 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + G(IN.C, IN.D, IN.A) + IN.buffer[4] + 0xe7d3fbc8, 20));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG9 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + G(IN.B, IN.C, IN.D) + IN.buffer[9] + 0x21e1cde6, 5));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG10 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + G(IN.A, IN.B, IN.C) + IN.buffer[14] + 0xc33707d6, 9));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG11 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + G(IN.D, IN.A, IN.B) + IN.buffer[3] + 0xf4d50d87, 14));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG12 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + G(IN.C, IN.D, IN.A) + IN.buffer[8] + 0x455a14ed, 20));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG13 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + G(IN.B, IN.C, IN.D) + IN.buffer[13] + 0xa9e3e905, 5));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG14 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + G(IN.A, IN.B, IN.C) + IN.buffer[2] + 0xfcefa3f8, 9));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG15 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + G(IN.D, IN.A, IN.B) + IN.buffer[7] + 0x676f02d9, 14));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundG16 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + G(IN.C, IN.D, IN.A) + IN.buffer[12] + 0x8d2a4c8a, 20));
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

        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
}
