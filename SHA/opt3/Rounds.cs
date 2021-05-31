using SME;
using static opt3.Statics;
using System;

namespace opt3
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
                for(int i = 0; i < 8; i++) {
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
        public readonly static uint[] K = new uint[8]
        {   0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5
        };
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
                for(int i = 8; i < 16; i++) {
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
        public readonly static uint[] K = new uint[8] {
          0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174
        };
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
                for(int i = 16; i < 24; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-16] + In.buffer[i];
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
        public readonly static uint[] K = new uint[8] {
            0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        };
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
                for(int i = 24; i < 32; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-24] + In.buffer[i];
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
        public readonly static uint[] K = new uint[8] {
            0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967
        };
    }
    [ClockedProcess]
    class Round5 : SimpleProcess {
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
                for(int i = 32; i < 40; i++) {
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
        public readonly static uint[] K = new uint[8] {
          0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        };
    }

    [ClockedProcess]
    class Round6 : SimpleProcess {
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
                for(int i = 40; i < 48; i++) {
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
        public readonly static uint[] K = new uint[8] {
          0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070
        };
    }

    [ClockedProcess]
    class Round7 : SimpleProcess {
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
                for(int i = 48; i < 56; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-48] + In.buffer[i];
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
        public readonly static uint[] K = new uint[8] {
          0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        };
    }
    [ClockedProcess]
    class Round8 : SimpleProcess {
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
                for(int i = 56; i < 64; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-56] + In.buffer[i];
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
        public readonly static uint[] K = new uint[8] {
          0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
        };
    }
    [ClockedProcess]
    class Combiner : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_final;
        [OutputBus] public IDigest Final = Scope.CreateBus<IDigest>();
        bool was_valid = false;
        bool was_ready = false;
        uint [] H = {0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a,
            0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19};

        protected override void OnTick() {
            if (was_ready && In.Valid) {
                for (int i = 0; i < DIGEST_SIZE; i++) {
                    Final.Digest[i] = H[i] + In.Digest[i];
                }
                Final.Valid = was_valid = true;
            } else {
                Final.Valid = was_valid = was_valid && !axi_final.Ready;
            }
                axi_in.Ready = was_ready = !was_valid;
        }
    }
}
