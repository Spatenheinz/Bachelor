using SME;
using static opt1.Statics;

namespace opt1
{
    // axis_inp_i
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

    // axis_res_i
    public interface IDigest : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [FixedArrayLength(DIGEST_SIZE)]
        IFixedArray<uint> Digest { get; set; }
    }

    public interface IRound : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [InitialValue(false)]
        bool Last {get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> buffer { get; set; }

        [FixedArrayLength(DIGEST_SIZE)]
        IFixedArray<uint> Digest { get; set; }
    }

    public interface IPadded : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        // [InitialValue(false)]
        // bool Ready { get; set; }
        [InitialValue(false)]
        bool Last { get; set; }

        [FixedArrayLength(MAX_BUFFER_SIZE)]
        IFixedArray<byte> buffer { get; set; }
    }

    public interface axi_r : IBus {
        [InitialValue(false)]
        bool Ready { get; set; }
    }
}
