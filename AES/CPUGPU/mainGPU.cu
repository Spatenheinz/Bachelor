#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <sys/time.h>
#include <assert.h>
#include <ctime>
#include "aes.cu.h"
#include "timer.h"

#define NUM_THREADS 7
#define CLOSEST_MUL16(x) ((x+15) & -16);
int main(int argc, char **argv) {
	int runs = 100;
    if (argc == 2) {
        runs = atoi(argv[1]);
    }
    size_t len;
    int i;
    ctx context;

    FILE *f_in = fopen("data2.txt", "rb");
    fseek(f_in, 0, SEEK_END);
    long fsize = ftell(f_in);
    fseek(f_in, 0, SEEK_SET);

    char *msg = (char*)malloc(fsize + 1);
    fread(msg, 1, fsize, f_in);
    fclose(f_in);
    FILE *f_target = fopen("data.txt", "rb");
    char *target = (char*)malloc(fsize + 1);
    fread(target, 1, fsize, f_target);
    fclose(f_target);

    msg[fsize] = 0;

    target[fsize] = 0;
    len = strlen(msg);
    pthread_t threads[NUM_THREADS];
    uint8_t result[len];
    uint8_t key[] = {0x9f, 0x86, 0xD0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f,
                    0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15};
    uint32_t expanded_key[44];
    //                 {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09,
    //                 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f};
    // uint8_t msg[] = {0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99,
    //                 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff};
    // context.key = key;

    struct timeval t_start, t_end, t_diff;
	printf("Testing GPU:\n");
    // benchmark cpu
	gettimeofday(&t_start, NULL);
    for (i = 0; i < runs; i++) {
        expandkey(key, expanded_key);
        for(size_t j = 0; j < len; j +=16) {
            aes128(expanded_key, (uint8_t*)msg+j, result+j);
        }
    }
    // for (int k = 0; k < 16; k++)
    //     printf("\\x%2.2x", result[k]);
        gettimeofday(&t_end, NULL);
        timeval_subtract(&t_diff, &t_end, &t_start);
        float elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
        double MBsec = len / elapsed;
        printf("GPU runs in:       %.0f microsecs,   MB/sec: %.2f\n", elapsed, MBsec);
    free(target);
    free(context.res);
    free(msg);

    return 0;
}
