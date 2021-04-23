
// using System;
// using SME;
// using static MD5.MD5Config;

// namespace MD5.opt1
// {
//     class RoundF : SimpleProcess {
//         [InputBus]
//         public IBlock block;

//         [InputBus]
//         public IRound IV;

//         [OutputBus]
//         public IRound Out = Scope.CreateBus<IRound>();

//         protected override void OnTick() {
//             if (block.Valid && IV.Valid) {
//                 A = IV.A;
//                 B = IV.B;
//                 C = IV.C;
//                 D = IV.D;
//             // Console.WriteLine($"called F {cc++}: {A}, {B}, {C}, {D}");
//                 processBlock();
//             // Console.WriteLine($"called F after: {A}, {B}, {C}, {D}");
//                 Out.Valid = true;
//             }
//         }

//         private uint A;
//         private uint B;
//         private uint C;
//         private uint D;

//         // This is the K array which store sthe sines of integers part
//         public readonly static uint [] TAB = new uint[16]
//             { 0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee
// 			, 0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501
//             , 0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be
//             , 0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821
//             };
//         // the loop in the algorithm, might be interesting to unfold the loop as
//         // RFC explains it and see which is faster
//         private void processBlock(){
//             // round 1
//             FF(ref A, B, C, D, 0, 7, 0);    FF(ref D, A, B, C, 1, 12, 1);
//             FF(ref C, D, A, B, 2, 17, 2);   FF(ref B, C, D, A, 3, 22, 3);

//             FF(ref A, B, C, D, 4, 7, 4);    FF(ref D, A, B, C, 5, 12, 5);
//             FF(ref C, D, A, B, 6, 17, 6);   FF(ref B, C, D, A, 7, 22, 7);

//             FF(ref A, B, C, D, 8, 7, 8);    FF(ref D, A, B, C, 9, 12, 9);
//             FF(ref C, D, A, B, 10, 17, 10); FF(ref B, C, D, A, 11, 22, 11);

//             FF(ref A, B, C, D, 12, 7, 12);  FF(ref D, A, B, C, 13, 12, 13);
//             FF(ref C, D, A, B, 14, 17, 14); FF(ref B, C, D, A, 15, 22, 15);

//             Out.A = A;
//             Out.B = B;
//             Out.C = C;
//             Out.D = D;
//         }
//         #region bitwise operators
//         private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
//             aa = bb + (LeftRotate(aa + F(bb, cc, dd) + block.buffer[k] + TAB[i], s));
//         }

//         private uint F(uint x, uint y, uint z) {
//             return (x & y) | ((~x) & z);
//         }
//         private uint LeftRotate(uint x, int k) {
//             return ((x << k) | (x >> (32 - k)));
//         }
//         #endregion
//     }

//     class RoundG : SimpleProcess {
//         [InputBus]
//         public IBlock block;

//         [InputBus]
//         public IRound F;

//         [OutputBus]
//         public IRound Out = Scope.CreateBus<IRound>();

//         protected override void OnTick() {
//             if (block.Valid  && F.Valid) {
//                 A = F.A;
//                 B = F.B;
//                 C = F.C;
//                 D = F.D;
//             // Console.WriteLine($"called G: {A}, {B}, {C}, {D}");
//                 processBlock();
//             // Console.WriteLine($"called G after: {A}, {B}, {C}, {D}");
//                 Out.Valid = true;
//             }
//         }

//         private uint A;
//         private uint B;
//         private uint C;
//         private uint D;

//         // This is the K array which store sthe sines of integers part
//         public readonly static uint [] TAB = new uint[16]
// 			{ 0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa
//             , 0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8
//             , 0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed
// 			, 0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a
//             };
//         // the loop in the algorithm, might be interesting to unfold the loop as
//         // RFC explains it and see which is faster
//         private void processBlock(){
//             GG(ref A, B, C, D, 1, 5, 0);   GG(ref D, A, B, C, 6, 9, 1);
//             GG(ref C, D, A, B, 11, 14, 2); GG(ref B, C, D, A, 0, 20, 3);

//             GG(ref A, B, C, D, 5, 5, 4);   GG(ref D, A, B, C, 10, 9, 5);
//             GG(ref C, D, A, B, 15, 14, 6); GG(ref B, C, D, A, 4, 20, 7);

//             GG(ref A, B, C, D, 9, 5, 8);   GG(ref D, A, B, C, 14, 9, 9);
//             GG(ref C, D, A, B, 3, 14, 10);  GG(ref B, C, D, A, 8, 20, 11);

//             GG(ref A, B, C, D, 13, 5, 12);  GG(ref D, A, B, C, 2, 9, 13);
//             GG(ref C, D, A, B, 7, 14, 14);  GG(ref B, C, D, A, 12, 20, 15);

//             Out.A = A;
//             Out.B = B;
//             Out.C = C;
//             Out.D = D;
//         }

//         #region bitwise operators
//         private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
//             aa = bb + (LeftRotate(aa + G(bb, cc, dd) + block.buffer[k] + TAB[i], s));
//         }
//         private uint G(uint x, uint y, uint z) {
//             return (x & z) | (y & (~z));
//         }
//         private uint LeftRotate(uint x, int k) {
//             return ((x << k) | (x >> (32 - k)));
//         }
//         #endregion
//     }

//     class RoundH : SimpleProcess {
//         [InputBus]
//         public IBlock block;

//         [InputBus]
//         public IRound G;

//         [OutputBus]
//         public IRound Out = Scope.CreateBus<IRound>();

