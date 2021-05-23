namespace opt1
{
    [ClockedProcess]
    class Combiner : SimpleProcess {
        [InputBus] public IDigest I;
        [OutputBus] public axi_r axi_I = Scope.CreateBus<axi_r>();


        [InputBus] public axi_r axi_final;
        [OutputBus] public IDigest Final = Scope.CreateBus<IDigest>();
        bool was_valid = false;
        bool was_ready = false;
        uint A = 0x67452301;
        uint B = 0xefcdab89;
        uint C = 0x98badcfe;
        uint D = 0x10325476;
        uint [] H = {0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a,
            0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19};

        protected override void OnTick() {
            if (was_ready && I.Valid) {
                for (int i = 0; i < DIGEST_SIZE; i++) {
                    Final.Digest[i] = H[i] + I.Digest[i];
                }
                Final.Valid = was_valid = true;
            } else {
                Final.Valid = was_valid = was_valid && !axi_final.Ready;
            }
                axi_I.Ready = was_ready = !was_valid;
        }
    }
}
