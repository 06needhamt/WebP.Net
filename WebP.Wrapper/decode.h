#pragma once

#include <webp/decode.h>

int GetDecoderVersion(void);

int GetInfo(const void* data, size_t data_size, int* width, int* height);

void* DecodeRGBA(const void* data, size_t data_size, int* width, int* height);

// Same as DecodeRGBA, but returning A, R, G, B, A, R, G, B... ordered data.
void* DecodeARGB(const void* data, size_t data_size, int* width, int* height);

// Same as DecodeRGBA, but returning B, G, R, A, B, G, R, A... ordered data.
void* DecodeBGRA(const void* data, size_t data_size, int* width, int* height);

// Same as DecodeRGBA, but returning R, G, B, R, G, B... ordered data.
// If the bitstream contains transparency, it is ignored.
void* DecodeRGB(const void* data, size_t data_size, int* width, int* height);

// Same as DecodeRGB, but returning B, G, R, B, G, R... ordered data.
void* DecodeBGR(const void* data, size_t data_size, int* width, int* height);