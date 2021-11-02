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
    public partial class GroupForm : BaseForm
    {

        private Group _oGroup;
        public Group oGroup
        {
            get
            {
                if (_oGroup == null)
                    _oGroup = new Group();
                return _oGroup;
            }
            set { _oGroup = value; }
        }

        private GroupBLL _fGroupBLL;
        public GroupBLL FGroupBLL
        {
            get
            {
                if (_fGroupBLL == null)
                    _fGroupBLL = new GroupBLL();
                return _fGroupBLL;
            }
            set
            {
                _fGroupBLL = value;
            }
        }

        public GroupForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text.Trim() == "")
            {
                errorProvider1.SetError(txtGroupName, "نام شیفت کاری را وارد کنید");
                txtGroupName.Focus();
                return;
            }
            oGroup.Name = txtGroupName.Text;
            oGroup.StartTime = dtpStartTime.Value.TimeOfDay;
            oGroup.EndTime = dtpEndTime.Value.TimeOfDay;
            oGroup.PeriodLength = ((KeyValuePair<string, int>)(cboPeriodLength.SelectedItem)).Value;
            oGroup.StartActiveDate = fdpStartActiveDate.Text;
            this.oGroup = oGroup;
            FGroupBLL.oGroup = this.oGroup;
            try
            {
                if (aPageMode == PageMode.Mode_new)
                {
                    oGroup.GroupCode = 0;
                    oGroup.GroupID = 0;
                    FGroupBLL.InsertNewGroup();
                }
                if (aPageMode == PageMode.Mode_edit)
                    FGroupBLL.UpdateGroup();
                InitialForm(false);
                MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridView();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string errorMessage = string.Empty;
                switch (ex.Message)
                {
                    case "60090":
                        errorMessage = "بدلیل ثبت مراجعه با این شیفت کاری امکان تغییر وجود ندارد";
                        break;
                    case "60080":
                        errorMessage = "نام انتخاب شده تکراریست";
                        break;
                    default:
                        break;
                }
                MessageBox.Show(errorMessage, "بروز خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            this.fdpStartActiveDate.SelectedDateTime = DateTime.Now;
            Dictionary<string, int> DPeriod = new Dictionary<string, int>();
            DPeriod.Add("15'", 15);
            DPeriod.Add("30'", 30);
            DPeriod.Add("45'", 45);
            DPeriod.Add("60'", 60);
            cboPeriodLength.DataSource = new BindingSource(DPeriod, null);
            cboPeriodLength.DisplayMember = "Value";
            cboPeriodLength.ValueMember = "Key";
        }

        private DataSet GetGroupList(Boolean All)
        {
            return FGroupBLL.GetGroupList(All);
        }

        private void FillDataGridView()
        {
            DataSet aDataSet;
            dgvGroup.AutoGenerateColumns = false;
            try
            {
                aDataSet = GetGroupList(false);
                if (aDataSet.Tables.Count < 1)
                    return;
                DataColumn aDataColumn = new DataColumn("RowNumber");
                DataColumn bDataColumn = new DataColumn("StartShortTime");
                DataColumn cDataColumn = new DataColumn("EndShortTime");
                aDataSet.Tables[0].Columns.Add(aDataColumn);
                aDataSet.Tables[0].Columns.Add(bDataColumn);
                aDataSet.Tables[0].Columns.Add(cDataColumn);
                for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                {
                    aDataSet.Tables[0].Rows[i]["RowNumber"] = i + 1;
                    //aDataSet.Tables[0].Rows[i]["EndShortTime"] = System.Convert.ToDateTime(aDataSet.Tables[0].Rows[i]["EndTime"]).TimeOfDay;
                    aDataSet.Tables[0].Rows[i]["StartShortTime"] = new DateTime().Add(TimeSpan.FromTicks((Int64)aDataSet.Tables[0].Rows[i]["StartTime"])).TimeOfDay;
                    aDataSet.Tables[0].Rows[i]["EndShortTime"] = new DateTime().Add(TimeSpan.FromTicks((Int64)aDataSet.Tables[0].Rows[i]["EndTime"])).TimeOfDay;
                }
                dgvGroup.DataSource = aDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1032");
                MessageBox.Show("بروز خطا در بارگزاری لیست شیفتهای کاری", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void InitialForm(bool SetValue)
        {
            string GroupName = string.Empty;
            if (SetValue)
            {
                GroupName = oGroup.Name;
                dtpStartTime.Value = DateTime.Now.Date.Add(oGroup.StartTime);
                dtpEndTime.Value = DateTime.Now.Date.Add(oGroup.EndTime);
                fdpStartActiveDate.Text = oGroup.StartActiveDate;
                cboPeriodLength.SelectedIndex = cboPeriodLength.FindString(oGroup.PeriodLength.ToString());
                btnRegister.Text = "ویرایش";
                btnCancle.Enabled = true;
                aPageMode = PageMode.Mode_edit;
            }
            else
            {
                this.fdpStartActiveDate.SelectedDateTime = DateTime.Now;
                cboPeriodLength.SelectedIndex = 0;
                aPageMode = PageMode.Mode_new;
                btnRegister.Text = "ثبت";
                btnCancle.Enabled = false;
            }
            txtGroupName.Text = GroupName;
        }

        private void dgvGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SetSelectedObject((DataRowView)dgvGroup.SelectedRows[0].DataBoundItem);
            InitialForm(true);
        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            oGroup.GroupID = (int)selectedDataRow.Row.ItemArray[0];
            oGroup.GroupCode = (int)selectedDataRow.Row.ItemArray[1];
            oGroup.Name = selectedDataRow.Row.ItemArray[2].ToString();
            oGroup.StartTime = new DateTime().Add(TimeSpan.FromTicks((Int64)selectedDataRow.Row.ItemArray[3])).TimeOfDay;// System.Convert.ToDateTime(((System.Data.DataRowView)(dgvGroup.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3]).TimeOfDay;
            oGroup.EndTime = new DateTime().Add(TimeSpan.FromTicks((Int64)selectedDataRow.Row.ItemArray[4])).TimeOfDay;  // System.Convert.ToDateTime(((System.Data.DataRowView)(dgvGroup.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4]).TimeOfDay;
            oGroup.StartActiveDate = selectedDataRow.Row.ItemArray[5].ToString();
            oGroup.PeriodLength = Convert.ToInt32(selectedDataRow.Row.ItemArray[7]);
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void dgvGroup_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvGroup.Rows[e.RowIndex].Selected = true;
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count <= 0)
                return;
            dgvGroup_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("رکورد مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    FGroupBLL.DeleteGroup((int)((DataRowView)dgvGroup.SelectedRows[0].DataBoundItem).Row.ItemArray[0]);
                    InitialForm(false);
                    FillDataGridView();
                    MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show("بدلیل وجود نوبت ثبت شده مرتبط با این شیفت کاری امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvGroup.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }
    }
}
