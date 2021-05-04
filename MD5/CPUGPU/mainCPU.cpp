#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <sys/time.h>
#include <ctime>
#include "md5.h"
#include "timer.h"

#define HASHES 512
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

    struct timeval t_start, t_end, t_diff;
    len = strlen(msg);

	printf("Testing CPU:\n");
    // benchmark cpu
	gettimeofday(&t_start, NULL);
    for (i = 0; i < runs; i++) {
        md5((uint8_t*)msg, len, result);
    }
        gettimeofday(&t_end, NULL);
        timeval_subtract(&t_diff, &t_end, &t_start);
        float elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
        double MBsec = len / elapsed;
        printf("CPU runs in:       %.0f microsecs,   MB/sec: %.2f\n", elapsed, MBsec);
    // display result cpu
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");
    memset(result, 0, 16);

    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");
	gettimeofday(&t_start, NULL);
    for (i = 0; i < runs; i++) {

        for(int j = 0; j < HASHES; j++) {
            // printf("%d\n", msg[j+(len/HASHES)]);
            md5((uint8_t*)msg+(j*(len/HASHES)), (len/HASHES), result);
        }
    }
        gettimeofday(&t_end, NULL);
        timeval_subtract(&t_diff, &t_end, &t_start);
        elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
        MBsec = len / elapsed;
        printf("CPU runs in:       %.0f microsecs,   MB/sec: %.2f\n", elapsed, MBsec);
    // display result cpu
    for (i = 0; i < 16; i++)
        printf("%2.2x", result[i]);
    puts("");

    free(msg);
    return 0;
}
