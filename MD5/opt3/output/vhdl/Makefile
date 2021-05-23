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

$(WORKDIR)/MessageFormat.o: MessageFormat.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) MessageFormat.vhdl

$(WORKDIR)/FormatConverter.o: FormatConverter.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) FormatConverter.vhdl

$(WORKDIR)/RoundF1.o: RoundF1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF1.vhdl

$(WORKDIR)/RoundF2.o: RoundF2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF2.vhdl

$(WORKDIR)/RoundF3.o: RoundF3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF3.vhdl

$(WORKDIR)/RoundF4.o: RoundF4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF4.vhdl

$(WORKDIR)/RoundG1.o: RoundG1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG1.vhdl

$(WORKDIR)/RoundG2.o: RoundG2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG2.vhdl

$(WORKDIR)/RoundG3.o: RoundG3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG3.vhdl

$(WORKDIR)/RoundG4.o: RoundG4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG4.vhdl

$(WORKDIR)/RoundH1.o: RoundH1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH1.vhdl

$(WORKDIR)/RoundH2.o: RoundH2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH2.vhdl

$(WORKDIR)/RoundH3.o: RoundH3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH3.vhdl

$(WORKDIR)/RoundH4.o: RoundH4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH4.vhdl

$(WORKDIR)/RoundI1.o: RoundI1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI1.vhdl

$(WORKDIR)/RoundI2.o: RoundI2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI2.vhdl

$(WORKDIR)/RoundI3.o: RoundI3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI3.vhdl

$(WORKDIR)/RoundI4.o: RoundI4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI4.vhdl

$(WORKDIR)/Combiner.o: Combiner.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Combiner.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt3.o: opt3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)/MessageFormat.o $(WORKDIR)/FormatConverter.o $(WORKDIR)/RoundF1.o $(WORKDIR)/RoundF2.o $(WORKDIR)/RoundF3.o $(WORKDIR)/RoundF4.o $(WORKDIR)/RoundG1.o $(WORKDIR)/RoundG2.o $(WORKDIR)/RoundG3.o $(WORKDIR)/RoundG4.o $(WORKDIR)/RoundH1.o $(WORKDIR)/RoundH2.o $(WORKDIR)/RoundH3.o $(WORKDIR)/RoundH4.o $(WORKDIR)/RoundI1.o $(WORKDIR)/RoundI2.o $(WORKDIR)/RoundI3.o $(WORKDIR)/RoundI4.o $(WORKDIR)/Combiner.o $(WORKDIR)/csv_util.o 
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
