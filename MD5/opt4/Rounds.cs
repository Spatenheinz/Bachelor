using System;
using SME;
using static opt4.Statics;

namespace opt4
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
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                    Console.WriteLine(IN.buffer[i]);
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            // round 1
            FF(ref A, B, C, D, 0, 7,  0xd76aa478); FF(ref D, A, B, C, 1, 12, 0xe8c7b756);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }

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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            FF(ref C, D, A, B, 2, 17, 0x242070db); FF(ref B, C, D, A, 3, 22, 0xc1bdceee);


            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            FF(ref A, B, C, D, 4, 7,  0xf57c0faf); FF(ref D, A, B, C, 5, 12, 0x4787c62a);


            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }

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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
            Console.WriteLine($"called F after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
                processBlock();
                forwardBlock();
            // Console.WriteLine($"called F after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
                Out.Valid = was_valid = true;
            Console.WriteLine($"called F after: {A.ToString("x8")}, {B.ToString("x8")}, {C.ToString("x8")}, {D.ToString("x8")}");
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            FF(ref C, D, A, B, 6, 17, 0xa8304613); FF(ref B, C, D, A, 7, 22, 0xfd469501);


            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }

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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            // round 1
            FF(ref A, B, C, D, 8, 7,  0x698098d8); FF(ref D, A, B, C, 9, 12, 0x8b44f7af);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            // round 1
            FF(ref C, D, A, B, 10, 17, 0xffff5bb1); FF(ref B, C, D, A, 11, 22, 0x895cd7be);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            FF(ref A, B, C, D, 12, 7, 0x6b901122);  FF(ref D, A, B, C, 13, 12, 0xfd987193);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B;private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }

        private void processBlock(){
            FF(ref C, D, A, B, 14, 17, 0xa679438e); FF(ref B, C, D, A, 15, 22, 0x49b40821);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + IN.buffer[k] + i, s));
        }
        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref A, B, C, D, 1, 5, 0xf61e2562);   GG(ref D, A, B, C, 6, 9, 0xc040b340);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref C, D, A, B, 11, 14, 0x265e5a51); GG(ref B, C, D, A, 0, 20, 0xe9b6c7aa);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref A, B, C, D, 5, 5, 0xd62f105d);   GG(ref D, A, B, C, 10, 9, 0x02441453);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref C, D, A, B, 15, 14, 0xd8a1e681); GG(ref B, C, D, A, 4, 20, 0xe7d3fbc8);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref A, B, C, D, 9, 5, 0x21e1cde6);   GG(ref D, A, B, C, 14, 9, 0xc33707d6);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                // Console.WriteLine($"{axi_out.Ready}");
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref C, D, A, B, 3, 14, 0xf4d50d87);  GG(ref B, C, D, A, 8, 20, 0x455a14ed);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                // Console.WriteLine($"{axi_out.Ready}");
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref A, B, C, D, 13, 5, 0xa9e3e905);  GG(ref D, A, B, C, 2, 9, 0xfcefa3f8);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                // Console.WriteLine($"{axi_out.Ready}");
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            GG(ref C, D, A, B, 7, 14, 0x676f02d9);  GG(ref B, C, D, A, 12, 20, 0x8d2a4c8a);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + IN.buffer[k] + i, s));
        }
        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref A, B, C, D, 5, 4, 0xfffa3942);   HH(ref D, A, B, C, 8, 11, 0x8771f681);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref C, D, A, B, 11, 16, 0x6d9d6122); HH(ref B, C, D, A, 14, 23, 0xfde5380c);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref A, B, C, D, 1, 4, 0xa4beea44);   HH(ref D, A, B, C, 4, 11, 0x4bdecfa9);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref C, D, A, B, 7, 16, 0xf6bb4b60);  HH(ref B, C, D, A, 10, 23, 0xbebfbc70);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref A, B, C, D, 13, 4, 0x289b7ec6);  HH(ref D, A, B, C, 0, 11, 0xeaa127fa);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref C, D, A, B, 3, 16, 0xd4ef3085);  HH(ref B, C, D, A, 6, 23, 0x04881d05);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref A, B, C, D, 9, 4, 0xd9d4d039);   HH(ref D, A, B, C, 12, 11, 0xe6db99e5);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void processBlock(){
            HH(ref C, D, A, B, 15, 16, 0x1fa27cf8); HH(ref B, C, D, A, 2, 23, 0xc4ac5665);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + IN.buffer[k] + i, s));
        }
        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
    }

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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref A, B, C, D, 0, 6, 0xf4292244);   II(ref D, A, B, C, 7, 10, 0x432aff97);
            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref C, D, A, B, 14, 15, 0xab9423a7); II(ref B, C, D, A, 5, 21, 0xfc93a039);
            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref A, B, C, D, 12, 6, 0x655b59c3);  II(ref D, A, B, C, 3, 10, 0x8f0ccc92);
            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref C, D, A, B, 10, 15, 0xffeff47d); II(ref B, C, D, A, 1, 21, 0x85845dd1);
            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref A, B, C, D, 8, 6, 0x6fa87e4f);   II(ref D, A, B, C, 15, 10, 0xfe2ce6e0);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref C, D, A, B, 6, 15, 0xa3014314);  II(ref B, C, D, A, 13, 21, 0x4e0811a1);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                forwardBlock();
                Out.Valid = was_valid = true;
            }  else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref A, B, C, D, 4, 6, 0xf7537e82);   II(ref D, A, B, C, 11, 10, 0xbd3af235);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void forwardBlock() {
            Out.Last = IN.Last;
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.buffer[i] = IN.buffer[i];
            }
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
        }
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
        [OutputBus] public IIV Out = Scope.CreateBus<IIV>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && IN.Valid) {
                A = IN.A; B = IN.B; C = IN.C; D = IN.D;
                processBlock();
                Out.Valid = was_valid = true;
                Out.Final = IN.Last;
            }  else {
                Out.Final = IN.Last;
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }

        private uint A; private uint B; private uint C; private uint D;

        private void processBlock(){
            II(ref C, D, A, B, 2, 15, 0x2ad7d2bb);  II(ref B, C, D, A, 9, 21, 0xeb86d391);

            Out.A = A; Out.B = B; Out.C = C; Out.D = D;
        }

        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, uint i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + IN.buffer[k] + i, s));
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
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();


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
            axi_in.Ready = was_ready = !was_valid;
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
    }
}
