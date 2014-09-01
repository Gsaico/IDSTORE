namespace IDstore
{
    partial class AxisCamaraIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxisCamaraIP));
            this.userLabel = new System.Windows.Forms.Label();
            this.myFileDialogButton = new System.Windows.Forms.Button();
            this.myRecordButton = new System.Windows.Forms.Button();
            this.myStopButton = new System.Windows.Forms.Button();
            this.myTypeBox = new System.Windows.Forms.ComboBox();
            this.myFileBox = new System.Windows.Forms.TextBox();
            this.myUrlBox = new System.Windows.Forms.TextBox();
            this.myPassBox = new System.Windows.Forms.TextBox();
            this.myUserBox = new System.Windows.Forms.TextBox();
            this.myPlayButton = new System.Windows.Forms.Button();
            this.amc = new AxAXISMEDIACONTROLLib.AxAxisMediaControl();
            this.myPlayFileButton = new System.Windows.Forms.Button();
            this.passLabel = new System.Windows.Forms.Label();
            this.btnsavejpeg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amc)).BeginInit();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userLabel.Location = new System.Drawing.Point(605, 36);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(80, 20);
            this.userLabel.TabIndex = 19;
            this.userLabel.Text = "Username:";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // myFileDialogButton
            // 
            this.myFileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myFileDialogButton.Location = new System.Drawing.Point(749, 244);
            this.myFileDialogButton.Name = "myFileDialogButton";
            this.myFileDialogButton.Size = new System.Drawing.Size(22, 24);
            this.myFileDialogButton.TabIndex = 23;
            this.myFileDialogButton.Text = "...";
            this.myFileDialogButton.Click += new System.EventHandler(this.myFileDialogButton_Click);
            // 
            // myRecordButton
            // 
            this.myRecordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myRecordButton.Location = new System.Drawing.Point(605, 212);
            this.myRecordButton.Name = "myRecordButton";
            this.myRecordButton.Size = new System.Drawing.Size(80, 23);
            this.myRecordButton.TabIndex = 20;
            this.myRecordButton.Text = "Grabar";
            this.myRecordButton.Click += new System.EventHandler(this.myRecordButton_Click);
            // 
            // myStopButton
            // 
            this.myStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myStopButton.Location = new System.Drawing.Point(605, 164);
            this.myStopButton.Name = "myStopButton";
            this.myStopButton.Size = new System.Drawing.Size(168, 23);
            this.myStopButton.TabIndex = 18;
            this.myStopButton.Text = "Detener";
            this.myStopButton.Click += new System.EventHandler(this.myStopButton_Click);
            // 
            // myTypeBox
            // 
            this.myTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myTypeBox.Location = new System.Drawing.Point(605, 84);
            this.myTypeBox.Name = "myTypeBox";
            this.myTypeBox.Size = new System.Drawing.Size(168, 21);
            this.myTypeBox.TabIndex = 15;
            // 
            // myFileBox
            // 
            this.myFileBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myFileBox.Location = new System.Drawing.Point(605, 244);
            this.myFileBox.Name = "myFileBox";
            this.myFileBox.Size = new System.Drawing.Size(138, 20);
            this.myFileBox.TabIndex = 22;
            this.myFileBox.Text = "D:\\AMC_Recording.asf";
            // 
            // myUrlBox
            // 
            this.myUrlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myUrlBox.Location = new System.Drawing.Point(605, 12);
            this.myUrlBox.Name = "myUrlBox";
            this.myUrlBox.Size = new System.Drawing.Size(168, 20);
            this.myUrlBox.TabIndex = 12;
            this.myUrlBox.Text = "169.254.1.55";
            // 
            // myPassBox
            // 
            this.myPassBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myPassBox.Location = new System.Drawing.Point(693, 60);
            this.myPassBox.Name = "myPassBox";
            this.myPassBox.PasswordChar = '*';
            this.myPassBox.Size = new System.Drawing.Size(80, 20);
            this.myPassBox.TabIndex = 14;
            this.myPassBox.Text = "12345";
            // 
            // myUserBox
            // 
            this.myUserBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myUserBox.Location = new System.Drawing.Point(693, 36);
            this.myUserBox.Name = "myUserBox";
            this.myUserBox.Size = new System.Drawing.Size(80, 20);
            this.myUserBox.TabIndex = 13;
            this.myUserBox.Text = "root";
            // 
            // myPlayButton
            // 
            this.myPlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myPlayButton.Location = new System.Drawing.Point(605, 132);
            this.myPlayButton.Name = "myPlayButton";
            this.myPlayButton.Size = new System.Drawing.Size(80, 23);
            this.myPlayButton.TabIndex = 16;
            this.myPlayButton.Text = "Play Live";
            this.myPlayButton.Click += new System.EventHandler(this.myPlayButton_Click);
            // 
            // amc
            // 
            this.amc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amc.Enabled = true;
            this.amc.Location = new System.Drawing.Point(12, 12);
            this.amc.Name = "amc";
            this.amc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("amc.OcxState")));
            this.amc.Size = new System.Drawing.Size(585, 546);
            this.amc.TabIndex = 11;
            this.amc.TabStop = false;
            this.amc.OnError += new AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnErrorEventHandler(this.amc_OnError);
            this.amc.OnStatusChange += new AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnStatusChangeEventHandler(this.amc_OnStatusChange);
            this.amc.OnNewVideoSize += new AxAXISMEDIACONTROLLib._IAxisMediaControlEvents_OnNewVideoSizeEventHandler(this.amc_OnNewVideoSize);
            // 
            // myPlayFileButton
            // 
            this.myPlayFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myPlayFileButton.Location = new System.Drawing.Point(693, 132);
            this.myPlayFileButton.Name = "myPlayFileButton";
            this.myPlayFileButton.Size = new System.Drawing.Size(80, 23);
            this.myPlayFileButton.TabIndex = 17;
            this.myPlayFileButton.Text = "Reproducir Archivo";
            this.myPlayFileButton.Click += new System.EventHandler(this.myPlayFileButton_Click);
            // 
            // passLabel
            // 
            this.passLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passLabel.Location = new System.Drawing.Point(605, 60);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(80, 20);
            this.passLabel.TabIndex = 21;
            this.passLabel.Text = "Password:";
            this.passLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnsavejpeg
            // 
            this.btnsavejpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsavejpeg.Location = new System.Drawing.Point(693, 212);
            this.btnsavejpeg.Name = "btnsavejpeg";
            this.btnsavejpeg.Size = new System.Drawing.Size(80, 23);
            this.btnsavejpeg.TabIndex = 24;
            this.btnsavejpeg.Text = "Guardar JPEG";
            this.btnsavejpeg.UseVisualStyleBackColor = true;
            this.btnsavejpeg.Click += new System.EventHandler(this.btnsavejpeg_Click);
            // 
            // AxisCamaraIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(785, 570);
            this.Controls.Add(this.btnsavejpeg);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.myFileDialogButton);
            this.Controls.Add(this.myRecordButton);
            this.Controls.Add(this.myStopButton);
            this.Controls.Add(this.myTypeBox);
            this.Controls.Add(this.myFileBox);
            this.Controls.Add(this.myUrlBox);
            this.Controls.Add(this.myPassBox);
            this.Controls.Add(this.myUserBox);
            this.Controls.Add(this.myPlayButton);
            this.Controls.Add(this.amc);
            this.Controls.Add(this.myPlayFileButton);
            this.Controls.Add(this.passLabel);
            this.Name = "AxisCamaraIP";
            this.Text = "AxisCamaraIP";
            this.Load += new System.EventHandler(this.AxisCamaraIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button myFileDialogButton;
        private System.Windows.Forms.Button myRecordButton;
        private System.Windows.Forms.Button myStopButton;
        private System.Windows.Forms.ComboBox myTypeBox;
        private System.Windows.Forms.TextBox myFileBox;
        private System.Windows.Forms.TextBox myUrlBox;
        private System.Windows.Forms.TextBox myPassBox;
        private System.Windows.Forms.TextBox myUserBox;
        private System.Windows.Forms.Button myPlayButton;
        private AxAXISMEDIACONTROLLib.AxAxisMediaControl amc;
        private System.Windows.Forms.Button myPlayFileButton;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Button btnsavejpeg;

    }
}