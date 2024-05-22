using AudioStream.Modules;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AudioStream
{
    public partial class AirportDatabaseSetting : Form
    {
        public AirportDatabaseSetting()
        {
            InitializeComponent();

            FSUIPC_Driver.FS_GLOBAL.AIRPORTDATABASE_LOADEDDONE += FS_GLOBAL_AIRPORTDATABASE_LOADEDDONE;

            txtDbPath.Enabled = true;
            btnLoad.Enabled = true;

            txtDbPath.Text = FSUIPC_Driver.FS_GLOBAL.AirportDBPath;
            waitIndicator.Hide();
            // 
        }

        private delegate void SafeCallDelegate(object? sender, bool e);
        private void FS_GLOBAL_AIRPORTDATABASE_LOADEDDONE(object? sender, bool e)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegate(FS_GLOBAL_AIRPORTDATABASE_LOADEDDONE);
                Invoke(d, args: new object[] { sender, e });
                return;
            }

            if (e)
            {
                this.Text = "Setting AirportDatabase is successfull";

                Task.Run(async () =>
                {
                    await Task.Delay(500);
                    this.Close();
                });

            }
            else
            {
                this.Text = "Setting AirportDatabase is failed";
            }

            waitIndicator.Hide();
            btnLoad.Enabled = true;
        }

        private void txtDbPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (FSUIPC_Driver.FS_GLOBAL != null)
            {
                this.Text = "Setting AirportDatabase is loading...";
                waitIndicator.Show();

                txtDbPath.Enabled = false;
                btnLoad.Enabled = false;

                FSUIPC_Driver.FS_GLOBAL.AirportDBPath = txtDbPath.Text;
            }
        }

        private void AirportDatabaseSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (picWaiting.Visible) e.Cancel = true;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                folderBrowserDialog1.Description = "Select the airport database directory";
                folderBrowserDialog1.ShowNewFolderButton = false;
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtDbPath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
    }
}
