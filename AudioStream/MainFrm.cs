using AudioStream.Modules;
using FSUIPC;
using System.Configuration;
using System.Diagnostics;

namespace AudioStream
{
    public partial class MainFrm : Form
    {
        private Configuration config;

        private DataDrv dataSource;
        int saveMode;
        List<AirportItem> lstAirport = new List<AirportItem>();

        private CusomAudioStream? preview;
        private CusomAudioStream? audio;
        bool previewIsplaying;
        bool audioIspaused;

        private SimDrv? sim = null;
        private FSUIPC_Driver? fs = null;
        private int warnings = 0;

        public MainFrm()
        {
            InitializeComponent();

            ///------- init config---------
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            string? strCONN_Mode = config.AppSettings.Settings["connection_mode"].Value;

            if (strCONN_Mode == null) strCONN_Mode = "0";

            if (strCONN_Mode == "0")//manual connection
            {
                mnuConnInFile.Enabled = true;
                mnuAutoConnInSetting.Checked = false;
            }
            else if (strCONN_Mode == "1") //auto mode
            {
                mnuConnInFile.Enabled = false;
                mnuAutoConnInSetting.Checked = true;
            }
            else
            {
                mnuConnInFile.Enabled = true;
                mnuAutoConnInSetting.Checked = false;
            }

            VolumeBar.Value = 50;

            ///-----Stream Table config-----
            List<String> cols = new List<string>();
            foreach (DataGridViewColumn column in tblStream.Columns)
            {
                cols.Add(column.HeaderText);
            }
            tblStream.AutoGenerateColumns = false;
            dataSource = new DataDrv(cols);

            dataSource.SelectionChanged += changedCurrentItem;

            tblStream.DataSource = dataSource.DataSource;

            tblAirports.AutoGenerateColumns = false;
            ///-----Audio config-----
            audio = new CusomAudioStream();
            preview = new CusomAudioStream();
            foreach (string output in CusomAudioStream.GetOutputDevices())
            {
                cmbOutputDevices.Items.Add(output);
            }


            btnPlay.Enabled = false;
            audio.PlayDone += Audio_PlayDone;
            preview.PlayDone += Preview_PlayDone;
            preview.PlayingNow += Preview_PlayingNow;

            previewIsplaying = false;
            audioIspaused = false;

            ///-----Simulator config
            string? strRad = config.AppSettings.Settings["rad"].Value;

            fs = new FSUIPC_Driver(double.Parse(strRad));

            fs.CONNECT_STATE_CHANGED += Simulator_CONNECT_STATE_CHANGED;
            fs.SIM_ERRO += Simulator_SIM_ERRO;
            fs.COM1_ACTFREQ_CHANGED += Simulator_COM1_ACTFREQ_CHANGED;
            fs.COM1_STNBYFREQ_CHANGED += Simulator_COM1_STNBYFREQ_CHANGED;
            fs.AIRPORT_CHANGED += AIRPORT_LIST_CHANGED;
            fs.AIRPORTDATABASE_LOADEDDONE += Fs_AIRPORTDATABASE_LOADEDDONE;
            fs.AutoConnectAble = mnuAutoConnInSetting.Checked;
            Warnings = 0;

            SetConfigure();

            if (mnuAutoConnInSetting.Checked)
            {
                fs.Connect(mnuAutoConnInSetting.Checked);
            }
        }

        private void Fs_AIRPORTDATABASE_LOADEDDONE(object? sender, bool e)
        {
            if (e)
            {
                config.AppSettings.Settings["airportdatabase"].Value = fs?.AirportDBPath;
            }
        }

