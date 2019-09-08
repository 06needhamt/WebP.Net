#pragma once

#ifndef WEBP_NATIVE_CALL
#define WEBP_NATIVE_CALL __declspec(dllexport) 
#endif 

#include <webp/encode.h>

// Return the encoder's version number, packed in hexadecimal using 8bits for
// each of major/minor/revision. E.g: v2.5.7 is 0x020507.
WEBP_NATIVE_CALL int __stdcall GetEncoderVersion(void);

//------------------------------------------------------------------------------
// One-stop-shop call! No questions asked:

// Returns the size of the compressed data (pointed to by *output), or 0 if
// an error occurred. The compressed data must be released by the caller
// using the call 'WebPFree(*output)'.
// These functions compress using the lossy format, and the quality_factor
// can go from 0 (smaller output, lower quality) to 100 (best quality,
// larger output).
WEBP_NATIVE_CALL size_t __stdcall EncodeRGB(const uint8_t* rgb,
	int width, int height, int stride,
	float quality_factor, uint8_t** output);
WEBP_NATIVE_CALL size_t __stdcall EncodeBGR(const uint8_t* bgr,
	int width, int height, int stride,
	float quality_factor, uint8_t** output);
WEBP_NATIVE_CALL size_t __stdcall EncodeRGBA(const uint8_t* rgba,
	int width, int height, int stride,
	float quality_factor, uint8_t** output);
WEBP_NATIVE_CALL size_t __stdcall EncodeBGRA(const uint8_t* bgra,
	int width, int height, int stride,
	float quality_factor, uint8_t** output);

// These functions are the equivalent of the above, but compressing in a
// lossless manner. Files are usually larger than lossy format, but will
// not suffer any compression loss.
// Note these functions, like the lossy versions, use the library's default
// settings. For lossless this means 'exact' is disabled. RGB values in
// transparent areas will be modified to improve compression. To avoid this,
// use WebPEncode() and set WebPConfig::exact to 1.
WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessRGB(const uint8_t* rgb,
	int width, int height, int stride,
	uint8_t** output);
WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessBGR(const uint8_t* bgr,
	int width, int height, int stride,
	uint8_t** output);
WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessRGBA(const uint8_t* rgba,
	int width, int height, int stride,
	uint8_t** output);
WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessBGRA(const uint8_t* bgra,
	int width, int height, int stride,
	uint8_t** output);

// Releases memory returned by the Encode*() functions above.
WEBP_NATIVE_CALL void __stdcall FreeEncoder(void* ptr);

