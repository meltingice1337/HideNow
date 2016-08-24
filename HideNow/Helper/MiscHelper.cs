using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using HideNow.Utils;
using System.Threading;

namespace HideNow.Helper
{
    class MiscHelper
    {
        private static KeyboardHook KeyboardHook = null;
        private static Thread BlackScreenThread;

        public static string[] GetProcessesWithPid()
        {
            var result = new List<string>();
            foreach(var process in Process.GetProcesses())
            {
                result.Add(string.Format("PID:{0}|Name: {1}.exe", process.Id, process.ProcessName));
            }
            return result.ToArray();
        }

        public static void TurnOffMonitor()
        {
            if (KeyboardHook == null)
            {
                KeyboardHook = new KeyboardHook();
                KeyboardHook.KeyPressed += KeyboardHook_KeyPressed;
            }

            KeyboardHook.Start();

            if (BlackScreenThread != null)
                if (BlackScreenThread.IsAlive)
                    return;

            IntPtr handle = ((Forms.FrmMain)Application.OpenForms["FrmMain"]).Handle;

            BlackScreenThread = new Thread(() => {
               
                while(true)
                {
                    NativeMethods.SendMessage(handle, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MONITORPOWER, NativeMethods.MOINTOR_POWEROFF);
                    Thread.Sleep(500);
                }
            });
            BlackScreenThread.Start();

        }

        private static void KeyboardHook_KeyPressed()
        {
            KeyboardHook.Stop();
            BlackScreenThread.Abort();

            SendKeys.Send("1");
        }
    }
}
