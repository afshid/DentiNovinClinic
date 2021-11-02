using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.Common;
using DentiClinic.BusinessLogic;
using DentiClinic.Properties;

namespace DentiClinic
{
    public partial class BillFormOld : BaseForm
    {
        private string TimeWeekID;

        private int _patientid;

        private bool DiscountChange = false;

        private bool FileNumberChange = false;



        private decimal _feesSum;

        private decimal _totalAllFees;
        private decimal _feesAllRecieved;
        private decimal _feesAllPayable;

        private bool _allowChangeChkBoxMode = false;

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

        public BillFormOld()
        {
            InitializeComponent();
            if ((bool)Settings.Default["TreatmentLatinName"])
                this.TreatmentName.DataPropertyName = "LatinName";
            aPageMode = PageMode.Mode_new;
        }

        private void InitialPatient()
        {
            txtFileNumber.Text = OPatient.FileNumber.ToString();
            txtPatientLastName.Text = OPatient.LastName.ToString();
            txtFirstName.Text = OPatient.FirstName.ToString();
            btnReport.Enabled = true;
        }

        private void InitialForm(Boolean SetValue)
        {
            string BillNo = string.Empty;
            string FeesPayable = string.Empty;
            string FeesReceived = string.Empty;
            string DateOfRegister = string.Empty;
            string TotalFees = string.Empty;

            if (SetValue)
            {
                BillNo = oBill.BillID.ToString();
                TotalFees = oBill.TotalFees.ToString();
                FeesPayable = oBill.FeesPayable.ToString();
                FeesReceived = oBill.FeesReceived.ToString();
                fdpDateOfRegister.Text = oBill.DateOfRegister;
                aPageMode = PageMode.Mode_edit;
                btnCancle.Enabled = true;
                btnSave.Enabled = false;
                btnPaySystem.Enabled = true;
                SelectBillTreatmentInDGV();
            }
            else
            {
                fdpDateOfRegister.SelectedDateTime = DateTime.Now;
                cmbShowListMode.SelectedIndex = 2;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancle.Enabled = false;
                btnSave.Enabled = false;
                btnPaySystem.Enabled = false;
            }



            txtBillNo.Text = BillNo;
            txtTotalFees.Text = TotalFees;
            txtFeesPayable.Text = FeesPayable;
            txtFeesReceived.Text = FeesReceived;
           // dgvPatientTreatment.Refresh();
        }

        public void UpdateCostByVisitDate()
        {

            FBillBLL.BiLLB = this.oBill;
            FBillBLL.UpdateCostByVisitDate();

        }
        DataSet ds;

        public void FilldgvBiLL()
        {
            FBillBLL.oPatient = this.OPatient;
            ds = FBillBLL.FilldgvBiLL();
            dgvBill.AutoGenerateColumns = false;
            //DataColumn aDataColumn = new DataColumn("RowNumber");
            //ds.Tables[0].Columns.Add(aDataColumn);
            _totalAllFees = 0;
            _feesAllRecieved = 0;
            _feesAllPayable = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //ds.Tables[0].Rows[i]["RowNumber"] = i + 1;
                _totalAllFees = _totalAllFees + (decimal)ds.Tables[0].Rows[i]["TotalFees"];
                _feesAllRecieved = _feesAllRecieved + (decimal)ds.Tables[0].Rows[i]["FeesReceived"];
                _feesAllPayable = _feesAllPayable + (decimal)ds.Tables[0].Rows[i]["FeesPayable"];
            }
            dgvBill.DataSource = ds.Tables[0];
            txtFeesAllReceived.Text = _feesAllRecieved.ToString();
            txtTotalAllFees.Text = _totalAllFees.ToString();
            txtRemainFees.Text = (_totalAllFees - _feesAllRecieved).ToString();
        }

        private void BillFormOld_Load(object sender, EventArgs e)
        {
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            btnReport.Enabled = false;
            this.OPatient = (Patient)((MainForm)this.MdiParent).oPatient.Clone();
            if (OPatient.FileNumber != 0)
            {
                InitialPatient();
                FilldgvBiLL();
                cmbShowListMode.SelectedIndex = 2;
                FileNumberChange = false;
            }
            else
            {
                // lblFileNumber.Visible = false;
                txtFirstName.Text = "";
                txtPatientLastName.Text = "";
                txtFileNumber.Visible = true;
            }
        }

        bool BillFlag = false;

