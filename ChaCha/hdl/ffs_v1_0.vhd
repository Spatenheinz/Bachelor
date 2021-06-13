library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity ffs_v1_0 is
	generic (
		-- Users to add parameters here

		-- User parameters ends
		-- Do not modify the parameters beyond this line


		-- Parameters of Axi Slave Bus Interface S00_AXI
		C_S00_AXI_DATA_WIDTH	: integer	:= 32;
		C_S00_AXI_ADDR_WIDTH	: integer	:= 8
	);
	port (
		-- Users to add ports here
        IState_ValidSeed: out STD_LOGIC;
        IState_ValidT: out STD_LOGIC;
        IState_Nonce0: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Nonce1: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Nonce2: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key0: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key1: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key2: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key3: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key4: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key5: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key6: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key7: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Text0: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text1: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text2: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text3: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text4: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text5: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text6: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text7: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text8: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text9: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text10: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text11: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text12: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text13: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text14: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text15: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text16: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text17: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text18: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text19: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text20: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text21: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text22: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text23: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text24: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text25: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text26: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text27: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text28: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text29: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text30: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text31: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text32: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text33: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text34: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text35: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text36: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text37: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text38: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text39: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text40: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text41: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text42: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text43: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text44: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text45: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text46: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text47: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text48: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text49: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text50: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text51: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text52: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text53: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text54: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text55: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text56: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text57: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text58: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text59: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text60: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text61: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text62: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text63: out STD_LOGIC_VECTOR(7 downto 0);

        -- Top-level bus axi_r signals
        axi_r_1_ready: in STD_LOGIC;

        -- Top-level bus axi_r signals
        axi_r_0_ready: out STD_LOGIC;

        -- Top-level bus IStream signals
        IStream_Valid: in STD_LOGIC;
        IStream_Values0: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values1: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values2: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values3: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values4: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values5: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values6: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values7: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values8: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values9: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values10: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values11: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values12: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values13: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values14: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values15: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values16: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values17: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values18: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values19: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values20: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values21: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values22: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values23: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values24: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values25: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values26: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values27: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values28: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values29: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values30: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values31: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values32: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values33: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values34: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values35: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values36: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values37: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values38: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values39: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values40: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values41: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values42: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values43: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values44: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values45: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values46: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values47: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values48: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values49: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values50: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values51: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values52: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values53: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values54: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values55: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values56: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values57: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values58: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values59: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values60: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values61: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values62: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values63: in STD_LOGIC_VECTOR(7 downto 0);

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
end ffs_v1_0;

architecture arch_imp of ffs_v1_0 is

	-- component declaration
	component ffs_v1_0_S00_AXI is
		generic (
		C_S_AXI_DATA_WIDTH	: integer	:= 32;
		C_S_AXI_ADDR_WIDTH	: integer	:= 8
		);
		port (
		        IState_ValidSeed: out STD_LOGIC;
        IState_ValidT: out STD_LOGIC;
        IState_Nonce0: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Nonce1: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Nonce2: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key0: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key1: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key2: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key3: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key4: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key5: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key6: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Key7: out STD_LOGIC_VECTOR(31 downto 0);
        IState_Text0: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text1: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text2: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text3: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text4: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text5: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text6: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text7: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text8: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text9: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text10: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text11: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text12: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text13: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text14: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text15: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text16: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text17: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text18: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text19: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text20: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text21: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text22: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text23: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text24: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text25: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text26: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text27: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text28: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text29: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text30: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text31: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text32: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text33: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text34: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text35: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text36: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text37: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text38: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text39: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text40: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text41: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text42: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text43: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text44: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text45: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text46: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text47: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text48: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text49: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text50: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text51: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text52: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text53: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text54: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text55: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text56: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text57: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text58: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text59: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text60: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text61: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text62: out STD_LOGIC_VECTOR(7 downto 0);
        IState_Text63: out STD_LOGIC_VECTOR(7 downto 0);

        -- Top-level bus axi_r signals
        axi_r_1_ready: in STD_LOGIC;

        -- Top-level bus axi_r signals
        axi_r_0_ready: out STD_LOGIC;

        -- Top-level bus IStream signals
        IStream_Valid: in STD_LOGIC;
        IStream_Values0: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values1: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values2: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values3: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values4: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values5: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values6: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values7: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values8: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values9: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values10: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values11: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values12: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values13: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values14: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values15: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values16: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values17: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values18: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values19: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values20: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values21: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values22: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values23: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values24: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values25: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values26: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values27: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values28: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values29: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values30: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values31: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values32: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values33: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values34: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values35: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values36: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values37: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values38: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values39: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values40: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values41: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values42: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values43: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values44: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values45: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values46: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values47: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values48: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values49: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values50: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values51: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values52: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values53: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values54: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values55: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values56: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values57: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values58: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values59: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values60: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values61: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values62: in STD_LOGIC_VECTOR(7 downto 0);
        IStream_Values63: in STD_LOGIC_VECTOR(7 downto 0);

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
	end component ffs_v1_0_S00_AXI;

begin

-- Instantiation of Axi Bus Interface S00_AXI
ffs_v1_0_S00_AXI_inst : ffs_v1_0_S00_AXI
	generic map (
		C_S_AXI_DATA_WIDTH	=> C_S00_AXI_DATA_WIDTH,
		C_S_AXI_ADDR_WIDTH	=> C_S00_AXI_ADDR_WIDTH
	)
	port map (
	IState_ValidSeed  =>  IState_ValidSeed,
 IState_ValidT   =>  IState_ValidT,
 IState_Nonce0 =>  IState_Nonce0,
 IState_Nonce1 =>  IState_Nonce1,
 IState_Nonce2 =>  IState_Nonce2,
 IState_Key0   =>  IState_Key0,
 IState_Key1   =>  IState_Key1,
 IState_Key2   =>  IState_Key2,
 IState_Key3   =>  IState_Key3,
 IState_Key4   =>  IState_Key4,
 IState_Key5   =>  IState_Key5,
 IState_Key6   =>  IState_Key6,
 IState_Key7   =>  IState_Key7,
 IState_Text0  =>  IState_Text0,
 IState_Text1  =>  IState_Text1,
 IState_Text2  =>  IState_Text2,
 IState_Text3  =>  IState_Text3,
 IState_Text4  =>  IState_Text4,
 IState_Text5  =>  IState_Text5,
 IState_Text6  =>  IState_Text6,
 IState_Text7  =>  IState_Text7,
 IState_Text8  =>  IState_Text8,
 IState_Text9  =>  IState_Text9,
 IState_Text10 =>  IState_Text10,
 IState_Text11 =>  IState_Text11,
 IState_Text12 =>  IState_Text12,
 IState_Text13 =>  IState_Text13,
 IState_Text14 =>  IState_Text14,
 IState_Text15 =>  IState_Text15,
 IState_Text16 =>  IState_Text16,
 IState_Text17 =>  IState_Text17,
 IState_Text18 =>  IState_Text18,
 IState_Text19 =>  IState_Text19,
 IState_Text20 =>  IState_Text20,
 IState_Text21 =>  IState_Text21,
 IState_Text22 =>  IState_Text22,
 IState_Text23 =>  IState_Text23,
 IState_Text24 =>  IState_Text24,
 IState_Text25 =>  IState_Text25,
 IState_Text26 =>  IState_Text26,
 IState_Text27 =>  IState_Text27,
 IState_Text28 =>  IState_Text28,
 IState_Text29 =>  IState_Text29,
 IState_Text30 =>  IState_Text30,
 IState_Text31 =>  IState_Text31,
 IState_Text32 =>  IState_Text32,
 IState_Text33 =>  IState_Text33,
 IState_Text34 =>  IState_Text34,
 IState_Text35 =>  IState_Text35,
 IState_Text36 =>  IState_Text36,
 IState_Text37 =>  IState_Text37,
 IState_Text38 =>  IState_Text38,
 IState_Text39 =>  IState_Text39,
 IState_Text40 =>  IState_Text40,
 IState_Text41 =>  IState_Text41,
 IState_Text42 =>  IState_Text42,
 IState_Text43 =>  IState_Text43,
 IState_Text44 =>  IState_Text44,
 IState_Text45 =>  IState_Text45,
 IState_Text46 =>  IState_Text46,
 IState_Text47 =>  IState_Text47,
 IState_Text48 =>  IState_Text48,
 IState_Text49 =>  IState_Text49,
 IState_Text50 =>  IState_Text50,
 IState_Text51 =>  IState_Text51,
 IState_Text52 =>  IState_Text52,
 IState_Text53 =>  IState_Text53,
 IState_Text54 =>  IState_Text54,
 IState_Text55 =>  IState_Text55,
 IState_Text56 =>  IState_Text56,
 IState_Text57 =>  IState_Text57,
 IState_Text58 =>  IState_Text58,
 IState_Text59 =>  IState_Text59,
 IState_Text60 =>  IState_Text60,
 IState_Text61 =>  IState_Text61,
 IState_Text62 =>  IState_Text62,
 IState_Text63 =>  IState_Text63,

 axi_r_1_ready => axi_r_1_ready,

 axi_r_0_ready => axi_r_0_ready,

 IStream_Valid    => IStream_Valid,
 IStream_Values0  => IStream_Values0,
 IStream_Values1  => IStream_Values1,
 IStream_Values2  => IStream_Values2,
 IStream_Values3  => IStream_Values3,
 IStream_Values4  => IStream_Values4,
 IStream_Values5  => IStream_Values5,
 IStream_Values6  => IStream_Values6,
 IStream_Values7  => IStream_Values7,
 IStream_Values8  => IStream_Values8,
 IStream_Values9  => IStream_Values9,
 IStream_Values10 => IStream_Values10,
 IStream_Values11 => IStream_Values11,
 IStream_Values12 => IStream_Values12,
 IStream_Values13 => IStream_Values13,
 IStream_Values14 => IStream_Values14,
 IStream_Values15 => IStream_Values15,
 IStream_Values16 => IStream_Values16,
 IStream_Values17 => IStream_Values17,
 IStream_Values18 => IStream_Values18,
 IStream_Values19 => IStream_Values19,
 IStream_Values20 => IStream_Values20,
 IStream_Values21 => IStream_Values21,
 IStream_Values22 => IStream_Values22,
 IStream_Values23 => IStream_Values23,
 IStream_Values24 => IStream_Values24,
 IStream_Values25 => IStream_Values25,
 IStream_Values26 => IStream_Values26,
 IStream_Values27 => IStream_Values27,
 IStream_Values28 => IStream_Values28,
 IStream_Values29 => IStream_Values29,
 IStream_Values30 => IStream_Values30,
 IStream_Values31 => IStream_Values31,
 IStream_Values32 => IStream_Values32,
 IStream_Values33 => IStream_Values33,
 IStream_Values34 => IStream_Values34,
 IStream_Values35 => IStream_Values35,
 IStream_Values36 => IStream_Values36,
 IStream_Values37 => IStream_Values37,
 IStream_Values38 => IStream_Values38,
 IStream_Values39 => IStream_Values39,
 IStream_Values40 => IStream_Values40,
 IStream_Values41 => IStream_Values41,
 IStream_Values42 => IStream_Values42,
 IStream_Values43 => IStream_Values43,
 IStream_Values44 => IStream_Values44,
 IStream_Values45 => IStream_Values45,
 IStream_Values46 => IStream_Values46,
 IStream_Values47 => IStream_Values47,
 IStream_Values48 => IStream_Values48,
 IStream_Values49 => IStream_Values49,
 IStream_Values50 => IStream_Values50,
 IStream_Values51 => IStream_Values51,
 IStream_Values52 => IStream_Values52,
 IStream_Values53 => IStream_Values53,
 IStream_Values54 => IStream_Values54,
 IStream_Values55 => IStream_Values55,
 IStream_Values56 => IStream_Values56,
 IStream_Values57 => IStream_Values57,
 IStream_Values58 => IStream_Values58,
 IStream_Values59 => IStream_Values59,
 IStream_Values60 => IStream_Values60,
 IStream_Values61 => IStream_Values61,
 IStream_Values62 => IStream_Values62,
 IStream_Values63 => IStream_Values63,
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
