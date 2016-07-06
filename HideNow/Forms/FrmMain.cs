using System;
using System.Windows.Forms;
using HideNow.Core;
using HideNow.Data;

namespace HideNow.Forms
{
    public partial class FrmMain : Form
    {
        private Window Window;
        private MotionDetect MotionDetect;
        private bool IsActivated;

        public FrmMain()
        {
            InitializeComponent();

            IsActivated = false;
        }

        private void MotionDetect_MotionDetected()
        {
            if(Window != null)
                WindowHide.Hide(Window);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GetWindows();
            FillWebcams();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetWindows();
        }

        private void lstWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetWindow((Window)lstWindows.SelectedItem);
        }

        private void GetWindows()
        {
            Window = null;
            Text = "HideNow";
            lstWindows.Items.Clear();
            lstWindows.Items.AddRange(WindowHelper.GetWindows());
        }

        private void SetWindow(Window window)
        {
            Window = window;
            Text = "HideNow - " + window.Title;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MotionDetect.Stop();
        }

        private void ToggleMonitoring(bool status)
        {
            if(status)
            {
                MotionDetect = new MotionDetect(cboxWebcams.SelectedIndex);
                MotionDetect.MotionDetected += MotionDetect_MotionDetected;
                MotionDetect.Start();

                IsActivated = true;
                cboxWebcams.Enabled = false;
                btnStatus.Text = "Deactivate monitoring";
            }
            else
            {
                IsActivated = false;
                cboxWebcams.Enabled = true;
                MotionDetect.MotionDetected -= MotionDetect_MotionDetected;
                MotionDetect.Stop();
                btnStatus.Text = "Activate monitoring";
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
    }
}
