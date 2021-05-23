all: test export
testbench: opt4_tb
export: opt4_export
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

$(WORKDIR)/Types_opt4.o: Types_opt4.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_opt4.vhdl

$(WORKDIR)/MessageFormat.o: MessageFormat.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) MessageFormat.vhdl

$(WORKDIR)/FormatConverter.o: FormatConverter.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) FormatConverter.vhdl

$(WORKDIR)/RoundF1.o: RoundF1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF1.vhdl

$(WORKDIR)/RoundF2.o: RoundF2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF2.vhdl

$(WORKDIR)/RoundF3.o: RoundF3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF3.vhdl

$(WORKDIR)/RoundF4.o: RoundF4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF4.vhdl

$(WORKDIR)/RoundF5.o: RoundF5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF5.vhdl

$(WORKDIR)/RoundF6.o: RoundF6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF6.vhdl

$(WORKDIR)/RoundF7.o: RoundF7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF7.vhdl

$(WORKDIR)/RoundF8.o: RoundF8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF8.vhdl

$(WORKDIR)/RoundG1.o: RoundG1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG1.vhdl

$(WORKDIR)/RoundG2.o: RoundG2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG2.vhdl

$(WORKDIR)/RoundG3.o: RoundG3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG3.vhdl

$(WORKDIR)/RoundG4.o: RoundG4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG4.vhdl

$(WORKDIR)/RoundG5.o: RoundG5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG5.vhdl

$(WORKDIR)/RoundG6.o: RoundG6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG6.vhdl

$(WORKDIR)/RoundG7.o: RoundG7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG7.vhdl

$(WORKDIR)/RoundG8.o: RoundG8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG8.vhdl

$(WORKDIR)/RoundH1.o: RoundH1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH1.vhdl

$(WORKDIR)/RoundH2.o: RoundH2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH2.vhdl

$(WORKDIR)/RoundH3.o: RoundH3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH3.vhdl

$(WORKDIR)/RoundH4.o: RoundH4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH4.vhdl

$(WORKDIR)/RoundH5.o: RoundH5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH5.vhdl

$(WORKDIR)/RoundH6.o: RoundH6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH6.vhdl

$(WORKDIR)/RoundH7.o: RoundH7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH7.vhdl

$(WORKDIR)/RoundH8.o: RoundH8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH8.vhdl

$(WORKDIR)/RoundI1.o: RoundI1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI1.vhdl

$(WORKDIR)/RoundI2.o: RoundI2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI2.vhdl

$(WORKDIR)/RoundI3.o: RoundI3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI3.vhdl

$(WORKDIR)/RoundI4.o: RoundI4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI4.vhdl

$(WORKDIR)/RoundI5.o: RoundI5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI5.vhdl

$(WORKDIR)/RoundI6.o: RoundI6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI6.vhdl

$(WORKDIR)/RoundI7.o: RoundI7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI7.vhdl

$(WORKDIR)/RoundI8.o: RoundI8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI8.vhdl

$(WORKDIR)/Combiner.o: Combiner.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Combiner.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt4.o: opt4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt4.o $(WORKDIR)/MessageFormat.o $(WORKDIR)/FormatConverter.o $(WORKDIR)/RoundF1.o $(WORKDIR)/RoundF2.o $(WORKDIR)/RoundF3.o $(WORKDIR)/RoundF4.o $(WORKDIR)/RoundF5.o $(WORKDIR)/RoundF6.o $(WORKDIR)/RoundF7.o $(WORKDIR)/RoundF8.o $(WORKDIR)/RoundG1.o $(WORKDIR)/RoundG2.o $(WORKDIR)/RoundG3.o $(WORKDIR)/RoundG4.o $(WORKDIR)/RoundG5.o $(WORKDIR)/RoundG6.o $(WORKDIR)/RoundG7.o $(WORKDIR)/RoundG8.o $(WORKDIR)/RoundH1.o $(WORKDIR)/RoundH2.o $(WORKDIR)/RoundH3.o $(WORKDIR)/RoundH4.o $(WORKDIR)/RoundH5.o $(WORKDIR)/RoundH6.o $(WORKDIR)/RoundH7.o $(WORKDIR)/RoundH8.o $(WORKDIR)/RoundI1.o $(WORKDIR)/RoundI2.o $(WORKDIR)/RoundI3.o $(WORKDIR)/RoundI4.o $(WORKDIR)/RoundI5.o $(WORKDIR)/RoundI6.o $(WORKDIR)/RoundI7.o $(WORKDIR)/RoundI8.o $(WORKDIR)/Combiner.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt4.vhdl

$(WORKDIR)/TestBench_opt4.o: TestBench_opt4.vhdl $(WORKDIR)/opt4.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_opt4.vhdl

opt4_tb: $(WORKDIR)/TestBench_opt4.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt4_tb

opt4_export: $(WORKDIR)/opt4.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_opt4.vhdl

test: opt4_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt4_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o opt4_tb

.PHONY: all clean test export build 
