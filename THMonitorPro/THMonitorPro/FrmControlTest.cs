using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THMonitorPro
{
    public partial class FrmControlTest : Form
    {
        public FrmControlTest()
        {
            InitializeComponent();
            this.thMonitor1.TemperatureWaring = 30;
        }

        int value = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            value++;
            this.thMonitor1.TemperatureValue = value;
            this.thMonitor1.HumidityValue = value;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            value--;
            this.thMonitor1.TemperatureValue = value;
            this.thMonitor1.HumidityValue = value;
        }
    }
}
