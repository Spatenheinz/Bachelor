default: compile run


###########################################################
# CUDA directory:
CUDA_ROOT_DIR=/usr/local/cuda
##########################################################
# CC compiler options:
CC=gcc
CC_FLAGS=
CC_LIBS=
##########################################################
# NVCC compiler options:
NVCC=nvcc
NVCC_FLAGS=
NVCC_LIBS=
# CUDA library directory:
CUDA_LIB_DIR= -L$(CUDA_ROOT_DIR)/lib64
# CUDA include directory:
CUDA_INC_DIR= -I$(CUDA_ROOT_DIR)/include
# CUDA linking libraries:
CUDA_LINK_LIBS= -lcudart
##########################################################
## Project file structure ##
# Source file directory:
SRC_DIR = src
# Object file directory:
OBJ_DIR = bin
# Include header file diretory:
INC_DIR = include
##########################################################
# Target executable name:
CPU = run_cpu
# GPU = run_gpu

# Object files:
OBJS_CPU = $(OBJ_DIR)/mainCPU.o $(OBJ_DIR)/md5.o
# OBJS_GPU = $(OBJ_DIR)/mainGPU.o $(OBJ_DIR)/kernel.o
##########################################################

## Compile ##

# Link c++ and CUDA compiled object files to target executable:
$(CPU) : $(OBJS_CPU)
	$(CC) $(CC_FLAGS) $(OBJS_CPU) -o $@
# $(GPU) : $(OBJS_GPU)
# 	$(NVCC) $(CC_FLAGS) $(OBJS_GPU) -o $@
#$(CUDA_INC_DIR) $(CUDA_LIB_DIR) $(CUDA_LINK_LIBS)

# Compile main .cpp file to object files:
$(OBJ_DIR)/%.o : %.cpp
	$(CC) $(CC_FLAGS) -c $< -o $@

$(OBJ_DIR)/%.o : %.cu
	$(NVCC) $(NVCC_FLAGS) -c $< -o $@

# Compile C++ source files to object files:
# $(OBJ_DIR)/%.o : $(SRC_DIR)/%.cpp include/%.h
# 	$(CC) $(CC_FLAGS) -c $< -o $@

# Compile CUDA source files to object files:
$(OBJ_DIR)/%.o : %.cu %.cu.h
	$(NVCC) $(NVCC_FLAGS) -c $< -o $@ $(NVCC_LIBS)

compile: $(CPU) $(GPU)

run: $(CPU) $(GPU)
	./$(CPU)
	./$(GPU)

# Clean objects in object directory.
clean:
	$(RM) bin/* *.o $(CPU) $(GPU)
