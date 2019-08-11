#include "decode.h"

int GetDecoderVersion() {
	return WebPGetDecoderVersion();
}

int GetInfo(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*) data;
	return WebPGetInfo(buffer, data_size, width, height);
}

void* DecodeRGBA(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeRGBA(buffer, data_size, width, height));
}

// Same as DecodeRGBA, but returning A, R, G, B, A, R, G, B... ordered data.
void* DecodeARGB(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeARGB(buffer, data_size, width, height));
}

// Same as DecodeRGBA, but returning B, G, R, A, B, G, R, A... ordered data.
void* DecodeBGRA(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeBGRA(buffer, data_size, width, height));
}

// Same as DecodeRGBA, but returning R, G, B, R, G, B... ordered data.
// If the bitstream contains transparency, it is ignored.
void* DecodeRGB(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeRGB(buffer, data_size, width, height));
}

// Same as DecodeRGB, but returning B, G, R, B, G, R... ordered data.
void* DecodeBGR(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeBGR(buffer, data_size, width, height));
}