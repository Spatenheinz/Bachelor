using SME;
using static opt2.Statics;
using System;

namespace opt2
{
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
                for(int i = 16; i < 20; i++) {
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
        public readonly static uint[] K = new uint[4] {
            0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc};
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
                for(int i = 20; i < 24; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-20] + In.buffer[i];
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
           0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da};
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
                for(int i = 24; i < 28; i++) {
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
        public readonly static uint[] K = new uint[4] {
            0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7};
    }
    [ClockedProcess]
    class Round8 : SimpleProcess {
        [InputBus] public IRound In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        // public Round8(int _size) {
        //     size = _size;
        // }
        // private int size;
        bool was_valid = false;
        bool was_ready = false;
        uint s0 = 0, s1 = 0, ch = 0, temp1 = 0, temp2 = 0, maj = 0;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                uint a = In.Digest[0], b = In.Digest[1], c = In.Digest[2], d = In.Digest[3];
                uint e = In.Digest[4], f = In.Digest[5], g = In.Digest[6], h = In.Digest[7];
                for(int i = 28; i < 32; i++) {
                    s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                    ch = (e & f) ^ ((~e) & g);
                    temp1 = h + s1 + ch + K[i-28] + In.buffer[i];
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
            0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967
        };
    }
}
