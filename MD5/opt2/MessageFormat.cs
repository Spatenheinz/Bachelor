using SME;
using static opt2.MD5Config;
using System;

namespace opt2
{
    [ClockedProcess]
    class MessageFormat : SimpleProcess {
        [InputBus]
        public IMessage Message;
        [OutputBus] public axi_r axi_Message = Scope.CreateBus<axi_r>();

        [OutputBus]
        public IPadded paddedBuffer = Scope.CreateBus<IPadded>();

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && Message.Valid) {
                preprocess(Message.Message);
                paddedBuffer.Valid = was_valid = true;
                paddedBuffer.Head = Message.Head;
            Console.WriteLine($"foramtter: {was_valid}, {was_ready}");
            }
            Console.WriteLine($"foramtter: {was_valid}, {was_ready}");
            axi_Message.Ready = was_ready = !was_valid;
        }

        public void preprocess(IFixedArray<byte> mes)
        {
            // the amount of padding 448 mod 512, only applies to the last block
            for (int i = 0; i < MAX_BUFFER_SIZE; i++) {
                paddedBuffer.buffer[i] = mes[i];
            }

            if (Message.Last)
            {
                if (!Message.Set) { paddedBuffer.buffer[Message.BufferSize] = 0x80; }
                ulong fullSize = (ulong)(Message.MessageSize << 3);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 8] = (byte)(fullSize >> 0 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 7] = (byte)(fullSize >> 8 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 6] = (byte)(fullSize >> 16 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 5] = (byte)(fullSize >> 24 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 4] = (byte)(fullSize >> 32 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 3] = (byte)(fullSize >> 40 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 2] = (byte)(fullSize >> 48 & 0x00000000000000ff);
                paddedBuffer.buffer[MAX_BUFFER_SIZE - 1] = (byte)(fullSize >> 56 & 0x00000000000000ff);
            }
            else if (Message.Set) {
                paddedBuffer.buffer[Message.BufferSize] = 0x80;
            }
        }
    }
    [ClockedProcess]
    class FormatConverter : SimpleProcess {
        [InputBus]
        public IPadded paddedBuffer;

        [OutputBus]
        public IBlock block = Scope.CreateBus<IBlock>();

        protected override void OnTick() {
            if (paddedBuffer.Valid) {
                fetchBlock(paddedBuffer.buffer);
                block.Valid = true;
                block.Head = paddedBuffer.Head;
                Console.WriteLine("ok");
            }
        }

        private void fetchBlock(IFixedArray<byte> buff) {
			for (int j=0; j<61;j+=4) {
				block.buffer[j>>2]=(((uint) buff[(j+3)]) <<24 ) |
						    (((uint) buff[(j+2)]) <<16 ) |
						    (((uint) buff[(j+1)]) <<8 ) |
						    (((uint) buff[(j)]) ) ;
			}
        }

    }
}
