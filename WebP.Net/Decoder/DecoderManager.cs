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
        public int Quality { get; private set; }

        public DecoderManager(string inputFile, string outputFile, int quality)
        {
            InputFile = new FileInfo(inputFile);
            OutputFile = new FileInfo(outputFile);
            Quality = quality;
        }

        public DecoderManager(FileInfo inputFile, FileInfo outputFile, int quality)
        {
            InputFile = inputFile;
            OutputFile = outputFile;
            Quality = quality;
        }
    }
}
