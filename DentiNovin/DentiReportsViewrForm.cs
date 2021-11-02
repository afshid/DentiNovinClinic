using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DentiNovin.Common;
using Stimulsoft.Report;

namespace DentiNovin
{
    public partial class DentiReportsViewerForm : Form
    {
        private List<DataSet> _reportDataSet;
        public List<DataSet> ReportDataSet
        {
            get
            {
                if (_reportDataSet == null)
                    _reportDataSet = new List<DataSet>();
                return _reportDataSet;
            }
            set
            {
                _reportDataSet = value;
            }
        }

        private List<ReportHeader> _reportHeader;
        public List<ReportHeader> ReportHeader
        {
            get
            {
                if (_reportHeader == null)
                    _reportHeader = new List<ReportHeader>();
                return _reportHeader;
            }
            set
            {
                _reportHeader = value;
            }
        }

        public DentiReport ReportType { get; set; }

        public bool ShowBillID { get; set; }
        
        public DentiReportsViewerForm()
        {
            InitializeComponent();
        }


        private void DentiReportsViewerForm_Load(object sender, EventArgs e)
        {
            switch (ReportType)
            {
                case DentiReport.PatientTreatmentReport:
                    break;
                case DentiReport.PatientsVisitsReport:
                    CreateReports(stiVisitsReport, ReportDataSet[0]);
                    break;
                case DentiReport.PatientsBillReport:
                    if(ShowBillID)
                        CreateReports(stiPatientBillsWithIDReport, ReportDataSet[0]);
                    else
                        CreateReports(stiPatientBillsReport, ReportDataSet[0]);
                    break;
                case DentiReport.DoctorsBillReport:
                    if(ShowBillID)
                        CreateReports(stiDoctorBillsWithIDReport, ReportDataSet[0]);
                    else
                        CreateReports(stiDoctorBillsReport, ReportDataSet[0]);
                    break;
                case DentiReport.PatientTreatmentListReport:
                    CreateReports(stiTreatmentsReport,ReportDataSet[0]);
                    break;
                default:
                    break;
            }

        }

        private void CreateReports(StiReport selectedSti, DataSet dsReport)
        {
            selectedSti.RegData("ReportsDataSet", dsReport.Tables[0]);
            selectedSti.Dictionary.Variables["rpStartDate"].Value = ReportHeader[0].StartDate;
            selectedSti.Dictionary.Variables["rpEndDate"].Value = ReportHeader[0].EndDate;

            selectedSti.Render();
            this.stiViewerControl1.Report = selectedSti;
        }
    }

    public class ReportHeader : BaseClass
    {
        public ReportHeader()
        {
        }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientFileNumber { get; set; }
        public string DoctorCode { get; set; }
    }
}
