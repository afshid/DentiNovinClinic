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
using DentiNovin.BusinessLogic;
using DentiNovin.Properties;

namespace DentiNovin
{
    public partial class DentiReportsMakerForm : BaseForm
    {
        private AppointmentBLL _fAppointmentFormBLL;
        public AppointmentBLL FAppointmentFormBLL
        {
            get
            {
                if (_fAppointmentFormBLL == null)
                    _fAppointmentFormBLL = new AppointmentBLL();
                return _fAppointmentFormBLL;
            }
            set
            {
                _fAppointmentFormBLL = value;
            }
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

        private DoctorBll _fDoctorBLL;
        public DoctorBll FDoctorBLL
        {
            get
            {
                if (_fDoctorBLL == null)
                    _fDoctorBLL = new DoctorBll();
                return _fDoctorBLL;
            }
            set
            {
                _fDoctorBLL = value;
            }
        }

        private PatientTreatmentBLL _fPatientTreatmentBLL;
        public PatientTreatmentBLL FPatientTreatmentBLL
        {
            get
            {
                if (_fPatientTreatmentBLL == null)
                    _fPatientTreatmentBLL = new PatientTreatmentBLL();
                return _fPatientTreatmentBLL;
            }
            set
            {
                _fPatientTreatmentBLL = value;
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

        private Boolean _fileNumberChanged = false;

        private int[] SelectedPETNSList;
        private string[] SelectedPRTNSList;
        private NumberingSystem SelectedNumberingSystem;

        private int _g4OldTop = 0;
        private int _g5OldTop = 0;
        const int g4NewTop = 22;
        const int g5NewTop = 36;
        int _correctG4Top = 0;
        int _correctG5Top = 0;
        bool _runSearch = false;
        DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();

        DataGridViewCellStyle dataGridViewCurrencyCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

        DataSet aDataSet;
        private bool _showPersianName = true;

        public DentiReportsMakerForm()
        {
            InitializeComponent();
            _showPersianName = (bool)Settings.Default["ShowPersianName"];
        }

        private void DentiReportsMakerForm_Load(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            SelectedNumberingSystem=(NumberingSystem)Settings.Default["NumberingSystem"];
            switch (SelectedNumberingSystem)
            {
                case NumberingSystem.UniversalSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).PermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).PrimaryToothNumberList;
                    break;
                case NumberingSystem.FdiSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).FdiPermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).FdiPrimaryToothNumberList;
                    break;
                case NumberingSystem.PalmerSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).PlrPermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).PlrPrimaryToothNumberList;
                    break;
                default:
                    break;
            }
            dataGridViewCurrencyCellStyle.Format = "#,0;(#,0)";
            dataGridViewCellStyle.Format = "";
            fdpStartRangeDate.SelectedDateTime = DateTime.Now;
            fdpEndRangeDate.SelectedDateTime = DateTime.Now;
            dgvDentiReport.AutoGenerateColumns = false;
            dgvDentiReport.RightToLeft = RightToLeft.Yes;
            _g4OldTop = groupBox4.Top;
            _g5OldTop = groupBox5.Top;
            CreateTreeViewItems();
            try
            {
                GetDoctorList();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1026");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateTreeViewItems()
        {
            TreeNode aTreeNode;
            string descriptiontemp = string.Empty;
            Dictionary<DentiReport, string> _dentiReportsList = new Dictionary<DentiReport, string>();
            foreach (DentiReport dr in Enum.GetValues(typeof(DentiReport)))
            {
                if ((int)dr == 0 || (int)dr == 3 || (int)dr == 5)
                    continue;
                descriptiontemp = UtilMethods.GetEnumDescription(dr);
                _dentiReportsList.Add(dr, descriptiontemp);
                aTreeNode = new TreeNode(descriptiontemp);
                aTreeNode.Tag = dr;
                trwReportsList.Nodes[0].Nodes.Add(aTreeNode);
            }
            trwReportsList.Nodes[0].ExpandAll();
        }

        private void trwReportsList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _runSearch = false;
            dgvDentiReport.DataSource = null;
            if (e.Node.Parent == null || e.Node.Tag == null)
            {
                btnPrint.Enabled = false;

                dgvDentiReport.Columns.Clear();
                SetSearchFormFields(DentiReport.PatientTreatmentReport);
            }
            else
            {
                _runSearch = true;
                btnPrint.Enabled = true;
                SetSearchFormFields((DentiReport)e.Node.Tag);
                GridViewColumnMaker((DentiReport)e.Node.Tag);
                btnSearch_Click(null, null);
            }

        }

        private DataSet CreatePatientVisitsReport()
        {

            return FAppointmentFormBLL.GetVisitsReportList(OPatient.PatientID, Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]), fdpStartRangeDate.Text, fdpEndRangeDate.Text);
        }

        private DataSet CreatePatientsBillsReport(bool withBillID)
        {
            return FBillBLL.GetBillsReportList(OPatient.PatientID, 0, fdpStartRangeDate.Text, fdpEndRangeDate.Text, true, withBillID);
        }

        private DataSet CreateDoctorsBillsReport(bool withBillID)
        {
            return FBillBLL.GetBillsReportList(0, Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]), fdpStartRangeDate.Text, fdpEndRangeDate.Text, false, withBillID);
        }

        private DataSet CreateTreatmentsReport()
        {
            return FPatientTreatmentBLL.GetTreatmentsReportList(OPatient.PatientID, Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]), fdpStartRangeDate.Text, fdpEndRangeDate.Text, _showPersianName);
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
            setPatientInfo();
            if (!_runSearch == true)
                return;
            btnSearch_Click(null, null);
        }

        public void setPatientInfo()
        {
            if (this.OPatient.PatientID != 0)
            {
                txtFileNumber.Text = this.OPatient.FileNumber.ToString();
                _fileNumberChanged = false;
                txtPatientLastName.Text = this.OPatient.LastName;
                _fileNumberChanged = false;
            }
            else
            {
                this.OPatient = null;
                txtPatientLastName.Text = "";
                _fileNumberChanged = false;
                if (txtFileNumber.Text.Trim() == string.Empty)
                    return;
                txtFileNumber.Focus();
                txtFileNumber.SelectionStart = 0;
                txtFileNumber.SelectionLength = txtFileNumber.TextLength;
            }

        }

        private void txtFileNumber_Leave(object sender, EventArgs e)
        {
            int _fileNumber = 0;
            if (!int.TryParse(txtFileNumber.Text.Trim(), out _fileNumber) || txtFileNumber.Text.Trim() == "0")
                OPatient.PatientID = 0;
            else
                if (_fileNumberChanged && _fileNumber != 0)
                    GetPatient();
                else
                    return;

            setPatientInfo();
            if (!_runSearch == true)
                return;
            btnSearch_Click(null, null);
        }

        public void GetPatient()
        {
            int _fileNumber = 0;
            if (!int.TryParse(txtFileNumber.Text.Trim(), out _fileNumber))
                return;
            this.OPatient.PatientID = 0;
            OPatient.FileNumber = Convert.ToInt32(txtFileNumber.Text);
            FAppointmentFormBLL.OPatient = this.OPatient;
            try
            {
                FAppointmentFormBLL.GetPatient();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1027");
                MessageBox.Show("بروز خطا در دریافت اطلاعات بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtFileNumber_TextChanged(object sender, EventArgs e)
        {
            _fileNumberChanged = true;
        }

        private void GetDoctorList()
        {
            DataSet aDataSet;//=new DataSet();
            aDataSet = FDoctorBLL.GetDoctorList(true);
            DataRow aDataRow = aDataSet.Tables[0].NewRow();
            aDataRow[0] = 0;
            aDataRow[2] = "تمامی پزشکان";
            aDataSet.Tables[0].Rows.InsertAt(aDataRow, 0);
            cbxDoctor.DataSource = aDataSet.Tables[0];
            cbxDoctor.DisplayMember = "LastName";
            cbxDoctor.ValueMember = "DoctorID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch ((DentiReport)trwReportsList.SelectedNode.Tag)
            {
                case DentiReport.PatientsVisitsReport:
                    aDataSet = CreatePatientVisitsReport();
                    dgvDentiReport.DataSource = aDataSet.Tables[0];
                    break;
                case DentiReport.PatientsBillReport:
                    aDataSet = CreatePatientsBillsReport(chkWithBillID.Checked);
                    dgvDentiReport.DataSource = aDataSet.Tables[0];
                    break;
                case DentiReport.DoctorsBillReport:
                    aDataSet = CreateDoctorsBillsReport(chkWithBillID.Checked);
                    dgvDentiReport.DataSource = aDataSet.Tables[0];
                    break;
                case DentiReport.PatientTreatmentListReport:
                    aDataSet = CreateTreatmentsReport();
                    DataColumn aDataColumn = new DataColumn("ToothNumberConverted");
                    aDataSet.Tables[0].Columns.Add(aDataColumn);
                    DataColumn bDataColumn = new DataColumn("FaToothDirection");
                    aDataSet.Tables[0].Columns.Add(bDataColumn);
                    for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                    {
                        string normalNumberString = string.Empty;
                        if (aDataSet.Tables[0].Rows[i]["ToothCode"] == System.DBNull.Value)
                            aDataSet.Tables[0].Rows[i]["ToothCode"] = 0;
                        if ((byte)aDataSet.Tables[0].Rows[i]["ToothType"] == (int)ToothType.Primary)
                            normalNumberString = this.SelectedPRTNSList[(byte)aDataSet.Tables[0].Rows[i]["ToothCode"] - 1];
                        else
                            normalNumberString = this.SelectedPETNSList[(byte)aDataSet.Tables[0].Rows[i]["ToothCode"] - 1].ToString();

                        aDataSet.Tables[0].Rows[i]["ToothNumberConverted"] = UtilMethods.GetToothNumberString((byte)aDataSet.Tables[0].Rows[i]["ToothCode"], (Int16)aDataSet.Tables[0].Rows[i]["TreatmentArea"], normalNumberString);
                        aDataSet.Tables[0].Rows[i]["FaToothDirection"] = UtilMethods.GetToothDirectionString((Byte)aDataSet.Tables[0].Rows[i]["ToothCode"], (Int16)aDataSet.Tables[0].Rows[i]["TreatmentArea"]);
                    }
                    dgvDentiReport.DataSource = aDataSet.Tables[0];
                    if (this.SelectedNumberingSystem == NumberingSystem.PalmerSystem)
                        dgvDentiReport.Columns[7].Visible = true;
                    else
                        dgvDentiReport.Columns[7].Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void SetSearchFormFields(DentiReport reportType)
        {
            bool showPatient = true;
            bool showDocotr = true;
            chkWithBillID.Visible = false;
            switch (reportType)
            {
                case DentiReport.PatientsVisitsReport:
                    showPatient = true;
                    showDocotr = true;
                    _correctG4Top = _g4OldTop;
                    _correctG5Top = _g5OldTop;
                    break;
                case DentiReport.PatientsBillReport:
                    showPatient = true;
                    showDocotr = false;
                    _correctG4Top = g4NewTop;
                    _correctG5Top = g5NewTop;
                    chkWithBillID.Visible = true;
                    break;
                case DentiReport.DoctorsBillReport:
                    showPatient = false;
                    showDocotr = true;
                    _correctG4Top = g4NewTop;
                    _correctG5Top = g5NewTop;
                    chkWithBillID.Visible = true;
                    break;
                case DentiReport.PatientTreatmentListReport:
                    showPatient = true;
                    showDocotr = true;
                    _correctG4Top = _g4OldTop;
                    _correctG5Top = _g5OldTop;
                    break;
                default:
                    break;
            }
            groupBox4.Visible = showPatient;
            groupBox5.Visible = showDocotr;
            groupBox4.Top = _correctG4Top;
            groupBox5.Top = _correctG5Top;
        }

        private void GridViewColumnMaker(DentiReport reportType)
        {

            dgvDentiReport.Columns.Clear();
            dgvDentiReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            Column1.DataPropertyName = "RowNumber";
            Column1.FillWeight = 25F;
            Column1.HeaderText = "ردیف";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Resizable = DataGridViewTriState.False;
            Column1.SortMode = DataGridViewColumnSortMode.NotSortable;

            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Resizable = DataGridViewTriState.False;
            Column2.SortMode = DataGridViewColumnSortMode.NotSortable;

            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Resizable = DataGridViewTriState.False;
            Column3.SortMode = DataGridViewColumnSortMode.NotSortable;

            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Resizable = DataGridViewTriState.False;
            Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column4.Visible = true;

            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Column5.SortMode = DataGridViewColumnSortMode.NotSortable;

            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Resizable = DataGridViewTriState.False;
            Column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column6.DefaultCellStyle = dataGridViewCellStyle;

            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Resizable = DataGridViewTriState.False;
            Column7.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column7.DefaultCellStyle = dataGridViewCellStyle;
            Column7.Visible = true;

            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Resizable = DataGridViewTriState.False;
            Column8.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column8.DefaultCellStyle = dataGridViewCellStyle;
            Column8.Visible = true;

            switch (reportType)
            {
                case DentiReport.PatientsVisitsReport:
                    Column2.DataPropertyName = "FileNumber";
                    Column2.FillWeight = 50F;
                    Column2.HeaderText = "شماره پرونده";
                    Column3.DataPropertyName = "PatientFullName";
                    Column3.FillWeight = 100F;
                    Column3.HeaderText = "نام و نام خانوادگی بیمار";
                    Column4.DataPropertyName = "DoctorFullName";
                    Column4.FillWeight = 100F;
                    Column4.HeaderText = "نام و نام خانوادگی پزشک";
                    Column5.DataPropertyName = "VisitDate";
                    Column5.FillWeight = 70F;
                    Column5.HeaderText = "تاریخ";
                    Column6.DataPropertyName = "VisitTime";
                    Column6.FillWeight = 60F;
                    Column6.HeaderText = "ساعت";
                    Column7.Visible = false;
                    Column8.Visible = false;
                    break;
                case DentiReport.PatientsBillReport:
                    Column2.DataPropertyName = "FileNumber";
                    Column2.FillWeight = 50F;
                    Column2.HeaderText = "شماره پرونده";
                    Column3.DataPropertyName = "PatientFullName";
                    Column3.FillWeight = 100F;
                    Column3.HeaderText = "نام و نام خانوادگی بیمار";
                    Column4.Visible = false;
                    if (chkWithBillID.Checked)
                    {
                        Column4.DataPropertyName = "BillID";
                        Column4.FillWeight = 50F;
                        Column4.HeaderText = "کد حساب";
                        Column4.Visible = true;
                    }
                    Column5.DataPropertyName = "TreatmentCount";
                    Column5.FillWeight = 50F;
                    Column5.HeaderText = "تعداد درمانها";
                    Column6.DataPropertyName = "SumFeesPayable";
                    Column6.FillWeight = 70F;
                    Column6.DefaultCellStyle = dataGridViewCurrencyCellStyle;
                    Column6.HeaderText = "هزینه قابل پرداخت";
                    Column7.DataPropertyName = "SumFeesReceived";
                    Column7.FillWeight = 60F;
                    Column7.DefaultCellStyle = dataGridViewCurrencyCellStyle;
                    Column7.HeaderText = "مبلغ پرداختی";
                    Column8.DataPropertyName = "SumFeesRemained";
                    Column8.FillWeight = 50F;
                    Column8.DefaultCellStyle = dataGridViewCurrencyCellStyle;
                    Column8.HeaderText = "مانده حساب";

                    break;
                case DentiReport.DoctorsBillReport:
                    Column2.DataPropertyName = "Code";
                    Column2.FillWeight = 50F;
                    Column2.HeaderText = "کد نظام پزشکی";
                    Column3.DataPropertyName = "DoctorFullName";
                    Column3.FillWeight = 100F;
                    Column3.HeaderText = "نام و نام خانوادگی پزشک";
                    Column4.Visible = false;
                    if (chkWithBillID.Checked)
                    {
                        Column4.DataPropertyName = "BillID";
                        Column4.FillWeight = 50F;
                        Column4.HeaderText = "کد حساب";
                        Column4.Visible = true;
                    }
                    Column5.DataPropertyName = "TreatmentCount";
                    Column5.FillWeight = 50F;
                    Column5.HeaderText = "تعداد درمانها";
                    Column6.DataPropertyName = "SumFeesPayable";
                    Column6.FillWeight = 70F;
                    Column6.DefaultCellStyle = dataGridViewCurrencyCellStyle;
                    Column6.HeaderText = "هزینه قابل پرداخت";
                    Column7.DataPropertyName = "SumFeesReceived";
                    Column7.FillWeight = 60F;
                    Column7.DefaultCellStyle = dataGridViewCurrencyCellStyle;
                    Column7.HeaderText = "مبلغ پرداختی";
                    Column8.DataPropertyName = "SumFeesRemained";
                    Column8.FillWeight = 50F;
                    Column8.DefaultCellStyle = dataGridViewCurrencyCellStyle;
                    Column8.HeaderText = "مانده حساب";
                    break;
                case DentiReport.PatientTreatmentListReport:
                    Column2.DataPropertyName = "FileNumber";
                    Column2.FillWeight = 40F;
                    Column2.HeaderText = "شماره پرونده";
                    Column3.DataPropertyName = "PatientFullName";
                    Column3.FillWeight = 92F;
                    Column3.HeaderText = "نام و نام خانوادگی بیمار";
                    Column4.DataPropertyName = "DoctorFullName";
                    Column4.FillWeight = 90F;
                    Column4.HeaderText = "نام و نام خانوادگی پزشک";
                    Column5.DataPropertyName = "TreatmentServiceName";
                    Column5.FillWeight = 110F;
                    Column5.HeaderText = "نام درمان";
                    Column6.DataPropertyName = "ToothNumberConverted";
                    Column6.FillWeight = 38F;
                    Column6.HeaderText = "شماره دندان";
                    Column7.DataPropertyName = "FaToothDirection";
                    Column7.FillWeight = 40F;
                    Column7.HeaderText = "جهت دندان";
                    Column7.Visible = true;
                    Column8.DataPropertyName = "VisitDate";
                    Column8.FillWeight = 40F;
                    Column8.HeaderText = "تاریخ";
                    Column8.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DentiReportsViewerForm aDentiReportsViewerForm = new DentiReportsViewerForm();
            aDentiReportsViewerForm.ReportType = (DentiReport)trwReportsList.SelectedNode.Tag;
            ReportHeader aReportHeader = new ReportHeader();
            aReportHeader.StartDate = fdpStartRangeDate.Text;
            aReportHeader.EndDate = fdpEndRangeDate.Text;
            aReportHeader.PatientFileNumber = OPatient.FileNumber.ToString();
            aReportHeader.PatientFullName = OPatient.LastName + " - " + OPatient.FirstName;
            aReportHeader.DoctorCode = "";
            aReportHeader.DoctorFullName = "";
            if (chkWithBillID.Visible)
                aDentiReportsViewerForm.ShowBillID = chkWithBillID.Checked;
            aDentiReportsViewerForm.ReportHeader.Add(aReportHeader);
            aDentiReportsViewerForm.ReportDataSet.Add(aDataSet.Copy());
            aDentiReportsViewerForm.MdiParent = this.MdiParent;
            aDentiReportsViewerForm.Show();
        }

        private void chkWithBillID_CheckedChanged(object sender, EventArgs e)
        {
            dgvDentiReport.DataSource = null;
            GridViewColumnMaker((DentiReport)trwReportsList.SelectedNode.Tag);
            if (!_runSearch == true)
                return;
            btnSearch_Click(null, null); ;
        }

        private void cbxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_runSearch == true)
                return;
            btnSearch_Click(null, null); ;
        }

        private void fdpStartRangeDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_runSearch == true)
                return;
            btnSearch_Click(null, null); ;
        }

        private void fdpEndRangeDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_runSearch == true)
                return;
            btnSearch_Click(null, null); ;
        }
    }
}
