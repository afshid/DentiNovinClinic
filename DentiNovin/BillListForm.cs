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
    public partial class BillListForm : MiddleBaseWinForm
    {
        private Patient _oPatient;
        public Patient OPatient
        {
            get
            {
                if (_oPatient == null)
                    _oPatient = new Patient();
                return _oPatient;
            }
            set { _oPatient = value; }
        }

        private BillBLL _fBillBLL;
        public BillBLL FBillBLL
        {
            get
            {
                if (_fBillBLL == null)
                    _fBillBLL = new BillBLL();
                return _fBillBLL;
            }
            set
            {
                _fBillBLL = value;
            }
        }

        private Bill _oBill;
        public Bill oBill
        {
            get
            {
                if (_oBill == null)
                    _oBill = new Bill();
                return _oBill;
            }
            set { _oBill = value; }
        }

        DataSet ds;
        private decimal _totalAllFees;
        private decimal _feesAllRecieved;
        private decimal _feesAllPayable;
        private bool _fileNumberChanged = false;

        public BillListForm()
        {
            InitializeComponent();
        }

        private void BillListForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.OPatient = (Patient)((MainForm)this.MdiParent).oPatient.Clone();
            InitialPatientInfo();
        }

        private void InitialPatientInfo()
        {
            if (OPatient.PatientID != 0)
            {
                txtFileNumber.Text = OPatient.FileNumber.ToString();
                txtPatientLastName.Text = OPatient.LastName.ToString();
                txtFirstName.Text = OPatient.FirstName.ToString();
                FilldgvBiLL();
                _fileNumberChanged = false;
            }
            else
            {
                txtFirstName.Text = string.Empty;
                txtPatientLastName.Text = string.Empty;
                dgvBill.DataSource = null;
                txtFeesAllReceived.Text = string.Empty;
                txtTotalAllFees.Text = string.Empty;
                txtRemainFees.Text = string.Empty;
                if (txtFileNumber.Text.Trim() == string.Empty)
                    return;
                txtFileNumber.Focus();
                txtFileNumber.SelectionStart = 0;
                txtFileNumber.SelectionLength = txtFileNumber.TextLength;
            }

            // btnReport.Enabled = true;
        }

        public void FilldgvBiLL()
        {
            try
            {
            FBillBLL.oPatient = this.OPatient;
            ds = FBillBLL.FilldgvBiLL();
            dgvBill.AutoGenerateColumns = false;
            DataColumn aDataColumn = new DataColumn("RemainFees");
            ds.Tables[0].Columns.Add(aDataColumn);
            _totalAllFees = 0;
            _feesAllRecieved = 0;
            _feesAllPayable = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["RemainFees"] = (decimal)ds.Tables[0].Rows[i]["FeesPayable"] - (decimal)ds.Tables[0].Rows[i]["FeesReceived"];
                _totalAllFees = _totalAllFees + (decimal)ds.Tables[0].Rows[i]["TotalFees"];
                _feesAllRecieved = _feesAllRecieved + (decimal)ds.Tables[0].Rows[i]["FeesReceived"];
                _feesAllPayable = _feesAllPayable + (decimal)ds.Tables[0].Rows[i]["FeesPayable"];
            }
            dgvBill.DataSource = ds.Tables[0];
            txtFeesAllReceived.Text = _feesAllRecieved.ToString("#,0;(#,0)");
            txtTotalAllFees.Text = _totalAllFees.ToString("#,0;(#,0)");
            txtFeesAllPayable.Text = _feesAllPayable.ToString("#,0;(#,0)");
            txtRemainFees.Text = (_feesAllPayable - _feesAllRecieved).ToString("#,0;(#,0)");

            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1022");
                MessageBox.Show("بروز خطا در بارگزاری لیست صورتحساب", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFileNumber_Leave(object sender, EventArgs e)
        {
            int _fileNumber = 0;
            if (!int.TryParse(txtFileNumber.Text.Trim(), out _fileNumber) || txtFileNumber.Text.Trim()=="0")
                OPatient.PatientID= 0;
            else
                if (_fileNumberChanged && _fileNumber != 0)
                    SelectPatient();
                else
                    return;
        InitialPatientInfo();
        }

        public void SelectPatient()
        {
            try
            {
            OPatient.PatientID = 0;
            OPatient.FileNumber = Convert.ToInt32(txtFileNumber.Text.Trim());
            FBillBLL.oPatient = OPatient;
            FBillBLL.SelectPatient();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1023");
                MessageBox.Show("بروز خطا در دریافت اطلاعات بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtFileNumber_TextChanged(object sender, EventArgs e)
        {
            _fileNumberChanged = true;
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            BillForm aBillForm = new BillForm();
            aBillForm.BillSaved += new EventHandler(aBillForm_BillSaved);
            aBillForm.OPatient = this.OPatient;
            aBillForm.aPageMode = PageMode.Mode_new;
            aBillForm.ShowDialog();
        }

        void aBillForm_BillSaved(object sender, EventArgs e)
        {
            FilldgvBiLL();
        }

        private void dgvBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            BillForm aBillForm = new BillForm();
            aBillForm.BillSaved += new EventHandler(aBillForm_BillSaved);
            aBillForm.OPatient = this.OPatient;
            SetSelectedObject((DataRowView)dgvBill.SelectedRows[0].DataBoundItem);
            aBillForm.oBill = this.oBill;
            aBillForm.aPageMode = PageMode.Mode_edit;
            aBillForm.ShowDialog();
        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            oBill.BillID = (Int64)selectedDataRow.Row.ItemArray[1];
            oBill.TotalFees = (Decimal)selectedDataRow.Row.ItemArray[5];
            oBill.FeesPayable = (Decimal)selectedDataRow.Row.ItemArray[6];
            oBill.FeesReceived = (Decimal)selectedDataRow.Row.ItemArray[8];
            oBill.DateOfRegister = selectedDataRow.Row.ItemArray[7].ToString();
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            SearchPatientForm aSearchPatientForm = new SearchPatientForm();
            aSearchPatientForm.TopMost = true;
            aSearchPatientForm.PatientSelected += new BaseClasses.PatientSelectEventHandler(aSearchPatientForm_PatientSelected);
            aSearchPatientForm.ShowDialog();
        }

        void aSearchPatientForm_PatientSelected(object sender, Patient e)
        {
            this.OPatient = (Patient)e.Clone();
            InitialPatientInfo();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            BillReportForm aBillReportForm = new BillReportForm();
            aBillReportForm.OPatient = this.OPatient;
            aBillReportForm.TotalFees = _totalAllFees;
            aBillReportForm.TotalFeesReceived = _feesAllRecieved;
            aBillReportForm.TolatFeesPayable = _feesAllPayable;
            aBillReportForm.BillDataSet = this.ds.Copy();
            aBillReportForm.MdiParent = this.MdiParent;
            aBillReportForm.Show();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count <= 0)
                return;
            dgvBill_CellDoubleClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("صورتحساب مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                FBillBLL.DeleteObject((Int64)((DataRowView)dgvBill.SelectedRows[0].DataBoundItem).Row.ItemArray[1]);
                MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InitialPatientInfo();
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1024");
                    MessageBox.Show("بروز خطا در حذف صورتحساب مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvBill_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvBill.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvBill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvBill.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }

    }
}
