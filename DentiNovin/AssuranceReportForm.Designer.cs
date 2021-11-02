namespace DentiNovin
{
    partial class AssuranceReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssuranceReportForm));
            this.stiKhAssuranceVisitReport = new Stimulsoft.Report.StiReport();
            this.assuranceDS = new DentiNovin.Data.AssuranceDS();
            this.stiReportDataSource2 = new Stimulsoft.Report.Design.StiReportDataSource("AssuranceDS", this.assuranceDS);
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.stiKhAssuranceMainReport = new Stimulsoft.Report.StiReport();
            this.stiKhAssuranceServiceReport = new Stimulsoft.Report.StiReport();
            this.stiMoAssuranceVisitReprot = new Stimulsoft.Report.StiReport();
            this.stiReportDataSource4 = new Stimulsoft.Report.Design.StiReportDataSource("AssuranceDS", this.assuranceDS);
            this.stiMoAssuranceMainReport = new Stimulsoft.Report.StiReport();
            this.stiMoAssuranceServiceReport = new Stimulsoft.Report.StiReport();
            this.stiReportDataSource3 = new Stimulsoft.Report.Design.StiReportDataSource("AssuranceDS", this.assuranceDS);
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("AssuranceDS", this.assuranceDS);
            ((System.ComponentModel.ISupportInitialize)(this.assuranceDS)).BeginInit();
            this.SuspendLayout();
            // 
            // stiKhAssuranceVisitReport
            // 
            this.stiKhAssuranceVisitReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiKhAssuranceVisitReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiKhAssuranceVisitReport.ReportAlias = "Report";
            this.stiKhAssuranceVisitReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiKhAssuranceVisitReport.ReportGuid = "6a18413f34e444028ec97ffea7beb4fd";
            this.stiKhAssuranceVisitReport.ReportName = "Report";
            this.stiKhAssuranceVisitReport.ReportSource = resources.GetString("stiKhAssuranceVisitReport.ReportSource");
            this.stiKhAssuranceVisitReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiKhAssuranceVisitReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // assuranceDS
            // 
            this.assuranceDS.DataSetName = "AssuranceDS";
            this.assuranceDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stiReportDataSource2
            // 
            this.stiReportDataSource2.Item = this.assuranceDS;
            this.stiReportDataSource2.Name = "AssuranceDS";
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stiViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.Report = this.stiKhAssuranceMainReport;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowBookmarksPanel = false;
            this.stiViewerControl1.ShowOpen = false;
            this.stiViewerControl1.ShowPageNew = false;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(760, 674);
            this.stiViewerControl1.TabIndex = 0;
            // 
            // stiKhAssuranceMainReport
            // 
            this.stiKhAssuranceMainReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiKhAssuranceMainReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiKhAssuranceMainReport.ReportAlias = "Report";
            this.stiKhAssuranceMainReport.ReportGuid = "f3f466153c484bdcb806c1089feebf47";
            this.stiKhAssuranceMainReport.ReportName = "Report";
            this.stiKhAssuranceMainReport.ReportSource = resources.GetString("stiKhAssuranceMainReport.ReportSource");
            this.stiKhAssuranceMainReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiKhAssuranceMainReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiKhAssuranceServiceReport
            // 
            this.stiKhAssuranceServiceReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiKhAssuranceServiceReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiKhAssuranceServiceReport.ReportAlias = "Report";
            this.stiKhAssuranceServiceReport.ReportDataSources.Add(this.stiReportDataSource2);
            this.stiKhAssuranceServiceReport.ReportGuid = "d75d4f254401464fb0724d5150a12e84";
            this.stiKhAssuranceServiceReport.ReportName = "Report";
            this.stiKhAssuranceServiceReport.ReportSource = resources.GetString("stiKhAssuranceServiceReport.ReportSource");
            this.stiKhAssuranceServiceReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiKhAssuranceServiceReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiMoAssuranceVisitReprot
            // 
            this.stiMoAssuranceVisitReprot.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiMoAssuranceVisitReprot.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiMoAssuranceVisitReprot.ReportAlias = "Report";
            this.stiMoAssuranceVisitReprot.ReportDataSources.Add(this.stiReportDataSource4);
            this.stiMoAssuranceVisitReprot.ReportGuid = "14b882dd9d34464bb99d53e8067fdda9";
            this.stiMoAssuranceVisitReprot.ReportName = "Report";
            this.stiMoAssuranceVisitReprot.ReportSource = resources.GetString("stiMoAssuranceVisitReprot.ReportSource");
            this.stiMoAssuranceVisitReprot.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiMoAssuranceVisitReprot.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiReportDataSource4
            // 
            this.stiReportDataSource4.Item = this.assuranceDS;
            this.stiReportDataSource4.Name = "AssuranceDS";
            // 
            // stiMoAssuranceMainReport
            // 
            this.stiMoAssuranceMainReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiMoAssuranceMainReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiMoAssuranceMainReport.ReportAlias = "Report";
            this.stiMoAssuranceMainReport.ReportGuid = "af57f0bf0e7a4ba8ad4feacace96d0da";
            this.stiMoAssuranceMainReport.ReportName = "Report";
            this.stiMoAssuranceMainReport.ReportSource = resources.GetString("stiMoAssuranceMainReport.ReportSource");
            this.stiMoAssuranceMainReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiMoAssuranceMainReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiMoAssuranceServiceReport
            // 
            this.stiMoAssuranceServiceReport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiMoAssuranceServiceReport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiMoAssuranceServiceReport.ReportAlias = "Report";
            this.stiMoAssuranceServiceReport.ReportDataSources.Add(this.stiReportDataSource3);
            this.stiMoAssuranceServiceReport.ReportGuid = "24b765c324874aeda4eeb9a493022856";
            this.stiMoAssuranceServiceReport.ReportName = "Report";
            this.stiMoAssuranceServiceReport.ReportSource = resources.GetString("stiMoAssuranceServiceReport.ReportSource");
            this.stiMoAssuranceServiceReport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiMoAssuranceServiceReport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            // 
            // stiReportDataSource3
            // 
            this.stiReportDataSource3.Item = this.assuranceDS;
            this.stiReportDataSource3.Name = "AssuranceDS";
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this.assuranceDS;
            this.stiReportDataSource1.Name = "AssuranceDS";
            // 
            // AssuranceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 674);
            this.Controls.Add(this.stiViewerControl1);
            this.MaximizeBox = false;
            this.Name = "AssuranceReportForm";
            this.Text = "گزارش بیمه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AssuranceReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assuranceDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.StiReport stiKhAssuranceVisitReport;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
        private Data.AssuranceDS assuranceDS;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource2;
        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private Stimulsoft.Report.StiReport stiKhAssuranceMainReport;
        private Stimulsoft.Report.StiReport stiKhAssuranceServiceReport;
        private Stimulsoft.Report.StiReport stiMoAssuranceVisitReprot;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource3;
        private Stimulsoft.Report.StiReport stiMoAssuranceMainReport;
        private Stimulsoft.Report.StiReport stiMoAssuranceServiceReport;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource4;




    }
}