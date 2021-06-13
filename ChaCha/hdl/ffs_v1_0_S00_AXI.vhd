library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity ffs_v1_0_S00_AXI is
	generic (
		-- Users to add parameters here

		-- User parameters ends
		-- Do not modify the parameters beyond this line

		-- Width of S_AXI data bus
		C_S_AXI_DATA_WIDTH	: integer	:= 32;
		-- Width of S_AXI address bus
		C_S_AXI_ADDR_WIDTH	: integer	:= 8
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

		-- Global Clock Signal
		S_AXI_ACLK	: in std_logic;
		-- Global Reset Signal. This Signal is Active LOW
		S_AXI_ARESETN	: in std_logic;
		-- Write address (issued by master, acceped by Slave)
		S_AXI_AWADDR	: in std_logic_vector(C_S_AXI_ADDR_WIDTH-1 downto 0);
		-- Write channel Protection type. This signal indicates the
    		-- privilege and security level of the transaction, and whether
    		-- the transaction is a data access or an instruction access.
		S_AXI_AWPROT	: in std_logic_vector(2 downto 0);
		-- Write address valid. This signal indicates that the master signaling
    		-- valid write address and control information.
		S_AXI_AWVALID	: in std_logic;
		-- Write address ready. This signal indicates that the slave is ready
    		-- to accept an address and associated control signals.
		S_AXI_AWREADY	: out std_logic;
		-- Write data (issued by master, acceped by Slave) 
		S_AXI_WDATA	: in std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
		-- Write strobes. This signal indicates which byte lanes hold
    		-- valid data. There is one write strobe bit for each eight
    		-- bits of the write data bus.    
		S_AXI_WSTRB	: in std_logic_vector((C_S_AXI_DATA_WIDTH/8)-1 downto 0);
		-- Write valid. This signal indicates that valid write
    		-- data and strobes are available.
		S_AXI_WVALID	: in std_logic;
		-- Write ready. This signal indicates that the slave
    		-- can accept the write data.
		S_AXI_WREADY	: out std_logic;
		-- Write response. This signal indicates the status
    		-- of the write transaction.
		S_AXI_BRESP	: out std_logic_vector(1 downto 0);
		-- Write response valid. This signal indicates that the channel
    		-- is signaling a valid write response.
		S_AXI_BVALID	: out std_logic;
		-- Response ready. This signal indicates that the master
    		-- can accept a write response.
		S_AXI_BREADY	: in std_logic;
		-- Read address (issued by master, acceped by Slave)
		S_AXI_ARADDR	: in std_logic_vector(C_S_AXI_ADDR_WIDTH-1 downto 0);
		-- Protection type. This signal indicates the privilege
    		-- and security level of the transaction, and whether the
    		-- transaction is a data access or an instruction access.
		S_AXI_ARPROT	: in std_logic_vector(2 downto 0);
		-- Read address valid. This signal indicates that the channel
    		-- is signaling valid read address and control information.
		S_AXI_ARVALID	: in std_logic;
		-- Read address ready. This signal indicates that the slave is
    		-- ready to accept an address and associated control signals.
		S_AXI_ARREADY	: out std_logic;
		-- Read data (issued by slave)
		S_AXI_RDATA	: out std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
		-- Read response. This signal indicates the status of the
    		-- read transfer.
		S_AXI_RRESP	: out std_logic_vector(1 downto 0);
		-- Read valid. This signal indicates that the channel is
    		-- signaling the required read data.
		S_AXI_RVALID	: out std_logic;
		-- Read ready. This signal indicates that the master can
    		-- accept the read data and response information.
		S_AXI_RREADY	: in std_logic
	);
end ffs_v1_0_S00_AXI;

