using SME;

using static ChaCha.config;

namespace ChaCha {
    public interface IState : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [InitialValue(true)]
        bool Head { get; set; }
        byte Size { get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> Key { get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> Text { get; set; }

        uint Nonce0   { get; set; }
        uint Nonce1   { get; set; }
        uint Nonce2   { get; set; }

    }

    public interface IStream : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(config.BLOCK_SIZE)]
        IFixedArray<byte> Values { get; set; }
    }

}
