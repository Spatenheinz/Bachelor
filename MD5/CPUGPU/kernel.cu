#include "kernel.cu.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <sys/time.h>
#define DEBUG_INFO  true
uint32_t MAX_HWDTH;
uint32_t MAX_BLOCK;
uint32_t MAX_SHMEM;

cudaDeviceProp prop;
void initHwd() {
    int nDevices;
    cudaGetDeviceCount(&nDevices);
    cudaGetDeviceProperties(&prop, 0);
    MAX_HWDTH = prop.maxThreadsPerMultiProcessor * prop.multiProcessorCount;
    MAX_BLOCK = prop.maxThreadsPerBlock;
    MAX_SHMEM = prop.sharedMemPerBlock;

    if (DEBUG_INFO) {
        printf("Device name: %s\n", prop.name);
        printf("Number of hardware threads: %d\n", MAX_HWDTH);
        printf("Max block size: %d\n", MAX_BLOCK);
        printf("Shared memory size: %d\n", MAX_SHMEM);
        puts("====");
    }
}

// Bad globals
uint32_t *dev_k = 0;
uint32_t *dev_r = 0;
int timeval_subtract(struct timeval *result, struct timeval *t2, struct timeval *t1)
{
    unsigned int resolution=1000000;
    long int diff = (t2->tv_usec + resolution * t2->tv_sec) - (t1->tv_usec + resolution * t1->tv_sec);
    result->tv_sec = diff / resolution;
    result->tv_usec = diff % resolution;
    return (diff<0);
}

#define gpuErrchk(ans) { gpuAssert((ans), __FILE__, __LINE__); }
inline void gpuAssert(cudaError_t code, const char* file, int line, bool abort = true)
{
    if (code != cudaSuccess)
    {
        fprintf(stderr, "GPUassert: %s %s %d\n", cudaGetErrorString(code), file, line);
        if (abort) exit(code);
    }
}
__device__ void cuda_to_bytes(uint32_t val, uint8_t *bytes)
{
    bytes[0] = (uint8_t) val;
    bytes[1] = (uint8_t) (val >> 8);
    bytes[2] = (uint8_t) (val >> 16);
    bytes[3] = (uint8_t) (val >> 24);
}

__device__ uint32_t cuda_to_int32(const uint8_t *bytes)
{
    return (uint32_t) bytes[0]
        | ((uint32_t) bytes[1] << 8)
        | ((uint32_t) bytes[2] << 16)
        | ((uint32_t) bytes[3] << 24);
}

