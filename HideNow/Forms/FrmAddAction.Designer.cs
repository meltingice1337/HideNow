namespace HideNow.Forms
{
    partial class FrmAddAction
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
            this.lblActionType = new System.Windows.Forms.Label();
            this.cboxActionType = new System.Windows.Forms.ComboBox();
            this.lblActionValue = new System.Windows.Forms.Label();
            this.cboxActionValue = new System.Windows.Forms.ComboBox();
            this.lblActionOptions = new System.Windows.Forms.Label();
            this.txtActionOptions = new System.Windows.Forms.TextBox();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.Location = new System.Drawing.Point(12, 9);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(73, 13);
            this.lblActionType.TabIndex = 0;
            this.lblActionType.Text = "Action Type";
            // 
            // cboxActionType
            // 
            this.cboxActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxActionType.FormattingEnabled = true;
            this.cboxActionType.Items.AddRange(new object[] {
            "Show Window",
            "Minimize Window",
            "Rename Window",
            "Black Screen",
            "Close Window",
            "Open Application",
            "Close Application"});
            this.cboxActionType.Location = new System.Drawing.Point(12, 25);
            this.cboxActionType.Name = "cboxActionType";
            this.cboxActionType.Size = new System.Drawing.Size(256, 21);
            this.cboxActionType.TabIndex = 1;
            this.cboxActionType.SelectedIndexChanged += new System.EventHandler(this.cboxActionType_SelectedIndexChanged);
            // 
            // lblActionValue
            // 
            this.lblActionValue.AutoSize = true;
            this.lblActionValue.Location = new System.Drawing.Point(12, 49);
            this.lblActionValue.Name = "lblActionValue";
            this.lblActionValue.Size = new System.Drawing.Size(77, 13);
            this.lblActionValue.TabIndex = 2;
            this.lblActionValue.Text = "Action Value";
            // 
            // cboxActionValue
            // 
            this.cboxActionValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxActionValue.FormattingEnabled = true;
            this.cboxActionValue.Location = new System.Drawing.Point(12, 65);
            this.cboxActionValue.Name = "cboxActionValue";
            this.cboxActionValue.Size = new System.Drawing.Size(256, 21);
            this.cboxActionValue.TabIndex = 3;
            // 
            // lblActionOptions
            // 
            this.lblActionOptions.AutoSize = true;
            this.lblActionOptions.Enabled = false;
            this.lblActionOptions.Location = new System.Drawing.Point(12, 89);
            this.lblActionOptions.Name = "lblActionOptions";
            this.lblActionOptions.Size = new System.Drawing.Size(89, 13);
            this.lblActionOptions.TabIndex = 4;
            this.lblActionOptions.Text = "Action Options";
            // 
            // txtActionOptions
            // 
            this.txtActionOptions.Enabled = false;
            this.txtActionOptions.Location = new System.Drawing.Point(15, 105);
            this.txtActionOptions.Name = "txtActionOptions";
            this.txtActionOptions.Size = new System.Drawing.Size(253, 21);
            this.txtActionOptions.TabIndex = 5;
            // 
            // btnAddAction
            // 
            this.btnAddAction.Location = new System.Drawing.Point(12, 137);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(256, 23);
            this.btnAddAction.TabIndex = 6;
            this.btnAddAction.Text = "Add Action";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // FrmAddAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 166);
            this.Controls.Add(this.btnAddAction);
            this.Controls.Add(this.txtActionOptions);
            this.Controls.Add(this.lblActionOptions);
            this.Controls.Add(this.cboxActionValue);
            this.Controls.Add(this.lblActionValue);
            this.Controls.Add(this.cboxActionType);
            this.Controls.Add(this.lblActionType);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAddAction";
            this.Text = "HideNow - Add Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.ComboBox cboxActionType;
        private System.Windows.Forms.Label lblActionValue;
        private System.Windows.Forms.ComboBox cboxActionValue;
        private System.Windows.Forms.Label lblActionOptions;
        private System.Windows.Forms.TextBox txtActionOptions;
        private System.Windows.Forms.Button btnAddAction;
    }
}