        private DataSet GetBillTreatmentList()
        {
            return FBillBLL.GetBillTreatmentList(OPatient.PatientID, this.oBill.BillID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal _feesPayable = 0;
            if (txtFeesPayable.Text.Trim() == "" || !decimal.TryParse(txtFeesPayable.Text.Trim(), out _feesPayable))
            {
                errorProvider1.SetError(txtFeesPayable, "مبلغ قابل پرداخت راوارد کنید");
                txtFeesPayable.Focus();
                return;
            }
            decimal _feesReceived = 0;
            if (txtFeesReceived.Text.Trim() == "" || !decimal.TryParse(txtFeesReceived.Text.Trim(), out _feesReceived))
            {
                errorProvider1.SetError(txtFeesReceived, "مبلغ دریافتی راوارد کنید");
                txtFeesReceived.Focus();
                return;
            }
            SetBill();
            FBillBLL.BiLLB = this.oBill;

            if (aPageMode == PageMode.Mode_new)
                FBillBLL.SaveBillInfo();
            if (aPageMode == PageMode.Mode_edit)
                FBillBLL.UpdateCostByVisitDate();
            InitialForm(false);
            FilldgvBiLL();
            FilldgvPatientTreatment(cmbShowListMode.SelectedIndex);
        }

        public void SetBill()
        {
            //oBill.PatientID = OPatient.PatientID;
            //oBill.FeesReceived = Convert.ToDecimal(txtFeesReceived.Text.Trim());
            //oBill.FeesPayable = Convert.ToDecimal(txtFeesPayable.Text.Trim());
            //oBill.DateOfRegister = fdpDateOfRegister.Text;
            oBill.PatientID = OPatient.PatientID;
            oBill.TotalFees = Convert.ToDecimal(txtTotalFees.Text.Trim());
            oBill.FeesPayable = Convert.ToDecimal(txtFeesPayable.Text.Trim());
        }

        public void SelectPatient()
        {
            OPatient.RowEffected = false;
            OPatient.FileNumber = Convert.ToInt32(txtFileNumber.Text.Trim());
            FBillBLL.oPatient = OPatient;
            FBillBLL.SelectPatient();
        }

        private void txtFileNumber_Leave(object sender, EventArgs e)
        {
            int _fileNumber = 0;
            if (!int.TryParse(txtFileNumber.Text.Trim(), out _fileNumber))
                return;
            if (FileNumberChange && txtFileNumber.Text != "")
            {
                this.OPatient.PatientID = 0;
                SelectPatient();
                setPatientInfo();
            }
        }

        public void setPatientInfo()
        {
            if (OPatient.RowEffected)
            {
                txtFileNumber.Text = OPatient.FileNumber.ToString();
                FileNumberChange = false;
                txtFirstName.Text = OPatient.FirstName;
                txtPatientLastName.Text = OPatient.LastName;
                FilldgvBiLL();
                FilldgvPatientTreatment(cmbShowListMode.SelectedIndex);
                btnReport.Enabled = true;
            }
            else
            {
                OPatient = null;
                txtFirstName.Text = "";
                txtPatientLastName.Text = "";
                txtTotalAllFees.Text = "";
                txtFeesAllReceived.Text = "";
                txtRemainFees.Text = "";
                dgvBill.DataSource = null;
                dgvBill.Refresh();
                dgvPatientTreatment.DataSource = null;
                dgvPatientTreatment.Refresh();
                FileNumberChange = false;
                txtFileNumber.Focus();
                txtFileNumber.SelectionStart = 0;
                txtFileNumber.SelectionLength = txtFileNumber.TextLength;
                btnReport.Enabled = false;

            }
            InitialForm(false);
        }


        private void FilldgvPatientTreatment(int showListMode)
        {
            DataSet ds = FBillBLL.GetPatientTreatmentList(OPatient.PatientID, showListMode);

            dgvPatientTreatment.AutoGenerateColumns = false;
            DataColumn aDataColumn = new DataColumn("RowNumber");
            ds.Tables[0].Columns.Add(aDataColumn);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                ds.Tables[0].Rows[i]["RowNumber"] = i + 1;
                //  ds.Tables[0].Rows[i]["PatientName"] = ds.Tables[0].Rows[i].ItemArray[4];
            }
            //if (ds.Tables[0].Rows.Count > 0)
            //    btnSave.Enabled = true;
            //else
            //    btnSave.Enabled = false;
            dgvPatientTreatment.DataSource = ds.Tables[0];

        }

        private void txtFileNumber_TextChanged(object sender, EventArgs e)
        {
            FileNumberChange = true;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            oBill = null;
            InitialForm(false);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            BillReportForm aBillReportForm = new BillReportForm();
            aBillReportForm.OPatient = this.OPatient;
            aBillReportForm.TotalFees = _totalAllFees;
            aBillReportForm.TotalFeesReceived = _feesAllRecieved;
            aBillReportForm.TolatFeesPayable = _feesAllPayable;
            aBillReportForm.BillDataSet = this.ds;
            aBillReportForm.MdiParent = this.MdiParent;
            aBillReportForm.Show();
        }

