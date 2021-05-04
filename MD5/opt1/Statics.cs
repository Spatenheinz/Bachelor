namespace opt1
{
    public static class MD5Config {
        public const int MAX_BUFFER_SIZE = 64;
        public const int DIGEST_SIZE = 4;
        public const int BLOCK_SIZE = 16;
        // This is the s array, which we can optimize since it has a lot of repetition.
    }
}
