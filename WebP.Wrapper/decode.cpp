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

void* DecodeARGB(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeARGB(buffer, data_size, width, height));
}

void* DecodeBGRA(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeBGRA(buffer, data_size, width, height));
}

void* DecodeRGB(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeRGB(buffer, data_size, width, height));
}

void* DecodeBGR(const void* data, size_t data_size, int* width, int* height) {
	uint8_t* buffer = (uint8_t*)data;
	return reinterpret_cast<void*>(WebPDecodeBGR(buffer, data_size, width, height));
}

void FreeDecoder(void* ptr) {
	WebPFree(ptr);
}