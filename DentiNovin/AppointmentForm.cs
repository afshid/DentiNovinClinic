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
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class AppointmentForm : BaseForm
    {

        private int _doctorID;
        public int DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; }
        }

        private Group _oGroup;
        public Group oGroup
        {
            get
            {
                if (_oGroup == null)
                    _oGroup = new Group();
                return _oGroup;
            }
            set { _oGroup = value; }
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

        private Appointment _selectedAppointment;
        public Appointment SelectedAppointment
        {
            get
            {
                if (_selectedAppointment == null)
                    _selectedAppointment = new Appointment();
                return _selectedAppointment;
            }
            set { _selectedAppointment = value; }
        }

        private List<Appointment> _lAppointment;
        public List<Appointment> LAppointment
        {
            get { return _lAppointment; }
            set { _lAppointment = value; }
        }

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

        private Boolean _fileNumberChanged = false;

        public AppointmentForm()
        {
            InitializeComponent();
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            GetDoctorList();
            txtFileNumber.Focus();
        }

        private void GetDoctorList()
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FDoctorBLL.GetDoctorList(true);
                cbxDoctor.DataSource = aDataSet.Tables[0];
                this.cbxDoctor.SelectedIndexChanged -= new System.EventHandler(this.cbxDoctor_SelectedIndexChanged);
                cbxDoctor.DisplayMember = "LastName";
                cbxDoctor.ValueMember = "DoctorID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1003");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.cbxDoctor.SelectedIndexChanged += new System.EventHandler(this.cbxDoctor_SelectedIndexChanged);
            }

        }

        private void GetGroup(string SelectedDate)
        {
            if (cbxDoctor.SelectedIndex == -1)
            {
                MessageBox.Show("لطفآ پزشک معالج را انتخاب نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            oGroup.DoctorID = Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]);
            if (cbxGroup.SelectedItem != null)
                oGroup.GroupCode = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[1]);
            else
                oGroup.GroupCode = 0;
            if (cbxGroup.SelectedItem != null)
                oGroup.GroupID = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[0]);
            else
                oGroup.GroupID = 0;
            try
            {
                FAppointmentFormBLL.oGroup = this.oGroup;
                FAppointmentFormBLL.GetGroup(SelectedDate);
                appointmentControl1.oGroup = this.oGroup;
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1004");
                MessageBox.Show("بروز خطا در بارگزاری لیست شیفتهای کاری", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                appointmentControl1.DSAppointment = GetAppointment(SelectedDate); ;
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1005");
                MessageBox.Show("بروز خطا در بارگزاری اطلاعات نوبت دهی", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataSet GetAppointment(string SelectedDate)
        {
            return FAppointmentFormBLL.GetAppointment(SelectedDate);
        }

        public void GetDoctorGroup(int DoctorID)
        {
            try
            {

                DataSet aDataSet = new DataSet();
                aDataSet = FAppointmentFormBLL.GetDoctorGroup(DoctorID);
                cbxGroup.DataSource = aDataSet.Tables[0];
                this.cbxGroup.SelectedIndexChanged -= new System.EventHandler(this.cbxGroup_SelectedIndexChanged);
                cbxGroup.DisplayMember = "Name";
                cbxGroup.ValueMember = "GroupCode";
                if (this.OPatient.PatientID != 0 && aDataSet.Tables[0] != null && aDataSet.Tables[0].Rows.Count != 0)
                    appointmentControl1.Registerable = true;
                else
                    appointmentControl1.Registerable = false;
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1006");
                MessageBox.Show("بروز خطا در بارگزاری لیست شیفتهای کاری", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.cbxGroup.SelectedIndexChanged += new System.EventHandler(this.cbxGroup_SelectedIndexChanged);
            }

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
                UtilMethods.LogError(ex, "1007");
                MessageBox.Show("بروز خطا در دریافت اطلاعات بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataSet GetPatientAppointment(int PatientID)
        {
            return FAppointmentFormBLL.GetPatientAppointment(PatientID);
        }

        private void txtFileNumber_TextChanged(object sender, EventArgs e)
        {
            _fileNumberChanged = true;
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
        }

        public void setPatientInfo()
        {
            appointmentControl1.Registerable = false;
            if (this.OPatient.PatientID != 0)
            {
                txtFileNumber.Text = this.OPatient.FileNumber.ToString();
                _fileNumberChanged = false;
                txtPatientName.Text = this.OPatient.FirstName;
                txtPatientLastName.Text = this.OPatient.LastName;
                cbxDoctor.SelectedValue = this.OPatient.DoctorID;
                FilldgvPatientAppointment(this.OPatient.PatientID);
                _fileNumberChanged = false;
                appointmentControl1.CurrentPatientID = this.OPatient.PatientID;
                IsNewPatient = false;
                btnPatientRegister.Text = "بیمار جدید";
                if (cbxDoctor.SelectedIndex == -1)
                {
                    MessageBox.Show("پزشک معالجِ بیمار،در لیست پزشکان فعال موجود نمی باشد.لطفآ پزشک دیگری انتخاب نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                appointmentControl1.Registerable = true;
            }
            else
            {
                this.OPatient = null;
                txtPatientName.Text = "";
                txtPatientLastName.Text = "";
                dgvPatientAppointment.DataSource = null;
                dgvPatientAppointment.Refresh();
                _fileNumberChanged = false;
                appointmentControl1.CurrentPatientID = 0;
                if (txtFileNumber.Text.Trim() == string.Empty)
                    return;
                txtFileNumber.Focus();
                txtFileNumber.SelectionStart = 0;
                txtFileNumber.SelectionLength = txtFileNumber.TextLength;
            }
        }

        private void cbxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDoctor.SelectedIndex != -1)
                GetDoctorGroup(Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]));
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroup(appointmentControl1.selectedPersianDate);
            appointmentControl1.DaysNumber = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[3]);
            appointmentControl1.InitialDataGridView();
        }

        private void FilldgvPatientAppointment(int PatientID)
        {
            try
            {
                DataSet aDataSet;
                dgvPatientAppointment.AutoGenerateColumns = false;
                aDataSet = GetPatientAppointment(PatientID);
                DataColumn aDataColumn = new DataColumn("RowNumber");
                DataColumn bDataColumn = new DataColumn("StartShortTime");
                aDataSet.Tables[0].Columns.Add(aDataColumn);
                aDataSet.Tables[0].Columns.Add(bDataColumn);
                for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                {
                    aDataSet.Tables[0].Rows[i]["RowNumber"] = i + 1;
                    aDataSet.Tables[0].Rows[i]["StartShortTime"] = new DateTime().Add(TimeSpan.FromTicks((Int64)aDataSet.Tables[0].Rows[i]["StartTime"])).TimeOfDay;
                }
                dgvPatientAppointment.DataSource = aDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1008");
                MessageBox.Show("بروز خطا در بارگزاری نوبتهای بیمار ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool IsNewPatient = false;
        private void btnPatientRegister_Click(object sender, EventArgs e)
        {
            if (!IsNewPatient)
            {
                txtFileNumber.Text = string.Empty;
                txtFileNumber_Leave(null, null);
                btnPatientRegister.Text = "ثبت بیمار جدید";
                IsNewPatient = true;
                txtPatientLastName.Focus();
                return;
            }
            if (txtPatientLastName.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPatientLastName, "نام خانوادگی راوارد کنید");
                txtPatientLastName.Focus();
                return;
            }
            if (txtPatientName.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPatientName, "نام را وارد کنید");
                txtPatientName.Focus();
                return;
            }
            OPatient.PatientID = 0;
            OPatient.LastName = txtPatientLastName.Text;
            OPatient.FirstName = txtPatientName.Text;
            OPatient.DoctorID = Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]);
            FPatientBLL.RunType = ((MainForm)this.MdiParent).RunType;
            FPatientBLL.oPatient = this.OPatient;
            try
            {
                FPatientBLL.PatientFastInsert();
            }
            catch (TrialException tex)
            {
                MessageBox.Show(tex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1009");
                MessageBox.Show("بروز خطا در ثبت اطلاعات بیمار جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("بیمار جدید با موفقیت ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtFileNumber.Text = OPatient.FileNumber.ToString();
            FilldgvPatientAppointment(OPatient.PatientID);
            appointmentControl1.Registerable = true;
            btnPatientRegister.Text = "بیمار جدید";
            IsNewPatient = false;
        }

        private void AppointmentForm_SizeChanged(object sender, EventArgs e)
        {
            appointmentControl1.Refresh();
        }

        private void appointmentControl1_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            GetGroup(appointmentControl1.selectedPersianDate);
            appointmentControl1.InitialDataGridView();
        }

        private void appointmentControl1_RegisterClicked(object sender, VisitNode e)
        {
            Appointment aAppointment = new Appointment();
            aAppointment.PatientID = OPatient.PatientID;
            aAppointment.GroupID = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[0]); //aNode.oGroup.GroupID;
            aAppointment.DoctorID = Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]); ;
            aAppointment.YearNumber = Convert.ToInt16(appointmentControl1.selectedPersianDate.Substring(0, 4));
            aAppointment.MonthNumber = Convert.ToInt16(appointmentControl1.selectedPersianDate.Substring(5, 2));
            aAppointment.DayNumber = e.DayNumber + 1;
            aAppointment.VisitDate = e.VisitDate;
            TimeSpan aTimeSpan = new TimeSpan(e.TimeIndex * this.oGroup.PeriodLength / 60, e.TimeIndex * this.oGroup.PeriodLength % 60, 0);
            aAppointment.StartTime = this.oGroup.StartTime + aTimeSpan;
            aAppointment.Index = e.TimeIndex;
            if (appointmentControl1.IsOutOfRange)
                aAppointment.Status = (int)AppointmentStatus.OutOfRange;
            else
                aAppointment.Status = (int)AppointmentStatus.Normal;
            try
            {
                FAppointmentFormBLL.Appointment = aAppointment;
                FAppointmentFormBLL.InsertNewAppointment();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1010");
                MessageBox.Show("بروز خطا در ثبت نوبت بیمار", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FAppointmentFormBLL.oGroup = this.oGroup;
            try
            {
                appointmentControl1.DSAppointment = GetAppointment(appointmentControl1.selectedPersianDate);
                appointmentControl1.DvgDataBinding();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1011");
                MessageBox.Show("بروز خطا در بارگزاری لیست نوبت دهی", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FilldgvPatientAppointment(OPatient.PatientID);
        }

        private void appointmentControl1_UnRegisterClicked(object sender, VisitNode e)
        {
            if (MessageBox.Show("رکوردانتخاب شده حذف خواهند شد آیا مطمئن هستید؟", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    FAppointmentFormBLL.DeleteAppointment(e.AppointmentID, (int)appointmentControl1.AptStatus);
                    FAppointmentFormBLL.oGroup = this.oGroup;
                    try
                    {
                        appointmentControl1.DSAppointment = GetAppointment(appointmentControl1.selectedPersianDate);
                        appointmentControl1.DvgDataBinding();
                    }
                    catch (Exception ex)
                    {
                        UtilMethods.LogError(ex, "1012");
                        MessageBox.Show("بروز خطا در بارگزاری لیست نوبت دهی", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (OPatient != null && OPatient.PatientID != 0)
                        FilldgvPatientAppointment(OPatient.PatientID);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show("بدلیل ثبت درمانی در این نوبت مراجعه امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPatientLastName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtPatientName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void appointmentControl1_ShowDossierClicked(object sender, VisitNode e)
        {
            if (e == null)
                return;
            SelectedAppointment.AppointmentID = e.AppointmentID;
            SelectedAppointment.VisitDate = e.VisitDate;
            SelectedAppointment.StartTime = e.StartTime;
            SelectedAppointment.DoctorID = (int)cbxDoctor.SelectedValue;
            ((MainForm)(this.ParentForm)).ShowSelectedPatientDossier(e.PatientID, SelectedAppointment);
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
        }

        private void dgvPatientAppointment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            int appointmentStatus = (byte)((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[10];
            if (appointmentStatus == 3 || appointmentStatus == 2)
                return;
            SelectedAppointment.AppointmentID = (Int64)((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[0];
            SelectedAppointment.VisitDate = ((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            SelectedAppointment.StartTime = new DateTime().Add(TimeSpan.FromTicks((Int64)((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[8])).TimeOfDay;
            ((MainForm)(this.ParentForm)).ShowSelectedPatientDossier(this.OPatient, SelectedAppointment);
        }

        private void appointmentControl1_ShowBillClicked(object sender, VisitNode e)
        {
            if (e == null)
                return;
            SelectedAppointment.AppointmentID = e.AppointmentID;
            SelectedAppointment.VisitDate = e.VisitDate;
            SelectedAppointment.StartTime = e.StartTime;
            ((MainForm)(this.ParentForm)).ShowSelectedPatientBill(e.PatientID, SelectedAppointment);
        }

        private void dgvPatientAppointment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            switch ((byte)((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[10])
            {
                case 2:
                    //dgvPatientAppointment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
                    break;
                case 3:
                    //dgvPatientAppointment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    break;
                case 4:
                    dgvPatientAppointment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
                    break;
            }
        }

        private void appointmentControl1_PatientEnterClicked(object sender, VisitNode e)
        {
            try
            {
                FAppointmentFormBLL.SetAppointmentStatus(e.AppointmentID, (int)appointmentControl1.AptStatus);
                FAppointmentFormBLL.oGroup = this.oGroup;
                try
                {
                    appointmentControl1.DSAppointment = GetAppointment(appointmentControl1.selectedPersianDate);
                    appointmentControl1.DvgDataBinding();
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1012");
                    MessageBox.Show("بروز خطا در بارگزاری لیست نوبت دهی", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FilldgvPatientAppointment(OPatient.PatientID);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                UtilMethods.LogError(ex, "1084");
                MessageBox.Show("بروز خطا در ثبت وضعیت مراجعه", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void appointmentControl1_RefreshRequested(object sender, EventArgs e)
        {
            cbxGroup_SelectedIndexChanged(null, null);
        }


    }
}
