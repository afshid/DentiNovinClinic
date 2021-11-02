using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using DentiNovin.BusinessLogic;
using DentiNovin.Common;

namespace DentiNovin
{
    public partial class PatientListDock : DockContent
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

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }

        public event EventHandler PatientSelected;

        private void OnPatientSelected()
        {
            if (PatientSelected != null)
                PatientSelected(this, null);
        }

        public PatientListDock()
        {
            InitializeComponent();
        }

        private void PatientListDock_Load(object sender, EventArgs e)
        {
            dgvPatientList.AutoGenerateColumns = false;
            cboSearch.SelectedIndex = 0;
        }

        private void FillGrid()
        {
            FillGrid(0, "",false);
        }

        private void FillGrid(int fileNumber, string patientLastname, bool showAllField)
        {
            DataSet aDataSet = FPatientBLL.SelectPatientListByField(fileNumber, patientLastname,showAllField);
            dgvPatientList.DataSource = aDataSet.Tables[0]; ;
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _fileNumber = 0;
            string _patientLastname = string.Empty;

            switch (cboSearch.SelectedIndex)
            {
                case 0:
                    _patientLastname = txtSearch.Text.Trim();
                    break;
                case 1:
                    bool parsed = int.TryParse(txtSearch.Text.Trim(), out _fileNumber);
                    break;
            }

            FillGrid(_fileNumber, _patientLastname,false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cboSearch_SelectedIndexChanged(null, null);
        }

        private void dgvPatientList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SetSelectedObject((int)((DataRowView)dgvPatientList.SelectedRows[0].DataBoundItem).Row.ItemArray[0]);
        }

        private void SetSelectedObject(int patientID)
        {
            oPatient.PatientID = patientID;
            FPatientBLL.oPatient=this.oPatient;
            FPatientBLL.GetPatientByID();
            OnPatientSelected();

        }

    }
}
