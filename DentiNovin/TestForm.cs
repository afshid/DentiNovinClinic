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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            PaintGradientColor(Color.Blue, Color.Green, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);

        }

        private void PaintGradientColor(Color color1, Color color2, System.Drawing.Drawing2D.LinearGradientMode mode)
        {
            System.Drawing.Drawing2D.LinearGradientBrush a = new System.Drawing.Drawing2D.LinearGradientBrush(new RectangleF(0, 0, this.Width, this.Height), color1, color2, mode);
            Graphics frmGraphics = this.CreateGraphics();
            frmGraphics.FillRectangle(a, new RectangleF(10, 10, this.Width, this.Height));
            frmGraphics.Dispose();
        }


    }
}
