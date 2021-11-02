using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.BusinessLogic;
using DentiNovin.Common;
using DentiNovin.BaseClasses;
using DentiNovin.Properties;

namespace DentiNovin
{
    public partial class BillForm : MiddleBaseWinForm
    {
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

        //private decimal _feesSum;
        public event EventHandler BillSaved;
        private bool _showPersianName = true;

        public BillForm()
        {
            InitializeComponent();
            _showPersianName = (bool)Settings.Default["ShowPersianName"];
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            int showListMode = 2;
            if (aPageMode == PageMode.Mode_edit)
            {
                showListMode = 1;
                InitialForm(true);
                FillBillDetailsList(oBill.BillID);
            }
            FilldgvPatientTreatment(showListMode);
        }

        private void FillBillDetailsList(Int64 billID)
        {
            try
            {
                DataSet aDataSet = FBillBLL.GetBillDetailsList(billID);
                oBill.BillDetailsList.Clear();
                for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                {
                    BillDetails aBillDetails = new BillDetails();
                    aBillDetails.FeesReceived = (decimal)aDataSet.Tables[0].Rows[i]["FeesReceived"];
                    aBillDetails.PayType = (Int16)aDataSet.Tables[0].Rows[i]["PayType"];
                    aBillDetails.PayTypeName = GetPayTypeName((Int16)aDataSet.Tables[0].Rows[i]["PayType"]);
                    aBillDetails.DateOfRegister = aDataSet.Tables[0].Rows[i]["DateOfRegister"].ToString();
                    oBill.BillDetailsList.Add(aBillDetails);
                }
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1013");
                MessageBox.Show("بروز خطا در بارگزاری اطلاعات صورتحساب ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GetPayTypeName(short payType)
        {
            switch (payType)
            {
                case 0:
                    return "نقدی";
                    break;
                case 1:
                    return "کارت بانکی";
                    break;
                case 2:
                    return "چکی";
                    break;
                default:
                    return "نقدی";
                    break;
            }
        }

        private void InitialForm(Boolean SetValue)
        {
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            string BillCode = string.Empty;
            string TotalFees = string.Empty;
            string FeesPayable = string.Empty;
            string FeesReceived = string.Empty;
            string DateOfRegister = string.Empty;

            if (SetValue)
            {
                BillCode = oBill.BillID.ToString();
                TotalFees = oBill.TotalFees.ToString("#,0;(#,0)");
                FeesPayable = oBill.FeesPayable.ToString("#,0;(#,0)");
                FeesReceived = oBill.FeesReceived.ToString("#,0;(#,0)");
                fdpDateOfRegister.Text = oBill.DateOfRegister;
                btnPaySystem.Enabled = true;
                btnSave.Enabled = true;
                btnSave.Text = "ویرایش";
            }
            else
                fdpDateOfRegister.SelectedDateTime = DateTime.Now;

            txtBillNo.Text = BillCode;
            txtTotalFees.Text = TotalFees;
            txtFeesPayable.Text = FeesPayable;
            txtFeesReceived.Text = FeesReceived;
        }

        private void FilldgvPatientTreatment(int showListMode)
        {
            try
            {
                DataSet ds = FBillBLL.GetPatientTreatmentList(this.OPatient.PatientID, this.oBill.BillID, showListMode, _showPersianName);

                dgvPatientTreatment.AutoGenerateColumns = false;
                dgvPatientTreatment.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1017");
                MessageBox.Show("بروز خطا در بارگزاری لیست درمانها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.oBill.BillDetailsList.Count == 0)
            {
                if (MessageBox.Show("در سیستم پرداخت رکوردی ثبت نشده است .آیا مایلید بدون ثبت رکورد پرداخت، عملیات ثبت صورتحساب را ادامه دهید؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            decimal _totalFees = 0;
            if (txtTotalFees.Text.Trim() == "" || !decimal.TryParse(txtTotalFees.Text.Trim(), out _totalFees))
            {
                errorProvider1.SetError(txtTotalFees, "هزینه درمان راوارد کنید");
                txtTotalFees.Focus();
                return;
            }
            decimal _feesPayable = 0;
            if (txtFeesPayable.Text.Trim() == "" || !decimal.TryParse(txtFeesPayable.Text.Trim(), out _feesPayable))
            {
                errorProvider1.SetError(txtFeesPayable, "مبلغ قابل پرداخت راوارد کنید");
                txtFeesPayable.Focus();
                return;
            }
            SetBill();
            FBillBLL.BiLLB = this.oBill;

            if (aPageMode == PageMode.Mode_new)
                try
                {
                    FBillBLL.SaveBillInfo();
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1020");
                    MessageBox.Show("بروز خطا در ثبت صورتحساب جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            if (aPageMode == PageMode.Mode_edit)
                try
                {
                    FBillBLL.EditBillInfo();
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1021");
                    MessageBox.Show("بروز خطا در ویرایش صورتحساب مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            OnBillSaved();
            this.Dispose();
        }

        public void SetBill()
        {
            oBill.PatientID = OPatient.PatientID;
            oBill.TotalFees = Convert.ToDecimal(txtTotalFees.Text.Trim());
            oBill.FeesPayable = Convert.ToDecimal(txtFeesPayable.Text.Trim());
            oBill.DateOfRegister = fdpDateOfRegister.Text;
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
            //_feesSum = 0;
            oBill.BillTreatmentList.Clear();

            for (int i = 0; i < dgvPatientTreatment.RowCount; i++)
            {
                if (dgvPatientTreatment.Rows[i].Cells[0].Value == null || (int)dgvPatientTreatment.Rows[i].Cells[0].Value == 0 || (int)dgvPatientTreatment.Rows[i].Cells[0].Value == 2)
                    continue;
                //_feesSum = _feesSum + Convert.ToDecimal(((System.Data.DataRowView)(dgvPatientTreatment.Rows[i].DataBoundItem)).Row.ItemArray[7]);
                oBill.BillTreatmentList.Add((Int64)((System.Data.DataRowView)(dgvPatientTreatment.Rows[i].DataBoundItem)).Row.ItemArray[0]);

            }
            //txtTotalFees.Text = _feesSum.ToString("#,0;(#,0)");
            //txtFeesPayable.Text = _feesSum.ToString("#,0;(#,0)");
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

        private void btnPaySystem_Click(object sender, EventArgs e)
        {
            decimal _totalFees = 0;
            if (txtTotalFees.Text.Trim() == "" || !decimal.TryParse(txtTotalFees.Text.Trim(), out _totalFees))
            {
                errorProvider1.SetError(txtTotalFees, "هزینه درمان راوارد کنید");
                txtTotalFees.Focus();
                return;
            }
            decimal _feesPayable = 0;
            if (txtFeesPayable.Text.Trim() == "" || !decimal.TryParse(txtFeesPayable.Text.Trim(), out _feesPayable))
            {
                errorProvider1.SetError(txtFeesPayable, "مبلغ قابل پرداخت راوارد کنید");
                txtFeesPayable.Focus();
                return;
            }

            BillPaymentForm aBillPaymentForm = new BillPaymentForm();
            //aBillDetailsFormOld.BillChanged += new EventHandler(aBillDetailsFormOld_BillChanged);
            SetBill();
            aBillPaymentForm.PayCharged += new BaseClasses.PaymentEventHandler(aBillPaymentForm_PayCharged);
            aBillPaymentForm.oBill = this.oBill;
            aBillPaymentForm.Owner = this;
            aBillPaymentForm.TopMost = true;
            aBillPaymentForm.ShowDialog();
        }

        void aBillPaymentForm_PayCharged(object sender, decimal e)
        {
            txtFeesReceived.Text =e.ToString("#,0;(#,0)");
        }

        private void OnBillSaved()
        {
            if (BillSaved != null)
                BillSaved(this, null);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void txtTotalFees_Leave(object sender, EventArgs e)
        {
            if (txtFeesPayable.Text.Trim() == "" || txtFeesPayable.Text.Trim() == "0")
                txtFeesPayable.Text = txtTotalFees.Text;
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtFeesPayable_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

    }
}
