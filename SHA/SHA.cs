using System;
using SME;
using static SHA.SHAConfig;

namespace SHA
{
    [ClockedProcess]
    class SHA : SimpleProcess {
        [InputBus] public IMessage Message;
        [OutputBus] public Iaxis_o axi_Message = Scope.CreateBus<Iaxis_o>();

        [OutputBus] public IDigest Digest = Scope.CreateBus<IDigest>();
        [InputBus] public Iaxis_o axi_Digest;

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (Message.Valid) {
                if (Message.Head) {
                    a = READH0; b = READH1; c = READH2; d = READH3; e = READH4; f = READH5; g = READH6; h = READH7;
                }
                calculateSHA(Message.Message);
                if (Message.Last) {
                    Digest.Digest[0] = H0;
                    Digest.Digest[1] = H1;
                    Digest.Digest[2] = H2;
                    Digest.Digest[3] = H3;
                    Digest.Digest[4] = H4;
                    Digest.Digest[5] = H5;
                    Digest.Digest[6] = H6;
                    Digest.Digest[7] = H7;
                    Digest.Valid = was_valid = true;
                }
            }
            else {
                Digest.Valid = was_valid = was_valid && !axi_Digest.Ready;
            }
            axi_Message.Ready = was_ready = !was_valid;
        }

        private readonly uint READH0 = 0x6a09e667;
        private readonly uint READH1 = 0xbb67ae85;
        private readonly uint READH2 = 0x3c6ef372;
        private readonly uint READH3 = 0xa54ff53a;
        private readonly uint READH4 = 0x510e527f;
        private readonly uint READH5 = 0x9b05688c;
        private readonly uint READH6 = 0x1f83d9ab;
        private readonly uint READH7 = 0x5be0cd19;
        private uint H0 = 0x6a09e667;
        private uint H1 = 0xbb67ae85;
        private uint H2 = 0x3c6ef372;
        private uint H3 = 0xa54ff53a;
        private uint H4 = 0x510e527f;
        private uint H5 = 0x9b05688c;
        private uint H6 = 0x1f83d9ab;
        private uint H7 = 0x5be0cd19;


        public readonly static uint [] k = new uint[64]
        {   0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5
          , 0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174
          , 0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da
          , 0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967
          , 0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85
          , 0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070
          , 0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3
          , 0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
        };

        private uint a;
        private uint b;
        private uint c;
        private uint d;
        private uint e;
        private uint f;
        private uint g;
        private uint h;


        // This works as the temporary buffer in which we store each of the 32bit
        // words in the 512 bit chunk
        private uint[] blockD = new uint[64]; // 16 for the message, 48 for SHA256 calcs.
        private byte[] workingBuffer = new byte[MAX_BUFFER_SIZE];

        // The main function to calculate MD
        public void calculateSHA(IFixedArray<byte> mes)
        {
            preprocess(mes);
            // string str = "";
            // for (int j = 0; j<MAX_BUFFER_SIZE; j++) {
            //     str += workingBuffer[j].ToString("X2");
            // }
            // Console.WriteLine("workingBuffer: " + str);
            fetchBlock(workingBuffer);
            // str = "";
            // for (int j = 0; j<64; j++) {
            //     str += workingBuffer[j].ToString("X2");
            // }
            // Console.WriteLine("blockD: " + str);
            processBlock();
        }

        // Padding er forkert? Den fejler når beskeden bliver over 64chars=512bits lang. Hvorfor?
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
                // Big-Endian
                workingBuffer[MAX_BUFFER_SIZE - 1] = (byte)(fullSize >>  0 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 2] = (byte)(fullSize >>  8 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 3] = (byte)(fullSize >> 16 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 4] = (byte)(fullSize >> 24 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 5] = (byte)(fullSize >> 32 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 6] = (byte)(fullSize >> 40 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 7] = (byte)(fullSize >> 48 & 0x00000000000000ff);
                workingBuffer[MAX_BUFFER_SIZE - 8] = (byte)(fullSize >> 56 & 0x00000000000000ff);
                // string str = "";
                // for (int j = 0; j<MAX_BUFFER_SIZE; j++) {
                //     str += workingBuffer[j].ToString("X2");
                // }
                // Console.WriteLine("Padding?: " + str);

            }
            else if (Message.Set) {
                workingBuffer[Message.BufferSize] = 0x80;
            }
        }

        #region Digest calculation
        // will be called 16 times.
        private void fetchBlock(byte[] buff) {
            for (int j=0; j<61;j+=4) {
                blockD[j>>2]=(((uint) buff[j+3])) |
                    (((uint) buff[j+2]) <<  8)    |
                    (((uint) buff[j+1]) << 16)    |
                    (((uint) buff[j] << 24));
                // Console.WriteLine($"blockD[j>>2]: {blockD[j>>2].ToString("X8")}");
            }
        }

        // the loop in the algorithm, might be interesting to unfold the loop as
        // RFC explains it and see which is faster
        private void processBlock() {
            // Use blockD. 512bit message in 16 * 32bit integers. = w[64]
            uint s0 = 0; uint s1 = 0; uint ch = 0; uint temp1 = 0; uint temp2 = 0; uint maj = 0;
            for (int j = 16; j < 64; j++) {
                s0 = rightrotate(blockD[j-15],  7) ^ rightrotate(blockD[j-15], 18) ^ (blockD[j-15] >>  3);
                s1 = rightrotate(blockD[j- 2], 17) ^ rightrotate(blockD[j- 2], 19) ^ (blockD[j- 2] >> 10);
                blockD[j] = blockD[j-16] + s0 + blockD[j-7] + s1;
                // Console.WriteLine($"s0:{s0.ToString("X8")} s1:{s1.ToString("X8")}");
            }

            a = H0; b = H1; c = H2; d = H3; e = H4; f = H5; g = H6; h = H7;

            for (int j = 0; j < 64; j++) {
                s1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
                ch = (e & f) ^ ((~e) & g);
                temp1 = h + s1 + ch + k[j] + blockD[j];
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
                // Console.WriteLine($"a:{a.ToString("X8")} b:{b.ToString("X8")} c:{c.ToString("X8")} d:{d.ToString("X8")} e:{e.ToString("X8")} f:{f.ToString("X8")} g:{g.ToString("X8")} h:{h.ToString("X8")}");
            }

            // Console.WriteLine($"H0 = {READH0.ToString("X8")} + {a.ToString("X8")} = {(READH0+a).ToString("X8")}");
            H0 = H0 + a;
            H1 = H1 + b;
            H2 = H2 + c;
            H3 = H3 + d;
            H4 = H4 + e;
            H5 = H5 + f;
            H6 = H6 + g;
            H7 = H7 + h;
        }
        #endregion

        #region bitwise operators

        public uint rightrotate(uint x, int bits) {
            // Right rotate: https://stackoverflow.com/questions/812022/c-sharp-bitwise-rotate-left-and-rotate-right
            return (x >> bits) | (x << (32 - bits));
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
