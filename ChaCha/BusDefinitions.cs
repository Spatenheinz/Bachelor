using SME;

using static ChaCha.config;

namespace ChaCha {
    public interface IState : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [InitialValue(true)]
        bool Head { get; set; }
        uint Size { get; set; }
        uint Nonce0   { get; set; }
        uint Nonce1   { get; set; }
        uint Nonce2   { get; set; }
        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> Key { get; set; }
    // }

    // public interface IText : IBus {
        // [InitialValue(false)]
        // bool Valid { get; set; }
        [FixedArrayLength(TEXT_SIZE)]
        IFixedArray<byte> Text { get; set; }
    }

    public interface IStream : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(TEXT_SIZE)]
        IFixedArray<byte> Values { get; set; }
    }

    // public interface axi_r : IBus {
    //     [InitialValue(false)]
    //     bool ready { get; set; }
    // }
}