//         protected override void OnTick() {
//             if (block.Valid && G.Valid) {
//                 A = G.A;
//                 B = G.B;
//                 C = G.C;
//                 D = G.D;
//             // Console.WriteLine($"called H: {A}, {B}, {C}, {D}");
//                 processBlock();
//             // Console.WriteLine($"called H after: {A}, {B}, {C}, {D}");
//                 Out.Valid = true;
//             }
//         }

//         private uint A;
//         private uint B;
//         private uint C;
//         private uint D;

//         // This is the K array which store sthe sines of integers part
//         public readonly static uint [] TAB = new uint[16]
//             { 0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c
//             , 0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70
//             , 0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05
// 			, 0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665
//             };
//         // the loop in the algorithm, might be interesting to unfold the loop as
//         // RFC explains it and see which is faster
//         private void processBlock(){
//             HH(ref A, B, C, D, 5, 4, 0);   HH(ref D, A, B, C, 8, 11, 1);
//             HH(ref C, D, A, B, 11, 16, 2); HH(ref B, C, D, A, 14, 23, 3);

//             HH(ref A, B, C, D, 1, 4, 4);   HH(ref D, A, B, C, 4, 11, 5);
//             HH(ref C, D, A, B, 7, 16, 6);  HH(ref B, C, D, A, 10, 23, 7);

//             HH(ref A, B, C, D, 13, 4, 8);  HH(ref D, A, B, C, 0, 11, 9);
//             HH(ref C, D, A, B, 3, 16, 10);  HH(ref B, C, D, A, 6, 23, 11);

//             HH(ref A, B, C, D, 9, 4, 12);   HH(ref D, A, B, C, 12, 11, 13);
//             HH(ref C, D, A, B, 15, 16, 14); HH(ref B, C, D, A, 2, 23, 15);

//             Out.A = A;
//             Out.B = B;
//             Out.C = C;
//             Out.D = D;
//         }

//         #region bitwise operators
//         private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
//             aa = bb + (LeftRotate(aa + H(bb, cc, dd) + block.buffer[k] + TAB[i], s));
//         }
//         private uint H(uint x, uint y, uint z) {
//             return x ^ y ^ z;
//         }
//         private uint LeftRotate(uint x, int k) {
//             return ((x << k) | (x >> (32 - k)));
//         }
//         #endregion
//     }

//     class RoundI : SimpleProcess {
//         [InputBus]
//         public IBlock block;

//         [InputBus]
//         public IRound H;

//         [OutputBus]
//         public IRound Out = Scope.CreateBus<IRound>();

//         protected override void OnTick() {
//             if (block.Valid && H.Valid) {
//                 A = H.A;
//                 B = H.B;
//                 C = H.C;
//                 D = H.D;
//             // Console.WriteLine($"called I: {A}, {B}, {C}, {D}");
//                 processBlock();
//             // Console.WriteLine($"called I after: {A}, {B}, {C}, {D}");
//                 Out.Valid = true;
//             }
//         }

//         private uint A;
//         private uint B;
//         private uint C;
//         private uint D;

//         // This is the K array which store sthe sines of integers part
//         public readonly static uint [] TAB = new uint[16]
//             { 0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039
//             , 0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1
//             , 0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1
// 			, 0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
//             };
//         // the loop in the algorithm, might be interesting to unfold the loop as
//         // RFC explains it and see which is faster
//         private void processBlock(){
//             II(ref A, B, C, D, 0, 6, 0);   II(ref D, A, B, C, 7, 10, 1);
//             II(ref C, D, A, B, 14, 15, 2); II(ref B, C, D, A, 5, 21, 3);

//             II(ref A, B, C, D, 12, 6, 4);  II(ref D, A, B, C, 3, 10, 5);
//             II(ref C, D, A, B, 10, 15, 6); II(ref B, C, D, A, 1, 21, 7);

//             II(ref A, B, C, D, 8, 6, 8);   II(ref D, A, B, C, 15, 10, 9);
//             II(ref C, D, A, B, 6, 15, 10);  II(ref B, C, D, A, 13, 21, 11);

//             II(ref A, B, C, D, 4, 6, 12);   II(ref D, A, B, C, 11, 10, 13);
//             II(ref C, D, A, B, 2, 15, 14);  II(ref B, C, D, A, 9, 21, 15);

//             Out.A = A;
//             Out.B = B;
//             Out.C = C;
//             Out.D = D;
//         }

//         #region bitwise operators
//         private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
//             aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + block.buffer[k] + TAB[i], s));
//         }
//         private uint Ia(uint x, uint y, uint z) {
//             return y ^ (x | (~z));
//         }
//         private uint LeftRotate(uint x, int k) {
//             return ((x << k) | (x >> (32 - k)));
//         }
//         #endregion
//     }
//     class Combiner : SimpleProcess {
//         [InputBus]
//         public IRound IV;

//         [InputBus]
//         public IRound I;

//         [OutputBus]
//         public IRound Out = Scope.CreateBus<IRound>();

//         protected override void OnTick() {
//             if (IV.Valid && I.Valid) {
//                 Out.A = IV.A + I.A;
//                 Out.B = IV.B + I.B;
//                 Out.C = IV.C + I.C;
//                 Out.D = IV.D + I.D;
//                 Out.Valid = true;
//             // Console.WriteLine($"called cob IV: {IV.A}, {IV.B}, {IV.C}, {IV.D}");
//             // Console.WriteLine($"called cob I: {I.A}, {I.B}, {I.C}, {I.D}");
//             }
//         }
//     }
// }
