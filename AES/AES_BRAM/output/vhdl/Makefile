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

$(WORKDIR)/AESe.o: AESe.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) AESe.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/AES_BRAM.o: AES_BRAM.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_AES_BRAM.o $(WORKDIR)/AESe.o $(WORKDIR)/csv_util.o 
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
