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
        public static extern byte[] DecodeRGBA(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern byte[] DecodeARGB(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern byte[] DecodeBGRA(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern byte[] DecodeRGB(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern byte[] DecodeBGR(byte[] data, long data_size, out int width, out int height);

        [DllImport("WebP.Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void FreeDecoder(IntPtr ptr);
    }
}
