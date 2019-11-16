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
            this.lblWebcams = new System.Windows.Forms.Label();
            this.cboxWebcams = new System.Windows.Forms.ComboBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.cboxMouseMovement = new System.Windows.Forms.CheckBox();
            this.btnRemoveAction = new HideNow.Controls.PictureButton();
            this.btnAddAction = new HideNow.Controls.PictureButton();
            this.lstActions = new xServer.Controls.AeroListView();
            this.colActions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValues = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAction)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWebcams
            // 
            this.lblWebcams.AutoSize = true;
            this.lblWebcams.Location = new System.Drawing.Point(9, 361);
            this.lblWebcams.Name = "lblWebcams";
            this.lblWebcams.Size = new System.Drawing.Size(55, 13);
            this.lblWebcams.TabIndex = 2;
            this.lblWebcams.Text = "Webcam";
            // 
            // cboxWebcams
            // 
            this.cboxWebcams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxWebcams.FormattingEnabled = true;
            this.cboxWebcams.Location = new System.Drawing.Point(12, 377);
            this.cboxWebcams.Name = "cboxWebcams";
            this.cboxWebcams.Size = new System.Drawing.Size(366, 21);
            this.cboxWebcams.TabIndex = 3;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(12, 404);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(366, 23);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "Activate monitoring";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // cboxMouseMovement
            // 
            this.cboxMouseMovement.AutoSize = true;
            this.cboxMouseMovement.Location = new System.Drawing.Point(84, 359);
            this.cboxMouseMovement.Name = "cboxMouseMovement";
            this.cboxMouseMovement.Size = new System.Drawing.Size(154, 17);
            this.cboxMouseMovement.TabIndex = 8;
            this.cboxMouseMovement.Text = "Use mouse movement";
            this.cboxMouseMovement.UseVisualStyleBackColor = true;
            this.cboxMouseMovement.CheckedChanged += new System.EventHandler(this.cboxMouseMovement_CheckedChanged);
            // 
            // btnRemoveAction
            // 
            this.btnRemoveAction.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveAction.BackgroundImage = global::HideNow.Properties.Resources.remove;
            this.btnRemoveAction.HoverImage = global::HideNow.Properties.Resources.remove_hover;
            this.btnRemoveAction.Location = new System.Drawing.Point(358, 323);
            this.btnRemoveAction.Name = "btnRemoveAction";
            this.btnRemoveAction.PressedImage = null;
            this.btnRemoveAction.Size = new System.Drawing.Size(25, 25);
            this.btnRemoveAction.TabIndex = 7;
            this.btnRemoveAction.TabStop = false;
            this.btnRemoveAction.Click += new System.EventHandler(this.btnRemoveAction_Click);
            // 
            // btnAddAction
            // 
            this.btnAddAction.BackColor = System.Drawing.Color.Transparent;
            this.btnAddAction.BackgroundImage = global::HideNow.Properties.Resources.add;
            this.btnAddAction.HoverImage = global::HideNow.Properties.Resources.add_hover;
            this.btnAddAction.Location = new System.Drawing.Point(358, 292);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.PressedImage = null;
            this.btnAddAction.Size = new System.Drawing.Size(25, 25);
            this.btnAddAction.TabIndex = 6;
            this.btnAddAction.TabStop = false;
            this.btnAddAction.Click += new System.EventHandler(this.pictureButton1_Click);
            // 
            // lstActions
            // 
            this.lstActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colActions,
            this.colValues});
            this.lstActions.FullRowSelect = true;
            this.lstActions.HideSelection = false;
            this.lstActions.Location = new System.Drawing.Point(0, 0);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(395, 356);
            this.lstActions.TabIndex = 5;
            this.lstActions.UseCompatibleStateImageBehavior = false;
            this.lstActions.View = System.Windows.Forms.View.Details;
            this.lstActions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstActions_KeyUp);
            // 
            // colActions
            // 
            this.colActions.Text = "Action";
            this.colActions.Width = 160;
            // 
            // colValues
            // 
            this.colValues.Text = "Value";
            this.colValues.Width = 230;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 447);
            this.Controls.Add(this.cboxMouseMovement);
            this.Controls.Add(this.btnRemoveAction);
            this.Controls.Add(this.btnAddAction);
            this.Controls.Add(this.lstActions);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.cboxWebcams);
            this.Controls.Add(this.lblWebcams);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "HideNow - Inactive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWebcams;
        private System.Windows.Forms.ComboBox cboxWebcams;
        private System.Windows.Forms.Button btnStatus;
        private xServer.Controls.AeroListView lstActions;
        private System.Windows.Forms.ColumnHeader colActions;
        private System.Windows.Forms.ColumnHeader colValues;
        private Controls.PictureButton btnAddAction;
        private Controls.PictureButton btnRemoveAction;
        private System.Windows.Forms.CheckBox cboxMouseMovement;
    }
}