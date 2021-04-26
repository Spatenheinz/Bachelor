#include <getopt.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <sys/time.h>
#include <ctime>
#include "kernel.cu.h"
#include "md5.h"

int main(int argc, char **argv) {
    size_t len;
    int i;
	int runs = 100;
    uint8_t result[16];

FILE *f = fopen("data.txt", "rb");
fseek(f, 0, SEEK_END);
long fsize = ftell(f);
fseek(f, 0, SEEK_SET);  /* same as rewind(f); */

char *msg = (char*)malloc(fsize + 1);
fread(msg, 1, fsize, f);
fclose(f);

msg[fsize] = 0;

    unsigned long int elapsed;
    struct timeval t_start, t_end, t_diff;
    len = strlen(msg);

    initHwd();
	/*************************************************************************/
    {
	printf("Testing CPU:\n\n");
    // benchmark cpu
	gettimeofday(&t_start, NULL);
    for (i = 0; i < runs; i++) {
        md5((uint8_t*)msg, len, result);
    }
        gettimeofday(&t_end, NULL);
        timeval_subtract(&t_diff, &t_end, &t_start);
        elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
        double GBsec = len * (2*sizeof(int) + sizeof(int)) * 1.0e-3f / elapsed;
        printf("CPU runs in:       %lu microsecs,   GB/sec: %.2f\n", elapsed, GBsec);
    // display result cpu
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");
    for (i = 0; i < 16; i++)
        result[i] = 0;
    }
    {
	printf("\n\nTesting GPU without memory transfers timed\n\n");
    // benchmark gpu
		MD5((uint8_t*)msg, len, result, runs);
    // display result gpu
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");
    }
    for (i = 0; i < 16; i++) {
        result[i] = 0;
    }
	printf("\n\nTesting GPU without memory transfers timed\n\n");
    // benchmark gpu
		Many_MD5((uint8_t*)msg, len, result, runs);
    // display result gpu
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");

    return 0;
}
