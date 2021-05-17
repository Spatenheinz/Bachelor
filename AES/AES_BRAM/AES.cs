using System;
using SME;
using SME.Components;
using static AES_BRAM.AESConfig;

namespace AES_BRAM
{
    [ClockedProcess]
    class AESe : SimpleProcess {
        [InputBus] public IPlainText PlainText;
        [OutputBus] public axi_r axi_Text = Scope.CreateBus<axi_r>();
        [OutputBus] public ICipher Cipher = Scope.CreateBus<ICipher>();
        [InputBus] public axi_r axi_Cipher;

        // [OutputBus] private readonly SinglePortMemory<uint>.IControl Controller;
        // [InputBus] private readonly SinglePortMemory<uint>.IReadResult RAM_RES;

        // public readonly SinglePortMemory<uint> BRAM;


        private byte[] IV = new byte[BLOCK_SIZE];
        private byte[] state = new byte[BLOCK_SIZE];
        private uint[] expandedKey128 = new uint[ROUND_SIZE_128];

        // public AESe() {
        //     BRAM = new SinglePortMemory<uint>(Tester.Tbox.Length, Tester.Tbox);
        //     Controller = BRAM.Control;
        //     RAM_RES = BRAM.ReadResult;
        // }
        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (PlainText.ValidKey) {
                Expand128(PlainText.Key);
            Console.WriteLine($"proc {was_ready} {was_valid}");
            } else if (PlainText.ValidBlock) {
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    state[i] = PlainText.block[i];
                }
                Encrypt128();
                for(int i = 0; i < BLOCK_SIZE; i++) {
                    Cipher.block[i] = IV[i];
                }
                Cipher.ValidBlock = was_valid = true;
            } else {
                Cipher.ValidBlock = was_valid && !axi_Cipher.ready;
            }
            axi_Text.ready = was_ready = !was_valid;
            Console.WriteLine($"proc {was_ready} {was_valid}");
        }

        private uint SubWord(uint x) {
            return
                   ((uint)S[0xff & (x>> 24)] << 24) |
                   ((uint)S[0xff & (x>> 16)] << 16) |
                   ((uint)S[0xff & (x>> 8)] << 8) |
                   ((uint)S[0xff & x]);
        }

        private void Expand128(IFixedArray<byte> key) {
            for (int i = 0; i < N_KEY_128<<2; i+=4) {
                expandedKey128[i>>2] = ((uint)key[i] << 24) |
                                        ((uint)key[i+1] << 16) |
                                        ((uint)key[i+2] << 8) |
                                        ((uint)key[i+3]);
            }
            for (int i = N_KEY_128; i < ROUND_SIZE_128; i++) {
                uint w = expandedKey128[i-1];
                if (i % N_KEY_128 == 0) {
                    w = SubWord(LeftRotate(w,8)) ^ Round[i / N_KEY_128];
                } else if ( N_KEY_128 > 6 && (i % N_KEY_128) == 4) {
                    w = SubWord(w);
                }
                expandedKey128[i] = expandedKey128[i-N_KEY_128] ^ w;
            }
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | ((x >> (32 - k)) & 0xff));
        }


        private void Encrypt128() {

            uint a0 = (((uint)state[0] << 24) | ((uint)state[1] << 16) | ((uint)state[2] << 8) | (uint)state[3]) ^ expandedKey128[0];
			uint a1 = (((uint)state[4] << 24) | ((uint)state[5] << 16) | ((uint)state[6] << 8) | (uint)state[7]) ^ expandedKey128[1];
			uint a2 = (((uint)state[8] << 24) | ((uint)state[9] << 16) | ((uint)state[10] << 8) | (uint)state[11]) ^ expandedKey128[2];
			uint a3 = (((uint)state[12] << 24) | ((uint)state[13] << 16) | ((uint)state[14] << 8) | (uint)state[15]) ^ expandedKey128[3];
            // Controller.Enabled = true;
            // Console.WriteLine($"k_sch: {expandedKey128[0].ToString("x8")}{expandedKey128[1].ToString("x8")}{expandedKey128[2].ToString("x8")}{expandedKey128[3].ToString("x8")}");
            // Console.WriteLine($"start: {a0.ToString("x8")}{a1.ToString("x8")}{a2.ToString("x8")}{a3.ToString("x8")}");
            /* Round 1 */
			// Console.WriteLine(T0[0]);
			uint b0 = T0[a0 >> 24] ^ T1[(byte)(a1 >> 16)] ^ T2[(byte)(a2 >> 8)] ^ T3[(byte)a3] ^ expandedKey128[4];
			uint b1 = T0[a1 >> 24] ^ T1[(byte)(a2 >> 16)] ^ T2[(byte)(a3 >> 8)] ^ T3[(byte)a0] ^ expandedKey128[5];
			uint b2 = T0[a2 >> 24] ^ T1[(byte)(a3 >> 16)] ^ T2[(byte)(a0 >> 8)] ^ T3[(byte)a1] ^ expandedKey128[6];
			uint b3 = T0[a3 >> 24] ^ T1[(byte)(a0 >> 16)] ^ T2[(byte)(a1 >> 8)] ^ T3[(byte)a2] ^ expandedKey128[7];
			/* Round 2 */
			a0 = T0[b0 >> 24] ^ T1[(byte)(b1 >> 16)] ^ T2[(byte)(b2 >> 8)] ^ T3[(byte)b3] ^ expandedKey128[8];
			a1 = T0[b1 >> 24] ^ T1[(byte)(b2 >> 16)] ^ T2[(byte)(b3 >> 8)] ^ T3[(byte)b0] ^ expandedKey128[9];
			a2 = T0[b2 >> 24] ^ T1[(byte)(b3 >> 16)] ^ T2[(byte)(b0 >> 8)] ^ T3[(byte)b1] ^ expandedKey128[10];
			a3 = T0[b3 >> 24] ^ T1[(byte)(b0 >> 16)] ^ T2[(byte)(b1 >> 8)] ^ T3[(byte)b2] ^ expandedKey128[11];
			/* Round 3 */
			b0 = T0[a0 >> 24] ^ T1[(byte)(a1 >> 16)] ^ T2[(byte)(a2 >> 8)] ^ T3[(byte)a3] ^ expandedKey128[12];
			b1 = T0[a1 >> 24] ^ T1[(byte)(a2 >> 16)] ^ T2[(byte)(a3 >> 8)] ^ T3[(byte)a0] ^ expandedKey128[13];
			b2 = T0[a2 >> 24] ^ T1[(byte)(a3 >> 16)] ^ T2[(byte)(a0 >> 8)] ^ T3[(byte)a1] ^ expandedKey128[14];
			b3 = T0[a3 >> 24] ^ T1[(byte)(a0 >> 16)] ^ T2[(byte)(a1 >> 8)] ^ T3[(byte)a2] ^ expandedKey128[15];
			/* Round 4 */
			a0 = T0[b0 >> 24] ^ T1[(byte)(b1 >> 16)] ^ T2[(byte)(b2 >> 8)] ^ T3[(byte)b3] ^ expandedKey128[16];
			a1 = T0[b1 >> 24] ^ T1[(byte)(b2 >> 16)] ^ T2[(byte)(b3 >> 8)] ^ T3[(byte)b0] ^ expandedKey128[17];
			a2 = T0[b2 >> 24] ^ T1[(byte)(b3 >> 16)] ^ T2[(byte)(b0 >> 8)] ^ T3[(byte)b1] ^ expandedKey128[18];
			a3 = T0[b3 >> 24] ^ T1[(byte)(b0 >> 16)] ^ T2[(byte)(b1 >> 8)] ^ T3[(byte)b2] ^ expandedKey128[19];
			/* Round 5 */
			b0 = T0[a0 >> 24] ^ T1[(byte)(a1 >> 16)] ^ T2[(byte)(a2 >> 8)] ^ T3[(byte)a3] ^ expandedKey128[20];
			b1 = T0[a1 >> 24] ^ T1[(byte)(a2 >> 16)] ^ T2[(byte)(a3 >> 8)] ^ T3[(byte)a0] ^ expandedKey128[21];
			b2 = T0[a2 >> 24] ^ T1[(byte)(a3 >> 16)] ^ T2[(byte)(a0 >> 8)] ^ T3[(byte)a1] ^ expandedKey128[22];
			b3 = T0[a3 >> 24] ^ T1[(byte)(a0 >> 16)] ^ T2[(byte)(a1 >> 8)] ^ T3[(byte)a2] ^ expandedKey128[23];
			/* Round 6 */
			a0 = T0[b0 >> 24] ^ T1[(byte)(b1 >> 16)] ^ T2[(byte)(b2 >> 8)] ^ T3[(byte)b3] ^ expandedKey128[24];
			a1 = T0[b1 >> 24] ^ T1[(byte)(b2 >> 16)] ^ T2[(byte)(b3 >> 8)] ^ T3[(byte)b0] ^ expandedKey128[25];
			a2 = T0[b2 >> 24] ^ T1[(byte)(b3 >> 16)] ^ T2[(byte)(b0 >> 8)] ^ T3[(byte)b1] ^ expandedKey128[26];
			a3 = T0[b3 >> 24] ^ T1[(byte)(b0 >> 16)] ^ T2[(byte)(b1 >> 8)] ^ T3[(byte)b2] ^ expandedKey128[27];
			/* Round 7 */
			b0 = T0[a0 >> 24] ^ T1[(byte)(a1 >> 16)] ^ T2[(byte)(a2 >> 8)] ^ T3[(byte)a3] ^ expandedKey128[28];
			b1 = T0[a1 >> 24] ^ T1[(byte)(a2 >> 16)] ^ T2[(byte)(a3 >> 8)] ^ T3[(byte)a0] ^ expandedKey128[29];
			b2 = T0[a2 >> 24] ^ T1[(byte)(a3 >> 16)] ^ T2[(byte)(a0 >> 8)] ^ T3[(byte)a1] ^ expandedKey128[30];
			b3 = T0[a3 >> 24] ^ T1[(byte)(a0 >> 16)] ^ T2[(byte)(a1 >> 8)] ^ T3[(byte)a2] ^ expandedKey128[31];
			/* Round 8 */
			a0 = T0[b0 >> 24] ^ T1[(byte)(b1 >> 16)] ^ T2[(byte)(b2 >> 8)] ^ T3[(byte)b3] ^ expandedKey128[32];
			a1 = T0[b1 >> 24] ^ T1[(byte)(b2 >> 16)] ^ T2[(byte)(b3 >> 8)] ^ T3[(byte)b0] ^ expandedKey128[33];
			a2 = T0[b2 >> 24] ^ T1[(byte)(b3 >> 16)] ^ T2[(byte)(b0 >> 8)] ^ T3[(byte)b1] ^ expandedKey128[34];
			a3 = T0[b3 >> 24] ^ T1[(byte)(b0 >> 16)] ^ T2[(byte)(b1 >> 8)] ^ T3[(byte)b2] ^ expandedKey128[35];
			/* Round 9 */
			b0 = T0[a0 >> 24] ^ T1[(byte)(a1 >> 16)] ^ T2[(byte)(a2 >> 8)] ^ T3[(byte)a3] ^ expandedKey128[36];
			b1 = T0[a1 >> 24] ^ T1[(byte)(a2 >> 16)] ^ T2[(byte)(a3 >> 8)] ^ T3[(byte)a0] ^ expandedKey128[37];
			b2 = T0[a2 >> 24] ^ T1[(byte)(a3 >> 16)] ^ T2[(byte)(a0 >> 8)] ^ T3[(byte)a1] ^ expandedKey128[38];
			b3 = T0[a3 >> 24] ^ T1[(byte)(a0 >> 16)] ^ T2[(byte)(a1 >> 8)] ^ T3[(byte)a2] ^ expandedKey128[39];

            IV[0] = (byte)(S[b0 >> 24] ^ (byte)(expandedKey128[40] >> 24));
			IV[1] = (byte)(S[(byte)(b1 >> 16)] ^ (byte)(expandedKey128[40] >> 16));
			IV[2] = (byte)(S[(byte)(b2 >> 8)] ^ (byte)(expandedKey128[40] >> 8));
			IV[3] = (byte)(S[(byte)b3] ^ (byte)expandedKey128[40]);

			IV[4] = (byte)(S[b1 >> 24] ^ (byte)(expandedKey128[41] >> 24));
			IV[5] = (byte)(S[(byte)(b2 >> 16)] ^ (byte)(expandedKey128[41] >> 16));
			IV[6] = (byte)(S[(byte)(b3 >> 8)] ^ (byte)(expandedKey128[41] >> 8));
			IV[7] = (byte)(S[(byte)b0] ^ (byte)expandedKey128[41]);

			IV[8] = (byte)(S[b2 >> 24] ^ (byte)(expandedKey128[42] >> 24));
			IV[9] = (byte)(S[(byte)(b3 >> 16)] ^ (byte)(expandedKey128[42] >> 16));
			IV[10] = (byte)(S[(byte)(b0 >> 8)] ^ (byte)(expandedKey128[42] >> 8));
			IV[11] = (byte)(S[(byte)b1] ^ (byte)expandedKey128[42]);

			IV[12] = (byte)(S[b3 >> 24] ^ (byte)(expandedKey128[43] >> 24));
			IV[13] = (byte)(S[(byte)(b0 >> 16)] ^ (byte)(expandedKey128[43] >> 16));
			IV[14] = (byte)(S[(byte)(b1 >> 8)] ^ (byte)(expandedKey128[43] >> 8));
			IV[15] = (byte)(S[(byte)b2] ^ (byte)expandedKey128[43]);
            // Console.Write($"output :");
            // for(int i = 0; i < BLOCK_SIZE; i++) {
            //     Console.Write($"{IV[i].ToString("x2")}");
            // }
            // Console.WriteLine("");
        }

		static readonly byte[] S = new byte[] {
			0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
			0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
			0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
			0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
			0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
			0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
			0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
			0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
			0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
			0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
			0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
			0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
			0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
			0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
			0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
			0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
		};

		static readonly uint[] Round = new uint[] {
			0x00000000, 0x01000000, 0x02000000, 0x04000000, 0x08000000, 0x10000000, 0x20000000, 0x40000000,
			0x80000000, 0x1b000000, 0x36000000, 0x6c000000, 0xd8000000, 0xab000000, 0x4d000000, 0x9a000000,
			0x2f000000
		};
    }
}