        /// <summary>
        /// UI relation
        /// </summary>
        private void SetConfigure()
        {
            string? strX = config.AppSettings.Settings["x"].Value;
            string? strY = config.AppSettings.Settings["y"].Value;
            string? strW = config.AppSettings.Settings["w"].Value;
            string? strH = config.AppSettings.Settings["h"].Value;
            string? strVolumn = config.AppSettings.Settings["volumn"].Value;
            string? strDelay = config.AppSettings.Settings["delay"].Value;
            string? strdDeviceindex = config.AppSettings.Settings["deviceindex"].Value;

            Point pt = new Point(0, 0);
            Size sz = new Size(800, 600);
            if (int.TryParse(strX, out int _x))
            {
                pt.X = _x;
            }

            if (int.TryParse(strY, out int _y))
            {
                pt.Y = _y;
            }

            if (int.TryParse(strW, out int _w))
            {
                sz.Width = _w;
            }

            if (int.TryParse(strH, out int _h))
            {
                sz.Height = _h;
            }

            this.Location = pt;
            this.Size = sz;

            if (int.TryParse(strVolumn, out int _volumn))
            {
                VolumeBar.Value = _volumn;
            }

            if (int.TryParse(strDelay, out int _delay))
            {
                iptDelay.Value = _delay;
            }

            if (int.TryParse(strdDeviceindex, out int _deviceIndex))
            {
                cmbOutputDevices.SelectedIndex = _deviceIndex + 1;
            }

            if (fs != null) fs.AirportDBPath = config.AppSettings.Settings["airportdatabase"].Value;
        }

        private void SaveLocation()
        {
            Point pt = this.Location;
            config.AppSettings.Settings["x"].Value = this.Location.X.ToString();
            config.AppSettings.Settings["y"].Value = this.Location.Y.ToString();
            config.AppSettings.Settings["w"].Value = this.Size.Width.ToString();
            config.AppSettings.Settings["h"].Value = this.Size.Height.ToString();
            config.AppSettings.Settings["rad"].Value = string.Format("{0}", fs?.Radius);

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataSource.Save();
            SaveLocation();

            sim?.Disconnect();
            fs?.Disconnect();
            //ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save();
            //ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        private void mnuConnInFile_Click(object sender, EventArgs e)
        {
            if (sim != null) { sim?.Connect(Handle); return; }
            if (fs != null) fs?.Connect();
        }

        private void mnuAutoConnInSetting_CheckedChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["connection_mode"].Value = mnuAutoConnInSetting.Checked ? "1" : "0";
            config.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("appSettings");
            mnuConnInFile.Enabled = !mnuAutoConnInSetting.Checked;
            mnuDisconnInFile.Enabled = false;
            if (fs != null)
            {
                fs.AutoConnectAble = mnuAutoConnInSetting.Checked;
                if (lblConnStatus.Text == "connected")
                {
                    mnuConnInFile.Enabled = false;
                    if (!mnuAutoConnInSetting.Checked) mnuDisconnInFile.Enabled = true;
                }
            }
        }

        private void mnuExitInFile_Click(object sender, EventArgs e)
        {
            string message = "Would you close and exit this Application?";
            string caption = "Closing Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cmbOutputDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            audio?.SetDevice(cmbOutputDevices.SelectedIndex - 1);
        }

        private void VolumeBar_ValueChanged(object sender, EventArgs e)
        {
            if (audio == null) return;
            audio.SetVolumn(VolumeBar.Value / 100f);
        }

        private void btnVolumeUp_Click(object sender, EventArgs e)
        {
            if (VolumeBar.Value < 100)
            {
                VolumeBar.Value += 1;
            }
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (VolumeBar.Value > 0)
            {
                VolumeBar.Value = 0;
            }
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            VolumeBar_ValueChanged(sender, e);
        }

