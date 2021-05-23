all: test export
testbench: opt5_tb
export: opt5_export
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

$(WORKDIR)/Types_opt5.o: Types_opt5.vhdl $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Types_opt5.vhdl

$(WORKDIR)/MessageFormat.o: MessageFormat.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) MessageFormat.vhdl

$(WORKDIR)/FormatConverter.o: FormatConverter.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) FormatConverter.vhdl

$(WORKDIR)/RoundF1.o: RoundF1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF1.vhdl

$(WORKDIR)/RoundF2.o: RoundF2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF2.vhdl

$(WORKDIR)/RoundF3.o: RoundF3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF3.vhdl

$(WORKDIR)/RoundF4.o: RoundF4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF4.vhdl

$(WORKDIR)/RoundF5.o: RoundF5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF5.vhdl

$(WORKDIR)/RoundF6.o: RoundF6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF6.vhdl

$(WORKDIR)/RoundF7.o: RoundF7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF7.vhdl

$(WORKDIR)/RoundF8.o: RoundF8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF8.vhdl

$(WORKDIR)/RoundF9.o: RoundF9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF9.vhdl

$(WORKDIR)/RoundF10.o: RoundF10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF10.vhdl

$(WORKDIR)/RoundF11.o: RoundF11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF11.vhdl

$(WORKDIR)/RoundF12.o: RoundF12.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF12.vhdl

$(WORKDIR)/RoundF13.o: RoundF13.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF13.vhdl

$(WORKDIR)/RoundF14.o: RoundF14.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF14.vhdl

$(WORKDIR)/RoundF15.o: RoundF15.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF15.vhdl

$(WORKDIR)/RoundF16.o: RoundF16.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundF16.vhdl

$(WORKDIR)/RoundG1.o: RoundG1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG1.vhdl

$(WORKDIR)/RoundG2.o: RoundG2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG2.vhdl

$(WORKDIR)/RoundG3.o: RoundG3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG3.vhdl

$(WORKDIR)/RoundG4.o: RoundG4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG4.vhdl

$(WORKDIR)/RoundG5.o: RoundG5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG5.vhdl

$(WORKDIR)/RoundG6.o: RoundG6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG6.vhdl

$(WORKDIR)/RoundG7.o: RoundG7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG7.vhdl

$(WORKDIR)/RoundG8.o: RoundG8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG8.vhdl

$(WORKDIR)/RoundG9.o: RoundG9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG9.vhdl

$(WORKDIR)/RoundG10.o: RoundG10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG10.vhdl

$(WORKDIR)/RoundG11.o: RoundG11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG11.vhdl

$(WORKDIR)/RoundG12.o: RoundG12.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG12.vhdl

$(WORKDIR)/RoundG13.o: RoundG13.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG13.vhdl

$(WORKDIR)/RoundG14.o: RoundG14.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG14.vhdl

$(WORKDIR)/RoundG15.o: RoundG15.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG15.vhdl

$(WORKDIR)/RoundG16.o: RoundG16.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundG16.vhdl

$(WORKDIR)/RoundH1.o: RoundH1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH1.vhdl

$(WORKDIR)/RoundH2.o: RoundH2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH2.vhdl

$(WORKDIR)/RoundH3.o: RoundH3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH3.vhdl

$(WORKDIR)/RoundH4.o: RoundH4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH4.vhdl

$(WORKDIR)/RoundH5.o: RoundH5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH5.vhdl

$(WORKDIR)/RoundH6.o: RoundH6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH6.vhdl

$(WORKDIR)/RoundH7.o: RoundH7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH7.vhdl

$(WORKDIR)/RoundH8.o: RoundH8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH8.vhdl

$(WORKDIR)/RoundH9.o: RoundH9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH9.vhdl

$(WORKDIR)/RoundH10.o: RoundH10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH10.vhdl

$(WORKDIR)/RoundH11.o: RoundH11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH11.vhdl

$(WORKDIR)/RoundH12.o: RoundH12.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH12.vhdl

$(WORKDIR)/RoundH13.o: RoundH13.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH13.vhdl

$(WORKDIR)/RoundH14.o: RoundH14.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH14.vhdl

$(WORKDIR)/RoundH15.o: RoundH15.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH15.vhdl

$(WORKDIR)/RoundH16.o: RoundH16.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundH16.vhdl

$(WORKDIR)/RoundI1.o: RoundI1.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI1.vhdl

$(WORKDIR)/RoundI2.o: RoundI2.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI2.vhdl

$(WORKDIR)/RoundI3.o: RoundI3.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI3.vhdl

$(WORKDIR)/RoundI4.o: RoundI4.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI4.vhdl

$(WORKDIR)/RoundI5.o: RoundI5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI5.vhdl

$(WORKDIR)/RoundI6.o: RoundI6.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI6.vhdl

