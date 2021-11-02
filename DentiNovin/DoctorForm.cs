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
using DentiNovin.Properties;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class DoctorForm : MiddleBaseWinForm //BaseWinForm //BaseForm//  
    {
        private DoctorBll _fDoctorBLL;
        public DoctorBll FDoctorBLL
        {
            get
            {
                if (_fDoctorBLL == null)
                    _fDoctorBLL = new DoctorBll();
                return _fDoctorBLL;
            }
            set
            {
                _fDoctorBLL = value;
            }
        }

        private DataTable aDataTable;

        private Doctor _doctorF;
        public Doctor DoctorF
        {
            get
            {
                if (_doctorF == null)
                    _doctorF = new Doctor();
                return _doctorF;
            }
            set { _doctorF = value; }
        }

        //private List<Group> _lGroup;
        //public List<Group> LGroup
        //{
        //    get
        //    {
        //        if (_lGroup == null)
        //            _lGroup = new List<Group>();
        //        return _lGroup;
        //    }
        //    set { _lGroup = value; }
        //}

        private Int32 _oRowSelectid;
        public Int32 ORowSelectID
        {
            get
            {

                return _oRowSelectid;
            }
            set { _oRowSelectid = value; }
        }

        private DataGridViewRow _oRowSelect;

        public DataGridViewRow ORowSelect
        {
            get { return _oRowSelect; }
            set { _oRowSelect = value; }
        }

        private bool _isMedCenter=false;
        private bool _gridRefreshed = false;
        public DoctorForm()
        {
            InitializeComponent();
        }

        private void SetGroupSelected()
        {
            ResetDataTable();
            for (int i = 0; i < DoctorF.LDoctorShift.Count; i++)
            {
                for (int j = 0; j < aDataTable.Rows.Count; j++)
                {
                    if ((int)DoctorF.LDoctorShift[i].SelectedShiftCode == (int)aDataTable.Rows[j][13])
                    {
                        if (DoctorF.LDoctorShift[i].SelectedDays != 0)
                        {
                            aDataTable.Rows[j][8] = DoctorF.LDoctorShift[i].SelectedDays;
                            SetSelectedDays(j, DoctorF.LDoctorShift[i].SelectedDays);
                        }

                    }
                }
            }
            dgvDoctorShifts.DataSource = aDataTable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.aDataTable.Rows.Count == 0)
            {
                if (MessageBox.Show("برای این پزشک شیفت کاری ثبت نشده است .آیا مایلید بدون ثبت شیفت کاری، عملیات ثبت پزشک را ادامه دهید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            if (txtLastName.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtLastName, "نام خانوادگی راوارد کنید");
                txtLastName.Focus();
                return;
            }

            if (txtDocName.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtDocName, "نام را وارد کنید");
                txtDocName.Focus();
                return;
            }

            if (txtCode.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtCode, "شماره نظام پزشکی را وارد کنید");
                txtCode.Focus();
                return;
            }

            if (txtIdentificationCodeKhadamat.Text.Trim() == "" && chkHaveContractWithKhadamat.Enabled && chkHaveContractWithKhadamat.Checked)
            {
                tabControl1.SelectedTab = tabPage3;
                errorProvider1.SetError(txtIdentificationCodeKhadamat, "کد شناسایی بیمه خدمات درمانی را وارد کنید");
                txtIdentificationCodeKhadamat.Focus();
                return;
            }

            if (txtIdentificationCodeMosallah.Text.Trim() == "" && chkHaveContractWithMosallah.Enabled && chkHaveContractWithMosallah.Checked)
            {
                tabControl1.SelectedTab = tabPage3;
                errorProvider1.SetError(txtIdentificationCodeMosallah, "کد شناسایی بیمه نیروهای مسلح را وارد کنید");
                txtIdentificationCodeMosallah.Focus();
                return;
            }

            SetObject();

            try
            {

                SaveInfo();
                MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (aPageMode == PageMode.Mode_new)
                {
                    UtilMethods.LogError(ex, "1028");
                    MessageBox.Show("بروز خطا در ثبت اطلاعات پزشک جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (aPageMode == PageMode.Mode_edit)
                {
                    UtilMethods.LogError(ex, "1029");
                    MessageBox.Show("بروز خطا در ویرایش اطلاعات پزشک مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            InitialForm(false);
            FillGrid();

        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            _isMedCenter = (bool)Settings.Default["IsMedCenter"];
            if (_isMedCenter)
            {
                chkHaveContractWithKhadamat.Enabled = false;
                chkHaveContractWithMosallah.Enabled = false;
            }
            try
            {
                FillDoctorGroup();//set DoctorShiftGrid in form
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1030");
                MessageBox.Show("بروز خطا در بارگزاری شیفتهای کاری پزشک", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cboDoctorKind.SelectedIndex = 0;
            FillGrid();
            txtLastName.Focus();
        }

        private void FillDoctorGroup()
        {
            //DataTable 
            aDataTable = new DataTable();

            for (int i = 0; i < 7; i++)
            {
                DataColumn aDataColumn = new DataColumn(i.ToString());
                aDataTable.Columns.Add(aDataColumn);
            }
            DataColumn bDataColumn = new DataColumn("HeaderText");
            aDataTable.Columns.Add(bDataColumn);

            DataColumn cDataColumn = new DataColumn("SelectedDays", System.Type.GetType("System.Int32"));
            aDataTable.Columns.Add(cDataColumn);

            DataColumn dDataColumn = new DataColumn("ActiveShift", System.Type.GetType("System.Boolean"));
            aDataTable.Columns.Add(dDataColumn);

            DataColumn eDataColumn = new DataColumn("StartTime", System.Type.GetType("System.TimeSpan"));
            aDataTable.Columns.Add(eDataColumn);

            DataColumn fDataColumn = new DataColumn("EndTime", System.Type.GetType("System.TimeSpan"));
            aDataTable.Columns.Add(fDataColumn);

            DataColumn gDataColumn = new DataColumn("ShiftID", System.Type.GetType("System.Int32"));
            aDataTable.Columns.Add(gDataColumn);

            DataColumn hDataColumn = new DataColumn("ShiftCode", System.Type.GetType("System.Int32"));
            aDataTable.Columns.Add(hDataColumn);
            System.Data.DataSet ds;//= new DataSet();
            ds = FDoctorBLL.FillGroupCheckBoxList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow aDataRow = aDataTable.NewRow();
                aDataRow["HeaderText"] = ds.Tables[0].Rows[i][2].ToString();
                aDataRow["SelectedDays"] = 0;
                aDataRow["ActiveShift"] = true;
                aDataRow["StartTime"] = new DateTime().Add(TimeSpan.FromTicks((Int64)ds.Tables[0].Rows[i]["StartTime"])).TimeOfDay;// Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]).TimeOfDay;
                aDataRow["EndTime"] = new DateTime().Add(TimeSpan.FromTicks((Int64)ds.Tables[0].Rows[i]["EndTime"])).TimeOfDay;// Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]).TimeOfDay;
                aDataRow["ShiftID"] = (int)ds.Tables[0].Rows[i][0];
                aDataRow["ShiftCode"] = (int)ds.Tables[0].Rows[i][1];
                aDataTable.Rows.Add(aDataRow);
            }
            dgvDoctorShifts.AutoGenerateColumns = false;
            dgvDoctorShifts.DataSource = aDataTable;

        }

        public List<DoctorShift> GetListGroupSelectForDoc(int doctorID)
        {
            return FDoctorBLL.GetListGroupSelectForDoc(doctorID);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtDocName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void dgvDoctorShifts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (!(bool)aDataTable.Rows[e.RowIndex][9])
            {
                MessageBox.Show("تداخل با یکی از شیفتهای انتخاب شده");
                return;
            }
            if (dgvDoctorShifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "حضور")
            {
                //((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8] = "false";
                dgvDoctorShifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                dgvDoctorShifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.SystemColors.Window;
                aDataTable.Rows[e.RowIndex][8] = CreateSelectedDays(Convert.ToInt32(aDataTable.Rows[e.RowIndex][8]), e.ColumnIndex + 1, false);

            }
            else
            {
                //((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8] = CreateSelectedDays(Convert.ToInt32(((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8]), e.ColumnIndex);
                dgvDoctorShifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "حضور";
                dgvDoctorShifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.SystemColors.Highlight;
                aDataTable.Rows[e.RowIndex][8] = CreateSelectedDays(Convert.ToInt32(aDataTable.Rows[e.RowIndex][8]), e.ColumnIndex + 1, true);
            }

            if ((int)aDataTable.Rows[e.RowIndex][8] != 0)
            {
                for (int i = 0; i < aDataTable.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        if (((TimeSpan)aDataTable.Rows[i][11] < (TimeSpan)((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[10]) || ((TimeSpan)aDataTable.Rows[i][10] > (TimeSpan)((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[11]))
                            aDataTable.Rows[i][9] = aDataTable.Rows[i][9];
                        else
                            aDataTable.Rows[i][9] = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < aDataTable.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        if (((TimeSpan)aDataTable.Rows[i][11] < (TimeSpan)((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[10]) || ((TimeSpan)aDataTable.Rows[i][10] > (TimeSpan)((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[11]))
                            aDataTable.Rows[i][9] = aDataTable.Rows[i][9];
                        else
                            aDataTable.Rows[i][9] = true;
                    }
                }

            }

            //textBox2.Text = aDataTable.Rows[e.RowIndex][8].ToString();

        }

        private int CreateSelectedDays(int currentNumber, int newDigit, bool add)
        {
            int coefficient;
            int sign = -1;
            if (add)
                sign = 1;

            if (currentNumber == -1)
                currentNumber = 0;
            switch (newDigit)
            {
                case 1:
                    coefficient = 1;
                    break;
                case 2:
                    coefficient = 20;
                    break;
                case 3:
                    coefficient = 300;
                    break;
                case 4:
                    coefficient = 4000;
                    break;
                case 5:
                    coefficient = 50000;
                    break;
                case 6:
                    coefficient = 600000;
                    break;
                case 7:
                    coefficient = 7000000;
                    break;
                default:
                    coefficient = 1;
                    break;
            }
            //return (currentNumber + (coefficient * sign) == 0) ? -1 : currentNumber + (coefficient * sign);
            return currentNumber + (coefficient * sign);

        }
        int count = 0;

        private void dgvDoctorShifts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            //int SelectedDays = (int)((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8];
            //if (SelectedDays != 0)
            //{
            //    if (SelectedDays % 10 == 1)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[0].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //    if (SelectedDays % 100 >= 20)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[1].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[1].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //    if (SelectedDays % 1000 >= 300)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[2].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[2].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //    if (SelectedDays % 10000 >= 4000)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[3].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[3].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //    if (SelectedDays % 100000 >= 50000)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[4].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[4].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //    if (SelectedDays % 1000000 >= 600000)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[5].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[5].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //    if (SelectedDays % 10000000 >= 7000000)
            //    {
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[6].Value = "حضور";
            //        dgvDoctorShifts.Rows[e.RowIndex].Cells[6].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //}
        }

        private void dgvDoctorShifts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvDoctorShifts.Rows[e.RowIndex].HeaderCell.Value = ((System.Data.DataRowView)(dgvDoctorShifts.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7].ToString();
        }

        private void SetSelectedDays(int DataRowNumber, int SelectedDays)
        {
            if (SelectedDays % 10 == 1)
            {
                aDataTable.Rows[DataRowNumber][0] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
            if (SelectedDays % 100 >= 20)
            {
                aDataTable.Rows[DataRowNumber][1] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[1].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
            if (SelectedDays % 1000 >= 300)
            {
                aDataTable.Rows[DataRowNumber][2] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[2].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
            if (SelectedDays % 10000 >= 4000)
            {
                aDataTable.Rows[DataRowNumber][3] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[3].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
            if (SelectedDays % 100000 >= 50000)
            {
                aDataTable.Rows[DataRowNumber][4] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[4].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
            if (SelectedDays % 1000000 >= 600000)
            {
                aDataTable.Rows[DataRowNumber][5] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[5].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
            if (SelectedDays % 10000000 >= 7000000)
            {
                aDataTable.Rows[DataRowNumber][6] = "حضور";
                dgvDoctorShifts.Rows[DataRowNumber].Cells[6].Style.BackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void ResetDataTable()
        {
            for (int i = 0; i < aDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    aDataTable.Rows[i][j] = "";
                    dgvDoctorShifts.Rows[i].Cells[j].Style.BackColor = System.Drawing.SystemColors.Window;
                }
                aDataTable.Rows[i][8] = 0;
            }
        }

        public override void SetObject()
        {
            //DoctorF.DoctorID = ORowSelectID;
            DoctorF.Docname = txtDocName.Text;
            DoctorF.LastName = txtLastName.Text;
            DoctorF.Code = txtCode.Text;
            DoctorF.PhoneNumber = txtPhoneNumber.Text;
            DoctorF.CellPhoneNumber = txtCellPhoneNumber.Text;
            DoctorF.Address = txtAddress.Text;
            DoctorF.Active = chkActive.Checked;
            DoctorF.VisitPrice = 0;
            DoctorF.IdentificationCodeKhadamat = txtIdentificationCodeKhadamat.Text;
            DoctorF.IdentificationCodeMosallah = txtIdentificationCodeMosallah.Text;
            DoctorF.HaveContractWithKhadamat = chkHaveContractWithKhadamat.Checked;
            DoctorF.HaveContractWithMosallah = chkHaveContractWithMosallah.Checked;
            DoctorF.DoctorKind =(Int16) cboDoctorKind.SelectedIndex;
            DoctorF.LDoctorShift.Clear();
            for (int i = 0; i < aDataTable.Rows.Count; i++)
            {
                if ((bool)aDataTable.Rows[i][9] == true && (int)aDataTable.Rows[i][8] != 0)
                {
                    DoctorShift aDoctorShift = new DoctorShift();
                    aDoctorShift.SelectedShiftCode = (int)aDataTable.Rows[i][13];
                    aDoctorShift.SelectedDays = (int)aDataTable.Rows[i][8];
                    DoctorF.LDoctorShift.Add(aDoctorShift);
                }
            }
        }

        public override void SaveInfo()
        {
            FDoctorBLL.DoctorB = this.DoctorF;
            if (aPageMode == PageMode.Mode_new)
            {
                SaveObject();
                this.DoctorF.LDoctorShift.Clear();
            }

            if (aPageMode == PageMode.Mode_edit)

                EditObject();
        }

        public override void SaveObject()
        {
            FDoctorBLL.SaveObject();
        }

        public override void EditObject()
        {
            FDoctorBLL.EditObject();
        }

        public override void FillGrid()
        {
            System.Data.DataSet ds;//= new DataSet();
            dgvDoctor.AutoGenerateColumns = false;
            try
            {
                ds = FDoctorBLL.GetDoctorList(false);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1031");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DataColumn aDataColumn = new DataColumn("RowNumber");
            ds.Tables[0].Columns.Add(aDataColumn);
            DataColumn bDataColumn = new DataColumn("FaActive");
            ds.Tables[0].Columns.Add(bDataColumn);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["RowNumber"] = i + 1;
                if ((bool)ds.Tables[0].Rows[i]["Active"])
                    ds.Tables[0].Rows[i]["FaActive"] = "فعال";
                else
                    ds.Tables[0].Rows[i]["FaActive"] = "غیر فعال";
            }
            dgvDoctor.DataSource = ds.Tables[0];
        }

        public override void GetObjectList()
        {
            throw new NotImplementedException();
        }

        public override void InitialForm(bool SetValue)
        {
            string DocName = string.Empty;
            string LastName = string.Empty;
            string Code = string.Empty;
            string PhoneNumber = string.Empty;
            string cellPhoneNumber = string.Empty;
            string Address = string.Empty;
            bool Active = true;
            string VisitPrice = "0";
            string IdentificationCodeKhadamat = string.Empty;
            string IdentificationCodeMosallah = string.Empty;
            bool HaveContractWithKhadamat = false;
            bool HaveContractWithMosallah = false;
            Int16 doctorKind = 0;



            if (SetValue)
            {
                DocName = DoctorF.Docname;
                LastName = DoctorF.LastName;
                Code = DoctorF.Code;
                PhoneNumber = DoctorF.PhoneNumber;
                cellPhoneNumber = DoctorF.CellPhoneNumber;
                Address = DoctorF.Address;
                Active = DoctorF.Active;
                VisitPrice = DoctorF.VisitPrice.ToString();
                IdentificationCodeKhadamat = DoctorF.IdentificationCodeKhadamat;
                IdentificationCodeMosallah = DoctorF.IdentificationCodeMosallah;
                HaveContractWithKhadamat = DoctorF.HaveContractWithKhadamat;
                HaveContractWithMosallah = DoctorF.HaveContractWithMosallah;
                doctorKind = DoctorF.DoctorKind;
                aPageMode = PageMode.Mode_edit;
                btnSave.Text = "ویرایش";
                btnCancle.Enabled = true;
            }
            else
            {
                this.DoctorF = null;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancle.Enabled = false;
            }


            SetGroupSelected();
            txtDocName.Text = DocName;
            txtLastName.Text = LastName;
            txtCode.Text = Code;
            txtPhoneNumber.Text = PhoneNumber;
            txtCellPhoneNumber.Text = cellPhoneNumber;
            txtAddress.Text = Address;
            chkActive.Checked = Active;
            //chkIsIndependent.Checked = isIndependent;
            cboDoctorKind.SelectedIndex = doctorKind;
            txtIdentificationCodeKhadamat.Text = IdentificationCodeKhadamat;
            txtIdentificationCodeMosallah.Text = IdentificationCodeMosallah;
            chkHaveContractWithKhadamat.Checked = HaveContractWithKhadamat;
            chkHaveContractWithMosallah.Checked = HaveContractWithMosallah;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && !_gridRefreshed)
            {
                _gridRefreshed = true;
                SetGroupSelected();
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvDoctor.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("پزشک مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    FDoctorBLL.DeleteObject((int)((DataRowView)dgvDoctor.SelectedRows[0].DataBoundItem).Row.ItemArray[0]);
                    FillGrid();
                    InitialForm(false);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show("بدلیل وجود نوبت ثبت شده مرتبط با این پزشک امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvDoctor_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvDoctor.Rows[e.RowIndex].Selected = true;
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvDoctor.SelectedRows.Count <= 0)
                return;
            dgvDoctor_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void dgvDoctor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetSelectedObject((DataRowView)dgvDoctor.SelectedRows[0].DataBoundItem);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1033");
                MessageBox.Show(" بروز خطا در دریافت اطلاعات پزشک مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitialForm(true);
            dgvDoctorShifts.Refresh();
        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {

            DoctorF.DoctorID = (int)selectedDataRow.Row.ItemArray[0];
            DoctorF.Docname = selectedDataRow.Row.ItemArray[1].ToString();
            DoctorF.LastName = selectedDataRow.Row.ItemArray[2].ToString();
            DoctorF.PhoneNumber = selectedDataRow.Row.ItemArray[4].ToString();
            DoctorF.Code = selectedDataRow.Row.ItemArray[3].ToString();
            DoctorF.Address = selectedDataRow.Row.ItemArray[5].ToString();
            DoctorF.Active = (bool)selectedDataRow.Row.ItemArray[6];
            DoctorF.VisitPrice = (decimal)selectedDataRow.Row.ItemArray[7];
            DoctorF.IdentificationCodeKhadamat = selectedDataRow.Row.ItemArray[8].ToString();
            DoctorF.IdentificationCodeMosallah = selectedDataRow.Row.ItemArray[9].ToString();
            DoctorF.DoctorKind = (Int16)selectedDataRow.Row.ItemArray[12];
            //var cellValue = Convert.IsDBNull(value) ? 0 : Convert.ToDecimal(value);
            DoctorF.HaveContractWithKhadamat = Convert.IsDBNull(selectedDataRow.Row.ItemArray[10])?false:(bool)selectedDataRow.Row.ItemArray[10];
            DoctorF.HaveContractWithMosallah = Convert.IsDBNull(selectedDataRow.Row.ItemArray[11]) ? false : (bool)selectedDataRow.Row.ItemArray[11];
            DoctorF.CellPhoneNumber = selectedDataRow.Row.ItemArray[13].ToString();
            DoctorF.LDoctorShift = GetListGroupSelectForDoc(DoctorF.DoctorID);


        }

        private void dgvDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvDoctor.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }

        private void chkHaveContractWithKhadamat_CheckedChanged(object sender, EventArgs e)
        {
            
                txtIdentificationCodeKhadamat.Enabled = chkHaveContractWithKhadamat.Checked;
                if (chkHaveContractWithKhadamat.Checked)
                    txtIdentificationCodeKhadamat.Focus();
        }

        private void chkHaveContractWithMosallah_CheckedChanged(object sender, EventArgs e)
        {
                txtIdentificationCodeMosallah.Enabled = chkHaveContractWithMosallah.Checked;
                if (chkHaveContractWithMosallah.Checked)
                    txtIdentificationCodeMosallah.Focus();
        }

        private void chkHaveContractWithKhadamat_EnabledChanged(object sender, EventArgs e)
        {
            txtIdentificationCodeKhadamat.Enabled = chkHaveContractWithKhadamat.Enabled;
        }

        private void chkHaveContractWithMosallah_EnabledChanged(object sender, EventArgs e)
        {
            txtIdentificationCodeMosallah.Enabled = chkHaveContractWithMosallah.Enabled;
        }

        private void txtIdentificationCodeKhadamat_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtIdentificationCodeMosallah_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }


    }



}

