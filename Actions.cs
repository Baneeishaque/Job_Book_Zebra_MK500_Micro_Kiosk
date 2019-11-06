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
        Stopwatch stopWatch = new Stopwatch();
        //bool stopWatchFlag = false;
        Thread childThread;

        public Actions()
        {
            InitializeComponent();
        }

        void CallToChildThread()
        {
            TimeSpan timespan = stopWatch.Elapsed;
            while (stopWatch.IsRunning)
            {
                //if (textBox10.InvokeRequired)
                //{
                //    textBox10.Invoke((Action)(() => textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds)));
                //    //textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds);
                //}
                textBox10.Invoke((Action)delegate { textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds); });
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
            //while (stopWatch.IsRunning)
            //{
            //    TimeSpan timespan = stopWatch.Elapsed;
            //    textBox10.Text = String.Format("{0:00}:{1:00}:{2:00}",timespan.Hours,timespan.Minutes,timespan.Seconds);
            //    if (stopWatchFlag)
            //    {
            //        stopWatch.Stop();
            //    }
            //}
            ThreadStart childref = new ThreadStart(CallToChildThread);
            childThread = new Thread(childref);
            childThread.Start();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //stopWatchFlag = true;
            stopWatch.Stop();
            childThread.Abort();
        }
    }
}