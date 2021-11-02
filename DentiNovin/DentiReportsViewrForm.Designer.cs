namespace DentiNovin
{
    partial class DentiReportsViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DentiReportsViewerForm));
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.stiVisitsReport = new Stimulsoft.Report.StiReport();
            this.reportsDataSet1 = new DentiNovin.Data.ReportsDataSet();
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("ReportsDataSet", this.reportsDataSet1);
            this.stiTreatmentsReport = new Stimulsoft.Report.StiReport();
            this.stiReportDataSource2 = new Stimulsoft.Report.Design.StiReportDataSource("ReportsDataSet", this.reportsDataSet1);
            this.stiPatientBillsReport = new Stimulsoft.Report.StiReport();
            this.stiDoctorBillsReport = new Stimulsoft.Report.StiReport();
            this.stiPatientBillsWithIDReport = new Stimulsoft.Report.StiReport();
            this.stiDoctorBillsWithIDReport = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stiViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.Report = null;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(714, 596);
            this.stiViewerControl1.TabIndex = 0;
            // 
            // stiVisitsReport
            // 
            this.stiVisitsReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiVisitsReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiVisitsReport.ReportAlias = "Report";
            this.stiVisitsReport.ReportDataSources.Add(this.stiReportDataSource1);
            this.stiVisitsReport.ReportGuid = "7158983799994da6ab0299da00752518";
            this.stiVisitsReport.ReportName = "Report";
            this.stiVisitsReport.ReportSource = resources.GetString("stiVisitsReport.ReportSource");
            this.stiVisitsReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiVisitsReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // reportsDataSet1
            // 
            this.reportsDataSet1.DataSetName = "ReportsDataSet";
            this.reportsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this.reportsDataSet1;
            this.stiReportDataSource1.Name = "ReportsDataSet";
            // 
            // stiTreatmentsReport
            // 
            this.stiTreatmentsReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiTreatmentsReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiTreatmentsReport.ReportAlias = "Report";
            this.stiTreatmentsReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiTreatmentsReport.ReportGuid = "ad794a72c7334988a1cab373b75c3786";
            this.stiTreatmentsReport.ReportName = "Report";
            this.stiTreatmentsReport.ReportSource = resources.GetString("stiTreatmentsReport.ReportSource");
            this.stiTreatmentsReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiTreatmentsReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiReportDataSource2
            // 
            this.stiReportDataSource2.Item = this.reportsDataSet1;
            this.stiReportDataSource2.Name = "ReportsDataSet";
            // 
            // stiPatientBillsReport
            // 
            this.stiPatientBillsReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiPatientBillsReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiPatientBillsReport.ReportAlias = "Report";
            this.stiPatientBillsReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiPatientBillsReport.ReportGuid = "7ff77ce49f6c4341aeff6a1eb526545b";
            this.stiPatientBillsReport.ReportName = "Report";
            this.stiPatientBillsReport.ReportSource = resources.GetString("stiPatientBillsReport.ReportSource");
            this.stiPatientBillsReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiPatientBillsReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiDoctorBillsReport
            // 
            this.stiDoctorBillsReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiDoctorBillsReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiDoctorBillsReport.ReportAlias = "Report";
            this.stiDoctorBillsReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiDoctorBillsReport.ReportGuid = "3fad5b57dfc84187b6cb792855c53217";
            this.stiDoctorBillsReport.ReportName = "Report";
            this.stiDoctorBillsReport.ReportSource = resources.GetString("stiDoctorBillsReport.ReportSource");
            this.stiDoctorBillsReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiDoctorBillsReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiPatientBillsWithIDReport
            // 
            this.stiPatientBillsWithIDReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiPatientBillsWithIDReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiPatientBillsWithIDReport.ReportAlias = "Report";
            this.stiPatientBillsWithIDReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiPatientBillsWithIDReport.ReportGuid = "0dca800c306c4f6c8ff7cf6d16c8ebc6";
            this.stiPatientBillsWithIDReport.ReportName = "Report";
            this.stiPatientBillsWithIDReport.ReportSource = resources.GetString("stiPatientBillsWithIDReport.ReportSource");
            this.stiPatientBillsWithIDReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiPatientBillsWithIDReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiDoctorBillsWithIDReport
            // 
            this.stiDoctorBillsWithIDReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiDoctorBillsWithIDReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiDoctorBillsWithIDReport.ReportAlias = "Report";
            this.stiDoctorBillsWithIDReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiDoctorBillsWithIDReport.ReportGuid = "7c9e20e778d2431bb1f730c268ef9aa7";
            this.stiDoctorBillsWithIDReport.ReportName = "Report";
            this.stiDoctorBillsWithIDReport.ReportSource = resources.GetString("stiDoctorBillsWithIDReport.ReportSource");
            this.stiDoctorBillsWithIDReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiDoctorBillsWithIDReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // DentiReportsViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 596);
            this.Controls.Add(this.stiViewerControl1);
            this.Name = "DentiReportsViewerForm";
            this.Text = "DentiReportsViewerForm";
            this.Load += new System.EventHandler(this.DentiReportsViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private Stimulsoft.Report.StiReport stiVisitsReport;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
        private Data.ReportsDataSet reportsDataSet1;
        private Stimulsoft.Report.StiReport stiTreatmentsReport;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource2;
        private Stimulsoft.Report.StiReport stiPatientBillsReport;
        private Stimulsoft.Report.StiReport stiDoctorBillsReport;
        private Stimulsoft.Report.StiReport stiPatientBillsWithIDReport;
        private Stimulsoft.Report.StiReport stiDoctorBillsWithIDReport;



    }
}