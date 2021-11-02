using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.Common;
using DentiClinic.Common.DateConvert;
using DentiClinic.BusinessLogic;
using System.IO;

namespace DentiClinic
{
    public partial class PrescriptionFormOld : MiddleBaseWinForm
    {
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

        private DataSet PrescriptionDs;

        private PersianCalendar pc;
        private bool _assuranceNumberChange = false;

        private int _serviceID = 0;
        public PrescriptionFormOld()
        {
            InitializeComponent();
        }

        private void PrescriptionFormOld_Load(object sender, EventArgs e)
        {
            dgvPrescriptionGroup.AutoGenerateColumns = false;
            pc = new PersianCalendar();
            GetDoctorList();
            InitialForm(false);
            //FilldgvPrescriptionList(PersianDateConverter.ToPersianDate(DateTime.Now).Year, PersianDateConverter.ToPersianDate(DateTime.Now).Month, 0,0);
            FilldgvPrescriptionGroup();
        }

        private void GetDoctorList()
        {
            DataSet aDataSet;//=new DataSet();

            aDataSet = FPatientBLL.GetDoctorList();
            cboDoctor.DataSource = aDataSet.Tables[0];
            cboDoctor.DisplayMember = "LastName";
            cboDoctor.ValueMember = "DoctorID";
        }

        public override void InitialForm(bool SetValue)
        {

            string PageNumber = string.Empty;
            string ActionDate = string.Empty;
            decimal PatientPayment = 0;
            bool IsReferenced = false;

            if (SetValue)
            {
                cboDoctor.SelectedValue = OPatient.DoctorID;
                PageNumber = OPrescription.PageNumber.ToString();
                ActionDate = OPrescription.ActionDate;
                PatientPayment = OPrescription.PatientPayment;
                IsReferenced = OPrescription.IsReferenced;
                if (IsReferenced)
                {
                    chkIsReferenced.Checked = true;
                    fdpReferenceDate.Text = OPrescription.ReferencedDate;
                }
                else
                    chkIsReferenced.Checked = false;

                fdpActiondate.Text = ActionDate;
            }
            else
            {
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancle.Enabled = false;
                btnDelete.Enabled = false;

                fdpReferenceDate.SelectedDateTime = DateTime.Now;
                txtYear.Text = pc.GetYear(DateTime.Now).ToString();
                cboMonth.SelectedIndex = pc.GetMonth(DateTime.Now) - 1;
                chkIsReferenced.Checked = false;

            }
            txtPageNumber.Text = PageNumber;
            txtValidityDate.Text = ActionDate;
            txtPatientPayment.Text = PatientPayment.ToString();

        }

        public void InitialFormPatientInfoSub(bool SetValue)
        {
            string LastName = string.Empty;
            string Name = string.Empty;
            string Sex = string.Empty;
            string AssuranceNumber = string.Empty;
            string AssuranceType = string.Empty;
            string ValidityDate = string.Empty;

            if (SetValue)
            {
                LastName = OPatient.LastName;
                Name = OPatient.FirstName;
                if (OPatient.Sex)
                    Sex = "مرد";
                else
                    Sex = "زن";
                cboDoctor.SelectedValue = OPatient.DoctorID;
                AssuranceNumber = OPatient.AssuranceNumber;
                AssuranceType = OPatient.AssuranceName;
                ValidityDate = OPatient.HandbookValidityDate;
            }

            txtLastName.Text = LastName;
            txtName.Text = Name;
            txtAssuranceNumber.Text = AssuranceNumber;
            txtSex.Text = Sex;
            txtAssuranceType.Text = AssuranceType;
            //txtValidityDate.Text = "";
        }

        public void InitialFormServiceInfoSub(bool SetValue)
        {
            string ServiceCode = string.Empty;
            string ServiceName = string.Empty;
            decimal ServicePrice = 0;
            decimal PatientShare = 0;

            if (SetValue)
            {
                ServiceCode = OAssuranceService.ServiceCode;
                ServiceName = OAssuranceService.ServiceName;
                ServicePrice = OAssuranceService.ServicePrice;
                PatientShare = OAssuranceService.ServicePrice * 3 / 100;
            }

            txtServiceCode.Text = ServiceCode;
            txtServiceName.Text = ServiceName;
            txtServicePrice.Text = ServicePrice.ToString();
            txtPatientShare.Text = PatientShare.ToString();
            txtPatientPayment.Text = PatientShare.ToString();
        }

