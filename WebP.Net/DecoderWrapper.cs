using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WebP.Net
{
    public static class DecoderWrapper
    {
        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDecoderVersion();

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetInfo(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeRGBA(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeARGB(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeBGRA(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeRGB(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeBGR(byte[] data, long data_size, out int width, out int height);
        
        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeRGBAInto(byte[] data, ulong data_size, IntPtr output_buffer, ulong output_buffer_size, int output_stride);
        
        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeARGBInto(byte[] data, ulong data_size, IntPtr output_buffer, ulong output_buffer_size, int output_stride);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeBGRAInto(byte[] data, ulong data_size, IntPtr output_buffer, ulong output_buffer_size, int output_stride);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeRGBInto(byte[] data, ulong data_size, IntPtr output_buffer, ulong output_buffer_size, int output_stride);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DecodeBGRInto(byte[] data, ulong data_size, IntPtr output_buffer, ulong output_buffer_size, int output_stride);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void FreeDecoder(IntPtr ptr);
    }
}
