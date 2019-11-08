using System;
using System.Collections.Generic;
using System.Text;

namespace WebP.Net
{
    [Flags]
    public enum PixelFormat
    {
        RGB = 1 << 0,
        BGR = 1 << 1,
        RGBA = 1 << 2,
        BGRA = 1 << 3,
        ARGB = 1 << 4,
    }
}
