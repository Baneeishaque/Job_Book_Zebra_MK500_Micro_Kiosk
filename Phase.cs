using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    public partial class Phase : Form
    {
        string phase;

        public Phase(string phase)
        {
            InitializeComponent();
            this.phase = phase;
            CommonApi.set_TimeStamps(lblDate, lblTime);
            CommonApi.showDeviceParameters(lblTableID, lblDepartmentCode);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actions actions = new Actions();
            actions.ShowDialog();
        }
    }
}