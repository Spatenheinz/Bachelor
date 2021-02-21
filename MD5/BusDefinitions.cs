using SME;
using static MD5.MD5Config;

namespace MD5
{
    public interface IMessage : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [FixedArrayLength(MAX_BUFFER_SIZE)]
        IFixedArray<byte> Message { get; set; }

        int BufferSize { get; set; }
        int MessageSize { get; set; }

        [InitialValue(true)]
        bool Last { get; set; }
        [InitialValue(true)]
        bool Head { get; set; }
        [InitialValue(false)]
        bool Set { get; set; }


    }

    public interface IDigest : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [FixedArrayLength(DIGEST_SIZE)]
        IFixedArray<uint> Digest { get; set; }
    }
}
