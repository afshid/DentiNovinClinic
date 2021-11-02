using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using DentiNovin.BusinessLogic;
using DentiNovin.Common.DateConvert;
using System.ComponentModel.DataAnnotations;
using DentiNovin.BaseClasses;
using DentiNovin.Properties;

namespace DentiNovin
{
    public partial class PrescriptionForm : MiddleBaseWinForm
    {
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

        private Doctor _oDoctor;
        public Doctor ODoctor
        {
            get
            {
                if (_oDoctor == null)
                    _oDoctor = new Doctor();
                return _oDoctor;
            }
            set { _oDoctor = value; }
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

        private PersianCalendar pc;

        DataSet _detailsDataSet;
        DataTable _detailsDataTable;

        private bool _assuranceNumberChange = false;
        private BindingList<AssuranceService> _prescriptionDetailsListShadow;
        public event EventHandler PrescriptionSaved;
        private bool visitExist = false;
        private bool ServiceExist = false;
        private int _assuranceID = 0;
        private Decimal _servicePrice = 0;
        private Decimal _kCoeff = 0;
        private int _organPercent = 0;
        private decimal _visitPrice = 0;
        private int _visitOrganPercent = 0;
        private Int64 visitServiceID = 0;
        private Int16 docorKind = 0;

        public PrescriptionForm()
        {
            InitializeComponent();
        }

        private void PrescriptionForm_Load(object sender, EventArgs e)
        {
            dgvServiceList.AutoGenerateColumns = false;
            _prescriptionDetailsListShadow = UtilMethods.CloneList<AssuranceService>(this.OPrescription.AssuranceServiceList);
            try
            {
                GetDoctorList();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1046");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.aPageMode == PageMode.Mode_edit)
            {
                txtAssuranceCode.Enabled = false;
                cboDoctor.Enabled = false;
                cboDoctor.BackColor = Color.Khaki;
                try
                {
                    SelectPatient(this.OPrescription.AssuranceCode);
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1047");
                    MessageBox.Show("بروز خطا در بارگزاری اطلاعات بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                setPatientInfo();
                InitialForm(true);
                foreach (AssuranceService aS in _prescriptionDetailsListShadow)
                {
                    if (aS.ServiceID == visitServiceID)
                    {
                        aS.ServicePrice = OPrescription.VisitPrice;
                        aS.PatientShare = aS.ServicePrice - (aS.ServicePrice * _visitOrganPercent / 100);
                    }
                    else
                    {
                        aS.PatientShare = aS.ServicePrice - (aS.ServicePrice * _organPercent / 100);
                    }

                }
                InitialFormPriceInfoSub(true);
            }
            else
            {
                InitialForm(false);
                //InitialFormPriceInfoSub(false);
            }
            dgvServiceList.DataSource = _prescriptionDetailsListShadow;
        }

        private void fdpReferenceDate_SelectedDateTimeChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenService_Click(object sender, EventArgs e)
        {
            ServicePickup aServicePickup = new ServicePickup();
            aServicePickup.ServiceAdded += new EventHandler(aServicePickup_ServiceAdded);
            aServicePickup.Owner = this;
            aServicePickup.OAssuranceService = this.OAssuranceService;
            aServicePickup.TopMost = true;
        }

        void aServicePickup_ServiceAdded(object sender, EventArgs e)
        {
            AssuranceService aAssuranceService;
            aAssuranceService = (AssuranceService)OAssuranceService.Clone();
            OAssuranceService = null;
            aAssuranceService.PatientShare = aAssuranceService.ServicePrice - (aAssuranceService.ServicePrice * _organPercent / 100);
            _prescriptionDetailsListShadow.Add(aAssuranceService);
            dgvServiceList.Refresh();
            InitialFormPriceInfoSub(false);
        }

        public override void InitialForm(bool SetValue)
        {

            string PageNumber = string.Empty;
            string ActionDate = string.Empty;
            decimal PatientPayment = 0;
            bool IsReferenced = false;

            if (SetValue)
            {

                cboDoctor.SelectedValue = OPrescription.DoctorID;
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
                btnSave.Text = "ویرایش";
                //fdpActiondate.Text = ActionDate;
                fdpActiondate.SelectedDateTime = PersianDateConverter.ToGregorianDateTime(ActionDate);
            }
            else
            {
                btnSave.Text = "ثبت";
                fdpActiondate.SelectedDateTime = DateTime.Now;
                fdpReferenceDate.SelectedDateTime = DateTime.Now;
                chkIsReferenced.Checked = false;
            }
            txtPageNumber.Text = PageNumber;
            txtPatientPayment.Text = PatientPayment.ToString();
        }

        public void InitialFormPatientInfoSub(bool SetValue)
        {
            string LastName = string.Empty;
            string Name = string.Empty;
            string Sex = string.Empty;
            string AssuranceCode = string.Empty;
            string AssuranceName = string.Empty;
            decimal KCoeff = 0;
            string ValidityDate = string.Empty;
            bool addServiceEnable = false;
            bool addVisitEnable = false;
            bool SavePrescription = false;
            if (SetValue)
            {
                LastName = OPatient.LastName;
                Name = OPatient.FirstName;
                if (OPatient.Sex)
                    Sex = "مرد";
                else
                    Sex = "زن";
                cboDoctor.SelectedValue = OPatient.DoctorID;
                AssuranceCode = OPatient.PatientAssuranceList[0].AssuranceCode;
                AssuranceName = OPatient.PatientAssuranceList[0].AssuranceName;
                _assuranceID = OPatient.PatientAssuranceList[0].AssuranceID;
                SetAssuranceInfo(_assuranceID);
                ValidityDate = OPatient.PatientAssuranceList[0].ValidityDate;

                addServiceEnable = true;
                addVisitEnable = true;
                SavePrescription = true;
            }
            else
            {
                _prescriptionDetailsListShadow.Clear();
                dgvServiceList.Refresh();
                InitialFormPriceInfoSub(false);
                SetAssuranceInfo(10);
            }
            txtLastName.Text = LastName;
            txtName.Text = Name;
            txtAssuranceCode.Text = AssuranceCode;
            txtSex.Text = Sex;
            txtAssuranceType.Text = AssuranceName;
            txtValidityDate.Text = ValidityDate;
            btnAddService.Enabled = addServiceEnable;
            btnAddVisit.Enabled = addVisitEnable;
            //btnSave.Enabled = SavePrescription;
            txtKCoeff.Text = _kCoeff.ToString();
        }

        public void InitialFormPriceInfoSub(bool SetValue)
        {
            decimal _sumServicePrice = 0;
            decimal _patientPayment = 0;
            Decimal _sumPatientShare = 0;
            _servicePrice = 0;
            visitExist = false;
            ServiceExist = false;
            foreach (AssuranceService aS in _prescriptionDetailsListShadow)
            {
                if (aS.ServiceID == visitServiceID)
                    visitExist = true;
                else
                    ServiceExist = true;
                _servicePrice = aS.ServicePrice;
                _sumServicePrice += _servicePrice;
                _sumPatientShare += aS.PatientShare;
            }
            btnAddVisit.Enabled = (!ServiceExist && !visitExist);
            btnAddService.Enabled = !visitExist;
            if (SetValue)
                _patientPayment = OPrescription.PatientPayment;
            else
                _patientPayment = _sumPatientShare;
            txtServicePrice.Text = _sumServicePrice.ToString("#,0;(#,0)");
            txtPatientShare.Text = _sumPatientShare.ToString("#,0;(#,0)");
            txtPatientPayment.Text = _patientPayment.ToString("#,0;(#,0)");
            btnSave.Enabled = ServiceExist || visitExist;
        }

        private void SetAssuranceInfo(int assuranceID)
        {
            switch (assuranceID)
            {
                case 2:
                    _kCoeff = (Decimal)Settings.Default["MoKCoeff"];
                    switch (docorKind)
                    {
                        case 1:
                            _visitPrice = (decimal)Settings.Default["MoVisitPriceSpecialist"];
                            break;
                        default:
                            _visitPrice = (decimal)Settings.Default["MoVisitPriceGeneral"];
                            break;
                    }
                    _visitOrganPercent = (int)Settings.Default["MoVisitOrganPercent"];
                    _organPercent = (int)Settings.Default["MoOrganPercent"];
                    break;
                case 3:
                    _kCoeff = (Decimal)Settings.Default["KhKCoeff"];
                    switch (docorKind)
                    {
                        case 1:
                            _visitPrice = (decimal)Settings.Default["KhVisitPriceSpecialist"];
                            break;
                        default:
                            _visitPrice = (decimal)Settings.Default["KhVisitPriceGeneral"];
                            break;
                    }
                    _visitOrganPercent = (int)Settings.Default["KhVisitOrganPercent"];
                    _organPercent = (int)Settings.Default["KhOrganPercent"];
                    break;
                default:
                    _kCoeff = 0;
                    _visitPrice = 0;
                    _visitOrganPercent = 0;
                    _organPercent = 0;
                    break;
            }
            if (this.aPageMode == PageMode.Mode_edit)
            {
                _kCoeff = OPrescription.KCoeff;
                _visitPrice = OPrescription.VisitPrice;
            }
            visitServiceID = GetVisitServiceID(1, assuranceID);
        }

        private void txtAssuranceNumber_Leave(object sender, EventArgs e)
        {
            if (_assuranceNumberChange && txtAssuranceCode.Text.Trim() != "")
            {
                aPageMode = PageMode.Mode_new;
                SelectPatient(txtAssuranceCode.Text.Trim());
                setPatientInfo();
            }
            else
            {
                this.OPatient = null;
                setPatientInfo();
            }
        }

        public void SelectPatient(string assuranceCode)
        {
            this.OPatient.PatientID = 0;
            FPrescriptionBLL.oPatient = OPatient;
            FPrescriptionBLL.SelectPatient(assuranceCode);
        }

        public void setPatientInfo()
        {
            if (this.OPatient.PatientID != 0)
            {
                _assuranceNumberChange = false;
                InitialFormPatientInfoSub(true);
            }
            else
            {
                OPatient = null;
                _assuranceNumberChange = false;
                _assuranceID = 0;
                InitialFormPatientInfoSub(false);
                if (txtAssuranceCode.Text.Trim() == string.Empty)
                    return;
                txtAssuranceCode.Focus();
                txtAssuranceCode.SelectionStart = 0;
                txtAssuranceCode.SelectionLength = txtAssuranceCode.TextLength;

            }
            InitialForm(false);
        }

        private void txtAssuranceNumber_TextChanged(object sender, EventArgs e)
        {
            _assuranceNumberChange = true;
        }

        private void GetDoctorList()
        {
            DataSet aDataSet;//=new DataSet();

            aDataSet = FDoctorBLL.GetDoctorList(true);
            cboDoctor.DataSource = aDataSet.Tables[0];
            cboDoctor.DisplayMember = "LastName";
            cboDoctor.ValueMember = "DoctorID";
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            ServicePickup aServicePickup = new ServicePickup();
            aServicePickup.ServiceAdded += new EventHandler(aServicePickup_ServiceAdded);
            aServicePickup.Owner = this;
            aServicePickup.OAssuranceService = this.OAssuranceService;
            aServicePickup.AssuranceID = OPatient.PatientAssuranceList[0].AssuranceID;
            aServicePickup.AssuranceName = OPatient.PatientAssuranceList[0].AssuranceName;
            aServicePickup.SelectedOrganKCoeff = _kCoeff;
            aServicePickup.TopMost = true;
            aServicePickup.ShowDialog();

        }

        Int16 _pageNumber = 0;
        Decimal _patientPayment = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPageNumber.Text.Trim() == "" || !Int16.TryParse(txtPageNumber.Text.Trim(), out _pageNumber))
            {
                errorProvider1.SetError(txtPageNumber, "شماره صفحه را وارد کنید");
                txtPageNumber.Focus();
                return;
            }

            if (txtPatientPayment.Text.Trim() == "" || !decimal.TryParse(txtPatientPayment.Text.Trim(), out _patientPayment))
            {
                errorProvider1.SetError(txtPatientPayment, "مبلغ پرداختی بیمار را وارد کنید");
                txtPatientPayment.Focus();
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
                    UtilMethods.LogError(ex, "1048");
                    MessageBox.Show("بروز خطا در ثبت اطلاعات نسخه جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (aPageMode == PageMode.Mode_edit)
                {
                    UtilMethods.LogError(ex, "1049");
                    MessageBox.Show("بروز خطا در ویرایش اطلاعات نسخه مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;

            }

            //InitialForm(false);
            OnBillSaved();
            this.Dispose();
            //this.Close();
        }

        public override void SetObject()
        {

            OPrescription.ActionDate = fdpActiondate.Text;
            OPrescription.DoctorID = Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]);
            OPrescription.AssuranceCode = txtAssuranceCode.Text;
            OPrescription.AssuranceID = OPatient.PatientAssuranceList[0].AssuranceID;
            OPrescription.KCoeff = _kCoeff;
            OPrescription.VisitPrice = _visitPrice;
            OPrescription.IsReferenced = chkIsReferenced.Checked;
            OPrescription.Month = (Int16)PersianDateConverter.ToPersianDate(fdpActiondate.SelectedDateTime).Month;
            OPrescription.PageNumber = _pageNumber;
            OPrescription.PatientID = OPatient.PatientID;
            OPrescription.ValidityDate = OPatient.PatientAssuranceList[0].ValidityDate;
            OPrescription.PatientPayment = _patientPayment;
            if (chkIsReferenced.Checked)
                OPrescription.ReferencedDate = fdpReferenceDate.Text;
            else
                OPrescription.ReferencedDate = "";
            OPrescription.Year = PersianDateConverter.ToPersianDate(fdpActiondate.SelectedDateTime).Year.ToString();
            OPrescription.AssuranceServiceList.Clear();
            OPrescription.AssuranceServiceList = _prescriptionDetailsListShadow;
        }

        public override void SaveInfo()
        {
            FPrescriptionBLL.OPrescription = this.OPrescription;
            try
            {
                if (aPageMode == PageMode.Mode_new)
                    SaveObject();
                else
                    EditObject();
                MessageBox.Show(".اطلاعات با موفقیت ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public override void SaveObject()
        {
            FPrescriptionBLL.SaveObject();
        }

        public override void EditObject()
        {
            FPrescriptionBLL.EditObject();
        }

        private void DeleteService(AssuranceService service)
        {
            OPrescription.AssuranceServiceList.Remove(service);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkIsReferenced_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsReferenced.Checked)
                fdpReferenceDate.Enabled = true;
            else
                fdpReferenceDate.Enabled = false;
        }

        private void OnBillSaved()
        {
            if (PrescriptionSaved != null)
                PrescriptionSaved(this, null);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("خدمت مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _prescriptionDetailsListShadow.Remove(OAssuranceService);
                if (OAssuranceService.ServiceID == 1)
                    visitExist = false;
                dgvServiceList.Refresh();
                InitialFormPriceInfoSub(false);
            }
        }

        private void dgvServiceList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvServiceList.Rows[e.RowIndex].Selected = true;
                //_selectdBillDetailsIndex = e.RowIndex;
                //_selectedBillDetailsPayment =(decimal) this.dgvBillPaymentList.Rows[e.RowIndex].Cells[1].Value;
                OAssuranceService = _prescriptionDetailsListShadow[e.RowIndex];

            }
        }

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            docorKind = (Int16)((DataRowView)cboDoctor.SelectedItem).Row[12];
            if (_assuranceID == 0)
                return;
            SetAssuranceInfo(_assuranceID);

            foreach (AssuranceService aS in _prescriptionDetailsListShadow)
            {

                if (aS.ServiceID != visitServiceID)
                    continue;

                aS.ServicePrice = _visitPrice;
                aS.PatientShare = aS.ServicePrice - (aS.ServicePrice * _visitOrganPercent / 100);
            }
            dgvServiceList.Refresh();
            InitialFormPriceInfoSub(false);
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            AssuranceService aAssuranceService = new AssuranceService();
            //switch (_assuranceID)
            //{
            //    case 2:
            //        //aAssuranceService.ServiceID = 1742;
            //        aAssuranceService.ServiceID = visitServiceID;
            //        break;
            //    case 3:
            //        //aAssuranceService.ServiceID = 3461;
            //        aAssuranceService.ServiceID = visitServiceID;
            //        break;
            //    default:
            //        break;
            //}
            if (visitServiceID == 0)
                return;
            aAssuranceService.ServiceID = visitServiceID;
            aAssuranceService.ServiceCode = "0";
            aAssuranceService.ServiceName = "ویزیت";
            aAssuranceService.ServicePrice = _visitPrice;
            aAssuranceService.PatientShare = aAssuranceService.ServicePrice - (aAssuranceService.ServicePrice * _visitOrganPercent / 100);

            _prescriptionDetailsListShadow.Add(aAssuranceService);
            dgvServiceList.Refresh();
            InitialFormPriceInfoSub(false);


        }

        private Int64 GetVisitServiceID(int headID, int assuranceID)
        {
            try
            {
            return FPrescriptionBLL.GetVisitServiceID(headID, assuranceID);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1050");
                MessageBox.Show("بروز خطا در دریافت اطلاعات ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int _VisitOrganPercent { get; set; }

        private void txtPageNumber_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void dgvServiceList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            dgvServiceList.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }
    }
}
