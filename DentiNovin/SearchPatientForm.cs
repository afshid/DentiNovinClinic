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
using System.Globalization;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class SearchPatientForm : BaseForm
    {
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

        private DataSet aDataSet;

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

        public event PatientSelectEventHandler PatientSelected;

        public SearchPatientForm()
        {
            InitializeComponent();
        }

        public void FillGrid()
        {
            try
            {
                int _fileNumber = 0;
                string _patientLastname = string.Empty;
                _patientLastname = txtLastName.Text.Trim();

                bool parsed = int.TryParse(txtFileNumber.Text.Trim(), out _fileNumber);

                dgvPatient.AutoGenerateColumns = false;
                aDataSet = FPatientBLL.SelectPatientListByField(_fileNumber, _patientLastname,true);
                dgvPatient.DataSource = aDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1055");
                MessageBox.Show("بروز خطا در بارگزاری لیت بیماران", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void txtFileNumber_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dgvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            OPatient.DoctorID = 0;
            if (((System.Data.DataRowView)(dgvPatient.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[2] != System.DBNull.Value)
                OPatient.DoctorID = (Int16)((System.Data.DataRowView)(dgvPatient.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[2];

            OPatient.PatientID = (int)((System.Data.DataRowView)(dgvPatient.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[1];
            OPatient.FileNumber = (int)((System.Data.DataRowView)(dgvPatient.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3];
            OPatient.FirstName = ((System.Data.DataRowView)(dgvPatient.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            OPatient.LastName = ((System.Data.DataRowView)(dgvPatient.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[5].ToString();
            OPatient.RowEffected = true;

            OnPatientSelected(OPatient);
            this.Close();
        }

        private void SearchPatientForm_Load(object sender, EventArgs e)
        {
            FillGrid();
            txtLastName.Focus();
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].Culture.EnglishName == "Persian")
                {
                    //CultureInfo cLanguage = new CultureInfo("fa-IR");
                    //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(cLanguage);
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }
            txtLastName.Focus();
        }

        private void OnPatientSelected(Patient selPatient)
        {
            if (PatientSelected != null)
                PatientSelected(this, selPatient);
        }
    }
}
