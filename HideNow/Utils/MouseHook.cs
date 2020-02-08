using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HideNow.Utils
{
    class MouseHook
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private NativeMethods.LowLevelHoocProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public bool IsStarted = false;

        public delegate void MouseMovedHandler();
        public event MouseMovedHandler MouseMoved;

        private bool watchForMouseButtonOnly;

        private IntPtr HookCallback( int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (watchForMouseButtonOnly)
            {
                if(nCode >= 0 && wParam == (IntPtr)0x20b)
                {
                    MouseMoved?.Invoke();
                }
            }
            else
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_MOUSEMOVE)
                {
                    MouseMoved?.Invoke();
                }
            }
            return NativeMethods.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(NativeMethods.LowLevelHoocProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return NativeMethods.SetWindowsHookEx(WH_MOUSE_LL, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public MouseHook(bool watchForMouseButtonOnly = false)
        {
            this.watchForMouseButtonOnly = watchForMouseButtonOnly;
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
