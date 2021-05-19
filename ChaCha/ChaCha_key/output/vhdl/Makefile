all: test export
testbench: chacha_key_tb
export: ChaCha_key_export
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

$(WORKDIR)/Types_ChaCha_key.o: Types_ChaCha_key.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_ChaCha_key.vhdl

$(WORKDIR)/ChaCha20.o: ChaCha20.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_ChaCha_key.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha20.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_ChaCha_key.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/ChaCha_key.o: ChaCha_key.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_ChaCha_key.o $(WORKDIR)/ChaCha20.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha_key.vhdl

$(WORKDIR)/TestBench_ChaCha_key.o: TestBench_ChaCha_key.vhdl $(WORKDIR)/ChaCha_key.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_ChaCha_key.vhdl

chacha_key_tb: $(WORKDIR)/TestBench_ChaCha_key.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha_key_tb

ChaCha_key_export: $(WORKDIR)/ChaCha_key.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_ChaCha_key.vhdl

test: chacha_key_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha_key_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o chacha_key_tb

.PHONY: all clean test export build 
