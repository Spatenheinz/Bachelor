using SME;

namespace SHA
{
    public interface IMessage : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [FixedArrayLength(64)]
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

        [FixedArrayLength(8)] // sæt i config
        IFixedArray<uint> Digest { get; set; }
    }
}
