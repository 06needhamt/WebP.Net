#include "encode.h"

int GetEncoderVersion(void)
{
	return WebPGetEncoderVersion();
}

size_t EncodeRGB(const uint8_t* rgb,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeRGB(rgb, width, height, stride, quality_factor, output);
}

size_t EncodeBGR(const uint8_t* bgr,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeBGR(bgr, width, height, stride, quality_factor, output);
}

size_t EncodeRGBA(const uint8_t* rgba,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeRGBA(rgba, width, height, stride, quality_factor, output);
}

size_t EncodeBGRA(const uint8_t* bgra,
	int width, int height, int stride,
	float quality_factor, uint8_t** output)
{
	return WebPEncodeBGRA(bgra, width, height, stride, quality_factor, output);
}

size_t EncodeLosslessRGB(const uint8_t* rgb,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessRGB(rgb, width, height, stride, output);
}

size_t EncodeLosslessBGR(const uint8_t* bgr,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessBGR(bgr, width, height, stride, output);
}

size_t EncodeLosslessRGBA(const uint8_t* rgba,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessRGBA(rgba, width, height, stride, output);
}

size_t EncodeLosslessBGRA(const uint8_t* bgra,
	int width, int height, int stride,
	uint8_t** output)
{
	return WebPEncodeLosslessBGRA(bgra, width, height, stride, output);
}

void FreeEncoder(void* ptr)
{
	WebPFree(ptr);
}


