#include "encode.h"

WEBP_NATIVE_CALL int __stdcall GetEncoderVersion(void)
{
	return WebPGetEncoderVersion();
}

WEBP_NATIVE_CALL size_t __stdcall EncodeRGB(const uint8_t* rgb,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeRGB(rgb, width, height, stride, quality_factor, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeBGR(const uint8_t* bgr,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeBGR(bgr, width, height, stride, quality_factor, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeRGBA(const uint8_t* rgba,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeRGBA(rgba, width, height, stride, quality_factor, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeBGRA(const uint8_t* bgra,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeBGRA(bgra, width, height, stride, quality_factor, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessRGB(const uint8_t* rgb,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessRGB(rgb, width, height, stride, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessBGR(const uint8_t* bgr,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessBGR(bgr, width, height, stride, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessRGBA(const uint8_t* rgba,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessRGBA(rgba, width, height, stride, output);
}

WEBP_NATIVE_CALL size_t __stdcall EncodeLosslessBGRA(const uint8_t* bgra,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessBGRA(bgra, width, height, stride, output);
}

WEBP_NATIVE_CALL void __stdcall FreeEncoder(void* ptr)
{
	WebPFree(ptr);
}


