using NAudio.CoreAudioApi;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MarcosIcecastRecorder
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, System.EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Loading configuration in settings window...");
            txtTitle.Text = Config.Title;
            txtSourceURL.Text = Config.StreamURL;

            if(Config.PhysicalDevice == "*") { cmbSourcePhysical.Text = ""; }
            else { cmbSourcePhysical.Text = Config.PhysicalDevice; }

            if(Config.UsePhysicalDevice)
            {
                radSourcePhysical.Checked = true;
            }
            else
            {
                radSourceURL.Checked = true;
            }

            chkSyncWithFullHour.Checked = Config.SyncToFullHour;
            txtLoggerLocation.Text = Config.LoggerLocation;
            txtLoggerFileName.Text = Config.FileName;
            nmrRecordingDuration.Value = Config.RecDurationInSec;
            chkUseTempFolder.Checked = Config.UseTempFolder;
            switch(Config.RecordingMode)
            {
                case 0: radFSNone.Checked = true; break;
                case 1: radFSbyDay.Checked = true; break;
                case 2: radFSbyProgram.Checked = true; break;
                case 3: radFSbyProgramDay.Checked = true; break;
                case 4: radFSbyDayProgram.Checked = true; break;
            }

            //Console.WriteLine("Ävailable audio devices:");
            var enumerator = new MMDeviceEnumerator();
            foreach (var endpoint in
                     enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                //Console.WriteLine(endpoint.FriendlyName);
                cmbSourcePhysical.Items.Add(endpoint);
            }
        }

        private void RecordingMode_CheckedChanged(object sender, System.EventArgs e)
        {
            if(radFSbyProgram.Checked || radFSbyProgramDay.Checked || radFSbyDayProgram.Checked)
            {
                btnProgramScheduler.Enabled = true;
            }
            else
            {
                btnProgramScheduler.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            bool usePhysicalDevice = false;
            int recordingMode = 0;

            if (radSourcePhysical.Checked)
            {
                usePhysicalDevice = true;
            }
            else if (radSourceURL.Checked)
            {
                usePhysicalDevice = false;
            }

            if (radFSNone.Checked) { recordingMode = 0; }
            else if (radFSbyDay.Checked) { recordingMode = 1; }
            else if (radFSbyProgram.Checked) { recordingMode = 2; }
            else if (radFSbyProgramDay.Checked) { recordingMode = 3; }
            else if (radFSbyDayProgram.Checked) { recordingMode = 4; }

            var settings = new AppSettings
            {
                Title = txtTitle.Text,

                StreamURL = txtSourceURL.Text,
                PhysicalDevice = cmbSourcePhysical.Text,

                UsePhysicalDevice = usePhysicalDevice,

                LoggerLocation = txtLoggerLocation.Text,
                FileName = txtLoggerFileName.Text,
                SyncToFullHour = chkSyncWithFullHour.Enabled,
                UseTempFolder = chkUseTempFolder.Checked,
                DaysToKeep = Convert.ToInt32(nmrDaysToKeep.Value),

                RecDurationInSec = Convert.ToInt32(nmrRecordingDuration.Value),

                RecordingMode = recordingMode
            };

            Config.SerializeToXml(settings, Config.filePath);
            Config.GetConfig();

            MessageBox.Show("New configuration will take effect on next recording or restart of this logger.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Close();
        }

        private void btnSaveRestart_Click(object sender, System.EventArgs e)
        {
            Recorder.RecordAgain = true;

            bool usePhysicalDevice = false;
            int recordingMode = 0;

            if (radSourcePhysical.Checked)
            {
                usePhysicalDevice = true;
            }
            else if (radSourceURL.Checked)
            {
                usePhysicalDevice = false;
            }

            if (radFSNone.Checked) { recordingMode = 0; }
            else if (radFSbyDay.Checked) { recordingMode = 1; }
            else if (radFSbyProgram.Checked) { recordingMode = 2; }
            else if (radFSbyProgramDay.Checked) { recordingMode = 3; }
            else if (radFSbyDayProgram.Checked) { recordingMode = 4; }

            var settings = new AppSettings
            {
                Title = txtTitle.Text,

                StreamURL = txtSourceURL.Text,
                PhysicalDevice = cmbSourcePhysical.Text,

                UsePhysicalDevice = usePhysicalDevice,

                LoggerLocation = txtLoggerLocation.Text,
                FileName = txtLoggerFileName.Text,
                SyncToFullHour = chkSyncWithFullHour.Enabled,
                UseTempFolder = chkUseTempFolder.Checked,
                DaysToKeep = Convert.ToInt32(nmrDaysToKeep.Value),

                RecDurationInSec = Convert.ToInt32(nmrRecordingDuration.Value),

                RecordingMode = recordingMode
            };

            Config.SerializeToXml(settings, Config.filePath);
            Config.GetConfig();

            MessageBox.Show("Logger process will now restart.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            try
            {
                Recorder.procRec.Kill();
                Program.recorder.Abort();
                
                Program.recorder = new Thread(new ThreadStart(Recorder.SetRecordingMode));
                Program.recorder.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error restarting recorder: " + ex.Message);
                Console.ReadKey();
                Application.Exit();
            }
            Console.Clear();
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Configuration changed. Started new recording.");

            this.Close();
        }

        private void radSourcePhysical_CheckedChanged(object sender, EventArgs e)
        {
            if(radSourcePhysical.Checked)
            {
                txtSourceURL.Enabled = false;
                cmbSourcePhysical.Enabled = true;
            }
        }

        private void radSourceURL_CheckedChanged(object sender, EventArgs e)
        {
            if (radSourceURL.Checked)
            {
                txtSourceURL.Enabled = true;
                cmbSourcePhysical.Enabled = false;
            }
        }

        private void btnChooseLoggerLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = fldLoggerLocation.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fldLoggerLocation.SelectedPath))
            {
                txtLoggerLocation.Text = fldLoggerLocation.SelectedPath;
            }
        }

        private void btnProgramScheduler_Click(object sender, EventArgs e)
        {
            frmScheduler frmScheduler = new frmScheduler();
            frmScheduler.ShowDialog();
        }

        private void btnShowSavedRecordings_Click(object sender, EventArgs e)
        {
            frmRecordings frmRecordings = new frmRecordings();
            frmRecordings.ShowDialog();
        }
    }
}
