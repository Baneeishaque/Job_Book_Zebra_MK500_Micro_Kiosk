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
        //Stopwatch stopWatch = new Stopwatch();
        ////bool stopWatchFlag = false;
        //Thread childThread;
        //int ms = 0,s=0,m=0,h=0;
        int s=0,m=0,h=0;

        public Actions()
        {
            InitializeComponent();

            // Sets the timer interval to 1 second.
            timer.Interval=1000;
        }

        //void CallToChildThread()
        //{
        //    TimeSpan timespan = stopWatch.Elapsed;
        //    while (stopWatch.IsRunning)
        //    {
        //        //if (textBox10.InvokeRequired)
        //        //{
        //        //    textBox10.Invoke((Action)(() => textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds)));
        //        //    //textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        //        //}
        //        textBox10.Invoke((Action)delegate { textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds); });
        //    }
        //}

        private void button8_Click(object sender, EventArgs e)
        {
            //stopWatch.Start();
            //while (stopWatch.IsRunning)
            //{
            //    TimeSpan timespan = stopWatch.Elapsed;
            //    textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}",timespan.Hours,timespan.Minutes,timespan.Seconds);
            //    if (stopWatchFlag)
            //    {
            //        stopWatch.Stop();
            //    }
            //}
            //ThreadStart childref = new ThreadStart(CallToChildThread);
            //childThread = new Thread(childref);
            //childThread.Start();

            //string[] job = textBox1.Text.Split('/');
            //string[] core = textBox2.Text.Split('/');

            //admin_pc_job_time_tracker.Service job_time_tracker_service = new ZebraApp.admin_pc_job_time_tracker.Service();
            //try
            //{

            //    job_time_tracker_service.InsertJob(lblTableID.Text, Int32.Parse(job[0]), Int32.Parse(job[1]), Int32.Parse(core[0]), Int32.Parse(core[1]), phase, "Start");

            //}
            //catch (FormatException exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
            button8.Enabled = false;
            button1.Enabled = true;
            timer.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //stopWatchFlag = true;
            //stopWatch.Stop();
            //childThread.Abort();
            timer.Enabled = false;

            //if (textBox4.Enabled == false)
            //{
            //    textBox4.Enabled = true;

            //    textBox4.Text = "";
            //}

            //if (textBox4.Text == "")
            //{
            //    MessageBox.Show("Please Scan your id");
            //}
            //else
            //{

            //    button3.Enabled = true;
            //    timer1.Enabled = false;



            //    panelLast.Hide();
            //    panelTable.Hide();
            //    pictureBoxSettings.Show();

            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    textBox9.Text = "";
            //    textBox4.Text = "";
            //    textBox3.Text = "";

            //    textBox4.Enabled = true;
            //    textBox1.Enabled = true;
            //    textBox2.Enabled = true;
            //    textBox3.Enabled = true;

            //    //timer stop

            //    ms = 0;
            //    h = 0;
            //    s = 0;
            //    m = 0;
            //    timer1.Enabled = false;
            //    textBox9.Text = "00:00:00";


            //    //Application.Restart();


            //}
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            s = s + 1;
            if (s == 60)
            {
                s = 0;
                
                m = m + 1;
                if (m == 60)
                {
                    m = 0;

                    h = h + 1;
                }
            }

                string seconds = s.ToString();
                seconds = seconds.Length == 1 ? "0" + seconds : seconds;
 
                string minutes = m.ToString();
                minutes = minutes.Length == 1 ? "0" + minutes : minutes;
                
                string hours = h.ToString();
                hours = hours.Length == 1 ? "0" + hours : hours;

                textBox10.Text = hours + ":" + minutes + ":" + seconds;
        }
    }
}