__global__ void md5kernel(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest) {
    // These vars will contain the hash
    uint32_t A, B, C, D;
    // Message (to prepare)
    uint8_t *msg = NULL;
    size_t new_len, offset;
    uint32_t w[16];
    uint32_t a, b, c, d, i;
    // Initialize variables - simple count in nibbles:
    A = 0x67452301;
    B = 0xefcdab89;
    C = 0x98badcfe;
    D = 0x10325476;
    //Pre-processing:
    //append "1" bit to message
    //append "0" bits until message length in bits ≡ 448 (mod 512)
    //append length mod (2^64) to message
    for (new_len = initial_len + 1; new_len % (512/8) != 448/8; new_len++)
        ;
    msg = (uint8_t *)malloc(new_len + 8);
    memcpy(msg, initial_msg, initial_len);
    msg[initial_len] = 0x80; // append the "1" bit; most significant bit is "first"
    #pragma unroll
    for (offset = initial_len + 1; offset < new_len; offset++)
        msg[offset] = 0; // append "0" bits
    // append the len in bits at the end of the buffer.
    cuda_to_bytes(initial_len*8, msg + new_len);
    // initial_len>>29 == initial_len*8>>32, but avoids overflow.
    cuda_to_bytes(initial_len>>29, msg + new_len + 4);
    // Process the message in successive 512-bit chunks:
    //for each 512-bit chunk of message:
    #pragma unroll
    for(offset=0; offset<new_len; offset += (512/8)) {
        // break chunk into sixteen 32-bit words w[j], 0 ≤ j ≤ 15
        #pragma unroll
        for (i = 0; i < 16; i++)
            w[i] = cuda_to_int32(msg + offset + i*4);
        // Initialize hash value for this chunk:
        a = A;
        b = B;
        c = C;
        d = D;
        // Main loop:
        FF ( a, b, c, d, w[ 0], 7, 3614090360); /* 1 */ FF ( d, a, b, c, w[ 1], 12, 3905402710); /* 2 */
        FF ( c, d, a, b, w[ 2], 17,  606105819); /* 3 */FF ( b, c, d, a, w[ 3], 22, 3250441966); /* 4 */
        FF ( a, b, c, d, w[ 4], 7, 4118548399); /* 5 */ FF ( d, a, b, c, w[ 5], 12, 1200080426); /* 6 */
        FF ( c, d, a, b, w[ 6], 17, 2821735955); /* 7 */FF ( b, c, d, a, w[ 7], 22, 4249261313); /* 8 */
        FF ( a, b, c, d, w[ 8], 7, 1770035416); /* 9 */ FF ( d, a, b, c, w[ 9], 12, 2336552879); /* 10 */
        FF ( c, d, a, b, w[10], 17, 4294925233); /* 11 */FF ( b, c, d, a, w[11], 22, 2304563134); /* 12 */
        FF ( a, b, c, d, w[12], 7, 1804603682); /* 13 */FF ( d, a, b, c, w[13], 12, 4254626195); /* 14 */
        FF ( c, d, a, b, w[14], 17, 2792965006); /* 15 */FF ( b, c, d, a, w[15], 22, 1236535329); /* 16 */
        GG ( a, b, c, d, w[ 1], 5, 4129170786); /* 17 */GG ( d, a, b, c, w[ 6], 9, 3225465664); /* 18 */
        GG ( c, d, a, b, w[11], 14,  643717713); /* 19 */GG ( b, c, d, a, w[ 0], 20, 3921069994); /* 20 */
        GG ( a, b, c, d, w[ 5], 5, 3593408605); /* 21 */GG ( d, a, b, c, w[10], 9,   38016083); /* 22 */
        GG ( c, d, a, b, w[15], 14, 3634488961); /* 23 */GG ( b, c, d, a, w[ 4], 20, 3889429448); /* 24 */
        GG ( a, b, c, d, w[ 9], 5,  568446438); /* 25 */ GG ( d, a, b, c, w[14], 9, 3275163606); /* 26 */
        GG ( c, d, a, b, w[ 3], 14, 4107603335); /* 27 */GG ( b, c, d, a, w[ 8], 20, 1163531501); /* 28 */
        GG ( a, b, c, d, w[13], 5, 2850285829); /* 29 */GG ( d, a, b, c, w[ 2], 9, 4243563512); /* 30 */
        GG ( c, d, a, b, w[ 7], 14, 1735328473); /* 31 */GG ( b, c, d, a, w[12], 20, 2368359562); /* 32 */
        HH ( a, b, c, d, w[ 5], 4, 4294588738); /* 33 */HH ( d, a, b, c, w[ 8], 11, 2272392833); /* 34 */
        HH ( c, d, a, b, w[11], 16, 1839030562); /* 35 */HH ( b, c, d, a, w[14], 23, 4259657740); /* 36 */
        HH ( a, b, c, d, w[ 1], 4, 2763975236); /* 37 */HH ( d, a, b, c, w[ 4], 11, 1272893353); /* 38 */
        HH ( c, d, a, b, w[ 7], 16, 4139469664); /* 39 */HH ( b, c, d, a, w[10], 23, 3200236656); /* 40 */
        HH ( a, b, c, d, w[13], 4,  681279174); /* 41 */HH ( d, a, b, c, w[ 0], 11, 3936430074); /* 42 */
        HH ( c, d, a, b, w[ 3], 16, 3572445317); /* 43 */HH ( b, c, d, a, w[ 6], 23,   76029189);/* 44 */
        HH ( a, b, c, d, w[ 9], 4, 3654602809); /* 45 */HH ( d, a, b, c, w[12], 11, 3873151461); /* 46 */
        HH ( c, d, a, b, w[15], 16,  530742520); /* 47 */HH ( b, c, d, a, w[ 2], 23, 3299628645); /* 48 */
        II ( a, b, c, d, w[ 0], 6, 4096336452); /* 49 */II ( d, a, b, c, w[ 7], 10, 1126891415); /* 50 */
        II ( c, d, a, b, w[14], 15, 2878612391); /* 51 */II ( b, c, d, a, w[ 5], 21, 4237533241); /* 52 */
        II ( a, b, c, d, w[12], 6, 1700485571); /* 53 */II ( d, a, b, c, w[ 3], 10, 2399980690); /* 54 */
        II ( c, d, a, b, w[10], 15, 4293915773); /* 55 */II ( b, c, d, a, w[ 1], 21, 2240044497); /* 56 */
        II ( a, b, c, d, w[ 8], 6, 1873313359); /* 57 */II ( d, a, b, c, w[15], 10, 4264355552); /* 58 */
        II ( c, d, a, b, w[ 6], 15, 2734768916); /* 59 */II ( b, c, d, a, w[13], 21, 1309151649); /* 60 */
        II ( a, b, c, d, w[ 4], 6, 4149444226); /* 61 */II ( d, a, b, c, w[11], 10, 3174756917); /* 62 */
        II ( c, d, a, b, w[ 2], 15,  718787259); /* 63 */II ( b, c, d, a, w[ 9], 21, 3951481745); /* 64 */
        // Add this chunk's hash to result so far:
        A += a;
        B += b;
        C += c;
        D += d;
    }

    // cleanup
    free(msg);
    //var char digest[16] := A append B append C append D //(Output is in little-endian)
    cuda_to_bytes(A, digest);
    cuda_to_bytes(B, digest + 4);
    cuda_to_bytes(C, digest + 8);
    cuda_to_bytes(D, digest + 12);
}
__global__ void many_md5kernel(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest) {
    // These vars will contain the hash
    uint32_t A, B, C, D;
    // Message (to prepare)
    uint8_t *msg = NULL;
    size_t new_len, offset;
    uint32_t w[16];
    uint32_t a, b, c, d, i;
    // Initialize variables - simple count in nibbles:
    A = 0x67452301;
    B = 0xefcdab89;
    C = 0x98badcfe;
    D = 0x10325476;
    //Pre-processing:
    //append "1" bit to message
    //append "0" bits until message length in bits ≡ 448 (mod 512)
    //append length mod (2^64) to message
    initial_len /= gridDim.x;
    for (new_len = initial_len + 1; new_len % (512/8) != 448/8; new_len++)
        ;

    msg = (uint8_t *)malloc(new_len + 8);
    memcpy(msg, (initial_msg+blockIdx.x*gridDim.x), initial_len);
    msg[initial_len] = 0x80; // append the "1" bit; most significant bit is "first"
    #pragma unroll
    for (offset = initial_len + 1; offset < new_len; offset++)
        msg[offset] = 0; // append "0" bits
    // append the len in bits at the end of the buffer.
    cuda_to_bytes(initial_len*8, msg + new_len);
    // initial_len>>29 == initial_len*8>>32, but avoids overflow.
    cuda_to_bytes(initial_len>>29, msg + new_len + 4);
    // Process the message in successive 512-bit chunks:
    //for each 512-bit chunk of message:
    #pragma unroll
    for(offset=0; offset<new_len; offset += (512/8)) {
        // break chunk into sixteen 32-bit words w[j], 0 ≤ j ≤ 15
        #pragma unroll
        for (i = 0; i < 16; i++)
            w[i] = cuda_to_int32(msg + offset + i*4);
        // Initialize hash value for this chunk:
        a = A;
        b = B;
        c = C;
        d = D;
        // Main loop:
        FF ( a, b, c, d, w[ 0], 7, 3614090360); /* 1 */ FF ( d, a, b, c, w[ 1], 12, 3905402710); /* 2 */
        FF ( c, d, a, b, w[ 2], 17,  606105819); /* 3 */FF ( b, c, d, a, w[ 3], 22, 3250441966); /* 4 */
        FF ( a, b, c, d, w[ 4], 7, 4118548399); /* 5 */ FF ( d, a, b, c, w[ 5], 12, 1200080426); /* 6 */
        FF ( c, d, a, b, w[ 6], 17, 2821735955); /* 7 */FF ( b, c, d, a, w[ 7], 22, 4249261313); /* 8 */
        FF ( a, b, c, d, w[ 8], 7, 1770035416); /* 9 */ FF ( d, a, b, c, w[ 9], 12, 2336552879); /* 10 */
        FF ( c, d, a, b, w[10], 17, 4294925233); /* 11 */FF ( b, c, d, a, w[11], 22, 2304563134); /* 12 */
        FF ( a, b, c, d, w[12], 7, 1804603682); /* 13 */FF ( d, a, b, c, w[13], 12, 4254626195); /* 14 */
        FF ( c, d, a, b, w[14], 17, 2792965006); /* 15 */FF ( b, c, d, a, w[15], 22, 1236535329); /* 16 */
        GG ( a, b, c, d, w[ 1], 5, 4129170786); /* 17 */GG ( d, a, b, c, w[ 6], 9, 3225465664); /* 18 */
        GG ( c, d, a, b, w[11], 14,  643717713); /* 19 */GG ( b, c, d, a, w[ 0], 20, 3921069994); /* 20 */
        GG ( a, b, c, d, w[ 5], 5, 3593408605); /* 21 */GG ( d, a, b, c, w[10], 9,   38016083); /* 22 */
        GG ( c, d, a, b, w[15], 14, 3634488961); /* 23 */GG ( b, c, d, a, w[ 4], 20, 3889429448); /* 24 */
        GG ( a, b, c, d, w[ 9], 5,  568446438); /* 25 */ GG ( d, a, b, c, w[14], 9, 3275163606); /* 26 */
        GG ( c, d, a, b, w[ 3], 14, 4107603335); /* 27 */GG ( b, c, d, a, w[ 8], 20, 1163531501); /* 28 */
        GG ( a, b, c, d, w[13], 5, 2850285829); /* 29 */GG ( d, a, b, c, w[ 2], 9, 4243563512); /* 30 */
        GG ( c, d, a, b, w[ 7], 14, 1735328473); /* 31 */GG ( b, c, d, a, w[12], 20, 2368359562); /* 32 */
        HH ( a, b, c, d, w[ 5], 4, 4294588738); /* 33 */HH ( d, a, b, c, w[ 8], 11, 2272392833); /* 34 */
        HH ( c, d, a, b, w[11], 16, 1839030562); /* 35 */HH ( b, c, d, a, w[14], 23, 4259657740); /* 36 */
        HH ( a, b, c, d, w[ 1], 4, 2763975236); /* 37 */HH ( d, a, b, c, w[ 4], 11, 1272893353); /* 38 */
        HH ( c, d, a, b, w[ 7], 16, 4139469664); /* 39 */HH ( b, c, d, a, w[10], 23, 3200236656); /* 40 */
        HH ( a, b, c, d, w[13], 4,  681279174); /* 41 */HH ( d, a, b, c, w[ 0], 11, 3936430074); /* 42 */
        HH ( c, d, a, b, w[ 3], 16, 3572445317); /* 43 */HH ( b, c, d, a, w[ 6], 23,   76029189);/* 44 */
        HH ( a, b, c, d, w[ 9], 4, 3654602809); /* 45 */HH ( d, a, b, c, w[12], 11, 3873151461); /* 46 */
        HH ( c, d, a, b, w[15], 16,  530742520); /* 47 */HH ( b, c, d, a, w[ 2], 23, 3299628645); /* 48 */
        II ( a, b, c, d, w[ 0], 6, 4096336452); /* 49 */II ( d, a, b, c, w[ 7], 10, 1126891415); /* 50 */
        II ( c, d, a, b, w[14], 15, 2878612391); /* 51 */II ( b, c, d, a, w[ 5], 21, 4237533241); /* 52 */
        II ( a, b, c, d, w[12], 6, 1700485571); /* 53 */II ( d, a, b, c, w[ 3], 10, 2399980690); /* 54 */
        II ( c, d, a, b, w[10], 15, 4293915773); /* 55 */II ( b, c, d, a, w[ 1], 21, 2240044497); /* 56 */
        II ( a, b, c, d, w[ 8], 6, 1873313359); /* 57 */II ( d, a, b, c, w[15], 10, 4264355552); /* 58 */
        II ( c, d, a, b, w[ 6], 15, 2734768916); /* 59 */II ( b, c, d, a, w[13], 21, 1309151649); /* 60 */
        II ( a, b, c, d, w[ 4], 6, 4149444226); /* 61 */II ( d, a, b, c, w[11], 10, 3174756917); /* 62 */
        II ( c, d, a, b, w[ 2], 15,  718787259); /* 63 */II ( b, c, d, a, w[ 9], 21, 3951481745); /* 64 */
        // Add this chunk's hash to result so far:
        A += a;
        B += b;
        C += c;
        D += d;
    }

    // cleanup
    free(msg);
    //var char digest[16] := A append B append C append D //(Output is in little-endian)
    cuda_to_bytes(A, digest);
    cuda_to_bytes(B, digest + 4);
    cuda_to_bytes(C, digest + 8);
    cuda_to_bytes(D, digest + 12);
}