        private void dgvPatientTreatment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            // dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value = 0;
            if (((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1] == System.DBNull.Value || (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1] == 0)
            {
                if (dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value == null)
                    dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value = 0;
                return;
            }
            dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value = 2;
            dgvPatientTreatment.Rows[e.RowIndex].Cells[0].ReadOnly = true;
            if (aPageMode == PageMode.Mode_edit && (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1] == oBill.BillID)
                dgvPatientTreatment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            else
            {
                dgvPatientTreatment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                dgvPatientTreatment.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void SelectBillTreatmentInDGV()
        {
            //foreach (DataGridViewRow dgvr in dgvPatientTreatment.Rows)
            //{
            //    dgvr.DefaultCellStyle.BackColor = Color.Red;
            //}
           // dgvPatientTreatment.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void dgvBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            this.oBill.BillID = (Int64)((System.Data.DataRowView)(dgvBill.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[0];
            this.oBill.PatientID = this.OPatient.PatientID;
            this.oBill.TotalFees = (decimal)((System.Data.DataRowView)(dgvBill.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5];
            this.oBill.FeesPayable = (decimal)((System.Data.DataRowView)(dgvBill.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[6];
            this.oBill.FeesReceived = (decimal)((System.Data.DataRowView)(dgvBill.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8];
            this.oBill.DateOfRegister = ((System.Data.DataRowView)(dgvBill.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7].ToString();
            cmbShowListMode.SelectedIndex = 1;
            InitialForm(true);
            dgvPatientTreatment.Refresh();
        }

        private void txtFeesPayable_TextChanged(object sender, EventArgs e)
        {
            // txtFeesReceived.Text = txtFeesPayable.Text;
        }

        private void txtFeesPayable_Leave(object sender, EventArgs e)
        {
            decimal _feesPayable = 0;
            if (txtFeesPayable.Text.Trim() != "" && decimal.TryParse(txtFeesPayable.Text.Trim(), out _feesPayable))
                errorProvider1.Clear();
        }

        private void txtFeesReceived_Leave(object sender, EventArgs e)
        {
            decimal _feesReceived = 0;
            if (txtFeesReceived.Text.Trim() != "" && decimal.TryParse(txtFeesReceived.Text.Trim(), out _feesReceived))
                errorProvider1.Clear();

        }

        private void cmbShowListMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilldgvPatientTreatment(cmbShowListMode.SelectedIndex);
        }

        private void btnPaySystem_Click(object sender, EventArgs e)
        {
            BillDetailsFormOld aBillDetailsFormOld = new BillDetailsFormOld();
            aBillDetailsFormOld.BillChanged += new EventHandler(aBillDetailsFormOld_BillChanged);
            SetBill();
            aBillDetailsFormOld.oBill = this.oBill;
            aBillDetailsFormOld.Owner = this;
            aBillDetailsFormOld.TopMost = true;
            aBillDetailsFormOld.ShowDialog();
        }

        void aBillDetailsFormOld_BillChanged(object sender, EventArgs e)
        {
            oBill= null;
            FilldgvBiLL();
            FilldgvPatientTreatment(cmbShowListMode.SelectedIndex);
        }

        private void dgvPatientTreatment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1 || aPageMode == PageMode.Mode_edit)
                return;
            if (dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value == null || (int)dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value == 0)
                dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value = 1;
            else
            {
                if ((int)dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value == 2)
                    return;
                dgvPatientTreatment.Rows[e.RowIndex].Cells[0].Value = 0;
            }
            _feesSum = 0;
            oBill.BillTreatmentList.Clear();

            for (int i = 0; i < dgvPatientTreatment.RowCount; i++)
            {
                if (dgvPatientTreatment.Rows[i].Cells[0].Value == null || (int)dgvPatientTreatment.Rows[i].Cells[0].Value == 0 || (int)dgvPatientTreatment.Rows[i].Cells[0].Value == 2)
                    continue;
                _feesSum = _feesSum + Convert.ToDecimal(((System.Data.DataRowView)(dgvPatientTreatment.Rows[i].DataBoundItem)).Row.ItemArray[7]);
                oBill.BillTreatmentList.Add(new BillTreatment((Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[i].DataBoundItem)).Row.ItemArray[0], (Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[i].DataBoundItem)).Row.ItemArray[14], (Decimal)((System.Data.DataRowView)(dgvPatientTreatment.Rows[i].DataBoundItem)).Row.ItemArray[7]));

            }
            txtTotalFees.Text = _feesSum.ToString();
            txtFeesPayable.Text = _feesSum.ToString();
            // txtFeesReceived.Text=_feesSum.ToString();
            txtFeesReceived.Text = "0";
            if (oBill.BillTreatmentList.Count > 0)
            {
                btnSave.Enabled = true;
                btnPaySystem.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnPaySystem.Enabled = false;
            }
        }
    }
}
