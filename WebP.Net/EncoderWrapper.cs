using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WebP.Net
{
    public static class EncoderWrapper
    {
        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEncoderVersion();

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeRGB(byte[] rgb, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeBGR(byte[] bgr, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeRGBA(byte[] rgba, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeBGRA(byte[] rgb, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeLosslessRGB(byte[] rgb, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeLosslessBGR(byte[] bgr, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeLosslessRGBA(byte[] rgba, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ulong EncodeLosslessBGRA(byte[] rgb, int width, int height, int stride,
            float quality_factor, out IntPtr output);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void FreeEncoder(IntPtr ptr);
    }
}
