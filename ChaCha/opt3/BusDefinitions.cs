using SME;

using static opt3.config;

namespace opt3 {
    public interface IState : IBus {
        [InitialValue(false)]
        bool ValidSeed { get; set; }
        [InitialValue(false)]
        bool ValidT { get; set; }
        uint Nonce0   { get; set; }
        uint Nonce1   { get; set; }
        uint Nonce2   { get; set; }
        [FixedArrayLength(8)]
        IFixedArray<uint> Key { get; set; }
        [FixedArrayLength(TEXT_SIZE)]
        IFixedArray<byte> Text { get; set; }
    }

    public interface IState2 : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> State { get; set; }
        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> StateO { get; set; }
        [FixedArrayLength(TEXT_SIZE)]
        IFixedArray<byte> Text { get; set; }
    }

    public interface IStream : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
        [FixedArrayLength(TEXT_SIZE)]
        IFixedArray<byte> Values { get; set; }
    }

    public interface axi_r : IBus {
        [InitialValue(false)]
        bool ready { get; set; }
    }
}
