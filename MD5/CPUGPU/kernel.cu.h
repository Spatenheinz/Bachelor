#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdint.h>
#include "cuda_runtime.h"

#define md5_size 16

int MD5(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest, int runs);
int Many_MD5(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest, int runs);
int timeval_subtract(struct timeval *result, struct timeval *t2, struct timeval *t1);
void initHwd();
// Constants are the integer part of the sines of integers (in radians) * 2^32.

// leftrotate function definition
#define LEFTROTATE(x, c) (((x) << (c)) | ((x) >> (32 - (c))))

#define F(x, y, z) (((x) & (y)) | ((~x) & (z)))
#define G(x, y, z) (((x) & (z)) | ((y) & (~z)))
#define H(x, y, z) ((x) ^ (y) ^ (z))
#define I(x, y, z) ((y) ^ ((x) | (~z)))

#define FF(a, b, c, d, x, s, ac) \
  {(a) += F ((b), (c), (d)) + (uint)(x) + (uint)(ac); \
   (a) = LEFTROTATE ((a), (s)); \
   (a) += (b); \
  }
#define GG(a, b, c, d, x, s, ac) \
  {(a) += G ((b), (c), (d)) + (uint)(x) + (uint)(ac); \
   (a) = LEFTROTATE ((a), (s)); \
   (a) += (b); \
  }
#define HH(a, b, c, d, x, s, ac) \
  {(a) += H ((b), (c), (d)) + (uint)(x) + (uint)(ac); \
   (a) = LEFTROTATE ((a), (s)); \
   (a) += (b); \
  }
#define II(a, b, c, d, x, s, ac) \
  {(a) += I ((b), (c), (d)) + (uint)(x) + (uint)(ac); \
   (a) = LEFTROTATE ((a), (s)); \
   (a) += (b); \
  }
