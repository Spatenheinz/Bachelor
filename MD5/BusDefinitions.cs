using SME;
using static MD5.MD5Config;

namespace MD5
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

// pipeline (optimisation 1)
    // public interface IPadded : IBus {
    //     [InitialValue(false)]
    //     bool Valid { get; set; }

    //     [FixedArrayLength(MAX_BUFFER_SIZE)]
    //     IFixedArray<byte> buffer { get; set; }
    // }

    // public interface IBlock : IBus {
    //     [InitialValue(false)]
    //     bool Valid { get; set; }

    //     [FixedArrayLength(BLOCK_SIZE)]
    //     IFixedArray<uint> buffer { get; set; }
    // }

    // public interface IRound : IBus {
    //     [InitialValue(false)]
    //     bool Valid { get; set; }

    //     uint A { get; set; }
    //     uint B { get; set; }
    //     uint C { get; set; }
    //     uint D { get; set; }
    // }
}
