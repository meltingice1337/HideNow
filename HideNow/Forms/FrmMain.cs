using System;
using System.Diagnostics;
using System.Windows.Forms;
using HideNow.Core;
using HideNow.Data;
using HideNow.Helper;
using HideNow.Utils;
using NAudio.Wave;
using Action = HideNow.Data.Action;

namespace HideNow.Forms
{
    public partial class FrmMain : Form
    {
        private Window Window;
        private MotionDetect MotionDetect;
        private AudioDetect AudioDetect;
        private MouseHook MouseHook;
        private MouseHook MouseButtonHook;
        private KeyboardHook KeyboardHook;

        private bool IsActivated;

        public FrmMain()
        {
            InitializeComponent();
            btnRemoveAction.BackColor = btnAddAction.BackColor = System.Drawing.Color.Transparent;
            btnRemoveAction.Parent =  btnAddAction.Parent = lstActions;
            KeyboardHook = new KeyboardHook();
            KeyboardHook.KeyPressed += KeyboardHook_KeyPressed;
            KeyboardHook.Start();
            MouseButtonHook = new MouseHook(true);
            MouseButtonHook.MouseMoved += MouseButtonHook_MouseMoved;
            MouseButtonHook.Start();
            AudioDetect = new AudioDetect(0);
            AudioDetect.AudioDetected += AudioDetect_AudioDetected;
            AudioDetect.Start();
            IsActivated = false;
        }

        private void AudioDetect_AudioDetected()
        {
            lstActions.BeginInvoke(new MethodInvoker(() =>
            {
                foreach (ListViewItem lvi in lstActions.Items)
                    ActionHandler.TakeAction((Action)lvi.Tag);
            }));
        }

        private void MouseButtonHook_MouseMoved()
        {
            lstActions.BeginInvoke(new MethodInvoker(() =>
            {
                foreach (ListViewItem lvi in lstActions.Items)
                    ActionHandler.TakeAction((Action)lvi.Tag);
            }));
        }

        private void KeyboardHook_KeyPressed()
        {
            btnStatus.PerformClick();
        }

        private void MotionDetect_MotionDetected()
        {
            lstActions.BeginInvoke(new MethodInvoker(() =>
            {
                foreach (ListViewItem lvi in lstActions.Items)
                    ActionHandler.TakeAction((Action)lvi.Tag);
            }));

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FillWebcams();
        }

        private void SetWindow(Window window)
        {
            Window = window;
            Text = "HideNow - " + window.Title;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MotionDetect != null)
                MotionDetect.Stop();
            if(MouseHook != null)
            {
                MouseHook.MouseMoved -= MotionDetect_MotionDetected;
                MouseHook.Stop();
            }

            if (KeyboardHook != null)
            {
                KeyboardHook.KeyPressed -= KeyboardHook_KeyPressed;
                KeyboardHook.Stop();
            }
            if(AudioDetect != null)
            {
                AudioDetect.Stop();
            }
        }

        private void ToggleMonitoring(bool status)
        {
            if(status)
            {
                if (cboxMouseMovement.Checked)
                {
                    MouseHook = new MouseHook();
                    MouseHook.MouseMoved += MotionDetect_MotionDetected;
                    MouseHook.Start();
                }
                else
                {
                    MotionDetect = new MotionDetect(cboxWebcams.SelectedIndex);
                    MotionDetect.MotionDetected += MotionDetect_MotionDetected;
                    MotionDetect.Start();
                }
                IsActivated = true;
                cboxMouseMovement.Enabled = false;
                cboxWebcams.Enabled = false;
                btnStatus.Text = "Deactivate monitoring";
                this.Text = "HideNow - Active";
            }
            else
            {
                IsActivated = false;
                cboxWebcams.Enabled = true;
                cboxMouseMovement.Enabled = true;
                if (cboxMouseMovement.Checked)
                {
                    MouseHook.MouseMoved -= MotionDetect_MotionDetected;
                    MouseHook.Stop();
                }
                else
                {
                    MotionDetect.MotionDetected -= MotionDetect_MotionDetected;
                    MotionDetect.Stop();
                }
                btnStatus.Text = "Activate monitoring";
                this.Text = "HideNow - Inactive";
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            ToggleMonitoring(!IsActivated);
        }

        private void FillWebcams()
        {
            string[] webcamNames = WebcamHandler.GetWebcamNames();
            cboxWebcams.Items.AddRange(webcamNames);
            if (cboxWebcams.Items.Count > 0)
                cboxWebcams.SelectedIndex = 0;
        }

        private void pictureButton1_Click(object sender, EventArgs e)
        {
            var faa = new FrmAddAction();
            if (faa.ShowDialog() == DialogResult.OK)
            {
                AddActionToList(faa.Action);
            }
        }
        
        private void AddActionToList(Data.Action action)
        {
            string value = "";
            string type = action.ActionType.ToString();

            if (action.ActionType == ActionType.OpenApplication)
            {
                var data = (object[])action.ActionData;
                if ((string)data[1] != "")
                    value = "Args:" + (string)data[1] + " || ";
                value += (string)data[0];
            }
            else if (action.ActionType == ActionType.CloseApplication)
            {
                var data = (object[])action.ActionData;
                value = ((string)data[0]);
            }
            else if (action.ActionType == ActionType.RenameWindow)
            {
                var data = (object[])action.ActionData;
                value = "New: " + (string)data[1] + " || " + ((Window)data[0]).Title;
            }
            else if (action.ActionType == ActionType.BlackScreen)
            {
                value = "";
            }
            else
            {
                var data = (object[])action.ActionData;
                value = ((Window)data[0]).Title;
            }
            var lvi = new ListViewItem(new string[] { type, value });
            lvi.Tag = action;

            lstActions.Items.Add(lvi);
        }

        private void btnRemoveAction_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstActions.SelectedItems)
                lstActions.Items.Remove(item);
        }

        private void lstActions_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
                btnRemoveAction_Click(null, null);
        }

        private void cboxMouseMovement_CheckedChanged(object sender, EventArgs e)
        {
            cboxWebcams.Enabled = !cboxMouseMovement.Checked;
        }
    }
}
