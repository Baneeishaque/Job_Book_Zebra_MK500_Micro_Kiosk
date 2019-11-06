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
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
            CommonApi.set_TimeStamps(lblDate, lblTime);
            CommonApi.showDeviceParameters(lblTableID, lblDepartmentCode);
            txtTableId.Text = Home.tableId;
            txtDepartmentCode.Text = Home.departmentCode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDepartmentCodeClear_Click(object sender, EventArgs e)
        {
            txtDepartmentCode.Text = "";
        }

        private void btntableIdClear_Click(object sender, EventArgs e)
        {
            txtTableId.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTableId.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Table ID");
                txtTableId.Focus();

            }
            else if (txtDepartmentCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Department Code");
                txtDepartmentCode.Focus();

            }
            else
            {
                Home.tableId = txtTableId.Text;
                Home.departmentCode = txtDepartmentCode.Text;
                MessageBox.Show("Table ID & Department Code saved successfully");
                this.Close();
            }

        }
    }
}