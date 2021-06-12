all: test export
testbench: opt3_tb
export: opt3_export
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

$(WORKDIR)/Types_opt3.o: Types_opt3.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_opt3.vhdl

$(WORKDIR)/Round1.o: Round1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round1.vhdl

$(WORKDIR)/RoundEven_2.o: RoundEven_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundEven_2.vhdl

$(WORKDIR)/RoundOdd_1.o: RoundOdd_1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundOdd_1.vhdl

$(WORKDIR)/RoundOdd_2.o: RoundOdd_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundOdd_2.vhdl

$(WORKDIR)/RoundEven_1.o: RoundEven_1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundEven_1.vhdl

$(WORKDIR)/RoundCombine.o: RoundCombine.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundCombine.vhdl

$(WORKDIR)/RoundCombine_2.o: RoundCombine_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundCombine_2.vhdl

$(WORKDIR)/RoundXOR.o: RoundXOR.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundXOR.vhdl

$(WORKDIR)/RoundXOR_2.o: RoundXOR_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundXOR_2.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt3.o: opt3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)/Round1.o $(WORKDIR)/RoundEven_2.o $(WORKDIR)/RoundOdd_1.o $(WORKDIR)/RoundOdd_2.o $(WORKDIR)/RoundEven_1.o $(WORKDIR)/RoundCombine.o $(WORKDIR)/RoundCombine_2.o $(WORKDIR)/RoundXOR.o $(WORKDIR)/RoundXOR_2.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt3.vhdl

$(WORKDIR)/TestBench_opt3.o: TestBench_opt3.vhdl $(WORKDIR)/opt3.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_opt3.vhdl

opt3_tb: $(WORKDIR)/TestBench_opt3.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt3_tb

opt3_export: $(WORKDIR)/opt3.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_opt3.vhdl

test: opt3_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt3_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o opt3_tb

.PHONY: all clean test export build 
