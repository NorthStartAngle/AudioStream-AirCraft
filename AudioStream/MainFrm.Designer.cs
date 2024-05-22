namespace AudioStream
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MenuStrip MainMenu;
            ToolStripMenuItem mnuFile;
            ToolStripMenuItem mnuExitInFile;
            ToolStripMenuItem mnuSetting;
            StatusStrip MainStatusBar;
            ToolStripStatusLabel lblConnStatusTitle;
            ToolStripStatusLabel lblSpace;
            ToolStripStatusLabel lblCurrentStreamTitle;
            TableLayoutPanel LayoutAudioControl;
            GroupBox grpAudioPlayer;
            TableLayoutPanel tableLayoutPanel2;
            TableLayoutPanel tableLayoutPanel4;
            Panel panel2;
            Button btnVolumeUp;
            Button btnMute;
            Label lblOutputDeivces;
            Button btnOutputDeviceSave;
            Label lblAudioDelayTitle;
            Label lblSecTitle;
            GroupBox grpCOMFrequence;
            TableLayoutPanel tableLayoutPanel1;
            Label lblActiveTitle;
            Label lblStandbyTitle;
            TabControl tabStream;
            Panel panStreamSearch;
            Button btnSort;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Panel panStreamControl;
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewTextBoxColumn iCAODataGridViewTextBoxColumn1;
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            GroupBox grpStreamInfo;
            TableLayoutPanel LayoutStreamInfo;
            Label lblCity;
            Label lblAirport;
            Label lblCountry;
            Label lblFreqType;
            Label lblFreq;
            Label lablblFileType;
            Label lblFilePath;
            Label lblFileUrl;
            Panel panFreq;
            Label lblFreqHint;
            Panel panFilePath;
            TableLayoutPanel LayoutStreamInfoButtonGroup;
            TableLayoutPanel LayoutBody;
            mnuConnInFile = new ToolStripMenuItem();
            mnuDisconnInFile = new ToolStripMenuItem();
            mnuAutoConnInSetting = new ToolStripMenuItem();
            settingAirportDatabaseToolStripMenuItem = new ToolStripMenuItem();
            mnuAirportFindRadiusInSetting = new ToolStripMenuItem();
            btnMsgFromSim = new ToolStripSplitButton();
            lblConnStatus = new ToolStripStatusLabel();
            lblCurrentStream = new ToolStripStatusLabel();
            lblSimWarning = new ToolStripStatusLabel();
            tableLayoutPanel8 = new TableLayoutPanel();
            VolumeBar = new TrackBar();
            cmbOutputDevices = new ComboBox();
            panel1 = new Panel();
            btnPlay = new Button();
            btnStop = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            iptDelay = new NumericUpDown();
            iptActiveFreq = new TextBox();
            iptStandByFreq = new NumericUpDown();
            btnSwapInCOM = new Button();
            tabPage2 = new TabPage();
            iptSearchBox = new TextBox();
            label16 = new Label();
            tblStream = new DataGridView();
            iCAODataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            airportDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            freqTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            freqDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            filePathDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataItemBindingSource = new BindingSource(components);
            btnStreamAdd = new Button();
            btnStreamDelete = new Button();
            btnStreamPreview = new Button();
            tabPage1 = new TabPage();
            tblAirports = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cityDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            distanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            airportItemBindingSource = new BindingSource(components);
            lblICAO = new Label();
            txtICAO = new TextBox();
            label1 = new Label();
            txtCity = new TextBox();
            txtAirport = new TextBox();
            txtCountry = new TextBox();
            cmbFreqType = new ComboBox();
            txtFreq = new MaskedTextBox();
            cmbFileType = new ComboBox();
            txtFileUrl = new TextBox();
            btnFilePathBrowser = new Button();
            txtFilePath = new TextBox();
            btnInfoSave = new Button();
            MainMenu = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuExitInFile = new ToolStripMenuItem();
            mnuSetting = new ToolStripMenuItem();
            MainStatusBar = new StatusStrip();
            lblConnStatusTitle = new ToolStripStatusLabel();
            lblSpace = new ToolStripStatusLabel();
            lblCurrentStreamTitle = new ToolStripStatusLabel();
            LayoutAudioControl = new TableLayoutPanel();
            grpAudioPlayer = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel2 = new Panel();
            btnVolumeUp = new Button();
            btnMute = new Button();
            lblOutputDeivces = new Label();
            btnOutputDeviceSave = new Button();
            lblAudioDelayTitle = new Label();
            lblSecTitle = new Label();
            grpCOMFrequence = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblActiveTitle = new Label();
            lblStandbyTitle = new Label();
            tabStream = new TabControl();
            panStreamSearch = new Panel();
            btnSort = new Button();
            panStreamControl = new Panel();
            iCAODataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            grpStreamInfo = new GroupBox();
            LayoutStreamInfo = new TableLayoutPanel();
            lblCity = new Label();
            lblAirport = new Label();
            lblCountry = new Label();
            lblFreqType = new Label();
            lblFreq = new Label();
            lablblFileType = new Label();
            lblFilePath = new Label();
            lblFileUrl = new Label();
            panFreq = new Panel();
            lblFreqHint = new Label();
            panFilePath = new Panel();
            LayoutStreamInfoButtonGroup = new TableLayoutPanel();
            LayoutBody = new TableLayoutPanel();
            MainMenu.SuspendLayout();
            MainStatusBar.SuspendLayout();
            LayoutAudioControl.SuspendLayout();
            grpAudioPlayer.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iptDelay).BeginInit();
            grpCOMFrequence.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iptStandByFreq).BeginInit();
            tabStream.SuspendLayout();
            tabPage2.SuspendLayout();
            panStreamSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblStream).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataItemBindingSource).BeginInit();
            panStreamControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblAirports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)airportItemBindingSource).BeginInit();
            grpStreamInfo.SuspendLayout();
            LayoutStreamInfo.SuspendLayout();
            panFreq.SuspendLayout();
            panFilePath.SuspendLayout();
            LayoutStreamInfoButtonGroup.SuspendLayout();
            LayoutBody.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { mnuFile, mnuSetting });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new Padding(0);
            MainMenu.Size = new Size(1199, 24);
            MainMenu.TabIndex = 1;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuConnInFile, mnuDisconnInFile, mnuExitInFile });
            mnuFile.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(44, 24);
            mnuFile.Text = "&File";
            // 
            // mnuConnInFile
            // 
            mnuConnInFile.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            mnuConnInFile.Name = "mnuConnInFile";
            mnuConnInFile.Size = new Size(257, 24);
            mnuConnInFile.Text = "Connect To Simulator";
            mnuConnInFile.Click += mnuConnInFile_Click;
            // 
            // mnuDisconnInFile
            // 
            mnuDisconnInFile.Enabled = false;
            mnuDisconnInFile.Name = "mnuDisconnInFile";
            mnuDisconnInFile.Size = new Size(257, 24);
            mnuDisconnInFile.Text = "Disconnect From Simulator";
            mnuDisconnInFile.Click += mnuDisconnInFile_Click;
            // 
            // mnuExitInFile
            // 
            mnuExitInFile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            mnuExitInFile.Name = "mnuExitInFile";
            mnuExitInFile.ShortcutKeys = Keys.Control | Keys.Shift | Keys.X;
            mnuExitInFile.Size = new Size(257, 24);
            mnuExitInFile.Text = "E&xit";
            mnuExitInFile.Click += mnuExitInFile_Click;
            // 
            // mnuSetting
            // 
            mnuSetting.DropDownItems.AddRange(new ToolStripItem[] { mnuAutoConnInSetting, settingAirportDatabaseToolStripMenuItem, mnuAirportFindRadiusInSetting });
            mnuSetting.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            mnuSetting.Name = "mnuSetting";
            mnuSetting.Size = new Size(68, 24);
            mnuSetting.Text = "&Setting";
            // 
            // mnuAutoConnInSetting
            // 
            mnuAutoConnInSetting.Checked = true;
            mnuAutoConnInSetting.CheckOnClick = true;
            mnuAutoConnInSetting.CheckState = CheckState.Checked;
            mnuAutoConnInSetting.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            mnuAutoConnInSetting.Name = "mnuAutoConnInSetting";
            mnuAutoConnInSetting.Size = new Size(243, 24);
            mnuAutoConnInSetting.Text = "Auto Connect To Simulator";
            mnuAutoConnInSetting.CheckedChanged += mnuAutoConnInSetting_CheckedChanged;
            // 
            // settingAirportDatabaseToolStripMenuItem
            // 
            settingAirportDatabaseToolStripMenuItem.Name = "settingAirportDatabaseToolStripMenuItem";
            settingAirportDatabaseToolStripMenuItem.Size = new Size(243, 24);
            settingAirportDatabaseToolStripMenuItem.Text = "Setting AirportDatabase";
            settingAirportDatabaseToolStripMenuItem.Click += settingAirportDatabaseToolStripMenuItem_Click;
            // 
            // mnuAirportFindRadiusInSetting
            // 
            mnuAirportFindRadiusInSetting.Name = "mnuAirportFindRadiusInSetting";
            mnuAirportFindRadiusInSetting.Size = new Size(243, 24);
            mnuAirportFindRadiusInSetting.Text = "Max Airport Radius";
            mnuAirportFindRadiusInSetting.Click += mnuAirportFindRadiusInSetting_Click;
            // 
            // MainStatusBar
            // 
            MainStatusBar.Items.AddRange(new ToolStripItem[] { btnMsgFromSim, lblConnStatusTitle, lblConnStatus, lblSpace, lblCurrentStreamTitle, lblCurrentStream, lblSimWarning });
            MainStatusBar.Location = new Point(0, 583);
            MainStatusBar.Name = "MainStatusBar";
            MainStatusBar.Size = new Size(1199, 25);
            MainStatusBar.TabIndex = 2;
            MainStatusBar.Text = "statusStrip1";
            // 
            // btnMsgFromSim
            // 
            btnMsgFromSim.Alignment = ToolStripItemAlignment.Right;
            btnMsgFromSim.BackgroundImageLayout = ImageLayout.Zoom;
            btnMsgFromSim.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMsgFromSim.DropDownButtonWidth = 10;
            btnMsgFromSim.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnMsgFromSim.Image = Resource1.chat;
            btnMsgFromSim.ImageAlign = ContentAlignment.MiddleLeft;
            btnMsgFromSim.ImageTransparentColor = Color.Magenta;
            btnMsgFromSim.Margin = new Padding(5, 2, 5, 0);
            btnMsgFromSim.Name = "btnMsgFromSim";
            btnMsgFromSim.Overflow = ToolStripItemOverflow.Never;
            btnMsgFromSim.Size = new Size(31, 23);
            btnMsgFromSim.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblConnStatusTitle
            // 
            lblConnStatusTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblConnStatusTitle.Name = "lblConnStatusTitle";
            lblConnStatusTitle.Size = new Size(107, 20);
            lblConnStatusTitle.Text = "Connect Status";
            // 
            // lblConnStatus
            // 
            lblConnStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblConnStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblConnStatus.ForeColor = Color.Red;
            lblConnStatus.Name = "lblConnStatus";
            lblConnStatus.Size = new Size(89, 20);
            lblConnStatus.Text = "disconnected";
            // 
            // lblSpace
            // 
            lblSpace.Name = "lblSpace";
            lblSpace.Size = new Size(819, 20);
            lblSpace.Spring = true;
            // 
            // lblCurrentStreamTitle
            // 
            lblCurrentStreamTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCurrentStreamTitle.Name = "lblCurrentStreamTitle";
            lblCurrentStreamTitle.Size = new Size(108, 20);
            lblCurrentStreamTitle.Text = "Current Stream";
            // 
            // lblCurrentStream
            // 
            lblCurrentStream.BorderSides = ToolStripStatusLabelBorderSides.Bottom;
            lblCurrentStream.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblCurrentStream.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentStream.ForeColor = Color.Black;
            lblCurrentStream.Name = "lblCurrentStream";
            lblCurrentStream.Overflow = ToolStripItemOverflow.Never;
            lblCurrentStream.Size = new Size(4, 20);
            // 
            // lblSimWarning
            // 
            lblSimWarning.Image = Resource1.warning;
            lblSimWarning.Name = "lblSimWarning";
            lblSimWarning.Size = new Size(16, 20);
            // 
            // LayoutAudioControl
            // 
            LayoutAudioControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LayoutAudioControl.ColumnCount = 2;
            LayoutAudioControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            LayoutAudioControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            LayoutAudioControl.Controls.Add(grpAudioPlayer, 1, 0);
            LayoutAudioControl.Controls.Add(grpCOMFrequence, 0, 0);
            LayoutAudioControl.Dock = DockStyle.Bottom;
            LayoutAudioControl.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            LayoutAudioControl.Location = new Point(0, 483);
            LayoutAudioControl.MaximumSize = new Size(0, 100);
            LayoutAudioControl.MinimumSize = new Size(0, 100);
            LayoutAudioControl.Name = "LayoutAudioControl";
            LayoutAudioControl.RowCount = 1;
            LayoutAudioControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            LayoutAudioControl.Size = new Size(1199, 100);
            LayoutAudioControl.TabIndex = 3;
            // 
            // grpAudioPlayer
            // 
            grpAudioPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            grpAudioPlayer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpAudioPlayer.Controls.Add(tableLayoutPanel2);
            grpAudioPlayer.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpAudioPlayer.Location = new Point(376, 3);
            grpAudioPlayer.Margin = new Padding(3, 3, 20, 3);
            grpAudioPlayer.MaximumSize = new Size(800, 100);
            grpAudioPlayer.Name = "grpAudioPlayer";
            grpAudioPlayer.Size = new Size(789, 94);
            grpAudioPlayer.TabIndex = 2;
            grpAudioPlayer.TabStop = false;
            grpAudioPlayer.Text = "Audio Player";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 3, 0);
            tableLayoutPanel2.Controls.Add(panel1, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel2.Location = new Point(3, 21);
            tableLayoutPanel2.Margin = new Padding(10, 3, 20, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(783, 70);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.Controls.Add(panel2, 0, 0);
            tableLayoutPanel4.Controls.Add(lblOutputDeivces, 0, 1);
            tableLayoutPanel4.Controls.Add(btnOutputDeviceSave, 2, 1);
            tableLayoutPanel4.Controls.Add(cmbOutputDevices, 1, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(350, 0);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(433, 70);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // panel2
            // 
            tableLayoutPanel4.SetColumnSpan(panel2, 3);
            panel2.Controls.Add(tableLayoutPanel8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(50, 2);
            panel2.Margin = new Padding(50, 2, 50, 2);
            panel2.MaximumSize = new Size(400, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(333, 31);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel8.Controls.Add(btnVolumeUp, 2, 0);
            tableLayoutPanel8.Controls.Add(VolumeBar, 1, 0);
            tableLayoutPanel8.Controls.Add(btnMute, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(333, 31);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // btnVolumeUp
            // 
            btnVolumeUp.Dock = DockStyle.Fill;
            btnVolumeUp.FlatAppearance.BorderSize = 0;
            btnVolumeUp.FlatStyle = FlatStyle.Flat;
            btnVolumeUp.Image = Resource1.volumn_max;
            btnVolumeUp.ImeMode = ImeMode.NoControl;
            btnVolumeUp.Location = new Point(286, 3);
            btnVolumeUp.Name = "btnVolumeUp";
            btnVolumeUp.Size = new Size(44, 25);
            btnVolumeUp.TabIndex = 1;
            btnVolumeUp.UseVisualStyleBackColor = true;
            btnVolumeUp.Click += btnVolumeUp_Click;
            // 
            // VolumeBar
            // 
            VolumeBar.AutoSize = false;
            VolumeBar.Dock = DockStyle.Fill;
            VolumeBar.ImeMode = ImeMode.NoControl;
            VolumeBar.Location = new Point(53, 3);
            VolumeBar.Maximum = 100;
            VolumeBar.Name = "VolumeBar";
            VolumeBar.Size = new Size(227, 25);
            VolumeBar.SmallChange = 5;
            VolumeBar.TabIndex = 2;
            VolumeBar.TickFrequency = 10;
            VolumeBar.Scroll += VolumeBar_Scroll;
            VolumeBar.ValueChanged += VolumeBar_ValueChanged;
            // 
            // btnMute
            // 
            btnMute.Dock = DockStyle.Fill;
            btnMute.FlatAppearance.BorderSize = 0;
            btnMute.FlatStyle = FlatStyle.Flat;
            btnMute.Image = Resource1.mute;
            btnMute.ImeMode = ImeMode.NoControl;
            btnMute.Location = new Point(0, 0);
            btnMute.Margin = new Padding(0);
            btnMute.Name = "btnMute";
            btnMute.Size = new Size(50, 31);
            btnMute.TabIndex = 0;
            btnMute.UseVisualStyleBackColor = true;
            btnMute.Click += btnMute_Click;
            // 
            // lblOutputDeivces
            // 
            lblOutputDeivces.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOutputDeivces.AutoSize = true;
            lblOutputDeivces.ImeMode = ImeMode.NoControl;
            lblOutputDeivces.Location = new Point(46, 43);
            lblOutputDeivces.Margin = new Padding(3, 8, 3, 0);
            lblOutputDeivces.Name = "lblOutputDeivces";
            lblOutputDeivces.Size = new Size(98, 19);
            lblOutputDeivces.TabIndex = 1;
            lblOutputDeivces.Text = "Output Device";
            // 
            // btnOutputDeviceSave
            // 
            btnOutputDeviceSave.BackgroundImageLayout = ImageLayout.None;
            btnOutputDeviceSave.FlatAppearance.BorderSize = 0;
            btnOutputDeviceSave.FlatStyle = FlatStyle.Flat;
            btnOutputDeviceSave.Image = Resource1.save_2;
            btnOutputDeviceSave.ImeMode = ImeMode.NoControl;
            btnOutputDeviceSave.Location = new Point(395, 35);
            btnOutputDeviceSave.Margin = new Padding(3, 0, 3, 3);
            btnOutputDeviceSave.Name = "btnOutputDeviceSave";
            btnOutputDeviceSave.Size = new Size(34, 29);
            btnOutputDeviceSave.TabIndex = 3;
            btnOutputDeviceSave.UseVisualStyleBackColor = true;
            btnOutputDeviceSave.Click += btnOutputDeviceSave_Click;
            // 
            // cmbOutputDevices
            // 
            cmbOutputDevices.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbOutputDevices.FormattingEnabled = true;
            cmbOutputDevices.Location = new Point(152, 40);
            cmbOutputDevices.Margin = new Padding(5, 5, 5, 3);
            cmbOutputDevices.Name = "cmbOutputDevices";
            cmbOutputDevices.Size = new Size(235, 25);
            cmbOutputDevices.TabIndex = 2;
            cmbOutputDevices.SelectedIndexChanged += cmbOutputDevices_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(btnPlay);
            panel1.Controls.Add(btnStop);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(144, 64);
            panel1.TabIndex = 0;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlay.BackColor = SystemColors.Control;
            btnPlay.BackgroundImageLayout = ImageLayout.None;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Image = Resource1.play;
            btnPlay.ImeMode = ImeMode.NoControl;
            btnPlay.Location = new Point(89, 26);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(32, 26);
            btnPlay.TabIndex = 1;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnStop
            // 
            btnStop.BackgroundImageLayout = ImageLayout.None;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Image = Resource1.stop;
            btnStop.ImeMode = ImeMode.NoControl;
            btnStop.Location = new Point(22, 24);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(32, 26);
            btnStop.TabIndex = 0;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(lblAudioDelayTitle, 0, 0);
            tableLayoutPanel3.Controls.Add(lblSecTitle, 1, 1);
            tableLayoutPanel3.Controls.Add(iptDelay, 0, 1);
            tableLayoutPanel3.Location = new Point(153, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.Size = new Size(194, 64);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // lblAudioDelayTitle
            // 
            tableLayoutPanel3.SetColumnSpan(lblAudioDelayTitle, 2);
            lblAudioDelayTitle.Dock = DockStyle.Fill;
            lblAudioDelayTitle.ForeColor = SystemColors.AppWorkspace;
            lblAudioDelayTitle.ImeMode = ImeMode.NoControl;
            lblAudioDelayTitle.Location = new Point(3, 0);
            lblAudioDelayTitle.Name = "lblAudioDelayTitle";
            lblAudioDelayTitle.Size = new Size(188, 19);
            lblAudioDelayTitle.TabIndex = 0;
            lblAudioDelayTitle.Text = "Audio Delay";
            lblAudioDelayTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSecTitle
            // 
            lblSecTitle.AutoSize = true;
            lblSecTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSecTitle.ImeMode = ImeMode.NoControl;
            lblSecTitle.Location = new Point(102, 29);
            lblSecTitle.Margin = new Padding(5, 10, 5, 0);
            lblSecTitle.Name = "lblSecTitle";
            lblSecTitle.Size = new Size(32, 21);
            lblSecTitle.TabIndex = 2;
            lblSecTitle.Text = "sec";
            // 
            // iptDelay
            // 
            iptDelay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iptDelay.Location = new Point(29, 29);
            iptDelay.Margin = new Padding(3, 10, 3, 3);
            iptDelay.Name = "iptDelay";
            iptDelay.Size = new Size(65, 25);
            iptDelay.TabIndex = 3;
            iptDelay.TextAlign = HorizontalAlignment.Center;
            // 
            // grpCOMFrequence
            // 
            grpCOMFrequence.Anchor = AnchorStyles.Top;
            grpCOMFrequence.Controls.Add(tableLayoutPanel1);
            grpCOMFrequence.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpCOMFrequence.Location = new Point(29, 5);
            grpCOMFrequence.Margin = new Padding(5);
            grpCOMFrequence.MaximumSize = new Size(300, 0);
            grpCOMFrequence.MinimumSize = new Size(280, 0);
            grpCOMFrequence.Name = "grpCOMFrequence";
            grpCOMFrequence.Padding = new Padding(10, 3, 10, 3);
            grpCOMFrequence.Size = new Size(300, 90);
            grpCOMFrequence.TabIndex = 1;
            grpCOMFrequence.TabStop = false;
            grpCOMFrequence.Text = "COM1 Frequency";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.9591827F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.0408173F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel1.Controls.Add(lblActiveTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(lblStandbyTitle, 2, 0);
            tableLayoutPanel1.Controls.Add(iptActiveFreq, 0, 1);
            tableLayoutPanel1.Controls.Add(iptStandByFreq, 2, 1);
            tableLayoutPanel1.Controls.Add(btnSwapInCOM, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 21);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(280, 66);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblActiveTitle
            // 
            lblActiveTitle.Anchor = AnchorStyles.None;
            lblActiveTitle.AutoSize = true;
            lblActiveTitle.ImeMode = ImeMode.NoControl;
            lblActiveTitle.Location = new Point(21, 7);
            lblActiveTitle.Name = "lblActiveTitle";
            lblActiveTitle.Size = new Size(46, 19);
            lblActiveTitle.TabIndex = 0;
            lblActiveTitle.Text = "Active";
            lblActiveTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStandbyTitle
            // 
            lblStandbyTitle.Anchor = AnchorStyles.None;
            lblStandbyTitle.AutoSize = true;
            lblStandbyTitle.ImeMode = ImeMode.NoControl;
            lblStandbyTitle.Location = new Point(203, 7);
            lblStandbyTitle.Name = "lblStandbyTitle";
            lblStandbyTitle.Size = new Size(59, 19);
            lblStandbyTitle.TabIndex = 1;
            lblStandbyTitle.Text = "Standby";
            lblStandbyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iptActiveFreq
            // 
            iptActiveFreq.Anchor = AnchorStyles.None;
            iptActiveFreq.Enabled = false;
            iptActiveFreq.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            iptActiveFreq.HideSelection = false;
            iptActiveFreq.Location = new Point(6, 36);
            iptActiveFreq.Name = "iptActiveFreq";
            iptActiveFreq.ReadOnly = true;
            iptActiveFreq.Size = new Size(76, 27);
            iptActiveFreq.TabIndex = 2;
            iptActiveFreq.TextAlign = HorizontalAlignment.Center;
            // 
            // iptStandByFreq
            // 
            iptStandByFreq.Anchor = AnchorStyles.None;
            iptStandByFreq.BorderStyle = BorderStyle.FixedSingle;
            iptStandByFreq.DecimalPlaces = 3;
            iptStandByFreq.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            iptStandByFreq.Increment = new decimal(new int[] { 25, 0, 0, 196608 });
            iptStandByFreq.Location = new Point(189, 36);
            iptStandByFreq.Maximum = new decimal(new int[] { 137995, 0, 0, 196608 });
            iptStandByFreq.Minimum = new decimal(new int[] { 118000, 0, 0, 196608 });
            iptStandByFreq.Name = "iptStandByFreq";
            iptStandByFreq.Size = new Size(87, 27);
            iptStandByFreq.TabIndex = 3;
            iptStandByFreq.TextAlign = HorizontalAlignment.Center;
            iptStandByFreq.ThousandsSeparator = true;
            iptStandByFreq.Value = new decimal(new int[] { 118000, 0, 0, 196608 });
            iptStandByFreq.ValueChanged += iptStandByFreq_ValueChanged;
            // 
            // btnSwapInCOM
            // 
            btnSwapInCOM.Anchor = AnchorStyles.None;
            btnSwapInCOM.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSwapInCOM.ImeMode = ImeMode.NoControl;
            btnSwapInCOM.Location = new Point(99, 37);
            btnSwapInCOM.Name = "btnSwapInCOM";
            btnSwapInCOM.Size = new Size(75, 25);
            btnSwapInCOM.TabIndex = 4;
            btnSwapInCOM.Text = "Swap";
            btnSwapInCOM.UseVisualStyleBackColor = true;
            btnSwapInCOM.Click += btnSwapFreq;
            // 
            // tabStream
            // 
            tabStream.Controls.Add(tabPage2);
            tabStream.Controls.Add(tabPage1);
            tabStream.Dock = DockStyle.Fill;
            tabStream.Location = new Point(5, 5);
            tabStream.Margin = new Padding(5);
            tabStream.Name = "tabStream";
            tabStream.SelectedIndex = 0;
            tabStream.Size = new Size(829, 449);
            tabStream.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panStreamSearch);
            tabPage2.Controls.Add(tblStream);
            tabPage2.Controls.Add(panStreamControl);
            tabPage2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(821, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Stream";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panStreamSearch
            // 
            panStreamSearch.BackColor = Color.DeepSkyBlue;
            panStreamSearch.Controls.Add(btnSort);
            panStreamSearch.Controls.Add(iptSearchBox);
            panStreamSearch.Controls.Add(label16);
            panStreamSearch.Dock = DockStyle.Top;
            panStreamSearch.Location = new Point(3, 3);
            panStreamSearch.Name = "panStreamSearch";
            panStreamSearch.Size = new Size(815, 54);
            panStreamSearch.TabIndex = 4;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.DeepSkyBlue;
            btnSort.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSort.Image = Resource1.sort;
            btnSort.ImeMode = ImeMode.NoControl;
            btnSort.Location = new Point(2, 2);
            btnSort.Margin = new Padding(0);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(44, 50);
            btnSort.TabIndex = 2;
            btnSort.UseMnemonic = false;
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click;
            // 
            // iptSearchBox
            // 
            iptSearchBox.AcceptsReturn = true;
            iptSearchBox.Anchor = AnchorStyles.Top;
            iptSearchBox.BorderStyle = BorderStyle.FixedSingle;
            iptSearchBox.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            iptSearchBox.Location = new Point(392, 14);
            iptSearchBox.Margin = new Padding(3, 5, 3, 3);
            iptSearchBox.MaximumSize = new Size(200, 40);
            iptSearchBox.MinimumSize = new Size(180, 30);
            iptSearchBox.Name = "iptSearchBox";
            iptSearchBox.Size = new Size(200, 31);
            iptSearchBox.TabIndex = 1;
            iptSearchBox.TextAlign = HorizontalAlignment.Center;
            iptSearchBox.TextChanged += iptSearchBox_TextChanged;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top;
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = Color.DarkRed;
            label16.ImeMode = ImeMode.NoControl;
            label16.Location = new Point(255, 18);
            label16.Name = "label16";
            label16.Size = new Size(126, 21);
            label16.TabIndex = 0;
            label16.Text = "Search Streams";
            // 
            // tblStream
            // 
            tblStream.AllowUserToAddRows = false;
            tblStream.AllowUserToDeleteRows = false;
            tblStream.AllowUserToOrderColumns = true;
            tblStream.AllowUserToResizeRows = false;
            tblStream.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblStream.AutoGenerateColumns = false;
            tblStream.BorderStyle = BorderStyle.Fixed3D;
            tblStream.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tblStream.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tblStream.ColumnHeadersHeight = 40;
            tblStream.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tblStream.Columns.AddRange(new DataGridViewColumn[] { iCAODataGridViewTextBoxColumn, airportDataGridViewTextBoxColumn, cityDataGridViewTextBoxColumn, countryDataGridViewTextBoxColumn, freqTypeDataGridViewTextBoxColumn, freqDataGridViewTextBoxColumn, filePathDataGridViewTextBoxColumn });
            tblStream.DataSource = dataItemBindingSource;
            tblStream.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblStream.Location = new Point(3, 58);
            tblStream.MultiSelect = false;
            tblStream.Name = "tblStream";
            tblStream.ReadOnly = true;
            tblStream.RowHeadersWidth = 30;
            tblStream.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tblStream.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Tai Le", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tblStream.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            tblStream.RowTemplate.Height = 30;
            tblStream.RowTemplate.ReadOnly = true;
            tblStream.RowTemplate.Resizable = DataGridViewTriState.True;
            tblStream.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblStream.ShowCellErrors = false;
            tblStream.ShowEditingIcon = false;
            tblStream.ShowRowErrors = false;
            tblStream.Size = new Size(815, 296);
            tblStream.TabIndex = 3;
            tblStream.VirtualMode = true;
            // 
            // iCAODataGridViewTextBoxColumn
            // 
            iCAODataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            iCAODataGridViewTextBoxColumn.DataPropertyName = "ICAO";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            iCAODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            iCAODataGridViewTextBoxColumn.HeaderText = "ICAO";
            iCAODataGridViewTextBoxColumn.Name = "iCAODataGridViewTextBoxColumn";
            iCAODataGridViewTextBoxColumn.ReadOnly = true;
            iCAODataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            iCAODataGridViewTextBoxColumn.Width = 80;
            // 
            // airportDataGridViewTextBoxColumn
            // 
            airportDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            airportDataGridViewTextBoxColumn.DataPropertyName = "Airport";
            airportDataGridViewTextBoxColumn.HeaderText = "Airport";
            airportDataGridViewTextBoxColumn.Name = "airportDataGridViewTextBoxColumn";
            airportDataGridViewTextBoxColumn.ReadOnly = true;
            airportDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            airportDataGridViewTextBoxColumn.Width = 350;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            cityDataGridViewTextBoxColumn.HeaderText = "City";
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            cityDataGridViewTextBoxColumn.ReadOnly = true;
            cityDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            cityDataGridViewTextBoxColumn.Width = 150;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            countryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            countryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            countryDataGridViewTextBoxColumn.HeaderText = "Country";
            countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            countryDataGridViewTextBoxColumn.ReadOnly = true;
            countryDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // freqTypeDataGridViewTextBoxColumn
            // 
            freqTypeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            freqTypeDataGridViewTextBoxColumn.DataPropertyName = "FreqType";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            freqTypeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            freqTypeDataGridViewTextBoxColumn.HeaderText = "FreqType";
            freqTypeDataGridViewTextBoxColumn.Name = "freqTypeDataGridViewTextBoxColumn";
            freqTypeDataGridViewTextBoxColumn.ReadOnly = true;
            freqTypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // freqDataGridViewTextBoxColumn
            // 
            freqDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            freqDataGridViewTextBoxColumn.DataPropertyName = "Freq";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            freqDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            freqDataGridViewTextBoxColumn.HeaderText = "Freq";
            freqDataGridViewTextBoxColumn.Name = "freqDataGridViewTextBoxColumn";
            freqDataGridViewTextBoxColumn.ReadOnly = true;
            freqDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            freqDataGridViewTextBoxColumn.Width = 150;
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            filePathDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            filePathDataGridViewTextBoxColumn.FillWeight = 200F;
            filePathDataGridViewTextBoxColumn.HeaderText = "FilePath";
            filePathDataGridViewTextBoxColumn.MinimumWidth = 100;
            filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            filePathDataGridViewTextBoxColumn.ReadOnly = true;
            filePathDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // dataItemBindingSource
            // 
            dataItemBindingSource.DataSource = typeof(Modules.DataItem);
            // 
            // panStreamControl
            // 
            panStreamControl.Controls.Add(btnStreamAdd);
            panStreamControl.Controls.Add(btnStreamDelete);
            panStreamControl.Controls.Add(btnStreamPreview);
            panStreamControl.Dock = DockStyle.Bottom;
            panStreamControl.Location = new Point(3, 354);
            panStreamControl.MaximumSize = new Size(0, 60);
            panStreamControl.Name = "panStreamControl";
            panStreamControl.Size = new Size(815, 60);
            panStreamControl.TabIndex = 2;
            // 
            // btnStreamAdd
            // 
            btnStreamAdd.BackColor = Color.Gainsboro;
            btnStreamAdd.FlatAppearance.BorderSize = 0;
            btnStreamAdd.FlatStyle = FlatStyle.Popup;
            btnStreamAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnStreamAdd.Image = Resource1.add;
            btnStreamAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnStreamAdd.ImeMode = ImeMode.NoControl;
            btnStreamAdd.Location = new Point(266, 6);
            btnStreamAdd.Name = "btnStreamAdd";
            btnStreamAdd.Padding = new Padding(10, 0, 5, 0);
            btnStreamAdd.Size = new Size(120, 50);
            btnStreamAdd.TabIndex = 2;
            btnStreamAdd.Text = "    Add Stream";
            btnStreamAdd.TextAlign = ContentAlignment.MiddleRight;
            btnStreamAdd.UseMnemonic = false;
            btnStreamAdd.UseVisualStyleBackColor = false;
            btnStreamAdd.Click += btnStreamAdd_Click;
            // 
            // btnStreamDelete
            // 
            btnStreamDelete.BackColor = Color.Gainsboro;
            btnStreamDelete.FlatAppearance.BorderSize = 0;
            btnStreamDelete.FlatStyle = FlatStyle.Popup;
            btnStreamDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnStreamDelete.Image = Resource1.remove;
            btnStreamDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnStreamDelete.ImeMode = ImeMode.NoControl;
            btnStreamDelete.Location = new Point(137, 6);
            btnStreamDelete.Name = "btnStreamDelete";
            btnStreamDelete.Padding = new Padding(10, 0, 5, 0);
            btnStreamDelete.Size = new Size(120, 50);
            btnStreamDelete.TabIndex = 1;
            btnStreamDelete.Text = "    Delete Stream";
            btnStreamDelete.TextAlign = ContentAlignment.MiddleRight;
            btnStreamDelete.UseMnemonic = false;
            btnStreamDelete.UseVisualStyleBackColor = false;
            btnStreamDelete.Click += btnStreamDelete_Click;
            // 
            // btnStreamPreview
            // 
            btnStreamPreview.BackColor = Color.Gainsboro;
            btnStreamPreview.FlatAppearance.BorderSize = 0;
            btnStreamPreview.FlatStyle = FlatStyle.Popup;
            btnStreamPreview.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnStreamPreview.Image = Resource1.sound_on;
            btnStreamPreview.ImageAlign = ContentAlignment.MiddleLeft;
            btnStreamPreview.ImeMode = ImeMode.NoControl;
            btnStreamPreview.Location = new Point(7, 6);
            btnStreamPreview.Name = "btnStreamPreview";
            btnStreamPreview.Padding = new Padding(10, 0, 5, 0);
            btnStreamPreview.Size = new Size(120, 50);
            btnStreamPreview.TabIndex = 0;
            btnStreamPreview.Text = "     Preview Stream";
            btnStreamPreview.TextAlign = ContentAlignment.MiddleRight;
            btnStreamPreview.UseMnemonic = false;
            btnStreamPreview.UseVisualStyleBackColor = false;
            btnStreamPreview.Click += btnStreamPreview_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tblAirports);
            tabPage1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(821, 417);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Nearby Airports";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tblAirports
            // 
            tblAirports.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            tblAirports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            tblAirports.ColumnHeadersHeight = 40;
            tblAirports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tblAirports.Columns.AddRange(new DataGridViewColumn[] { iCAODataGridViewTextBoxColumn1, nameDataGridViewTextBoxColumn, cityDataGridViewTextBoxColumn1, locationDataGridViewTextBoxColumn, distanceDataGridViewTextBoxColumn });
            tblAirports.DataSource = airportItemBindingSource;
            tblAirports.Dock = DockStyle.Fill;
            tblAirports.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblAirports.Location = new Point(3, 3);
            tblAirports.Name = "tblAirports";
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            tblAirports.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            tblAirports.RowHeadersWidth = 30;
            tblAirports.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tblAirports.RowTemplate.Height = 28;
            tblAirports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblAirports.Size = new Size(815, 411);
            tblAirports.TabIndex = 0;
            // 
            // iCAODataGridViewTextBoxColumn1
            // 
            iCAODataGridViewTextBoxColumn1.DataPropertyName = "ICAO";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            iCAODataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            iCAODataGridViewTextBoxColumn1.HeaderText = "ICAO";
            iCAODataGridViewTextBoxColumn1.Name = "iCAODataGridViewTextBoxColumn1";
            iCAODataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            iCAODataGridViewTextBoxColumn1.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // cityDataGridViewTextBoxColumn1
            // 
            cityDataGridViewTextBoxColumn1.DataPropertyName = "City";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cityDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            cityDataGridViewTextBoxColumn1.HeaderText = "City";
            cityDataGridViewTextBoxColumn1.Name = "cityDataGridViewTextBoxColumn1";
            cityDataGridViewTextBoxColumn1.Width = 200;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            locationDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            locationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            locationDataGridViewTextBoxColumn.FillWeight = 200F;
            locationDataGridViewTextBoxColumn.HeaderText = "Location";
            locationDataGridViewTextBoxColumn.MinimumWidth = 100;
            locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            distanceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            distanceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            distanceDataGridViewTextBoxColumn.HeaderText = "Distance (nm)";
            distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            distanceDataGridViewTextBoxColumn.Width = 150;
            // 
            // airportItemBindingSource
            // 
            airportItemBindingSource.DataSource = typeof(Modules.AirportItem);
            // 
            // grpStreamInfo
            // 
            grpStreamInfo.Controls.Add(LayoutStreamInfo);
            grpStreamInfo.Dock = DockStyle.Fill;
            grpStreamInfo.Location = new Point(844, 5);
            grpStreamInfo.Margin = new Padding(5);
            grpStreamInfo.MaximumSize = new Size(380, 0);
            grpStreamInfo.Name = "grpStreamInfo";
            grpStreamInfo.Size = new Size(350, 449);
            grpStreamInfo.TabIndex = 5;
            grpStreamInfo.TabStop = false;
            grpStreamInfo.Text = "Stream Information";
            // 
            // LayoutStreamInfo
            // 
            LayoutStreamInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LayoutStreamInfo.ColumnCount = 2;
            LayoutStreamInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            LayoutStreamInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            LayoutStreamInfo.Controls.Add(lblICAO, 0, 0);
            LayoutStreamInfo.Controls.Add(txtICAO, 1, 0);
            LayoutStreamInfo.Controls.Add(lblCity, 0, 1);
            LayoutStreamInfo.Controls.Add(lblAirport, 0, 2);
            LayoutStreamInfo.Controls.Add(lblCountry, 0, 3);
            LayoutStreamInfo.Controls.Add(lblFreqType, 0, 4);
            LayoutStreamInfo.Controls.Add(lblFreq, 0, 5);
            LayoutStreamInfo.Controls.Add(lablblFileType, 0, 6);
            LayoutStreamInfo.Controls.Add(lblFilePath, 0, 7);
            LayoutStreamInfo.Controls.Add(lblFileUrl, 0, 9);
            LayoutStreamInfo.Controls.Add(label1, 1, 8);
            LayoutStreamInfo.Controls.Add(txtCity, 1, 1);
            LayoutStreamInfo.Controls.Add(txtAirport, 1, 2);
            LayoutStreamInfo.Controls.Add(txtCountry, 1, 3);
            LayoutStreamInfo.Controls.Add(cmbFreqType, 1, 4);
            LayoutStreamInfo.Controls.Add(panFreq, 1, 5);
            LayoutStreamInfo.Controls.Add(cmbFileType, 1, 6);
            LayoutStreamInfo.Controls.Add(txtFileUrl, 1, 9);
            LayoutStreamInfo.Controls.Add(panFilePath, 1, 7);
            LayoutStreamInfo.Controls.Add(LayoutStreamInfoButtonGroup, 0, 10);
            LayoutStreamInfo.Dock = DockStyle.Fill;
            LayoutStreamInfo.Location = new Point(3, 22);
            LayoutStreamInfo.MinimumSize = new Size(0, 400);
            LayoutStreamInfo.Name = "LayoutStreamInfo";
            LayoutStreamInfo.RowCount = 11;
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            LayoutStreamInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutStreamInfo.Size = new Size(344, 424);
            LayoutStreamInfo.TabIndex = 0;
            // 
            // lblICAO
            // 
            lblICAO.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblICAO.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblICAO.Location = new Point(0, 5);
            lblICAO.Margin = new Padding(0, 5, 0, 0);
            lblICAO.Name = "lblICAO";
            lblICAO.Size = new Size(86, 20);
            lblICAO.TabIndex = 0;
            lblICAO.Text = "ICAO";
            lblICAO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtICAO
            // 
            txtICAO.AcceptsTab = true;
            txtICAO.BorderStyle = BorderStyle.FixedSingle;
            txtICAO.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtICAO.Location = new Point(91, 5);
            txtICAO.Margin = new Padding(5);
            txtICAO.Name = "txtICAO";
            txtICAO.Size = new Size(161, 27);
            txtICAO.TabIndex = 1;
            txtICAO.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCity
            // 
            lblCity.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCity.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblCity.Location = new Point(0, 44);
            lblCity.Margin = new Padding(0, 5, 0, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(86, 20);
            lblCity.TabIndex = 2;
            lblCity.Text = "CITY";
            lblCity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAirport
            // 
            lblAirport.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblAirport.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblAirport.Location = new Point(0, 83);
            lblAirport.Margin = new Padding(0, 5, 0, 0);
            lblAirport.Name = "lblAirport";
            lblAirport.Size = new Size(86, 20);
            lblAirport.TabIndex = 3;
            lblAirport.Text = "AIRPORT";
            lblAirport.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCountry
            // 
            lblCountry.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCountry.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblCountry.Location = new Point(0, 122);
            lblCountry.Margin = new Padding(0, 5, 0, 0);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(86, 20);
            lblCountry.TabIndex = 4;
            lblCountry.Text = "COUNTRY";
            lblCountry.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFreqType
            // 
            lblFreqType.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFreqType.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblFreqType.Location = new Point(0, 161);
            lblFreqType.Margin = new Padding(0, 5, 0, 0);
            lblFreqType.Name = "lblFreqType";
            lblFreqType.Size = new Size(86, 20);
            lblFreqType.TabIndex = 5;
            lblFreqType.Text = "FREQ TYPE";
            lblFreqType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFreq
            // 
            lblFreq.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFreq.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblFreq.Location = new Point(0, 200);
            lblFreq.Margin = new Padding(0, 5, 0, 0);
            lblFreq.Name = "lblFreq";
            lblFreq.Size = new Size(86, 20);
            lblFreq.TabIndex = 6;
            lblFreq.Text = "FREQ";
            lblFreq.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lablblFileType
            // 
            lablblFileType.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lablblFileType.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lablblFileType.Location = new Point(0, 239);
            lablblFileType.Margin = new Padding(0, 5, 0, 0);
            lablblFileType.Name = "lablblFileType";
            lablblFileType.Size = new Size(86, 20);
            lablblFileType.TabIndex = 7;
            lablblFileType.Text = "FILE TYPE";
            lablblFileType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFilePath
            // 
            lblFilePath.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFilePath.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblFilePath.Location = new Point(0, 278);
            lblFilePath.Margin = new Padding(0, 5, 0, 0);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(86, 20);
            lblFilePath.TabIndex = 8;
            lblFilePath.Text = " FILE PATH";
            lblFilePath.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFileUrl
            // 
            lblFileUrl.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFileUrl.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblFileUrl.Location = new Point(0, 332);
            lblFileUrl.Margin = new Padding(0, 5, 0, 0);
            lblFileUrl.Name = "lblFileUrl";
            lblFileUrl.Size = new Size(86, 20);
            lblFileUrl.TabIndex = 9;
            lblFileUrl.Text = " FILE URL";
            lblFileUrl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            label1.Location = new Point(89, 312);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 10;
            label1.Text = "(OR)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCity
            // 
            txtCity.AcceptsTab = true;
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtCity.Location = new Point(91, 44);
            txtCity.Margin = new Padding(5);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(248, 27);
            txtCity.TabIndex = 11;
            txtCity.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAirport
            // 
            txtAirport.AcceptsTab = true;
            txtAirport.BorderStyle = BorderStyle.FixedSingle;
            txtAirport.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAirport.Location = new Point(91, 83);
            txtAirport.Margin = new Padding(5);
            txtAirport.Name = "txtAirport";
            txtAirport.Size = new Size(248, 25);
            txtAirport.TabIndex = 12;
            txtAirport.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCountry
            // 
            txtCountry.AcceptsTab = true;
            txtCountry.BorderStyle = BorderStyle.FixedSingle;
            txtCountry.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtCountry.Location = new Point(91, 122);
            txtCountry.Margin = new Padding(5);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(248, 27);
            txtCountry.TabIndex = 13;
            txtCountry.TextAlign = HorizontalAlignment.Center;
            // 
            // cmbFreqType
            // 
            cmbFreqType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFreqType.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFreqType.FormattingEnabled = true;
            cmbFreqType.Items.AddRange(new object[] { "Approach", "ATIS", "Clearance Delivery", "Departure", "Ground", "Ramp", "Tower" });
            cmbFreqType.Location = new Point(91, 161);
            cmbFreqType.Margin = new Padding(5);
            cmbFreqType.Name = "cmbFreqType";
            cmbFreqType.Size = new Size(248, 28);
            cmbFreqType.TabIndex = 14;
            // 
            // panFreq
            // 
            panFreq.Controls.Add(lblFreqHint);
            panFreq.Controls.Add(txtFreq);
            panFreq.Dock = DockStyle.Fill;
            panFreq.Location = new Point(86, 200);
            panFreq.Margin = new Padding(0, 5, 0, 0);
            panFreq.Name = "panFreq";
            panFreq.Size = new Size(258, 34);
            panFreq.TabIndex = 15;
            // 
            // lblFreqHint
            // 
            lblFreqHint.AutoSize = true;
            lblFreqHint.Location = new Point(124, 9);
            lblFreqHint.Name = "lblFreqHint";
            lblFreqHint.Size = new Size(123, 19);
            lblFreqHint.TabIndex = 1;
            lblFreqHint.Text = "(e.g 118.000 MHz)";
            // 
            // txtFreq
            // 
            txtFreq.BorderStyle = BorderStyle.FixedSingle;
            txtFreq.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtFreq.Location = new Point(5, 1);
            txtFreq.Margin = new Padding(0);
            txtFreq.Mask = "000.000 MHz";
            txtFreq.Name = "txtFreq";
            txtFreq.RejectInputOnFirstFailure = true;
            txtFreq.Size = new Size(117, 27);
            txtFreq.TabIndex = 0;
            txtFreq.TextAlign = HorizontalAlignment.Center;
            // 
            // cmbFileType
            // 
            cmbFileType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFileType.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFileType.FormattingEnabled = true;
            cmbFileType.Items.AddRange(new object[] { "File", "Url" });
            cmbFileType.Location = new Point(91, 239);
            cmbFileType.Margin = new Padding(5);
            cmbFileType.Name = "cmbFileType";
            cmbFileType.Size = new Size(95, 28);
            cmbFileType.TabIndex = 16;
            cmbFileType.SelectedIndexChanged += cmbFileType_SelectedIndexChanged;
            // 
            // txtFileUrl
            // 
            txtFileUrl.AcceptsReturn = true;
            txtFileUrl.AcceptsTab = true;
            txtFileUrl.BorderStyle = BorderStyle.FixedSingle;
            txtFileUrl.CausesValidation = false;
            txtFileUrl.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtFileUrl.HideSelection = false;
            txtFileUrl.Location = new Point(91, 329);
            txtFileUrl.Margin = new Padding(5, 2, 2, 2);
            txtFileUrl.Name = "txtFileUrl";
            txtFileUrl.Size = new Size(248, 27);
            txtFileUrl.TabIndex = 17;
            txtFileUrl.WordWrap = false;
            // 
            // panFilePath
            // 
            panFilePath.Controls.Add(btnFilePathBrowser);
            panFilePath.Controls.Add(txtFilePath);
            panFilePath.Dock = DockStyle.Fill;
            panFilePath.Location = new Point(86, 278);
            panFilePath.Margin = new Padding(0, 5, 0, 0);
            panFilePath.Name = "panFilePath";
            panFilePath.Size = new Size(258, 34);
            panFilePath.TabIndex = 18;
            // 
            // btnFilePathBrowser
            // 
            btnFilePathBrowser.BackColor = SystemColors.ControlDarkDark;
            btnFilePathBrowser.FlatAppearance.BorderSize = 0;
            btnFilePathBrowser.FlatStyle = FlatStyle.Flat;
            btnFilePathBrowser.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnFilePathBrowser.ForeColor = SystemColors.ControlLightLight;
            btnFilePathBrowser.Location = new Point(225, 3);
            btnFilePathBrowser.Name = "btnFilePathBrowser";
            btnFilePathBrowser.Size = new Size(28, 23);
            btnFilePathBrowser.TabIndex = 20;
            btnFilePathBrowser.Text = "...a";
            btnFilePathBrowser.TextAlign = ContentAlignment.TopCenter;
            btnFilePathBrowser.UseVisualStyleBackColor = true;
            btnFilePathBrowser.Click += browserLocalFilePath;
            // 
            // txtFilePath
            // 
            txtFilePath.AcceptsTab = true;
            txtFilePath.BorderStyle = BorderStyle.FixedSingle;
            txtFilePath.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtFilePath.HideSelection = false;
            txtFilePath.Location = new Point(5, 0);
            txtFilePath.Margin = new Padding(2);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(220, 27);
            txtFilePath.TabIndex = 19;
            txtFilePath.WordWrap = false;
            // 
            // LayoutStreamInfoButtonGroup
            // 
            LayoutStreamInfoButtonGroup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LayoutStreamInfoButtonGroup.ColumnCount = 3;
            LayoutStreamInfo.SetColumnSpan(LayoutStreamInfoButtonGroup, 2);
            LayoutStreamInfoButtonGroup.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            LayoutStreamInfoButtonGroup.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            LayoutStreamInfoButtonGroup.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            LayoutStreamInfoButtonGroup.Controls.Add(btnInfoSave, 2, 0);
            LayoutStreamInfoButtonGroup.Dock = DockStyle.Fill;
            LayoutStreamInfoButtonGroup.Location = new Point(3, 369);
            LayoutStreamInfoButtonGroup.Name = "LayoutStreamInfoButtonGroup";
            LayoutStreamInfoButtonGroup.RowCount = 1;
            LayoutStreamInfoButtonGroup.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            LayoutStreamInfoButtonGroup.Size = new Size(338, 52);
            LayoutStreamInfoButtonGroup.TabIndex = 19;
            // 
            // btnInfoSave
            // 
            btnInfoSave.BackColor = Color.Gainsboro;
            btnInfoSave.BackgroundImageLayout = ImageLayout.None;
            btnInfoSave.Dock = DockStyle.Fill;
            btnInfoSave.FlatStyle = FlatStyle.Flat;
            btnInfoSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnInfoSave.Image = Resource1.save_1;
            btnInfoSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnInfoSave.ImeMode = ImeMode.NoControl;
            btnInfoSave.Location = new Point(234, 2);
            btnInfoSave.Margin = new Padding(10, 2, 10, 2);
            btnInfoSave.Name = "btnInfoSave";
            btnInfoSave.Size = new Size(94, 48);
            btnInfoSave.TabIndex = 2;
            btnInfoSave.Text = "       Save";
            btnInfoSave.TextAlign = ContentAlignment.MiddleRight;
            btnInfoSave.UseCompatibleTextRendering = true;
            btnInfoSave.UseVisualStyleBackColor = false;
            btnInfoSave.Click += btnInfoSave_Click;
            // 
            // LayoutBody
            // 
            LayoutBody.ColumnCount = 2;
            LayoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            LayoutBody.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
            LayoutBody.Controls.Add(grpStreamInfo, 1, 0);
            LayoutBody.Controls.Add(tabStream, 0, 0);
            LayoutBody.Dock = DockStyle.Fill;
            LayoutBody.Location = new Point(0, 24);
            LayoutBody.Name = "LayoutBody";
            LayoutBody.RowCount = 1;
            LayoutBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            LayoutBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            LayoutBody.Size = new Size(1199, 459);
            LayoutBody.TabIndex = 6;
            // 
            // MainFrm
            // 
            ClientSize = new Size(1199, 608);
            Controls.Add(LayoutBody);
            Controls.Add(LayoutAudioControl);
            Controls.Add(MainStatusBar);
            Controls.Add(MainMenu);
            Name = "MainFrm";
            StartPosition = FormStartPosition.Manual;
            Text = "FSRealATC-v2";
            FormClosing += MainFrm_FormClosing;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            MainStatusBar.ResumeLayout(false);
            MainStatusBar.PerformLayout();
            LayoutAudioControl.ResumeLayout(false);
            grpAudioPlayer.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)VolumeBar).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iptDelay).EndInit();
            grpCOMFrequence.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iptStandByFreq).EndInit();
            tabStream.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panStreamSearch.ResumeLayout(false);
            panStreamSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tblStream).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataItemBindingSource).EndInit();
            panStreamControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblAirports).EndInit();
            ((System.ComponentModel.ISupportInitialize)airportItemBindingSource).EndInit();
            grpStreamInfo.ResumeLayout(false);
            LayoutStreamInfo.ResumeLayout(false);
            LayoutStreamInfo.PerformLayout();
            panFreq.ResumeLayout(false);
            panFreq.PerformLayout();
            panFilePath.ResumeLayout(false);
            panFilePath.PerformLayout();
            LayoutStreamInfoButtonGroup.ResumeLayout(false);
            LayoutBody.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem mnuConnInFile;
        private ToolStripMenuItem mnuSetting;
        private ToolStripMenuItem mnuAutoConnInSetting;
        private ToolStripSplitButton btnMsgFromSim;
        private ToolStripStatusLabel lblConnStatus;
        private ToolStripStatusLabel lblSpace;
        private ToolStripStatusLabel lblCurrentStream;
        private ToolStripStatusLabel lblSimWarning;
        private TableLayoutPanel LayoutAudioControl;
        private TabControl tabStream;
        private TabPage tabPage2;
        private Label lblStandbyTitle;
        private TextBox iptActiveFreq;
        private NumericUpDown iptStandByFreq;
        private Button btnSwapInCOM;
        private TableLayoutPanel tableLayoutPanel8;
        private Button btnVolumeUp;
        private Button btnMute;
        private TrackBar VolumeBar;
        private ComboBox cmbOutputDevices;
        private Panel panel1;
        private Button btnPlay;
        private Button btnStop;
        private TableLayoutPanel tableLayoutPanel3;
        private NumericUpDown iptDelay;
        private GroupBox grpStreamInfo;
        private Label lblICAO;
        private TextBox txtICAO;
        private Label lblAirport;
        private Label lblCountry;
        private Label lblFreqType;
        private Label lblFreq;
        private Label lablblFileType;
        private Label lblFilePath;
        private Label lblFileUrl;
        private Label label1;
        private TextBox txtCity;
        private TextBox txtAirport;
        private TextBox txtCountry;
        private ComboBox cmbFreqType;
        private Label lblFreqHint;
        private MaskedTextBox txtFreq;
        private ComboBox cmbFileType;
        private TextBox txtFileUrl;
        private Button btnFilePathBrowser;
        private TextBox txtFilePath;
        private Button btnStreamAdd;
        private Button btnStreamDelete;
        private Button btnStreamPreview;
        private Button btnSort;
        private TextBox iptSearchBox;
        private Label label16;
        private DataGridView tblStream;
        private Button btnInfoSave;
        private DataGridViewTextBoxColumn iCAODataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn airportDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn freqTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn freqDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn filetypesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private BindingSource dataItemBindingSource;
        private ToolStripMenuItem settingAirportDatabaseToolStripMenuItem;
        private TabPage tabPage1;
        private DataGridView tblAirports;
        private DataGridViewTextBoxColumn iCAODataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
        private BindingSource airportItemBindingSource;
        private ToolStripMenuItem mnuDisconnInFile;
        private ToolStripMenuItem mnuAirportFindRadiusInSetting;
    }
}