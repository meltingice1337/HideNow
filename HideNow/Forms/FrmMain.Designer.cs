namespace HideNow.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWebcams = new System.Windows.Forms.Label();
            this.cboxWebcams = new System.Windows.Forms.ComboBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.lstWindows = new HideNow.ListBoxEx();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 345);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(314, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh windowses";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWebcams
            // 
            this.lblWebcams.AutoSize = true;
            this.lblWebcams.Location = new System.Drawing.Point(9, 371);
            this.lblWebcams.Name = "lblWebcams";
            this.lblWebcams.Size = new System.Drawing.Size(50, 13);
            this.lblWebcams.TabIndex = 2;
            this.lblWebcams.Text = "Webcam";
            // 
            // cboxWebcams
            // 
            this.cboxWebcams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxWebcams.FormattingEnabled = true;
            this.cboxWebcams.Location = new System.Drawing.Point(12, 387);
            this.cboxWebcams.Name = "cboxWebcams";
            this.cboxWebcams.Size = new System.Drawing.Size(314, 21);
            this.cboxWebcams.TabIndex = 3;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(12, 414);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(314, 23);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "Activate monitoring";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // lstWindows
            // 
            this.lstWindows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstWindows.FormattingEnabled = true;
            this.lstWindows.ItemHeight = 40;
            this.lstWindows.Location = new System.Drawing.Point(12, 12);
            this.lstWindows.Name = "lstWindows";
            this.lstWindows.Size = new System.Drawing.Size(317, 322);
            this.lstWindows.TabIndex = 0;
            this.lstWindows.SelectedIndexChanged += new System.EventHandler(this.lstWindows_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 454);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.cboxWebcams);
            this.Controls.Add(this.lblWebcams);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "HideNow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBoxEx lstWindows;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblWebcams;
        private System.Windows.Forms.ComboBox cboxWebcams;
        private System.Windows.Forms.Button btnStatus;
    }
}