architecture arch_imp of ffs_v1_0_S00_AXI is

	-- AXI4LITE signals
	signal axi_awaddr	: std_logic_vector(C_S_AXI_ADDR_WIDTH-1 downto 0);
	signal axi_awready	: std_logic;
	signal axi_wready	: std_logic;
	signal axi_bresp	: std_logic_vector(1 downto 0);
	signal axi_bvalid	: std_logic;
	signal axi_araddr	: std_logic_vector(C_S_AXI_ADDR_WIDTH-1 downto 0);
	signal axi_arready	: std_logic;
	signal axi_rdata	: std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal axi_rresp	: std_logic_vector(1 downto 0);
	signal axi_rvalid	: std_logic;

	-- Example-specific design signals
	-- local parameter for addressing 32 bit / 64 bit C_S_AXI_DATA_WIDTH
	-- ADDR_LSB is used for addressing 32/64 bit registers/memories
	-- ADDR_LSB = 2 for 32 bits (n downto 2)
	-- ADDR_LSB = 3 for 64 bits (n downto 3)
	constant ADDR_LSB  : integer := (C_S_AXI_DATA_WIDTH/32)+ 1;
	constant OPT_MEM_ADDR_BITS : integer := 5;
	------------------------------------------------
	---- Signals for user logic register space example
	--------------------------------------------------
	---- Number of Slave Registers 47
	signal slv_reg0	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg1	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg2	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg3	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg4	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg5	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg6	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg7	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg8	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg9	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg10	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg11	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg12	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg13	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg14	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg15	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg16	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg17	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg18	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg19	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg20	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg21	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg22	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg23	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg24	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg25	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg26	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg27	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg28	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg29	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg30	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg31	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg32	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg33	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg34	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg35	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg36	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg37	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg38	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg39	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg40	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg41	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg42	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg43	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg44	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg45	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg46	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal slv_reg_rden	: std_logic;
	signal slv_reg_wren	: std_logic;
	signal reg_data_out	:std_logic_vector(C_S_AXI_DATA_WIDTH-1 downto 0);
	signal byte_index	: integer;
	signal aw_en	: std_logic;

begin
	-- I/O Connections assignments

	S_AXI_AWREADY	<= axi_awready;
	S_AXI_WREADY	<= axi_wready;
	S_AXI_BRESP	<= axi_bresp;
	S_AXI_BVALID	<= axi_bvalid;
	S_AXI_ARREADY	<= axi_arready;
	S_AXI_RDATA	<= axi_rdata;
	S_AXI_RRESP	<= axi_rresp;
	S_AXI_RVALID	<= axi_rvalid;
	-- Implement axi_awready generation
	-- axi_awready is asserted for one S_AXI_ACLK clock cycle when both
	-- S_AXI_AWVALID and S_AXI_WVALID are asserted. axi_awready is
	-- de-asserted when reset is low.

	process (S_AXI_ACLK)
	begin
	  if rising_edge(S_AXI_ACLK) then 
	    if S_AXI_ARESETN = '0' then
	      axi_awready <= '0';
	      aw_en <= '1';
	    else
	      if (axi_awready = '0' and S_AXI_AWVALID = '1' and S_AXI_WVALID = '1' and aw_en = '1') then
	        -- slave is ready to accept write address when
	        -- there is a valid write address and write data
	        -- on the write address and data bus. This design 
	        -- expects no outstanding transactions. 
	           axi_awready <= '1';
	           aw_en <= '0';
	        elsif (S_AXI_BREADY = '1' and axi_bvalid = '1') then
	           aw_en <= '1';
	           axi_awready <= '0';
	      else
	        axi_awready <= '0';
	      end if;
	    end if;
	  end if;
	end process;

	-- Implement axi_awaddr latching
	-- This process is used to latch the address when both 
	-- S_AXI_AWVALID and S_AXI_WVALID are valid. 

	process (S_AXI_ACLK)
	begin
	  if rising_edge(S_AXI_ACLK) then 
	    if S_AXI_ARESETN = '0' then
	      axi_awaddr <= (others => '0');
	    else
	      if (axi_awready = '0' and S_AXI_AWVALID = '1' and S_AXI_WVALID = '1' and aw_en = '1') then
	        -- Write Address latching
	        axi_awaddr <= S_AXI_AWADDR;
	      end if;
	    end if;
	  end if;                   
	end process; 

	-- Implement axi_wready generation
	-- axi_wready is asserted for one S_AXI_ACLK clock cycle when both
	-- S_AXI_AWVALID and S_AXI_WVALID are asserted. axi_wready is 
	-- de-asserted when reset is low. 

	process (S_AXI_ACLK)
	begin
	  if rising_edge(S_AXI_ACLK) then 
	    if S_AXI_ARESETN = '0' then
	      axi_wready <= '0';
	    else
	      if (axi_wready = '0' and S_AXI_WVALID = '1' and S_AXI_AWVALID = '1' and aw_en = '1') then
	          -- slave is ready to accept write data when 
	          -- there is a valid write address and write data
	          -- on the write address and data bus. This design 
	          -- expects no outstanding transactions.           
	          axi_wready <= '1';
	      else
	        axi_wready <= '0';
	      end if;
	    end if;
	  end if;
	end process; 

	-- Implement memory mapped register select and write logic generation
	-- The write data is accepted and written to memory mapped registers when
	-- axi_awready, S_AXI_WVALID, axi_wready and S_AXI_WVALID are asserted. Write strobes are used to
	-- select byte enables of slave registers while writing.
	-- These registers are cleared when reset (active low) is applied.
	-- Slave register write enable is asserted when valid address and data are available
	-- and the slave is ready to accept the write address and write data.
	slv_reg_wren <= axi_wready and S_AXI_WVALID and axi_awready and S_AXI_AWVALID ;

	process (S_AXI_ACLK)
	variable loc_addr :std_logic_vector(OPT_MEM_ADDR_BITS downto 0); 
	begin
	  if rising_edge(S_AXI_ACLK) then 
	    if S_AXI_ARESETN = '0' then
	      slv_reg0 <= (others => '0');
	      slv_reg1 <= (others => '0');
	      slv_reg2 <= (others => '0');
	      slv_reg3 <= (others => '0');
	      slv_reg4 <= (others => '0');
	      slv_reg5 <= (others => '0');
	      slv_reg6 <= (others => '0');
	      slv_reg7 <= (others => '0');
	      slv_reg8 <= (others => '0');
	      slv_reg9 <= (others => '0');
	      slv_reg10 <= (others => '0');
	      slv_reg11 <= (others => '0');
	      slv_reg12 <= (others => '0');
	      slv_reg13 <= (others => '0');
	      slv_reg14 <= (others => '0');
	      slv_reg15 <= (others => '0');
	      slv_reg16 <= (others => '0');
	      slv_reg17 <= (others => '0');
	      slv_reg18 <= (others => '0');
	      slv_reg19 <= (others => '0');
	      slv_reg20 <= (others => '0');
	      slv_reg21 <= (others => '0');
	      slv_reg22 <= (others => '0');
	      slv_reg23 <= (others => '0');
	      slv_reg24 <= (others => '0');
	      slv_reg25 <= (others => '0');
	      slv_reg26 <= (others => '0');
	      slv_reg27 <= (others => '0');
