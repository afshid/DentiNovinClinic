using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using DentiNovin.BusinessLogic;
using System.Runtime.InteropServices;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class LoginForm : BaseForm
    {
        const int MF_BYPOSITION = 0x400;

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        private User _oUserF;
        public User OUserF
        {
            get {
                return _oUserF; }
            set { _oUserF = value; }
        }

        public LoginForm()
        {
            InitializeComponent();
        }


        private Login _oLoginf;
        public Login OLoginF
        {
            get { return _oLoginf; }
            set { _oLoginf = value; }
        }
        
        private void btnlog_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUser, "نام کاربر را وارد کنید");
                txtUser.Focus();
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPass, "کلمه عبور را وارد کنید");
                txtPass.Focus();
                return;
            }
            try
            {
                OUserF.UserName = txtUser.Text.Trim();
            OUserF.Password = txtPass.Text.Trim();
            DateTime start = DateTime.Now;
            LoginBLL aLoginBLL = new LoginBLL();
            aLoginBLL.OUserB = this.OUserF;
            aLoginBLL.SearchtUser();
            if (this.OUserF.UserID != 0)
                this.Close();
            lblMessage.Visible = true;
            txtUser.Focus();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1001");
                MessageBox.Show("بروز خطا در دریافت اطلاعات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);

            int menuItemCount = GetMenuItemCount(hMenu);

            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }





    }
}
