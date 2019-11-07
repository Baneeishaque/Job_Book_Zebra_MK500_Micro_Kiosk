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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnAssembly_Click(object sender, EventArgs e)
        {
            Phase phase = new Phase("Assembly");
            phase.ShowDialog();
        }

        private void btnNonConformity_Click(object sender, EventArgs e)
        {
            Phase phase = new Phase("Non Conformity");
            phase.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }
    }
}