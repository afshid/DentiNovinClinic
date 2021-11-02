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
using DentiNovin.Common.DateConvert;

namespace DentiNovin
{
    public partial class AppointmentListDock : DockContent
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

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set {
                _oPatient = value;
                //FilldgvPatientAppointment(oPatient.PatientID);
            }
        }

        private Appointment _selectedAppointment;
        public Appointment SelectedAppointment
        {
            get {
                if (_selectedAppointment == null)
                    _selectedAppointment = new Appointment();
                return _selectedAppointment; }
            set { _selectedAppointment = value; }
        }

        public event EventHandler AppointmentSelected;

        private void OnAppointmentSelected()
        {
            if (AppointmentSelected != null)
                AppointmentSelected(this, null);
        }
        
        public AppointmentListDock()
        {
            InitializeComponent();
        }
       
        private DataSet GetPatientAppointment(int PatientID)
        {
            return FAppointmentFormBLL.GetPatientAppointment(PatientID);
        }
        
        public void FilldgvPatientAppointment(int PatientID)
        {
            //btnAdd.Enabled = true;
            btnRefresh.Enabled = true;
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
                //aDataSet.Tables[0].Rows[i]["StartShortTime"] = System.Convert.ToDateTime(aDataSet.Tables[0].Rows[i]["StartTime"]).TimeOfDay;
                aDataSet.Tables[0].Rows[i]["StartShortTime"] = new DateTime().Add(TimeSpan.FromTicks((Int64)aDataSet.Tables[0].Rows[i]["StartTime"])).TimeOfDay;
            }

            dgvPatientAppointment.DataSource = aDataSet.Tables[0];

        }

        private void AppointmentListDock_Load(object sender, EventArgs e)
        {
            if (oPatient.PatientID == 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
               // btnAdd.Enabled = true;
                btnRefresh.Enabled = true;
                FilldgvPatientAppointment(oPatient.PatientID);
            }
        }

        private void dgvPatientAppointment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SelectedAppointment.AppointmentID = (Int64)((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[0];
            SelectedAppointment.VisitDate = ((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[4].ToString();
            SelectedAppointment.StartTime =Convert.ToDateTime(((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[14]).TimeOfDay;
            SelectedAppointment.DoctorID = (int)((System.Data.DataRowView)(dgvPatientAppointment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[3];
            OnAppointmentSelected();
        }

        private void dgvPatientAppointment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPatientAppointment.Columns[e.ColumnIndex].Name == "VisitDate")
                if (e.Value != null)
                    try
                    {
                        if (e.Value.ToString() == PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null))
                        {

                            dgvPatientAppointment.ClearSelection();
                            dgvPatientAppointment.FirstDisplayedScrollingRowIndex = e.RowIndex;
                            dgvPatientAppointment.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        e.FormattingApplied = false;

                    }

        }

        private void dgvPatientAppointment_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FilldgvPatientAppointment(oPatient.PatientID);
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control) sender, "بارگزاری مجدد");
        }
    }
}
