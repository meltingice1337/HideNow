using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using HideNow.Data;
using HideNow.Utils;

namespace HideNow.Core
{
    class WindowHelper
    {
        public static Window[] GetWindows()
        {
            var result = new List<Window>();
            var shellWindow = NativeMethods.GetShellWindow();

            NativeMethods.EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!NativeMethods.IsWindowVisible(hWnd)) return true;

                var length = NativeMethods.GetWindowTextLength(hWnd);
                if (length == 0) return true;

                var builder = new StringBuilder(length);
                NativeMethods.GetWindowText(hWnd, builder, length + 1);

                if (builder.ToString() == "Start") return true;

                result.Add(new Window { Title = builder.ToString(), Handle = hWnd, Icon = GetIconBitmap(hWnd) });
                return true;

            }, 0);
            return result.ToArray() ;
        }

        private static Bitmap GetIconBitmap(IntPtr hWnd)
        {
            uint pID;
            NativeMethods.GetWindowThreadProcessId(hWnd, out pID);
           foreach (var process in Process.GetProcesses())
            {
                if (process.Id == pID)
                    return Icon.ExtractAssociatedIcon(process.MainModule.FileName).ToBitmap();
            }
            return null;
        }
    }
}
