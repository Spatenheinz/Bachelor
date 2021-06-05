all: test export
testbench: aes_bram_tb
export: AES_BRAM_export
build: export testbench

# Use a temporary folder for compiled stuff
WORKDIR=work

# All code should be VHDL93 compliant,
# but 93c is a bit easier to work with
STD=93c

# Eveything should compile with clean IEEE,
# but the test-bench and CSV util's require
# std_logic_textio from Synopsys
IEEE=synopsys

# VCD trace file for GTKWave
VCDFILE=trace.vcd

# Disable the 'Warning: redundant others'
FLAGS=--warn-no-others

$(WORKDIR):
	mkdir $(WORKDIR)

$(WORKDIR)/system_types.o: system_types.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) system_types.vhdl

$(WORKDIR)/Types_AES_BRAM.o: Types_AES_BRAM.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_AES_BRAM.vhdl

$(WORKDIR)/Round1.o: Round1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round1.vhdl

$(WORKDIR)/Round2.o: Round2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round2.vhdl

$(WORKDIR)/SME_Components_TrueDualPortMemory_1_UInt32.o: SME_Components_TrueDualPortMemory_1_UInt32.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) SME_Components_TrueDualPortMemory_1_UInt32.vhdl

$(WORKDIR)/Round3.o: Round3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round3.vhdl

$(WORKDIR)/Round4.o: Round4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round4.vhdl

$(WORKDIR)/Round5.o: Round5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round5.vhdl

$(WORKDIR)/Round6.o: Round6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round6.vhdl

$(WORKDIR)/Round7.o: Round7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round7.vhdl

$(WORKDIR)/Round8.o: Round8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round8.vhdl

$(WORKDIR)/Round9.o: Round9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round9.vhdl

$(WORKDIR)/Round10.o: Round10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round10.vhdl

$(WORKDIR)/Round11.o: Round11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round11.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/AES_BRAM.o: AES_BRAM.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)/Round1.o $(WORKDIR)/Round2.o $(WORKDIR)/SME_Components_TrueDualPortMemory_1_UInt32.o $(WORKDIR)/Round3.o $(WORKDIR)/Round4.o $(WORKDIR)/Round5.o $(WORKDIR)/Round6.o $(WORKDIR)/Round7.o $(WORKDIR)/Round8.o $(WORKDIR)/Round9.o $(WORKDIR)/Round10.o $(WORKDIR)/Round11.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) AES_BRAM.vhdl

$(WORKDIR)/TestBench_AES_BRAM.o: TestBench_AES_BRAM.vhdl $(WORKDIR)/AES_BRAM.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_AES_BRAM.vhdl

aes_bram_tb: $(WORKDIR)/TestBench_AES_BRAM.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) AES_BRAM_tb

AES_BRAM_export: $(WORKDIR)/AES_BRAM.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_AES_BRAM.vhdl

test: aes_bram_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) AES_BRAM_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o aes_bram_tb

.PHONY: all clean test export build 
