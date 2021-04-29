#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <sys/time.h>
#include <ctime>
#include "kernel.cu.h"
#include "timer.h"

int main(int argc, char **argv) {
	int runs = 100;
    if (argc == 2) {
        runs = atoi(argv[1]);
    }
    size_t len;
    int i;
    uint8_t result[16];

    FILE *f = fopen("data.txt", "rb");
    fseek(f, 0, SEEK_END);
    long fsize = ftell(f);
    fseek(f, 0, SEEK_SET);

    char *msg = (char*)malloc(fsize + 1);
    fread(msg, 1, fsize, f);
    fclose(f);

    msg[fsize] = 0;

    len = strlen(msg);

	printf("\n\nTesting GPU without much parallelization\n");
    // benchmark gpu
		MD5((uint8_t*)msg, len, result, runs);
    // display result gpu
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");
    for (i = 0; i < 16; i++) {
        result[i] = 0;
    }
	printf("\n\nTesting GPU with many smaller hashes\n");
		Many_MD5((uint8_t*)msg, len, result, runs);
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");
    free(msg);
    return 0;
}
