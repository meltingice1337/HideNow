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

                lstActions.BeginInvoke(new MethodInvoker(() =>
                {
                    foreach(ListViewItem lvi in lstActions.Items)
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

        private void pictureButton1_Click(object sender, EventArgs e)
        {
            var faa = new FrmAddAction();
            if (faa.ShowDialog() == DialogResult.OK)
            {
                AddActionToList(faa.Action);
            }
        }
        
        private void AddActionToList(Action action)
        {
            string value = "";
            string type = action.ActionType.ToString();

            if(action.ActionType == ActionTypeEnum.OpenApplication)
            {
                var data = (object[])action.ActionData;
                if ((string)data[1] != "")
                    value = "Args:" + (string)data[1] + " || ";
                value += (string)data[0];
            }
            else if (action.ActionType == ActionTypeEnum.CloseApplication)
            {
                var data = (object[])action.ActionData;
                value = ((string)data[0]);
            }
            else if(action.ActionType == ActionTypeEnum.RenameWindow)
            {
                var data = (object[])action.ActionData;
                value = "New: " + (string)data[1] + " || " +((Window)data[0]).Title;
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
    }
}
