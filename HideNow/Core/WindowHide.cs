using HideNow.Utils;
using HideNow.Data;

namespace HideNow.Core
{
    class WindowHide
    {
        public static void Hide(Window window,string replaceText = "#")
        {
            NativeMethods.ShowWindow(window.Handle, NativeMethods.SW_MINIMIZE);
            NativeMethods.SetWindowText(window.Handle, replaceText);
        }
    }
}
