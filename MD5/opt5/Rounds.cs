using System;
using SME;
using static opt5.Statics;

namespace opt5
{

    [ClockedProcess]
    class Combiner : SimpleProcess {
        [InputBus] public IIV I;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();


        [InputBus] public axi_r axi_final;
        [OutputBus] public IIV Final = Scope.CreateBus<IIV>();
        bool was_valid = false;
        bool was_ready = false;
        uint A = 0x67452301;
        uint B = 0xefcdab89;
        uint C = 0x98badcfe;
        uint D = 0x10325476;
        protected override void OnTick() {
            if (was_ready && I.Valid) {
                Final.A = reverseByte(A + I.A);
                Final.B = reverseByte(B + I.B);
                Final.C = reverseByte(C + I.C);
                Final.D = reverseByte(D + I.D);
                Final.Valid = was_valid = true;
            } else {
                Final.Valid = was_valid = was_valid && !axi_final.Ready;
            }
            axi_in.Ready = was_ready = !was_valid;
        }
        private uint reverseByte(uint i) {
            return ((i & 0x000000ff) << 24) |
                (i >> 24) |
                ((i & 0x00ff0000) >> 8) |
                ((i & 0x0000ff00) << 8);
        }
    }
}
