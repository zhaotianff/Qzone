using System;
using System.Collections.Generic;
using System.Text;

namespace Qzone.Util
{
    public class WinAPI
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
    }
}
