using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HideNow.Utils
{
    class KeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private NativeMethods.LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public bool IsStarted = false;

        public delegate void KeyPressedHandler();
        public static event KeyPressedHandler KeyPressed;

        private IntPtr HookCallback( int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (vkCode == NativeMethods.VK_F5)
                    KeyPressed?.Invoke();
            }
            return NativeMethods.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(NativeMethods.LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return NativeMethods.SetWindowsHookEx(WH_KEYBOARD_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public KeyboardHook()
        {
            _proc = HookCallback;
        }

        public void Start()
        {
            if (IsStarted)
                return;

            _hookID = SetHook(_proc);
            IsStarted = true;
        }

        public void Stop()
        {
            if (!IsStarted)
                return;

            NativeMethods.UnhookWindowsHookEx(_hookID);
            IsStarted = false;
        }
    }
}
