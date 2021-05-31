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

$(WORKDIR)/MessageFormat.o: MessageFormat.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) MessageFormat.vhdl

$(WORKDIR)/FormatConverter.o: FormatConverter.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) FormatConverter.vhdl

$(WORKDIR)/Round1.o: Round1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round1.vhdl

$(WORKDIR)/Round2.o: Round2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round2.vhdl

$(WORKDIR)/Round3.o: Round3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round3.vhdl

$(WORKDIR)/Round4.o: Round4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round4.vhdl

$(WORKDIR)/Round5.o: Round5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round5.vhdl

$(WORKDIR)/Round6.o: Round6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round6.vhdl

$(WORKDIR)/Round7.o: Round7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round7.vhdl

$(WORKDIR)/Round8.o: Round8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round8.vhdl

$(WORKDIR)/Round9.o: Round9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round9.vhdl

$(WORKDIR)/Round10.o: Round10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round10.vhdl

$(WORKDIR)/Round11.o: Round11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round11.vhdl

$(WORKDIR)/Round12.o: Round12.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round12.vhdl

$(WORKDIR)/Round13.o: Round13.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round13.vhdl

$(WORKDIR)/Round14.o: Round14.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round14.vhdl

$(WORKDIR)/Round15.o: Round15.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round15.vhdl

$(WORKDIR)/Round16.o: Round16.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round16.vhdl

$(WORKDIR)/Combiner.o: Combiner.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Combiner.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt2.o: opt2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt2.o $(WORKDIR)/MessageFormat.o $(WORKDIR)/FormatConverter.o $(WORKDIR)/Round1.o $(WORKDIR)/Round2.o $(WORKDIR)/Round3.o $(WORKDIR)/Round4.o $(WORKDIR)/Round5.o $(WORKDIR)/Round6.o $(WORKDIR)/Round7.o $(WORKDIR)/Round8.o $(WORKDIR)/Round9.o $(WORKDIR)/Round10.o $(WORKDIR)/Round11.o $(WORKDIR)/Round12.o $(WORKDIR)/Round13.o $(WORKDIR)/Round14.o $(WORKDIR)/Round15.o $(WORKDIR)/Round16.o $(WORKDIR)/Combiner.o $(WORKDIR)/csv_util.o 
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