        private void browserLocalFilePath(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                openFileDialog.Filter = "audio files (*.mp3)|*.MP3";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == SimDrv.WM_USER_SIMCONNECT)
            {
                if (sim != null && sim.connector != null)
                {
                    sim.connector.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void btnInfoSave_Click(object sender, EventArgs e)
        {
            Object[] obj = new object[8];
            obj[0] = txtICAO.Text;
            obj[1] = txtAirport.Text;
            obj[2] = txtCity.Text;
            obj[3] = txtCountry.Text;
            obj[4] = cmbFreqType.SelectedItem.ToString();
            obj[5] = txtFreq.Text.Remove(txtFreq.Text.Length - 4);
            obj[6] = cmbFileType.SelectedItem.ToString();
            obj[7] = obj[6].ToString() == "File" ? txtFilePath.Text : txtFileUrl.Text;

            Int32 selectedRowCount = tblStream.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (SaveMode == 0)//Upgrade
            {
                dataSource.UpgradeStream(obj);
            }
            else if (SaveMode == 1) //Add
            {
                dataSource.AddStream(obj);
            }

            btnInfoSave.Text = "Append";
        }

        private void InfoClear()
        {
            txtICAO.Text = "";
            txtCity.Text = "";
            txtAirport.Text = "";
            txtCountry.Text = "";
            cmbFreqType.SelectedIndex = 0;
            txtFreq.Text = "000.000 MHz";
            cmbFileType.SelectedIndex = cmbFileType.Items.IndexOf("File");
            txtFilePath.Text = "";
            txtFileUrl.Text = "";
        }

        private void iptSearchBox_TextChanged(object sender, EventArgs e)
        {
            string filter = string.Format("ICAO like '%{0}%'", iptSearchBox.Text);
            dataSource.Filter(filter);
        }

        private void cmbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFileType.SelectedItem.ToString() == "File")
            {
                txtFileUrl.Enabled = false;
                txtFilePath.Enabled = true;
            }
            else if (cmbFileType.SelectedItem.ToString() == "Url")
            {
                txtFileUrl.Enabled = true;
                txtFilePath.Enabled = false;
            }
        }

        private void btnStreamDelete_Click(object sender, EventArgs e)
        {
            string message = "Would you remove the selected stream?";
            string caption = "Removing stream";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                dataSource.RemoveStream();
            }
        }

        private void btnStreamAdd_Click(object sender, EventArgs e)
        {
            SaveMode = 1;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AudioIsPaused = true;
            audio?.Pause();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            AudioIsPaused = false;
            if (!PreviewIsPlaying) audio?.Resume();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            dataSource.Sort();
        }

        /// <summary>
        /// StreamTable relation
        /// 

        public int SaveMode
        {
            get { return saveMode; }
            set
            {
                saveMode = value;
                if (saveMode == 0)
                {

                    btnInfoSave.Text = "Save";
                }
                else
                {
                    btnInfoSave.Text = "Append";

                    InfoClear();
                }
            }
        }

        /// <summary>
        /// DataSource relation
        /// 
        private void changedCurrentItem(object? sender, SelectionChangedEventArg e)
        {
            SaveMode = 0;

            if (e.stream == null) return;

            var obj = e.stream as DataItem;

            txtICAO.Text = obj?.ICAO;
            txtAirport.Text = obj?.Airport;
            txtCity.Text = obj?.City;
            txtCountry.Text = obj?.Country;
            if (!cmbFreqType.Items.Contains(obj?.FreqType))
            {
                cmbFreqType.Items.Add(obj?.FreqType);
            }
            cmbFreqType.SelectedIndex = cmbFreqType.Items.IndexOf(obj?.FreqType);
            txtFreq.Text = obj?.Freq.ToString("F3");
            cmbFileType.SelectedIndex = obj?.Filetypes == FileType.File ? 0 : 1;
            if (cmbFileType.SelectedIndex == 0)
            {
                txtFilePath.Text = obj?.FilePath;
                txtFileUrl.Text = "";
            }
            else
            {
                txtFilePath.Text = "";
                txtFileUrl.Text = obj?.FilePath;
            }
        }

        /// <summary>
        /// Simulator relation
        /// 
        public int Warnings
        {
            get { return warnings; }
            set
            {
                warnings = value;
                if (warnings < 1)
                    lblSimWarning.Visible = false;
                else
                {
                    if (warnings > 100)
                    {
                        warnings = 100;
                        lblSimWarning.Text = "100+";
                    }
                    else
                    {
                        lblSimWarning.Text = warnings.ToString();
                    }
                    lblSimWarning.Visible = true;

                }
            }
        }

