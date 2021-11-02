using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stimulsoft.Report.Components;
using Stimulsoft.Report;
using DentiNovin.Common;

namespace DentiNovin
{
    public partial class ReportsForm : Form
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

        private List<DataTable> _reportDataTable;
        public List<DataTable> ReportDataTable
        {
            get
            {
                if (_reportDataTable == null)
                    _reportDataTable = new List<DataTable>();
                return _reportDataTable;
            }
            set
            {
                _reportDataTable = value;
            }
        }

        private Patient _oPatient;
        public Patient oPatient
        {
            get { return _oPatient; }
            set { _oPatient = value; }
        }


        private DentiReport ReportKind;

        public ReportsForm(DentiReport reportKind)
        {
            this.ReportKind = reportKind;
            InitializeComponent();
        }


        private void ReportsForm_Load(object sender, EventArgs e)
        {
            switch ((int)ReportKind)
            {
                case 0:
                    BuildPatientTreatmentReport();
                    break;
                default:
                    break;
            }
        }

        private void BuildPatientTreatmentReport()
        {
            CreateTreatmentChartReport(ReportDataTable[0]);
            CreateTreatmentDetailsReport(ReportDataTable[1]);
            MergePeports(stiPatientTreatmentMainReport, stiPatientTreatmentDetailsReport);
        }

        private void CreateTreatmentChartReport(DataTable dtReport)
        {
            if (dtReport.Rows.Count == 0)
                return;
            stiPatientTreatmentMainReport.RegData("PatientTreatmentChart", dtReport);
            stiPatientTreatmentMainReport.Render();
        }

        private void CreateTreatmentDetailsReport(DataTable dtReport)
        {
            if (dtReport.Rows.Count == 0)
                return;
            stiPatientTreatmentDetailsReport.RegData("PatientTreatment", dtReport);
            stiPatientTreatmentDetailsReport.Dictionary.Variables["prPatientLastName"].Value = oPatient.LastName;
            stiPatientTreatmentDetailsReport.Dictionary.Variables["prPatientName"].Value = oPatient.FirstName;
            stiPatientTreatmentDetailsReport.Dictionary.Variables["prPatientFileNumber"].Value = oPatient.FileNumber.ToString();
            stiPatientTreatmentDetailsReport.Render();
        }

        private void MergePeports(StiReport mainReport, StiReport addedReport)
        {
            foreach (StiPage page in addedReport.RenderedPages)
            {
                mainReport.RenderedPages.Add(page);
            }
        }

    }
}
