using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebP.Net.Decoder
{
    public class DecoderManager
    {
        public FileInfo InputFile { get; private set; }
        public FileInfo OutputFile { get; private set; }

        public DecoderManager(string inputFile, string outputFile)
        {
            InputFile = new FileInfo(inputFile);
            OutputFile = new FileInfo(outputFile);
        }

        public DecoderManager(FileInfo inputFile, FileInfo outputFile)
        {
            InputFile = inputFile;
            OutputFile = outputFile;
        }

        public int GetDecoderVersion(out string error)
        {
            try
            {
                error = string.Empty;
                return DecoderWrapper.GetDecoderVersion();
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

        public int GetInfo(out int width, out int height, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return DecoderWrapper.GetInfo(data, data.Length, out width, out height);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                width = -1;
                height = -1;
                return -1;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                width = -1;
                height = -1;
                return -1;
            }
        }

        public byte[] DecodeRGBA(out int width, out int height, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return DecoderWrapper.DecodeRGBA(data, data.Length, out width, out height);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                width = -1;
                height = -1;
                return null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                width = -1;
                height = -1;
                return null;
            }
        }

        public byte[] DecodeARGB(out int width, out int height, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return DecoderWrapper.DecodeARGB(data, data.Length, out width, out height);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                width = -1;
                height = -1;
                return null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                width = -1;
                height = -1;
                return null;
            }
        }

        public byte[] DecodeBGRA(out int width, out int height, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return DecoderWrapper.DecodeBGRA(data, data.Length, out width, out height);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                width = -1;
                height = -1;
                return null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                width = -1;
                height = -1;
                return null;
            }
        }

        public byte[] DecodeRGB(out int width, out int height, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return DecoderWrapper.DecodeRGB(data, data.Length, out width, out height);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                width = -1;
                height = -1;
                return null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                width = -1;
                height = -1;
                return null;
            }
        }

        public byte[] DecodeBGR(out int width, out int height, out string error)
        {
            byte[] data = new byte[InputFile.Length];
            FileStream fs = new FileStream(InputFile.FullName, FileMode.Open);
            try
            {
                fs.Read(data, (int)SeekOrigin.Begin, (int)InputFile.Length);
                fs.Close();
                fs.Dispose();
                error = string.Empty;
                return DecoderWrapper.DecodeBGR(data, data.Length, out width, out height);
            }
            catch (AggregateException ae)
            {
                error = ae.InnerException.Message;
                width = -1;
                height = -1;
                return null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                width = -1;
                height = -1;
                return null;
            }
        }

        public void FreeDecoder(IntPtr ptr, out string error)
        {
            try
            {
                DecoderWrapper.FreeDecoder(ptr);
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
