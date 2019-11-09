using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using WebP.Net;

namespace BatchProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (args.Length != 2)
            {
                return;
            }

            List<string> files = Directory.EnumerateFiles(args[0]).ToList();
            Console.WriteLine($"Using Encoder Version: {EncoderWrapper.GetEncoderVersion()}");

            foreach (string file in files)
            {
                string outfile = Path.Combine(args[1], Path.GetFileNameWithoutExtension(file) + ".webp");
                Image img = Image.FromFile(file);
                IntPtr ptr = IntPtr.Zero;
                ulong size = 0L;
                MemoryStream ms = new MemoryStream();
                ms.Seek(0L, SeekOrigin.Begin);
                img.Save(ms, ImageFormat.Bmp);

                size = EncoderWrapper.EncodeBGR(ms.ToArray(), img.Width, img.Height, img.Width * 3, 100, out ptr);

                byte[] buffer = new byte[(int)size];
                Marshal.Copy(ptr, buffer, 0, (int)size);

                FileStream fs = new FileStream(outfile, FileMode.Create, FileAccess.Write);
                fs.Write(buffer, (int)SeekOrigin.Begin, buffer.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();

                ms.Close();
                ms.Dispose();

                img.Dispose();

                //EncoderWrapper.FreeEncoder(ptr);

                Console.WriteLine($"File: {Path.GetFileName(file)}.webp Was Successfully Encoded");
            }
        }
    }
}