--	      slv_reg28 <= (others => '0');
	      slv_reg29 <= (others => '0');
--	      slv_reg30 <= (others => '0');
--	      slv_reg31 <= (others => '0');
--	      slv_reg32 <= (others => '0');
--	      slv_reg33 <= (others => '0');
--	      slv_reg34 <= (others => '0');
--	      slv_reg35 <= (others => '0');
--	      slv_reg36 <= (others => '0');
--	      slv_reg37 <= (others => '0');
--	      slv_reg38 <= (others => '0');
--	      slv_reg39 <= (others => '0');
--	      slv_reg40 <= (others => '0');
--	      slv_reg41 <= (others => '0');
--	      slv_reg42 <= (others => '0');
--	      slv_reg43 <= (others => '0');
--	      slv_reg44 <= (others => '0');
--	      slv_reg45 <= (others => '0');
--	      slv_reg46 <= (others => '0');
	    else
	      loc_addr := axi_awaddr(ADDR_LSB + OPT_MEM_ADDR_BITS downto ADDR_LSB);
	      if (slv_reg_wren = '1') then
	        case loc_addr is
	          when b"000000" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 0
	                slv_reg0(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000001" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 1
	                slv_reg1(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000010" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 2
	                slv_reg2(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000011" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 3
	                slv_reg3(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000100" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 4
	                slv_reg4(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000101" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 5
	                slv_reg5(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000110" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 6
	                slv_reg6(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"000111" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 7
	                slv_reg7(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001000" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 8
	                slv_reg8(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001001" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 9
	                slv_reg9(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001010" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 10
	                slv_reg10(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001011" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 11
	                slv_reg11(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001100" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 12
	                slv_reg12(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001101" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 13
	                slv_reg13(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001110" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 14
	                slv_reg14(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"001111" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 15
	                slv_reg15(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010000" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 16
	                slv_reg16(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010001" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 17
	                slv_reg17(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010010" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 18
	                slv_reg18(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010011" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 19
	                slv_reg19(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010100" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 20
	                slv_reg20(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010101" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 21
	                slv_reg21(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010110" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 22
	                slv_reg22(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"010111" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 23
	                slv_reg23(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011000" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 24
	                slv_reg24(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011001" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 25
	                slv_reg25(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011010" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 26
	                slv_reg26(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011011" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 27
	                slv_reg27(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011100" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 28
--	                slv_reg28(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011101" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 29
	                slv_reg29(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011110" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 30
--	                slv_reg30(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"011111" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 31
--	                slv_reg31(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100000" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 32
--	                slv_reg32(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100001" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 33
--	                slv_reg33(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100010" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 34
--	                slv_reg34(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100011" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 35
--	                slv_reg35(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100100" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 36
--	                slv_reg36(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100101" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 37
--	                slv_reg37(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100110" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 38
--	                slv_reg38(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"100111" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 39
--	                slv_reg39(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101000" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 40
--	                slv_reg40(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101001" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 41
--	                slv_reg41(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101010" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 42
--	                slv_reg42(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101011" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 43
--	                slv_reg43(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101100" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 44
--	                slv_reg44(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101101" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 45
--	                slv_reg45(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when b"101110" =>
	            for byte_index in 0 to (C_S_AXI_DATA_WIDTH/8-1) loop
	              if ( S_AXI_WSTRB(byte_index) = '1' ) then
	                -- Respective byte enables are asserted as per write strobes                   
	                -- slave registor 46
--	                slv_reg46(byte_index*8+7 downto byte_index*8) <= S_AXI_WDATA(byte_index*8+7 downto byte_index*8);
	              end if;
	            end loop;
	          when others =>
	            slv_reg0 <= slv_reg0;
	            slv_reg1 <= slv_reg1;
	            slv_reg2 <= slv_reg2;
	            slv_reg3 <= slv_reg3;
	            slv_reg4 <= slv_reg4;
	            slv_reg5 <= slv_reg5;
	            slv_reg6 <= slv_reg6;
	            slv_reg7 <= slv_reg7;
	            slv_reg8 <= slv_reg8;
	            slv_reg9 <= slv_reg9;
	            slv_reg10 <= slv_reg10;
	            slv_reg11 <= slv_reg11;
	            slv_reg12 <= slv_reg12;
	            slv_reg13 <= slv_reg13;
	            slv_reg14 <= slv_reg14;
	            slv_reg15 <= slv_reg15;
	            slv_reg16 <= slv_reg16;
	            slv_reg17 <= slv_reg17;
	            slv_reg18 <= slv_reg18;
	            slv_reg19 <= slv_reg19;
	            slv_reg20 <= slv_reg20;
	            slv_reg21 <= slv_reg21;
	            slv_reg22 <= slv_reg22;
	            slv_reg23 <= slv_reg23;
	            slv_reg24 <= slv_reg24;
	            slv_reg25 <= slv_reg25;
	            slv_reg26 <= slv_reg26;
	            slv_reg27 <= slv_reg27;
--	            slv_reg28 <= slv_reg28;
	            slv_reg29 <= slv_reg29;
--	            slv_reg30 <= slv_reg30;
--	            slv_reg31 <= slv_reg31;
--	            slv_reg32 <= slv_reg32;
--	            slv_reg33 <= slv_reg33;
--	            slv_reg34 <= slv_reg34;
--	            slv_reg35 <= slv_reg35;
--	            slv_reg36 <= slv_reg36;
--	            slv_reg37 <= slv_reg37;
--	            slv_reg38 <= slv_reg38;
--	            slv_reg39 <= slv_reg39;
--	            slv_reg40 <= slv_reg40;
--	            slv_reg41 <= slv_reg41;
--	            slv_reg42 <= slv_reg42;
--	            slv_reg43 <= slv_reg43;
--	            slv_reg44 <= slv_reg44;
--	            slv_reg45 <= slv_reg45;
--	            slv_reg46 <= slv_reg46;
	        end case;
	      end if;
	    end if;
	  end if;                   
	end process; 

	-- Implement write response logic generation
	-- The write response and response valid signals are asserted by the slave 
	-- when axi_wready, S_AXI_WVALID, axi_wready and S_AXI_WVALID are asserted.  
	-- This marks the acceptance of address and indicates the status of 
	-- write transaction.

	process (S_AXI_ACLK)
	begin
	  if rising_edge(S_AXI_ACLK) then 
	    if S_AXI_ARESETN = '0' then
	      axi_bvalid  <= '0';
	      axi_bresp   <= "00"; --need to work more on the responses
	    else
	      if (axi_awready = '1' and S_AXI_AWVALID = '1' and axi_wready = '1' and S_AXI_WVALID = '1' and axi_bvalid = '0'  ) then
	        axi_bvalid <= '1';
	        axi_bresp  <= "00"; 
	      elsif (S_AXI_BREADY = '1' and axi_bvalid = '1') then   --check if bready is asserted while bvalid is high)
	        axi_bvalid <= '0';                                 -- (there is a possibility that bready is always asserted high)
	      end if;
	    end if;
	  end if;                   
	end process; 

	-- Implement axi_arready generation
	-- axi_arready is asserted for one S_AXI_ACLK clock cycle when
	-- S_AXI_ARVALID is asserted. axi_awready is 
	-- de-asserted when reset (active low) is asserted. 
	-- The read address is also latched when S_AXI_ARVALID is 
	-- asserted. axi_araddr is reset to zero on reset assertion.

	process (S_AXI_ACLK)
	begin
	  if rising_edge(S_AXI_ACLK) then 
	    if S_AXI_ARESETN = '0' then
	      axi_arready <= '0';
	      axi_araddr  <= (others => '1');
	    else
	      if (axi_arready = '0' and S_AXI_ARVALID = '1') then
	        -- indicates that the slave has acceped the valid read address
	        axi_arready <= '1';
	        -- Read Address latching 
	        axi_araddr  <= S_AXI_ARADDR;           
	      else
	        axi_arready <= '0';
	      end if;
	    end if;
	  end if;                   
	end process; 

	-- Implement axi_arvalid generation
	-- axi_rvalid is asserted for one S_AXI_ACLK clock cycle when both 
	-- S_AXI_ARVALID and axi_arready are asserted. The slave registers 
	-- data are available on the axi_rdata bus at this instance. The 
	-- assertion of axi_rvalid marks the validity of read data on the 
	-- bus and axi_rresp indicates the status of read transaction.axi_rvalid 
	-- is deasserted on reset (active low). axi_rresp and axi_rdata are 
	-- cleared to zero on reset (active low).  
	process (S_AXI_ACLK)
	begin
	  if rising_edge(S_AXI_ACLK) then
	    if S_AXI_ARESETN = '0' then
	      axi_rvalid <= '0';
	      axi_rresp  <= "00";
	    else
	      if (axi_arready = '1' and S_AXI_ARVALID = '1' and axi_rvalid = '0') then
	        -- Valid read data is available at the read data bus
	        axi_rvalid <= '1';
	        axi_rresp  <= "00"; -- 'OKAY' response
	      elsif (axi_rvalid = '1' and S_AXI_RREADY = '1') then
	        -- Read data is accepted by the master
	        axi_rvalid <= '0';
	      end if;            
	    end if;
	  end if;
	end process;

	-- Implement memory mapped register select and read logic generation
	-- Slave register read enable is asserted when valid address is available
	-- and the slave is ready to accept the read address.
	slv_reg_rden <= axi_arready and S_AXI_ARVALID and (not axi_rvalid) ;

	process (slv_reg0, slv_reg1, slv_reg2, slv_reg3, slv_reg4, slv_reg5, slv_reg6, slv_reg7, slv_reg8, slv_reg9, slv_reg10, slv_reg11, slv_reg12, slv_reg13, slv_reg14, slv_reg15, slv_reg16, slv_reg17, slv_reg18, slv_reg19, slv_reg20, slv_reg21, slv_reg22, slv_reg23, slv_reg24, slv_reg25, slv_reg26, slv_reg27, slv_reg28, slv_reg29, slv_reg30, slv_reg31, slv_reg32, slv_reg33, slv_reg34, slv_reg35, slv_reg36, slv_reg37, slv_reg38, slv_reg39, slv_reg40, slv_reg41, slv_reg42, slv_reg43, slv_reg44, slv_reg45, slv_reg46, axi_araddr, S_AXI_ARESETN, slv_reg_rden)
	variable loc_addr :std_logic_vector(OPT_MEM_ADDR_BITS downto 0);
	begin
	    -- Address decoding for reading registers
	    loc_addr := axi_araddr(ADDR_LSB + OPT_MEM_ADDR_BITS downto ADDR_LSB);
	    case loc_addr is
	      when b"000000" =>
	        reg_data_out <= slv_reg0;
	      when b"000001" =>
	        reg_data_out <= slv_reg1;
	      when b"000010" =>
	        reg_data_out <= slv_reg2;
	      when b"000011" =>
	        reg_data_out <= slv_reg3;
	      when b"000100" =>
	        reg_data_out <= slv_reg4;
	      when b"000101" =>
	        reg_data_out <= slv_reg5;
	      when b"000110" =>
	        reg_data_out <= slv_reg6;
	      when b"000111" =>
	        reg_data_out <= slv_reg7;
	      when b"001000" =>
	        reg_data_out <= slv_reg8;
	      when b"001001" =>
	        reg_data_out <= slv_reg9;
	      when b"001010" =>
	        reg_data_out <= slv_reg10;
	      when b"001011" =>
	        reg_data_out <= slv_reg11;
	      when b"001100" =>
	        reg_data_out <= slv_reg12;
	      when b"001101" =>
	        reg_data_out <= slv_reg13;
	      when b"001110" =>
	        reg_data_out <= slv_reg14;
	      when b"001111" =>
	        reg_data_out <= slv_reg15;
	      when b"010000" =>
	        reg_data_out <= slv_reg16;
	      when b"010001" =>
	        reg_data_out <= slv_reg17;
	      when b"010010" =>
	        reg_data_out <= slv_reg18;
	      when b"010011" =>
	        reg_data_out <= slv_reg19;
	      when b"010100" =>
	        reg_data_out <= slv_reg20;
	      when b"010101" =>
	        reg_data_out <= slv_reg21;
	      when b"010110" =>
	        reg_data_out <= slv_reg22;
	      when b"010111" =>
	        reg_data_out <= slv_reg23;
	      when b"011000" =>
	        reg_data_out <= slv_reg24;
	      when b"011001" =>
	        reg_data_out <= slv_reg25;
	      when b"011010" =>
	        reg_data_out <= slv_reg26;
	      when b"011011" =>
	        reg_data_out <= slv_reg27;
	      when b"011100" =>
	        reg_data_out <= slv_reg28;
	      when b"011101" =>
	        reg_data_out <= slv_reg29;
	      when b"011110" =>
	        reg_data_out <= slv_reg30;
	      when b"011111" =>
	        reg_data_out <= slv_reg31;
	      when b"100000" =>
	        reg_data_out <= slv_reg32;
	      when b"100001" =>
	        reg_data_out <= slv_reg33;
	      when b"100010" =>
	        reg_data_out <= slv_reg34;
	      when b"100011" =>
	        reg_data_out <= slv_reg35;
	      when b"100100" =>
	        reg_data_out <= slv_reg36;
	      when b"100101" =>
	        reg_data_out <= slv_reg37;
	      when b"100110" =>
	        reg_data_out <= slv_reg38;
	      when b"100111" =>
	        reg_data_out <= slv_reg39;
	      when b"101000" =>
	        reg_data_out <= slv_reg40;
	      when b"101001" =>
	        reg_data_out <= slv_reg41;
	      when b"101010" =>
	        reg_data_out <= slv_reg42;
	      when b"101011" =>
	        reg_data_out <= slv_reg43;
	      when b"101100" =>
	        reg_data_out <= slv_reg44;
	      when b"101101" =>
	        reg_data_out <= slv_reg45;
	      when b"101110" =>
	        reg_data_out <= slv_reg46;
	      when others =>
	        reg_data_out  <= (others => '0');
	    end case;
	end process; 

	-- Output register or memory read data
	process( S_AXI_ACLK ) is
	begin
	  if (rising_edge (S_AXI_ACLK)) then
	    if ( S_AXI_ARESETN = '0' ) then
	      axi_rdata  <= (others => '0');
	    else
	      if (slv_reg_rden = '1') then
	        -- When there is a valid read address (S_AXI_ARVALID) with 
	        -- acceptance of read address by the slave (axi_arready), 
	        -- output the read dada 
	        -- Read address mux
	          axi_rdata <= reg_data_out;     -- register read data
	      end if;   
	    end if;
	  end if;
	end process;


	-- Add user logic here
        IState_ValidSeed <= slv_reg0(0);
        IState_ValidT <= slv_reg0(1);
        IState_Nonce0 <= slv_reg1(31 downto 0);
        IState_Nonce1 <= slv_reg2(31 downto 0);
        IState_Nonce2 <= slv_reg3(31 downto 0);
        IState_Key0   <= slv_reg4(31 downto 0);
        IState_Key1   <= slv_reg5(31 downto 0);
        IState_Key2   <= slv_reg6(31 downto 0);
        IState_Key3   <= slv_reg7(31 downto 0);
        IState_Key4   <= slv_reg8(31 downto 0);
        IState_Key5   <= slv_reg9(31 downto 0);
        IState_Key6   <= slv_reg10(31 downto 0);
        IState_Key7   <= slv_reg11(31 downto 0);
        IState_Text0 <= slv_reg12(7  downto 0);
        IState_Text1 <= slv_reg12(15 downto 8);
        IState_Text2 <= slv_reg12(23 downto 16);
        IState_Text3 <= slv_reg12(31 downto 24);
        IState_Text4 <= slv_reg13(7  downto 0);
        IState_Text5 <= slv_reg13(15 downto 8);
        IState_Text6 <= slv_reg13(23 downto 16);
        IState_Text7 <= slv_reg13(31 downto 24);
        IState_Text8 <= slv_reg14(7  downto 0);
        IState_Text9 <= slv_reg14(15 downto 8);
        IState_Text10 <= slv_reg14(23 downto 16);
        IState_Text11 <= slv_reg14(31 downto 24);
        IState_Text12 <= slv_reg15(7  downto 0);
        IState_Text13 <= slv_reg15(15 downto 8);
        IState_Text14 <= slv_reg15(23 downto 16);
        IState_Text15 <= slv_reg15(31 downto 24);
        IState_Text16 <= slv_reg16(7  downto 0);
        IState_Text17 <= slv_reg16(15 downto 8);
        IState_Text18 <= slv_reg16(23 downto 16);
        IState_Text19 <= slv_reg16(31 downto 24);
        IState_Text20 <= slv_reg17(7  downto 0);
        IState_Text21 <= slv_reg17(15 downto 8);
        IState_Text22 <= slv_reg17(23 downto 16);
        IState_Text23 <= slv_reg17(31 downto 24);
        IState_Text24 <= slv_reg18(7  downto 0);
        IState_Text25 <= slv_reg18(15 downto 8);
        IState_Text26 <= slv_reg18(23 downto 16);
        IState_Text27 <= slv_reg18(31 downto 24);
        IState_Text28 <= slv_reg19(7  downto 0);
        IState_Text29 <= slv_reg19(15 downto 8);
        IState_Text30 <= slv_reg19(23 downto 16);
        IState_Text31 <= slv_reg19(31 downto 24);
        IState_Text32 <= slv_reg20(7  downto 0);
        IState_Text33 <= slv_reg20(15 downto 8);
        IState_Text34 <= slv_reg20(23 downto 16);
        IState_Text35 <= slv_reg20(31 downto 24);
        IState_Text36 <= slv_reg21(7  downto 0);
        IState_Text37 <= slv_reg21(15 downto 8);
        IState_Text38 <= slv_reg21(23 downto 16);
        IState_Text39 <= slv_reg21(31 downto 24);
        IState_Text40 <= slv_reg22(7  downto 0);
        IState_Text41 <= slv_reg22(15 downto 8);
        IState_Text42 <= slv_reg22(23 downto 16);
        IState_Text43 <= slv_reg22(31 downto 24);
        IState_Text44 <= slv_reg23(7  downto 0);
        IState_Text45 <= slv_reg23(15 downto 8);
        IState_Text46 <= slv_reg23(23 downto 16);
        IState_Text47 <= slv_reg23(31 downto 24);
        IState_Text48 <= slv_reg24(7  downto 0);
        IState_Text49 <= slv_reg24(15 downto 8);
        IState_Text50 <= slv_reg24(23 downto 16);
        IState_Text51 <= slv_reg24(31 downto 24);
        IState_Text52 <= slv_reg25(7  downto 0);
        IState_Text53 <= slv_reg25(15 downto 8);
        IState_Text54 <= slv_reg25(23 downto 16);
        IState_Text55 <= slv_reg25(31 downto 24);
        IState_Text56 <= slv_reg26(7  downto 0);
        IState_Text57 <= slv_reg26(15 downto 8);
        IState_Text58 <= slv_reg26(23 downto 16);
        IState_Text59 <= slv_reg26(31 downto 24);
        IState_Text60 <= slv_reg27(7  downto 0);
        IState_Text61 <= slv_reg27(15 downto 8);
        IState_Text62 <= slv_reg27(23 downto 16);
        IState_Text63 <= slv_reg27(31 downto 24);

        slv_reg28(0) <= axi_r_1_ready;
        axi_r_0_ready <= slv_reg29(0);

        slv_reg30(0) <= IStream_Valid;
        slv_reg31(7  downto 0)  <=  IStream_Values0;
        slv_reg31(15 downto 8)  <=  IStream_Values1;
        slv_reg31(23 downto 16) <=  IStream_Values2;
        slv_reg31(31 downto 24) <=  IStream_Values3;
        slv_reg32(7  downto 0)  <=  IStream_Values4;
        slv_reg32(15 downto 8)  <=  IStream_Values5;
        slv_reg32(23 downto 16) <=  IStream_Values6;
        slv_reg32(31 downto 24) <=  IStream_Values7;
        slv_reg33(7  downto 0)  <=  IStream_Values8;
        slv_reg33(15 downto 8)  <=  IStream_Values9;
        slv_reg33(23 downto 16) <= IStream_Values10;
        slv_reg33(31 downto 24) <= IStream_Values11;
        slv_reg34(7  downto 0)  <= IStream_Values12;
        slv_reg34(15 downto 8)  <= IStream_Values13;
        slv_reg34(23 downto 16) <= IStream_Values14;
        slv_reg34(31 downto 24) <= IStream_Values15;
        slv_reg35(7  downto 0)  <= IStream_Values16;
        slv_reg35(15 downto 8)  <= IStream_Values17;
        slv_reg35(23 downto 16) <= IStream_Values18;
        slv_reg35(31 downto 24) <= IStream_Values19;
        slv_reg36(7  downto 0)  <= IStream_Values20;
        slv_reg36(15 downto 8)  <= IStream_Values21;
        slv_reg36(23 downto 16) <= IStream_Values22;
        slv_reg36(31 downto 24) <= IStream_Values23;
        slv_reg37(7  downto 0)  <= IStream_Values24;
        slv_reg37(15 downto 8)  <= IStream_Values25;
        slv_reg37(23 downto 16) <= IStream_Values26;
        slv_reg37(31 downto 24) <= IStream_Values27;
        slv_reg38(7  downto 0)  <= IStream_Values28;
        slv_reg38(15 downto 8)  <= IStream_Values29;
        slv_reg38(23 downto 16) <= IStream_Values30;
        slv_reg38(31 downto 24) <= IStream_Values31;
        slv_reg39(7  downto 0)  <= IStream_Values32;
        slv_reg39(15 downto 8)  <= IStream_Values33;
        slv_reg39(23 downto 16) <= IStream_Values34;
        slv_reg39(31 downto 24) <= IStream_Values35;
        slv_reg40(7  downto 0)  <= IStream_Values36;
        slv_reg40(15 downto 8)  <= IStream_Values37;
        slv_reg40(23 downto 16) <= IStream_Values38;
        slv_reg40(31 downto 24) <= IStream_Values39;
        slv_reg41(7  downto 0)  <= IStream_Values40;
        slv_reg41(15 downto 8)  <= IStream_Values41;
        slv_reg41(23 downto 16) <= IStream_Values42;
        slv_reg41(31 downto 24) <= IStream_Values43;
        slv_reg42(7  downto 0)  <= IStream_Values44;
        slv_reg42(15 downto 8)  <= IStream_Values45;
        slv_reg42(23 downto 16) <= IStream_Values46;
        slv_reg42(31 downto 24) <= IStream_Values47;
        slv_reg43(7  downto 0)  <= IStream_Values48;
        slv_reg43(15 downto 8)  <= IStream_Values49;
        slv_reg43(23 downto 16) <= IStream_Values50;
        slv_reg43(31 downto 24) <= IStream_Values51;
        slv_reg44(7  downto 0)  <= IStream_Values52;
        slv_reg44(15 downto 8)  <= IStream_Values53;
        slv_reg44(23 downto 16) <= IStream_Values54;
        slv_reg44(31 downto 24) <= IStream_Values55;
        slv_reg45(7  downto 0)  <= IStream_Values56;
        slv_reg45(15 downto 8)  <= IStream_Values57;
        slv_reg45(23 downto 16) <= IStream_Values58;
        slv_reg45(31 downto 24) <= IStream_Values59;
        slv_reg46(7  downto 0)  <= IStream_Values60;
        slv_reg46(15 downto 8)  <= IStream_Values61;
        slv_reg46(23 downto 16) <= IStream_Values62;
        slv_reg46(31 downto 24) <= IStream_Values63;

	-- User logic ends

end arch_imp;
