using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarcosIcecastRecorder
{
    public partial class frmRecordings : Form
    {
        public frmRecordings()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            listRecordings.Dock = DockStyle.Fill;
            listRecordings.View = View.Details;

            listRecordings.Columns.Add("Creation date", 150);
            listRecordings.Columns.Add("FileName", 270);
            listRecordings.Columns.Add("ProgramName", 270);
            listRecordings.Columns.Add("Removal date", 150);

            string jsonString = File.ReadAllText("records.json");
            List<Recording> recordings = JsonSerializer.Deserialize<List<Recording>>(jsonString);

            // Stap 2: Voeg de records toe aan de ListView
            foreach (var recording in recordings)
            {
                var item = new ListViewItem(recording.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(recording.FileName);
                item.SubItems.Add(recording.ProgramName);
                item.SubItems.Add(recording.RemovalDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (DateTime.Now.ToString("yyyy-MM-dd-HH") == recording.RemovalDate.ToString("yyyy-MM-dd-HH"))
                {
                    item.ForeColor = Color.Blue;
                }

                // Voeg het item toe aan de ListView
                listRecordings.Items.Add(item);
            }

            //var currentrecording = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //currentrecording.SubItems.Add(FileManager.l_folder + "\\" + FileManager.l_filename + ".mp3");
            //currentrecording.SubItems.Add(Values.GetCurrentProgram());
            //currentrecording.SubItems.Add("Available when recording completes.");



            //listRecordings.Items.Add(currentrecording);
        }

        private void frmRecordings_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnMenuRefresh_Click(object sender, EventArgs e)
        {
            listRecordings.Clear();
            RefreshData();
        }
    }
}
