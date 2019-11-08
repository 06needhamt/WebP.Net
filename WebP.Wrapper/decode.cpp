#include "decode.h"

WEBP_NATIVE_CALL int __stdcall GetDecoderVersion() {
	return WebPGetDecoderVersion();
}

WEBP_NATIVE_CALL int __stdcall GetInfo(const uint8_t* data, size_t data_size, int* width, int* height) {
	return WebPGetInfo(data, data_size, width, height);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGBA(const uint8_t* data, size_t data_size, int* width, int* height) {
	return WebPDecodeRGBA(data, data_size, width, height);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeARGB(const uint8_t* data, size_t data_size, int* width, int* height) {
	return WebPDecodeARGB(data, data_size, width, height);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGRA(const uint8_t* data, size_t data_size, int* width, int* height) {
	return WebPDecodeBGRA(data, data_size, width, height);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGB(const uint8_t* data, size_t data_size, int* width, int* height) {
	return WebPDecodeRGB(data, data_size, width, height);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGR(const uint8_t* data, size_t data_size, int* width, int* height) {
	return WebPDecodeBGR(data, data_size, width, height);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGBAInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride) {
	return WebPDecodeRGBAInto(data, data_size, output_buffer, output_buffer_size, output_stride);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeARGBInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride) {
	return WebPDecodeARGBInto(data, data_size, output_buffer, output_buffer_size, output_stride);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGRAInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride) {
	return WebPDecodeBGRAInto(data, data_size, output_buffer, output_buffer_size, output_stride);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGBInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride) {
	return WebPDecodeRGBInto(data, data_size, output_buffer, output_buffer_size, output_stride);
}

WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGRInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride) {
	return WebPDecodeBGRInto(data, data_size, output_buffer, output_buffer_size, output_stride);
}

WEBP_NATIVE_CALL void __stdcall FreeDecoder(void* ptr) {
	WebPFree(ptr);
}