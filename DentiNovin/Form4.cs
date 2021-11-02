using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentiClinic
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
this.reportViewer1.LocalReport.ReportPath=@"Reports\Report2.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
