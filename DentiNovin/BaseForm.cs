using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using System.Runtime.InteropServices;

namespace DentiNovin
{
    public partial class BaseForm : Form
    {
        private int xBefore = 0;
        private int yBefore = 0;
        private int widthBefore = 0;
        private int heightBefore = 0;

        private const int WM_SETREDRAW = 0xB;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //[DllImport("User32.dll", CharSet = CharSet.Auto)]
        //public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //[DllImport("User32.dll")]
        //private static extern IntPtr GetWindowDC(IntPtr hWnd);

        public PageMode aPageMode;
        protected string error = null;
        ////The color and the width of the border.
        //private Color borderColor = Color.GreenYellow;
        //private int borderWidth = 3;
        ////The color and region of the header.
        //private Color headerColor = Color.GreenYellow;
        //private Rectangle headerRect;
        ////The region of the client.
        //private Rectangle clientRect;
        ////The region of the title text.
        //private Rectangle titleRect;
        ////The region of the minimum button.
        //private Rectangle miniBoxRect;
        ////The region of the maximum button.
        //private Rectangle maxBoxRect;
        ////The region of the close button.
        //private Rectangle closeBoxRect;
        ////The states of the three header buttons.
        //private ButtonState miniState;
        //private ButtonState maxState;
        //private ButtonState closeState;
        ////Store the mouse down point to handle moving the form.
        //private int x = 0;
        //private int y = 0;
        ////The height of the header.
        //const int HEADER_HEIGHT = 25;
        ////The size of the header buttons.
        //private Size BUTTON_BOX_SIZE = new Size(15, 15);


        public BaseForm()
        {
            aPageMode = PageMode.Mode_new;
            InitializeComponent();
        }

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    //const int WM_NCPAINT = 0x85;
        //    //if (m.Msg == WM_NCPAINT)
        //    //{
        //    //    IntPtr hdc = GetWindowDC(m.HWnd);
        //    //    if ((int)hdc != 0)
        //    //    {
        //    //        Graphics g = Graphics.FromHdc(hdc);
        //    //        g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 23));
        //    //        g.Flush();
        //    //        ReleaseDC(m.HWnd, hdc);
        //    //    }
        //    //}
        //}

        private void BaseForm_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            xBefore = this.Left;
            yBefore = this.Top;
            heightBefore = this.Height;
            widthBefore = this.Width;
        }

        //private void BaseForm_Paint(object sender, PaintEventArgs e)
        //{
        //    ////Draw the header.
        //    //using (SolidBrush brush = new SolidBrush(borderColor))
        //    //    e.Graphics.FillRectangle(brush, headerRect);

        //    ////Draw the title text
        //    //using (SolidBrush brush = new SolidBrush(this.ForeColor))
        //    //    e.Graphics.DrawString(this.Text, this.Font, brush, titleRect);

        //    ////Draw the header buttons.
        //    //if (this.MinimizeBox)
        //    //    ControlPaint.DrawCaptionButton(e.Graphics, miniBoxRect, CaptionButton.Minimize, miniState);
        //    //if (this.MaximizeBox)
        //    //    ControlPaint.DrawCaptionButton(e.Graphics, maxBoxRect, CaptionButton.Maximize, maxState);
        //    //if (this.MinimizeBox)
        //    //    ControlPaint.DrawCaptionButton(e.Graphics, closeBoxRect, CaptionButton.Close, closeState);
        //    ////Draw the border.
        //    //ControlPaint.DrawBorder(e.Graphics, clientRect, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);

        //}

        private void BaseForm_Resize(object sender, EventArgs e)
        {

            //headerRect = new Rectangle(this.ClientRectangle.Location, new Size(this.ClientRectangle.Width, HEADER_HEIGHT));
            //clientRect = new Rectangle(new Point(this.ClientRectangle.Location.X, this.ClientRectangle.Y + HEADER_HEIGHT), new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - HEADER_HEIGHT));
            //int yOffset = (headerRect.Height + borderWidth - BUTTON_BOX_SIZE.Height) / 2;
            //titleRect = new Rectangle(yOffset, yOffset, this.ClientRectangle.Width - 3 * (BUTTON_BOX_SIZE.Width + 1) - yOffset, BUTTON_BOX_SIZE.Height);
            //miniBoxRect = new Rectangle(this.ClientRectangle.Width - 3 * (BUTTON_BOX_SIZE.Width + 1), yOffset, BUTTON_BOX_SIZE.Width, BUTTON_BOX_SIZE.Height);
            //maxBoxRect = new Rectangle(this.ClientRectangle.Width - 2 * (BUTTON_BOX_SIZE.Width + 1), yOffset, BUTTON_BOX_SIZE.Width, BUTTON_BOX_SIZE.Height);
            //closeBoxRect = new Rectangle(this.ClientRectangle.Width - 1 * (BUTTON_BOX_SIZE.Width + 1), yOffset, BUTTON_BOX_SIZE.Width, BUTTON_BOX_SIZE.Height);
            //this.Invalidate();
            float WidthPerscpective = (float)Width / widthBefore;
            float HeightPerscpective = (float)Height / heightBefore;
            //ResizeAllControls(this, WidthPerscpective, HeightPerscpective);
        }

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            ////Start to move the form.
            //if (titleRect.Contains(e.Location))
            //{
            //    x = e.X;
            //    y = e.Y;
            //}

