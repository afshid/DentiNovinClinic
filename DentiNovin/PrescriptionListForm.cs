using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common.DateConvert;
using DentiNovin.BusinessLogic;
using DentiNovin.Common;
using System.IO;
//using Jacksonsoft;
using DentiNovin.Properties;
using Microsoft.Reporting.WinForms;
using DentiNovin.BaseClasses;
using Stimulsoft.Report;

namespace DentiNovin
{
    public partial class PrescriptionListForm : MiddleBaseWinForm
    {
        private PersianCalendar pc;
        private bool useAscii;
        private bool standardXml;
        private string medCenterCode = string.Empty;
        private string medCenterName = string.Empty;
        private bool isMedCenter = false;

        private bool useNewLine;
        private string organServiceCode = string.Empty;
        private int _organPercent = 0;
        private int _visitOrganPercent = 0;
        string _code = string.Empty;
        string _name = string.Empty;
        decimal _sumServicePrice = 0;
        decimal _sumOrganPay = 0;
        decimal _sumPatientPay = 0;
        decimal _servicePrice = 0;
        decimal _itemServicePrice = 0;
        decimal _itemOrganPay = 0;
        decimal _itemPatientPay = 0;
        decimal _organShare = 0;
        string _sex = string.Empty;
        private Int64 visitServiceID = 0;

        private PrescriptionBLL _fPrescriptionBLL;
        public PrescriptionBLL FPrescriptionBLL
        {
            get
            {
                if (_fPrescriptionBLL == null)
                    _fPrescriptionBLL = new PrescriptionBLL();
                return _fPrescriptionBLL;
            }
            set
            {
                _fPrescriptionBLL = value;
            }
        }

        private PatientBLL _fPatientBLL;
        public PatientBLL FPatientBLL
        {
            get
            {
                if (_fPatientBLL == null)
                    _fPatientBLL = new PatientBLL();
                return _fPatientBLL;
            }
            set
            {
                _fPatientBLL = value;
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

        private Prescription _oPrescription;
        public Prescription OPrescription
        {
            get
            {
                if (_oPrescription == null)
                    _oPrescription = new Prescription();
                return _oPrescription;
            }
            set { _oPrescription = value; }
        }

        bool _refreshGrid = false;

        private Dictionary<Int64, BindingList<AssuranceService>> _prescritionDic;

        ReportParameter[] _parameters = new ReportParameter[4];

        DataSet _prescriptionDataSet;

        Dictionary<string, DataTable> reportDataSource;

        public PrescriptionListForm()
        {
            InitializeComponent();
        }

        private Boolean _yearChanged = false;

        private void PrescriptionListForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            isMedCenter = (bool)Settings.Default["IsMedCenter"];
            _prescritionDic = new Dictionary<Int64, BindingList<AssuranceService>>();
            pc = new PersianCalendar();
            //FilldgvPrescriptionGroup();
            try
            {
                GetDoctorList();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1051");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GetAssuranceList();
            txtYear.Text = pc.GetYear(DateTime.Now).ToString();
            cboMonth.SelectedIndex = pc.GetMonth(DateTime.Now) - 1;
            FilldgvPrescriptionList(PersianDateConverter.ToPersianDate(DateTime.Now).Year, PersianDateConverter.ToPersianDate(DateTime.Now).Month, 0, Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]));
            this.useAscii = (bool)Settings.Default["CodingType"];
            this.standardXml = !(bool)Settings.Default["FileType"];

            _refreshGrid = true;
        }

