using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DentiNovin
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            string curDir = Directory.GetCurrentDirectory();
            //webBrowser1.Navigate(new Uri(String.Format("file:///{0}/DentiNovinTutorials.htm", curDir)));
            webBrowser1.Url = new Uri(String.Format("file:///{0}/DentiNovinTutorials.htm", curDir));
        }
    }
}
