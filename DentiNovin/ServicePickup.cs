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

namespace DentiNovin
{
    public partial class ServicePickup : BaseForm
    {
        private AssuranceService _oAssuranceService;
        public AssuranceService OAssuranceService
        {
            get
            {
                return _oAssuranceService;
            }
            set { _oAssuranceService = value; }
        }


        private AssuranceBLL _fAssuranceBLL;
        public AssuranceBLL FAssuranceBLL
        {
            get
            {
                if (_fAssuranceBLL == null)
                    _fAssuranceBLL = new AssuranceBLL();
                return _fAssuranceBLL;
            }
            set
            {
                _fAssuranceBLL = value;
            }
        }

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

        private DataSet aDataSet;

        public int AssuranceID { get; set; }

        public string AssuranceName { get; set; }

        public decimal SelectedOrganKCoeff { get; set; }

        public event EventHandler ServiceAdded;

        public ServicePickup()
        {
            InitializeComponent();
        }

        private void ServicePickup_Load(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            dgvAssuranceServiceList.AutoGenerateColumns = false;
            GetServiceHeaderList();
            //cboAssurance.SelectedValue = AssuranceID;
            txtAssuranceName.Text = AssuranceName;
            //FilldgvAssuranceServiceList("", "", 0);
        }

        private void GetServiceHeaderList()
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FTreatmentBLL.GetServiceHeaderList(AssuranceID,true);
                DataTable aDataTable = new DataTable();
                aDataTable = aDataSet.Tables[0];
                DataRow aDataRow = aDataTable.NewRow();
                aDataRow[0] = 0;
                aDataRow[1] = "تمامی گروه ها";
                aDataTable.Rows.InsertAt(aDataRow, 0);
                cboServiceHeader.DataSource = aDataTable;
                cboServiceHeader.DisplayMember = "HeaderName";
                cboServiceHeader.ValueMember = "HeaderID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1056");
                MessageBox.Show("بروز خطا در بارگزاری لیست گروه خدمات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FilldgvAssuranceServiceList(string serviceCode, string serviceName, int assuranceID, int serviceHeaderID)
        {
            aDataSet = FTreatmentBLL.GetAssuranceServiceList(serviceCode, serviceName, assuranceID, serviceHeaderID, SelectedOrganKCoeff, false);
            dgvAssuranceServiceList.DataSource = aDataSet.Tables[0];
        }

        private void txtSeviceCode_TextChanged(object sender, EventArgs e)
        {
            string _serviceCode = string.Empty;
            string _serviceName = string.Empty;
            _serviceName = txtServiceName.Text.Trim();
            _serviceCode = txtSeviceCode.Text.Trim();
            FilldgvAssuranceServiceList(_serviceCode, _serviceName, AssuranceID, Convert.ToInt32(((DataRowView)cboServiceHeader.SelectedItem).Row[0]));
        }

        private void dgvAssuranceServiceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            OAssuranceService.ServiceID = (Int64)((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3];
            OAssuranceService.ServiceCode = ((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[9].ToString();
            OAssuranceService.ServiceName = ((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1].ToString() + " - " + ((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            OAssuranceService.KPrice = (int)((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5];
            OAssuranceService.ServicePrice = (decimal)((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[6];
            OAssuranceService.BaseOnK = (bool)((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7];
            //FTreatmentBLL.AssuranceServiceDetailsUsedCountIncrease((Int64)((System.Data.DataRowView)(dgvAssuranceServiceList.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3]);
            OnServiceAdded();
            this.Close();
        }


        private void OnServiceAdded()
        {
            if (ServiceAdded != null)
                ServiceAdded(this, null);
        }

        private void cboServiceHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _serviceCode = string.Empty;
            string _serviceName = string.Empty;
            _serviceName = txtServiceName.Text.Trim();
            _serviceCode = txtSeviceCode.Text.Trim();
            FTreatmentBLL.AssuranceServiceHeaderUsedCountIncrease((int)((DataRowView)cboServiceHeader.SelectedItem).Row[0]);
            FilldgvAssuranceServiceList(_serviceCode, _serviceName, AssuranceID, Convert.ToInt32(((DataRowView)cboServiceHeader.SelectedItem).Row[0]));

        }

    }
}
