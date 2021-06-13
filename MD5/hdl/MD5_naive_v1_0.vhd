library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity MD5_naive_v1_0 is
	generic (
		-- Users to add parameters here

		-- User parameters ends
		-- Do not modify the parameters beyond this line


		-- Parameters of Axi Slave Bus Interface S00_AXI
		C_S00_AXI_DATA_WIDTH	: integer	:= 32;
		C_S00_AXI_ADDR_WIDTH	: integer	:= 7
	);
	port (
		-- Users to add ports here
        IMessage_Valid: out STD_LOGIC;
        IMessage_Message0: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message1: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message2: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message3: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message4: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message5: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message6: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message7: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message8: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message9: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message10: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message11: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message12: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message13: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message14: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message15: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message16: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message17: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message18: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message19: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message20: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message21: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message22: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message23: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message24: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message25: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message26: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message27: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message28: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message29: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message30: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message31: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message32: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message33: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message34: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message35: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message36: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message37: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message38: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message39: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message40: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message41: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message42: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message43: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message44: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message45: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message46: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message47: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message48: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message49: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message50: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message51: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message52: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message53: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message54: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message55: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message56: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message57: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message58: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message59: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message60: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message61: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message62: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message63: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_BufferSize: out STD_LOGIC_VECTOR(31 downto 0);
        IMessage_MessageSize: out STD_LOGIC_VECTOR(31 downto 0);
        IMessage_Last: out STD_LOGIC;
        IMessage_Head: out STD_LOGIC;
        IMessage_Set: out STD_LOGIC;

        -- Top-level bus Iaxis_o signals
        Iaxis_o_1_Ready: out STD_LOGIC;

        -- Top-level bus Iaxis_o signals
        Iaxis_o_0_Ready: in STD_LOGIC;

        -- Top-level bus IDigest signals
        IDigest_Valid: in STD_LOGIC;
        IDigest_Digest0: in STD_LOGIC_VECTOR(31 downto 0);
        IDigest_Digest1: in STD_LOGIC_VECTOR(31 downto 0);
        IDigest_Digest2: in STD_LOGIC_VECTOR(31 downto 0);
        IDigest_Digest3: in STD_LOGIC_VECTOR(31 downto 0);

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
end MD5_naive_v1_0;

architecture arch_imp of MD5_naive_v1_0 is

	-- component declaration
	component MD5_naive_v1_0_S00_AXI is
		generic (
		C_S_AXI_DATA_WIDTH	: integer	:= 32;
		C_S_AXI_ADDR_WIDTH	: integer	:= 7
		);
		port (
		        IMessage_Valid: out STD_LOGIC;
        IMessage_Message0: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message1: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message2: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message3: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message4: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message5: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message6: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message7: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message8: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message9: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message10: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message11: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message12: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message13: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message14: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message15: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message16: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message17: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message18: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message19: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message20: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message21: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message22: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message23: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message24: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message25: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message26: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message27: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message28: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message29: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message30: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message31: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message32: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message33: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message34: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message35: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message36: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message37: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message38: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message39: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message40: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message41: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message42: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message43: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message44: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message45: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message46: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message47: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message48: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message49: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message50: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message51: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message52: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message53: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message54: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message55: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message56: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message57: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message58: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message59: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message60: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message61: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message62: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_Message63: out STD_LOGIC_VECTOR(7 downto 0);
        IMessage_BufferSize: out STD_LOGIC_VECTOR(31 downto 0);
        IMessage_MessageSize: out STD_LOGIC_VECTOR(31 downto 0);
        IMessage_Last: out STD_LOGIC;
        IMessage_Head: out STD_LOGIC;
        IMessage_Set: out STD_LOGIC;

        -- Top-level bus Iaxis_o signals
        Iaxis_o_1_Ready: out STD_LOGIC;

        -- Top-level bus Iaxis_o signals
        Iaxis_o_0_Ready: in STD_LOGIC;

        -- Top-level bus IDigest signals
        IDigest_Valid: in STD_LOGIC;
        IDigest_Digest0: in STD_LOGIC_VECTOR(31 downto 0);
        IDigest_Digest1: in STD_LOGIC_VECTOR(31 downto 0);
        IDigest_Digest2: in STD_LOGIC_VECTOR(31 downto 0);
        IDigest_Digest3: in STD_LOGIC_VECTOR(31 downto 0);

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
	end component MD5_naive_v1_0_S00_AXI;

begin

-- Instantiation of Axi Bus Interface S00_AXI
MD5_naive_v1_0_S00_AXI_inst : MD5_naive_v1_0_S00_AXI
	generic map (
		C_S_AXI_DATA_WIDTH	=> C_S00_AXI_DATA_WIDTH,
		C_S_AXI_ADDR_WIDTH	=> C_S00_AXI_ADDR_WIDTH
	)
	port map (
				        IMessage_Valid => IMessage_Valid,
        IMessage_Message0 => IMessage_Message0,
        IMessage_Message1 => IMessage_Message1,
        IMessage_Message2 => IMessage_Message2,
        IMessage_Message3 => IMessage_Message3,
        IMessage_Message4 => IMessage_Message4,
        IMessage_Message5 => IMessage_Message5,
        IMessage_Message6 => IMessage_Message6,
        IMessage_Message7 => IMessage_Message7,
        IMessage_Message8 => IMessage_Message8,
        IMessage_Message9 => IMessage_Message9,
        IMessage_Message10 => IMessage_Message10,
        IMessage_Message11 => IMessage_Message11,
        IMessage_Message12 => IMessage_Message12,
        IMessage_Message13 => IMessage_Message13,
        IMessage_Message14 => IMessage_Message14,
        IMessage_Message15 => IMessage_Message15,
        IMessage_Message16 => IMessage_Message16,
        IMessage_Message17 => IMessage_Message17,
        IMessage_Message18 => IMessage_Message18,
        IMessage_Message19 => IMessage_Message19,
        IMessage_Message20 => IMessage_Message20,
        IMessage_Message21 => IMessage_Message21,
        IMessage_Message22 => IMessage_Message22,
        IMessage_Message23 => IMessage_Message23,
        IMessage_Message24 => IMessage_Message24,
        IMessage_Message25 => IMessage_Message25,
        IMessage_Message26 => IMessage_Message26,
        IMessage_Message27 => IMessage_Message27,
        IMessage_Message28 => IMessage_Message28,
        IMessage_Message29 => IMessage_Message29,
        IMessage_Message30 => IMessage_Message30,
        IMessage_Message31 => IMessage_Message31,
        IMessage_Message32 => IMessage_Message32,
        IMessage_Message33 => IMessage_Message33,
        IMessage_Message34 => IMessage_Message34,
        IMessage_Message35 => IMessage_Message35,
        IMessage_Message36 => IMessage_Message36,
        IMessage_Message37 => IMessage_Message37,
        IMessage_Message38 => IMessage_Message38,
        IMessage_Message39 => IMessage_Message39,
        IMessage_Message40 => IMessage_Message40,
        IMessage_Message41 => IMessage_Message41,
        IMessage_Message42 => IMessage_Message42,
        IMessage_Message43 => IMessage_Message43,
        IMessage_Message44 => IMessage_Message44,
        IMessage_Message45 => IMessage_Message45,
        IMessage_Message46 => IMessage_Message46,
        IMessage_Message47 => IMessage_Message47,
        IMessage_Message48 => IMessage_Message48,
        IMessage_Message49 => IMessage_Message49,
        IMessage_Message50 => IMessage_Message50,
        IMessage_Message51 => IMessage_Message51,
        IMessage_Message52 => IMessage_Message52,
        IMessage_Message53 => IMessage_Message53,
        IMessage_Message54 => IMessage_Message54,
        IMessage_Message55 => IMessage_Message55,
        IMessage_Message56 => IMessage_Message56,
        IMessage_Message57 => IMessage_Message57,
        IMessage_Message58 => IMessage_Message58,
        IMessage_Message59 => IMessage_Message59,
        IMessage_Message60 => IMessage_Message60,
        IMessage_Message61 => IMessage_Message61,
        IMessage_Message62 => IMessage_Message62,
        IMessage_Message63 => IMessage_Message63,
        IMessage_BufferSize => IMessage_BufferSize,
        IMessage_MessageSize => IMessage_MessageSize,
        IMessage_Last => IMessage_Last,
        IMessage_Head => IMessage_Head,
        IMessage_Set => IMessage_Set,

        Iaxis_o_1_Ready => Iaxis_o_1_Ready,

        -- Top-level bus Iaxis_o signals
        Iaxis_o_0_Ready => Iaxis_o_0_Ready,
        -- Top-level bus IDigest signals
        IDigest_Valid => IDigest_Valid,
        IDigest_Digest0 => IDigest_Digest0,
        IDigest_Digest1 => IDigest_Digest1,
        IDigest_Digest2 => IDigest_Digest2,
        IDigest_Digest3 => IDigest_Digest3,

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
