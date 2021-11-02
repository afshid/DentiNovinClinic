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

namespace DentiClinic
{
    public partial class BillDetailsForm : BaseForm
    {
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

        public BillDetailsForm()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
           FilldgvBillDetails(oBill.BillID);
        }


        private void FilldgvBillDetails(Int64 billID)
        {
            DataSet ds;
            ds = FBillBLL.FilldgvBillDetails(billID);
            dgvBillDetails.AutoGenerateColumns = false;
            DataColumn aDataColumn = new DataColumn("RowNumber");
            ds.Tables[0].Columns.Add(aDataColumn);
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["RowNumber"] = i + 1;
            }
            dgvBillDetails.DataSource = ds.Tables[0];
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SetBillDetails();
            FBillBLL.OBillDetails = this.oBillDetails;
        }

        public void SetBillDetails()
        {
            oBillDetails.BillID= this.oBill.BillID;
            oBillDetails.FeesReceived = Convert.ToDecimal(txtFeesReceived.Text.Trim());
            oBillDetails.PayType =(Int16) cboPayType.SelectedIndex;
            oBillDetails.DateOfRegister = fdpDateOfRegister.Text;
        }
    }
}
