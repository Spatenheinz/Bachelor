using SME;
using static SHA.SHAConfig;

namespace SHA
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

    public interface Iaxis_o : IBus {
        [InitialValue(false)]
        bool Ready { get; set; }
    }


    // public interface IMessage : IBus {
    //     [InitialValue(false)]
    //     bool Valid { get; set; }

    //     [FixedArrayLength(64)]
    //     IFixedArray<byte> Message { get; set; }

    //     int BufferSize { get; set; }
    //     int MessageSize { get; set; }

    //     [InitialValue(true)]
    //     bool Last { get; set; }
    //     [InitialValue(true)]
    //     bool Head { get; set; }
    //     [InitialValue(false)]
    //     bool Set { get; set; }
    // }


    // public interface IDigest : IBus {
    //     [InitialValue(false)]
    //     bool Valid { get; set; }

    //     [FixedArrayLength(DIGEST_SIZE)] // sæt i config
    //     IFixedArray<uint> Digest { get; set; }
    // }
}
