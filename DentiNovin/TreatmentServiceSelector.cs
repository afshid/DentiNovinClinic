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
using DentiNovin.Common.DateConvert;
using DentiNovin.Properties;

namespace DentiNovin
{
    public partial class TreatmentServiceSelector : BaseForm
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

        public ServiceFilterType ServiceFilter = ServiceFilterType.ShowAll;

        private bool _showPersianName = true;
        bool _goToEvent = false;

        public event EventHandler TreatmentSelected;

        public TreatmentServiceSelector()
        {
            InitializeComponent();
            _showPersianName = (bool)Settings.Default["ShowPersianName"];
        }

        private void TreatmentServiceSelector_Load(object sender, EventArgs e)
        {
            GetTreatmentClassList();
            txtTreatmentNameSearch.Focus();
        }

        private void GetTreatmentClassList()
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FTreatmentBLL.GetTreatmentClassList();
                DataRow aDataRow = aDataSet.Tables[0].NewRow();
                aDataRow[0] = "00";
                aDataRow[3] = "تمامی دسته بندی ها";
                aDataSet.Tables[0].Rows.InsertAt(aDataRow, 0);
                cboTreatmentClass.DataSource = aDataSet.Tables[0];
                _goToEvent = true;
                cboTreatmentClass.DisplayMember = "LatinName";
                cboTreatmentClass.ValueMember = "TreatmentClassID";
                //cboTreatmentClass.Items.Add(aDataSet.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void GetTreatmentServiceList(ServiceFilterType sft, string currentDate, int treatmentClassID, string treatmentCode, string treatmentName)
        {
            dgvTreatment.AutoGenerateColumns = false;
            DataSet aDataSet;
            aDataSet = FTreatmentBLL.GetTreatmentServiceList(sft, currentDate, treatmentClassID, treatmentCode, treatmentName, _showPersianName);
            dgvTreatment.DataSource = aDataSet.Tables[0];
        }

        private void dgvTreatment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            this.oTreatment = null;
            this.oTreatment.TreatmentServiceID = (int)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1];
            this.oTreatment.TreatmentClassID = (Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[2];
            this.oTreatment.Code = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3].ToString();
            this.oTreatment.TreatmentArea =(Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8];
            this.oTreatment.PersianName = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            this.oTreatment.LatinName = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5].ToString();
            this.oTreatment.DrawType = (Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[9];
            this.oTreatment.BrushType = (Int16)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[10];
            this.oTreatment.BrushColor = (int)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[17];
            this.oTreatment.ShowRootInfoForm = (bool)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[18];
            this.oTreatment.MarkToothMissing = (bool)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[21];

            OnTreatmentSelected();
            this.Dispose();
        }

        private void cboTreatmentClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_goToEvent)
                return;
            GetTreatmentServiceList(ServiceFilter, "", (int)((System.Data.DataRowView)(cboTreatmentClass.SelectedItem)).Row.ItemArray[0], string.Empty, txtTreatmentNameSearch.Text.Trim());
        }

        private void OnTreatmentSelected()
        {
            if (TreatmentSelected != null)
                TreatmentSelected(this, null);
        }

        private void txtTreatmentNameSearch_TextChanged(object sender, EventArgs e)
        {
            GetTreatmentServiceList(ServiceFilter, "", (int)((System.Data.DataRowView)(cboTreatmentClass.SelectedItem)).Row.ItemArray[0], string.Empty, txtTreatmentNameSearch.Text.Trim());
        }
    }
}
