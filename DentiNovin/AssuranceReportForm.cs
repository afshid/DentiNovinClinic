using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using DentiNovin.Common;

namespace DentiNovin
{

    public partial class AssuranceReportForm : Form
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


        private List<AssuranceReportHeader> _reportHeader;
        public List<AssuranceReportHeader> ReportHeader
        {
            get
            {
                if (_reportHeader == null)
                    _reportHeader = new List<AssuranceReportHeader>();
                return _reportHeader;
            }
            set
            {
                _reportHeader = value;
            }
        }

        public AssuranceType AssuranceType { get; set; }

        public AssuranceReportForm()
        {
            InitializeComponent();
        }

        private void AssuranceReportForm_Load(object sender, EventArgs e)
        {
            switch (AssuranceType)
            {
                case AssuranceType.None:
                    break;
                case AssuranceType.Taamin:
                    break;
                case AssuranceType.Mosallah:
                    stiMoAssuranceMainReport.Render();
                    CreateMoAssuranceVisitReport(ReportDataSet[0]);
                    CreateMoAssuranceServiceReport(ReportDataSet[1]);
                    this.stiViewerControl1.Report = this.stiMoAssuranceMainReport;
                    break;
                case AssuranceType.Khadamat:
                    stiKhAssuranceMainReport.Render();
                    CreateKhAssuranceVisitReport(ReportDataSet[0]);
                    CreateKhAssuranceServiceReport(ReportDataSet[1]);
                    this.stiViewerControl1.Report = this.stiKhAssuranceMainReport;
                    break;
                case AssuranceType.Emdad:
                    break;
                default:
                    break;
            }

        }

        private void CreateKhAssuranceVisitReport(DataSet dsReport)
        {
            for (int i = 0; i < dsReport.Tables.Count; i++)
            {
                if (dsReport.Tables[i].Rows.Count == 0)
                    continue;
                stiKhAssuranceVisitReport.RegData("AssurancePrescription", dsReport.Tables[i]);
                stiKhAssuranceVisitReport.Dictionary.Variables["rpHandBookType"].Value = ReportHeader[i].HandBookType;
                stiKhAssuranceVisitReport.Dictionary.Variables["rpMonth"].Value = ReportHeader[i].MonthName;
                stiKhAssuranceVisitReport.Dictionary.Variables["rpDoctorName"].Value = ReportHeader[i].DoctorFullName;
                stiKhAssuranceVisitReport.Dictionary.Variables["rpYear"].Value = ReportHeader[i].Year;
                stiKhAssuranceVisitReport.Render();
                foreach (StiPage page in this.stiKhAssuranceVisitReport.RenderedPages)
                {
                    this.stiKhAssuranceMainReport.RenderedPages.Add(page);

                    foreach (StiComponent comp in page.Components)
                    {
                        if (comp.Name == "Text19")
                        {
                            (comp as StiText).Text = ReportHeader[i].HandBookType;
                        }
                    }
                }
                this.stiKhAssuranceVisitReport.Reset();
            }
        }

        private void CreateKhAssuranceServiceReport(DataSet dsReport)
        {
            for (int i = 0; i < dsReport.Tables.Count; i++)
            {
                if (dsReport.Tables[i].Rows.Count == 0)
                    continue;
                stiKhAssuranceServiceReport.RegData("AssurancePrescription", dsReport.Tables[i]);
                stiKhAssuranceServiceReport.Dictionary.Variables["rpHandBookType"].Value = ReportHeader[i].HandBookType;
                stiKhAssuranceServiceReport.Dictionary.Variables["rpMonth"].Value = ReportHeader[i].MonthName;
                stiKhAssuranceServiceReport.Dictionary.Variables["rpDoctorName"].Value = ReportHeader[i].DoctorFullName;
                stiKhAssuranceServiceReport.Dictionary.Variables["rpYear"].Value = ReportHeader[i].Year;
                stiKhAssuranceServiceReport.Render();
                foreach (StiPage page in this.stiKhAssuranceServiceReport.RenderedPages)
                {
                    this.stiKhAssuranceMainReport.RenderedPages.Add(page);

                    foreach (StiComponent comp in page.Components)
                    {
                        if (comp.Name == "Text19")
                        {
                            (comp as StiText).Text = ReportHeader[i].HandBookType;
                        }
                    }
                }
                this.stiKhAssuranceServiceReport.Reset();
            }
        }

        private void CreateMoAssuranceVisitReport(DataSet dsReport)
        {
            for (int i = 0; i < dsReport.Tables.Count; i++)
            {
                if (dsReport.Tables[i].Rows.Count == 0)
                    continue;
                stiMoAssuranceVisitReprot.RegData("AssurancePrescription", dsReport.Tables[i]);
                stiMoAssuranceVisitReprot.Dictionary.Variables["rpMonth"].Value = ReportHeader[i].MonthName;
                stiMoAssuranceVisitReprot.Dictionary.Variables["rpYear"].Value = ReportHeader[i].Year;
                stiMoAssuranceVisitReprot.Render();
                foreach (StiPage page in this.stiMoAssuranceVisitReprot.RenderedPages)
                {
                    this.stiMoAssuranceMainReport.RenderedPages.Add(page);
                }
                this.stiMoAssuranceVisitReprot.Reset();
            }
        }

        private void CreateMoAssuranceServiceReport(DataSet dsReport)
        {
            for (int i = 0; i < dsReport.Tables.Count; i++)
            {
                if (dsReport.Tables[i].Rows.Count == 0)
                    continue;
                stiMoAssuranceServiceReport.RegData("AssurancePrescription", dsReport.Tables[i]);
                stiMoAssuranceServiceReport.Dictionary.Variables["rpMonth"].Value = ReportHeader[i].MonthName;
                stiMoAssuranceServiceReport.Dictionary.Variables["rpYear"].Value = ReportHeader[i].Year;
                stiMoAssuranceServiceReport.Render();
                foreach (StiPage page in this.stiMoAssuranceServiceReport.RenderedPages)
                {
                    this.stiMoAssuranceMainReport.RenderedPages.Add(page);
                }
                this.stiMoAssuranceServiceReport.Reset();
            }
        }

    }
}

