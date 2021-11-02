namespace DentiNovin
{
    partial class ReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.stiPatientTreatmentMainReport = new Stimulsoft.Report.StiReport();
            this.stiPatientTreatmentDetailsReport = new Stimulsoft.Report.StiReport();
            this.patientTreatmentDS1 = new DentiNovin.Data.PatientTreatmentDS();
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("PatientTreatmentDS", this.patientTreatmentDS1);
            this.stiReportDataSource2 = new Stimulsoft.Report.Design.StiReportDataSource("PatientTreatmentDS", this.patientTreatmentDS1);
            ((System.ComponentModel.ISupportInitialize)(this.patientTreatmentDS1)).BeginInit();
            this.SuspendLayout();
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stiViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.Report = this.stiPatientTreatmentMainReport;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(761, 661);
            this.stiViewerControl1.TabIndex = 0;
            // 
            // stiPatientTreatmentMainReport
            // 
            this.stiPatientTreatmentMainReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiPatientTreatmentMainReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiPatientTreatmentMainReport.ReportAlias = "Report";
            this.stiPatientTreatmentMainReport.ReportDataSources.Add(this.stiReportDataSource1);
            this.stiPatientTreatmentMainReport.ReportGuid = "43ac465dfcd84ed8bbeef527783756fd";
            this.stiPatientTreatmentMainReport.ReportName = "Report";
            this.stiPatientTreatmentMainReport.ReportSource = resources.GetString("stiPatientTreatmentMainReport.ReportSource");
            this.stiPatientTreatmentMainReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiPatientTreatmentMainReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiPatientTreatmentDetailsReport
            // 
            this.stiPatientTreatmentDetailsReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiPatientTreatmentDetailsReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiPatientTreatmentDetailsReport.ReportAlias = "Report";
            this.stiPatientTreatmentDetailsReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiPatientTreatmentDetailsReport.ReportGuid = "d6e7fb7e1e4a497fba0f265937f983a0";
            this.stiPatientTreatmentDetailsReport.ReportName = "Report";
            this.stiPatientTreatmentDetailsReport.ReportSource = resources.GetString("stiPatientTreatmentDetailsReport.ReportSource");
            this.stiPatientTreatmentDetailsReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiPatientTreatmentDetailsReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // patientTreatmentDS1
            // 
            this.patientTreatmentDS1.DataSetName = "PatientTreatmentDS";
            this.patientTreatmentDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this.patientTreatmentDS1;
            this.stiReportDataSource1.Name = "PatientTreatmentDS";
            // 
            // stiReportDataSource2
            // 
            this.stiReportDataSource2.Item = this.patientTreatmentDS1;
            this.stiReportDataSource2.Name = "PatientTreatmentDS";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 661);
            this.Controls.Add(this.stiViewerControl1);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patientTreatmentDS1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private Stimulsoft.Report.StiReport stiPatientTreatmentMainReport;
        private Data.PatientTreatmentDS patientTreatmentDS1;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
        private Stimulsoft.Report.StiReport stiPatientTreatmentDetailsReport;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource2;
    }
}