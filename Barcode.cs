using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS_Barcode;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    public partial class Barcode : Form
    {
        string currentPhase;

        // Initialize the BarcodeAPI reference.
        API barcodeAPI = new API();
        bool isReaderInitiated;
        EventHandler barcodeReadNotifyHandler = null;

        public Barcode(string passedPhase)
        {
            this.currentPhase = passedPhase;

            InitializeComponent();

            isReaderInitiated = barcodeAPI.InitReader();

            if (!(this.isReaderInitiated))
            {
                // If the reader has not been initialized
                errorOnBarcodeRead("");
            }
            else
            {
                // If the reader has been initialized
                // Start a read operation & attach a handler.
                barcodeAPI.StartRead(false);
                barcodeReadNotifyHandler = new EventHandler(currentBarcodeReadNotifyHandler);
                barcodeAPI.AttachReadNotify(barcodeReadNotifyHandler);
            }
        }

        /// <summary>
        /// Read notification handler.
        /// </summary>
        private void currentBarcodeReadNotifyHandler(object Sender, EventArgs e)
        {
            // Checks if the Invoke method is required because the ReadNotify delegate is called by a different thread
            if (this.InvokeRequired)
            {
                // Executes the ReadNotify delegate on the main thread
                this.Invoke(barcodeReadNotifyHandler, new object[] { Sender, e });
            }
            else
            {
                // Get ReaderData
                Symbol.Barcode.ReaderData TheReaderData = barcodeAPI.Reader.GetNextReaderData();

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
        }

        void errorOnBarcodeRead(string message)
        {
            // Stop the read operation & detach the handler.
            barcodeAPI.StopRead();
            barcodeAPI.DetachReadNotify();
            if (message == "")
            {
                MessageBox.Show("Error Reading Barcode...");
            }
            else
            {
                MessageBox.Show(message);
            }
            Phase phase = new Phase("",currentPhase);
            phase.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Handle data from the reader. Used in the scan mode.
        /// </summary>
        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            Phase phase = new Phase(TheReaderData.Text,currentPhase);
            phase.ShowDialog();
            this.Close();
        }

        private void Barcode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isReaderInitiated)
            {
                barcodeAPI.StopRead();
                barcodeAPI.DetachReadNotify();
                barcodeAPI.TermReader();
            }
        }

    }
}