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
                if (Message.Head) {
                    A = READA; B = READB; C = READC; D = READD;
                }
                calculateMD5(Message.Message);
                if (Message.Last) {
                    Digest.Digest[0] = reverseByte(A);
                    Digest.Digest[1] = reverseByte(B);
                    Digest.Digest[2] = reverseByte(C);
                    Digest.Digest[3] = reverseByte(D);
                    Digest.Valid = true;
                }
            }
        }

        // The 4 32bit parts of the digest.
        private readonly uint READA = 0x67452301;
        private readonly uint READB = 0xefcdab89;
        private readonly uint READC = 0x98badcfe;
        private readonly uint READD = 0x10325476;
        private uint A = 0x67452301;
        private uint B = 0xefcdab89;
        private uint C = 0x98badcfe;
        private uint D = 0x10325476;

        // This works as the temporary buffer in which we store each of the 32bit
        // words in the 512 bit chunk
        private uint[] block = new uint[16];
        private byte[] workingBuffer = new byte[MAX_BUFFER_SIZE];

        // The main function to calculate MD
        public void calculateMD5(IFixedArray<byte> mes)
        {
            preprocess(mes);
            // for (int i = 0; i < MAX_BUFFER_SIZE; i++){
            //     Console.WriteLine(workingBuffer[i]);
            // }
                // Console.WriteLine();
                // break up chunks and process.
                fetchBlock(workingBuffer, 0);
            processBlock();
        }

        public void preprocess(IFixedArray<byte> mes)
        {
            // the amount of padding 448 mod 512, only applies to the last block
            for (int i = 0; i < MAX_BUFFER_SIZE; i++) {
                workingBuffer[i] = mes[i];
            }

            if (Message.Last)
            {
                if (!Message.Set) { workingBuffer[Message.BufferSize] = 0x80; }
                ulong fullSize = (ulong)(Message.MessageSize << 3);
                workingBuffer[MAX_BUFFER_SIZE - 8] = (byte)(fullSize >> 0 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 7] = (byte)(fullSize >> 8 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 6] = (byte)(fullSize >> 16 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 5] = (byte)(fullSize >> 24 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 4] = (byte)(fullSize >> 32 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 3] = (byte)(fullSize >> 40 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 2] = (byte)(fullSize >> 48 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 1] = (byte)(fullSize >> 56 & 0x00000000000000ff);
            }
            else if (Message.Set) {
                workingBuffer[Message.BufferSize] = 0x80;
            }
        }

        #region Digest calculation
        // this will move the b block into the smaller buffer block
        // will be called 16 times.
        private void fetchBlock(byte[] buff, int b) {
			b=b<<6;
			for (int j=0; j<61;j+=4) {
				block[j>>2]=(((uint) buff[b+(j+3)]) <<24 ) |
						    (((uint) buff[b+(j+2)]) <<16 ) |
						    (((uint) buff[b+(j+1)]) <<8 ) |
						    (((uint) buff[b+(j)]) ) ;
			}
        }
        // the loop in the algorithm, might be interesting to unfold the loop as
        // RFC explains it and see which is faster
        private void processBlock(){
            uint AA = A, BB = B, CC = C, DD = D;
            // round 1
            A = FF( A, B, C, D, 0, 7, 0); D = FF( D, A, B, C, 1, 12, 1);
            C = FF( C, D, A, B, 2, 17, 2); B = FF( B, C, D, A, 3, 22, 3);

            A = FF( A, B, C, D, 4, 7, 4); D = FF( D, A, B, C, 5, 12, 5);
            C = FF( C, D, A, B, 6, 17, 6); B = FF( B, C, D, A, 7, 22, 7);

            A = FF( A, B, C, D, 8, 7, 8); D = FF( D, A, B, C, 9, 12, 9);
            C = FF( C, D, A, B, 10, 17, 10); B = FF( B, C, D, A, 11, 22, 11);

            A = FF( A, B, C, D, 12, 7, 12); D = FF( D, A, B, C, 13, 12, 13);
            C = FF( C, D, A, B, 14, 17, 14); B = FF( B, C, D, A, 15, 22, 15);
            // round 2
            A = GG( A, B, C, D, 1, 5, 16); D = GG( D, A, B, C, 6, 9, 17);
            C = GG( C, D, A, B, 11, 14, 18); B = GG( B, C, D, A, 0, 20, 19);

            A = GG( A, B, C, D, 5, 5, 20); D = GG( D, A, B, C, 10, 9, 21);
            C = GG( C, D, A, B, 15, 14, 22); B = GG( B, C, D, A, 4, 20, 23);

            A = GG( A, B, C, D, 9, 5, 24); D = GG( D, A, B, C, 14, 9, 25);
            C = GG( C, D, A, B, 3, 14, 26); B = GG( B, C, D, A, 8, 20, 27);

            A = GG( A, B, C, D, 13, 5, 28); D = GG( D, A, B, C, 2, 9, 29);
            C = GG( C, D, A, B, 7, 14, 30); B = GG( B, C, D, A, 12, 20, 31);
            // round 3
            A = HH( A, B, C, D, 5, 4, 32); D = HH( D, A, B, C, 8, 11, 33);
            C = HH( C, D, A, B, 11, 16, 34); B = HH( B, C, D, A, 14, 23, 35);

            A = HH( A, B, C, D, 1, 4, 36); D = HH( D, A, B, C, 4, 11, 37);
            C = HH( C, D, A, B, 7, 16, 38); B = HH( B, C, D, A, 10, 23, 39);

            A = HH( A, B, C, D, 13, 4, 40); D = HH( D, A, B, C, 0, 11, 41);
            C = HH( C, D, A, B, 3, 16, 42); B = HH( B, C, D, A, 6, 23, 43);

            A = HH( A, B, C, D, 9, 4, 44); D = HH( D, A, B, C, 12, 11, 45);
            C = HH( C, D, A, B, 15, 16, 46); B = HH( B, C, D, A, 2, 23, 47);
            // round 4
            A = II( A, B, C, D, 0, 6, 48); D = II( D, A, B, C, 7, 10, 49);
            C = II( C, D, A, B, 14, 15, 50); B = II( B, C, D, A, 5, 21, 51);

            A = II( A, B, C, D, 12, 6, 52); D = II( D, A, B, C, 3, 10, 53);
            C = II( C, D, A, B, 10, 15, 54); B = II( B, C, D, A, 1, 21, 55);

            A = II( A, B, C, D, 8, 6, 56); D = II( D, A, B, C, 15, 10, 57);
            C = II( C, D, A, B, 6, 15, 58); B = II( B, C, D, A, 13, 21, 59);

            A = II( A, B, C, D, 4, 6, 60); D = II( D, A, B, C, 11, 10, 61);
            C = II( C, D, A, B, 2, 15, 62); B = II( B, C, D, A, 9, 21, 63);

            A += AA;
            B += BB;
            C += CC;
            D += DD;
        }
        #endregion

        #region bitwise operators
        private uint FF( uint a, uint b, uint c, uint d, int k, int s, int i) {
            return a = b + (LeftRotate(a + F(b, c, d) + block[k] + TAB[i], s));
        }
        private uint GG( uint a, uint b, uint c, uint d, int k, int s, int i) {
            return a = b + (LeftRotate(a + G(b, c, d) + block[k] + TAB[i], s));
        }
        private uint HH( uint a, uint b, uint c, uint d, int k, int s, int i) {
            return a = b + (LeftRotate(a + H(b, c, d) + block[k] + TAB[i], s));
        }
        private uint II( uint a, uint b, uint c, uint d, int k, int s, int i) {
            return a = b + (LeftRotate(a + I(b, c, d) + block[k] + TAB[i], s));
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
