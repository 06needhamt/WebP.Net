using System;
using System.Collections.Generic;
using System.Text;

namespace WebP.Net
{
    [Flags]
    public enum Mode
    {
        Decode = 1 << 0,
        Encode = 1 << 1,
    }
}
