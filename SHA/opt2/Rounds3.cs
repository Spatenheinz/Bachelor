using SME;
using static opt2.Statics;
using System;

namespace opt2
{
    [ClockedProcess]
    class Round9 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = In.Digest[0], b = In.Digest[1], c = In.Digest[2], d = In.Digest[3];
                uint e = In.Digest[4], f = In.Digest[5], g = In.Digest[6], h = In.Digest[7];
                for(int i = 32; i < 36; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-32] + In.buffer[i];
                    s0 = rightrotate(a, 2) ^ rightrotate(a, 13) ^ rightrotate(a, 22);
                    maj = (a & b) ^ (a & c) ^ (b & c);
                    temp2 = s0 + maj;
                    h = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }
                Out.Digest[0] = a;
                Out.Digest[1] = b;
                Out.Digest[2] = c;
                Out.Digest[3] = d;
                Out.Digest[4] = e;
                Out.Digest[5] = f;
                Out.Digest[6] = g;
                Out.Digest[7] = h;
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
                axi_in.Ready = was_ready = !was_valid;
        }
        public uint rightrotate(uint x, int bits) {
            return (x >> bits) | (x << (32 - bits));
        }
        private void forwardBlock() {
            Out.Last = In.Last;
            for(int i = 0; i < MAX_BUFFER_SIZE; i++) {
                Out.buffer[i] = In.buffer[i];
            }
        }
        public readonly static uint[] K = new uint[4] {
          0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13 };
    }

    [ClockedProcess]
    class Round10 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = In.Digest[0], b = In.Digest[1], c = In.Digest[2], d = In.Digest[3];
                uint e = In.Digest[4], f = In.Digest[5], g = In.Digest[6], h = In.Digest[7];
                for(int i = 36; i < 40; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-36] + In.buffer[i];
                    s0 = rightrotate(a, 2) ^ rightrotate(a, 13) ^ rightrotate(a, 22);
                    maj = (a & b) ^ (a & c) ^ (b & c);
                    temp2 = s0 + maj;
                    h = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }
                Out.Digest[0] = a;
                Out.Digest[1] = b;
                Out.Digest[2] = c;
                Out.Digest[3] = d;
                Out.Digest[4] = e;
                Out.Digest[5] = f;
                Out.Digest[6] = g;
                Out.Digest[7] = h;
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
                axi_in.Ready = was_ready = !was_valid;
        }
        public uint rightrotate(uint x, int bits) {
            return (x >> bits) | (x << (32 - bits));
        }
        private void forwardBlock() {
            Out.Last = In.Last;
            for(int i = 0; i < MAX_BUFFER_SIZE; i++) {
                Out.buffer[i] = In.buffer[i];
            }
        }
        public readonly static uint[] K = new uint[4] {
          0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85 };
    }
    [ClockedProcess]
    class Round11 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = In.Digest[0], b = In.Digest[1], c = In.Digest[2], d = In.Digest[3];
                uint e = In.Digest[4], f = In.Digest[5], g = In.Digest[6], h = In.Digest[7];
                for(int i = 40; i < 44; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-40] + In.buffer[i];
                    s0 = rightrotate(a, 2) ^ rightrotate(a, 13) ^ rightrotate(a, 22);
                    maj = (a & b) ^ (a & c) ^ (b & c);
                    temp2 = s0 + maj;
                    h = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }
                Out.Digest[0] = a;
                Out.Digest[1] = b;
                Out.Digest[2] = c;
                Out.Digest[3] = d;
                Out.Digest[4] = e;
                Out.Digest[5] = f;
                Out.Digest[6] = g;
                Out.Digest[7] = h;
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
                axi_in.Ready = was_ready = !was_valid;
        }
        public uint rightrotate(uint x, int bits) {
            return (x >> bits) | (x << (32 - bits));
        }
        private void forwardBlock() {
            Out.Last = In.Last;
            for(int i = 0; i < MAX_BUFFER_SIZE; i++) {
                Out.buffer[i] = In.buffer[i];
            }
        }
        public readonly static uint[] K = new uint[4] {
          0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3 };
    }

    [ClockedProcess]
    class Round12 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = In.Digest[0], b = In.Digest[1], c = In.Digest[2], d = In.Digest[3];
                uint e = In.Digest[4], f = In.Digest[5], g = In.Digest[6], h = In.Digest[7];
                for(int i = 44; i < 48; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-44] + In.buffer[i];
                    s0 = rightrotate(a, 2) ^ rightrotate(a, 13) ^ rightrotate(a, 22);
                    maj = (a & b) ^ (a & c) ^ (b & c);
                    temp2 = s0 + maj;
                    h = g;
                    g = f;
                    f = e;
                    e = d + temp1;
                    d = c;
                    c = b;
                    b = a;
                    a = temp1 + temp2;
                }
                Out.Digest[0] = a;
                Out.Digest[1] = b;
                Out.Digest[2] = c;
                Out.Digest[3] = d;
                Out.Digest[4] = e;
                Out.Digest[5] = f;
                Out.Digest[6] = g;
                Out.Digest[7] = h;
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
                axi_in.Ready = was_ready = !was_valid;
        }
        public uint rightrotate(uint x, int bits) {
            return (x >> bits) | (x << (32 - bits));
        }
        private void forwardBlock() {
            Out.Last = In.Last;
            for(int i = 0; i < MAX_BUFFER_SIZE; i++) {
                Out.buffer[i] = In.buffer[i];
            }
        }
        public readonly static uint[] K = new uint[4] {
          0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070 };
    }
}
