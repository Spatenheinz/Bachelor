using System;
using SME;
using static MD5.MD5Config;

namespace MD5
{
    class MD5 : SimpleProcess {
        [InputBus]
        public IMessage Message;

        [OutputBus]
        public IDigest Digest = Scope.CreateBus<IDigest>();

        protected override void OnTick() {
            if (Message.Valid) {
                var tmp = calculateMD5(Message.Message, Message.BufferSize);
                for (int i = 0; i < DIGEST_SIZE; i++) {
                    Console.WriteLine(tmp[i].ToString("x8"));
                    Digest.Digest[i] = tmp[i];
                }
                Digest.Valid = true;
            }
        }


        // The 4 32bit parts of the digest.
        private uint A = 0x67452301;
        private uint B = 0xefcdab89;
        private uint C = 0x98badcfe;
        private uint D = 0x10325476;
        private uint AA = 0;
        private uint BB = 0;
        private uint CC = 0;
        private uint DD = 0;

        // This works as the temporary buffer in which we store each of the 32bit
        // words in the 512 bit chunk
        private uint[] block = new uint[16];

        // The main function to calculate MD
        public uint[] calculateMD5(IFixedArray<byte> mes, int size)
        {
            //preprocess
            byte[] msgB = preprocess(mes, size);
            // break up chunks and process.
            uint blocks = (uint)(msgB.Length * 8) >> 5;
            for (uint i = 0; i < blocks >> 4; i++) {
                fetchBlock(msgB, i);
                processBlock();
            }
            //format
            return new[] { reverseByte(A), reverseByte(B), reverseByte(C), reverseByte(D) };
        }

        public byte[] preprocess(IFixedArray<byte> mes, int size)
        {
            // the amount of padding 448 mod 512, only applies to the last block
            uint padding = 0;
            if (Message.Last) {
                int temp = (448 - ((size * 8) % 512));
                Console.WriteLine("its the last round");
                padding = (uint)((temp + 512) % 512);
                if (padding == 0 && Message.Last) padding = 512;
            }
            // the size of the digest buffer
            uint buffSize = (uint)(size + (padding >> 3) + 8);
            // the size of the message
            ulong fullSize = (ulong)(Message.MessageSize << 3);
            //buffer for the working buffer
            byte[] buff = new byte[buffSize];
            //copy over the message to the working buffer
            for (int i = 0; i < size; i++) { buff[i] = (byte)mes[i]; }
            // add 1 to padding
            buff[size] |= 0x80;
            // add the length to the padding
            for (int i = 8; i > 0; i--) {
                buff[buffSize - i] = (byte)(fullSize >> ((8 - i) << 3) & 0x00000000000000ff);
            }
            return buff;
        }

