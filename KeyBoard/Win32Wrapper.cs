using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoard
{
    public static class Win32Wrapper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void OutputDebugString(string lpOutputString);
    }
}
