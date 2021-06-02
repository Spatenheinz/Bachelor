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

$(WORKDIR)/Round2.o: Round2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round2.vhdl

$(WORKDIR)/Round2_2.o: Round2_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round2_2.vhdl

$(WORKDIR)/Round3.o: Round3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round3.vhdl

$(WORKDIR)/Round3_2.o: Round3_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round3_2.vhdl

$(WORKDIR)/Round4.o: Round4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round4.vhdl

$(WORKDIR)/Round4_2.o: Round4_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round4_2.vhdl

$(WORKDIR)/Round5.o: Round5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round5.vhdl

$(WORKDIR)/Round5_2.o: Round5_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round5_2.vhdl

$(WORKDIR)/Round6.o: Round6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round6.vhdl

$(WORKDIR)/Round6_2.o: Round6_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round6_2.vhdl

$(WORKDIR)/Round7.o: Round7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round7.vhdl

$(WORKDIR)/Round7_2.o: Round7_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round7_2.vhdl

$(WORKDIR)/Round8.o: Round8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round8.vhdl

$(WORKDIR)/Round8_2.o: Round8_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round8_2.vhdl

$(WORKDIR)/Round9.o: Round9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round9.vhdl

$(WORKDIR)/Round9_2.o: Round9_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round9_2.vhdl

$(WORKDIR)/Round10.o: Round10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round10.vhdl

$(WORKDIR)/Round10_2.o: Round10_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round10_2.vhdl

$(WORKDIR)/Round11.o: Round11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round11.vhdl

$(WORKDIR)/Round11_2.o: Round11_2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round11_2.vhdl

$(WORKDIR)/Round11_3.o: Round11_3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round11_3.vhdl

$(WORKDIR)/Round11_4.o: Round11_4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Round11_4.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt3.o: opt3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt3.o $(WORKDIR)/Round1.o $(WORKDIR)/Round2.o $(WORKDIR)/Round2_2.o $(WORKDIR)/Round3.o $(WORKDIR)/Round3_2.o $(WORKDIR)/Round4.o $(WORKDIR)/Round4_2.o $(WORKDIR)/Round5.o $(WORKDIR)/Round5_2.o $(WORKDIR)/Round6.o $(WORKDIR)/Round6_2.o $(WORKDIR)/Round7.o $(WORKDIR)/Round7_2.o $(WORKDIR)/Round8.o $(WORKDIR)/Round8_2.o $(WORKDIR)/Round9.o $(WORKDIR)/Round9_2.o $(WORKDIR)/Round10.o $(WORKDIR)/Round10_2.o $(WORKDIR)/Round11.o $(WORKDIR)/Round11_2.o $(WORKDIR)/Round11_3.o $(WORKDIR)/Round11_4.o $(WORKDIR)/csv_util.o 
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
