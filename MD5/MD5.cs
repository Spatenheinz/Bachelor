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
            uint a = A, b = B, c = C, d = D;
            for (uint i = 0; i < 64; i++) {
                uint f = 0, g = 0;
                if (i < 16) {
                    f = F(b,c,d);
                    g = i;
                } else if (15 < i && i < 32) {
                    f = G(b,c,d);
                    g = (5 * i + 1) % 16;
                } else if (31 < i && i < 48) {
                    f = H(b, c, d);
                    g = (3 * i + 5) % 16;
                } else if (47 < i && i < 64) {
                    f = I(b, c, d);
                    g = (7 * i) % 16;
                }
                f = f + a + TAB[i] + block[g];
                a = d;
                d = c;
                c = b;
                b = b + LeftRotate(f, ROUND[i]);
            }
            A += a;
            B += b;
            C += c;
            D += d;
        }
        #endregion

        #region bitwise operators
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
