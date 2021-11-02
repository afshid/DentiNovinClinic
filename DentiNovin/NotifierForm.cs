using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentiNovin
{
    public partial class NotifierForm : Form
    {
        public NotifierForm()
        {
            InitializeComponent();
        }

        private void NotifierForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //this.Hide();
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            Left = (SystemInformation.WorkingArea.Size.Width - Size.Width);
            Top = (SystemInformation.WorkingArea.Size.Height - Size.Height);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref m);
        }
    }
}
