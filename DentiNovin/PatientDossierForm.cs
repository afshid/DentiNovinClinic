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
using DentiClinic.BaseClasses;
using DentiClinic.Controls;

namespace DentiClinic
{
    public partial class PatientDossierForm : BaseForm
    {
        private Patient _oPatient;
        public Patient OPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        private PatientTreatmentInfo _oPatientTreatmentInfo;
        public PatientTreatmentInfo oPatientTreatmentInfo
        {
            get
            {
                if (_oPatientTreatmentInfo == null)
                    _oPatientTreatmentInfo = new PatientTreatmentInfo();
                return _oPatientTreatmentInfo;
            }
            set { _oPatientTreatmentInfo = value; }
        }

        private PatientDossierBLL _fPatientDossierBLL;
        public PatientDossierBLL FPatientDossierBLL
        {
            get
            {
                if (_fPatientDossierBLL == null)
                    _fPatientDossierBLL = new PatientDossierBLL();
                return _fPatientDossierBLL;
            }
            set
            {
                _fPatientDossierBLL = value;
            }
        }

        private List<cTooth> _selectedTeeth = new List<cTooth>();
        private Boolean _fileNumberChanged = false;


        public PatientDossierForm()
        {
            InitializeComponent();
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
                    if (OPatient.Sex)
                        txtSex.Text = "مرد";
                    else
                        txtSex.Text = "زن";
                    txtAge.Text = OPatient.Age.ToString();
                    FilldgvTreatment(OPatient.PatientID);
                    TeethControl.MultiSelect = true;
                    TeethControl.PreviewMode = true;
                    TeethControl.LSelectedTeeth = _selectedTeeth;
                    TeethControl.ResetControl(false);
                    _fileNumberChanged = false;
                }
            }
        }

        public void GetPatient()
        {
            TimesFormBLL aTimesFormBLL = new TimesFormBLL();
            OPatient = new Patient();
            OPatient.FileNumber = Convert.ToInt32(txtFileNumber.Text);
            aTimesFormBLL.OPatient = this.OPatient;
            aTimesFormBLL.GetPatient();
        }

        private void FilldgvTreatment(int PatientID)
        {
            FilldgvTreatment(PatientID, 0, 0);
        }

        private void FilldgvTreatment(int PatientID, int ToothNumber, int ToothDirection)
        {
            Int16 tDir;
            Int16 tNum;
            DataSet aDataSet;
            dgvTreatment.AutoGenerateColumns = false;
            aDataSet = FPatientDossierBLL.GetAccomplishedTreatmentList(PatientID, ToothNumber, ToothDirection);
            DataColumn aDataColumn = new DataColumn("RowNumber");
            aDataSet.Tables[0].Columns.Add(aDataColumn);

            DataColumn bDataColumn = new DataColumn("pToothDirection");
            aDataSet.Tables[0].Columns.Add(bDataColumn);

            DataColumn cDataColumn = new DataColumn("lToothDirection");
            aDataSet.Tables[0].Columns.Add(cDataColumn);
            _selectedTeeth.Clear();
            for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
            {
                aDataSet.Tables[0].Rows[i]["RowNumber"] = i + 1;
                tDir = (short)aDataSet.Tables[0].Rows[i][4];
                tNum = (short)aDataSet.Tables[0].Rows[i][3];
                _selectedTeeth.Add(TeethControl.CreateTooth(tNum, tDir));
                aDataSet.Tables[0].Rows[i]["pToothDirection"] = UtilMethods.GetToothDirection(tDir);
                if (tDir >= 5)
                    tNum += 8;
                aDataSet.Tables[0].Rows[i]["lToothDirection"] = UtilMethods.GetToothNumber(tNum);

            }
            dgvTreatment.DataSource = aDataSet.Tables[0];

        }

        private void InitialForm(Boolean SetValue)
        {
            string ToothDirection = string.Empty;
            string ToothNumber = string.Empty;
            string TreatmentCode = string.Empty;
            string TreatmentTitle = string.Empty;
            string Description = string.Empty;
            string VisitDate = string.Empty;
            string DoctorName = string.Empty;
            string ToothKind = string.Empty;
            if (SetValue)
            {
                TreatmentTitle = oPatientTreatmentInfo.TreatmentTitle;
                VisitDate = oPatientTreatmentInfo.VisitDate;
                Description = oPatientTreatmentInfo.Description;
                DoctorName = oPatientTreatmentInfo.DoctorName;
                if (Convert.ToInt32(oPatientTreatmentInfo.ToothDirection) > 4)
                    ToothKind = "موقتی";
                else
                    ToothKind = "دائمی";
            }
            txtTreatment.Text = TreatmentTitle;
            txtTreatmentDate.Text = VisitDate;
            txtToothKind.Text = ToothKind;
            txtTreatmentDoctor.Text = DoctorName;
            txtDescription.Text = Description;
        }

        private void TeethControl_LastSelectedToothChanged(object sender, cTooth tooth)
        {
            FilldgvTreatment(OPatient.PatientID, tooth.ToothNumber, tooth.ToothDirection);
        }

        private void dgvTreatment_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            oPatientTreatmentInfo.ToothDirection = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            oPatientTreatmentInfo.ToothNumber = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3].ToString();
            oPatientTreatmentInfo.TreatmentCode = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1].ToString();
            oPatientTreatmentInfo.TreatmentTitle = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[2].ToString();
            oPatientTreatmentInfo.Description = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[7].ToString();
            oPatientTreatmentInfo.VisitDate =((DateTime)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[12]).ToShortDateString();
            oPatientTreatmentInfo.DoctorName = ((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[11].ToString();
            InitialForm(true);
        }

    }

    public class PatientTreatmentInfo
    {
        public string ToothDirection { get; set; }
        public string ToothNumber { get; set; }
        public string TreatmentCode { get; set; }
        public string TreatmentTitle { get; set; }
        public string Description { get; set; }
        public string VisitDate { get; set; }
        public string DoctorName { get; set; }

    }
}
