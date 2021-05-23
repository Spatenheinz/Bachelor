using SME;
using static opt4.Statics;

namespace opt4
{
    public interface IMessage : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        // [InitialValue(false)]
        // bool Ready { get; set; }

        [FixedArrayLength(MAX_BUFFER_SIZE)]
        IFixedArray<byte> Message { get; set; }

        int BufferSize { get; set; }
        int MessageSize { get; set; }

        [InitialValue(false)]
        bool Last { get; set; }
        [InitialValue(true)]
        bool Head { get; set; }
        [InitialValue(false)]
        bool Set { get; set; }
    }
// pipeline (optimisation 1)
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

    public interface IRound : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        // [InitialValue(false)]
        // bool Ready { get; set; }

        [InitialValue(false)]
        bool Last {get; set; }

        [FixedArrayLength(BLOCK_SIZE)]
        IFixedArray<uint> buffer { get; set; }

        uint A { get; set; }
        uint B { get; set; }
        uint C { get; set; }
        uint D { get; set; }

    }

    public interface IIV : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        // [InitialValue(false)]
        // bool Ready { get; set;
        [InitialValue(false)]
        bool Final { get; set; }

        uint A { get; set; }
        uint B { get; set; }
        uint C { get; set; }
        uint D { get; set; }
    }

    public interface IEOFFlag : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }
    }
    public interface IInit : IBus {
        [InitialValue(true)]
        bool Valid { get; set; }
    }

    public interface axi_v : IBus
    {
        [InitialValue(false)]
        bool Valid { get; set; }
    }

    public interface axi_r : IBus
    {
        [InitialValue(false)]
        bool Ready { get; set; }
    }
}
