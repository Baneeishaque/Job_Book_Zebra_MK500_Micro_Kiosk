using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    public partial class Actions : Form
    {
        int timerSeconds = 0, timerMinutes = 0, timerHours = 0;
        string operatorBadgeID, jobNumber, itemNumber, coreNumber, coreTotal, tableID, phase;
        job_time_tracker_service.Service jobTimeTrackerService = new Job_Book_Zebra_MK500_Micro_Kiosk.job_time_tracker_service.Service();

        public Actions(string passedOperatorBadgeID, string passedJobNumber, string passedItemNumber, string passedCoreNumber, string passedCoreTotal, string passedTableID, string passedPhase)
        {
            InitializeComponent();

            textBoxOperatorBadgeID.Text = passedOperatorBadgeID;
            textBoxJobNumber.Text = passedJobNumber + "/" + passedItemNumber;
            textBoxCoreNumber.Text = passedCoreNumber + "/" + passedCoreTotal;
            textBoxTableID.Text = passedTableID;

            this.operatorBadgeID = passedOperatorBadgeID;
            this.jobNumber = passedJobNumber;
            this.itemNumber = passedItemNumber;
            this.coreNumber = passedCoreNumber;
            this.coreTotal = passedCoreTotal;
            this.tableID = passedTableID;
            this.phase = passedPhase;

            // Sets the timer interval to 1 second.
            timer.Interval = 1000;

            try
            {
                jobTimeTrackerService.Url = Settings.webServiceURL;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Settings Error : " + exception.Message);
                Application.Exit();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                string dbOperationResult = jobTimeTrackerService.InsertJob("M00045",operatorBadgeID,jobNumber,itemNumber,coreNumber,coreTotal,phase);
                if (dbOperationResult == "1")
                {
                    buttonStart.Enabled = false;
                    textBoxStatus.Text = "Start";
                    buttonEnd.Enabled = true;
                    timer.Enabled = true;
                }
                else if (dbOperationResult == "0")
                {

                    MessageBox.Show("Database Error...");
                }
                else
                {
                    MessageBox.Show("Database Error : " + dbOperationResult);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception : " + exception.Message);
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;

            try
            {
                string dbOperationResult = jobTimeTrackerService.UpdateJob("M00045",operatorBadgeID,jobNumber);
                if (dbOperationResult == "1")
                {
                    MessageBox.Show("Thanks...");
                    Application.Exit();
                }
                else if (dbOperationResult == "0")
                {

                    MessageBox.Show("Database Error...");
                }
                else
                {
                    MessageBox.Show("Database Error : " + dbOperationResult);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception : " + exception.Message);
            }
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