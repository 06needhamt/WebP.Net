using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebP.Net.Encoder
{
    public class EncoderManager
    {
        public FileInfo InputFile { get; private set; }
        public FileInfo OutputFile { get; private set; }
        public int Stride { get; private set; }
        public float Quality { get; private set; }

        public EncoderManager(string inputFile, string outputFile, int stride, float quality)
        {
            InputFile = new FileInfo(inputFile);
            OutputFile = new FileInfo(outputFile);
            Quality = quality;
        }

        public EncoderManager(FileInfo inputFile, FileInfo outputFile, int stride, float quality)
        {
            InputFile = inputFile;
            OutputFile = outputFile;
            Quality = quality;
        }

        public int GetEncoderVersion(out string error)
        {
            try
            {
                error = string.Empty;
                return EncoderWrapper.GetEncoderVersion();
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                return -1;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
        }

        public ulong EncodeRGB(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeRGB(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeBGR(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeBGR(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeRGBA(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeRGBA(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeBGRA(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeBGRA(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeLosslessRGB(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeLosslessRGB(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeLosslessBGR(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeLosslessBGR(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeLosslessRGBA(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeLosslessRGBA(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public ulong EncodeLosslessBGRA(int width, int height, int stride,
            float quality_factor, out byte[] output, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            byte[] outputData = new byte[] { };
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return EncoderWrapper.EncodeLosslessBGRA(data, width, stride, height, quality_factor, out output);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                output = null;
                return ulong.MaxValue;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                output = null;
                return ulong.MaxValue;
            }
        }

        public void FreeEncoder(IntPtr ptr, out string error)
        {
            try
            {
                EncoderWrapper.FreeEncoder(ptr);
                error = string.Empty;
                return;
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                return;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return;
            }
        }
    }
}