// Helper function for using CUDA to compute MD5 with timing
int MD5(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest, int runs)
{
    unsigned long int elapsed;
    struct timeval t_start, t_end, t_diff;
    uint8_t *dev_initial_msg = 0;
    uint8_t *dev_digest = 0;
    // Choose which GPU to run on, change this on a multi-GPU system.
    gpuErrchk(cudaSetDevice(0));
    gpuErrchk(cudaMalloc((void**)&dev_digest, md5_size * sizeof(uint8_t)));
    gpuErrchk(cudaMalloc((void**)&dev_initial_msg, initial_len * sizeof(uint8_t)));
    // Copy input vectors from host memory to GPU buffers.
    gpuErrchk(cudaMemcpy(dev_initial_msg, initial_msg, initial_len * sizeof(uint8_t), cudaMemcpyHostToDevice));
	gettimeofday(&t_start, NULL);
    for (int i = 0; i < runs; i++) {
        md5kernel<<<1, 1>>>(dev_initial_msg, initial_len, dev_digest);
    }
    gpuErrchk(cudaDeviceSynchronize());
        gettimeofday(&t_end, NULL);
        timeval_subtract(&t_diff, &t_end, &t_start);
        elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
        double GBsec = initial_len * (2*sizeof(int) + sizeof(int)) * 1.0e-3f / elapsed;
        printf("GPU2 runs in:       %lu microsecs,   GB/sec: %.2f\n", elapsed, GBsec);

    // Check for any errors launching the kernel
    gpuErrchk(cudaGetLastError());
    // cudaDeviceSynchronize waits for the kernel to finish, and returns
    // any errors encountered during the launch.

    // Copy output vector from GPU buffer to host memory.
    gpuErrchk(cudaMemcpy(digest, dev_digest, md5_size * sizeof(uint8_t), cudaMemcpyDeviceToHost));

    gpuErrchk(cudaFree(dev_digest));
    gpuErrchk(cudaFree(dev_initial_msg));

    return 0;
}



