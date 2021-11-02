using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.BusinessLogic;
using DentiClinic.Common;
using DentiClinic.BaseClasses;

namespace DentiClinic
{
    public partial class TreatmentForm : BaseForm
    {

        private TreatmentBLL _fTreatmentBLL;
        public TreatmentBLL FTreatmentBLL
        {
            get
            {
                if (_fTreatmentBLL == null)
                    _fTreatmentBLL = new TreatmentBLL();
                return _fTreatmentBLL;
            }
            set
            {
                _fTreatmentBLL = value;
            }
        }

        private Treatment _oTreatment;
        public Treatment oTreatment
        {
            get
            {
                if (_oTreatment == null)
                    _oTreatment = new Treatment();
                return _oTreatment;
            }
            set { _oTreatment = value; }
        }

        //private int _numberReplaced;
        //private int _directionRelpaced;

        private ToothMode toothMode;
        private ToothSelectMode toothSelectMode;

        private Dictionary<string, int> Ddirection = new Dictionary<string, int>();

        public TreatmentForm()
        {
            InitializeComponent();
        }


        private void TreatmentForm_Load(object sender, EventArgs e)
        {
            toothMode = ToothMode.Adult;
            toothSelectMode = ToothSelectMode.Separate;

            Dictionary<string, int> Dnumber = new Dictionary<string, int>();
            Dnumber.Add("1", 1); Dnumber.Add("2", 2); Dnumber.Add("3", 3); Dnumber.Add("4", 4);
            Dnumber.Add("5", 5); Dnumber.Add("6", 6); Dnumber.Add("7", 7); Dnumber.Add("8", 8);
            Dnumber.Add("A", 9); Dnumber.Add("B", 10); Dnumber.Add("C", 11); Dnumber.Add("D", 12); Dnumber.Add("E", 13);


            cboNumber.DataSource = new BindingSource(Dnumber, null);
            cboNumber.DisplayMember = "Key";
            cboNumber.ValueMember = "Value";

            cboSearch.SelectedIndex = 0;
            GetTreatmentTitleList();
            GetTreatmentList();

            InitialForm(false);
        }

        private void AssignDirectionCombo(int kind)
        {
            Ddirection.Clear();

            if (kind == 4)
            {
                Ddirection.Add("بالا - راست", 1);
                Ddirection.Add("بالا - چپ", 2);
                Ddirection.Add("پایین - چپ", 3);
                Ddirection.Add("پایین - راست", 4);
            }
            else
            {
                Ddirection.Add("فک بالا", 100);
                Ddirection.Add("فک پایین", 200);
            }

            cboDirection.DataSource = new BindingSource(Ddirection, null);
            cboDirection.DisplayMember = "Key";
            cboDirection.ValueMember = "Value";
        }

        private void SetTreatment()
        {
            oTreatment.TreatmentTitleID = (int)((DataRowView)cboTreatmentTitle.SelectedItem).Row.ItemArray[0];
            int direction = 0;
            int number = 0;
            bool child = false;
            //if (cboDirection.Enabled)
            direction = ((System.Collections.Generic.KeyValuePair<string, int>)cboDirection.SelectedItem).Value;
            if (cboNumber.Enabled)
            {
                number = ((System.Collections.Generic.KeyValuePair<string, int>)cboNumber.SelectedItem).Value;
                if(toothMode==ToothMode.Child)
                {
                    number = number - 8;
                    direction = direction + 4;
                }
            }

            //oTreatment.TreatmentCode = GenerateTreatmentCode(((DataRowView)cboTreatmentTitle.SelectedItem).Row.ItemArray[1].ToString(), direction, number, child);
            oTreatment.TreatmentCode = txtTreatmentCode.Text;
            oTreatment.ToothNumber = number;
            oTreatment.ToothDirection = direction;
            oTreatment.Price = Convert.ToDecimal(txtTariffWO.Text);
            oTreatment.InsurancePrice = Convert.ToDecimal(txtTariffW.Text);
            oTreatment.DateOfRegister = Convert.ToDateTime(fdpActiveDate.Text);
        }

        //private string GenerateTreatmentCode(string titleCode, int direction, int number, bool child)
        //{
        //    if (titleCode.Length < 3)
        //        return string.Format("000{0}{1}0", direction, number);
        //    else
        //    {
        //        switch (titleCode)
        //        {
        //            case "0220":
        //                if (child)
        //                    titleCode = "0230";
        //                break;
        //            default:
        //                break;
        //        }
        //        string dirnumber = direction.ToString() + number.ToString();
        //        if (direction == 0 && number == 0)
        //            dirnumber = _directionRelpaced.ToString() + _numberReplaced.ToString();
        //        return titleCode.Insert(3, dirnumber);
        //    }
        //}


