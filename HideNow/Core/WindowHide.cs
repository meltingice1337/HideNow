using HideNow.Utils;
using HideNow.Data;
using System;

namespace HideNow.Core
{
    class WindowHide
    {
        public static void Minimize(Window window)
        {
            SetWindowPlacement(window.Handle, NativeMethods.SW_SHOWMINIMIZED);
        }

        private static void SetWindowPlacement(IntPtr hWnd, int cmdShow)
        {
            NativeMethods.WINDOWPLACEMENT windowPlacement = new NativeMethods.WINDOWPLACEMENT();
            NativeMethods.GetWindowPlacement(hWnd, out windowPlacement);
            windowPlacement.showCmd = cmdShow;

            NativeMethods.SetWindowPlacement(hWnd, windowPlacement);
        }
    }
}
