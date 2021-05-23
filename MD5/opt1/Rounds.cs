using System;
using SME;
using static opt1.Statics;

namespace opt1
{
    [ClockedProcess]
    class RoundF : SimpleProcess {
        [InputBus] public IRound I;
        [OutputBus] public axi_r axi_i = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;

        protected override void OnTick() {
            if (was_ready && I.Valid) {
                A = 0x67452301; B = 0xefcdab89; C = 0x98badcfe; D = 0x10325476;
                processBlock();
                forwardBlock();
            // Console.WriteLine($"called F after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_i.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        // This is the K array which store sthe sines of integers part
        public readonly static uint [] TAB = new uint[16]
            { 0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee
			, 0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501
            , 0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be
            , 0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821
            };

        private void forwardBlock() {
            Out.Last = I.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = I.buffer[i];
            }
        }

        private void processBlock(){
            // round 1
            FF(ref A, B, C, D, 0, 7, 0);    FF(ref D, A, B, C, 1, 12, 1);
            FF(ref C, D, A, B, 2, 17, 2);   FF(ref B, C, D, A, 3, 22, 3);

            FF(ref A, B, C, D, 4, 7, 4);    FF(ref D, A, B, C, 5, 12, 5);
            FF(ref C, D, A, B, 6, 17, 6);   FF(ref B, C, D, A, 7, 22, 7);

            FF(ref A, B, C, D, 8, 7, 8);    FF(ref D, A, B, C, 9, 12, 9);
            FF(ref C, D, A, B, 10, 17, 10); FF(ref B, C, D, A, 11, 22, 11);

            FF(ref A, B, C, D, 12, 7, 12);  FF(ref D, A, B, C, 13, 12, 13);
            FF(ref C, D, A, B, 14, 17, 14); FF(ref B, C, D, A, 15, 22, 15);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + I.buffer[k] + TAB[i], s));
        }

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }

    [ClockedProcess]
    class RoundG : SimpleProcess {
        [InputBus] public IRound F;
        [OutputBus] public axi_r axi_F = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {

            if (was_ready && F.Valid) {
                A = F.A; B = F.B; C = F.C; D = F.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
                // Console.WriteLine($"called G after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_F.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        public readonly static uint [] TAB = new uint[16]
			{ 0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa
            , 0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8
            , 0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed
			, 0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a
            };
        private void forwardBlock() {
            Out.Last = F.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = F.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref A, B, C, D, 1, 5, 0);   GG(ref D, A, B, C, 6, 9, 1);
            GG(ref C, D, A, B, 11, 14, 2); GG(ref B, C, D, A, 0, 20, 3);

            GG(ref A, B, C, D, 5, 5, 4);   GG(ref D, A, B, C, 10, 9, 5);
            GG(ref C, D, A, B, 15, 14, 6); GG(ref B, C, D, A, 4, 20, 7);

            GG(ref A, B, C, D, 9, 5, 8);   GG(ref D, A, B, C, 14, 9, 9);
            GG(ref C, D, A, B, 3, 14, 10);  GG(ref B, C, D, A, 8, 20, 11);

            GG(ref A, B, C, D, 13, 5, 12);  GG(ref D, A, B, C, 2, 9, 13);
            GG(ref C, D, A, B, 7, 14, 14);  GG(ref B, C, D, A, 12, 20, 15);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + F.buffer[k] + TAB[i], s));
        }
        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }

    [ClockedProcess]
    class RoundH : SimpleProcess {
        [InputBus] public IRound G;
        [OutputBus] public axi_r axi_G = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && G.Valid) {
                A = G.A; B = G.B; C = G.C; D = G.D;
                processBlock();
            // Console.WriteLine($"called H after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_G.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        // This is the K array which store sthe sines of integers part
        public readonly static uint [] TAB = new uint[16]
            { 0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c
            , 0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70
            , 0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05
			, 0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665
            };
        private void forwardBlock() {
            Out.Last = G.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = G.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref A, B, C, D, 5, 4, 0);   HH(ref D, A, B, C, 8, 11, 1);
            HH(ref C, D, A, B, 11, 16, 2); HH(ref B, C, D, A, 14, 23, 3);

            HH(ref A, B, C, D, 1, 4, 4);   HH(ref D, A, B, C, 4, 11, 5);
            HH(ref C, D, A, B, 7, 16, 6);  HH(ref B, C, D, A, 10, 23, 7);

            HH(ref A, B, C, D, 13, 4, 8);  HH(ref D, A, B, C, 0, 11, 9);
            HH(ref C, D, A, B, 3, 16, 10);  HH(ref B, C, D, A, 6, 23, 11);

            HH(ref A, B, C, D, 9, 4, 12);   HH(ref D, A, B, C, 12, 11, 13);
            HH(ref C, D, A, B, 15, 16, 14); HH(ref B, C, D, A, 2, 23, 15);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + G.buffer[k] + TAB[i], s));
        }
        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }

    [ClockedProcess]
    class RoundI : SimpleProcess {
        [InputBus] public IRound H;
        [OutputBus] public axi_r axi_H = Scope.CreateBus<axi_r>();

        [InputBus] public axi_r axi_out;
        [OutputBus] public IIV Out = Scope.CreateBus<IIV>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && H.Valid) {
                A = H.A; B = H.B; C = H.C; D = H.D;
                processBlock();
            // Console.WriteLine($"called I after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
                Out.Valid = was_valid = true;
                Out.Final = H.Last;
            }  else {
                Out.Final = H.Last;
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_H.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        // This is the K array which store sthe sines of integers part
        public readonly static uint [] TAB = new uint[16]
            { 0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039
            , 0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1
            , 0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1
			, 0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
            };
        // the loop in the algorithm, might be interesting to unfold the loop as
        // RFC explains it and see which is faster
        private void processBlock(){
            II(ref A, B, C, D, 0, 6, 0);   II(ref D, A, B, C, 7, 10, 1);
            II(ref C, D, A, B, 14, 15, 2); II(ref B, C, D, A, 5, 21, 3);

            II(ref A, B, C, D, 12, 6, 4);  II(ref D, A, B, C, 3, 10, 5);
            II(ref C, D, A, B, 10, 15, 6); II(ref B, C, D, A, 1, 21, 7);

            II(ref A, B, C, D, 8, 6, 8);   II(ref D, A, B, C, 15, 10, 9);
            II(ref C, D, A, B, 6, 15, 10);  II(ref B, C, D, A, 13, 21, 11);

            II(ref A, B, C, D, 4, 6, 12);   II(ref D, A, B, C, 11, 10, 13);
            II(ref C, D, A, B, 2, 15, 14);  II(ref B, C, D, A, 9, 21, 15);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + H.buffer[k] + TAB[i], s));
        }
        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }

    [ClockedProcess]
    class Combiner : SimpleProcess {
        [InputBus] public IIV I;
        [OutputBus] public axi_r axi_I = Scope.CreateBus<axi_r>();


        [InputBus] public axi_r axi_final;
        [OutputBus] public IIV Final = Scope.CreateBus<IIV>();
        bool was_valid = false;
        bool was_ready = false;
        uint A = 0x67452301;
        uint B = 0xefcdab89;
        uint C = 0x98badcfe;
        uint D = 0x10325476;
        protected override void OnTick() {
            if (was_ready && I.Valid) {
                Final.A = reverseByte(A + I.A);
                Final.B = reverseByte(B + I.B);
                Final.C = reverseByte(C + I.C);
                Final.D = reverseByte(D + I.D);
                Final.Valid = was_valid = true;
            } else {
                Final.Valid = was_valid = was_valid && !axi_final.Ready;
            }
            axi_I.Ready = was_ready = !was_valid;
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
    }
}
