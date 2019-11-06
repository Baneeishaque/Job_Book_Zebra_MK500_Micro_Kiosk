using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    class CommonApi
    {
        public static void set_TimeStamps(Label lblDate, Label lblTime)
        {
            DateTime datetime = DateTime.Now;
            lblDate.Text = datetime.ToShortDateString();
            lblTime.Text = datetime.ToString("HH:mm:ss");
        }

        public static void showDeviceParameters(Label lblTableID, Label lblDepartmentCode)
        {
            lblTableID.Text = Home.tableId;
            lblDepartmentCode.Text = Home.departmentCode;
        }
    }
}
