using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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

            byte[] buffer = new byte[(int)Math.Pow(10, 8)];
            MemoryStream ms = new MemoryStream();

            img.Save(ms, ImageFormat.Bmp);

            switch (pixelFormat)
            {
                case WebP.Net.PixelFormat.BGR:
                    if (lossless)
                        EncoderWrapper.EncodeLosslessBGR(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out buffer);
                    else
                        EncoderWrapper.EncodeBGR(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out buffer);
                    break;
                case WebP.Net.PixelFormat.BGRA:
                    if (lossless)
                        EncoderWrapper.EncodeLosslessBGRA(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out buffer);
                    else
                        EncoderWrapper.EncodeBGRA(ms.ToArray(), img.Width, img.Height, img.Width * 4, 100, out buffer);
                    break;
                case WebP.Net.PixelFormat.RGB:
                    if (lossless)
                        EncoderWrapper.EncodeLosslessRGB(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out buffer);
                    else
                        EncoderWrapper.EncodeRGB(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out buffer);
                    break;
                case WebP.Net.PixelFormat.RGBA:
                    if (lossless)
                        EncoderWrapper.EncodeLosslessRGBA(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out buffer);
                    else
                        EncoderWrapper.EncodeRGBA(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out buffer);
                    break;
            }

            FileStream fs = new FileStream(outputFile.FullName, FileMode.Create, FileAccess.Write);
            fs.Write(buffer, (int)SeekOrigin.Begin, buffer.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();

            ms.Close();
            ms.Dispose();

            img.Dispose();

            Console.WriteLine("File Was Successfully Encoded");
        }
        
        private static void DecodeTest()
        {
            Console.WriteLine($"Using Decoder Version: {DecoderWrapper.GetDecoderVersion()}");

            Image img = Image.FromFile(inputFile.FullName);
            int width = 0;
            int height = 0;

            byte[] buffer = new byte[] { };
            MemoryStream ms = new MemoryStream();

            img.Save(ms, img.RawFormat);

            switch (pixelFormat)
            {
                case WebP.Net.PixelFormat.BGR:
                    buffer = DecoderWrapper.DecodeBGR(ms.ToArray(), ms.Length, out width, out height);
                    break;
                case WebP.Net.PixelFormat.BGRA:
                    buffer = DecoderWrapper.DecodeBGRA(ms.ToArray(), ms.Length, out width, out height);
                    break;
                case WebP.Net.PixelFormat.RGB:
                    buffer = DecoderWrapper.DecodeRGB(ms.ToArray(), ms.Length, out width, out height);
                    break;
                case WebP.Net.PixelFormat.RGBA:
                    buffer = DecoderWrapper.DecodeRGBA(ms.ToArray(), ms.Length, out width, out height);
                    break;
            }

            FileStream fs = new FileStream(outputFile.FullName, FileMode.Create, FileAccess.Write);
            fs.Write(buffer, (int)SeekOrigin.Begin, buffer.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();

            ms.Close();
            ms.Dispose();

            img.Dispose();

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
