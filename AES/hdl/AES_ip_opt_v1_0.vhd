library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity AES_ip_opt_v1_0 is
	generic (
		-- Users to add parameters here

		-- User parameters ends
		-- Do not modify the parameters beyond this line


		-- Parameters of Axi Slave Bus Interface S00_AXI
		C_S00_AXI_DATA_WIDTH	: integer	:= 32;
		C_S00_AXI_ADDR_WIDTH	: integer	:= 6
	);
	port (
		-- Users to add ports here
		IPlainText_ValidKey: out STD_LOGIC;
        IPlainText_ValidBlock: out STD_LOGIC;
        IPlainText_block0: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block1: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block2: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block3: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block4: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block5: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block6: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block7: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block8: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block9: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block10: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block11: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block12: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block13: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block14: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block15: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key0: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key1: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key2: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key3: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key4: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key5: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key6: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key7: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key8: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key9: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key10: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key11: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key12: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key13: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key14: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key15: out STD_LOGIC_VECTOR(7 downto 0);

        -- Top-level bus axi_r signals
        axi_r_1_ready: in STD_LOGIC;

        -- Top-level bus axi_r signals
        axi_r_0_ready: out STD_LOGIC;

        -- Top-level bus ICipher signals
        ICipher_ValidBlock: in STD_LOGIC;
        ICipher_block0: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block1: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block2: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block3: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block4: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block5: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block6: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block7: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block8: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block9: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block10: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block11: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block12: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block13: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block14: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block15: in STD_LOGIC_VECTOR(7 downto 0);

		-- User ports ends
		-- Do not modify the ports beyond this line


		-- Ports of Axi Slave Bus Interface S00_AXI
		s00_axi_aclk	: in std_logic;
		s00_axi_aresetn	: in std_logic;
		s00_axi_awaddr	: in std_logic_vector(C_S00_AXI_ADDR_WIDTH-1 downto 0);
		s00_axi_awprot	: in std_logic_vector(2 downto 0);
		s00_axi_awvalid	: in std_logic;
		s00_axi_awready	: out std_logic;
		s00_axi_wdata	: in std_logic_vector(C_S00_AXI_DATA_WIDTH-1 downto 0);
		s00_axi_wstrb	: in std_logic_vector((C_S00_AXI_DATA_WIDTH/8)-1 downto 0);
		s00_axi_wvalid	: in std_logic;
		s00_axi_wready	: out std_logic;
		s00_axi_bresp	: out std_logic_vector(1 downto 0);
		s00_axi_bvalid	: out std_logic;
		s00_axi_bready	: in std_logic;
		s00_axi_araddr	: in std_logic_vector(C_S00_AXI_ADDR_WIDTH-1 downto 0);
		s00_axi_arprot	: in std_logic_vector(2 downto 0);
		s00_axi_arvalid	: in std_logic;
		s00_axi_arready	: out std_logic;
		s00_axi_rdata	: out std_logic_vector(C_S00_AXI_DATA_WIDTH-1 downto 0);
		s00_axi_rresp	: out std_logic_vector(1 downto 0);
		s00_axi_rvalid	: out std_logic;
		s00_axi_rready	: in std_logic
	);
end AES_ip_opt_v1_0;

architecture arch_imp of AES_ip_opt_v1_0 is

	-- component declaration
	component AES_ip_opt_v1_0_S00_AXI is
		generic (
		C_S_AXI_DATA_WIDTH	: integer	:= 32;
		C_S_AXI_ADDR_WIDTH	: integer	:= 6
		);
		port (
		        IPlainText_ValidKey: out STD_LOGIC;
		        IPlainText_ValidBlock: out STD_LOGIC;
        IPlainText_block0: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block1: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block2: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block3: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block4: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block5: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block6: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block7: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block8: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block9: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block10: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block11: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block12: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block13: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block14: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_block15: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key0: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key1: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key2: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key3: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key4: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key5: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key6: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key7: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key8: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key9: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key10: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key11: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key12: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key13: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key14: out STD_LOGIC_VECTOR(7 downto 0);
        IPlainText_Key15: out STD_LOGIC_VECTOR(7 downto 0);

        -- Top-level bus axi_r signals
        axi_r_1_ready: in STD_LOGIC;

        -- Top-level bus axi_r signals
        axi_r_0_ready: out STD_LOGIC;

        -- Top-level bus ICipher signals
        ICipher_ValidBlock: in STD_LOGIC;
        ICipher_block0: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block1: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block2: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block3: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block4: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block5: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block6: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block7: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block8: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block9: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block10: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block11: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block12: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block13: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block14: in STD_LOGIC_VECTOR(7 downto 0);
        ICipher_block15: in STD_LOGIC_VECTOR(7 downto 0);

		S_AXI_ACLK	: in std_logic;
		S_AXI_ARESETN	: in std_logic;
		S_AXI_AWADDR	: in std_logic_vector(C_S_AXI_ADDR_WIDTH-1 downto 0);
		S_AXI_AWPROT	: in std_logic_vector(2 downto 0);
		S_AXI_AWVALID	: in std_logic;
		S_AXI_AWREADY	: out std_logic;
		S_AXI_WDATA	: in std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
		S_AXI_WSTRB	: in std_logic_vector((C_S_AXI_DATA_WIDTH/8)-1 downto 0);
		S_AXI_WVALID	: in std_logic;
		S_AXI_WREADY	: out std_logic;
		S_AXI_BRESP	: out std_logic_vector(1 downto 0);
		S_AXI_BVALID	: out std_logic;
		S_AXI_BREADY	: in std_logic;
		S_AXI_ARADDR	: in std_logic_vector(C_S_AXI_ADDR_WIDTH-1 downto 0);
		S_AXI_ARPROT	: in std_logic_vector(2 downto 0);
		S_AXI_ARVALID	: in std_logic;
		S_AXI_ARREADY	: out std_logic;
		S_AXI_RDATA	: out std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
		S_AXI_RRESP	: out std_logic_vector(1 downto 0);
		S_AXI_RVALID	: out std_logic;
		S_AXI_RREADY	: in std_logic
		);
	end component AES_ip_opt_v1_0_S00_AXI;

