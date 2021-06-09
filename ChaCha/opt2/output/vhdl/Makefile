all: test export
testbench: opt2_tb
export: opt2_export
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

$(WORKDIR)/Types_opt2.o: Types_opt2.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_opt2.vhdl

$(WORKDIR)/Round1.o: Round1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round1.vhdl

$(WORKDIR)/RoundOdd.o: RoundOdd.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundOdd.vhdl

$(WORKDIR)/RoundEven.o: RoundEven.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundEven.vhdl

$(WORKDIR)/RoundCombine.o: RoundCombine.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundCombine.vhdl

$(WORKDIR)/RoundXOR.o: RoundXOR.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundXOR.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt2.o: opt2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)/Round1.o $(WORKDIR)/RoundOdd.o $(WORKDIR)/RoundEven.o $(WORKDIR)/RoundCombine.o $(WORKDIR)/RoundXOR.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt2.vhdl

$(WORKDIR)/TestBench_opt2.o: TestBench_opt2.vhdl $(WORKDIR)/opt2.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_opt2.vhdl

opt2_tb: $(WORKDIR)/TestBench_opt2.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt2_tb

opt2_export: $(WORKDIR)/opt2.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_opt2.vhdl

test: opt2_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt2_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o opt2_tb

.PHONY: all clean test export build 