        private void FilldgvPrescriptionList(int year, int month, int assuranceID)
        {
            DataSet ds = FPrescriptionBLL.GetPrescriptionList(year, month, assuranceID,0);
            dgvPrescriptionList.AutoGenerateColumns = false;
            dgvPrescriptionList.DataSource = ds.Tables[0];
        }

        private void FilldgvPrescriptionGroup()
        {
            DataSet ds = FPrescriptionBLL.GetPrescritionGroupList();
            dgvPrescriptionGroup.DataSource = ds.Tables[0];
        }
        private void btnDisketteCreator_Click(object sender, EventArgs e)
        {

        }

        private void dgvPrescriptionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InitialForm(true);
            aPageMode = PageMode.Mode_edit;
            btnSave.Text = "ویرایش";
            btnCancle.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void txtAssuranceNumber_TextChanged(object sender, EventArgs e)
        {
            _assuranceNumberChange = true;
        }

        private void txtAssuranceNumber_Leave(object sender, EventArgs e)
        {
            if (_assuranceNumberChange && txtAssuranceNumber.Text.Trim() != "")
            {
                aPageMode = PageMode.Mode_new;
                SelectPatient();
                setPatientInfo();
            }
            else
                InitialForm(false);
        }

        public void SelectPatient()
        {
            OPatient.AssuranceNumber = txtAssuranceNumber.Text.Trim();
            FPrescriptionBLL.oPatient = OPatient;
            FPrescriptionBLL.SelectPatient();
        }

        public void setPatientInfo()
        {
            if (OPatient.RowEffected)
            {
                _assuranceNumberChange = false;
                InitialFormPatientInfoSub(true);
            }
            else
            {
                OPatient = null;
                _assuranceNumberChange = false;
                txtAssuranceNumber.Focus();
                txtAssuranceNumber.SelectionStart = 0;
                txtAssuranceNumber.SelectionLength = txtAssuranceNumber.TextLength;
                InitialFormPatientInfoSub(false);
            }
            //InitialFormServiceInfoSub(false);
            InitialForm(false);
        }

