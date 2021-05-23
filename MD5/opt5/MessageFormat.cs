using System;
using SME;
using static opt5.Statics;

namespace opt5
{
    [ClockedProcess]
    class MessageFormat : SimpleProcess {
        [InputBus] public IMessage Message;
        [OutputBus] public axi_r axi_mes = Scope.CreateBus<axi_r>();

        [OutputBus] public IPadded paddedBuffer = Scope.CreateBus<IPadded>();
        [InputBus] public axi_r axi_pad;

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            // if the process is ready and the data-transfer is valid
            if (was_ready && Message.Valid) {
                        Console.WriteLine("message");
                preprocess(Message.Message);
                paddedBuffer.Valid = was_valid = true;
            } else {
                // if we are not valid or the
                paddedBuffer.Valid = was_valid = was_valid && !axi_pad.Ready;
            }
            axi_mes.Ready = was_ready = !was_valid;
        }

        public void preprocess(IFixedArray<byte> mes)
        {
            // the amount of padding 448 mod 512, only applies to the last block
            for (int i = 0; i < MAX_BUFFER_SIZE; i++) {
                paddedBuffer.buffer[i] = mes[i];
            }

            if (Message.Last)
            {
                paddedBuffer.Last = true;
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
        [InputBus] public IPadded paddedBuffer;
        [OutputBus] public axi_r axi_pad = Scope.CreateBus<axi_r>();

        [OutputBus] public IRound Out = Scope.CreateBus<IRound>();
        [InputBus] public axi_r axi_out;

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && paddedBuffer.Valid) {
                fetchBlock(paddedBuffer.buffer);
                Out.Last = paddedBuffer.Last;
                Out.Valid = was_valid = true;
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.Ready;
            }

            axi_pad.Ready = was_ready = !was_valid;
        }

        private void fetchBlock(IFixedArray<byte> buff) {
			for (int j=0; j<61;j+=4) {
				Out.buffer[j>>2]=(((uint) buff[(j+3)]) <<24 ) |
						    (((uint) buff[(j+2)]) <<16 ) |
						    (((uint) buff[(j+1)]) <<8 ) |
						    (((uint) buff[(j)]) ) ;
			}
        }

    }
}
