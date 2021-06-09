using System;
using SME;
using static opt1.config;

namespace opt1 {
    [ClockedProcess]
    public class Round11 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IStream Out = Scope.CreateBus<IStream>();
        [InputBus] public axi_r axi_out;

        private byte[] res = new byte[TEXT_SIZE];
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | (x >> (32 - k)));
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }

        private void toByteArray() {
            for(int i=0; i < 61; i+=4){
                Out.Values[i] = (byte)(In.Text[i] ^ ((In.State[i>>2] >> 24) & 0xff));
                Out.Values[i+1] = (byte)((In.Text[i+1] ^ (In.State[i>>2] >> 16) & 0xff));
                Out.Values[i+2] = (byte)((In.Text[i+2] ^ (In.State[i>>2] >> 8) & 0xff));
                Out.Values[i+3] = (byte)((In.Text[i+3] ^(In.State[i>>2]) & 0xff));
            }
        }

        bool was_valid = false;
        bool was_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                toByteArray();
                Out.Valid = was_valid = true;
            Console.WriteLine($"last, {was_ready}, {was_valid}");
            } else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }

    }

}