        private void chkIsReferenced_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsReferenced.Checked)
                fdpReferenceDate.Enabled = true;
            else
                fdpReferenceDate.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ServicePickup aServicePickup = new ServicePickup();
            aServicePickup.Owner = this;
            aServicePickup.OAssuranceService = this.OAssuranceService;
            aServicePickup.TopMost = true;
            if (aServicePickup.ShowDialog() == DialogResult.OK)
                InitialFormServiceInfoSub(true);
            else
                InitialFormServiceInfoSub(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetObject();
            SaveInfo();
            InitialForm(false);
            FilldgvPrescriptionList(PersianDateConverter.ToPersianDate(fdpActiondate.SelectedDateTime).Year, PersianDateConverter.ToPersianDate(fdpActiondate.SelectedDateTime).Month, OPatient.AssuranceID);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        public override void SetObject()
        {
            Int16 _pageNumber = 0;
            Decimal _patientPayment = 0;
            if (txtPageNumber.Text.Trim() == "" || !Int16.TryParse(txtPageNumber.Text.Trim(), out _pageNumber))
            {
                //errorProvider1.SetError(txtFeesPayable, "مبلغ قابل پرداخت راوارد کنید");
                txtPageNumber.Focus();
                return;
            }

            if (txtPatientPayment.Text.Trim() == "" || !decimal.TryParse(txtPatientPayment.Text.Trim(), out _patientPayment))
            {
                //errorProvider1.SetError(txtFeesPayable, "مبلغ قابل پرداخت راوارد کنید");
                txtPatientPayment.Focus();
                return;
            }
            OPrescription.ActionDate = fdpActiondate.Text;
            ///*OPrescription.AssuranceServiceID = _serviceID;
            OPrescription.DoctorID = Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]);
            OPrescription.InsuranceCoeff = 0;
            OPrescription.IsReferenced = chkIsReferenced.Checked;
            OPrescription.Month = (Int16)PersianDateConverter.ToPersianDate(fdpActiondate.SelectedDateTime).Month;
            OPrescription.PageNumber = _pageNumber;
            OPrescription.PatientID = OPatient.PatientID;
            OPrescription.PatientPayment = _patientPayment;
            if (chkIsReferenced.Checked)
                OPrescription.ReferencedDate = fdpReferenceDate.Text;
            else
                OPrescription.ReferencedDate = "";
            OPrescription.Year = PersianDateConverter.ToPersianDate(fdpActiondate.SelectedDateTime).Year.ToString();

        }

        public override void SaveInfo()
        {
            FPrescriptionBLL.OPrescription = this.OPrescription;
            if (aPageMode == PageMode.Mode_new)
                SaveObject();
            else
                EditObject();
        }

        public override void SaveObject()
        {
            FPrescriptionBLL.SaveObject();
        }

        public override void EditObject()
        {
            FPrescriptionBLL.EditObject();
        }

        public void setServiceInfo()
        {

        }

        private bool useAscii;
        private bool standardXml;
        private bool isIndependent;
        private string medCenterCode = string.Empty;
        private string medCenterName = string.Empty;
        private int visitRecCount = 0;
        private bool useNewLine;

        private void CreateDiskette(string dir, int nos, Doctor doctor, int year, int month, DataSet pDataset)
        {
            string _code = string.Empty;
            string _name = string.Empty;

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

            if (isIndependent)
            {
                _code = medCenterCode;
                Name = doctor.Docname + " " + doctor.LastName;
            }
            else
            {
                _code = medCenterCode;
                _name = medCenterName;
            }

            sw.WriteLine("<DC>" + _code + "</DC>");
            sw.WriteLine("<DN>" + _name + "</DN>");
            sw.WriteLine("<RC>" + visitRecCount.ToString() + "</RC>");
            sw.WriteLine("<FD>" + _startDate + "</FD>");
            sw.WriteLine("<TD>" + _endDate + "</TD>");
            sw.WriteLine("<CR>6959</CR>");
            sw.WriteLine("</HR>");

            if (this.standardXml)
            {
                sw.WriteLine("<Y>");
            }

            for (int i = 0; i < pDataset.Tables[0].Rows.Count; i++)
            {
                sw.WriteLine("");
                sw.WriteLine("<X>");
                sw.WriteLine("<PH>");
                this.writeToBuffer(sw, "<SQ>" + i.ToString() + "</SQ>");
                //this.writeToBuffer(sw, "<ND>" + header.nd + "</ND>");
                //this.writeToBuffer(sw, "<RD>" + header.rd + "</RD>");
                //this.writeToBuffer(sw, "<VD>" + header.vd + "</VD>");
                //this.writeToBuffer(sw, "<KD>" + header.kd + "</KD>");
                //this.writeToBuffer(sw, "<PT>" + header.pt + "</PT>");
                //this.writeToBuffer(sw, "<SN>" + header.sn + "</SN>");
                //this.writeToBuffer(sw, "<GR>" + header.gr.ToString() + "</GR>");
                //this.writeToBuffer(sw, "<RN>" + header.rn.ToString() + "</RN>");
                //this.writeToBuffer(sw, "<PG>" + header.pg.ToString() + "</PG>");
                //this.writeToBuffer(sw, "<PC>" + header.pc + "</PC>");
                //this.writeToBuffer(sw, "<PP>" + header.pp.ToString() + "</PP>");
                //this.writeToBuffer(sw, "<IS>" + header.is_.ToString() + "</IS>");
                //this.writeToBuffer(sw, "<PS>" + header.ps.ToString() + "</PS>");
                //sw.WriteLine("</PH>");
                //sw.WriteLine("<BY>");
                //foreach (VisitItem item in header.items)
                //{
                //    this.writeToBuffer(sw, "<MH>");
                //    this.writeToBuffer(sw, "<SG>" + item.sg.ToString() + "</SG>");
                //    this.writeToBuffer(sw, "<MG>" + item.mg + "</MG>");
                //    this.writeToBuffer(sw, "<MD>" + item.md.ToString() + "</MD>");
                //    this.writeToBuffer(sw, "<MP>" + item.mp.ToString() + "</MP>");
                //    this.writeToBuffer(sw, "<MI>" + item.mi.ToString() + "</MI>");
                //    this.writeToBuffer(sw, "<MS>" + item.ms.ToString() + "</MS>");
                //    this.writeToBuffer(sw, "</MH>");
                //}
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





    }

}
