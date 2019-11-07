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
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxOperatorBadgeID.Text.Trim() == "")
            {
                MessageBox.Show("Enter Operator Badge ID");
                textBoxOperatorBadgeID.Focus();
            }
            else if (textBoxJobNumber.Text.Trim() == "")
            {
                MessageBox.Show("Enter Job Number");
                textBoxJobNumber.Focus();
            }
            else if (textBoxCoreNumber.Text.Trim() == "")
            {
                MessageBox.Show("Enter Core Number");
                textBoxCoreNumber.Focus();
            }
            else if (textBoxTableID.Text.Trim() == "")
            {
                MessageBox.Show("Enter Table ID");
                textBoxTableID.Focus();
            }
            else if (!textBoxJobNumber.Text.Contains('/'))
            {
                MessageBox.Show("Enter Job Number in Job/Item format");
                textBoxJobNumber.Focus();
            }
            else if (!textBoxCoreNumber.Text.Contains('/'))
            {
                MessageBox.Show("Enter Core Number in Core/Core_Total format");
                textBoxCoreNumber.Focus();
            }
            else
            {
                string[] job = textBoxJobNumber.Text.Trim().Split('/');
                if (job[0] == "" || job[1] == "")
                {
                    MessageBox.Show("Enter Job Number in Job/Item format");
                    textBoxJobNumber.Focus();
                }
                else
                {
                    string[] core = textBoxCoreNumber.Text.Trim().Split('/');
                    if (core[0] == "" || core[1] == "")
                    {
                        MessageBox.Show("Enter Core Number in Core/Core_Total format");
                        textBoxCoreNumber.Focus();
                    }
                    else
                    {
                        Actions actions = new Actions(textBoxOperatorBadgeID.Text.Trim(),job[0],job[1],core[0],core[1],textBoxTableID.Text.Trim());
                        actions.ShowDialog();
                    }
                }
            }
        }

        private void textBoxJobNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }

            // only allow one /
            if ((e.KeyChar == '/') && ((sender as TextBox).Text.IndexOf('/') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxCoreNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }

            // only allow one /
            if ((e.KeyChar == '/') && ((sender as TextBox).Text.IndexOf('/') > -1))
            {
                e.Handled = true;
            }
        }
    }
}