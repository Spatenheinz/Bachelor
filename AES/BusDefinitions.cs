using SME;
using static AES.AESConfig;

namespace AES
{
    public interface IPlainText : IBus {
        [InitialValue(false)]
        bool ValidKey { get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> Key { get; set; }

        [InitialValue(false)]
        bool ValidBlock { get; set; }
        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> block { get; set; }

    }
    public interface ICypher : IBus {
        [InitialValue(false)]
        bool ValidKey { get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> Key { get; set; }

        [InitialValue(false)]
        bool ValidBlock { get; set; }
        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<byte> block { get; set; }

    }
}