$(WORKDIR)/RoundI7.o: RoundI7.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI7.vhdl

$(WORKDIR)/RoundI8.o: RoundI8.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI8.vhdl

$(WORKDIR)/RoundI9.o: RoundI9.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI9.vhdl

$(WORKDIR)/RoundI10.o: RoundI10.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI10.vhdl

$(WORKDIR)/RoundI11.o: RoundI11.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI11.vhdl

$(WORKDIR)/RoundI12.o: RoundI12.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI12.vhdl

$(WORKDIR)/RoundI13.o: RoundI13.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI13.vhdl

$(WORKDIR)/RoundI14.o: RoundI14.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI14.vhdl

$(WORKDIR)/RoundI15.o: RoundI15.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI15.vhdl

$(WORKDIR)/RoundI16.o: RoundI16.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) RoundI16.vhdl

$(WORKDIR)/Combiner.o: Combiner.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Combiner.vhdl

$(WORKDIR)/csv_util.o: csv_util.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) csv_util.vhdl

$(WORKDIR)/opt5.o: opt5.vhdl $(WORKDIR)/system_types.o $(WORKDIR)/Types_opt5.o $(WORKDIR)/MessageFormat.o $(WORKDIR)/FormatConverter.o $(WORKDIR)/RoundF1.o $(WORKDIR)/RoundF2.o $(WORKDIR)/RoundF3.o $(WORKDIR)/RoundF4.o $(WORKDIR)/RoundF5.o $(WORKDIR)/RoundF6.o $(WORKDIR)/RoundF7.o $(WORKDIR)/RoundF8.o $(WORKDIR)/RoundF9.o $(WORKDIR)/RoundF10.o $(WORKDIR)/RoundF11.o $(WORKDIR)/RoundF12.o $(WORKDIR)/RoundF13.o $(WORKDIR)/RoundF14.o $(WORKDIR)/RoundF15.o $(WORKDIR)/RoundF16.o $(WORKDIR)/RoundG1.o $(WORKDIR)/RoundG2.o $(WORKDIR)/RoundG3.o $(WORKDIR)/RoundG4.o $(WORKDIR)/RoundG5.o $(WORKDIR)/RoundG6.o $(WORKDIR)/RoundG7.o $(WORKDIR)/RoundG8.o $(WORKDIR)/RoundG9.o $(WORKDIR)/RoundG10.o $(WORKDIR)/RoundG11.o $(WORKDIR)/RoundG12.o $(WORKDIR)/RoundG13.o $(WORKDIR)/RoundG14.o $(WORKDIR)/RoundG15.o $(WORKDIR)/RoundG16.o $(WORKDIR)/RoundH1.o $(WORKDIR)/RoundH2.o $(WORKDIR)/RoundH3.o $(WORKDIR)/RoundH4.o $(WORKDIR)/RoundH5.o $(WORKDIR)/RoundH6.o $(WORKDIR)/RoundH7.o $(WORKDIR)/RoundH8.o $(WORKDIR)/RoundH9.o $(WORKDIR)/RoundH10.o $(WORKDIR)/RoundH11.o $(WORKDIR)/RoundH12.o $(WORKDIR)/RoundH13.o $(WORKDIR)/RoundH14.o $(WORKDIR)/RoundH15.o $(WORKDIR)/RoundH16.o $(WORKDIR)/RoundI1.o $(WORKDIR)/RoundI2.o $(WORKDIR)/RoundI3.o $(WORKDIR)/RoundI4.o $(WORKDIR)/RoundI5.o $(WORKDIR)/RoundI6.o $(WORKDIR)/RoundI7.o $(WORKDIR)/RoundI8.o $(WORKDIR)/RoundI9.o $(WORKDIR)/RoundI10.o $(WORKDIR)/RoundI11.o $(WORKDIR)/RoundI12.o $(WORKDIR)/RoundI13.o $(WORKDIR)/RoundI14.o $(WORKDIR)/RoundI15.o $(WORKDIR)/RoundI16.o $(WORKDIR)/Combiner.o $(WORKDIR)/csv_util.o 
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt5.vhdl

$(WORKDIR)/TestBench_opt5.o: TestBench_opt5.vhdl $(WORKDIR)/opt5.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) TestBench_opt5.vhdl

opt5_tb: $(WORKDIR)/TestBench_opt5.o
	ghdl -e --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt5_tb

opt5_export: $(WORKDIR)/opt5.o
	ghdl -a --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) Export_opt5.vhdl

test: opt5_tb
	cp "../trace.csv" .
	ghdl -r --std=$(STD) --ieee=$(IEEE) --workdir=$(WORKDIR) $(FLAGS) opt5_tb --vcd=$(VCDFILE)

clean:
	rm -rf $(WORKDIR) *.o opt5_tb

.PHONY: all clean test export build 
