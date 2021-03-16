using System;
using SME;

namespace AES
{
    public static class AESConfig {
        public const int BLOCK_SIZE = 16;
        public const int BLOCK_SIZE_BITS = 128;
        public const int KEY_128 = 16;
        public const int KEY_192 = 24;
        public const int KEY_256 = 32;
    }

    public interface IMessage : IBus {
        [InitialValue(false)]
        bool Valid { get; set; }

        [FixedArrayLength()]
        IFixedArray<byte> Message { get; set; }
    }


    class naive : SimpleProcess {
        [InputBus]
        public IMessage Message;

        [OutputBus]
        public IDigest Digest = Scope.CreateBus<IDigest>();

        protected override void OnTick() {
        }

    }
}
