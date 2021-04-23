using System;
using SME;
using static MD5.MD5Config;

namespace MD5
{
    [ClockedProcess]
    class MD5 : SimpleProcess {
        [InputBus] public IMessage Message;
        [OutputBus] public Iaxis_o in_o = Scope.CreateBus<Iaxis_o>();

        [OutputBus] public IDigest Digest = Scope.CreateBus<IDigest>();
        [InputBus] public Iaxis_o out_o;

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && Message.Valid) {
                if (Message.Head) {
                    A = READA; B = READB; C = READC; D = READD;
                }
                calculateMD5(Message.Message);
                if (Message.Last) {
                    Digest.Digest[0] = reverseByte(A);
                    Digest.Digest[1] = reverseByte(B);
                    Digest.Digest[2] = reverseByte(C);
                    Digest.Digest[3] = reverseByte(D);
                    Digest.Valid = was_valid = true;
                }
            } else {
                Digest.Valid = was_valid = was_valid && !out_o.Ready;
            }
            in_o.Ready = was_ready = !was_valid;
        }

        public readonly static int [] ROUND = new int[64]
            { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22
            , 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20
            , 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23
            , 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
            };
        // This is the K array which store sthe sines of integers part
        public readonly static uint [] TAB = new uint[64]
            { 0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee
			, 0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501
            , 0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be
            , 0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821
			, 0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa
            , 0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8
            , 0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed
			, 0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a
            , 0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c
            , 0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70
            , 0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05
			, 0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665
            , 0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039
            , 0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1
            , 0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1
			, 0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
            };
        // The 4 32bit parts of the digest.
        private readonly uint READA = 0x67452301;
        private readonly uint READB = 0xefcdab89;
        private readonly uint READC = 0x98badcfe;
        private readonly uint READD = 0x10325476;
        private uint A;
        private uint B;
        private uint C;
        private uint D;

        // This works as the temporary buffer in which we store each of the 32bit
        // words in the 512 bit chunk
        private uint[] blockD = new uint[16];
        private byte[] workingBuffer = new byte[MAX_BUFFER_SIZE];

        // The main function to calculate MD
        public void calculateMD5(IFixedArray<byte> mes)
        {
            preprocess(mes);
                fetchBlock(workingBuffer);
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
        private void fetchBlock(byte[] buff) {
			for (int j=0; j<61;j+=4) {
				blockD[j>>2]=(((uint) buff[j]) ) |
                             (((uint) buff[j+1]) <<8 ) |
						    (((uint) buff[j+2]) <<16 ) |
						    (((uint) buff[j+3]) <<24 );
			}
        }
        // the loop in the algorithm, might be interesting to unfold the loop as
        // RFC explains it and see which is faster
        private void processBlock(){
            uint AA = A, BB = B, CC = C, DD = D;
            // round 1
            FF(ref A, B, C, D, 0, 7, 0);    FF(ref D, A, B, C, 1, 12, 1);
            FF(ref C, D, A, B, 2, 17, 2);   FF(ref B, C, D, A, 3, 22, 3);

            FF(ref A, B, C, D, 4, 7, 4);    FF(ref D, A, B, C, 5, 12, 5);
            FF(ref C, D, A, B, 6, 17, 6);   FF(ref B, C, D, A, 7, 22, 7);

            FF(ref A, B, C, D, 8, 7, 8);    FF(ref D, A, B, C, 9, 12, 9);
            FF(ref C, D, A, B, 10, 17, 10); FF(ref B, C, D, A, 11, 22, 11);

            FF(ref A, B, C, D, 12, 7, 12);  FF(ref D, A, B, C, 13, 12, 13);
            FF(ref C, D, A, B, 14, 17, 14); FF(ref B, C, D, A, 15, 22, 15);
            //round 2
            GG(ref A, B, C, D, 1, 5, 16);   GG(ref D, A, B, C, 6, 9, 17);
            GG(ref C, D, A, B, 11, 14, 18); GG(ref B, C, D, A, 0, 20, 19);

            GG(ref A, B, C, D, 5, 5, 20);   GG(ref D, A, B, C, 10, 9, 21);
            GG(ref C, D, A, B, 15, 14, 22); GG(ref B, C, D, A, 4, 20, 23);

            GG(ref A, B, C, D, 9, 5, 24);   GG(ref D, A, B, C, 14, 9, 25);
            GG(ref C, D, A, B, 3, 14, 26);  GG(ref B, C, D, A, 8, 20, 27);

            GG(ref A, B, C, D, 13, 5, 28);  GG(ref D, A, B, C, 2, 9, 29);
            GG(ref C, D, A, B, 7, 14, 30);  GG(ref B, C, D, A, 12, 20, 31);
            //round 3
            HH(ref A, B, C, D, 5, 4, 32);   HH(ref D, A, B, C, 8, 11, 33);
            HH(ref C, D, A, B, 11, 16, 34); HH(ref B, C, D, A, 14, 23, 35);

            HH(ref A, B, C, D, 1, 4, 36);   HH(ref D, A, B, C, 4, 11, 37);
            HH(ref C, D, A, B, 7, 16, 38);  HH(ref B, C, D, A, 10, 23, 39);

            HH(ref A, B, C, D, 13, 4, 40);  HH(ref D, A, B, C, 0, 11, 41);
            HH(ref C, D, A, B, 3, 16, 42);  HH(ref B, C, D, A, 6, 23, 43);

            HH(ref A, B, C, D, 9, 4, 44);   HH(ref D, A, B, C, 12, 11, 45);
            HH(ref C, D, A, B, 15, 16, 46); HH(ref B, C, D, A, 2, 23, 47);
            //round 4
            II(ref A, B, C, D, 0, 6, 48);   II(ref D, A, B, C, 7, 10, 49);
            II(ref C, D, A, B, 14, 15, 50); II(ref B, C, D, A, 5, 21, 51);

            II(ref A, B, C, D, 12, 6, 52);  II(ref D, A, B, C, 3, 10, 53);
            II(ref C, D, A, B, 10, 15, 54); II(ref B, C, D, A, 1, 21, 55);

            II(ref A, B, C, D, 8, 6, 56);   II(ref D, A, B, C, 15, 10, 57);
            II(ref C, D, A, B, 6, 15, 58);  II(ref B, C, D, A, 13, 21, 59);

            II(ref A, B, C, D, 4, 6, 60);   II(ref D, A, B, C, 11, 10, 61);
            II(ref C, D, A, B, 2, 15, 62);  II(ref B, C, D, A, 9, 21, 63);

            A += AA;
            B += BB;
            C += CC;
            D += DD;
        }
        #endregion

        #region bitwise operators
        private void FF(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + F(bb, cc, dd) + blockD[k] + TAB[i], s));
        }
        private void GG(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + G(bb, cc, dd) + blockD[k] + TAB[i], s));
        }
        private void HH(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + H(bb, cc, dd) + blockD[k] + TAB[i], s));
        }
        private void II(ref uint aa, uint bb, uint cc, uint dd, int k, int s, int i) {
            aa = bb + (LeftRotate(aa + Ia(bb, cc, dd) + blockD[k] + TAB[i], s));
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
        private uint Ia(uint x, uint y, uint z) {
            return y ^ (x | (~z));
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
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
