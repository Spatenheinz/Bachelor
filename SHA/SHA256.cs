using System;
using SME;

namespace SHA
{
    class naive : SimpleProcess {
        [InputBus]
        public IMessage Message;

        [OutputBus]
        public IDigest Digest = Scope.CreateBus<IDigest>();

        protected override void OnTick() {
        }

    }
}