int Many_MD5(const uint8_t *initial_msg, size_t initial_len, uint8_t *digest, int runs)
{
    unsigned long int elapsed;
    struct timeval t_start, t_end, t_diff;
    uint8_t *dev_initial_msg = 0;
    uint8_t *dev_digest = 0;

    // Choose which GPU to run on, change this on a multi-GPU system.
    gpuErrchk(cudaSetDevice(0));

    gpuErrchk(cudaMalloc((void**)&dev_digest, md5_size * sizeof(uint8_t)));
    gpuErrchk(cudaMalloc((void**)&dev_initial_msg, initial_len * sizeof(uint8_t)));
    // Copy input vectors from host memory to GPU buffers.
    gpuErrchk(cudaMemcpy(dev_initial_msg, initial_msg, initial_len * sizeof(uint8_t), cudaMemcpyHostToDevice));

    // Launch a kernel on the GPU with one thread for each element.
	gettimeofday(&t_start, NULL);
    for (int i = 0; i < runs; i++) {
        many_md5kernel<<<512, 1>>>(dev_initial_msg, initial_len, dev_digest);
    }
    gpuErrchk(cudaDeviceSynchronize());
        gettimeofday(&t_end, NULL);
        timeval_subtract(&t_diff, &t_end, &t_start);
        elapsed = (t_diff.tv_sec*1e6+t_diff.tv_usec) / runs;
        double GBsec = initial_len * (2*sizeof(int) + sizeof(int)) * 1.0e-3f / elapsed;
        printf("GPU2 runs in:       %lu microsecs,   GB/sec: %.2f\n", elapsed, GBsec);

    // Check for any errors launching the kernel
    gpuErrchk(cudaGetLastError());
    // cudaDeviceSynchronize waits for the kernel to finish, and returns
    // any errors encountered during the launch.

    // Copy output vector from GPU buffer to host memory.
    gpuErrchk(cudaMemcpy(digest, dev_digest, md5_size * sizeof(uint8_t), cudaMemcpyDeviceToHost));

    gpuErrchk(cudaFree(dev_digest));
    gpuErrchk(cudaFree(dev_initial_msg));

    return 0;
}
