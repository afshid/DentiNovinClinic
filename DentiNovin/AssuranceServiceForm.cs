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
using DentiNovin.Properties;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class AssuranceServiceForm : MiddleBaseWinForm
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

        private AssuranceService _oAssuranceService;
        public AssuranceService OAssuranceService
        {
            get
            {
                if (_oAssuranceService == null)
                    _oAssuranceService = new AssuranceService();
                return _oAssuranceService;
            }
            set { _oAssuranceService = value; }
        }

        private DataSet aDataSet;
        Decimal _kCoeff = 1;
        int organPercent = 0;
        bool _allowRefresh = false;
        string _serviceCode = string.Empty;
        string _serviceName = string.Empty;
        int _assuranceID = 0;
        int _assuranceHeaderId = 0;

        public AssuranceServiceForm()
        {
            InitializeComponent();
        }

        private void AssuranceServiceForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            _assuranceID = ((MainForm)this.MdiParent).SelectedAssuranceID;
            switch (_assuranceID)
            {
                case 2:
                    _kCoeff = (decimal)Settings.Default["MoKCoeff"];
                    organPercent = (int)Settings.Default["MoOrganPercent"];
                    break;
                case 3:
                    _kCoeff = (decimal)Settings.Default["KhKCoeff"];
                    organPercent = (int)Settings.Default["KhOrganPercent"];
                    break;
                default:
                    _kCoeff = 0;
                    organPercent = 0;
                    break;
            }
            txtKCoeff.Text = _kCoeff.ToString();
            txtOrganPercent.Text = organPercent.ToString();
            dgvAssuranceServiceList.AutoGenerateColumns = false;
            GetServiceHeaderList();
            //GetAssuranceList();
            InitialForm(false);
            FillGrid();
            _allowRefresh = true;
        }

        public override void SetObject()
        {
            OAssuranceService.ServiceCode = txtServiceCode.Text.Trim();
            OAssuranceService.ServiceName = txtServiceName.Text.Trim();
            OAssuranceService.KPrice = Convert.ToInt32(txtServiceKPrice.Text.Trim());
            OAssuranceService.AssuranceID = _assuranceID;
            OAssuranceService.ServiceHeaderID = (int)((System.Data.DataRowView)(cboServiceHeader.SelectedItem)).Row.ItemArray[0];
            OAssuranceService.BaseOnK = chkBaseOnK.Checked;
            OAssuranceService.IsVisible = chkIsVisible.Checked;
            if (!chkBaseOnK.Checked)
                OAssuranceService.ServicePrice = Convert.ToDecimal(txtServicePrice.Text.Trim());
            else
                OAssuranceService.ServicePrice = 0;
        }

        public override void SaveInfo()
        {
            FTreatmentBLL.OAssuranceService = this.OAssuranceService;
            if (aPageMode == PageMode.Mode_new)
                SaveObject();
            else
                EditObject();
        }

        public override void SaveObject()
        {
            FTreatmentBLL.SaveAssuranceService();
        }

        public override void EditObject()
        {
            FTreatmentBLL.EditAssuranceService();
        }

        public override void FillGrid()
        {
            try
            {
                aDataSet = FTreatmentBLL.GetAssuranceServiceList(_serviceCode, "", _assuranceID, _assuranceHeaderId, _kCoeff, true);
                dgvAssuranceServiceList.DataSource = aDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1014");
                MessageBox.Show("بروز خطا در بارگزاری لیست خدمات بیمه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetServiceHeaderList()
        {
            try
            {
                DataSet aDataSet;
                DataSet bDataSet;
                aDataSet = FTreatmentBLL.GetServiceHeaderList(_assuranceID,true);
                cboServiceHeader.DataSource =aDataSet.Tables[0];
                cboServiceHeader.DisplayMember = "HeaderName";
                cboServiceHeader.ValueMember = "HeaderID";
                bDataSet = aDataSet.Copy();
                DataRow aDataRow = bDataSet.Tables[0].NewRow();
                aDataRow[0] = 0;
                aDataRow[1] = "تمامی گروه ها";
                bDataSet.Tables[0].Rows.InsertAt(aDataRow, 0);
                cboServiceHeaderSearch.DataSource = bDataSet.Tables[0];
                cboServiceHeaderSearch.DisplayMember = "HeaderName";
                cboServiceHeaderSearch.ValueMember = "HeaderID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1015");
                MessageBox.Show("بروز خطا در بارگزاری لیست گروه خدمات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GetAssuranceList()
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FAssuranceBLL.GetAssuranceList(true);
                DataTable aDataTable = new DataTable();
                aDataTable = aDataSet.Tables[0];
                cboAssurance.DataSource = aDataTable;
                cboAssurance.DisplayMember = "AssuranceName";
                cboAssurance.ValueMember = "AssuranceID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1016");
                MessageBox.Show("بروز خطا در بارگزاری لیست بیمه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public override void InitialForm(bool SetValue)
        {
            string serviceCode = string.Empty;
            string serviceName = string.Empty;
            string serviceKPrice = string.Empty;
            Decimal OrganShare = 0;
            Decimal patientShare = 0;
            Decimal servicePrice = 0;
            if (SetValue)
            {
                serviceCode = OAssuranceService.ServiceCode;
                serviceName = OAssuranceService.ServiceName;
                serviceKPrice = OAssuranceService.KPrice.ToString();
                cboAssurance.SelectedValue = OAssuranceService.AssuranceID;
                cboServiceHeader.SelectedValue = OAssuranceService.ServiceHeaderID;
                if (!OAssuranceService.BaseOnK)
                {
                    servicePrice = OAssuranceService.ServicePrice;
                    txtServicePrice.BackColor = txtServiceCode.BackColor;
                }
                else
                {
                    txtServicePrice.BackColor = txtKCoeff.BackColor;
                    servicePrice = OAssuranceService.KPrice * _kCoeff;
                }
                OrganShare = (OAssuranceService.KPrice * _kCoeff) * organPercent / 100;
                patientShare = (OAssuranceService.KPrice * _kCoeff) - OrganShare;
                aPageMode = PageMode.Mode_edit;
                btnSave.Text = "ویرایش";
                btnCancel.Enabled = true;
            }
            else
            {
                cboServiceHeader.SelectedIndex = -1;
                cboAssurance.SelectedIndex = -1;
                cboServiceHeaderSearch.SelectedIndex = 0;
                txtServicePrice.BackColor = txtKCoeff.BackColor;
                OrganShare =0;
                patientShare = 0;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancel.Enabled = false;
            }
            switch (_assuranceID)
            {
                case 2:
                    txtAssuranceName.Text = "نیروهای مسلح";
                    break;
                case 3:
                    txtAssuranceName.Text = "خدمات درمانی";
                    break;
                default:
                    txtAssuranceName.Text = "";
                    break;
            }
            chkBaseOnK.Checked = OAssuranceService.BaseOnK;
            chkIsVisible.Checked = OAssuranceService.IsVisible;
            txtServicePrice.ReadOnly = OAssuranceService.BaseOnK;
            txtServiceCode.Text = serviceCode;
            txtServiceName.Text = serviceName;
            txtServiceKPrice.Text = serviceKPrice;
            txtServicePrice.Text = servicePrice.ToString("#,0;(#,0)");
            txtOrganShare.Text = OrganShare.ToString("#,0;(#,0)");
            txtPatientShare.Text = patientShare.ToString("#,0;(#,0)");
        }

        public override void GetObjectList()
        {
            throw new NotImplementedException();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvAssuranceServiceList.SelectedRows.Count <= 0)
                return;
            dgvAssuranceServiceList_CellDoubleClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvAssuranceServiceList.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("رکورد مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    FTreatmentBLL.DeleteAssuranceService((Int64)((DataRowView)dgvAssuranceServiceList.SelectedRows[0].DataBoundItem).Row.ItemArray[3]);
                    InitialForm(false);
                    FillGrid();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show("بدلیل وجود نسخه ثبت شده شامل این خدمت، امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            OAssuranceService.ServiceID = (Int64)selectedDataRow.Row.ItemArray[3];
            OAssuranceService.ServiceCode = selectedDataRow.Row.ItemArray[9].ToString();
            //OAssuranceService.ServiceName = selectedDataRow.Row.ItemArray[1].ToString() + " - " + selectedDataRow.Row.ItemArray[4].ToString();
            OAssuranceService.ServiceName =selectedDataRow.Row.ItemArray[4].ToString();
            OAssuranceService.AssuranceID = (int)selectedDataRow.Row.ItemArray[8];
            OAssuranceService.ServiceHeaderID = (int)selectedDataRow.Row.ItemArray[10];
            OAssuranceService.KPrice = (int)selectedDataRow.Row.ItemArray[5];
            OAssuranceService.ServicePrice = (decimal)selectedDataRow.Row.ItemArray[6];
            OAssuranceService.IsVisible = (bool)selectedDataRow.Row.ItemArray[11];
            OAssuranceService.BaseOnK = (bool)selectedDataRow.Row.ItemArray[7];

        }

        private void dgvAssuranceServiceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SetSelectedObject((DataRowView)dgvAssuranceServiceList.SelectedRows[0].DataBoundItem);
            InitialForm(true);
        }

        private void dgvAssuranceServiceList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                this.dgvAssuranceServiceList.ContextMenuStrip = null;
                //contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvAssuranceServiceList.Rows[e.RowIndex].Selected = true;
                this.dgvAssuranceServiceList.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void dgvAssuranceServiceList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvAssuranceServiceList.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtServiceCode.Text.Trim() == "")
            {
                errorProvider1.SetError(txtServiceCode, "کد خدمت را وارد کنید");
                txtServiceCode.Focus();
                return;
            }
            
            if (cboServiceHeader.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboServiceHeader, "گروه خدمت را مشخص کنید");
                cboServiceHeader.Focus();
                return;
            }
            if (txtServiceName.Text.Trim() == "")
            {
                errorProvider1.SetError(txtServiceName, "شرح خدمت را وارد کنید");
                txtServiceName.Focus();
                return;
            }
            int _kPrice = 0;
            if (txtServiceKPrice.Text.Trim() == "" || !int.TryParse(txtServiceKPrice.Text.Trim(), out _kPrice))
            {
                errorProvider1.SetError(txtServiceKPrice, "تعرفه خدمت را وارد کنید");
                txtServiceKPrice.Focus();
                return;
            }


            decimal _servicePrice = 0;
            if (!chkBaseOnK.Checked && (txtServicePrice.Text.Trim() == "" || !decimal.TryParse(txtServicePrice.Text.Trim(), out _servicePrice)))
            {
                errorProvider1.SetError(txtServicePrice, "هزینه خدمت را وارد کنید");
                txtServicePrice.Focus();
                return;
            }

            SetObject();
            try
            {
               SaveInfo();
            }
            catch (Exception ex)
            {
                if (aPageMode == PageMode.Mode_new)
                {
                    UtilMethods.LogError(ex, "1018");
                    MessageBox.Show("بروز خطا در ثبت خدمت جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (aPageMode == PageMode.Mode_edit)
                {
                    UtilMethods.LogError(ex, "1019");
                    MessageBox.Show("بروز خطا در ویرایش خدمت مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            //FillGrid();
            InitialForm(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void ControlByZero_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender,this.errorProvider1, true);
        }

        private void senderControl_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void cboServiceHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillGrid();
        }

        private void chkBaseOnK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBaseOnK.Checked)
            {
                txtServicePrice.ReadOnly = true;
                txtServicePrice.BackColor = txtKCoeff.BackColor;
            }
            else
            {
                txtServicePrice.ReadOnly = false;
                txtServicePrice.BackColor = txtServiceCode.BackColor;
            }
        }

        private void cboAssurance_Leave(object sender, EventArgs e)
        {
            if(((ComboBox)sender).SelectedIndex!=-1)
                errorProvider1.Clear();
        }

        private void txtSeviceCodeSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_allowRefresh)
                return;
            _serviceCode = txtServiceCodeSearch.Text.Trim();
            _assuranceHeaderId = (int)((DataRowView)cboServiceHeaderSearch.SelectedItem).Row[0];
            FillGrid();
        }

        private void txtServiceKPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                    e.Handled = true;
            }
        }

    }
}
