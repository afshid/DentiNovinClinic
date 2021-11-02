using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiClinic.Common;
using DentiClinic.BusinessLogic;
using DentiClinic.Common.DateConvert;

namespace DentiClinic
{
    public partial class TimesForm : Form
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
            get {
                if (_oGroup == null)
                    _oGroup = new Group();
                return _oGroup; }
            set { _oGroup = value; }
        }

        private Patient _oPatient;
        public Patient OPatient
        {
            get {
                if (_oPatient == null)
                    _oPatient = new Patient();
                
                return _oPatient; }
            set { _oPatient = value; }
        }

        private List<TimesWeek> _lTimesWeek;
        public List<TimesWeek> LTimesWeek
        {
            get { return _lTimesWeek; }
            set { _lTimesWeek = value; }
        }

        private TimesFormBLL _fTimesFormBLL;
        public TimesFormBLL FTimesFormBLL
        {
            get
            {
                if (_fTimesFormBLL == null)
                    _fTimesFormBLL = new TimesFormBLL();
                return _fTimesFormBLL;
            }
            set
            {
                _fTimesFormBLL = value;
            }
        }


        private Boolean _fileNumberChanged = false;

        public TimesForm()
        {
            //this.visitTable1.SelectedDateTime = DateTime.Now;
            InitializeComponent();
        }

        private void TimesForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // this.visitTable1.SelectedDateTime = DateTime.Now;
            GetDoctorList();
        }

        private void GetDoctorList()
        {
            DataSet aDataSet;//=new DataSet();
            aDataSet = FTimesFormBLL.GetDoctorList();
            cbxDoctor.DataSource = aDataSet.Tables[0];
            cbxDoctor.DisplayMember = "LastName";
            cbxDoctor.ValueMember = "DoctorID";
        }

        private void GetGroup(string SelectedDate)
        {
            oGroup.DoctorID = Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]);
            if (cbxGroup.SelectedItem != null)
                oGroup.GroupCode = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[1]);
            else
                oGroup.GroupCode = 0;
            if (cbxGroup.SelectedItem != null)
                oGroup.GroupID = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[0]);
            else
                oGroup.GroupID = 0;


            FTimesFormBLL.oGroup = this.oGroup;
            FTimesFormBLL.GetGroup(SelectedDate);
            visitTable1.oGroup = this.oGroup;
            visitTable1.DSTimesWeek = GetTimesWeek(SelectedDate);
        }

        private DataSet GetTimesWeek(string SelectedDate)
        {
            DataSet aDataSet = new DataSet();
            return FTimesFormBLL.GetTimesWeek(SelectedDate);
        }

        public void GetDoctorGroup(int DoctorID)
        {
            DataSet aDataSet = new DataSet();
            aDataSet = FTimesFormBLL.GetDoctorGroup(DoctorID);
            cbxGroup.DataSource = aDataSet.Tables[0];
            cbxGroup.DisplayMember = "Name";
            cbxGroup.ValueMember = "GroupCode";
        }

        private void visitTable1_MonthChanged(object sender, EventArgs e)
        {
            GetGroup(visitTable1.selectedPersianDate);
        }

        public void GetPatient()
        {
            OPatient.FileNumber = Convert.ToInt32(txtFileNumber.Text);
            FTimesFormBLL.OPatient = this.OPatient;
            FTimesFormBLL.GetPatient();
        }

        public DataSet GetPatientTimesWeek(int PatientID)
        {
            return FTimesFormBLL.GetPatientTimesWeek(PatientID);
        }

        private void txtFileNumber_TextChanged(object sender, EventArgs e)
        {
            _fileNumberChanged = true;
        }

        private void txtFileNumber_Leave(object sender, EventArgs e)
        {
            if (_fileNumberChanged && txtFileNumber.Text != "")
            {
                GetPatient();
                if (OPatient.RowEffected)
                {
                    txtPatientName.Text = OPatient.FirstName;
                    txtPatientLastName.Text = OPatient.LastName;
                    cbxDoctor.SelectedValue = OPatient.DoctorID;
                    FilldgvPatientTimesWeek(OPatient.PatientID);
                    visitTable1.Registerable = true;
                    _fileNumberChanged = false;
                }
                else
                    visitTable1.Registerable = false;
            }
        }

        private void cbxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDoctorGroup(Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]));
        }

        private void cbxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroup(visitTable1.selectedPersianDate);
            visitTable1.DaysNumber = Convert.ToInt32(((DataRowView)cbxGroup.SelectedItem).Row[3]); 
            visitTable1.Repaint();
        }

        private void FilldgvPatientTimesWeek(int PatientID)
        {
            DataSet aDataSet;
            dgvPatientTimesWeek.AutoGenerateColumns = false;
            aDataSet = GetPatientTimesWeek(PatientID);
            DataColumn aDataColumn = new DataColumn("RowNumber");
            DataColumn bDataColumn = new DataColumn("StartShortTime");
            aDataSet.Tables[0].Columns.Add(aDataColumn);
            aDataSet.Tables[0].Columns.Add(bDataColumn);
            for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
            {
                aDataSet.Tables[0].Rows[i]["RowNumber"] = i + 1;
                aDataSet.Tables[0].Rows[i]["StartShortTime"] = System.Convert.ToDateTime(aDataSet.Tables[0].Rows[i]["StartTime"]).TimeOfDay;
            }

            dgvPatientTimesWeek.DataSource = aDataSet.Tables[0];

        }

        private void visitTable1_RegisterClicked(object sender, System.Collections.ArrayList Node)
        {
            TimesWeek aTimesWeek = new TimesWeek();

            Boolean goAction = false;
            LTimesWeek = new List<TimesWeek>();
            foreach (Node aNode in Node)
            {
                if (aNode.oPatient == null)
                {
                    goAction = true;
                    //TimesWeek aTimesWeek = new TimesWeek();
                    aTimesWeek.PatientID = OPatient.PatientID;
                    aTimesWeek.GroupID = aNode.oGroup.GroupID;
                    aTimesWeek.DoctorID = Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]); ;

                    aTimesWeek.YearNumber = Convert.ToInt16(visitTable1.selectedPersianDate.Substring(0, 4));
                    aTimesWeek.MonthNumber = Convert.ToInt16(visitTable1.selectedPersianDate.Substring(5, 2));
                    aTimesWeek.DayNumber = aNode.dIndex + 1;

                    aTimesWeek.VisitDate = visitTable1.selectedPersianDate.Substring(0, 4) + "/" + visitTable1.selectedPersianDate.Substring(5, 2) + "/" + Utilities.toDouble(aTimesWeek.DayNumber);


                    TimeSpan aTimeSpan = new TimeSpan(aNode.nIndex * aNode.oGroup.PeriodLength / 60, aNode.nIndex * aNode.oGroup.PeriodLength % 60, 0);

                    aTimesWeek.StartTime = aNode.oGroup.StartTime + aTimeSpan;
                    aTimesWeek.Index = aNode.nIndex;
                    LTimesWeek.Add(aTimesWeek);
                }
            }
            if (goAction)
            {
                FTimesFormBLL.TimesWeek = aTimesWeek;
                FTimesFormBLL.InsertNewTimesWeek();
                FTimesFormBLL.oGroup = this.oGroup;
                visitTable1.DSTimesWeek = GetTimesWeek(visitTable1.selectedPersianDate);
                FilldgvPatientTimesWeek(OPatient.PatientID);
            }

        }

        private void visitTable1_UnRegisterClicked(object sender, System.Collections.ArrayList Node)
        {
            if (MessageBox.Show("رکورد(های) انتخاب شده حذف خواهند شد آیا مطمئن هستید؟", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string qString = string.Empty;
                Boolean goAction = false;
                foreach (Node aNode in Node)
                {
                    goAction = true;
                    qString = qString + "," + aNode.rIndex;
                }

                if (goAction)
                {
                    //FTimesFormBLL.DeleteTimesWeek(qString.Substring(1, qString.Length - 1));
                    FTimesFormBLL.oGroup = this.oGroup;
                    visitTable1.DSTimesWeek = GetTimesWeek(visitTable1.selectedPersianDate);
                }
                if (OPatient != null && OPatient.PatientID != 0)
                    FilldgvPatientTimesWeek(OPatient.PatientID);
            }

        }

        private void btnPatientRegister_Click(object sender, EventArgs e)
        {
            OPatient.LastName = txtPatientLastName.Text;
            OPatient.FirstName = txtPatientName.Text;
            //OPatient.FileNumber = 0;
            OPatient.DoctorID = Convert.ToInt32(((DataRowView)cbxDoctor.SelectedItem).Row[0]);

            PatientBLL aPatientBLL = new PatientBLL();
            aPatientBLL.oPatient = this.OPatient;
            aPatientBLL.PatientFastInsert();
            if (!this.OPatient.RowEffected)
            {
                MessageBox.Show(this.OPatient.ActionMessage);
                return;
            }

            txtFileNumber.Text = OPatient.FileNumber.ToString();
            FilldgvPatientTimesWeek(OPatient.PatientID);
            visitTable1.Registerable = true;
        }

        private void visitTable1_ShowDossierClicked(object sender, System.Collections.ArrayList Node)
        {
           // PatientTreatmentForm aPatientVisitForm = new PatientTreatmentForm(((Node)Node[0]).oPatient.FileNumber);
           // //aPatientVisitForm.MdiParent = this.MdiParent;
           //// aPatientVisitForm.FormBorderStyle = FormBorderStyle.FixedDialog;
           // aPatientVisitForm.Owner = this;
           // aPatientVisitForm.TopMost=true;
           // aPatientVisitForm.ShowDialog();
        }

        private void TimesForm_SizeChanged(object sender, EventArgs e)
        {
            visitTable1.Refresh();
        }

    }
}
