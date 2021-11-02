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
    public partial class OperationForm : BaseForm
    {
        public OperationForm()
        {
            InitializeComponent();
        }

        bool dragable = false;
        int NewX;
        int NewY;
        int OldX;
        int OldY;
        int count = 0;
        private void OperationForm_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

    //          Rectangle rc = new Rectangle(this.Left - 1, this.Top - 1,
    //this.Size.Width + 1, this.Size.Height + 1);
    //          e.Graphics.DrawRectangle(Pens.Fuchsia, rc); 
        }
        private void OperationForm_MouseDown(object sender, MouseEventArgs e)
        {
            //dragable = true;
            //NewX = e.X;
            //NewY = e.Y;
            //OldX = NewX;
            //OldY = NewY;
        }

        private void OperationForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //Pen myPen = new Pen(Color.Black, 5);
            //// GraphicsPath myPath=new GraphicsPath(
            //NewX = e.X;
            //NewY = e.Y;
            //if (dragable == true)
            //{
            //    //g.Clear(Color.White);
            //    g.DrawLine(myPen, OldX, OldY, NewX, NewY);
            //    OldX = NewX;
            //    OldY = NewY;
            //    count = count + 1;
            //    textBox2.Text = OldX.ToString();
            //    textBox3.Text = OldY.ToString();
            //    textBox4.Text = NewX.ToString();
            //    textBox5.Text = NewY.ToString();
            //    textBox1.Text = count.ToString();
            //    //g.DrawPath(myPen, GraphicsPath
            //    //g.DrawRectangle(myPen, e.X, e.Y, 1, 1);
            //}

        }

        private void OperationForm_MouseUp(object sender, MouseEventArgs e)
        {
            //dragable = false;
            //if (OldX == NewX)
            //{
            //                Graphics g = this.CreateGraphics();
            //Pen myPen = new Pen(Color.Black, 3);
            //g.DrawRectangle(myPen, e.X, e.Y,2,2);
            //}
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bmp);
            Pen myPen = new Pen(Color.Black, 5);
            NewX = e.X;
            NewY = e.Y;
            if (dragable == true)
            {
                //g.Clear(Color.White);
                g.DrawLine(myPen, OldX, OldY, NewX, NewY);
                OldX = NewX;
                OldY = NewY;
            }
            //bmp.Save(pictureBox1.Image);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragable = true;
            NewX = e.X;
            NewY = e.Y;
            OldX = NewX;
            OldY = NewY;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragable = false;
            //if (OldX == NewX)
            //{
            //    Graphics g = this.CreateGraphics();
            //    Pen myPen = new Pen(Color.Black, 3);
            //    g.DrawRectangle(myPen, e.X, e.Y, 2, 2);
            //}
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            object obj = checkedListBox1.SelectedItem;
        }
    }
}
