using System;
using SME;
using SME.Components;
using static AES_BRAM.AESConfig;

namespace AES_BRAM
{
    [ClockedProcess]
    class Round9 : SimpleProcess {
        [InputBus] public IState In;
        [OutputBus] public axi_r axi_in = Scope.CreateBus<axi_r>();
        [OutputBus] public IState Out = Scope.CreateBus<IState>();
        [InputBus] public axi_r axi_out;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT0_1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT0a1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT0a1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT0b1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT0b1;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT0_2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT0a2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT0a2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT0b2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT0b2;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT1_1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT1a1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT1a1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT1b1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT1b1;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT1_2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT1a2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT1a2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT1b2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT1b2;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT2_1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT2a1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT2a1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT2b1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT2b1;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT2_2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT2a2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT2a2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT2b2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT2b2;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT3_1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT3a1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT3a1;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT3b1;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT3b1;

        [Ignore] private readonly TrueDualPortMemory<uint> bramT3_2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT3a2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT3a2;
        [OutputBus] private readonly TrueDualPortMemory<uint>.IControl m_conT3b2;
        [InputBus] private readonly TrueDualPortMemory<uint>.IReadResult m_rrT3b2;

        public Round9() {
            bramT0_1 = new TrueDualPortMemory<uint>(TBOX_SIZE, T0);
            m_conT0a1 = bramT0_1.ControlA;
            m_rrT0a1 = bramT0_1.ReadResultA;
            m_conT0b1 = bramT0_1.ControlB;
            m_rrT0b1 = bramT0_1.ReadResultB;

            bramT0_2 = new TrueDualPortMemory<uint>(TBOX_SIZE, T0);
            m_conT0a2 = bramT0_2.ControlA;
            m_rrT0a2 = bramT0_2.ReadResultA;
            m_conT0b2 = bramT0_2.ControlB;
            m_rrT0b2 = bramT0_2.ReadResultB;

            bramT1_1 = new TrueDualPortMemory<uint>(TBOX_SIZE, T1);
            m_conT1a1 = bramT1_1.ControlA;
            m_rrT1a1 = bramT1_1.ReadResultA;
            m_conT1b1 = bramT1_1.ControlB;
            m_rrT1b1 = bramT1_1.ReadResultB;

            bramT1_2 = new TrueDualPortMemory<uint>(TBOX_SIZE, T1);
            m_conT1a2 = bramT1_2.ControlA;
            m_rrT1a2 = bramT1_2.ReadResultA;
            m_conT1b2 = bramT1_2.ControlB;
            m_rrT1b2 = bramT1_2.ReadResultB;

            bramT2_1 = new TrueDualPortMemory<uint>(TBOX_SIZE, T2);
            m_conT2a1 = bramT2_1.ControlA;
            m_rrT2a1 = bramT2_1.ReadResultA;
            m_conT2b1 = bramT2_1.ControlB;
            m_rrT2b1 = bramT2_1.ReadResultB;

            bramT2_2 = new TrueDualPortMemory<uint>(TBOX_SIZE, T2);
            m_conT2a2 = bramT2_2.ControlA;
            m_rrT2a2 = bramT2_2.ReadResultA;
            m_conT2b2 = bramT2_2.ControlB;
            m_rrT2b2 = bramT2_2.ReadResultB;

            bramT3_1 = new TrueDualPortMemory<uint>(TBOX_SIZE, T3);
            m_conT3a1 = bramT3_1.ControlA;
            m_rrT3a1 = bramT3_1.ReadResultA;
            m_conT3b1 = bramT3_1.ControlB;
            m_rrT3b1 = bramT3_1.ReadResultB;

            bramT3_2 = new TrueDualPortMemory<uint>(TBOX_SIZE, T3);
            m_conT3a2 = bramT3_2.ControlA;
            m_rrT3a2 = bramT3_2.ReadResultA;
            m_conT3b2 = bramT3_2.ControlB;
            m_rrT3b2 = bramT3_2.ReadResultB;
        }
        private uint[] expandedKey128 = new uint[8];

