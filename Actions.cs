using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    public partial class Actions : Form
    {
        int timerSeconds = 0, timerMinutes = 0, timerHours = 0;

        public Actions(string passedOperatorBadgeID, string passedJobNumber, string passedItemNumber, string passedCoreNumber, string passedCoreTotal, string passedTableID)
        {
            InitializeComponent();

            textBoxOperatorBadgeID.Text = passedOperatorBadgeID;
            textBoxJobNumber.Text = passedJobNumber + "/" + passedItemNumber;
            textBoxCoreNumber.Text = passedCoreNumber + "/" + passedCoreTotal;
            textBoxTableID.Text = passedTableID;

            // Sets the timer interval to 1 second.
            timer.Interval = 1000;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //admin_pc_job_time_tracker.Service job_time_tracker_service = new ZebraApp.admin_pc_job_time_tracker.Service();
            //try
            //{

            //    job_time_tracker_service.InsertJob(lblTableID.Text, Int32.Parse(job[0]), Int32.Parse(job[1]), Int32.Parse(core[0]), Int32.Parse(core[1]), phase, "Start");

            //}
            //catch (FormatException exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
            buttonStart.Enabled = false;
            textBoxStatus.Text = "Start";
            buttonEnd.Enabled = true;
            timer.Enabled = true;
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timerSeconds = timerSeconds + 1;
            if (timerSeconds == 60)
            {
                timerSeconds = 0;

                timerMinutes = timerMinutes + 1;
                if (timerMinutes == 60)
                {
                    timerMinutes = 0;

                    timerHours = timerHours + 1;
                }
            }

            string seconds = timerSeconds.ToString();
            seconds = seconds.Length == 1 ? "0" + seconds : seconds;

            string minutes = timerMinutes.ToString();
            minutes = minutes.Length == 1 ? "0" + minutes : minutes;

            string hours = timerHours.ToString();
            hours = hours.Length == 1 ? "0" + hours : hours;

            textBoxTimer.Text = hours + ":" + minutes + ":" + seconds;
        }
    }
}