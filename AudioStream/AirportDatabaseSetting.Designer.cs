namespace AudioStream
{
    partial class AirportDatabaseSetting
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
            btnLoad = new Button();
            txtDbPath = new TextBox();
            btnBrowser = new Button();
            waitIndicator = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)waitIndicator).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(573, 72);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(104, 35);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtDbPath
            // 
            txtDbPath.BackColor = SystemColors.ControlLight;
            txtDbPath.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtDbPath.ForeColor = SystemColors.Info;
            txtDbPath.Location = new Point(41, 29);
            txtDbPath.Name = "txtDbPath";
            txtDbPath.PlaceholderText = "C:\\\\Program Files\\\\FSUIPC\\\\MakeRunwaysOutput";
            txtDbPath.Size = new Size(582, 27);
            txtDbPath.TabIndex = 1;
            txtDbPath.TextChanged += txtDbPath_TextChanged;
            // 
            // btnBrowser
            // 
            btnBrowser.Location = new Point(629, 30);
            btnBrowser.Name = "btnBrowser";
            btnBrowser.Size = new Size(26, 23);
            btnBrowser.TabIndex = 5;
            btnBrowser.Text = "...";
            btnBrowser.UseVisualStyleBackColor = true;
            btnBrowser.Click += btnBrowser_Click;
            // 
            // waitIndicator
            // 
            waitIndicator.BackColor = Color.OrangeRed;
            waitIndicator.BackgroundImageLayout = ImageLayout.Stretch;
            waitIndicator.Image = Resource1.waiting;
            waitIndicator.InitialImage = Resource1.waiting;
            waitIndicator.Location = new Point(301, 72);
            waitIndicator.Margin = new Padding(0);
            waitIndicator.Name = "waitIndicator";
            waitIndicator.Size = new Size(64, 64);
            waitIndicator.TabIndex = 6;
            waitIndicator.TabStop = false;
            // 
            // AirportDatabaseSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(689, 153);
            Controls.Add(waitIndicator);
            Controls.Add(btnBrowser);
            Controls.Add(btnLoad);
            Controls.Add(txtDbPath);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AirportDatabaseSetting";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Setting AirportDatabase";
            TopMost = true;
            FormClosing += AirportDatabaseSetting_FormClosing;
            ((System.ComponentModel.ISupportInitialize)waitIndicator).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDbPath;
        private Button btnLoad;
        private Button btnBrowser;
        private PictureBox waitIndicator;
    }
}