begin

-- Instantiation of Axi Bus Interface S00_AXI
AES_ip_opt_v1_0_S00_AXI_inst : AES_ip_opt_v1_0_S00_AXI
	generic map (
		C_S_AXI_DATA_WIDTH	=> C_S00_AXI_DATA_WIDTH,
		C_S_AXI_ADDR_WIDTH	=> C_S00_AXI_ADDR_WIDTH
	)
	port map (
	    IPlainText_ValidKey   => IPlainText_ValidKey,
        IPlainText_ValidBlock => IPlainText_ValidBlock,
        IPlainText_block0     => IPlainText_block0,
        IPlainText_block1     => IPlainText_block1,
        IPlainText_block2     => IPlainText_block2,
        IPlainText_block3     => IPlainText_block3,
        IPlainText_block4     => IPlainText_block4,
        IPlainText_block5     => IPlainText_block5,
        IPlainText_block6     => IPlainText_block6,
        IPlainText_block7     => IPlainText_block7,
        IPlainText_block8     => IPlainText_block8,
        IPlainText_block9     => IPlainText_block9,
        IPlainText_block10    => IPlainText_block10,
        IPlainText_block11    => IPlainText_block11,
        IPlainText_block12    => IPlainText_block12,
        IPlainText_block13    => IPlainText_block13,
        IPlainText_block14    => IPlainText_block14,
        IPlainText_block15    => IPlainText_block15,
        IPlainText_Key0       => IPlainText_Key0,
        IPlainText_Key1       => IPlainText_Key1,
        IPlainText_Key2       => IPlainText_Key2,
        IPlainText_Key3       => IPlainText_Key3,
        IPlainText_Key4       => IPlainText_Key4,
        IPlainText_Key5       => IPlainText_Key5,
        IPlainText_Key6       => IPlainText_Key6,
        IPlainText_Key7       => IPlainText_Key7,
        IPlainText_Key8       => IPlainText_Key8,
        IPlainText_Key9       => IPlainText_Key9,
        IPlainText_Key10      => IPlainText_Key10,
        IPlainText_Key11      => IPlainText_Key11,
        IPlainText_Key12      => IPlainText_Key12,
        IPlainText_Key13      => IPlainText_Key13,
        IPlainText_Key14      => IPlainText_Key14,
        IPlainText_Key15      => IPlainText_Key15,

        -- Top-level bus axi_r signals
        axi_r_1_ready         => axi_r_1_ready,

        -- Top-level bus axi_r signals
        axi_r_0_ready         => axi_r_0_ready,

        -- Top-level bus ICipher signals
        ICipher_ValidBlock => ICipher_ValidBlock,
        ICipher_block0     => ICipher_block0,
        ICipher_block1     => ICipher_block1,
        ICipher_block2     => ICipher_block2,
        ICipher_block3     => ICipher_block3,
        ICipher_block4     => ICipher_block4,
        ICipher_block5     => ICipher_block5,
        ICipher_block6     => ICipher_block6,
        ICipher_block7     => ICipher_block7,
        ICipher_block8     => ICipher_block8,
        ICipher_block9     => ICipher_block9,
        ICipher_block10    => ICipher_block10,
        ICipher_block11    => ICipher_block11,
        ICipher_block12    => ICipher_block12,
        ICipher_block13    => ICipher_block13,
        ICipher_block14    => ICipher_block14,
        ICipher_block15    => ICipher_block15,

		S_AXI_ACLK	=> s00_axi_aclk,
		S_AXI_ARESETN	=> s00_axi_aresetn,
		S_AXI_AWADDR	=> s00_axi_awaddr,
		S_AXI_AWPROT	=> s00_axi_awprot,
		S_AXI_AWVALID	=> s00_axi_awvalid,
		S_AXI_AWREADY	=> s00_axi_awready,
		S_AXI_WDATA	=> s00_axi_wdata,
		S_AXI_WSTRB	=> s00_axi_wstrb,
		S_AXI_WVALID	=> s00_axi_wvalid,
		S_AXI_WREADY	=> s00_axi_wready,
		S_AXI_BRESP	=> s00_axi_bresp,
		S_AXI_BVALID	=> s00_axi_bvalid,
		S_AXI_BREADY	=> s00_axi_bready,
		S_AXI_ARADDR	=> s00_axi_araddr,
		S_AXI_ARPROT	=> s00_axi_arprot,
		S_AXI_ARVALID	=> s00_axi_arvalid,
		S_AXI_ARREADY	=> s00_axi_arready,
		S_AXI_RDATA	=> s00_axi_rdata,
		S_AXI_RRESP	=> s00_axi_rresp,
		S_AXI_RVALID	=> s00_axi_rvalid,
		S_AXI_RREADY	=> s00_axi_rready
	);

	-- Add user logic here

	-- User logic ends

end arch_imp;
