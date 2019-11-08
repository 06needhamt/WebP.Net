using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebP.Net;

namespace TestApp
{
    class Program
    {
        static FileInfo inputFile;
        static FileInfo outputFile;
        static WebP.Net.PixelFormat pixelFormat;
        static Mode mode;
        static bool lossless = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if(args.Length < 4)
                Error();

            inputFile = new FileInfo(args[0]);
            outputFile = new FileInfo(args[1]);

            if (args.Contains("--encode"))
                mode = Mode.Encode;
            else if (args.Contains("--decode"))
                mode = Mode.Decode;
            else
                Error();

            if (args.Contains("--rgb"))
                pixelFormat = WebP.Net.PixelFormat.RGB;
            else if (args.Contains("--rgba"))
                pixelFormat = WebP.Net.PixelFormat.RGBA;
            else if (args.Contains("--bgr"))
                pixelFormat = WebP.Net.PixelFormat.BGR;
            else if (args.Contains("--bgra"))
                pixelFormat = WebP.Net.PixelFormat.BGRA;
            else
                Error();

            if (args.Contains("--lossless"))
                lossless = true;
            else
                lossless = false;

            switch (mode)
            {
                case Mode.Decode:
                    DecodeTest();
                    break;
                case Mode.Encode:
                    EncodeTest();
                    break;
            }

            Console.ReadKey();
        }

        private static void EncodeTest()
        {
            Console.WriteLine($"Using Encoder Version: {EncoderWrapper.GetEncoderVersion()}");

            Image img = Image.FromFile(inputFile.FullName);
            IntPtr ptr = IntPtr.Zero;
            ulong size = 0L;
            MemoryStream ms = new MemoryStream();

            img.Save(ms, ImageFormat.Bmp);

            switch (pixelFormat)
            {
                case WebP.Net.PixelFormat.BGR:
                    if (lossless)
                        size = EncoderWrapper.EncodeLosslessBGR(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out ptr);
                    else
                        size = EncoderWrapper.EncodeBGR(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out ptr);
                    break;
                case WebP.Net.PixelFormat.RGB:
                    if (lossless)
                        size = EncoderWrapper.EncodeLosslessRGB(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out ptr);
                    else
                        size = EncoderWrapper.EncodeRGB(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out ptr);
                    break;
                case WebP.Net.PixelFormat.RGBA:
                    if (lossless)
                        size = EncoderWrapper.EncodeLosslessRGBA(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out ptr);
                    else
                        size = EncoderWrapper.EncodeRGBA(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out ptr);
                    break;
                case WebP.Net.PixelFormat.BGRA:
                    if (lossless)
                        size = EncoderWrapper.EncodeLosslessBGRA(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out ptr);
                    else
                        size = EncoderWrapper.EncodeBGRA(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out ptr);
                    break;
            }

            byte[] buffer = new byte[(int)size];
            Marshal.Copy(ptr, buffer, 0, (int)size);

            FileStream fs = new FileStream(outputFile.FullName, FileMode.Create, FileAccess.Write);
            fs.Write(buffer, (int)SeekOrigin.Begin, buffer.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();

            ms.Close();
            ms.Dispose();

            img.Dispose();

            //EncoderWrapper.FreeEncoder(ptr);

            Console.WriteLine("File Was Successfully Encoded");
        }
        
        private static void DecodeTest()
        {
            Console.WriteLine($"Using Decoder Version: {DecoderWrapper.GetDecoderVersion()}");

            int width = 0;
            int height = 0;
            int data_size = 0;
            IntPtr ptr = IntPtr.Zero;
            Bitmap bitmap = null;
            BitmapData bitmapData = null;
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(inputFile.FullName));

            DecoderWrapper.GetInfo(ms.ToArray(), ms.Length, out width, out height);

            switch (pixelFormat)
            {
                case WebP.Net.PixelFormat.BGR:
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    ptr = DecoderWrapper.DecodeBGRInto(ms.ToArray(), (ulong)ms.Length, bitmapData.Scan0, (ulong)(bitmapData.Stride * bitmapData.Height), bitmapData.Stride);
                    data_size = width * height * 3;
                    break;
                case WebP.Net.PixelFormat.RGB:
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    ptr = ptr = DecoderWrapper.DecodeRGBInto(ms.ToArray(), (ulong)ms.Length, bitmapData.Scan0, (ulong)(bitmapData.Stride * bitmapData.Height), bitmapData.Stride);
                    data_size = width * height * 3;
                    break;
                case WebP.Net.PixelFormat.RGBA:
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    ptr = DecoderWrapper.DecodeRGBAInto(ms.ToArray(), (ulong)ms.Length, bitmapData.Scan0, (ulong)(bitmapData.Stride * bitmapData.Height), bitmapData.Stride);
                    data_size = width * height * 4;
                    break;
                case WebP.Net.PixelFormat.ARGB:
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    ptr = DecoderWrapper.DecodeARGBInto(ms.ToArray(), (ulong)ms.Length, bitmapData.Scan0, (ulong)(bitmapData.Stride * bitmapData.Height), bitmapData.Stride);
                    data_size = width * height * 4;
                    break;
                case WebP.Net.PixelFormat.BGRA:
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    ptr = DecoderWrapper.DecodeBGRAInto(ms.ToArray(), (ulong)ms.Length, bitmapData.Scan0, (ulong)(bitmapData.Stride * bitmapData.Height), bitmapData.Stride);
                    data_size = width * height * 4;
                    break;
            }

            bitmap.UnlockBits(bitmapData);

            FileStream fs = new FileStream(outputFile.FullName, FileMode.Create, FileAccess.Write);
            bitmap.Save(fs, ImageFormat.Jpeg);
            fs.Flush();
            fs.Close();
            fs.Dispose();

            ms.Close();
            ms.Dispose();

            //DecoderWrapper.FreeDecoder(ptr);

            Console.WriteLine("File Was Successfully Decoded");
        }

        private static void Error()
        {
            Console.WriteLine("USAGE: <input_file> <output_file> <--decode|--encode> <--rgb|--rgba|--bgr|--bgra> [--lossless]");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
