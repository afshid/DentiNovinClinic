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
using DentiClinic.BaseClasses;

namespace DentiClinic
{
    public partial class BillDetailsFormOld : BaseForm
    {
    //{
    //    private BillDetails _oBillDetails;
    //    public BillDetails oBillDetails
    //    {
    //        get
    //        {
    //            if (_oBillDetails == null)
    //                _oBillDetails = new BillDetails();
    //            return _oBillDetails;
    //        }
    //        set { _oBillDetails = value; }
    //    }

    //    private BillBLL _fBillBLL;
    //    public BillBLL FBillBLL
    //    {
    //        get
    //        {
    //            if (_fBillBLL == null)
    //                _fBillBLL = new BillBLL();
    //            return _fBillBLL;
    //        }
    //        set
    //        {
    //            _fBillBLL = value;
    //        }
    //    }

    //    private Bill _oBill;
    //    public Bill oBill
    //    {
    //        get
    //        {
    //            if (_oBill == null)
    //                _oBill = new Bill();
    //            return _oBill;
    //        }
    //        set { _oBill = value; }
    //    }

    //    private decimal _feesAllRecieved;

    //    public event EventHandler BillInserted;
    //    public event EventHandler BillChanged;
    //    public event PaymentEventHandler PayCharged;

    //    public BillDetailsFormOld()
    //    {
    //        InitializeComponent();
    //    }

    //    private void FilldgvBillDetails(Int64 billID)
    //    {
    //        DataSet ds;
    //        ds = FBillBLL.FilldgvBillDetails(billID);
    //        dgvBillPayment.AutoGenerateColumns = false;
    //        DataColumn aDataColumn = new DataColumn("RowNumber");
    //        ds.Tables[0].Columns.Add(aDataColumn);
    //        DataColumn bDataColumn = new DataColumn("PayTypeDesc");
    //        ds.Tables[0].Columns.Add(bDataColumn);
    //        _feesAllRecieved = 0;
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ds.Tables[0].Rows[i]["RowNumber"] = i + 1;
    //            switch ((Int16)ds.Tables[0].Rows[i]["PayType"])
    //            {
    //                case 0:
    //                    ds.Tables[0].Rows[i]["PayTypeDesc"] = "نقدی";
    //                    break;
    //                case 1:
    //                    ds.Tables[0].Rows[i]["PayTypeDesc"] = "کارت بانکی";
    //                    break;
    //                case 2:
    //                    ds.Tables[0].Rows[i]["PayTypeDesc"] = "چکی";
    //                    break;
    //                default:
    //                    break;
    //            }
    //            _feesAllRecieved = _feesAllRecieved + (decimal)ds.Tables[0].Rows[i]["FeesReceived"];

    //        }
    //        dgvBillPayment.DataSource = ds.Tables[0];
    //    }

    //    private void BillDetailsFormOld_Load(object sender, EventArgs e)
    //    {
    //        _feesAllRecieved = 0;
    //        if (oBill.BillID != 0)
    //            FilldgvBillDetails(oBill.BillID);
    //        InitialForm(false);
    //    }

    //    private void btnPay_Click(object sender, EventArgs e)
    //    {
    //        decimal _feesPayable = 0;
    //        if (txtFeesPayable.Text.Trim() == "" || !decimal.TryParse(txtFeesPayable.Text.Trim(), out _feesPayable))
    //        {
    //            errorProvider1.SetError(txtFeesPayable, "مبلغ قابل پرداخت راوارد کنید");
    //            txtFeesPayable.Focus();
    //            return;
    //        }
    //        decimal _feesReceived = 0;
    //        if (txtFeesReceived.Text.Trim() == "" || !decimal.TryParse(txtFeesReceived.Text.Trim(), out _feesReceived))
    //        {
    //            errorProvider1.SetError(txtFeesReceived, "مبلغ دریافتی راوارد کنید");
    //            txtFeesReceived.Focus();
    //            return;
    //        }
    //        if (this.oBill.BillID == 0)
    //        {
    //            //SetBill();
    //            FBillBLL.BiLLB = this.oBill;
    //            FBillBLL.SaveBillInfo();
    //            //OnBillInserted();
    //        }
    //        //SetBillDetails();
    //        FBillBLL.OBillDetails = this.oBillDetails;
    //        FBillBLL.SaveBillDetails();
    //        FilldgvBillDetails(oBill.BillID);
    //        //InitialForm(false);
    //        //OnBillChanged();
    //        OnPayCharged(decimal totalPayment);
    //    }

    //    private void InitialForm(Boolean SetValue)
    //    {
    //        fdpDateOfRegister.SelectedDateTime = DateTime.Now;
    //        string FeesPayable = string.Empty;
    //        string FeesReceived = string.Empty;
    //        string DateOfRegister = string.Empty;
    //        string TotalFees = string.Empty;
    //        TotalFees = oBill.TotalFees.ToString();
    //        FeesPayable = oBill.FeesPayable.ToString();
    //        FeesReceived = (oBill.FeesPayable - _feesAllRecieved).ToString();
    //        if (SetValue)
    //        {
    //            fdpDateOfRegister.Text = oBillDetails.DateOfRegister;
    //            cboPayType.SelectedIndex = oBillDetails.PayType;
    //            aPageMode = PageMode.Mode_edit;
    //            btnPay.Text = "ویرایش";
    //            btnCancle.Enabled = true;
    //            btnCancle.Text = "انصراف";
    //            //btnPay.Enabled = false;
    //        }
    //        else
    //        {
    //            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
    //            aPageMode = PageMode.Mode_new;
    //            btnPay.Text = "ثبت";
    //            btnCancle.Text = "خروج";
    //            //btnCancle.Enabled = false;
    //            cboPayType.SelectedIndex = 0;
    //        }

    //        txtTotalFees.Text = TotalFees;
    //        txtFeesPayable.Text = FeesPayable;
    //        txtFeesReceived.Text = FeesReceived;
    //    }

    //    public void SetBill()
    //    {
    //        oBill.FeesReceived = Convert.ToDecimal(txtFeesReceived.Text.Trim());
    //        oBill.FeesPayable = Convert.ToDecimal(txtFeesPayable.Text.Trim());
    //        oBill.DateOfRegister = fdpDateOfRegister.Text;
    //    }

    //    public void SetBillDetails()
    //    {
    //        oBillDetails.BillID = this.oBill.BillID;
    //        oBillDetails.FeesReceived = Convert.ToDecimal(txtFeesReceived.Text.Trim());
    //        oBillDetails.PayType = (Int16)cboPayType.SelectedIndex;
    //        oBillDetails.DateOfRegister = fdpDateOfRegister.Text;
    //    }

    //    private void btnCancle_Click(object sender, EventArgs e)
    //    {
    //        this.Close();
    //    }

    //    private void OnBillInserted()
    //    {
    //        if (BillInserted != null)
    //            BillInserted(this, null);
    //    }

    //    private void OnBillChanged()
    //    {
    //        if (BillChanged != null)
    //            BillChanged(this, null);
    //    }

    //    private void OnPayCharged(decimal totalPayment)
    //    {
    //        if (PayCharged != null)
    //            PayCharged(this, totalPayment);
    //    }
    //}
    }
}
