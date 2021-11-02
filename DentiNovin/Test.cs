using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.BusinessLogic;

namespace DentiClinic
{
    public partial class Test :BaseForm 
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "123")
            {
                errorProvider1.SetError(textBox3, "whjwhw");
            
            }
            try
            {
                TestBLL atestBLL = new TestBLL();
              textBox2.Text=atestBLL.ttttttttt(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
           
        }
       

        
    }
}
