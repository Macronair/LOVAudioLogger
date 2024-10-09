using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarcosIcecastRecorder
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrCloseSplash.Start();
        }

        private void tmrCloseSplash_Tick(object sender, EventArgs e)
        {
            this.Close();
            tmrCloseSplash.Stop();
        }
    }
}
