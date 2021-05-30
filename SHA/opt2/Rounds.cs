using SME;
using static opt2.Statics;
using System;

namespace opt2
{
    [ClockedProcess]
    class Round1 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = 0x6a09e667, b = 0xbb67ae85, c = 0x3c6ef372, d = 0xa54ff53a;
                uint e = 0x510e527f, f = 0x9b05688c, g = 0x1f83d9ab, h = 0x5be0cd19;
                for(int i = 0; i < 4; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i] + In.buffer[i];
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
        public readonly static uint[] K = new uint[4]
        {   0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5};
    }

    [ClockedProcess]
    class Round2 : SimpleProcess {
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
                for(int i = 4; i < 8; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-4] + In.buffer[i];
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
                    // Console.WriteLine($"a: {a}, b {b}, c {c}, d {d}, e {e}, f {f}, g {g} h {h}");
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
        public readonly static uint[] K = new uint[4]
        {   0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5 };
    }
    [ClockedProcess]
    class Round3 : SimpleProcess {
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
                for(int i = 8; i < 12; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-8] + In.buffer[i];
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
        public readonly static uint[] K = new uint[4]
        {  0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3};
    }

    [ClockedProcess]
    class Round4 : SimpleProcess {
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
                for(int i = 12; i < 16; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-12] + In.buffer[i];
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
        public readonly static uint[] K = new uint[4]
        {   0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174 };
    }
}
