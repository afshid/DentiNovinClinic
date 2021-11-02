using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using DentiNovin.Common.SerialMaker;
//using DentiNovin.BaseClasses;

namespace DentiNovin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SerialMaker aSerialMaker = new SerialMaker("DentiNovin", Application.StartupPath + "\\RegFile.reg", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\DNSetp.dbf", "976");

            Application.Run(new MainForm(aSerialMaker, aSerialMaker.CheckStatus()));

        }
    }
}