        private void GetAssuranceList()
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FAssuranceBLL.GetAssuranceList(true);
                //DataTable aDataTable;// = new DataTable();
                //aDataTable = aDataSet.Tables[0];
                //DataRow aDataRow = aDataTable.NewRow();
                //aDataRow[0] = 0;
                //aDataRow[1] = "همه انواع بیمه";
                //aDataTable.Rows.InsertAt(aDataRow, 0);
                //cboAssurance.DataSource = aDataTable;
                cboAssurance.DataSource = aDataSet.Tables[0];
                cboAssurance.DisplayMember = "AssuranceName";
                cboAssurance.ValueMember = "AssuranceID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1052");
                MessageBox.Show("بروز خطا در بارگزاری لیست بیمه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetDoctorList()
        {
            DataSet aDataSet;
            aDataSet = FDoctorBLL.GetDoctorList(true);
            DataTable aDataTable;//=new DataTable();
            aDataTable = aDataSet.Tables[0];
            if (aDataTable.Rows.Count > 1)
            {
                DataRow aDataRow = aDataTable.NewRow();
                aDataRow[0] = 0;
                aDataRow[2] = "همه پزشکان";
                aDataTable.Rows.InsertAt(aDataRow, 0);
            }
            cboDoctor.DataSource = aDataTable;
            cboDoctor.DisplayMember = "LastName";
            cboDoctor.ValueMember = "DoctorID";
        }

        //private void FilldgvPrescriptionGroup()
        //{
        //    DataSet ds = FPrescriptionBLL.GetPrescritionGroupList();
        //    dgvPrescriptionGroup.DataSource = ds.Tables[0];
        //}

        private void FilldgvPrescriptionList(int year, int month, int assuranceID, int doctorID)
        {
            try
            {
                _prescriptionDataSet = FPrescriptionBLL.GetPrescriptionList(year, month, assuranceID, doctorID);
                dgvPrescriptionList.AutoGenerateColumns = false;
                dgvPrescriptionList.DataSource = _prescriptionDataSet.Tables[0];
                DetailsListCreator(_prescriptionDataSet.Tables[1]);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1053");
                MessageBox.Show("بروز خطا در بارگزاری لیست نسخه های ثبت شده", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPrescrpition_Click(object sender, EventArgs e)
        {
            PrescriptionForm aPrescriptionForm = new PrescriptionForm();
            aPrescriptionForm.PrescriptionSaved += new EventHandler(aPrescriptionForm_PrescriptionSaved);
            aPrescriptionForm.ShowDialog();
        }

        private void aPrescriptionForm_PrescriptionSaved(object sender, EventArgs e)
        {
            Int32 _year = Convert.ToInt32(txtYear.Text.Trim());
            FilldgvPrescriptionList(_year, cboMonth.SelectedIndex + 1, Convert.ToInt32(((DataRowView)cboAssurance.SelectedItem).Row[0]), Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]));
        }

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_refreshGrid)
                return;
            btnDisketteCreator.Enabled = false;
            btnCDCreator.Enabled = false;
            btnReportCreator.Enabled = false;
            //if (cboAssurance.SelectedIndex > 0 && ((isMedCenter && cboDoctor.SelectedIndex == 0) || (!isMedCenter && cboDoctor.SelectedIndex > 0)))
            if (((isMedCenter && cboDoctor.SelectedIndex == 0) || (!isMedCenter && cboDoctor.SelectedIndex > 0)))
            {
                btnDisketteCreator.Enabled = true;
                btnCDCreator.Enabled = true;
                btnReportCreator.Enabled = true;
            }
            Int32 _year = Convert.ToInt32(txtYear.Text.Trim());
            FilldgvPrescriptionList(_year, cboMonth.SelectedIndex + 1, Convert.ToInt32(((DataRowView)cboAssurance.SelectedItem).Row[0]), Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]));

        }

        private void txtYear_Leave(object sender, EventArgs e)
        {

            if (_yearChanged && txtYear.Text.Trim() != "")
                errorProvider1.Clear();
            if (!_refreshGrid)
                return;
            Int32 _year = Convert.ToInt32(txtYear.Text.Trim());
            FilldgvPrescriptionList(_year, cboMonth.SelectedIndex + 1, Convert.ToInt32(((DataRowView)cboAssurance.SelectedItem).Row[0]), Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]));

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            int _year = 0;
            if (!int.TryParse(txtYear.Text.Trim(), out _year))
            {
                errorProvider1.SetError(txtYear, "عدد سال را صحیح وارد کنید");
                txtYear.Focus();
                return;
            }
            _yearChanged = true;
        }

        private void dgvPrescriptionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            // DetailsListCreator(_prescriptionDataSet.Tables[1]);
            try
            {
                PrescriptionForm aPrescriptionForm = new PrescriptionForm();
                aPrescriptionForm.PrescriptionSaved += new EventHandler(aPrescriptionForm_PrescriptionSaved);
                SetSelectedObject((DataRowView)dgvPrescriptionList.SelectedRows[0].DataBoundItem);
                aPrescriptionForm.OPrescription = this.OPrescription;
                aPrescriptionForm.aPageMode = PageMode.Mode_edit;
                aPrescriptionForm.ShowDialog();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1053");
                MessageBox.Show("بروز خطا در دریافت اطلاعات نسخه ثبت شده", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            OPrescription.PrescriptionID = (Int64)selectedDataRow.Row.ItemArray[1];
            OPrescription.DoctorID = (Int32)selectedDataRow.Row.ItemArray[3];
            OPrescription.AssuranceCode = selectedDataRow.Row.ItemArray[4].ToString();
            OPrescription.ActionDate = selectedDataRow.Row.ItemArray[5].ToString();
            OPrescription.PageNumber = (int)selectedDataRow.Row.ItemArray[6];
            OPrescription.PatientPayment = (Decimal)selectedDataRow.Row.ItemArray[9];
            OPrescription.IsReferenced = (bool)selectedDataRow.Row.ItemArray[7];
            OPrescription.ReferencedDate = selectedDataRow.Row.ItemArray[8].ToString();
            OPrescription.KCoeff = (Decimal)selectedDataRow.Row.ItemArray[10];
            OPrescription.VisitPrice = (Decimal)selectedDataRow.Row.ItemArray[11];
            OPrescription.AssuranceServiceList = (BindingList<AssuranceService>)_prescritionDic[(Int64)selectedDataRow.Row.ItemArray[1]];
            //foreach (AssuranceService aS in OPrescription.AssuranceServiceList)
            //{
            //    if (aS.ServiceID == 1)
            //        aS.ServicePrice = OPrescription.VisitPrice;
            //    else
            //        aS.ServicePrice = aS.KPrice * OPrescription.KCoeff;

            //}
        }

        private void DetailsListCreator(DataTable detailsDT)
        {
            Int64 prescritionHID = 0;
            Int64 prescritionDID = 0;
            _prescritionDic.Clear();
            for (int i = 0; i < detailsDT.Rows.Count; i++)
            {
                AssuranceService aAssuranceService = new AssuranceService();
                aAssuranceService.ServiceID = (Int64)detailsDT.Rows[i]["AssuranceServiceID"];
                aAssuranceService.ServiceCode = detailsDT.Rows[i]["ServiceCode"].ToString();
                aAssuranceService.ServiceName = detailsDT.Rows[i]["ServiceName"].ToString();
                aAssuranceService.AssuranceID = (Int32)detailsDT.Rows[i]["AssuranceID"];
                aAssuranceService.KPrice = 0;
                if (detailsDT.Rows[i]["AssuranceKPrice"] != System.DBNull.Value)
                    aAssuranceService.KPrice = (int)detailsDT.Rows[i]["AssuranceKPrice"];
                aAssuranceService.ServicePrice = 0;
                if (detailsDT.Rows[i]["AssuranceServicePrice"] != System.DBNull.Value)
                    aAssuranceService.ServicePrice = (Decimal)detailsDT.Rows[i]["AssuranceServicePrice"];
                prescritionHID = (Int64)detailsDT.Rows[i]["PrescriptionHrID"];
                prescritionDID = (Int64)detailsDT.Rows[i]["PrescriptionDsID"];
                if (!_prescritionDic.ContainsKey(prescritionHID))
                    _prescritionDic.Add(prescritionHID, new BindingList<AssuranceService>());
                _prescritionDic[prescritionHID].Add(aAssuranceService);

            }
        }

        private Int64 GetVisitServiceID(int headID, int assuranceID)
        {
            try
            {
                return FPrescriptionBLL.GetVisitServiceID(headID, assuranceID);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1054");
                MessageBox.Show("بروز خطا در دریافت اطلاعات ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnDisketteCreator_Click(object sender, EventArgs e)
        {
            if (_prescriptionDataSet.Tables.Count != 2 || _prescriptionDataSet.Tables[1].Rows.Count == 0)
                return;
            Doctor aDoctor = new Doctor();
            //DetailsListCreator(_prescriptionDataSet.Tables[1]);'
            if (cboDoctor.SelectedIndex != 0 || cboDoctor.Items.Count == 1)
            {
                aDoctor.Docname = ((DataRowView)cboDoctor.SelectedItem).Row[1].ToString();
                aDoctor.LastName = ((DataRowView)cboDoctor.SelectedItem).Row[2].ToString();
                aDoctor.Code = ((DataRowView)cboDoctor.SelectedItem).Row[3].ToString();
                aDoctor.IdentificationCodeKhadamat = ((DataRowView)cboDoctor.SelectedItem).Row[8].ToString();
                aDoctor.IdentificationCodeMosallah = ((DataRowView)cboDoctor.SelectedItem).Row[9].ToString();
                aDoctor.HaveContractWithKhadamat = (bool)((DataRowView)cboDoctor.SelectedItem).Row[10];
                aDoctor.HaveContractWithMosallah = (bool)((DataRowView)cboDoctor.SelectedItem).Row[11];
                aDoctor.DoctorKind = (Int16)((DataRowView)cboDoctor.SelectedItem).Row[12];
            }
            //string _filePath = Settings.Default["DisketteFilePath"].ToString();

            //if (_filePath.Trim() != "")
                //CreateDiskette(_filePath + "\\", aDoctor, Convert.ToInt32(txtYear.Text.Trim()), cboMonth.SelectedIndex + 1, _prescriptionDataSet);
            //else
            //    MessageBox.Show("لطفآ از قسمت تنظیمات، مسیر ذخیره فایل را مشخص کنید", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            string _filePath = GetDisketteFilePath(Settings.Default["DisketteFilePath"].ToString());
            if (_filePath == "")
                return;
            CreateDiskette(_filePath + "\\", aDoctor, Convert.ToInt32(txtYear.Text.Trim()), cboMonth.SelectedIndex + 1, _prescriptionDataSet);
        }

        private void CreateDiskette(string dir, Doctor doctor, int year, int month, DataSet pDataset)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            visitServiceID = GetVisitServiceID(1, (int)((System.Data.DataRowView)(cboAssurance.SelectedItem)).Row.ItemArray[0]);

            //object result = WaitWindow.Show(this.ProgressWorkerMethod, "Please wait...   0%");
            switch ((int)((System.Data.DataRowView)(cboAssurance.SelectedItem)).Row.ItemArray[0])
            {
                case 0:
                case 1:
                case 4:
                    break;
                case 2:
                    _visitOrganPercent = (int)Settings.Default["MoVisitOrganPercent"];
                    _organPercent = (int)Settings.Default["MoOrganPercent"];
                    this.CreateMADFile(dir, doctor, year, month, pDataset);
                    MessageBox.Show("فایلهای بیمه با موفقیت ایجاد شد");

                    break;


                case 3:
                    _visitOrganPercent = (int)Settings.Default["KhVisitOrganPercent"];
                    _organPercent = (int)Settings.Default["KhOrganPercent"];
                    this.CreateKADFile(dir, 1, doctor, year, month, pDataset);
                    this.CreateKADFile(dir, 2, doctor, year, month, pDataset);
                    this.CreateKADFile(dir, 3, doctor, year, month, pDataset);
                    this.CreateKADFile(dir, 4, doctor, year, month, pDataset);
                    //MessageBox.Show(result.ToString());
                    MessageBox.Show("فایلهای بیمه با موفقیت ایجاد شد");
                    break;

                default:
                    break;
            }

        }
        //MAD:MosallahAssuranceDeiskette
        private void CreateMADFile(string dir, Doctor doctor, int year, int month, DataSet pDataset)
        {
            int prescriptionCount = 0;
            int visitRecCount = 0;
            visitRecCount = pDataset.Tables[0].Rows.Count;
            FileStream stream = new FileStream(dir + "Den.TXT", FileMode.Create);
            StreamWriter sw = new StreamWriter(stream, this.useAscii ? Encoding.ASCII : Encoding.UTF8);
            if (this.standardXml)
            {
                sw.WriteLine("<?xml version=\"1.0\" ?>");
            }
            if (this.standardXml)
            {
                sw.WriteLine("<Y>");
            }
            string _startDate = ((year % 100)).ToString() + ((month < 10) ? "0" : "") + month.ToString() + "01";
            string _endDate = ((year % 100)).ToString() + ((month < 10) ? "0" : "") + month.ToString() + pc.GetDaysInMonth(year, month).ToString();

            sw.WriteLine("<HR>");
            if (!isMedCenter)
            {
                _code = doctor.IdentificationCodeKhadamat;
                _name = doctor.Docname + " " + doctor.LastName;
            }
            else
            {
                medCenterName = Settings.Default["MedCenterName"].ToString();
                medCenterCode = Settings.Default["KhMedCenterCode"].ToString();
                _code = medCenterCode;
                _name = medCenterName;
            }
            sw.WriteLine("<DC>" + _code.Trim() + "</DC>");
            sw.WriteLine("<DN>" + _name + "</DN>");
            sw.WriteLine("<RC>" + visitRecCount + "</RC>");
            sw.WriteLine("<FD>" + _startDate + "</FD>");
            sw.WriteLine("<TD>" + _endDate + "</TD>");
            sw.WriteLine("<CR>2144421610</CR>");
            sw.WriteLine("</HR>");
            if (this.standardXml)
            {
                sw.WriteLine("<Y>");
            }
            for (int i = 0; i < pDataset.Tables[0].Rows.Count; i++)
            {
                prescriptionCount += 1;
                _itemPatientPay = 0;
                _sumServicePrice = 0;
                _sumOrganPay = 0;
                _sumPatientPay = 0;
                foreach (AssuranceService aS in _prescritionDic[(Int64)pDataset.Tables[0].Rows[i]["PrescriptionHrID"]])
                {
                    if (aS.ServiceID == visitServiceID)
                    {
                        _itemServicePrice = (Decimal)pDataset.Tables[0].Rows[i]["VisitPrice"];
                        _itemOrganPay = (Decimal)pDataset.Tables[0].Rows[i]["VisitPrice"] * _visitOrganPercent / 100;
                    }
                    else
                    {
                        //_itemServicePrice = aS.KPrice * (Decimal)pDataset.Tables[0].Rows[i]["KCoeff"];
                        //_itemOrganPay = (aS.KPrice * (Decimal)pDataset.Tables[0].Rows[i]["KCoeff"]) * _organPercent / 100;
                        _itemServicePrice = aS.ServicePrice;
                        _itemOrganPay = aS.ServicePrice * _organPercent / 100;
                    }
                    _itemPatientPay = _itemServicePrice - _itemOrganPay;
                    _sumServicePrice += _itemServicePrice;
                    _sumOrganPay += _itemOrganPay;
                    _sumPatientPay += _itemPatientPay;
                }
                if ((Boolean)pDataset.Tables[0].Rows[i]["Sex"])
                    _sex = "1";
                else
                    _sex = "0";

                sw.WriteLine("");
                sw.WriteLine("<X>");
                sw.WriteLine("<PH>");
                this.writeToBuffer(sw, "<SQ>" + prescriptionCount + "</SQ>");
                this.writeToBuffer(sw, "<ND>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ActionDate"].ToString()) + "</ND>");
                this.writeToBuffer(sw, "<RD>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ActionDate"].ToString()) + "</RD>");
                this.writeToBuffer(sw, "<VD>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ValidityDate"].ToString()) + "</VD>");
                this.writeToBuffer(sw, "<KD>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ReferenceDate"].ToString()) + "</KD>");
                this.writeToBuffer(sw, "<PT>" + pDataset.Tables[0].Rows[i]["AssuranceID"].ToString() + "</PT>");
                this.writeToBuffer(sw, "<SN>" + pDataset.Tables[0].Rows[i]["AssuranceCode"].ToString() + "</SN>");
                this.writeToBuffer(sw, "<GR>" + _sex + "</GR>");
                this.writeToBuffer(sw, "<RN>" + pDataset.Tables[0].Rows[i]["PageNumber"].ToString() + "</RN>");
                this.writeToBuffer(sw, "<PG>" + "2" + "</PG>");//doctorGroup: Dentist=2
                this.writeToBuffer(sw, "<PC>" + pDataset.Tables[0].Rows[i]["Code"].ToString() + "</PC>");
                this.writeToBuffer(sw, "<PP>" + string.Format("{0:0}", _sumServicePrice) + "</PP>");
                this.writeToBuffer(sw, "<IS>" + string.Format("{0:0}", _sumOrganPay) + "</IS>");
                this.writeToBuffer(sw, "<PS>" + string.Format("{0:0}", _sumPatientPay) + "</PS>");
                sw.WriteLine("</PH>");
                sw.WriteLine("<BY>");
                foreach (AssuranceService aS in _prescritionDic[(Int64)pDataset.Tables[0].Rows[i]["PrescriptionHrID"]])
                {
                    if (aS.ServiceID == visitServiceID)
                    {
                        _servicePrice = (Decimal)pDataset.Tables[0].Rows[i]["VisitPrice"];
                        _organShare = _servicePrice * _visitOrganPercent / 100;
                        //aS.ServiceCode = "000999";
                    }
                    else
                    {
                        //_servicePrice = aS.KPrice * (Decimal)pDataset.Tables[0].Rows[i]["KCoeff"];
                        //_organShare = _servicePrice * _organPercent / 100;
                        _servicePrice = aS.ServicePrice;
                        _organShare = _servicePrice * _organPercent / 100;
                    }

                    this.writeToBuffer(sw, "<MH>");
                    this.writeToBuffer(sw, "<MG>" + aS.ServiceCode.Trim() + "</MG>");
                    this.writeToBuffer(sw, "<MD>" + "1" + "</MD>");
                    this.writeToBuffer(sw, "<MR>" + "1" + "</MR>");//number of same service in aprescription
                    this.writeToBuffer(sw, "<MP>" + string.Format("{0:0}", _servicePrice) + "</MP>");
                    this.writeToBuffer(sw, "<MI>" + string.Format("{0:0}", _organShare) + "</MI>");
                    this.writeToBuffer(sw, "<MS>" + string.Format("{0:0}", _servicePrice - _organShare) + "</MS>");
                    this.writeToBuffer(sw, "</MH>");
                }
                if (!this.useNewLine)
                {
                    sw.WriteLine("");
                }
                sw.WriteLine("</BY>");
                sw.WriteLine("</X>");
            }

            if (this.standardXml)
            {
                sw.WriteLine("</Y>");
            }
            if (this.standardXml)
            {
                sw.WriteLine("</Y>");
            }
            sw.Close();
            stream.Close();

        }

        //KAD:KhadamatAssuranceDeiskette
        private void CreateKADFile(string dir, Int16 nos, Doctor doctor, int year, int month, DataSet pDataset)
        {
            int _prescriptionCount = 0;
            int visitRecCount = 0;



            for (int i = 0; i < pDataset.Tables[0].Rows.Count; i++)
            {
                if ((Int16)pDataset.Tables[0].Rows[i]["HandbookID"] != nos)
                    if( nos !=2 ||(nos == 2 && (Int16)pDataset.Tables[0].Rows[i]["HandbookID"] != 5))
                    continue;
                visitRecCount += 1;
            }

            FileStream stream = new FileStream(dir + "NOS" + nos.ToString() + ".TXT", FileMode.Create);
            StreamWriter sw = new StreamWriter(stream, this.useAscii ? Encoding.ASCII : Encoding.UTF8);
            if (this.standardXml)
            {
                sw.WriteLine("<?xml version=\"1.0\" ?>");
            }
            if (this.standardXml)
            {
                sw.WriteLine("<Y>");
            }
            string _startDate = ((year % 100)).ToString() + ((month < 10) ? "0" : "") + month.ToString() + "01";
            string _endDate = ((year % 100)).ToString() + ((month < 10) ? "0" : "") + month.ToString() + pc.GetDaysInMonth(year, month).ToString();

            sw.WriteLine("<HR>");

            if (!isMedCenter)
            {
                _code = doctor.IdentificationCodeKhadamat;
                _name = doctor.Docname + " " + doctor.LastName;
            }
            else
            {
                medCenterName = Settings.Default["MedCenterName"].ToString();
                medCenterCode = Settings.Default["KhMedCenterCode"].ToString();
                _code = medCenterCode;
                _name = medCenterName;
            }

            sw.WriteLine("<DC>" + _code.Trim() + "</DC>");
            sw.WriteLine("<DN>" + _name + "</DN>");
            sw.WriteLine("<RC>" + visitRecCount + "</RC>");
            sw.WriteLine("<FD>" + _startDate + "</FD>");
            sw.WriteLine("<TD>" + _endDate + "</TD>");
            sw.WriteLine("<CR>2144421610</CR>");
            sw.WriteLine("</HR>");

            if (this.standardXml)
            {
                sw.WriteLine("<Y>");
            }

            for (int i = 0; i < pDataset.Tables[0].Rows.Count; i++)
            {
                if ((Int16)pDataset.Tables[0].Rows[i]["HandbookID"] != nos)
                    if (nos != 2 || (nos == 2 && (Int16)pDataset.Tables[0].Rows[i]["HandbookID"] != 5))
                    continue;
                _prescriptionCount += 1;
                _itemPatientPay = 0;
                _sumServicePrice = 0;
                _sumOrganPay = 0;
                _sumPatientPay = 0;
                foreach (AssuranceService aS in _prescritionDic[(Int64)pDataset.Tables[0].Rows[i]["PrescriptionHrID"]])
                {
                    if (aS.ServiceID == visitServiceID)
                    {
                        _itemServicePrice = (Decimal)pDataset.Tables[0].Rows[i]["VisitPrice"];
                        _itemOrganPay = (Decimal)pDataset.Tables[0].Rows[i]["VisitPrice"] * _visitOrganPercent / 100;
                    }
                    else
                    {
                        //_itemServicePrice = aS.KPrice * (Decimal)pDataset.Tables[0].Rows[i]["KCoeff"];
                        //_itemOrganPay = (aS.KPrice * (Decimal)pDataset.Tables[0].Rows[i]["KCoeff"]) * _organPercent / 100;
                        _itemServicePrice = aS.ServicePrice;
                        _itemOrganPay = aS.ServicePrice * _organPercent / 100;
                    }
                    _itemPatientPay = _itemServicePrice - _itemOrganPay;
                    _sumServicePrice += _itemServicePrice;
                    _sumOrganPay += _itemOrganPay;
                    _sumPatientPay += _itemPatientPay;

                }
                if ((Boolean)pDataset.Tables[0].Rows[i]["Sex"])
                    _sex = "1";
                else
                    _sex = "0";

                sw.WriteLine("");
                sw.WriteLine("<X>");
                sw.WriteLine("<PH>");
                this.writeToBuffer(sw, "<SQ>" + _prescriptionCount + "</SQ>");
                this.writeToBuffer(sw, "<ND>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ActionDate"].ToString()) + "</ND>");
                this.writeToBuffer(sw, "<RD>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ActionDate"].ToString()) + "</RD>");
                this.writeToBuffer(sw, "<VD>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ValidityDate"].ToString()) + "</VD>");
                this.writeToBuffer(sw, "<KD>" + CustomizeDate(pDataset.Tables[0].Rows[i]["ReferenceDate"].ToString()) + "</KD>");
                this.writeToBuffer(sw, "<PT>" + (102 + (Int32)pDataset.Tables[0].Rows[i]["AssuranceID"]).ToString() + "</PT>");
                this.writeToBuffer(sw, "<SN>" + pDataset.Tables[0].Rows[i]["AssuranceCode"].ToString() + "</SN>");
                this.writeToBuffer(sw, "<GR>" + _sex + "</GR>");
                this.writeToBuffer(sw, "<RN>" + pDataset.Tables[0].Rows[i]["PageNumber"].ToString() + "</RN>");
                this.writeToBuffer(sw, "<PG>" + "2" + "</PG>");//doctorGroup: Dentist=2
                this.writeToBuffer(sw, "<PC>" + pDataset.Tables[0].Rows[i]["Code"].ToString() + "</PC>");//doctor code
                this.writeToBuffer(sw, "<PP>" + string.Format("{0:0}", _sumServicePrice) + "</PP>");
                this.writeToBuffer(sw, "<IS>" + string.Format("{0:0}", _sumOrganPay) + "</IS>");
                this.writeToBuffer(sw, "<PS>" + string.Format("{0:0}", _sumPatientPay) + "</PS>");
                sw.WriteLine("</PH>");
                sw.WriteLine("<BY>");
                foreach (AssuranceService aS in _prescritionDic[(Int64)pDataset.Tables[0].Rows[i]["PrescriptionHrID"]])
                {
                    if (aS.ServiceID == visitServiceID)
                    {
                        _servicePrice = (Decimal)pDataset.Tables[0].Rows[i]["VisitPrice"];
                        _organShare = _servicePrice * _visitOrganPercent / 100;
                        organServiceCode = "21";
                        aS.ServiceCode = "000999";
                    }
                    else
                    {
                        //_servicePrice = aS.KPrice * (Decimal)pDataset.Tables[0].Rows[i]["KCoeff"];
                        //_organShare = _servicePrice * _organPercent / 100;
                        organServiceCode = "22";
                        _servicePrice = aS.ServicePrice;
                        _organShare = _servicePrice * _organPercent / 100;
                    }

                    this.writeToBuffer(sw, "<MH>");
                    this.writeToBuffer(sw, "<SG>" + organServiceCode + "</SG>");
                    this.writeToBuffer(sw, "<MG>" + aS.ServiceCode.Trim() + "</MG>");
                    this.writeToBuffer(sw, "<MD>" + "1" + "</MD>");
                    this.writeToBuffer(sw, "<MP>" + string.Format("{0:0}", _servicePrice) + "</MP>");
                    this.writeToBuffer(sw, "<MI>" + string.Format("{0:0}", _organShare) + "</MI>");
                    this.writeToBuffer(sw, "<MS>" + string.Format("{0:0}", _servicePrice - _organShare) + "</MS>");
                    this.writeToBuffer(sw, "</MH>");
                }

                if (!this.useNewLine)
                {
                    sw.WriteLine("");
                }
                sw.WriteLine("</BY>");
                sw.WriteLine("</X>");
            }

            if (this.standardXml)
            {
                sw.WriteLine("</Y>");
            }
            if (this.standardXml)
            {
                sw.WriteLine("</Y>");
            }
            sw.Close();
            stream.Close();
        }

        private void writeToBuffer(StreamWriter sw, string text)
        {
            if (this.useNewLine)
            {
                sw.WriteLine(text);
            }
            else
            {
                sw.Write(text);
            }
        }

        public string CustomizeDate(string farsiDate)
        {
            if (farsiDate.Trim() == "")
            {
                return "";
            }
            try
            {
                DateTime time = PersianDate.Parse(farsiDate);
                int dayOfMonth = pc.GetDayOfMonth(time);
                int month = pc.GetMonth(time);
                int num3 = pc.GetYear(time) % 100;
                return (num3.ToString() + ((month < 10) ? "0" : "") + month.ToString() + ((dayOfMonth < 10) ? "0" : "") + dayOfMonth.ToString());
            }
            catch
            {
                return "";
            }
        }

        private void dgvPrescriptionList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvPrescriptionList.Rows[e.RowIndex].Selected = true;
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionList.SelectedRows.Count <= 0)
                return;
            dgvPrescriptionList_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionList.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("نسخه مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FPrescriptionBLL.DeleteObject((Int64)((DataRowView)dgvPrescriptionList.SelectedRows[0].DataBoundItem).Row.ItemArray[1]);
                Int32 _year = Convert.ToInt32(txtYear.Text.Trim());
                FilldgvPrescriptionList(_year, cboMonth.SelectedIndex + 1, Convert.ToInt32(((DataRowView)cboAssurance.SelectedItem).Row[0]), Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]));

            }
        }

        private void btnReportCreator_Click(object sender, EventArgs e)
        {
            if (_prescriptionDataSet.Tables.Count != 2 || _prescriptionDataSet.Tables[1].Rows.Count == 0)
                return;
            Doctor aDoctor = new Doctor();
            //DetailsListCreator(_prescriptionDataSet.Tables[1]);'
            if (cboDoctor.SelectedIndex != 0 || cboDoctor.Items.Count == 1)
            {
                aDoctor.Docname = ((DataRowView)cboDoctor.SelectedItem).Row[1].ToString();
                aDoctor.LastName = ((DataRowView)cboDoctor.SelectedItem).Row[2].ToString();
                aDoctor.Code = ((DataRowView)cboDoctor.SelectedItem).Row[3].ToString();
                aDoctor.IdentificationCodeKhadamat = ((DataRowView)cboDoctor.SelectedItem).Row[8].ToString();
                aDoctor.IdentificationCodeMosallah = ((DataRowView)cboDoctor.SelectedItem).Row[9].ToString();
                aDoctor.HaveContractWithKhadamat = (bool)((DataRowView)cboDoctor.SelectedItem).Row[10];
                aDoctor.HaveContractWithMosallah = (bool)((DataRowView)cboDoctor.SelectedItem).Row[11];
                aDoctor.DoctorKind = (Int16)((DataRowView)cboDoctor.SelectedItem).Row[12];
            }

            switch ((int)((System.Data.DataRowView)(cboAssurance.SelectedItem)).Row.ItemArray[0])
            {
                case 0:
                case 1:

                case 4:
                    break;
                case 2:
                    _visitOrganPercent = (int)Settings.Default["MoVisitOrganPercent"];
                    _organPercent = (int)Settings.Default["MoOrganPercent"];
                    CreateMoPrescriptionReport(aDoctor, Convert.ToInt32(txtYear.Text.Trim()), cboMonth.SelectedIndex + 1, (int)((System.Data.DataRowView)(cboAssurance.SelectedItem)).Row.ItemArray[0]);
                    break;
                case 3:
                    _visitOrganPercent = (int)Settings.Default["KhVisitOrganPercent"];
                    _organPercent = (int)Settings.Default["KhOrganPercent"];
                    CreateKhPrescriptionReport(aDoctor, Convert.ToInt32(txtYear.Text.Trim()), cboMonth.SelectedIndex + 1, (int)((System.Data.DataRowView)(cboAssurance.SelectedItem)).Row.ItemArray[0]);
                    break;

                default:
                    break;
            }
        }

        private void CreateKhPrescriptionReport(Doctor doctor, int year, int month, int assuranceID)
        {
            DataSet reportDataSet;

            AssuranceReportHeader aAssuranceReportHeader;
            AssuranceReportForm aAssuranceReportForm = new AssuranceReportForm();
            aAssuranceReportForm.AssuranceType = AssuranceType.Khadamat;
            string MonthName = PersianDate.PersianMonthNames.Default[month];
            string docOrmedName = string.Empty;
            if (!isMedCenter)
                docOrmedName = doctor.Docname + " " + doctor.LastName;
            else
                docOrmedName = Settings.Default["MedCenterName"].ToString();
            for (int i = 0; i < 4; i++)
            {
                aAssuranceReportHeader = new AssuranceReportHeader(UtilMethods.GetSHandBookName(i + 1, true), docOrmedName, MonthName, year.ToString());
                aAssuranceReportForm.ReportHeader.Add(aAssuranceReportHeader);
            }
            try
            {
                reportDataSet = GetKhPrescriptionVisitServiceMixedList(doctor, year, month, assuranceID);
                aAssuranceReportForm.ReportDataSet.Add(reportDataSet.Copy());
                reportDataSet = GetKhPrescriptionServiceMixedList(doctor, year, month, assuranceID);
                aAssuranceReportForm.ReportDataSet.Add(reportDataSet.Copy());
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1057");
                MessageBox.Show("بروز خطا در بارگزاری اطلاعات لیست نسخه ها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            aAssuranceReportForm.MdiParent = this.MdiParent;
            aAssuranceReportForm.Show();
        }

        private DataSet GetKhPrescriptionVisitServiceMixedList(Doctor doctor, int year, int month, int assuranceID)
        {
            return FPrescriptionBLL.GetKhPrescriptionVisitServiceMixedList(doctor, year, month, assuranceID, _visitOrganPercent);
        }

        private DataSet GetKhPrescriptionServiceMixedList(Doctor doctor, int year, int month, int assuranceID)
        {
            return FPrescriptionBLL.GetKhPrescriptionServiceMixedList(doctor, year, month, assuranceID, _organPercent);
        }

        private void CreateMoPrescriptionReport(Doctor doctor, int year, int month, int assuranceID)
        {
            DataSet reportDataSet;

            AssuranceReportHeader aAssuranceReportHeader;
            AssuranceReportForm aAssuranceReportForm = new AssuranceReportForm();
            aAssuranceReportForm.AssuranceType = AssuranceType.Mosallah;
            string MonthName = PersianDate.PersianMonthNames.Default[month];
            string docOrmedName = string.Empty;
            if (!isMedCenter)
                docOrmedName = doctor.Docname + " " + doctor.LastName;
            else
                docOrmedName = Settings.Default["MedCenterName"].ToString();

            aAssuranceReportHeader = new AssuranceReportHeader("", docOrmedName, MonthName, year.ToString());
            aAssuranceReportForm.ReportHeader.Add(aAssuranceReportHeader);

            try
            {
                reportDataSet = GetMoPrescriptionVisitServiceMixedList(doctor, year, month, assuranceID);
                aAssuranceReportForm.ReportDataSet.Add(reportDataSet.Copy());
                reportDataSet = GetMoPrescriptionServiceMixedList(doctor, year, month, assuranceID);
                aAssuranceReportForm.ReportDataSet.Add(reportDataSet.Copy());
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1058");
                MessageBox.Show("بروز خطا در بارگزاری اطلاعات لیست نسخه ها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            aAssuranceReportForm.MdiParent = this.MdiParent;
            aAssuranceReportForm.Show();
        }

        private DataSet GetMoPrescriptionVisitServiceMixedList(Doctor doctor, int year, int month, int assuranceID)
        {
            return FPrescriptionBLL.GetMoPrescriptionVisitServiceMixedList(doctor, year, month, assuranceID, _visitOrganPercent);
        }

        private DataSet GetMoPrescriptionServiceMixedList(Doctor doctor, int year, int month, int assuranceID)
        {
            return FPrescriptionBLL.GetMoPrescriptionServiceMixedList(doctor, year, month, assuranceID, _organPercent);
        }

        private string GetDisketteFilePath(string selectedPath)
        {
            //string _filePath = Settings.Default["DisketteFilePath"].ToString();
            string folderName = string.Empty;
            FolderBrowserDialog aFolderBrowserDialog = new FolderBrowserDialog();
            if (selectedPath != "")
                aFolderBrowserDialog.SelectedPath = selectedPath;
            else
                aFolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = aFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = aFolderBrowserDialog.SelectedPath;
            }
            return folderName;

        }

    }
}
