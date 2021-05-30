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

$(WORKDIR)/Round1.o: Round1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round1.vhdl

$(WORKDIR)/Round2.o: Round2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round2.vhdl

$(WORKDIR)/Round3.o: Round3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round3.vhdl

$(WORKDIR)/Round4.o: Round4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round4.vhdl

$(WORKDIR)/Round5.o: Round5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round5.vhdl

$(WORKDIR)/Round6.o: Round6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round6.vhdl

$(WORKDIR)/Round7.o: Round7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round7.vhdl

$(WORKDIR)/Round8.o: Round8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round8.vhdl

$(WORKDIR)/Combiner.o: Combiner.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Combiner.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt3.o: opt3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)/MessageFormat.o $(WORKDIR)/FormatConverter.o $(WORKDIR)/Round1.o $(WORKDIR)/Round2.o $(WORKDIR)/Round3.o $(WORKDIR)/Round4.o $(WORKDIR)/Round5.o $(WORKDIR)/Round6.o $(WORKDIR)/Round7.o $(WORKDIR)/Round8.o $(WORKDIR)/Combiner.o $(WORKDIR)/csv_util.o 
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