        private delegate void SafeCallDelegate(object? sender, bool e);
        private void Simulator_CONNECT_STATE_CHANGED(object? sender, bool e)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegate(Simulator_CONNECT_STATE_CHANGED);
                Invoke(d, args: new object[] { sender, e });
                return;
            }

            lblConnStatus.Text = e ? "connected" : "disconnected";
            lblConnStatus.ForeColor = e ? Color.Green : Color.Red;
            lblCurrentStream.Text = "";
            if (e)
            {
                Warnings = 0;
                if (mnuAutoConnInSetting.Checked)
                {
                    fs?.SetAirportDB();
                }
                mnuConnInFile.Enabled = false;
                if (!mnuAutoConnInSetting.Checked) mnuDisconnInFile.Enabled = true;
            }
            else
            {
                if (!mnuAutoConnInSetting.Checked) mnuConnInFile.Enabled = true;
                mnuDisconnInFile.Enabled = false;
                audio?.StopBySim();
                iptActiveFreq.Text = "";
            }
        }

        private delegate void SafeCallDelegateForFreq(object? sender, uint e);
        private void Simulator_COM1_STNBYFREQ_CHANGED(object? sender, uint e)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegateForFreq(Simulator_COM1_STNBYFREQ_CHANGED);
                Invoke(d, args: new object[] { sender, e });
                return;
            }

            var v = Decimal.Parse(SimDrv.HzToMhz(e));
            if (v > iptStandByFreq.Minimum && v < iptStandByFreq.Maximum)
            {
                iptStandByFreq.Value = v;
            }
        }

        private void Simulator_COM1_ACTFREQ_CHANGED(object? sender, uint e)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegateForFreq(Simulator_COM1_ACTFREQ_CHANGED);
                Invoke(d, args: new object[] { sender, e });
                return;
            }

            iptActiveFreq.Text = SimDrv.HzToMhz(e);

            PlayCOM1Active();
        }

        private delegate void SafeCallDelegateForAirPort(object? sender, List<AirportItem> apis);
        private void AIRPORT_LIST_CHANGED(object? sender, List<AirportItem> apis)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegateForAirPort(AIRPORT_LIST_CHANGED);
                Invoke(d, args: new object[] { sender, apis });
                return;
            }
            if (sender != fs) return;
            tblAirports.DataSource = null;

            if (apis.Count > 0)
            {
                apis.Sort(FSUIPC_Driver.CompareDouble);
                tblAirports.DataSource = apis;

                PlayCOM1Active();
            }
        }

        private void Simulator_msgText(object? sender, string e)
        {
            if (btnMsgFromSim.DropDownItems.Count >= 10)
            {
                btnMsgFromSim.DropDownItems.RemoveAt(0);
            }
            btnMsgFromSim.DropDownItems.Add(e);
        }

        private void PlayCOM1Active()
        {
            lblCurrentStream.Text = iptActiveFreq.Text + "MHz";
            List<DataItemWrapper>? candidates = dataSource.FindStream("Freq", iptActiveFreq.Text);
            DataItemWrapper? validStreamItemWrapper = null;

            if (candidates != null && candidates.Count > 0)
            {
                validStreamItemWrapper = filterByFreq(candidates);

                if (validStreamItemWrapper != null && audio != null)
                {
                    if (audio.beforePos != validStreamItemWrapper.Pos)
                    {
                        audio.beforePos = validStreamItemWrapper.Pos;
                        DataItem si = validStreamItemWrapper.Content;
                        lblCurrentStream.Text = si.ICAO + " " + si.FreqType + " (" + iptActiveFreq.Text + "MHz)";

                        audio.Play(si.Filetypes == FileType.File, si.FilePath, (int)iptDelay.Value, VolumeBar.Value / 100f, PreviewIsPlaying | AudioIsPaused);
                    }
                }
                else
                {
                    audio.beforePos = -1;
                    audio?.Stop();
                }
            }
            else
            {
                audio.beforePos = -1;
                audio?.Stop();
            }
        }

        private delegate void SafeCallDelegateForError(object? sender, string e);

        private void Simulator_SIM_ERRO(object? sender, string e)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegateForError(Simulator_SIM_ERRO);
                Invoke(d, args: new object[] { sender, e });
                return;

            }
            Warnings = Warnings + 1;
        }

        private DataItemWrapper? filterByFreq(List<DataItemWrapper> siws)
        {
            DataItemWrapper result = null;
            foreach (DataItemWrapper diw in siws)
            {
                List<AirportItem> records = (List<AirportItem>)tblAirports.DataSource;
                if (records != null && records.Count > 0)
                {
                    bool founded = false;
                    foreach (AirportItem rec in records)
                    {
                        if (rec.ICAO == diw.Content.ICAO)
                        {
                            founded = true; break;
                        }
                    }

                    if (founded)
                    {
                        result = diw; break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Audio relation
        private void btnStreamPreview_Click(object sender, EventArgs e)
        {
            if (PreviewIsPlaying)
            {
                preview?.Stop(true);
            }
            else
            {
                var stream = dataSource.GetCurrentStream();
                if (stream != null)
                {
                    audio?.Pause();
                    preview?.Play(stream.Filetypes == FileType.File, stream.FilePath, 0, VolumeBar.Value / 100f);
                }
                else
                {
                    preview?.Stop();
                }
            }
        }

        public bool PreviewIsPlaying
        {
            get { return previewIsplaying; }
            set
            {
                setPreviewStatus(value);
            }
        }

        public bool AudioIsPaused
        {
            get { return audioIspaused; }
            set
            {
                audioIspaused = value;
                if (!audioIspaused)
                {
                    btnStop.Enabled = true; btnPlay.Enabled = false;
                }
                else
                {
                    btnStop.Enabled = false; btnPlay.Enabled = true;
                }
            }
        }

        private void setPreviewStatus(bool val)
        {
            previewIsplaying = val;
            if (previewIsplaying)
            {
                btnStreamPreview.Image = Resource1.sound_off;
                btnStreamPreview.Text = "  Stop  Preview";
            }
            else
            {
                btnStreamPreview.Image = Resource1.sound_on;
                btnStreamPreview.Text = "     Preview Stream";
                if (!AudioIsPaused) audio?.Resume();
            }
        }

        private void Audio_PlayDone(object? sender, PlayEvent e)
        {

        }

        private void Preview_PlayDone(object? sender, PlayEvent e)
        {
            PreviewIsPlaying = false;
        }

        private void Preview_PlayingNow(object? sender, EventArgs e)
        {
            PreviewIsPlaying = true;
        }

        private void btnSwapFreq(object sender, EventArgs e)
        {
            if (iptActiveFreq.Text == "" && iptStandByFreq.Value < 100) return;
            if (sim != null)
            {
                sim?.SetCOM1Info(0, (uint)(iptStandByFreq.Value * 1000000));
                sim?.SetCOM1Swap();
            }
            else if (fs != null)
            {
                fs?.COM1_swap();
            }
        }

        private void btnOutputDeviceSave_Click(object sender, EventArgs e)
        {
            config.AppSettings.Settings["volumn"].Value = VolumeBar.Value.ToString();
            config.AppSettings.Settings["delay"].Value = iptDelay.Value.ToString();
            config.AppSettings.Settings["deviceindex"].Value = (cmbOutputDevices.SelectedIndex - 1).ToString();
        }

        private void settingAirportDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AirportDatabaseSetting()).ShowDialog();
        }

        private void mnuDisconnInFile_Click(object sender, EventArgs e)
        {
            fs?.Disconnect();
        }

        private void mnuAirportFindRadiusInSetting_Click(object sender, EventArgs e)
        {
            double value = (double)(fs.Radius);
            if (InputDialogBox("Inputing", "Please input the double number in below box", ref value) == DialogResult.OK)
            {
                fs.Radius = value;
            }
        }

        public static DialogResult InputDialogBox(string title, string promptText, ref double value)
        {
            Form form = new Form();
            Label label = new Label();
            NumericUpDown textBox = new NumericUpDown();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            textBox.Maximum = 40;
            textBox.DecimalPlaces = 1;
            textBox.Value = (decimal)value;
            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(36, 36, 100, 13);
            textBox.SetBounds(56, 86, 60, 20);
            buttonOk.SetBounds(140, 86, 80, 30);
            buttonCancel.SetBounds(230, 86, 80, 30);

            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            form.ClientSize = new Size(340, 140);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = (double)textBox.Value;
            return dialogResult;

        }

        private void iptStandByFreq_ValueChanged(object sender, EventArgs e)
        {
            fs?.SetCOM1Info(0, (uint)(iptStandByFreq.Value * 1000000));
        }
    }
}