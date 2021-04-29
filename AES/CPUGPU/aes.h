#pragma once
#include <stdlib.h>
#include <string.h>
#include <stdint.h>

void aes128(const uint32_t *expanded_key, const uint8_t *initial_msg, uint8_t *cypher);
void* threaded_aes(void *context);
void expandkey(const uint8_t *key, uint32_t* expanded_key);
typedef struct CTX {
    uint32_t* key;
    uint8_t* msg;
    uint8_t* res;
} ctx;

typedef struct wrapper {
    ctx* data;
    int start;
    int end;
} offset_wrapper;
