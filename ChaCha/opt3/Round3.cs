using System;
using SME;
using static opt3.config;

namespace opt3 {
    [ClockedProcess]
    public class RoundXOR : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState2 Out = Scope.CreateBus<IState2>();
        [InputBus] public axi_r axi_out;

        private void toByteArray() {
            for(int i=0; i < 32; i+=4){
                Out.Text[i] = (byte)(In.Text[i] ^ ((In.State[i>>2] >> 24) & 0xff));
                Out.Text[i+1] = (byte)((In.Text[i+1] ^ (In.State[i>>2] >> 16) & 0xff));
                Out.Text[i+2] = (byte)((In.Text[i+2] ^ (In.State[i>>2] >> 8) & 0xff));
                Out.Text[i+3] = (byte)((In.Text[i+3] ^(In.State[i>>2]) & 0xff));
            }
            for(int i=32; i < TEXT_SIZE; i++) {
                Out.Text[i] = In.Text[i];
            }
            for(int i = 0; i < BLOCK_SIZE; i++) {
                Out.State[i] = In.State[i];
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

    [ClockedProcess]
    public class RoundXOR_2 : SimpleProcess {
        [InputBus] public IState2 In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IStream Out = Scope.CreateBus<IStream>();
        [InputBus] public axi_r axi_out;

        private void toByteArray() {
            for(int i=0; i < 32; i++) {
                Out.Values[i] = In.Text[i];
            }
            Out.Values[32] = (byte)( In.Text[32] ^((In.State[8] >> 24) & 0xff));
            Out.Values[33] = (byte)((In.Text[33] ^ (In.State[8] >> 16) & 0xff));
            Out.Values[34] = (byte)((In.Text[34] ^ (In.State[8] >> 8) & 0xff));
            Out.Values[35] = (byte)((In.Text[35] ^ (In.State[8]) & 0xff));

            Out.Values[36] = (byte)( In.Text[36] ^((In.State[9] >> 24) & 0xff));
            Out.Values[37] = (byte)((In.Text[37] ^ (In.State[9] >> 16) & 0xff));
            Out.Values[38] = (byte)((In.Text[38] ^ (In.State[9] >> 8) & 0xff));
            Out.Values[39] = (byte)((In.Text[39] ^ (In.State[9]) & 0xff));

            Out.Values[40] = (byte)( In.Text[40] ^((In.State[10] >> 24) & 0xff));
            Out.Values[41] = (byte)((In.Text[41] ^ (In.State[10] >> 16) & 0xff));
            Out.Values[42] = (byte)((In.Text[42] ^ (In.State[10] >> 8) & 0xff));
            Out.Values[43] = (byte)((In.Text[43] ^ (In.State[10]) & 0xff));

            Out.Values[44] = (byte)( In.Text[44] ^((In.State[11] >> 24) & 0xff));
            Out.Values[45] = (byte)((In.Text[45] ^ (In.State[11] >> 16) & 0xff));
            Out.Values[46] = (byte)((In.Text[46] ^ (In.State[11] >> 8) & 0xff));
            Out.Values[47] = (byte)((In.Text[47] ^ (In.State[11]) & 0xff));

            Out.Values[48] = (byte)( In.Text[48] ^((In.State[12] >> 24) & 0xff));
            Out.Values[49] = (byte)((In.Text[49] ^ (In.State[12] >> 16) & 0xff));
            Out.Values[50] = (byte)((In.Text[50] ^ (In.State[12] >> 8) & 0xff));
            Out.Values[51] = (byte)((In.Text[51] ^ (In.State[12]) & 0xff));

            Out.Values[52] = (byte)( In.Text[52] ^((In.State[13] >> 24) & 0xff));
            Out.Values[53] = (byte)((In.Text[53] ^ (In.State[13] >> 16) & 0xff));
            Out.Values[54] = (byte)((In.Text[54] ^ (In.State[13] >> 8) & 0xff));
            Out.Values[55] = (byte)((In.Text[55] ^ (In.State[13]) & 0xff));

            Out.Values[56] = (byte)( In.Text[56] ^((In.State[14] >> 24) & 0xff));
            Out.Values[57] = (byte)((In.Text[57] ^ (In.State[14] >> 16) & 0xff));
            Out.Values[58] = (byte)((In.Text[58] ^ (In.State[14] >> 8) & 0xff));
            Out.Values[59] = (byte)((In.Text[59] ^ (In.State[14]) & 0xff));

            Out.Values[60] = (byte)( In.Text[60] ^((In.State[15] >> 24) & 0xff));
            Out.Values[61] = (byte)((In.Text[61] ^ (In.State[15] >> 16) & 0xff));
            Out.Values[62] = (byte)((In.Text[62] ^ (In.State[15] >> 8) & 0xff));
            Out.Values[63] = (byte)((In.Text[63] ^ (In.State[15]) & 0xff));
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
