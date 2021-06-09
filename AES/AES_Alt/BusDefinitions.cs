using SME;
using static AES_Alt.AESConfig;

namespace AES_Alt
{
    public interface IPlainText : IBus {
        [InitialValue(false)]
        bool ValidKey { get; set; }
        [InitialValue(false)]
        bool ValidBlock { get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> block { get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> Key { get; set; }
    }
    public interface ICipher : IBus {

        [InitialValue(false)]
        bool ValidBlock { get; set; }
        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> block { get; set; }

    }

    // public interface IInter : IBus {
    //     // [InitialValue(false)]
    //     // bool ValidKey { get; set; }

    //     // [FixedArrayLength(BLOCK_SIZE)]
    //     // IFixedArray<byte> Key { get; set; }

    //     [InitialValue(false)]
    //     bool ValidBlock { get; set; }
    //     [FixedArrayLength(BLOCK_SIZE)]
    //     IFixedArray<byte> block { get; set; }

    // }

    public interface axi_r : IBus {
        [InitialValue(false)]
        bool ready { get; set; }
    }
}