        bool was_valid = false;
        bool was_ready = false;
        bool bram_was_read = false;
        bool bram_ready = false;
        protected override void OnTick() {
            if (was_ready && In.Valid) {
                Expand128();
                readBRAM();
                bram_was_read = true;
            } else if (bram_was_read) {
                bram_ready = true;
                bram_was_read = false;
            } else if (was_ready && bram_ready) {
            Console.WriteLine($"Process 9: r: {was_ready}, v: {was_valid} axi: {axi_out.ready}");
                Encrypt128();
                bram_ready = false;
                Out.Valid = was_valid = true;
            }
            else {
                Out.Valid = was_valid = was_valid && !axi_out.ready;
            }
            axi_in.ready = was_ready = !was_valid;
        }

        private uint SubWord(uint x) {
            return
                   ((uint)S[0xff & (x>> 24)] << 24) |
                   ((uint)S[0xff & (x>> 16)] << 16) |
                   ((uint)S[0xff & (x>> 8)] << 8) |
                   ((uint)S[0xff & x]);
        }

        private void Expand128() {
            for (int i = 0; i < 4; i++) {
                expandedKey128[i] = In.Key[i];
            }
            for (int i = 4; i < 8; i++) {
                uint w = expandedKey128[i-1];
                if (i % N_KEY_128 == 0) {
                    w = SubWord(LeftRotate(w,8)) ^ 0x80000000;
                } else if ( N_KEY_128 > 6 && (i % N_KEY_128) == 4) {
                    w = SubWord(w);
                }
                expandedKey128[i] = expandedKey128[i-N_KEY_128] ^ w;
            }
            for (int i = 0; i < 4; i++) {
                Out.Key[i] = expandedKey128[4+i];
            }
        }
        private uint LeftRotate(uint x, int k) {
            return ((x << k) | ((x >> (32 - k)) & 0xff));
        }

        private void readBRAM() {
            uint a0 = In.Block[0]; uint a1 = In.Block[1];
            uint a2 = In.Block[2]; uint a3 = In.Block[3];
            m_conT0a1.Enabled = m_conT0b1.Enabled = m_conT0a2.Enabled = m_conT0b2.Enabled = true;
            m_conT1a1.Enabled = m_conT1b1.Enabled = m_conT1a2.Enabled = m_conT1b2.Enabled = true;
            m_conT2a1.Enabled = m_conT2b1.Enabled = m_conT2a2.Enabled = m_conT2b2.Enabled = true;
            m_conT3a1.Enabled = m_conT3b1.Enabled = m_conT3a2.Enabled = m_conT3b2.Enabled = true;
            m_conT0a1.Address = (byte)(a0 >> 24); m_conT1a1.Address = (byte)(a1 >> 16); m_conT2a1.Address = (byte)(a2 >> 8); m_conT3a1.Address = (byte)(a3);
            m_conT0b1.Address = (byte)(a1 >> 24); m_conT1b1.Address = (byte)(a2 >> 16); m_conT2b1.Address = (byte)(a3 >> 8); m_conT3b1.Address = (byte)(a0);
            m_conT0a2.Address = (byte)(a2 >> 24); m_conT1a2.Address = (byte)(a3 >> 16); m_conT2a2.Address = (byte)(a0 >> 8); m_conT3a2.Address = (byte)(a1);
            m_conT0b2.Address = (byte)(a3 >> 24); m_conT1b2.Address = (byte)(a0 >> 16); m_conT2b2.Address = (byte)(a1 >> 8); m_conT3b2.Address = (byte)(a2);
        }

        private void Encrypt128() {
            Out.Block[0] = m_rrT0a1.Data ^ m_rrT1a1.Data ^ m_rrT2a1.Data ^ m_rrT3a1.Data ^ expandedKey128[4];
            Out.Block[1] = m_rrT0b1.Data ^ m_rrT1b1.Data ^ m_rrT2b1.Data ^ m_rrT3b1.Data ^ expandedKey128[5];
            Out.Block[2] = m_rrT0a2.Data ^ m_rrT1a2.Data ^ m_rrT2a2.Data ^ m_rrT3a2.Data ^ expandedKey128[6];
            Out.Block[3] = m_rrT0b2.Data ^ m_rrT1b2.Data ^ m_rrT2b2.Data ^ m_rrT3b2.Data ^ expandedKey128[7];
        }

		static readonly byte[] S = new byte[] {
			0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
			0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
			0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
			0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
			0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
			0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
			0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
			0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
			0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
			0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
			0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
			0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
			0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
			0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
			0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
			0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
		};
    }
}
