﻿using System;
using System.Collections.Generic;
using System.Text;
using HideNow.Data;
using HideNow.Helper;
using HideNow.Utils;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Action = HideNow.Data.Action;

namespace HideNow.Core
{
    class ActionHandler
    {
        public static void TakeAction(Action action)
        {
            var data = (object[])action.ActionData;

            if (action.ActionType == ActionType.MinimizeWindow)
            {
                try
                {
                    var window = (Window)data[0];
                    WindowHide.Minimize(window);
                }
                catch(Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }

            else if(action.ActionType == ActionType.RenameWindow)
            {
                try
                {
                    var window = (Window)data[0];
                    var name = (string)data[1];
                    NativeMethods.SetWindowText(window.Handle, name);
                }
                catch (Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }

            else if(action.ActionType == ActionType.ShowWindow)
            {
                try
                {
                    var window = (Window)data[0];
                    NativeMethodsHelper.ForceBringWindowToTop(window.Handle);
                }
                catch (Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }

            else if(action.ActionType == ActionType.OpenApplication)
            {
                try
                {
                    var path = (string)data[0];
                    var args = (string)data[1];
                    Process.Start(path, args);
                }
                catch (Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }

            else if (action.ActionType == ActionType.CloseApplication)
            {
                try
                {
                    var name = (string)data[0];
                    var string_pid = name.Substring(4, name.IndexOf("|") - 4);
                    var pid = int.Parse(string_pid);
                    var process = Process.GetProcessById(pid);

                    if(process != null)
                        process.Kill();
                }
                catch (Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }

            else if (action.ActionType == ActionType.CloseWindow)
            {
                try
                {
                    var window = (Window)data[0];
                    foreach(var process in Process.GetProcesses())
                        if (process.MainWindowHandle == window.Handle)
                            process.Kill();
                }
                catch (Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }

            else if (action.ActionType == ActionType.BlackScreen)
            {
                    MiscHelper.TurnOffMonitor();
                try
                {
                }
                catch (Exception ex)
                {
                    Log.WriteLog("ERROR: " + ex.ToString());
                }
            }
        }
    }
}
