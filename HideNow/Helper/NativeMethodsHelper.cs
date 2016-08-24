using System;
using System.Collections.Generic;
using System.Text;
using HideNow.Utils;

namespace HideNow.Helper
{
    class NativeMethodsHelper
    {
        public static int MakeLong(int wLow, int wHigh)
        {
            int low = (int)IntLoWord(wLow);
            short high = IntLoWord(wHigh);
            int product = 0x10000 * (int)high;
            int mkLong = (int)(low | product);
            return mkLong;
        }

        private static short IntLoWord(int word)
        {
            return (short)(word & short.MaxValue);
        }

        public static void ForceBringWindowToTop(IntPtr handle)
        {
            var fThread = NativeMethods.GetWindowThreadProcessId(NativeMethods.GetForegroundWindow(), IntPtr.Zero);
            var cThread = NativeMethods.GetWindowThreadProcessId(handle, IntPtr.Zero);
            if (fThread != cThread)
            {
                NativeMethods.AttachThreadInput(fThread, cThread, true);
                NativeMethods.BringWindowToTop(handle);
                NativeMethods.AttachThreadInput(fThread, cThread, false);
            }
            else NativeMethods.BringWindowToTop(handle);
        }
    }
}
