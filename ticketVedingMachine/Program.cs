﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ticketVedingMachine
{
    internal static class Program
    {
        public static string myConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PaymentMethod());
        }
    }
}
