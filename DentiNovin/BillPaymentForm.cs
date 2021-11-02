using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class BillPaymentForm : BaseForm
    {
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

        private BillDetails _oBillDetails;
        public BillDetails oBillDetails
        {
            get
            {
                if (_oBillDetails == null)
                    _oBillDetails = new BillDetails();
                return _oBillDetails;
            }
            set { _oBillDetails = value; }
        }

        private decimal _feesAllRecieved;
        public event PaymentEventHandler PayCharged;

        private BindingList<BillDetails> _billDetailsListShadow;

        decimal _deletedFeesReceived = 0;
        public BillPaymentForm()
        {
            InitializeComponent();
        }

        private void BillPaymentForm_Load(object sender, EventArgs e)
        {
            _feesAllRecieved = 0;
            dgvBillPaymentList.AutoGenerateColumns = false;
            //_billDetailsListShadow =new BindingList<BillDetails>(this.oBill.BillDetailsList);
            _billDetailsListShadow = UtilMethods.CloneList<BillDetails>(this.oBill.BillDetailsList);
            dgvBillPaymentList.DataSource = this._billDetailsListShadow;
            InitialForm();
        }

        private void InitialForm()
        {
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            string FeesPayable = string.Empty;
            string FeesReceived = string.Empty;
            string DateOfRegister = string.Empty;
            string RemainFees = string.Empty;

            FeesPayable = oBill.FeesPayable.ToString("#,0;(#,0)");
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            cboPayType.SelectedIndex = 0;
            _feesAllRecieved = 0;
            foreach (BillDetails bDs in this._billDetailsListShadow)
            {
                _feesAllRecieved += bDs.FeesReceived;
            }
            txtFeesPayable.Text = FeesPayable;

            txtRemainFees.Text = (oBill.FeesPayable - _feesAllRecieved).ToString("#,0;(#,0)");
            txtFeesReceived.Text = txtRemainFees.Text;

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //decimal _feesPayable = 0;
            //if (txtRemainFees.Text.Trim() == "" || !decimal.TryParse(txtRemainFees.Text.Trim(), out _feesPayable))
            //{
            //    errorProvider1.SetError(txtRemainFees, "مبلغ قابل پرداخت راوارد کنید");
            //    txtRemainFees.Focus();
            //    return;
            //}
            decimal _feesReceived = 0;
            if (txtFeesReceived.Text.Trim() == "" || txtFeesReceived.Text.Trim() == "0" || !decimal.TryParse(txtFeesReceived.Text.Trim(), out _feesReceived))
            {
                errorProvider1.SetError(txtFeesReceived, "مبلغ پرداختی راوارد کنید");
                txtFeesReceived.Focus();
                return;
            }

            BillDetails aBillDetails = new BillDetails();
            aBillDetails.FeesReceived = _feesReceived;
            aBillDetails.PayType = (Int16)cboPayType.SelectedIndex;
            aBillDetails.PayTypeName = cboPayType.SelectedItem.ToString();
            aBillDetails.DateOfRegister = fdpDateOfRegister.Text;
            _billDetailsListShadow.Add(aBillDetails);
            InitialForm();
            dgvBillPaymentList.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           this.oBill.BillDetailsList.Clear();
            this.oBill.BillDetailsList = _billDetailsListShadow;
            OnPayCharged(_feesAllRecieved);
            this.Dispose();

        }

        private void OnPayCharged(decimal totalPayment)
        {
            if (PayCharged != null)
                PayCharged(this, totalPayment);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvBillPaymentList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvBillPaymentList.Rows[e.RowIndex].Selected = true;
                //_selectdBillDetailsIndex = e.RowIndex;
                //_selectedBillDetailsPayment =(decimal) this.dgvBillPaymentList.Rows[e.RowIndex].Cells[1].Value;
                oBillDetails = _billDetailsListShadow[e.RowIndex];

            }
        }

        private void DeleteService(BillDetails details)
        {
            _billDetailsListShadow.Remove(details);
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            InitialForm();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            _deletedFeesReceived = 0;
            if (MessageBox.Show("پرداخت مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _billDetailsListShadow.Remove(oBillDetails);
                dgvBillPaymentList.Refresh();
                _deletedFeesReceived = oBillDetails.FeesReceived;
                InitialForm();
            }
        }

        private void dgvBillPaymentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            dgvBillPaymentList.Rows[e.RowIndex].Cells[0].Value = e.RowIndex+1;
        }

        private void txtFeesReceived_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }


    }
}
