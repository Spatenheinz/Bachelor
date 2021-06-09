using System.Collections.Generic;

namespace AES2
{
    public static class AESConfig {
        public const int BLOCK_SIZE_BITS = 128;
        public const int BLOCK_SIZE = BLOCK_SIZE_BITS >> 3;
        public const int BLOCK_SIZE_UINT = BLOCK_SIZE_BITS >> 5;
        public const int N_KEY_128 = 4;
        public const int NR = 11;
        public const int ROUND_SIZE_128 = N_KEY_128 * (NR);
    }
}
