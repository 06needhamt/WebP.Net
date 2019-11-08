#pragma once

#ifndef WEBP_NATIVE_CALL
#define WEBP_NATIVE_CALL __declspec(dllexport) 
#endif 

#include <webp/decode.h>

extern "C" {

	// Return the decoder's version number, packed in hexadecimal using 8bits for
	// each of major/minor/revision. E.g: v2.5.7 is 0x020507.
	WEBP_NATIVE_CALL int __stdcall GetDecoderVersion(void);

	// Retrieve basic header information: width, height.
	// This function will also validate the header, returning true on success,
	// false otherwise. '*width' and '*height' are only valid on successful return.
	// Pointers 'width' and 'height' can be passed NULL if deemed irrelevant.
	// Note: The following chunk sequences (before the raw VP8/VP8L data) are
	// considered valid by this function:
	// RIFF + VP8(L)
	// RIFF + VP8X + (optional chunks) + VP8(L)
	// ALPH + VP8 <-- Not a valid WebP format: only allowed for internal purpose.
	// VP8(L)     <-- Not a valid WebP format: only allowed for internal purpose.
	WEBP_NATIVE_CALL int __stdcall GetInfo(const uint8_t* data, size_t data_size, int* width, int* height);

	// Decodes WebP images pointed to by 'data' and returns RGBA samples, along
	// with the dimensions in *width and *height. The ordering of samples in
	// memory is R, G, B, A, R, G, B, A... in scan order (endian-independent).
	// The returned pointer should be deleted calling WebPFree().
	// Returns NULL in case of error.
	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGBA(const uint8_t* data, size_t data_size, int* width, int* height);

	// Same as DecodeRGBA, but returning A, R, G, B, A, R, G, B... ordered data.
	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeARGB(const uint8_t* data, size_t data_size, int* width, int* height);

	// Same as DecodeRGBA, but returning B, G, R, A, B, G, R, A... ordered data.
	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGRA(const uint8_t* data, size_t data_size, int* width, int* height);

	// Same as DecodeRGBA, but returning R, G, B, R, G, B... ordered data.
	// If the bitstream contains transparency, it is ignored.
	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGB(const uint8_t* data, size_t data_size, int* width, int* height);

	// Same as DecodeRGB, but returning B, G, R, B, G, R... ordered data.
	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGR(const uint8_t* data, size_t data_size, int* width, int* height);

	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGBAInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride);

	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeARGBInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride);

	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGRAInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride);

	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeRGBInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride);

	WEBP_NATIVE_CALL uint8_t* __stdcall DecodeBGRInto(const uint8_t* data, size_t data_size, uint8_t* output_buffer, size_t output_buffer_size, int output_stride);

	// Releases memory returned by the Decode*() functions above.
	WEBP_NATIVE_CALL void __stdcall FreeDecoder(void* ptr);
}