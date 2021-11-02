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
using DentiNovin.BaseClasses;

namespace DentiNovin
{


    public partial class UserAccessForm : MiddleBaseWinForm// BaseForm//
    {
        private User _oUserF;
        public User OUserF
        {
            get
            {
                if (_oUserF == null)
                    _oUserF = new User();
                return _oUserF;
            }
            set { _oUserF = value; }
        }

        private UserAccessBll _fUserAccessBll;
        public UserAccessBll FUserAccessBll
        {
            get
            {
                if (_fUserAccessBll == null)
                    _fUserAccessBll = new UserAccessBll();
                return _fUserAccessBll;
            }
            set
            {
                _fUserAccessBll = value;
            }
        }

        private DataGridViewRow _oRowSelect;
        public DataGridViewRow ORowSelect
        {
            get { return _oRowSelect; }
            set { _oRowSelect = value; }
        }

        private Int32 _oRowSelectid;
        public Int32 ORowSelectID
        {
            get
            {

                return _oRowSelectid;
            }
            set { _oRowSelectid = value; }
        }

        private void UserAccessForm_Load(object sender, EventArgs e)
        {
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            FillGrid();
            System.Data.DataSet ds;
            try
            {
                ds = FillTreeview();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string FormID = ds.Tables[0].Rows[i][1].ToString();
                    string Name = ds.Tables[0].Rows[i][0].ToString();
                    treeView1.Nodes.Add(FormID, Name.Trim());
                }
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1075");
                MessageBox.Show("بروز خطا در بارگزاری لیست فرمها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitialForm(false);
        }

        public UserAccessForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUserName, "نام کاربری را وارد کنید");
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPassword, "کلمه عبور را وارد کنید");
                txtPassword.Focus();
                return;
            }

            SetObject();
            SaveInfo();
            InitialForm(false);
            FillGrid();
        }

        public DataSet FillTreeview()
        {
            System.Data.DataSet ds = new DataSet();
            UserAccessBll aUserAccessBll = new UserAccessBll();
            ds = aUserAccessBll.FillTreeview();
            return ds;
        }

        public void GetFormSelected()
        {
            this.OUserF.LForms = new List<Forms>();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Checked)
                {
                    Forms aForms = new Forms();
                    aForms.FormID = System.Convert.ToInt32(treeView1.Nodes[i].Name);
                    this.OUserF.LForms.Add(aForms);
                }
            }
        }

        public List<Forms> GetUserFormAccsessList()
        {
            List<Forms> Lforms = new List<Forms>();
            UserAccessBll aUserAccessBll = new UserAccessBll();
            try
            {
                Lforms = aUserAccessBll.GetListFormsSelectForUser(OUserF.UserID);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1076");
                MessageBox.Show("بروز خطا در بارگزاری فرمهای قابل دسترسی", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Lforms;
        }

        public override void SetObject()
        {
            OUserF.FullName = txtFullName.Text.Trim();
            OUserF.UserName = txtUserName.Text.Trim();
            OUserF.Password = txtPassword.Text.Trim();
            //OUserF.DateOfRegister = Convert.ToDateTime(fdpDateOfRegister.Text);
            OUserF.DateOfRegister = fdpDateOfRegister.Text.Trim();
            if (chkActive.Checked)
                OUserF.Active = true;
            else
                OUserF.Active = false;

            this.OUserF.LForms = new List<Forms>();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Checked)
                {
                    Forms aForms = new Forms();
                    aForms.FormID = System.Convert.ToInt32(treeView1.Nodes[i].Name);
                    this.OUserF.LForms.Add(aForms);
                }
            }
        }

        public override void SaveInfo()
        {
            FUserAccessBll.OUserB = this.OUserF;
            if (aPageMode == PageMode.Mode_new)
                SaveObject();
            if (aPageMode == PageMode.Mode_edit)
                EditObject();

        }

        public override void SaveObject()
        {
            try
            {
                FUserAccessBll.SaveObject();
                MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1077");
                MessageBox.Show("بروز خطا در ثبت کاربر جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void EditObject()
        {
            try
            {
                FUserAccessBll.EditObject();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1078");
                MessageBox.Show("بروز خطا در ویرایش اطلاعات کاربر مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void FillGrid()
        {
            try
            {
                System.Data.DataSet ds;
                ds = FUserAccessBll.FillgridUser();
                DataColumn aDataColumn = new DataColumn("FaActive");
                ds.Tables[0].Columns.Add(aDataColumn);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if ((bool)ds.Tables[0].Rows[i]["Active"])
                        ds.Tables[0].Rows[i]["FaActive"] = "فعال";
                    else
                        ds.Tables[0].Rows[i]["FaActive"] = "غیر فعال";
                }
                dgvUser.AutoGenerateColumns = false;
                dgvUser.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1079");
                MessageBox.Show("بروز خطا در بارگزاری لیست کاربران", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void InitialForm(bool SetValue)
        {
            string FullName = string.Empty;
            string UserName = string.Empty;
            string Password = string.Empty;
            string RegisterDate = string.Empty;
            string Active = string.Empty;

            if (SetValue)
            {
                FullName = OUserF.FullName;
                UserName = OUserF.UserName;
                Password = OUserF.Password;
                //fdpDateOfRegister.Text = OUserF.DateOfRegister.ToShortDateString();
                fdpDateOfRegister.Text = OUserF.DateOfRegister;
                chkActive.Checked = OUserF.Active;
                aPageMode = PageMode.Mode_edit;
                ShowUserFormsAccsess();
                btnSave.Text = "ویرایش";
                btncancle.Enabled = true;

            }
            else
            {
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    if (treeView1.Nodes[i].Checked)
                        treeView1.Nodes[i].Checked = false;
                }
                this.OUserF = null;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btncancle.Enabled = false;
                fdpDateOfRegister.SelectedDateTime = DateTime.Now;
                chkActive.Checked = false;
            }
            //FormSelected();
            txtFullName.Text = FullName;
            txtUserName.Text = UserName;
            txtPassword.Text = Password;

        }

        public override void GetObjectList()
        {
            throw new NotImplementedException();
        }

        public void ShowUserFormsAccsess()
        {

            for (int j = 0; j < treeView1.Nodes.Count; j++)
            {
                treeView1.Nodes[j].Checked = false;
                for (int i = 0; i < OUserF.LForms.Count; i++)
                {
                    if (treeView1.Nodes[j].Name == OUserF.LForms[i].FormID.ToString())
                    {
                        treeView1.Nodes[j].Checked = true;
                    }
                }
            }
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SetSelectedObject((DataRowView)dgvUser.SelectedRows[0].DataBoundItem);

            InitialForm(true);
        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            OUserF.UserID = (int)selectedDataRow.Row.ItemArray[0];
            OUserF.UserName = selectedDataRow.Row.ItemArray[2].ToString();
            OUserF.Password = selectedDataRow.Row.ItemArray[3].ToString();
            OUserF.FullName = selectedDataRow.Row.ItemArray[1].ToString();
            //OUserF.DateOfRegister = System.Convert.ToDateTime(((System.Data.DataRowView)(dgvUser.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4]);
            OUserF.DateOfRegister = selectedDataRow.Row.ItemArray[5].ToString();
            OUserF.Active = (bool)selectedDataRow.Row.ItemArray[4];
            OUserF.LForms = GetUserFormAccsessList();
        }

        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 5)
                return;
            if (dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value == null)
                return;
            dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = typeof(string);
            if ((bool)dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value)
                dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "فعال";
            else
                dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "غیر فعال";
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("رکورد مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    FUserAccessBll.DeleteObject((int)((DataRowView)dgvUser.SelectedRows[0].DataBoundItem).Row.ItemArray[0]);
                    FillGrid();
                    InitialForm(false);
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1080");
                    MessageBox.Show("بروز خطا در حذف کاربر مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count <= 0)
                return;
            dgvUser_CellDoubleClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void dgvUser_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvUser.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvUser.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }






    }
}
