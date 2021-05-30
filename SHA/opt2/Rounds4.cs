using SME;
using static opt2.Statics;
using System;

namespace opt2
{
    [ClockedProcess]
    class Round13 : SimpleProcess {
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
                for(int i = 48; i < 52; i++) {
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
        public readonly static uint[] K = new uint[4] {
          0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5};
    }

    [ClockedProcess]
    class Round14 : SimpleProcess {
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
                for(int i = 52; i < 56; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-52] + In.buffer[i];
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
            0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        };
    }
    [ClockedProcess]
    class Round15 : SimpleProcess {
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
                for(int i = 56; i < 60; i++) {
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
        public readonly static uint[] K = new uint[4] {
          0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208
        };
    }
    [ClockedProcess]
    class Round16 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IDigest Out = Scope.CreateBus<IDigest>();

        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = In.Digest[0], b = In.Digest[1], c = In.Digest[2], d = In.Digest[3];
                uint e = In.Digest[4], f = In.Digest[5], g = In.Digest[6], h = In.Digest[7];
                for(int i = 60; i < 64; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-60] + In.buffer[i];
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
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
                axi_in.Ready = was_ready = !was_valid;
        }
        public uint rightrotate(uint x, int bits) {
            return (x >> bits) | (x << (32 - bits));
        }
        public readonly static uint[] K = new uint[4] {
            0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
        };
    }

    [ClockedProcess]
    class Combiner : SimpleProcess {
        [InputBus] public IDigest In;
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
