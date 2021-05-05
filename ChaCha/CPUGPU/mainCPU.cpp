#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <sys/time.h>
#include <ctime>
#include "chacha.h"
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
    //inputfile made with tr
    // FILE *f_in = fopen("data2.txt", "rb");
    // fseek(f_in, 0, SEEK_END);
    // long fsize = ftell(f_in);
    // fseek(f_in, 0, SEEK_SET);

    // char *msg = (char*)malloc(fsize + 1);
    // fread(msg, 1, fsize, f_in);
    // fclose(f_in);
    //target bytes created by openssl
    // FILE *f_target = fopen("data.txt", "rb");
    // char *target = (char*)malloc(fsize + 1);
    // fread(target, 1, fsize, f_target);
    // fclose(f_target);

    // msg[fsize] = 0;

    // target[fsize] = 0;
    // len = strlen(msg);
    // pthread_t threads[NUM_THREADS];
    // uint8_t result[len];
    uint8_t key[] = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09,
    0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13,
    0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f};
    uint8_t nonce[] = {0x00,0x00,0x00,0x09,0x00,0x00,0x00,0x4a,0x00,0x00, 0x00, 0x00};

    struct timeval t_start, t_end, t_diff;
	printf("Testing CPU:\n");
    // benchmark cpu
	gettimeofday(&t_start, NULL);
    for (i = 0; i < runs; i++) {
        expandkey(key, expanded_key);
        for(size_t j = 0; j < len; j +=16) {
            chacha20(expanded_key, (uint8_t*)msg, result);
        }
        // for(size_t j = 0; j < len; j +=16) {
        //     chacha20(expanded_key, (uint8_t*)msg+j, result+j);
        // }
    }
    gettimeofday(&t_end, NULL);
    timeval_subtract(&t_diff, &t_end, &t_start);
    float elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
    double MBsec = len / elapsed;
    printf("CPU runs in:       %.0f microsecs,   MB/sec: %.2f\n", elapsed, MBsec);
    for (size_t i = 0; i < len; i++){
        char res1 = result[i];
        char res2 = target[i];
        if (res1 != res2) {
            printf("ERROR at result vector index %d (cpu, openssl): (%x, %x)\n", i, res1, res2);
            break;
        }
    }
    //setup the context for threads
    context.msg = (uint8_t*) msg;
    context.res = (uint8_t*) malloc(fsize+1);
    context.key = expanded_key;
    offset_wrapper thread_ctx[NUM_THREADS];
    gettimeofday(&t_start, NULL);
    for(i = 0; i < runs; i++) {
        for(int j = 0; j < NUM_THREADS; j++) {
            thread_ctx[j].start = CLOSEST_MUL16(j*(len/NUM_THREADS));
            thread_ctx[j].end   = CLOSEST_MUL16((j+1)*(len/NUM_THREADS)-1);
            thread_ctx[j].data = &context;
                pthread_create(&threads[j], NULL, threaded_aes, &thread_ctx[j]);
        }
        for(int j = 0; j < NUM_THREADS; j++) {
            pthread_join(threads[j],NULL);
        }
    }
    gettimeofday(&t_end, NULL);
    timeval_subtract(&t_diff, &t_end, &t_start);
    elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
    MBsec = len / elapsed;
    printf("threaded CPU runs in:       %.0f microsecs,   MB/sec: %.2f\n", elapsed, MBsec);
    for (size_t i = 0; i < len; i++){
        char res1 = context.res[i];
        char res2 = target[i];
        if (res1 != res2) {
            printf("ERROR at result vector index %d (cpu-threaded, openssl): (%x, %x)\n", i, res1, res2);
            break;
        }
    }
    free(target);
    free(context.res);
    free(msg);

    return 0;
}