            ////Check and press the header buttons.
            //Point mousePos = this.PointToClient(Control.MousePosition);
            //if (miniBoxRect.Contains(mousePos))
            //    miniState = ButtonState.Pushed;
            //else if (maxBoxRect.Contains(mousePos))
            //    maxState = ButtonState.Pushed;
            //else if (closeBoxRect.Contains(mousePos))
            //    closeState = ButtonState.Pushed;

        }

        private void BaseForm_MouseMove(object sender, MouseEventArgs e)
        {
            ////Move and refresh.
            //if (x != 0 && y != 0)
            //{
            //    this.Location = new Point(this.Left + e.X - x, this.Top + e.Y - y);
            //    this.Refresh();
            //}
        }

        private void BaseForm_MouseUp(object sender, MouseEventArgs e)
        {
            ////Reset the mouse point.
            //x = 0;
            //y = 0;

            ////Check the button states and modify the window state.
            //if (miniState == ButtonState.Pushed)
            //{
            //    this.WindowState = FormWindowState.Minimized;
            //    miniState = ButtonState.Normal;
            //}
            //else if (maxState == ButtonState.Pushed)
            //{
            //    if (this.WindowState == FormWindowState.Normal)
            //    {
            //        this.WindowState = FormWindowState.Maximized;
            //        maxState = ButtonState.Checked;
            //    }
            //    else
            //    {
            //        this.WindowState = FormWindowState.Normal;
            //        maxState = ButtonState.Normal;
            //    }
            //}
            //else if (closeState == ButtonState.Pushed)
            //    this.Close();
        }

        private void BaseForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (titleRect.Contains(e.Location))
            //{
            //    if (this.WindowState == FormWindowState.Normal)
            //    {
            //        this.WindowState = FormWindowState.Maximized;
            //        maxState = ButtonState.Checked;
            //    }
            //    else
            //    {
            //        this.WindowState = FormWindowState.Normal;
            //        maxState = ButtonState.Normal;
            //    }
            //}
        }

        private void BaseForm_ResizeBegin(object sender, EventArgs e)
        {
            xBefore = this.Left;
            yBefore = this.Top;
            heightBefore = this.Height;
            widthBefore = this.Width;
        }

        private void BaseForm_ResizeEnd(object sender, EventArgs e)
        {
            float WidthPerscpective = (float)Width / widthBefore;
            float HeightPerscpective = (float)Height / heightBefore;
            ResizeAllControls(this, WidthPerscpective, HeightPerscpective);
        }

        private void ResizeAllControls(Control recussiveControl,
              float WidthPerscpective, float HeightPerscpective)
        {
            SuspendLayout();
            foreach (Control control in recussiveControl.Controls)
            {
                if (control.Controls.Count != 0)
                {
                    SendMessage(this.Handle, WM_SETREDRAW, 0, 0);
                    ResizeAllControls(control, WidthPerscpective, HeightPerscpective);
                    SendMessage(this.Handle, WM_SETREDRAW, 1, 0);
                    Invalidate(control.Region);
                    control.Update();
                }
                control.Left = (int)(control.Left * WidthPerscpective);
                control.Top = (int)(control.Top * HeightPerscpective);
                //control.Width = (int)(control.Width * WidthPerscpective);
                //control.Height = (int)(control.Height * HeightPerscpective);
                Invalidate(control.Region);
                control.Update();
            }
            ResumeLayout();
        }


        //*****************************

        //private void  SetObject()
        //{
        //}

        //private void SaveInfo()
        //{

        //}

        //private void SaveObject()
        //{
        //}

        //private void EditObject()
        //{
        //}

        //private void FillGrid()
        //{ 
        //}

        //private void InitialForm(bool SetValue)
        //{ }

        //private void GetObjectList()
        //{
        //}
    }
}
