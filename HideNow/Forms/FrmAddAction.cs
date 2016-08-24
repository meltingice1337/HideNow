using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HideNow.Helper;
using HideNow.Data;

namespace HideNow.Forms
{
    public partial class FrmAddAction : Form
    {
        private List<Window> windows = new List<Window>();
        public Action Action;

        public FrmAddAction()
        {
            InitializeComponent();
        }

        private void cboxActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxActionValue.Items.Clear();
            txtActionOptions.Text = "";

            switch (cboxActionType.Text)
            {
                case "Open Application":
                    ToggleControls(true);
                    lblActionOptions.Text = "Arguments";
                    var ofd = new OpenFileDialog();
                    ofd.Filter = "All Files(*.*)|*.*";
                    ofd.Multiselect = false;

                    if (ofd.ShowDialog() == DialogResult.OK)
                        cboxActionValue.Items.Add(ofd.FileName);
                    else
                    {
                        ToggleControls(false);
                        cboxActionType.SelectedIndex = 0;
                        return;
                    }
                    break;
                case "Close Application":
                    ToggleControls(false);
                    cboxActionValue.Items.AddRange(MiscHelper.GetProcessesWithPid());
                    break;
                case "Rename Window":
                    ToggleControls(true);
                    lblActionOptions.Text = "Rename window to";

                    windows = WindowHelper.GetWindows();
                    cboxActionValue.Items.AddRange(WindowHelper.GetWindowsTitle(windows));
                    break;
                default:
                    ToggleControls(false);
                    windows = WindowHelper.GetWindows();
                    cboxActionValue.Items.AddRange(WindowHelper.GetWindowsTitle(windows));
                    break;
            }
            cboxActionValue.SelectedIndex = 0;
        }

        private void ToggleControls(bool enabled)
        {
            lblActionOptions.Enabled = txtActionOptions.Enabled = enabled;
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            Action = new Data.Action();
            Action.ActionType = (ActionTypeEnum)Enum.Parse(typeof(ActionTypeEnum), cboxActionType.Text.Replace(" ", ""));

            switch (cboxActionType.Text)
            {
                case "Open Application":
                    Action.ActionData = new object[]
                    {
                        cboxActionValue.Text,
                        txtActionOptions.Text
                    };
                    break;
                case "Rename Window":
                    if(txtActionOptions.Text == "")
                    {
                        MessageBox.Show("You can't leave the input empty!");
                        return;
                    }
                    Action.ActionData = new object[]
                    {
                         windows[cboxActionValue.SelectedIndex],
                        txtActionOptions.Text
                    };
                    break;
                case "Close Application":
                    Action.ActionData = new object[]
                    {
                        cboxActionValue.Text
                    };
                    break;
                default:
                    Action.ActionData = new object[]
                    {
                         windows[cboxActionValue.SelectedIndex]
                    };
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
