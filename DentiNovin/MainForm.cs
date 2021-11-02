using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using DentiNovin;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;
using DentiNovin.Properties;
using DentiNovin.BaseClasses;
using DentiNovin.BusinessLogic;
using Microsoft.Win32;
using System.Security.Cryptography;
using DentiNovin.Common.SerialMaker;
using System.IO;

using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Resources;
using System.Globalization;


namespace DentiNovin
{
    public partial class MainForm : BaseForm
    {
        private User _oUserM;
        public User OUserM
        {
            get
            {
                if (_oUserM == null)
                    _oUserM = new User();
                return _oUserM;
            }
            set { _oUserM = value; }
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

        private Patient _oPatient;
        public Patient oPatient
        {
            get
            {
                if (_oPatient == null)
                    _oPatient = new Patient();
                return _oPatient;
            }
            set { _oPatient = value; }
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

        private Appointment _currentAppointment;
        public Appointment CurrentAppointment
        {
            get
            {
                if (_currentAppointment == null)
                    _currentAppointment = new Appointment();
                return _currentAppointment;
            }
            set { _currentAppointment = value; }
        }

        private int childFormNumber = 0;

        private SerialMaker aSerialMaker;

        public SerialMaker.RunTypes RunType { get; set; }

        public bool ShowAlert { get; set; }

        public int SelectedAssuranceID { get; set; }

        public PatientListDock oPatientListDock;
        public AppointmentListDock oAppointmentListDock;
        public X_RayDock oX_RayDock = new X_RayDock();

        public int[] PermanetToothNumberList { get; set; }
        public string[] PrimaryToothNumberList { get; set; }

        public int[] FdiPermanetToothNumberList { get; set; }
        public string[] FdiPrimaryToothNumberList { get; set; }

        public int[] PlrPermanetToothNumberList { get; set; }
        public string[] PlrPrimaryToothNumberList { get; set; }


        public MainForm(SerialMaker sMaker, SerialMaker.RunTypes runType)
        {
           // ResourceManager resources = new ResourceManager("",(typeof(MainForm));

            InitializeComponent();
            //this.Text = global::DentiNovin.Properties.Resources.txt_MainCaption;//resources.GetString("txt_MainCaption", CultureInfo.CreateSpecificCulture("en"));
            this.aSerialMaker = sMaker;
            this.RunType = runType;
            InitialAppointmentListDock();
            InitialPatientListDock();
            InitialoXRayDock();
        }

        void CurrentAppointmentChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ویزیت مورد نظر انتخاب شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.CurrentAppointment = oAppointmentListDock.SelectedAppointment;
            tssVisitTime.Text = this.CurrentAppointment.VisitDate;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.RunType == SerialMaker.RunTypes.Full)
                registrationSubMenu.Visible = false;
            LoginForm aloginform = new LoginForm();
            aloginform.OUserF = this.OUserM;
            aloginform.ShowDialog();
            if (aloginform.DialogResult == DialogResult.Abort)
            {
                aloginform.Dispose();
                aloginform = null;
                this.Dispose();
                return;
            }

            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].Culture.EnglishName == "Persian")
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }

            PermanetToothNumberList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
            PrimaryToothNumberList = new string[] { "", "", "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "", "", "", "", "", "", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "", "", "" };

            FdiPermanetToothNumberList = new int[] { 28, 27, 26, 25, 24, 23, 22, 21, 11, 12, 13, 14, 15, 16, 17, 18, 48, 47, 46, 45, 44, 43, 42, 41, 31, 32, 33, 34, 35, 36, 37, 38 };
            FdiPrimaryToothNumberList = new string[] { "", "", "", "65", "64", "63", "62", "61", "51", "52", "53", "54", "55", "", "", "", "", "", "", "85", "84", "83", "82", "81", "71", "72", "73", "74", "75", "", "", "" };

            PlrPermanetToothNumberList = new int[] { 8, 7, 6, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 6, 7, 8 };
            PlrPrimaryToothNumberList = new string[] { "", "", "", "E", "D", "C", "B", "A", "A", "B", "C", "D", "E", "", "", "", "", "", "", "E", "D", "C", "B", "A", "A", "B", "C", "D", "E", "", "", "" };

            oPatientListDock.Show(dockPanel1, DockState.DockRightAutoHide);

            oAppointmentListDock.Show(dockPanel1, DockState.DockRight);
            oAppointmentListDock.DockState = DockState.DockRightAutoHide;
            oX_RayDock.Show(dockPanel1, DockState.DockRight);
            oX_RayDock.DockState = DockState.DockRightAutoHide;
            if (UtilMethods.CheckPermission(3, this.OUserM))
                MdiFormSingleton<AppointmentForm>.ShowChild(this);
        }

        private void TimeMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.AppointmentForm, this.OUserM))
                return;
            MdiFormSingleton<AppointmentForm>.ShowChild(this);
        }

        private void CurrentPatientChange(object sender, EventArgs e)
        {
            CloseForms();
            if (UtilMethods.CheckPermission(7, this.OUserM))
                MdiFormSingleton<TreatmentChartForm>.ShowChild(this);
            ChangeCurrentPatient(true, false);
        }

        private void ChangeCurrentPatient(bool closeOpenForms, bool isNewAppointment)
        {
            oAppointmentListDock.FilldgvPatientAppointment(oPatient.PatientID);
            oX_RayDock.PatientID = oPatient.PatientID;
            oX_RayDock.GetXRayImages(this.oPatient.PatientID);
            //foreach (Form cdForm in this.MdiChildren)
            //{
            //    if (closeOpenForms && !cdForm.GetType().Equals(typeof(AppointmentForm)))
            //        cdForm.Dispose();
            //}
            tssPatientName.Text = this.oPatient.FirstName + "  " + this.oPatient.LastName;
            tssFileNumber.Text = this.oPatient.FileNumber.ToString();
            tssVisitTime.Text = "";

            if (!isNewAppointment)
                this.CurrentAppointment = null;
            else
                tssVisitTime.Text = this.CurrentAppointment.VisitDate;

        }

        private void CloseForms()
        {
            foreach (Form cdForm in this.MdiChildren)
            {
                if (!cdForm.GetType().Equals(typeof(AppointmentForm)))
                    cdForm.Dispose();
            }
        }

        public void ShowSelectedPatientDossier(Int32 patientID, Appointment selAppointment)
        {
            try
            {
                this.oPatient.PatientID = patientID;
                FPatientBLL.oPatient = this.oPatient;
                FPatientBLL.GetPatientByID();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1036");
                MessageBox.Show("بروز خطا در دریافت اطلاعات بیمار مورد نظر ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.CurrentAppointment = selAppointment;
            CloseForms();
            if (UtilMethods.CheckPermission(7, this.OUserM))
                MdiFormSingleton<TreatmentChartForm>.ShowChild(this);
            ChangeCurrentPatient(true, true);
        }

        public void ShowSelectedPatientDossier(Patient selPatient, Appointment selAppointment)
        {
            this.oPatient = selPatient;
            CloseForms();
            if (UtilMethods.CheckPermission(7, this.OUserM))
                MdiFormSingleton<TreatmentChartForm>.ShowChild(this);
            ChangeCurrentPatient(true, true);
        }

        public void ShowSelectedPatientBill(Int32 patientID, Appointment selAppointment)
        {
            try
            {
                this.oPatient.PatientID = patientID;
                FPatientBLL.oPatient = this.oPatient;
                FPatientBLL.GetPatientByID();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1037");
                MessageBox.Show("بروز خطا در دریافت اطلاعات بیمار مورد نظر ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.CurrentAppointment = selAppointment;
            CloseForms();
            if (UtilMethods.CheckPermission(8, this.OUserM))
                MdiFormSingleton<BillListForm>.ShowChild(this);
            ChangeCurrentPatient(true, true);
        }

        public void ShowSelectedPatientBill(Patient selPatient, Appointment selAppointment)
        {
            this.oPatient = selPatient;
            CloseForms();
            if (UtilMethods.CheckPermission(8, this.OUserM))
                MdiFormSingleton<BillListForm>.ShowChild(this);
            ChangeCurrentPatient(true, true);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            OpenAppointmentListDock();
        }

        public void OpenAppointmentListDock()
        {
            if (oAppointmentListDock.IsDisposed)
            {
                InitialAppointmentListDock();
                oAppointmentListDock.Show(dockPanel1, DockState.DockLeftAutoHide);
            }
        }

        private void InitialAppointmentListDock()
        {
            oAppointmentListDock = new AppointmentListDock();
            oAppointmentListDock.RightToLeftLayout = RightToLeftLayout;
            oAppointmentListDock.oPatient = this.oPatient;
            oAppointmentListDock.AppointmentSelected += new EventHandler(CurrentAppointmentChanged);
        }

        private void InitialoXRayDock()
        {
            oX_RayDock = new X_RayDock();
            oX_RayDock.RightToLeftLayout = RightToLeftLayout;
            oX_RayDock.PatientID = this.oPatient.PatientID;
        }

        private void InitialPatientListDock()
        {
            oPatientListDock = new PatientListDock();
            oPatientListDock.RightToLeftLayout = RightToLeftLayout;
            oPatientListDock.oPatient = this.oPatient;
            oPatientListDock.PatientSelected += new EventHandler(CurrentPatientChange);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (oPatientListDock.IsDisposed)
            {
                InitialPatientListDock();
                oPatientListDock.Show(dockPanel1, DockState.DockLeftAutoHide);
            }
        }

        //private bool CheckPermission(int id)
        //{
        //    bool isPermit = false;
        //    if (OUserM == null || OUserM.LForms == null)
        //        return false;
        //    foreach (Forms frm in OUserM.LForms)
        //    {
        //        if (frm.FormID == id)
        //            isPermit = true;
        //    }
        //    if (!isPermit)
        //        MessageBox.Show("!محدودیت در دسترسی به این صفحه", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    return isPermit;
        //}

        private void PatientTreatmentMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.PatientTreatmentForm, this.OUserM))
                return;
            if (oPatient.PatientID == 0)
            {
                MessageBox.Show("برای ثبت درمان ابتدا بیمار مورد نظر خود راانتخاب نمایید", "");
                oPatientListDock.Activate();
                return;
            }
            MdiFormSingleton<TreatmentChartForm>.ShowChild(this);
        }

        private void PatientBillMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.BillList, this.OUserM))
                return;
            MdiFormSingleton<BillListForm>.ShowChild(this);
        }

        private void PatientListMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.PatientForm, this.OUserM))
                return;
            MdiFormSingleton<PatientForm>.ShowChild(this);
        }

        private void UserListSubMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.UserForm, this.OUserM))
                return;
            MinimizeOpenForms();
            //MdiFormSingleton<UserAccessForm>.Form.ShowDialog();
            MdiFormSingleton<UserAccessForm>.ShowChild(this);
        }

        private void ShiftSubMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.GroupForm, this.OUserM))
                return;
            MinimizeOpenForms();
            //MdiFormSingleton<GroupForm>.Form.ShowDialog();
            MdiFormSingleton<GroupForm>.ShowChild(this);
        }

        private void DoctorListSubMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.DoctorForm, this.OUserM))
                return;
            MinimizeOpenForms();
            //MdiFormSingleton<DoctorForm>.Form.ShowDialog();
            MdiFormSingleton<DoctorForm>.ShowChild(this);
        }

        private void TreatmentListMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.TreatmentForm, this.OUserM))
                return;
            //MinimizeOpenForms();
            MdiFormSingleton<TreatmentServiceForm>.ShowChild(this);
        }

        private void ReportMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.ReportsForm, this.OUserM))
                return;
            MdiFormSingleton<DentiReportsMakerForm>.ShowChild(this);
        }

        private void SetupMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.SetupForm, this.OUserM))
                return;
            MinimizeOpenForms();
            MdiFormSingleton<SetupForm>.ShowChild(this);
            //FormSingleton<SetupForm>.Form.ShowDialog();
        }

        private void AboutSubMenu_Click(object sender, EventArgs e)
        {
            MinimizeOpenForms();
            MdiFormSingleton<AboutForm>.ShowChild(this);
        }

        private void NotifierSubMenu_Click(object sender, EventArgs e)
        {
            // MdiFormSingleton<NotifierForm>.ShowChild(this);

            //MdiFormSingleton<Form1>.ShowChild(this);
        }

        private void MinimizeOpenForms()
        {
            foreach (Form cdForm in this.MdiChildren)
            {
                cdForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void DisketButtonMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.PrescriptionList, this.OUserM))
                return;
            MdiFormSingleton<PrescriptionListForm>.ShowChild(this);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //MdiFormSingleton<BillFormOld>.ShowChild(this);
        }

        private void AssuranceTreatmentListMenu_Click(object sender, EventArgs e)
        {
            // MinimizeOpenForms();

        }

        private void KhAssuranceTreatmentListMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.ServiceForm, this.OUserM))
                return;
            SelectedAssuranceID = 3;
            foreach (Form cdForm in this.MdiChildren)
            {
                if (cdForm.GetType().Equals(typeof(AssuranceServiceForm)))
                    cdForm.Dispose();
            }
            MdiFormSingleton<AssuranceServiceForm>.ShowChild(this);
        }

        private void MoAssuranceTreatmentListMenu_Click(object sender, EventArgs e)
        {
            if (!UtilMethods.CheckPermission((int)DentiForms.ServiceForm, this.OUserM))
                return;
            SelectedAssuranceID = 2;
            foreach (Form cdForm in this.MdiChildren)
            {
                if (cdForm.GetType().Equals(typeof(AssuranceServiceForm)))
                    cdForm.Dispose();
            }
            MdiFormSingleton<AssuranceServiceForm>.ShowChild(this);
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MdiFormSingleton<HelpForm>.ShowChild(this);
            string curDir = Directory.GetCurrentDirectory();
            Process.Start(String.Format("file:///{0}/DentiNovinTutorials.htm", curDir));
        }

        private void registrationSubMenu_Click(object sender, EventArgs e)
        {
            RegistrationForm aRegistrationForm = new RegistrationForm(this.aSerialMaker);
            if (aRegistrationForm.ShowDialog() == DialogResult.OK)
            {
                registrationSubMenu.Visible = false;
                this.RunType = DentiNovin.Common.SerialMaker.SerialMaker.RunTypes.Full;
            }
        }

        private void BackupMenu_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            GetBackup(curDir + "\\Data\\a.bak", curDir + "\\Data\\MNMDentiDB.mdf"); 
        }

        private void GetBackup(string filePath, string databaseName)
        {
            //try
            //{
            //    Microsoft.SqlServer.Management.Smo.Server localServer = new Microsoft.SqlServer.Management.Smo.Server();
            //    Microsoft.SqlServer.Management.Smo.Backup backupMgr = new Microsoft.SqlServer.Management.Smo.Backup();
            //    backupMgr.Devices.AddDevice(filePath, Microsoft.SqlServer.Management.Smo.DeviceType.File);
            //    backupMgr.Database = databaseName;
            //    backupMgr.Action = Microsoft.SqlServer.Management.Smo.BackupActionType.Database;
            //    backupMgr.SqlBackup(localServer);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + " " + ex.InnerException);
            //}

            try
            {
                //String destinationPath = "C:\\";
                //Microsoft.SqlServer.Management.Smo.Backup sqlBackup = new Microsoft.SqlServer.Management.Smo.Backup();
                //sqlBackup.Action = Microsoft.SqlServer.Management.Smo.BackupActionType.Database;
                //sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString();
                //sqlBackup.BackupSetName = "Archive";
                //Microsoft.SqlServer.Management.Smo.BackupDeviceItem deviceItem = new Microsoft.SqlServer.Management.Smo.BackupDeviceItem(destinationPath, Microsoft.SqlServer.Management.Smo.DeviceType.File);
                //ServerConnection connection = new ServerConnection(".\\SQLEXPRESS");
                //Microsoft.SqlServer.Management.Smo.Server sqlServer = new Microsoft.SqlServer.Management.Smo.Server(connection);
                //StringCollection sc = new StringCollection();
                //sc.Add(Directory.GetCurrentDirectory() + "\\Data\\MNMDentiDB.mdf"); //Bin directory
                //sc.Add(Directory.GetCurrentDirectory() + "\\Data\\MNMDentiDB.ldf");
                //sqlServer.AttachDatabase("Xmain", sc);
                //Microsoft.SqlServer.Management.Smo.Database db = sqlServer.Databases["Xmain"];
                //sqlBackup.Initialize = true;
                //sqlBackup.Checksum = true;
                //sqlBackup.ContinueAfterError = true;

                //sqlBackup.Devices.Add(deviceItem);
                //sqlBackup.Incremental = false;

                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                //sqlBackup.LogTruncation = Microsoft.SqlServer.Management.Smo.BackupTruncateLogType.Truncate;

                //sqlBackup.FormatMedia = false;

                //sqlBackup.SqlBackup(sqlServer);
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].Culture.EnglishName == "English (United States)")
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }
        }

    }
}
