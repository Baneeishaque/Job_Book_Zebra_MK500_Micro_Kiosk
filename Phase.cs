using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using CS_Barcode;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    public partial class Phase : Form
    {


        job_time_tracker_service.Service jobTimeTrackerService = new Job_Book_Zebra_MK500_Micro_Kiosk.job_time_tracker_service.Service();
        string phase="ASSEMBLY";
   
        API barcodeAPI = new API();
        bool isReaderInitiated;
        EventHandler barcodeReadNotifyHandler = null;
        bool initialised = false;
        TextBox focussedTextBox = null;

        string job0passingtoactionpanel="";
        string job1passingtoactionpanel = "";
        string core0passingtoactionpanel = "";
        string core1passingtoactionpanel = "";

        string customer_Number = "";
        string customer_Description = "";
        string Core_Description = "";


        string Number_Passing_To_ItemTbl_For_getting_weight = "";
        string production_BOM_Number = "";
        string weight_sending_TO_Database = "";
        string Product_Group_Code = "";
        string thickness_Sending_toDATABASE = "";


        //=============Version 2.0 Varibles==============//
        //string jobNumberFromEquipmentScrum = "";
        //string ItemNumberFromEquipmentScrum = "";
        //string CoreNumberFromEquipmentScrum = "";
        //string CoreTotalFromEquipmentScrum = "";


      

        //=============Version 2.0 Varibles End Here==============//

        public Phase() 
        {
           InitializeComponent();
        
            try
            {
                jobTimeTrackerService.Url = Settings.webServiceURL;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Settings Error : " + exception.Message);
                
                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();
            }
           // textBoxOperatorBadgeID.Focus();
       

        }
      

        /// <summary>
        /// Handle data from the reader. Used in the scan mode.
        /// </summary>
        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            try
            {

                if (focussedTextBox != null)
                {
                    focussedTextBox.Text = TheReaderData.Text;
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("1.Scan again");
             //   string s = ex.ToString();
                MessageBox.Show(ex.ToString());
                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();

            }

        }

        
        private void currentBarcodeReadNotifyHandler(object Sender, EventArgs e)
        {
            try
            {
                // Checks if the Invoke method is required because the ReadNotify delegate is called by a different thread
                if (this.InvokeRequired)
                {
                    // Executes the ReadNotify delegate on the main thread
                    this.Invoke(barcodeReadNotifyHandler, new object[] { Sender, e });
                }
                else
                {

                                try
                                {
                                        // Get ReaderData
                                        Symbol.Barcode.ReaderData TheReaderData = barcodeAPI.Reader.GetNextReaderData();
                                        if (TheReaderData != null )
                                        {
                                            switch (TheReaderData.Result)
                                            {


                                                case Symbol.Results.SUCCESS:
                                                    // Handle the data from this read & submit the next read.
                                                    HandleData(TheReaderData);
                                                    barcodeAPI.StartRead(false);
                                                    break;

                                                case Symbol.Results.E_SCN_READTIMEOUT:
                                                    errorOnBarcodeRead("");
                                                    break;

                                                case Symbol.Results.CANCELED:
                                                    errorOnBarcodeRead("");
                                                    break;

                                                case Symbol.Results.E_SCN_DEVICEFAILURE:
                                                    errorOnBarcodeRead("");
                                                    break;

                                                default:
                                                    errorOnBarcodeRead("Read Failed\nResult = " + (TheReaderData.Result).ToString());
                                                    //if (TheReaderData.Result == Symbol.Results.E_SCN_READINCOMPATIBLE)
                                                    //{
                                                    //    // If the failure is E_SCN_READINCOMPATIBLE, exit the application.
                                                    //    errorOnBarcodeRead("");
                                                    //}
                                                    break;
                                            }
                                        }
                                        else
                                        {

                                        }

                                }
                                catch (Exception ex)
                                {
                                    //ex.ToString();
                                  
                                    //Process p = new Process();
                                    //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                                    //p.Start();
                                    //Application.Exit();
                                    MessageBox.Show(ex.ToString());

                                }



                }
            }
            catch (Exception ex)
            {
                //ex.ToString();
                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();
                MessageBox.Show(ex.ToString());
            }

        }

        void errorOnBarcodeRead(string message)
        {

            try
            {

            // Stop the read operation & detach the handler.
            barcodeAPI.StopRead();
            barcodeAPI.DetachReadNotify();
            barcodeAPI.TermReader();

            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();

                MessageBox.Show(ex.ToString());
            }




            //MessageBox.Show("Scanning Error...");
            //if (message == "")
            //{
            //    MessageBox.Show("Error Reading Barcode...");
            //}
            //else
            //{
            //    MessageBox.Show(message);
            //}

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            textBoxOperatorBadgeID.Text = "";
            textBoxJobNumber.Text = "";
            textBoxCoreNumber.Text = "";
            textBoxTableID.Text = "";

            buttonStart.Visible = false;
            buttonEnd.Visible = false;
            buttonScan.Visible = true;
            buttonScan.Enabled = true;

            textBoxOperatorBadgeID.Enabled = true;
            textBoxJobNumber.Enabled = false;
            textBoxCoreNumber.Enabled = false;
            textBoxTableID.Enabled = false;
            buttonScan.Focus();
            //textBoxOperatorBadgeID.Focus();


            //barcodeAPI.StopRead();


            //barcodeAPI.DetachReadNotify();

            //barcodeAPI.TermReader();


            
            //Process p = new Process();
            //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
            //p.Start();
            //Application.Exit();

            //Home hm = new Home();
            //hm.ShowDialog();
            //this.Close();


            //Refresh Global Variables
             //jobNumberFromEquipmentScrum = "";
             //ItemNumberFromEquipmentScrum = "";
             //CoreNumberFromEquipmentScrum = "";
             //CoreTotalFromEquipmentScrum = "";

              job0passingtoactionpanel = "";
             job1passingtoactionpanel = "";
              core0passingtoactionpanel = "";
             core1passingtoactionpanel = "";


             //IdEmployeeFromTimeEmployee = "";
             //TimeStartFromTimeEmployee = "";

             btnEndMyJob.Visible = false;
             btnStartMyJob.Visible = false;
             txtBoxAddAllOperators.Text = "";


             //============refresh============//

             buttonEnd.Size = new Size(180, 62);
             buttonEnd.Location = new Point(124, 171);

             buttonBack.Visible = true;
             buttonBack.Size = new Size(108, 62);
             buttonBack.Location = new Point(10, 171);


             btnEndMyJob.Size = new Size(180, 62);
             btnEndMyJob.Location = new Point(124, 171);



            //============FOCUS================//

             if (textBoxTableID.Text == "")
             {
                 textBoxTableID.Enabled = true;
                 textBoxTableID.Focus();
             }
             else
             {
                 if (textBoxJobNumber.Text == "")
                 {
                     textBoxJobNumber.Enabled = true;
                     textBoxJobNumber.Focus();

                 }
                 else
                 {
                     if (textBoxCoreNumber.Text == "")
                     {
                         textBoxCoreNumber.Enabled = true;
                         textBoxCoreNumber.Focus();
                     }
                     else
                     {
                         if (textBoxOperatorBadgeID.Text == "")
                         {
                             textBoxOperatorBadgeID.Enabled = true;
                             textBoxOperatorBadgeID.Focus();
                         }
                         else
                         {
                             buttonScan.Focus();
                         }

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

        
        private void Phase_Load(object sender, EventArgs e)
        {
            //Color colour = ColorTranslator.FromHtml("#E7EFF2");
            buttonScan.Focus();

            
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            
           // textBoxOperatorBadgeID.Focus();

            textBoxOperatorBadgeID.Text = "";
            textBoxJobNumber.Text = "";
            textBoxCoreNumber.Text = "";
            textBoxTableID.Text = "";

            buttonStart.Visible = false;
            buttonEnd.Visible = false;
            buttonScan.Visible = true;
            buttonScan.Enabled = true;
            textBoxOperatorBadgeID.Enabled =true ;
            textBoxJobNumber.Enabled = false;
            textBoxCoreNumber.Enabled = false;
            textBoxTableID.Enabled = false;
            buttonScan.Focus();
        
          
        }
     

      
       
        private void buttonContinue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ControlBox = true;
                this.MinimizeBox = true;



            }
           
        }

        private void textBoxOperatorBadgeId_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (textBoxOperatorBadgeID != null)
                {

                    focussedTextBox = textBoxOperatorBadgeID;
                    resetBarcode();
                }
                else
                {
                    MessageBox.Show("Please Scan");
                    textBoxOperatorBadgeID.Focus();
                }
            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();

                MessageBox.Show(ex.ToString());
            }
        }

        private void textBoxJobNumber_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (textBoxJobNumber != null)
                {

                    focussedTextBox = textBoxJobNumber;
                    resetBarcode();

                }
                else
                {
                    MessageBox.Show("Please Scan");
                    textBoxJobNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();

                MessageBox.Show(ex.ToString());
            }
       
        }

        private void textBoxCoreNumber_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (textBoxCoreNumber != null)
                {
                    focussedTextBox = textBoxCoreNumber;
                    resetBarcode();
                }
                else
                {
                    MessageBox.Show("Please Scan");
                    textBoxCoreNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();
                MessageBox.Show(ex.ToString());

            }
          
        }
        

        private void textBoxTableID_GotFocus(object sender, EventArgs e)
        {


            try
            {
                if (textBoxTableID != null)
                {

                    focussedTextBox = textBoxTableID;
                    resetBarcode();
                }
                else
                {
                    MessageBox.Show("Please Scan");
                    textBoxTableID.Focus();
                }
            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();

                MessageBox.Show(ex.ToString());
            }

          
        }

        private void Phase_Closing(object sender, CancelEventArgs e)
        {
            barcodeAPI.StopRead();
            barcodeAPI.DetachReadNotify();
            barcodeAPI.TermReader();
        }
   
        private void resetBarcode()
        {
            try
            {
                if (initialised)
                {
                    barcodeAPI.StopRead();
                    barcodeAPI.DetachReadNotify();
                    barcodeAPI.TermReader();
                }
                else
                {
                    initialised = true;
                }

                    barcodeAPI = null;
            
                    barcodeAPI = new API();
                
                isReaderInitiated = barcodeAPI.InitReader();

                if (this.isReaderInitiated)
                {
                    barcodeAPI.StartRead(true);
                    barcodeReadNotifyHandler = new EventHandler(currentBarcodeReadNotifyHandler);
                    barcodeAPI.AttachReadNotify(barcodeReadNotifyHandler);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();
                MessageBox.Show(ex.ToString());
            }

        }
      

        private void textBoxOperatorBadgeID_TextChanged(object sender, EventArgs e)
        {


            if (textBoxOperatorBadgeID.Text == "")
            {

            }
            else
            {

                if (textBoxOperatorBadgeID.Text.Contains("/") || !textBoxOperatorBadgeID.Text.Contains("-"))
                {
                    MessageBox.Show("Invalid Badge ID");


                    textBoxOperatorBadgeID.Enabled = true;
                    textBoxJobNumber.Enabled = false;
                    textBoxCoreNumber.Enabled = false;
                    textBoxTableID.Enabled = false;

                    textBoxOperatorBadgeID.Text = "";
                    textBoxOperatorBadgeID.Focus();




                }
                else
                {

                    string Is_This_Job_Already_Exist_In_Workin_Progress = jobTimeTrackerService.Select_Count_of_Running_WorkinProgress_To_Check_Number_of_running_jobs(job0passingtoactionpanel, job1passingtoactionpanel, core0passingtoactionpanel, core1passingtoactionpanel, phase);
                    int number_of_times_this_Jobadded_in_Workin_Progress = int.Parse(Is_This_Job_Already_Exist_In_Workin_Progress.ToString());


                    if (number_of_times_this_Jobadded_in_Workin_Progress == 0)
                    {




                        string[] job = textBoxJobNumber.Text.Trim().Split('/');
                        string jobnumber_ = job[0].Trim();
                        string itemnumber_ = job[1].TrimStart(new Char[] { 'O' });


                        string[] core = textBoxCoreNumber.Text.Trim().Split('/');
                        string corenumber_ = core[0].Trim();
                        string coretotal_ = core[1].TrimStart(new Char[] { 'O' });




                        string wrkinprogressnumberofthisEmployeesgetting = "";
                        //Select Number of employees work in this project
                        string connetionString1 = null;
                        SqlConnection cnn1;
                        connetionString1 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                        cnn1 = new SqlConnection(connetionString1);
                        cnn1.Open();

                        SqlCommand cmd1;
                        SqlDataReader datareader1;
                        string sql1 = "";

                        //select customer number and core description
                        sql1 = "SELECT No_ from WorkInProgress where Job='" + jobnumber_ + "' and Item='" + itemnumber_ + "' and Core='" + corenumber_ + "' and CoreTotal='" + coretotal_ + "' ";

                        cmd1 = new SqlCommand(sql1, cnn1);
                        datareader1 = cmd1.ExecuteReader();
                        while (datareader1.Read())
                        {
                            wrkinprogressnumberofthisEmployeesgetting = datareader1.GetValue(0).ToString();

                        }

                        datareader1.Close();
                        cmd1.Dispose();
                        cnn1.Close();

                        //=====================Checking for scanned badge ID is running in Time Employee or not=====================//


                        string connetionString = null;
                        SqlConnection cnn;
                        connetionString = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                        cnn = new SqlConnection(connetionString);
                        cnn.Open();
                        string sql;
                        SqlCommand cmd;
                        SqlDataReader datareader;

                        string IdEmployeeFromTimeEmployee = "";
                        string TimeStartFromTimeEmployee = "";

                        sql = "SELECT ID_employee,Time_Start from Time_Employee where Time_End='' and ID_employee='" + textBoxOperatorBadgeID.Text + "' and FK_WorkInProgress_No_='" + wrkinprogressnumberofthisEmployeesgetting + "'";

                        cmd = new SqlCommand(sql, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {

                            IdEmployeeFromTimeEmployee = datareader.GetValue(0).ToString();
                            TimeStartFromTimeEmployee = datareader.GetValue(1).ToString();

                        }



                        datareader.Close();
                        cmd.Dispose();
                        cnn.Close();

                        //=====================//


                        string jobNumberFromEquipmentScrum = "";
                        string ItemNumberFromEquipmentScrum = "";
                        string CoreNumberFromEquipmentScrum = "";
                        string CoreTotalFromEquipmentScrum = "";


                        string connetionString2 = null;
                        SqlConnection cnn2;
                        connetionString2 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                        cnn2 = new SqlConnection(connetionString2);
                        cnn2.Open();

                        SqlCommand cmd2;
                        SqlDataReader datareader2;
                        string sql2;


                        sql2 = "SELECT Job,Item,Core,CoreTotal from Equipment_Scrum where [Equipment No_]='" + textBoxTableID.Text + "' ";

                        if (sql2 != null && sql2 != "")    // This Table is already running - We get the project details
                        {

                            cmd2 = new SqlCommand(sql2, cnn2);
                            datareader2 = cmd2.ExecuteReader();
                            while (datareader2.Read())
                            {
                                jobNumberFromEquipmentScrum = datareader2.GetValue(0).ToString();
                                ItemNumberFromEquipmentScrum = datareader2.GetValue(1).ToString();
                                CoreNumberFromEquipmentScrum = datareader2.GetValue(2).ToString();
                                CoreTotalFromEquipmentScrum = datareader2.GetValue(3).ToString();
                            }

                            datareader2.Close();
                            cmd2.Dispose();
                            cnn2.Close();




                            if (jobNumberFromEquipmentScrum != "" && ItemNumberFromEquipmentScrum != "" && CoreNumberFromEquipmentScrum != "" && CoreTotalFromEquipmentScrum != "")
                            // If PRoject Is already Started
                            {


                                //eee wrkin progresssil iyaalkkk finisheryyaatha wrkgal illa
                                if (IdEmployeeFromTimeEmployee.ToString() == "" && TimeStartFromTimeEmployee.ToString() == "")    //// there is no unfinished job for this employee in this same workin progress
                                {

                                    //Insert in to Time Employee

                                    //iyyyaaal veeere eedhileelum wrkeyyundo checkeyy


                                    string connetionString5 = null;
                                    SqlConnection cnn5;
                                    connetionString5 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                                    cnn5 = new SqlConnection(connetionString5);
                                    cnn5.Open();
                                    string sql5;
                                    SqlCommand cmd5;
                                    SqlDataReader datareader5;

                                    string ifhealreadydoingsomework1 = "";
                                    string ifhealreadydoingsomework12 = "";

                                    sql5 = "SELECT ID_employee,Time_Start from Time_Employee where Time_End='' and ID_employee='" + textBoxOperatorBadgeID.Text + "'";

                                    cmd5 = new SqlCommand(sql5, cnn5);
                                    datareader5 = cmd5.ExecuteReader();
                                    while (datareader5.Read())
                                    {

                                        ifhealreadydoingsomework1 = datareader5.GetValue(0).ToString();
                                        ifhealreadydoingsomework12 = datareader5.GetValue(1).ToString();

                                    }



                                    datareader5.Close();
                                    cmd5.Dispose();
                                    cnn5.Close();


                                    if (ifhealreadydoingsomework1 == "" && ifhealreadydoingsomework12 == "")
                                    {

                                        textBoxOperatorBadgeID.Enabled = false;
                                        textBoxJobNumber.Enabled = false;
                                        textBoxCoreNumber.Enabled = false;
                                        textBoxTableID.Enabled = false;


                                        buttonScan.Visible = false;


                                        buttonEnd.Visible = false;
                                        btnEndMyJob.Visible = false;

                                        buttonBack.Visible = true;

                                        buttonStart.Visible = false;

                                        btnStartMyJob.Visible = true;
                                        btnStartMyJob.Focus();

                                    }
                                    else
                                    {
                                        MessageBox.Show("You already started another job");
                                    }
                                }
                                else // this employee started one job already in this workinprogress
                                {

                                    //  string numberofemployees = jobTimeTrackerService.Select_Number_of_Employees_Working_In_this_Project(wrkinprogressnumberofthisEmployeesgetting);  //max id of time employee
                                    // int NumberOfEmployeesWorkingInthisProject = int.Parse(numberofemployees); // maxi id of time employee increment


                                    //  if (NumberOfEmployeesWorkingInthisProject <= 1)//it is the last employee
                                    // {
                                    //textBoxOperatorBadgeID.Enabled = false;
                                    //textBoxJobNumber.Enabled = false;
                                    //textBoxCoreNumber.Enabled = false;
                                    //textBoxTableID.Enabled = false;

                                    //buttonScan.Visible = false;
                                    //buttonStart.Visible = false;
                                    //btnStartMyJob.Visible = false;
                                    //buttonEnd.Visible = true;

                                    // }
                                    // else
                                    // {




                                    string For_Permission_CheckThisEmployeewereWorkedInthisProjectOrNot = jobTimeTrackerService.CheckThisEmployeewereWorkedInthisProjectOrNot(wrkinprogressnumberofthisEmployeesgetting, textBoxOperatorBadgeID.Text);
                                    int numberofrowsretrived = int.Parse(For_Permission_CheckThisEmployeewereWorkedInthisProjectOrNot);

                                    //check this guy are work in this project or not
                                    if (numberofrowsretrived == 0)
                                    {
                                        MessageBox.Show("You are not in this project");

                                        //==========================REFRESH=============================//
                                        textBoxOperatorBadgeID.Text = "";
                                        textBoxJobNumber.Text = "";
                                        textBoxCoreNumber.Text = "";
                                        textBoxTableID.Text = "";

                                        buttonStart.Visible = false;
                                        buttonEnd.Visible = false;
                                        buttonScan.Visible = true;
                                        buttonScan.Enabled = true;

                                        textBoxOperatorBadgeID.Enabled = true;
                                        textBoxJobNumber.Enabled = false;
                                        textBoxCoreNumber.Enabled = false;
                                        textBoxTableID.Enabled = false;
                                        buttonScan.Focus();


                                        job0passingtoactionpanel = "";
                                        job1passingtoactionpanel = "";
                                        core0passingtoactionpanel = "";
                                        core1passingtoactionpanel = "";



                                        btnEndMyJob.Visible = false;
                                        btnStartMyJob.Visible = false;
                                        txtBoxAddAllOperators.Text = "";

                                        buttonEnd.Size = new Size(180, 62);
                                        buttonEnd.Location = new Point(124, 171);

                                        buttonBack.Visible = true;
                                        buttonBack.Size = new Size(108, 62);
                                        buttonBack.Location = new Point(10, 171);


                                        btnEndMyJob.Size = new Size(180, 62);
                                        btnEndMyJob.Location = new Point(124, 171);

                                        if (textBoxTableID.Text == "")
                                        {
                                            textBoxTableID.Enabled = true;
                                            textBoxTableID.Focus();
                                        }
                                        else
                                        {
                                            if (textBoxJobNumber.Text == "")
                                            {
                                                textBoxJobNumber.Enabled = true;
                                                textBoxJobNumber.Focus();

                                            }
                                            else
                                            {
                                                if (textBoxCoreNumber.Text == "")
                                                {
                                                    textBoxCoreNumber.Enabled = true;
                                                    textBoxCoreNumber.Focus();
                                                }
                                                else
                                                {
                                                    if (textBoxOperatorBadgeID.Text == "")
                                                    {
                                                        textBoxOperatorBadgeID.Enabled = true;
                                                        textBoxOperatorBadgeID.Focus();
                                                    }
                                                    else
                                                    {
                                                        buttonScan.Focus();
                                                    }

                                                }

                                            }
                                        }


                                        //=============================REFRESH END Here===================================

                                    }
                                    else
                                    {

                                        textBoxOperatorBadgeID.Enabled = false;
                                        textBoxJobNumber.Enabled = false;
                                        textBoxCoreNumber.Enabled = false;
                                        textBoxTableID.Enabled = false;



                                        buttonScan.Visible = false;
                                        buttonStart.Visible = false;
                                        btnStartMyJob.Visible = false;



                                        buttonEnd.Visible = true;
                                        buttonEnd.Size = new Size(108, 62);
                                        buttonEnd.Location = new Point(70, 170);

                                        buttonBack.Visible = true;
                                        buttonBack.Size = new Size(55, 62);
                                        buttonBack.Location = new Point(10, 170);

                                        btnEndMyJob.Visible = true;
                                        btnEndMyJob.Size = new Size(121, 62);
                                        btnEndMyJob.Location = new Point(183, 170);

                                        // }


                                    }






                                }

                            } // if it is a new project
                            else
                            {

                                //select location from wrk in prgress and where job item core and core_total
                                //if exist and tble is not same 



                                string connetionString5 = null;
                                SqlConnection cnn5;
                                connetionString5 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                                cnn5 = new SqlConnection(connetionString5);
                                cnn5.Open();
                                string sql5;
                                SqlCommand cmd5;
                                SqlDataReader datareader5;

                                string LocationToCheck = "";


                                sql5 = "SELECT Location from WorkInProgress where Job='" + job0passingtoactionpanel + "' and Item='" + job1passingtoactionpanel + "' and Core='" + core0passingtoactionpanel + "' and CoreTotal='" + core1passingtoactionpanel + "'";

                                cmd5 = new SqlCommand(sql5, cnn5);
                                datareader5 = cmd5.ExecuteReader();
                                while (datareader5.Read())
                                {

                                    LocationToCheck = datareader5.GetValue(0).ToString();
                                 
                                }



                                datareader5.Close();
                                cmd5.Dispose();
                                cnn5.Close();

                                if (LocationToCheck.ToString() == "" || (LocationToCheck.ToString() == textBoxTableID.Text)) ///eeee table il thanneee aaanooo job thodangyadh nokkaan
                                {
                                    string connetionString3 = null;
                                    SqlConnection cnn3;
                                    connetionString3 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                                    cnn3 = new SqlConnection(connetionString3);
                                    cnn3.Open();
                                    string sql3;
                                    SqlCommand cmd3;
                                    SqlDataReader datareader3;

                                    string IdEmployeeFromTimeEmployee_NewProject = "";
                                    string TimeStartFromTimeEmployee_NewPRoject = "";

                                    sql3 = "SELECT ID_employee,Time_Start from Time_Employee where Time_End='' and ID_employee='" + textBoxOperatorBadgeID.Text + "'";

                                    cmd3 = new SqlCommand(sql3, cnn3);
                                    datareader3 = cmd3.ExecuteReader();
                                    while (datareader3.Read())
                                    {

                                        IdEmployeeFromTimeEmployee_NewProject = datareader3.GetValue(0).ToString();
                                        TimeStartFromTimeEmployee_NewPRoject = datareader3.GetValue(1).ToString();

                                    }



                                    datareader3.Close();
                                    cmd3.Dispose();
                                    cnn3.Close();




                                    if (IdEmployeeFromTimeEmployee_NewProject.ToString() == "" && TimeStartFromTimeEmployee_NewPRoject.ToString() == "")// there is no unfinished job for this employee
                                    {
                                        PanelPopup.Enabled = true;
                                        PanelPopup.Visible = true;


                                        textBoxOperatorBadgeID.Enabled = false;
                                        textBoxJobNumber.Enabled = false;
                                        textBoxCoreNumber.Enabled = false;
                                        textBoxTableID.Enabled = false;


                                        buttonScan.Visible = false;


                                        buttonEnd.Visible = false;
                                        btnEndMyJob.Visible = false;
                                        btnStartMyJob.Visible = false;

                                        buttonBack.Visible = true;

                                     
                                        buttonStart.Visible = true;
                                        lblTeam.Text = textBoxOperatorBadgeID.Text;
                                        lblTableIdinPopupWindow.Text = textBoxTableID.Text;
                                    }
                                    else
                                    {

                                        MessageBox.Show("You already started another Project");
                                        textBoxOperatorBadgeID.Text = "";
                                        textBoxOperatorBadgeID.Focus();

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Wrong table for this job");
                                    //======================REFRESH============================//

                                    textBoxOperatorBadgeID.Text = "";
                                    textBoxJobNumber.Text = "";
                                    textBoxCoreNumber.Text = "";
                                    textBoxTableID.Text = "";

                                    buttonStart.Visible = false;
                                    buttonEnd.Visible = false;
                                    buttonScan.Visible = true;
                                    buttonScan.Enabled = true;

                                    textBoxOperatorBadgeID.Enabled = true;
                                    textBoxJobNumber.Enabled = false;
                                    textBoxCoreNumber.Enabled = false;
                                    textBoxTableID.Enabled = false;
                                    buttonScan.Focus();
                                    //textBoxOperatorBadgeID.Focus();


                                    //barcodeAPI.StopRead();


                                    //barcodeAPI.DetachReadNotify();

                                    //barcodeAPI.TermReader();



                                    //Process p = new Process();
                                    //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                                    //p.Start();
                                    //Application.Exit();

                                    //Home hm = new Home();
                                    //hm.ShowDialog();
                                    //this.Close();


                                    //Refresh Global Variables
                                    //jobNumberFromEquipmentScrum = "";
                                    //ItemNumberFromEquipmentScrum = "";
                                    //CoreNumberFromEquipmentScrum = "";
                                    //CoreTotalFromEquipmentScrum = "";

                                    job0passingtoactionpanel = "";
                                    job1passingtoactionpanel = "";
                                    core0passingtoactionpanel = "";
                                    core1passingtoactionpanel = "";


                                    //IdEmployeeFromTimeEmployee = "";
                                    //TimeStartFromTimeEmployee = "";

                                    btnEndMyJob.Visible = false;
                                    btnStartMyJob.Visible = false;
                                    txtBoxAddAllOperators.Text = "";


                                    //============refresh============//

                                    buttonEnd.Size = new Size(180, 62);
                                    buttonEnd.Location = new Point(124, 171);

                                    buttonBack.Visible = true;
                                    buttonBack.Size = new Size(108, 62);
                                    buttonBack.Location = new Point(10, 171);


                                    btnEndMyJob.Size = new Size(180, 62);
                                    btnEndMyJob.Location = new Point(124, 171);



                                    //============FOCUS================//

                                    if (textBoxTableID.Text == "")
                                    {
                                        textBoxTableID.Enabled = true;
                                        textBoxTableID.Focus();
                                    }
                                    else
                                    {
                                        if (textBoxJobNumber.Text == "")
                                        {
                                            textBoxJobNumber.Enabled = true;
                                            textBoxJobNumber.Focus();

                                        }
                                        else
                                        {
                                            if (textBoxCoreNumber.Text == "")
                                            {
                                                textBoxCoreNumber.Enabled = true;
                                                textBoxCoreNumber.Focus();
                                            }
                                            else
                                            {
                                                if (textBoxOperatorBadgeID.Text == "")
                                                {
                                                    textBoxOperatorBadgeID.Enabled = true;
                                                    textBoxOperatorBadgeID.Focus();
                                                }
                                                else
                                                {
                                                    buttonScan.Focus();
                                                }

                                            }

                                        }
                                    }







                                    //==========================REFRESH END========================//

                                }
                               
                              
                            }

                            //        cnn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Job Already added");
                        textBoxOperatorBadgeID.Text = "";
                        textBoxJobNumber.Text = "";
                        textBoxCoreNumber.Text = "";
                        textBoxTableID.Text = "";

                        buttonStart.Visible = false;
                        buttonEnd.Visible = false;
                        buttonScan.Visible = true;
                        buttonScan.Enabled = true;

                        textBoxOperatorBadgeID.Enabled = true;
                        textBoxJobNumber.Enabled = false;
                        textBoxCoreNumber.Enabled = false;
                        textBoxTableID.Enabled = false;
                        buttonScan.Focus();
                        //textBoxOperatorBadgeID.Focus();


                        //barcodeAPI.StopRead();


                        //barcodeAPI.DetachReadNotify();

                        //barcodeAPI.TermReader();



                        //Process p = new Process();
                        //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                        //p.Start();
                        //Application.Exit();

                        //Home hm = new Home();
                        //hm.ShowDialog();
                        //this.Close();


                        //Refresh Global Variables
                        //jobNumberFromEquipmentScrum = "";
                        //ItemNumberFromEquipmentScrum = "";
                        //CoreNumberFromEquipmentScrum = "";
                        //CoreTotalFromEquipmentScrum = "";

                        job0passingtoactionpanel = "";
                        job1passingtoactionpanel = "";
                        core0passingtoactionpanel = "";
                        core1passingtoactionpanel = "";


                        //IdEmployeeFromTimeEmployee = "";
                        //TimeStartFromTimeEmployee = "";

                        btnEndMyJob.Visible = false;
                        btnStartMyJob.Visible = false;
                        txtBoxAddAllOperators.Text = "";


                        //============refresh============//

                        buttonEnd.Size = new Size(180, 62);
                        buttonEnd.Location = new Point(124, 171);

                        buttonBack.Visible = true;
                        buttonBack.Size = new Size(108, 62);
                        buttonBack.Location = new Point(10, 171);


                        btnEndMyJob.Size = new Size(180, 62);
                        btnEndMyJob.Location = new Point(124, 171);



                        //============FOCUS================//

                        if (textBoxTableID.Text == "")
                        {
                            textBoxTableID.Enabled = true;
                            textBoxTableID.Focus();
                        }
                        else
                        {
                            if (textBoxJobNumber.Text == "")
                            {
                                textBoxJobNumber.Enabled = true;
                                textBoxJobNumber.Focus();

                            }
                            else
                            {
                                if (textBoxCoreNumber.Text == "")
                                {
                                    textBoxCoreNumber.Enabled = true;
                                    textBoxCoreNumber.Focus();
                                }
                                else
                                {
                                    if (textBoxOperatorBadgeID.Text == "")
                                    {
                                        textBoxOperatorBadgeID.Enabled = true;
                                        textBoxOperatorBadgeID.Focus();
                                    }
                                    else
                                    {
                                        buttonScan.Focus();
                                    }

                                }

                            }
                        }

                    }
                }
            }
        }

        private void textBoxJobNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxJobNumber.Text == "")
            {

            }
            else
            {   
             string[] job8 = textBoxJobNumber.Text.Trim().Split('/');

             if (!textBoxJobNumber.Text.Contains("/") || job8[0].Length<7)
                {
                     MessageBox.Show ("Invalid Job No");

                
                    textBoxOperatorBadgeID.Enabled = false;
                    textBoxJobNumber.Enabled = true;
                    textBoxCoreNumber.Enabled = false;
                    textBoxTableID.Enabled = false;
                    textBoxJobNumber.Text = "";
                    textBoxJobNumber.Focus();

                }
                else
                {

                    string[] job = textBoxJobNumber.Text.Trim().Split('/');
                    job0passingtoactionpanel = job[0].Trim();
                    job1passingtoactionpanel = job[1].TrimStart(new Char[] { 'O' });
                
                    if (textBoxCoreNumber.Text == "")
                    {
                        textBoxCoreNumber.Enabled = true;
                        textBoxCoreNumber.Focus();


                        textBoxJobNumber.Enabled = false;

                        textBoxOperatorBadgeID.Enabled = false;

                        textBoxTableID.Enabled = false;


                    }
                    else
                    {
                        buttonScan.Focus();
                    }
                }
            }
        }

        private void textBoxCoreNumber_TextChanged(object sender, EventArgs e)
        {
          
            if (textBoxCoreNumber.Text == "")
            {

            }
            else
            {

                string[] core8 = textBoxCoreNumber.Text.Trim().Split('/');
                if (!textBoxCoreNumber.Text.Contains("/") || core8[0].Length >3)
                {
            
                    MessageBox.Show ("Invalid Core No");

               

                    textBoxOperatorBadgeID.Enabled = false;

                    textBoxJobNumber.Enabled = false;
                    textBoxCoreNumber.Enabled = true;
                    textBoxTableID.Enabled = false;
                    textBoxCoreNumber.Text = "";
                    textBoxCoreNumber.Focus();

                }

                else
                {
              //table i8d automaticallly show in table text box if job and item exist


                   
                    string[] core = textBoxCoreNumber.Text.Trim().Split('/');
                    core0passingtoactionpanel = core[0].Trim();
                    core1passingtoactionpanel = core[1].TrimStart(new Char[] { 'O' }); 



                    if (textBoxOperatorBadgeID.Text == "")
                    {


                        textBoxTableID.Enabled = false;
                        textBoxJobNumber.Enabled = false;
                        textBoxCoreNumber.Enabled = false;
                        textBoxOperatorBadgeID.Enabled = true;
                        textBoxOperatorBadgeID.Focus();


                    }
                    else
                    {
                        buttonScan.Focus();
                    }

                  
                }
            }
        }

        private void textBoxTableID_TextChanged(object sender, EventArgs e)
        {


          
            
            if (textBoxTableID.Text == "")
            {

            }
            else
            {
          
                if (textBoxTableID.Text.Contains("/") || textBoxTableID.Text.Contains("-"))
                {
            
                      MessageBox.Show ("Invalid Table ID");

                  


                    textBoxOperatorBadgeID.Enabled = false;

                    textBoxJobNumber.Enabled = false;
                    textBoxCoreNumber.Enabled = false;
                    textBoxTableID.Enabled = true;

                    textBoxTableID.Text = "";
                    textBoxTableID.Focus();

                }
                else
                {
                    textBoxTableID.Enabled = false;

                    string connetionString = null;
                    SqlConnection cnn;
                    connetionString = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                    cnn = new SqlConnection(connetionString);
                    cnn.Open();

                    SqlCommand cmd;
                    SqlDataReader datareader;
                    string sql;

                    //select customer number and core description


                    string jobNumberFromEquipmentScrum = "";
                    string ItemNumberFromEquipmentScrum = "";
                    string CoreNumberFromEquipmentScrum = "";
                    string CoreTotalFromEquipmentScrum = "";
                  
                    sql = "SELECT Job,Item,Core,CoreTotal from Equipment_Scrum where [Equipment No_]='" + textBoxTableID.Text + "' ";
              
                    if (sql != null && sql != "")    // This Table is already running - We get the project details
                    {

                        cmd = new SqlCommand(sql, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                             jobNumberFromEquipmentScrum = datareader.GetValue(0).ToString();
                             ItemNumberFromEquipmentScrum = datareader.GetValue(1).ToString();
                             CoreNumberFromEquipmentScrum = datareader.GetValue(2).ToString();
                             CoreTotalFromEquipmentScrum = datareader.GetValue(3).ToString();
                        }
                      
                        datareader.Close();
                        cmd.Dispose();

                        if (jobNumberFromEquipmentScrum.ToString() != "" && ItemNumberFromEquipmentScrum.ToString() != "" && CoreNumberFromEquipmentScrum.ToString() != "" && CoreTotalFromEquipmentScrum.ToString() != "")
                        {
                            textBoxJobNumber.Enabled = true;
                            textBoxJobNumber.Text = jobNumberFromEquipmentScrum + "/" + ItemNumberFromEquipmentScrum;
                            textBoxJobNumber.Enabled = false;

                            textBoxCoreNumber.Enabled = true;
                            textBoxCoreNumber.Text = CoreNumberFromEquipmentScrum + "/" + CoreTotalFromEquipmentScrum;
                            textBoxCoreNumber.Enabled = false;


                            // focusing to badge id

                            textBoxOperatorBadgeID.Enabled = true;
                            textBoxOperatorBadgeID.Focus();


                         


                        }
                        else
                        {
                            if (textBoxJobNumber.Text == "")
                            {
                                textBoxJobNumber.Enabled = true;
                                textBoxJobNumber.Focus();
                            }
                            else
                            {
                                buttonScan.Focus();
                            }
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("No Data");
                      
                    }



                    cnn.Close();

                    
                }
            }
        }
        
        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (textBoxTableID.Text == "")
            {
                textBoxTableID.Enabled = true;
                textBoxTableID.Focus();
            }
            else
            {
                if (textBoxJobNumber.Text == "")
                {
                    textBoxJobNumber.Enabled = true;
                    textBoxJobNumber.Focus();

                }
                else
                {
                    if (textBoxCoreNumber.Text == "")
                    {
                        textBoxCoreNumber.Enabled = true;
                        textBoxCoreNumber.Focus();
                    }
                    else
                    {
                        if (textBoxOperatorBadgeID.Text == "")
                        {
                            textBoxOperatorBadgeID.Enabled = true;
                            textBoxOperatorBadgeID.Focus();
                        }
                        else
                        {
                            buttonScan.Focus();
                        }

                    }

                }
            }
        }
         private void buttonStart_Click(object sender, EventArgs e)
        {   
            try
            {


                string[] job = textBoxJobNumber.Text.Trim().Split('/');
                string[] core = textBoxCoreNumber.Text.Trim().Split('/');
                job0passingtoactionpanel = job[0].Trim();
                job1passingtoactionpanel = job[1].TrimStart(new Char[] { 'O' });
                core0passingtoactionpanel = core[0].Trim();
                core1passingtoactionpanel = core[1].TrimStart(new Char[] { 'O' }); 


            

                string MaxofWorkinProgress = jobTimeTrackerService.Selectmaxofworkinprogressnumber(); // max id of work in progress

                int mxnumber = int.Parse(MaxofWorkinProgress) + 1; //max id incrementing

              


                string maxofTimeEployeenumber = jobTimeTrackerService.SelectmaxoftimeEmployee();  //max id of time employee
                int mxnumberTimeEmployee = int.Parse(maxofTimeEployeenumber) + 1; // maxi id of time employee increment




                string NoofRecordsinWorkinPRogressTocheckInsertionofScrumTable = jobTimeTrackerService.SelectNoofWorkinProgress(job0passingtoactionpanel, job1passingtoactionpanel, textBoxOperatorBadgeID.Text, core0passingtoactionpanel, core1passingtoactionpanel, phase);//for inserting data first time in scrum table.All other times will updation. Select data fromwork in progress where job item core


                string numberofWorkinProgress_Doing = jobTimeTrackerService.SelectNofRowsinWorkinProgressToupdateDoinginScrumTable(job0passingtoactionpanel, job1passingtoactionpanel, textBoxOperatorBadgeID.Text, core0passingtoactionpanel, core1passingtoactionpanel, phase);

                string numberofWorkinProgress_Done = jobTimeTrackerService.SelectNofRowsinWorkinProgressToupdateDoneinScrumTable(job0passingtoactionpanel, job1passingtoactionpanel, textBoxOperatorBadgeID.Text, core0passingtoactionpanel, core1passingtoactionpanel, phase);
      
            
                string numberofWorkinProgress_Todo = (int.Parse(core1passingtoactionpanel) - (int.Parse(numberofWorkinProgress_Doing) + int.Parse(numberofWorkinProgress_Done))).ToString();                                       //(TotalCore-(doing+done))


           

                

               // ***************Below Code for Selecting Customer Name and Customer Description From BRETLI_GROUP_ME DataBase***********************




                try
                {
                 

                    string connetionString = null;
                    SqlConnection cnn ;
                    connetionString = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=bertelli_group_ME";
                    cnn = new SqlConnection(connetionString);
                    cnn.Open();
                   
                    SqlCommand cmd;
                    SqlDataReader datareader;
                    string sql, sql1, sql2, sql3,sql4;

                    //select customer number and core description


                    sql = "SELECT [Sell-to Customer No_],[Description],[No_] from [LTC ME$Sales Line] where [Document No_]='" + job0passingtoactionpanel + "' and Posizione='" + job1passingtoactionpanel + "' ";
                    if (sql != null && sql != "")
                    {

                        cmd = new SqlCommand(sql, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            customer_Number = datareader.GetValue(0).ToString();
                            Core_Description = datareader.GetValue(1).ToString();
                            Number_Passing_To_ItemTbl_For_getting_weight = datareader.GetValue(2).ToString(); 
                        }

                        datareader.Close();
                        cmd.Dispose();


                    }
                     //select customer name using customer number
                    sql1 = "SELECT [Name] from [LTC ME$Customer] where [No_]='" + customer_Number + "'";
                    if (sql1 != null && sql1 != "")
                    {

                        cmd = new SqlCommand(sql1, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            customer_Description = datareader.GetValue(0).ToString();

                        }

                        datareader.Close();
                        cmd.Dispose();


                    }


                    /*
                     * 
                     * 
                     * 
                     * ====================Below code is for getting weight
                     * 
                     * 
                     * 
                     * */


                    sql2 = "SELECT [Production BOM No_],[Product Group Code] from [LTC ME$Item] where [No_]='" + Number_Passing_To_ItemTbl_For_getting_weight + "'";

                    if (sql2 != null && sql2 != "")
                    {

                        cmd = new SqlCommand(sql2, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            production_BOM_Number = datareader.GetValue(0).ToString();
                            Product_Group_Code = datareader.GetValue(1).ToString();
                        }
                        
                        datareader.Close();
                        cmd.Dispose();


                    }

                    sql3 = "SELECT [Quantity per] from [LTC ME$Production BOM Line] where [No_] LIKE '08%' and [Production BOM No_] ='" + production_BOM_Number + "'";
                    if (sql3 != null && sql3 != "")
                    {

                        cmd = new SqlCommand(sql3, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            weight_sending_TO_Database = datareader.GetValue(0).ToString();

                        }

                        datareader.Close();
                        cmd.Dispose();


                    }



                    //thickness

                    sql4 = "SELECT [Thickness] from [LTC ME$Product Group] where Code='" + Product_Group_Code + "' and [Item Category Code] LIKE '09%'";
                    if (sql4 != null && sql4 != "")
                    {

                        cmd = new SqlCommand(sql4, cnn);
                        datareader = cmd.ExecuteReader();
                        while (datareader.Read())
                        {
                            thickness_Sending_toDATABASE = datareader.GetValue(0).ToString();

                        }

                        datareader.Close();
                        cmd.Dispose();


                    }
                  


                    cnn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }




                //  Below code for fetching DepartmentCode

                String Department_Code = jobTimeTrackerService.SelectDetails_Department_Code(textBoxTableID.Text);

                    //inserting to database
                string Start_Normal_Or_Repaire = phase.ToString();


                if (weight_sending_TO_Database == "" || production_BOM_Number=="")  //weight not added
                {
                    MessageBox.Show("Contact IT Department");
                }
                else
                {




                    string dbOperationResult = jobTimeTrackerService.InsertJob(textBoxTableID.Text, textBoxOperatorBadgeID.Text, job0passingtoactionpanel, job1passingtoactionpanel, core0passingtoactionpanel, core1passingtoactionpanel, phase, mxnumber.ToString(), mxnumberTimeEmployee.ToString(), numberofWorkinProgress_Todo, numberofWorkinProgress_Doing, numberofWorkinProgress_Done, NoofRecordsinWorkinPRogressTocheckInsertionofScrumTable, Department_Code, Start_Normal_Or_Repaire, customer_Number, customer_Description, Core_Description, weight_sending_TO_Database.ToString(), thickness_Sending_toDATABASE.ToString());

                    if (dbOperationResult == "1")
                    {


                        if (lblTeam.Text.Contains(","))
                        {

                            string s = lblTeam.Text; 
                            string[] values = s.Split(','); 
                            for (int i = 0; i < values.Length; i++)
                            {
                                string constr;
                                SqlConnection conn;
                                constr = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                                conn = new SqlConnection(constr);
                                conn.Open();
                                SqlCommand cmd;
                                SqlDataAdapter adap = new SqlDataAdapter();
                                string sql = "";

                                sql = "INSERT INTO Time_Employee(PK_Time_Employee, FK_WorkInProgress_No_, ID_employee, Time_Start, Time_End)VALUES('" + mxnumberTimeEmployee.ToString() + "','" + mxnumber.ToString() + "','" + values[i].Trim().ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','')";
                                cmd = new SqlCommand(sql, conn);
                                adap.InsertCommand = new SqlCommand(sql, conn);
                                adap.InsertCommand.ExecuteNonQuery();
                                cmd.Dispose();
                                conn.Close();
                            } 

                          
                        }
                        else
                        {
                            string constr;
                            SqlConnection conn;
                            constr = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                            conn = new SqlConnection(constr);
                            conn.Open();
                            SqlCommand cmd;
                            SqlDataAdapter adap = new SqlDataAdapter();
                            string sql = "";

                            sql = "INSERT INTO Time_Employee(PK_Time_Employee, FK_WorkInProgress_No_, ID_employee, Time_Start, Time_End)VALUES('" + mxnumberTimeEmployee.ToString() + "','" + mxnumber.ToString() + "','" + textBoxOperatorBadgeID.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','')";
                            cmd = new SqlCommand(sql, conn);
                            adap.InsertCommand = new SqlCommand(sql, conn);
                            adap.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                            conn.Close();
                        }


                     



                           //Process p = new Process();
                           //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                           //p.Start();
                           //Application.Exit();


                       textBoxOperatorBadgeID.Text = "";
                       textBoxJobNumber.Text = "";
                       textBoxCoreNumber.Text = "";
                       textBoxTableID.Text = "";

                       buttonStart.Visible = false;
                       buttonEnd.Visible = false;
                       btnEndMyJob.Visible = false;
                       btnStartMyJob.Visible = false;




                       buttonScan.Visible = true;
                       buttonScan.Enabled = true;

                       textBoxOperatorBadgeID.Enabled = false;
                       textBoxJobNumber.Enabled = false;
                       textBoxCoreNumber.Enabled = false;
                       textBoxTableID.Enabled = true;
                     //  textBoxOperatorBadgeID.Focus();
                       txtBoxAddAllOperators.Text = "";



                       //Refresh Global Variables
                       //jobNumberFromEquipmentScrum = "";
                       //ItemNumberFromEquipmentScrum = "";
                       //CoreNumberFromEquipmentScrum = "";
                       //CoreTotalFromEquipmentScrum = "";


                       job0passingtoactionpanel = "";
                       job1passingtoactionpanel = "";
                       core0passingtoactionpanel = "";
                       core1passingtoactionpanel = "";


                       //IdEmployeeFromTimeEmployee = "";
                       //TimeStartFromTimeEmployee = "";




                       //============refresh============//

                       buttonEnd.Size = new Size(180, 62);
                       buttonEnd.Location = new Point(124, 171);

                       buttonBack.Visible = true;
                       buttonBack.Size = new Size(108, 62);
                       buttonBack.Location = new Point(10, 171);


                       btnEndMyJob.Size = new Size(180, 62);
                       btnEndMyJob.Location = new Point(124, 171);


                       //============FOCUS================//

                       if (textBoxTableID.Text == "")
                       {
                           textBoxTableID.Enabled = true;
                           textBoxTableID.Focus();
                       }
                       else
                       {
                           if (textBoxJobNumber.Text == "")
                           {
                               textBoxJobNumber.Enabled = true;
                               textBoxJobNumber.Focus();

                           }
                           else
                           {
                               if (textBoxCoreNumber.Text == "")
                               {
                                   textBoxCoreNumber.Enabled = true;
                                   textBoxCoreNumber.Focus();
                               }
                               else
                               {
                                   if (textBoxOperatorBadgeID.Text == "")
                                   {
                                       textBoxOperatorBadgeID.Enabled = true;
                                       textBoxOperatorBadgeID.Focus();
                                   }
                                   else
                                   {
                                       buttonScan.Focus();
                                   }

                               }

                           }
                       }


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
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception : " + exception.Message);
            }
        }


        private void buttonEnd_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogresult = MessageBox.Show("Project Finished?", "End Project ?", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if (dialogresult == DialogResult.Yes)
                
                {


                    string DoingPassing = jobTimeTrackerService.SelectNofRowsinWorkinProgressToupdateDoinginScrumTable(job0passingtoactionpanel, job1passingtoactionpanel, textBoxOperatorBadgeID.Text, core0passingtoactionpanel, core1passingtoactionpanel, phase);

                    string Donepassing = jobTimeTrackerService.SelectNofRowsinWorkinProgressToupdateDoneinScrumTable(job0passingtoactionpanel, job1passingtoactionpanel, textBoxOperatorBadgeID.Text, core0passingtoactionpanel, core1passingtoactionpanel, phase);

                    //if (buttonEnd.Text == "END")

                    //{


                    /*
                     *   update cheyyumbool payeee date nte kooode onn kooottanam ennaaleee current logic aavollu adhoondaan
                     *   
                     * thaazhe +1 and -1 okeee kodthadh
                     * 
                     * */


                    int DoingPassingforupdation = int.Parse(DoingPassing) - 1;
                    int DonepassingfoUpdation = int.Parse(Donepassing) + 1;
                    int todopassingfoUpdation = int.Parse(core1passingtoactionpanel) - (DoingPassingforupdation + DonepassingfoUpdation);

                    // string todopassing = (int.Parse(core1passingtoactionpanel) - ((int.Parse(DoingPassing.ToString())-1) +( int.Parse(Donepassing.ToString())+1)).ToString());                                       //(TotalCore-(doing+done))




                    string dbOperationResult = jobTimeTrackerService.UpdateJob(textBoxTableID.Text, textBoxOperatorBadgeID.Text, job0passingtoactionpanel, job1passingtoactionpanel, core0passingtoactionpanel, phase, todopassingfoUpdation.ToString(), DoingPassingforupdation.ToString(), DonepassingfoUpdation.ToString(), core1passingtoactionpanel, phase);
                    if (dbOperationResult == "1")
                    {
                        //==========select No of workin progress for this employee====//


                        string connetionString = null;
                        SqlConnection cnn;
                        connetionString = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                        cnn = new SqlConnection(connetionString);
                        cnn.Open();

                        SqlCommand cmd1;
                        SqlDataReader datareader;
                        string sql1 = "";
                        string wrkinprogressnumberofthisEmployees = "";
                        //select customer number and core description
                        sql1 = "SELECT No_ from WorkInProgress where Job='" + job0passingtoactionpanel + "' and Item='" + job1passingtoactionpanel + "' and Core='" + core0passingtoactionpanel + "' and CoreTotal='" + core1passingtoactionpanel + "' ";

                        cmd1 = new SqlCommand(sql1, cnn);
                        datareader = cmd1.ExecuteReader();
                        while (datareader.Read())
                        {
                            wrkinprogressnumberofthisEmployees = datareader.GetValue(0).ToString();

                        }

                        datareader.Close();
                        cmd1.Dispose();
                        cnn.Close();





                        //============Updation Code=================//
                        string constr;
                        SqlConnection conn;
                        constr = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                        conn = new SqlConnection(constr);
                        conn.Open();
                        SqlCommand cmd;
                        SqlDataAdapter adap = new SqlDataAdapter();
                        string sql = "";

                        sql = "UPDATE Time_Employee SET Time_End = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE(FK_WorkInProgress_No_ = '" + wrkinprogressnumberofthisEmployees + "' and Time_End='' )";
                        cmd = new SqlCommand(sql, conn);
                        adap.InsertCommand = new SqlCommand(sql, conn);
                        adap.InsertCommand.ExecuteNonQuery();
                        cmd.Dispose();
                        conn.Close();






                        textBoxOperatorBadgeID.Text = "";
                        textBoxJobNumber.Text = "";
                        textBoxCoreNumber.Text = "";
                        textBoxTableID.Text = "";

                        buttonStart.Visible = false;
                        buttonEnd.Visible = false;
                        btnEndMyJob.Visible = false;
                        btnStartMyJob.Visible = false;




                        buttonScan.Visible = true;
                        buttonScan.Enabled = true;

                        textBoxOperatorBadgeID.Enabled = false;
                        textBoxJobNumber.Enabled = false;
                        textBoxCoreNumber.Enabled = false;
                        textBoxTableID.Enabled = true;
                        // textBoxOperatorBadgeID.Focus();
                        txtBoxAddAllOperators.Text = "";



                        //Refresh Global Variables
                        //jobNumberFromEquipmentScrum = "";
                        //ItemNumberFromEquipmentScrum = "";
                        //CoreNumberFromEquipmentScrum = "";
                        //CoreTotalFromEquipmentScrum = "";

                        job0passingtoactionpanel = "";
                        job1passingtoactionpanel = "";
                        core0passingtoactionpanel = "";
                        core1passingtoactionpanel = "";
                        //IdEmployeeFromTimeEmployee = "";
                        //TimeStartFromTimeEmployee = "";




                        //============refresh============//

                        buttonEnd.Size = new Size(180, 62);
                        buttonEnd.Location = new Point(124, 171);

                        buttonBack.Visible = true;
                        buttonBack.Size = new Size(108, 62);
                        buttonBack.Location = new Point(10, 171);


                        btnEndMyJob.Size = new Size(180, 62);
                        btnEndMyJob.Location = new Point(124, 171);

                        //============FOCUS================//

                        if (textBoxTableID.Text == "")
                        {
                            textBoxTableID.Enabled = true;
                            textBoxTableID.Focus();
                        }
                        else
                        {
                            if (textBoxJobNumber.Text == "")
                            {
                                textBoxJobNumber.Enabled = true;
                                textBoxJobNumber.Focus();

                            }
                            else
                            {
                                if (textBoxCoreNumber.Text == "")
                                {
                                    textBoxCoreNumber.Enabled = true;
                                    textBoxCoreNumber.Focus();
                                }
                                else
                                {
                                    if (textBoxOperatorBadgeID.Text == "")
                                    {
                                        textBoxOperatorBadgeID.Enabled = true;
                                        textBoxOperatorBadgeID.Focus();
                                    }
                                    else
                                    {
                                        buttonScan.Focus();
                                    }

                                }

                            }
                        }

                    }

                    else
                    {
                        MessageBox.Show("Database Error : " + dbOperationResult);
                    }

                    //BUTTON END REPAIR 

                    //} 
                    //else
                    //{


                    //    int DoingPassingforupdation = int.Parse(DoingPassing);
                    //    int DonepassingfoUpdation = int.Parse(Donepassing);
                    //    int todopassingfoUpdation = int.Parse(core1passingtoactionpanel) - (DoingPassingforupdation + DonepassingfoUpdation);

                    //    // string todopassing = (int.Parse(core1passingtoactionpanel) - ((int.Parse(DoingPassing.ToString())-1) +( int.Parse(Donepassing.ToString())+1)).ToString());                                       //(TotalCore-(doing+done))


                    //    string dbOperationResult = jobTimeTrackerService.UpdateJob(textBoxTableID.Text, textBoxOperatorBadgeID.Text, job0passingtoactionpanel, job1passingtoactionpanel, core0passingtoactionpanel, phase, todopassingfoUpdation.ToString(), DoingPassingforupdation.ToString(), DonepassingfoUpdation.ToString(), core1passingtoactionpanel, "REPAIR");
                    //    if (dbOperationResult == "1")
                    //    {
                    //        // MessageBox.Show("Thank You");

                    //        textBoxOperatorBadgeID.Text = "";
                    //        textBoxJobNumber.Text = "";
                    //        textBoxCoreNumber.Text = "";
                    //        textBoxTableID.Text = "";
                    //       // buttonEnd.Text = "END";
                    //        //buttonStart.Text = "START";
                    //        buttonStart.Visible = false;
                    //        buttonEnd.Visible = false;
                    //        buttonScan.Visible = true;
                    //        buttonScan.Enabled = true;
                    //        textBoxOperatorBadgeID.Enabled = true;
                    //        textBoxJobNumber.Enabled = false;
                    //        textBoxCoreNumber.Enabled = false;
                    //        textBoxTableID.Enabled = false;

                    //        textBoxOperatorBadgeID.Focus();
                    //      //  buttonScan.Focus();
                    //        //Home hm = new Home();
                    //        //hm.ShowDialog();
                    //        //this.Close();

                    //        //Refresh Global Variables
                    //        jobNumberFromEquipmentScrum = "";
                    //         ItemNumberFromEquipmentScrum = "";
                    //         CoreNumberFromEquipmentScrum = "";
                    //         CoreTotalFromEquipmentScrum = "";


                    //         IdEmployeeFromTimeEmployee = "";
                    //         TimeStartFromTimeEmployee = "";




                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Database Error : " + dbOperationResult);
                    //    }



                    //}

                }
                else if (dialogresult == DialogResult.No)
                {
                }
               
            }

            catch (Exception exception)
            {
                MessageBox.Show("Exception : " + exception.Message);
            }  
        }
   

        private void buttonStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ControlBox = true;
                this.MinimizeBox = true;



            }
        }

        private void buttonEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ControlBox = true;
                this.MinimizeBox = true;



            }
        }



     

        
        private void buttonScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ControlBox = true;
                this.MinimizeBox = true;



            }
        }

   

    
       
        private void btnEndMyJob_Click(object sender, EventArgs e)
        {

            //================SELECT WORKINPROGRESS NUMBER==================//
            string connetionString1 = null;
            SqlConnection cnn1;
            connetionString1 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
            cnn1 = new SqlConnection(connetionString1);
            cnn1.Open();

            SqlCommand cmd1;
            SqlDataReader datareader1;
            string sql1 = "";
            string wrkinprogressnumberofthisEmployees = "";
            //select customer number and core description
            sql1 = "SELECT No_ from WorkInProgress where Job='" + job0passingtoactionpanel + "' and Item='" + job1passingtoactionpanel + "' and Core='" + core0passingtoactionpanel + "' and CoreTotal='" + core1passingtoactionpanel + "' ";

            cmd1 = new SqlCommand(sql1, cnn1);
            datareader1 = cmd1.ExecuteReader();
            while (datareader1.Read())
            {
                wrkinprogressnumberofthisEmployees = datareader1.GetValue(0).ToString();

            }

            datareader1.Close();
            cmd1.Dispose();
            cnn1.Close();



            //============Updation Code=================//
            string constr;
            SqlConnection conn;
            constr = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
            conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd;
            SqlDataAdapter adap = new SqlDataAdapter();
            string sql = "";
            sql = "UPDATE Time_Employee SET Time_End = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE(FK_WorkInProgress_No_ = '" + wrkinprogressnumberofthisEmployees + "' and Time_End='' and ID_employee='" + textBoxOperatorBadgeID.Text + "' )";
            cmd = new SqlCommand(sql, conn);
            adap.InsertCommand = new SqlCommand(sql, conn);
            adap.InsertCommand.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();




            textBoxOperatorBadgeID.Text = "";
            textBoxJobNumber.Text = "";
            textBoxCoreNumber.Text = "";
            textBoxTableID.Text = "";

            buttonStart.Visible = false;
            buttonEnd.Visible = false;
            btnEndMyJob.Visible = false;
            btnStartMyJob.Visible = false;




            buttonScan.Visible = true;
            buttonScan.Enabled = true;

            textBoxOperatorBadgeID.Enabled = false;
            textBoxJobNumber.Enabled = false;
            textBoxCoreNumber.Enabled = false;
            textBoxTableID.Enabled = true;

           // textBoxOperatorBadgeID.Focus();
            txtBoxAddAllOperators.Text = "";



            //Refresh Global Variables
            //jobNumberFromEquipmentScrum = "";
            //ItemNumberFromEquipmentScrum = "";
            //CoreNumberFromEquipmentScrum = "";
            //CoreTotalFromEquipmentScrum = "";
            job0passingtoactionpanel = "";
            job1passingtoactionpanel = "";
            core0passingtoactionpanel = "";
            core1passingtoactionpanel = "";

            //IdEmployeeFromTimeEmployee = "";
            //TimeStartFromTimeEmployee = "";




            //============refresh============//

            buttonEnd.Size = new Size(180, 62);
            buttonEnd.Location = new Point(124, 171);

            buttonBack.Visible = true;
            buttonBack.Size = new Size(108, 62);
            buttonBack.Location = new Point(10, 171);


            btnEndMyJob.Size = new Size(180, 62);
            btnEndMyJob.Location = new Point(124, 171);

            //============FOCUS================//

            if (textBoxTableID.Text == "")
            {
                textBoxTableID.Enabled = true;
                textBoxTableID.Focus();
            }
            else
            {
                if (textBoxJobNumber.Text == "")
                {
                    textBoxJobNumber.Enabled = true;
                    textBoxJobNumber.Focus();

                }
                else
                {
                    if (textBoxCoreNumber.Text == "")
                    {
                        textBoxCoreNumber.Enabled = true;
                        textBoxCoreNumber.Focus();
                    }
                    else
                    {
                        if (textBoxOperatorBadgeID.Text == "")
                        {
                            textBoxOperatorBadgeID.Enabled = true;
                            textBoxOperatorBadgeID.Focus();
                        }
                        else
                        {
                            buttonScan.Focus();
                        }

                    }

                }
            }



        }

        private void btnStartMyJob_Click(object sender, EventArgs e)
        {

            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand cmd1;
            SqlDataReader datareader;
            string sql1 = "";
            string wrkinprogressnumberofthisEmployees = "";
            //select customer number and core description
            sql1 = "SELECT No_ from WorkInProgress where Job='" + job0passingtoactionpanel + "' and Item='" + job1passingtoactionpanel + "' and Core='" + core0passingtoactionpanel + "' and CoreTotal='" + core1passingtoactionpanel + "' ";

            cmd1 = new SqlCommand(sql1, cnn);
            datareader = cmd1.ExecuteReader();
            while (datareader.Read())
            {
                wrkinprogressnumberofthisEmployees = datareader.GetValue(0).ToString();

            }

            datareader.Close();
            cmd1.Dispose();
            cnn.Close();



            string maxofTimeEployeenumber = jobTimeTrackerService.SelectmaxoftimeEmployee();  //max id of time employee
            int mxnumberTimeEmployee = int.Parse(maxofTimeEployeenumber) + 1; // maxi id of time employee increment

            string constr;
            SqlConnection conn;
            constr = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
            conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd;
            SqlDataAdapter adap = new SqlDataAdapter();
            string sql = "";

            sql = "INSERT INTO Time_Employee(PK_Time_Employee, FK_WorkInProgress_No_, ID_employee, Time_Start, Time_End)VALUES('" + mxnumberTimeEmployee.ToString() + "','" + wrkinprogressnumberofthisEmployees.ToString() + "','" + textBoxOperatorBadgeID.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','')";
            cmd = new SqlCommand(sql, conn);
            adap.InsertCommand = new SqlCommand(sql, conn);
            adap.InsertCommand.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();


            textBoxOperatorBadgeID.Text = "";
            textBoxJobNumber.Text = "";
            textBoxCoreNumber.Text = "";
            textBoxTableID.Text = "";

            buttonStart.Visible = false;
            buttonEnd.Visible = false;
            btnEndMyJob.Visible = false;
            btnStartMyJob.Visible = false;




            buttonScan.Visible = true;
            buttonScan.Enabled = true;

            textBoxOperatorBadgeID.Enabled = false;
            textBoxJobNumber.Enabled = false;
            textBoxCoreNumber.Enabled = false;
            textBoxTableID.Enabled = true;
       
            txtBoxAddAllOperators.Text = "";



            //Refresh Global Variables
            //jobNumberFromEquipmentScrum = "";
            //ItemNumberFromEquipmentScrum = "";
            //CoreNumberFromEquipmentScrum = "";
            //CoreTotalFromEquipmentScrum = "";
            job0passingtoactionpanel = "";
            job1passingtoactionpanel = "";
            core0passingtoactionpanel = "";
            core1passingtoactionpanel = "";

            //IdEmployeeFromTimeEmployee = "";
            //TimeStartFromTimeEmployee = "";




            //============refresh============//

            buttonEnd.Size = new Size(180, 62);
            buttonEnd.Location = new Point(124, 171);

            buttonBack.Visible = true;
            buttonBack.Size = new Size(108, 62);
            buttonBack.Location = new Point(10, 171);


            btnEndMyJob.Size = new Size(180, 62);
            btnEndMyJob.Location = new Point(124, 171);




            //============FOCUS================//

            if (textBoxTableID.Text == "")
            {
                textBoxTableID.Enabled = true;
                textBoxTableID.Focus();
            }
            else
            {
                if (textBoxJobNumber.Text == "")
                {
                    textBoxJobNumber.Enabled = true;
                    textBoxJobNumber.Focus();

                }
                else
                {
                    if (textBoxCoreNumber.Text == "")
                    {
                        textBoxCoreNumber.Enabled = true;
                        textBoxCoreNumber.Focus();
                    }
                    else
                    {
                        if (textBoxOperatorBadgeID.Text == "")
                        {
                            textBoxOperatorBadgeID.Enabled = true;
                            textBoxOperatorBadgeID.Focus();
                        }
                        else
                        {
                            buttonScan.Focus();
                        }

                    }

                }
            }




        }

        private void btnok_Click(object sender, EventArgs e)
        {
            txtBoxAddAllOperators.Text = "";
            PanelPopup.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBoxAddAllOperators.Text = "";
            txtBoxAddAllOperators.Focus();
          
        }

        private void txtBoxAddAllOperators_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxAddAllOperators.Text == "")
            {

            }
            else
            {





                string connetionString3 = null;
                SqlConnection cnn3;
                connetionString3 = @"Data Source=mssql.ae.ltc.local;User ID=AssemblyTrackingSystem;Password=assembly2019;Initial Catalog=TEST_LAVORAZIONEINESSERE";
                cnn3 = new SqlConnection(connetionString3);
                cnn3.Open();
                string sql3;
                SqlCommand cmd3;
                SqlDataReader datareader3;

                string IdEmployeeFromTimeEmployee_NewProject = "";
                string TimeStartFromTimeEmployee_NewPRoject = "";

                sql3 = "SELECT ID_employee,Time_Start from Time_Employee where Time_End='' and ID_employee='" + txtBoxAddAllOperators.Text + "'";

                cmd3 = new SqlCommand(sql3, cnn3);
                datareader3 = cmd3.ExecuteReader();
                while (datareader3.Read())
                {

                    IdEmployeeFromTimeEmployee_NewProject = datareader3.GetValue(0).ToString();
                    TimeStartFromTimeEmployee_NewPRoject = datareader3.GetValue(1).ToString();

                }



                datareader3.Close();
                cmd3.Dispose();
                cnn3.Close();



                if (txtBoxAddAllOperators.Text.Contains("/") || !txtBoxAddAllOperators.Text.Contains("-"))
                {
                    MessageBox.Show("Invalid Badge ID");



                    txtBoxAddAllOperators.Text = "";
                    txtBoxAddAllOperators.Focus();


                }
                else
                {

                    if (IdEmployeeFromTimeEmployee_NewProject.ToString() == "" && TimeStartFromTimeEmployee_NewPRoject.ToString() == "")
                    {

                        if (lblTeam.Text.Contains(txtBoxAddAllOperators.Text))
                        {
                            MessageBox.Show("Already Added");
                            txtBoxAddAllOperators.Text = "";
                            btnok.Focus();
                        }
                        else
                        {

                            lblTeam.Text = txtBoxAddAllOperators.Text.ToString() + "," + lblTeam.Text.ToString();
                            //  txtBoxAddAllOperators.Text = "";
                            btnok.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Badge Id already found in another Project");
                        txtBoxAddAllOperators.Text = "";
                        txtBoxAddAllOperators.Focus();
                    }



                  
                }
            }
        }

        private void txtBoxAddAllOperators_GotFocus(object sender, EventArgs e)
        {

            try
            {
                if (txtBoxAddAllOperators != null)
                {
                    focussedTextBox = txtBoxAddAllOperators;
                    resetBarcode();
                }
                else
                {
                    MessageBox.Show("Please Scan");
                    txtBoxAddAllOperators.Focus();
                }
            }
            catch (Exception ex)
            {
                //ex.ToString();

                //Process p = new Process();
                //p.StartInfo.FileName = @"Program Files\LTCAPP\LTC.exe";
                //p.Start();
                //Application.Exit();
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBoxAddAllOperators_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ControlBox = true;
                this.MinimizeBox = true;



            }
        }

        private void txtBoxAddAllOperators_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PanelPopup_GotFocus(object sender, EventArgs e)
        {
        
        }

        private void scaninalloprators_Click(object sender, EventArgs e)
        {
            txtBoxAddAllOperators.Text = "";
            txtBoxAddAllOperators.Focus();
          
        }

       

        

    }
}