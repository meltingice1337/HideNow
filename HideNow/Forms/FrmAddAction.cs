using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HideNow.Helper;
using HideNow.Data;
using Action = HideNow.Data.Action;

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
            cboxActionValue.Enabled = lblActionValue.Enabled = true;
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
                case "Black Screen":
                    ToggleControls(false);
                    cboxActionValue.Enabled = lblActionValue.Enabled = false;
                    break;
                default:
                    ToggleControls(false);
                    windows = WindowHelper.GetWindows();
                    cboxActionValue.Items.AddRange(WindowHelper.GetWindowsTitle(windows));
                    break;
            }
            if(cboxActionValue.Items.Count > 0)
                cboxActionValue.SelectedIndex = 0;
        }

        private void ToggleControls(bool enabled)
        {
            lblActionOptions.Enabled = txtActionOptions.Enabled = enabled;
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            Action = new Data.Action();
            Action.ActionType = (ActionType)Enum.Parse(typeof(ActionType), cboxActionType.Text.Replace(" ", ""));

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
                case "Black Screen":
                    MessageBox.Show(this, "Warning: Press F5 to exit the blackscreen", "HideNow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Action.ActionData = new object[]
                    {
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