        #region Digest calculation
        // this will move the b block into the smaller buffer block
        // will be called 16 times.
        private void fetchBlock(byte[] buff, uint b) {
			b=b<<6;
			for (uint j=0; j<61;j+=4) {
				block[j>>2]=(((uint) buff[b+(j+3)]) <<24 ) |
						    (((uint) buff[b+(j+2)]) <<16 ) |
						    (((uint) buff[b+(j+1)]) <<8 ) |
						    (((uint) buff[b+(j)]) ) ;
			}
        }
        // the loop in the algorithm, might be interesting to unfold the loop as
        // RFC explains it and see which is faster
        private void processBlock(){
            AA = A; BB = B; CC = C; DD = D;
            // round 1
            FF(ref A, B, C, D, 0, 7, 0); FF(ref D, A, B, C, 1, 12, 1);
            FF(ref C, D, A, B, 2, 17, 2); FF(ref B, C, D, A, 3, 22, 3);

            FF(ref A, B, C, D, 4, 7, 4); FF(ref D, A, B, C, 5, 12, 5);
            FF(ref C, D, A, B, 6, 17, 6); FF(ref B, C, D, A, 7, 22, 7);

            FF(ref A, B, C, D, 8, 7, 8); FF(ref D, A, B, C, 9, 12, 9);
            FF(ref C, D, A, B, 10, 17, 10); FF(ref B, C, D, A, 11, 22, 11);

            FF(ref A, B, C, D, 12, 7, 12); FF(ref D, A, B, C, 13, 12, 13);
            FF(ref C, D, A, B, 14, 17, 14); FF(ref B, C, D, A, 15, 22, 15);
            // round 2
            GG(ref A, B, C, D, 1, 5, 16); GG(ref D, A, B, C, 6, 9, 17);
            GG(ref C, D, A, B, 11, 14, 18); GG(ref B, C, D, A, 0, 20, 19);

            GG(ref A, B, C, D, 5, 5, 20); GG(ref D, A, B, C, 10, 9, 21);
            GG(ref C, D, A, B, 15, 14, 22); GG(ref B, C, D, A, 4, 20, 23);

            GG(ref A, B, C, D, 9, 5, 24); GG(ref D, A, B, C, 14, 9, 25);
            GG(ref C, D, A, B, 3, 14, 26); GG(ref B, C, D, A, 8, 20, 27);

            GG(ref A, B, C, D, 13, 5, 28); GG(ref D, A, B, C, 2, 9, 29);
            GG(ref C, D, A, B, 7, 14, 30); GG(ref B, C, D, A, 12, 20, 31);
            // round 3
            HH(ref A, B, C, D, 5, 4, 32); HH(ref D, A, B, C, 8, 11, 33);
            HH(ref C, D, A, B, 11, 16, 34); HH(ref B, C, D, A, 14, 23, 35);

            HH(ref A, B, C, D, 1, 4, 36); HH(ref D, A, B, C, 4, 11, 37);
            HH(ref C, D, A, B, 7, 16, 38); HH(ref B, C, D, A, 10, 23, 39);

            HH(ref A, B, C, D, 13, 4, 40); HH(ref D, A, B, C, 0, 11, 41);
            HH(ref C, D, A, B, 3, 16, 42); HH(ref B, C, D, A, 6, 23, 43);
            HH(ref A, B, C, D, 9, 4, 44); HH(ref D, A, B, C, 12, 11, 45);
            HH(ref C, D, A, B, 15, 16, 46); HH(ref B, C, D, A, 2, 23, 47);
            // round 4
            II(ref A, B, C, D, 0, 6, 48); II(ref D, A, B, C, 7, 10, 49);
            II(ref C, D, A, B, 14, 15, 50); II(ref B, C, D, A, 5, 21, 51);

            II(ref A, B, C, D, 12, 6, 52); II(ref D, A, B, C, 3, 10, 53);
            II(ref C, D, A, B, 10, 15, 54); II(ref B, C, D, A, 1, 21, 55);

            II(ref A, B, C, D, 8, 6, 56); II(ref D, A, B, C, 15, 10, 57);
            II(ref C, D, A, B, 6, 15, 58); II(ref B, C, D, A, 13, 21, 59);

            II(ref A, B, C, D, 4, 6, 60); II(ref D, A, B, C, 11, 10, 61);
            II(ref C, D, A, B, 2, 15, 62); II(ref B, C, D, A, 9, 21, 63);

            A += AA;
            B += BB;
            C += CC;
            D += DD;
        }
        #endregion

        #region bitwise operators
        private void FF(ref uint a, uint b, uint c, uint d, int k, int s, int i) {
            a = b + (LeftRotate(a + F(b, c, d) + block[k] + TAB[i], s));
        }
        private void GG(ref uint a, uint b, uint c, uint d, int k, int s, int i) {
            a = b + (LeftRotate(a + G(b, c, d) + block[k] + TAB[i], s));
        }
        private void HH(ref uint a, uint b, uint c, uint d, int k, int s, int i) {
            a = b + (LeftRotate(a + H(b, c, d) + block[k] + TAB[i], s));
        }
        private void II(ref uint a, uint b, uint c, uint d, int k, int s, int i) {
            a = b + (LeftRotate(a + I(b, c, d) + block[k] + TAB[i], s));
        }

        private uint F(uint x, uint y, uint z) {
            return (x & y) | ((~x) & z);
        }
        private uint G(uint x, uint y, uint z) {
            return (x & z) | (y & (~z));
        }
        private uint H(uint x, uint y, uint z) {
            return x ^ y ^ z;
        }
        private uint I(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int c) {
            return ((x << c) | (x >> (32 - c)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
        #endregion
    }
}
