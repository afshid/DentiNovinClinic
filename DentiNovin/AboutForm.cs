using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DentiNovin
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string product = ((System.Reflection.AssemblyProductAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0])).Product;

            string copyright = ((System.Reflection.AssemblyCopyrightAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0])).Copyright;
            string company = ((System.Reflection.AssemblyCompanyAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0])).Company;


            lblVersion.Text = version;
            lblCopyRight.Text = copyright;
            lblCompany.Text = product;
        }
    }
}
