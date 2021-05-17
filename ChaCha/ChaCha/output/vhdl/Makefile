all: test export
testbench: chacha_tb
export: ChaCha_export
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

$(WORKDIR)/Types_ChaCha.o: Types_ChaCha.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_ChaCha.vhdl

$(WORKDIR)/ChaCha20.o: ChaCha20.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_ChaCha.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha20.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_ChaCha.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/ChaCha.o: ChaCha.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_ChaCha.o $(WORKDIR)/ChaCha20.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha.vhdl

$(WORKDIR)/TestBench_ChaCha.o: TestBench_ChaCha.vhdl $(WORKDIR)/ChaCha.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_ChaCha.vhdl

chacha_tb: $(WORKDIR)/TestBench_ChaCha.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha_tb

ChaCha_export: $(WORKDIR)/ChaCha.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_ChaCha.vhdl

test: chacha_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) ChaCha_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o chacha_tb

.PHONY: all clean test export build 
