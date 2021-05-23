using System;
using SME;
using static opt5.Statics;

namespace opt5
{
    [ClockedProcess]
    class RoundF1 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                A = 0x67452301; B = 0xefcdab89; C = 0x98badcfe; D = 0x10325476;
                A = B + (LeftRotate(A + F(B, C, D) + IN.buffer[0] + 0xd76aa478, 7));
                Out.A = A; Out.B = B; Out.C = C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF2 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + F(IN.A, IN.B, IN.C) + IN.buffer[1] + 0xe8c7b756, 12));

                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF3 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + F(IN.D, IN.A, IN.B) + IN.buffer[2] + 0x242070db, 17));

                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF4 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + F(IN.C, IN.D, IN.A) + IN.buffer[3] + 0xc1bdceee, 22));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }
        private uint B;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF5 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + F(IN.B, IN.C, IN.D) + IN.buffer[4] + 0xf57c0faf, 7));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF6 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + F(IN.A, IN.B, IN.C) + IN.buffer[5] + 0x4787c62a, 12));

                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF7 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + F(IN.D, IN.A, IN.B) + IN.buffer[6] + 0xa8304613, 17));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Console.WriteLine(IN.buffer[i]);
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF8 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + F(IN.C, IN.D, IN.A) + IN.buffer[7] + 0xfd469501, 22));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }
        private uint B;
        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF9 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + F(IN.B, IN.C, IN.D) + IN.buffer[8] + 0x698098d8, 7));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF10 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + F(IN.A, IN.B, IN.C) + IN.buffer[9] + 0x8b44f7af, 12));

                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF11 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + F(IN.D, IN.A, IN.B) + IN.buffer[10] + 0xffff5bb1, 17));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF12 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + F(IN.C, IN.D, IN.A) + IN.buffer[11] + 0x895cd7be, 22));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }
        private uint B;
        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF13 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                A = IN.B + (LeftRotate(IN.A + F(IN.B, IN.C, IN.D) + IN.buffer[12] + 0x6b901122, 7));
                Out.A = A; Out.B = IN.B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF14 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                D = IN.A + (LeftRotate(IN.D + F(IN.A, IN.B, IN.C) + IN.buffer[13] + 0xfd987193, 12));

                Out.A = IN.A; Out.B = IN.B; Out.C = IN.C; Out.D = D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint D;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF15 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                C = IN.D + (LeftRotate(IN.C + F(IN.D, IN.A, IN.B) + IN.buffer[14] + 0xa679438e, 17));
                Out.A = IN.A; Out.B = IN.B; Out.C = C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint C;

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
    [ClockedProcess]
    class RoundF16 : SimpleProcess {
        [InputBus] public IRound IN;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                B = IN.C + (LeftRotate(IN.B + F(IN.C, IN.D, IN.A) + IN.buffer[15] + 0x49b40821, 22));
                Out.A = IN.A; Out.B = B; Out.C = IN.C; Out.D = IN.D;
                Out.Last = IN.Last;
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Out.buffer[i] = IN.buffer[i];
                }
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }
        private uint B;
        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
}
