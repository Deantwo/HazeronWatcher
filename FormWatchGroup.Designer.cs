namespace HazeronWatcher
{
    partial class FormWatchGroup
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
            this.lblName = new System.Windows.Forms.Label();
            this.btnCreateSave = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.cbbxColor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.chbxNotification = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSound = new System.Windows.Forms.Label();
            this.cbbxSound = new System.Windows.Forms.ComboBox();
            this.lblColorTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // btnCreateSave
            // 
            this.btnCreateSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSave.Location = new System.Drawing.Point(121, 123);
            this.btnCreateSave.Name = "btnCreateSave";
            this.btnCreateSave.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSave.TabIndex = 1;
            this.btnCreateSave.Text = "Create/Save";
            this.btnCreateSave.UseVisualStyleBackColor = true;
            this.btnCreateSave.Click += new System.EventHandler(this.btnCreateSave_Click);
            // 
            // tbxName
            // 
            this.tbxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxName.Location = new System.Drawing.Point(80, 12);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(116, 20);
            this.tbxName.TabIndex = 2;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // cbbxColor
            // 
            this.cbbxColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxColor.FormattingEnabled = true;
            this.cbbxColor.Location = new System.Drawing.Point(80, 38);
            this.cbbxColor.Name = "cbbxColor";
            this.cbbxColor.Size = new System.Drawing.Size(74, 21);
            this.cbbxColor.TabIndex = 3;
            this.cbbxColor.SelectedIndexChanged += new System.EventHandler(this.cbbxColor_SelectedIndexChanged);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(12, 41);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Color:";
            // 
            // chbxNotification
            // 
            this.chbxNotification.AutoSize = true;
            this.chbxNotification.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbxNotification.Location = new System.Drawing.Point(12, 65);
            this.chbxNotification.Name = "chbxNotification";
            this.chbxNotification.Size = new System.Drawing.Size(82, 17);
            this.chbxNotification.TabIndex = 5;
            this.chbxNotification.Text = "Notification:";
            this.chbxNotification.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSound
            // 
            this.lblSound.AutoSize = true;
            this.lblSound.Location = new System.Drawing.Point(12, 91);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(41, 13);
            this.lblSound.TabIndex = 7;
            this.lblSound.Text = "Sound:";
            // 
            // cbbxSound
            // 
            this.cbbxSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbxSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxSound.FormattingEnabled = true;
            this.cbbxSound.Location = new System.Drawing.Point(80, 88);
            this.cbbxSound.Name = "cbbxSound";
            this.cbbxSound.Size = new System.Drawing.Size(116, 21);
            this.cbbxSound.TabIndex = 6;
            // 
            // lblColorTest
            // 
            this.lblColorTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorTest.BackColor = System.Drawing.Color.Black;
            this.lblColorTest.Location = new System.Drawing.Point(160, 38);
            this.lblColorTest.Name = "lblColorTest";
            this.lblColorTest.Size = new System.Drawing.Size(36, 21);
            this.lblColorTest.TabIndex = 4;
            this.lblColorTest.Text = "Test";
            this.lblColorTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormWatchGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 158);
            this.Controls.Add(this.lblSound);
            this.Controls.Add(this.cbbxSound);
            this.Controls.Add(this.chbxNotification);
            this.Controls.Add(this.lblColorTest);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cbbxColor);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateSave);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(224, 197);
            this.Name = "FormWatchGroup";
            this.Text = "WatchGroup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCreateSave;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.ComboBox cbbxColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.CheckBox chbxNotification;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSound;
        private System.Windows.Forms.ComboBox cbbxSound;
        private System.Windows.Forms.Label lblColorTest;
    }
}