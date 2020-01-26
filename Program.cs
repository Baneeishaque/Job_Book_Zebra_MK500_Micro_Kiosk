using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new Phase());
        }
    }
}