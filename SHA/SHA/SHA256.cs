// using System;
// using SME;
// using static SHA.SHAConfig;

// namespace SHA
// {
//     class naive : SimpleProcess {
//         [InputBus]
//         public IMessage Message;

//         [OutputBus]
//         public IDigest Digest = Scope.CreateBus<IDigest>();

//         public int counter = 0;

//         protected override void OnTick() {
//             counter++;
//             if (Message.Valid) {
//                 if (Message.Head) {
//                     a = h0; b = h1; c = h2; d = h3; e = h4; f = h5; g = h6; h = h7;
//                 }
//                 SHA256(Message.Message);
//                 if (Message.Last) {
//                     // for (i = 0; i < DIGEST_SIZE; i++) {
//                     //     Digest.Digest = hash[i];
//                     // }
//                     Digest.Digest[0] = hash[0];
//                     Digest.Digest[1] = hash[1];
//                     Digest.Digest[2] = hash[2];
//                     Digest.Digest[3] = hash[3];
//                     Digest.Digest[4] = hash[4];
//                     Digest.Digest[5] = hash[5];
//                     Digest.Digest[6] = hash[6];
//                     Digest.Digest[7] = hash[7];
//                     Digest.Valid = true;
//                 }
//             }
//         }

//         public uint rightrotate(uint x, int bits) {
//             // Right rotate: https://stackoverflow.com/questions/812022/c-sharp-bitwise-rotate-left-and-rotate-right
//             return (x >> bits) | (x << (32 - bits));
//         }

//         // Initialize hash values:
//         // (first 32 bits of the fractional parts of the square roots of the first 8 primes 2..19):
//         public static uint h0 = 0x6a09e667;
//         public static uint h1 = 0xbb67ae85;
//         public static uint h2 = 0x3c6ef372;
//         public static uint h3 = 0xa54ff53a;
//         public static uint h4 = 0x510e527f;
//         public static uint h5 = 0x9b05688c;
//         public static uint h6 = 0x1f83d9ab;
//         public static uint h7 = 0x5be0cd19;

//         // Initialize array of round constants:
//         // (first 32 bits of the fractional parts of the cube roots of the first 64 primes 2..311):
//         public readonly static uint [] k = new uint[64]
//         { 0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5
//         , 0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174
//         , 0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da
//         , 0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967
//         , 0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85
//         , 0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070
//         , 0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3
//         , 0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
//         };

//         public byte[] arr;
//         public uint[] hash;

//         private uint a;
//         private uint b;
//         private uint c;
//         private uint d;
//         private uint e;
//         private uint f;
//         private uint g;
//         private uint h;

//         // Padding --- Same as in MD5 it seems
//         public void preprocess(IFixedArray<byte> mes) { // Er ikke glad for alle disse typecasts
//             ulong L = (ulong) mes.Length;
//             // I assume we should always pad, even if L = 512.
//             uint K = (uint) (512ul - ((L + 65ul) % 512ul) % 512ul);
//             arr = new byte[L + K + 65ul];
//             for (int i = 0; i < (int)L; i++) {
//                 arr[i] = mes[i];
//             }
//             arr[L] = 1;
//             for (uint i = ((uint)L + 1u); i < (arr.Length - 64u); i++) {
//                 arr[i] = 0;
//             }
//             for (int i = 0; i < 64; i++) {
//                 // Should encode length of the mes array as the last 64 bits of the array in big endian style
//                 arr[i] = (byte) (L & 1);
//                 L = L >> 1;
//             }
//         }

//         public void SHA256(IFixedArray<byte> mes) {
//             preprocess(mes);
//             // Do stuff med arr.
//             uint[] w = new uint[64]; // could zero out but not necessary?
//             for (int i = 0; i < arr.Length; i += 512) {
//                 for (int j = 0; j < 16; j++) {
//                     uint curr = 0;
//                     for (int k = 0; k < 32; k++) {
//                         curr += arr[i+k];
//                         curr = curr << 1;
//                     }
//                     w[j] = curr;
//                 }
//                 uint s0 = 0; uint s1 = 0;
//                 for (int j = 16; j < 64; j++) {
//                     s0 = rightrotate(w[j-15],  7) ^ rightrotate(w[j-15], 18) ^ (w[j-15] >>  3);
//                     s1 = rightrotate(w[j-15], 17) ^ rightrotate(w[j-15], 19) ^ (w[j- 2] >> 10);
//                     w[j] = w[j-16] + s0 + w[j-7] + s1;
//                 }

//                 // a = h0;
//                 // b = h1;
//                 // c = h2;
//                 // d = h3;
//                 // e = h4;
//                 // f = h5;
//                 // g = h6;
//                 // h = h7;

//                 for (int j = 0; j < 64; j++) {
//                     s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
//                     uint ch = (e & f) ^ ((~e) & g);
//                     uint temp1 = h + s1 + ch + k[j] + w[j];
//                     s0 = rightrotate(a, 2) ^ rightrotate(a, 13) ^ rightrotate(a, 22);
//                     uint maj = (a & b) ^ (a & c) ^ (b & c);
//                     uint temp2 = s0 + maj;

//                     h = g;
//                     g = f;
//                     f = e;
//                     e = d + temp1;
//                     d = c;
//                     c = b;
//                     b = a;
//                     a = temp1 + temp2;
//                 }

//                 h0 = h0 + a;
//                 h1 = h1 + b;
//                 h2 = h2 + c;
//                 h3 = h3 + d;
//                 h4 = h4 + e;
//                 h5 = h5 + f;
//                 h6 = h6 + g;
//                 h7 = h7 + h;
//             }

//             hash = new uint[DIGEST_SIZE] {h0, h1, h2, h3, h4, h5, h6, h7}; // Big Endian
//         }
//     }
// }

// // Left-rotate  : (original << bits) | (original >> (32 - bits))
// // Right-rotate : (original >> bits) | (original << (32 - bits))