        private void InitialForm(Boolean SetValue)
        {
            string TarrifWithAssurance = string.Empty;
            string TarrifWithoutAssurance = string.Empty;
            string StartActiveDate = string.Empty;
            Boolean setEmpty = true;

            if (SetValue)
            {
                setEmpty = false;
                TarrifWithAssurance = oTreatment.InsurancePrice.ToString();
                TarrifWithoutAssurance = oTreatment.Price.ToString();
                StartActiveDate = oTreatment.DateOfRegister.ToShortDateString();
                cboTreatmentTitle.SelectedValue = oTreatment.TreatmentTitleID;

                int dir = oTreatment.ToothDirection;
                int num = oTreatment.ToothNumber;
                if (dir > 4)
                {
                    if (dir > 99)
                    {
                        toothSelectMode = ToothSelectMode.TopDown;
                        toothMode = ToothMode.Adult;
                    }
                    else
                    {
                        toothMode = ToothMode.Child;
                        dir = dir - 4;
                        num = num + 8;
                    }
                }
                cboDirection.SelectedValue = dir;
                cboNumber.SelectedValue = num;

                //cboTreatmentTitle
                aPageMode = PageMode.Mode_edit;
                btnSave.Text = "ویرایش";
                btnCancle.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                cboTreatmentTitle.SelectedIndex = -1;
                cboDirection.SelectedIndex = -1;
                cboNumber.SelectedIndex = -1;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancle.Enabled = false;
                btnDelete.Enabled = false;

            }

            fdpActiveDate.Text = StartActiveDate;
            txtTariffWO.Text = TarrifWithoutAssurance;
            txtTariffW.Text = TarrifWithAssurance;


        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetTreatment();
            FTreatmentBLL.oTreatment = this.oTreatment;

            if (aPageMode == PageMode.Mode_new)
                FTreatmentBLL.TreatmentInsert();
            else
                FTreatmentBLL.TreatmentEdit();

            GetTreatmentList();

            InitialForm(false);
        }

        public int GetLastCode()
        {
            return FTreatmentBLL.GetLastCode();
        }

        private void GetTreatmentTitleList()
        {
            DataSet aDataSet;
            aDataSet = FTreatmentBLL.GetTreatmentClassList();
            cboTreatmentTitle.DataSource = aDataSet.Tables[0];
            cboTreatmentTitle.DisplayMember = "PersianName";
            cboTreatmentTitle.ValueMember = "TreatmentTitleID";
        }

        private void GetTreatmentList()
        {
            dgvTreatment.AutoGenerateColumns = false;
            DataSet aDataSet;
            aDataSet = FTreatmentBLL.GetTreatmentServiceList();

            DataColumn aDataColumn = new DataColumn("RowNumber");
            DataColumn bDataColumn = new DataColumn("ToothProp");

            aDataSet.Tables[0].Columns.Add(aDataColumn);
            aDataSet.Tables[0].Columns.Add(bDataColumn);

            for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
            {
                aDataSet.Tables[0].Rows[i]["RowNumber"] = i + 1;
                aDataSet.Tables[0].Rows[i]["ToothProp"] = GetToothProp((Int16)aDataSet.Tables[0].Rows[i]["ToothDirection"], (Int16)aDataSet.Tables[0].Rows[i]["ToothNumber"]);
            }
            dgvTreatment.DataSource = aDataSet.Tables[0];
        }

        private string GetToothProp(Int16 direction, Int16 number)
        {
            string ToothProp = string.Empty;

            switch (direction)
            {
                case 1:
                case 5:
                    ToothProp = "بالا - راست";
                    break;
                case 2:
                case 6:
                    ToothProp = "بالا - چپ";
                    break;
                case 3:
                case 7:
                    ToothProp = "پایین - چپ";
                    break;
                case 4:
                case 8:
                    ToothProp = "پایین - راست";
                    break;
                case 100:
                    ToothProp = "فک بالا";
                    break;
                case 200:
                    ToothProp = "فک پایین";
                    break;
                default:
                    break;
            }
            if (direction > 4 && direction < 100)
                number = (short)(number + 8);
            switch (number)
            {
                case 9:
                    ToothProp = ToothProp + " - A";
                    break;
                case 10:
                    ToothProp = ToothProp + " - B";
                    break;
                case 11:
                    ToothProp = ToothProp + " - C";
                    break;
                case 12:
                    ToothProp = ToothProp + " - D";
                    break;
                case 13:
                    ToothProp = ToothProp + " - E";
                    break;
                default:
                    ToothProp = ToothProp + " - " + number.ToString();
                    break;
            }

            return ToothProp;
        }

        private void dgvTreatment_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            oTreatment.TreatmentID = (int)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[0];
            oTreatment.TreatmentTitleID = (Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1];
            oTreatment.TreatmentCode = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7].ToString();
            oTreatment.ToothDirection = (Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3];
            oTreatment.ToothNumber = (Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[2];
            oTreatment.Price = (decimal)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4];
            oTreatment.InsurancePrice = (decimal)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5];
            oTreatment.DateOfRegister = Convert.ToDateTime(((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[6]);
            InitialForm(true);
        }

        private void cboTreatmentTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTreatmentTitle.SelectedIndex == -1)
                return;
            if ((byte)((DataRowView)cboTreatmentTitle.SelectedItem).Row.ItemArray[4] == 2)
            {

                //cboDirection.Enabled = false;
                AssignDirectionCombo(2);
                toothSelectMode = ToothSelectMode.TopDown;
                toothMode = ToothMode.Adult;
                cboNumber.SelectedIndex = -1;
                cboNumber.Enabled = false;
                //_directionRelpaced = (byte)((DataRowView)cboTreatmentTitle.SelectedItem).Row.ItemArray[6];
            }
            else
            {
                AssignDirectionCombo(4);
                toothSelectMode = ToothSelectMode.Separate;
                //cboDirection.Enabled = true;
                cboNumber.Enabled = true;
            }


            //if ((byte)((DataRowView)cboTreatmentTitle.SelectedItem).Row.ItemArray[5] == 0)
            //{
            //    cboNumber.Enabled = false;
            //    //_numberReplaced = (byte)((DataRowView)cboTreatmentTitle.SelectedItem).Row.ItemArray[7];
            //}
            //else
            //    cboNumber.Enabled = true;

        }

        private void cboNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNumber.SelectedIndex > 7)
                toothMode = ToothMode.Child;
            else
                toothMode = ToothMode.Adult;
        }



    }
}
