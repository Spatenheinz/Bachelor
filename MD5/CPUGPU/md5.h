#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdint.h>

// leftrotate function definition
#define LEFTROTATE(x, c) (((x) << (c)) | ((x) >> (32 - (c))))

void to_bytes(uint32_t val, uint8_t *bytes);

uint32_t to_int32(const uint8_t *bytes);

void md5(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest);
