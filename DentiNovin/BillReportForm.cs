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
using Microsoft.Reporting.WinForms;
using DentiNovin.BaseClasses;
using DentiNovin.Properties;

namespace DentiNovin
{
    public partial class BillReportForm : Form
    {
        private BillBLL _fBillBLL;
        public BillBLL FBillBLL
        {
            get
            {
                if (_fBillBLL == null)
                    _fBillBLL = new BillBLL();
                return _fBillBLL;
            }
            set
            {
                _fBillBLL = value;
            }
        }

        private Bill _oBill;
        public Bill oBill
        {
            get
            {
                if (_oBill == null)
                    _oBill = new Bill();
                return _oBill;
            }
            set { _oBill = value; }
        }

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

        private DataSet _billDataSet;
        public DataSet BillDataSet
        {
            get
            {
                return _billDataSet;
            }
            set
            {
                _billDataSet = value;
            }
        }

        DataTable aDataTable;
        DataSet aDataset;
        ReportParameter[] _parameters = new ReportParameter[6];

        public Decimal TotalFees { get; set; }

        public Decimal TolatFeesPayable { get; set; }

        public Decimal TotalFeesReceived { get; set; }

        private bool _showPersianName = true;
        private int[] SelectedPETNSList;
        private string[] SelectedPRTNSList;
        private NumberingSystem SelectedNumberingSystem;

        public BillReportForm()
        {
            InitializeComponent();
            _showPersianName = (bool)Settings.Default["ShowPersianName"];
        }

        private void BillReportForm_Load(object sender, EventArgs e)
        {
            if (BillDataSet == null || BillDataSet.Tables[0].Rows.Count == 0)
                return;
            TreeNode aTreeNode;
            aTreeNode = new TreeNode("صورتحساب کل");
            aTreeNode.Nodes.Add(new TreeNode("ریز کل درمان"));
            //aTreeNode.Nodes.Add(new TreeNode("ریز حساب"));
            trvBillList.Nodes[0].Nodes.Add(aTreeNode);
            foreach (DataRow dr in BillDataSet.Tables[0].Rows)
            {
                aTreeNode = new TreeNode(dr["DateOfRegister"].ToString());
                aTreeNode.Tag = dr;
                aTreeNode.Nodes.Add(new TreeNode("ریز درمان"));
                //aTreeNode.Nodes.Add(new TreeNode("ریز حساب"));
                trvBillList.Nodes[0].Nodes.Add(aTreeNode);
            }
            trvBillList.Nodes[0].ExpandAll();
            _parameters[0] = new ReportParameter("rpLastName", OPatient.LastName);
            _parameters[1] = new ReportParameter("rpName", OPatient.FirstName);
            _parameters[2] = new ReportParameter("rpFileNumber", OPatient.FileNumber.ToString());
            _parameters[3] = new ReportParameter("rpTotalFees", "");
            _parameters[4] = new ReportParameter("rpTolatFeesPayable", "");
            _parameters[5] = new ReportParameter("rpTotalFeesReceived", "");

            int rowcount = BillDataSet.Tables[0].Rows.Count % 5;
            for (int i = 0; i < 5 - rowcount; i++)
            {
                BillDataSet.Tables[0].Rows.Add(BillDataSet.Tables[0].NewRow());
            }
            aDataTable = BillDataSet.Tables[0].Clone();
            reportViewer1.LocalReport.ReportEmbeddedResource = @"DentiNovin.Reports.PatientBillReport.rdlc";
            //reportViewer1.LocalReport.ReportEmbeddedResource = @"DentiNovin.Reports.AssuranceVisitReport.rdlc";
            reportViewer1.LocalReport.SetParameters(_parameters);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ds1", BillDataSet.Tables[0]));
            this.reportViewer1.RefreshReport();

            SelectedNumberingSystem = (NumberingSystem)Settings.Default["NumberingSystem"];
            switch (SelectedNumberingSystem)
            {
                case NumberingSystem.UniversalSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).PermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).PrimaryToothNumberList;
                    break;
                case NumberingSystem.FdiSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).FdiPermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).FdiPrimaryToothNumberList;
                    break;
                case NumberingSystem.PalmerSystem:
                    this.SelectedPETNSList = ((MainForm)this.MdiParent).PlrPermanetToothNumberList;
                    this.SelectedPRTNSList = ((MainForm)this.MdiParent).PlrPrimaryToothNumberList;
                    break;
                default:
                    break;
            }

        }
        Int64 _billID = 0;
        Decimal _sTotalFees = 0;
        Decimal _sTolatFeesPayable = 0;
        Decimal _sTotalFeesReceived = 0;
        private void trvBillList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            if (e.Node.Parent != null && e.Node.Parent.Name != "HeadNode")
            {
                _billID = 0;
                _sTotalFees = 0;
                _sTolatFeesPayable = 0;
                _sTotalFeesReceived = 0;

                try
                {
                    if ((DataRow)e.Node.Parent.Tag != null)
                    {
                        _billID = (Int64)((DataRow)e.Node.Parent.Tag)[1];
                        _sTotalFees = (Decimal)((DataRow)e.Node.Parent.Tag)[5];
                        _sTolatFeesPayable = (Decimal)((DataRow)e.Node.Parent.Tag)[6];
                        _sTotalFeesReceived = (Decimal)((DataRow)e.Node.Parent.Tag)[8];
                    }
                    else
                    {
                        _sTotalFees = TotalFees;
                        _sTolatFeesPayable = TolatFeesPayable;
                        _sTotalFeesReceived = TotalFeesReceived;
                    }
                    aDataset = GetBillTreatmentList(OPatient.PatientID, _billID, _showPersianName);
                    DataColumn aDataColumn = new DataColumn("ToothNumberConverted");
                    aDataset.Tables[0].Columns.Add(aDataColumn);
                    DataColumn bDataColumn = new DataColumn("FaToothDirection");
                    aDataset.Tables[0].Columns.Add(bDataColumn);
                    for (int i = 0; i < aDataset.Tables[0].Rows.Count; i++)
                    {
                        string normalNumberString = string.Empty;
                        if (aDataset.Tables[0].Rows[i]["ToothCode"] == System.DBNull.Value)
                            aDataset.Tables[0].Rows[i]["ToothCode"] = 0;
                        if ((byte)aDataset.Tables[0].Rows[i]["ToothType"] == (int)ToothType.Primary)
                            normalNumberString = this.SelectedPRTNSList[(byte)aDataset.Tables[0].Rows[i]["ToothCode"] - 1];
                        else
                            normalNumberString = this.SelectedPETNSList[(byte)aDataset.Tables[0].Rows[i]["ToothCode"] - 1].ToString();

                        aDataset.Tables[0].Rows[i]["ToothNumberConverted"] = UtilMethods.GetToothNumberString((byte)aDataset.Tables[0].Rows[i]["ToothCode"], (Int16)aDataset.Tables[0].Rows[i]["TreatmentArea"], normalNumberString);
                        aDataset.Tables[0].Rows[i]["FaToothDirection"] = UtilMethods.GetToothDirectionString((Byte)aDataset.Tables[0].Rows[i]["ToothCode"], (Int16)aDataset.Tables[0].Rows[i]["TreatmentArea"]);
                    }

                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1025");
                    MessageBox.Show("بروز خطا در بارگزاری اطلاعات ریز درمان صورتحساب", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (aDataset.Tables[0] == null)
                    return;
                int rowcount = aDataset.Tables[0].Rows.Count % 5;
                for (int i = 0; i < 5 - rowcount; i++)
                {
                    aDataset.Tables[0].Rows.Add(aDataset.Tables[0].NewRow());
                }
                reportViewer1.LocalReport.ReportEmbeddedResource = @"DentiNovin.Reports.BillTreatmentDetailsReport.rdlc";
                _parameters[3] = new ReportParameter("rpTotalFees", _sTotalFees.ToString("#,0;(#,0)"));
                _parameters[4] = new ReportParameter("rpTolatFeesPayable", _sTolatFeesPayable.ToString("#,0;(#,0)"));
                _parameters[5] = new ReportParameter("rpTotalFeesReceived", _sTotalFeesReceived.ToString("#,0;(#,0)"));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", aDataset.Tables[0]));
                reportViewer1.LocalReport.SetParameters(_parameters);
                this.reportViewer1.RefreshReport();
                return;
            }
            reportViewer1.LocalReport.ReportEmbeddedResource = @"DentiNovin.Reports.PatientBillReport.rdlc";
            if (e.Node.Index == 0)
            {
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ds1", BillDataSet.Tables[0]));
                this.reportViewer1.RefreshReport();
                return;
            }
            DataRow aBill = (DataRow)e.Node.Tag;
            if (aBill == null)
                return;
            aDataTable.Rows.Clear();
            aDataTable.ImportRow(aBill);
            aDataTable.Rows[0]["RowNumber"] = 1;
            for (int i = 0; i < 4; i++)
            {
                aDataTable.Rows.Add(aDataTable.NewRow());
            }
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ds1", aDataTable));
            this.reportViewer1.RefreshReport();
        }

        private DataSet GetBillTreatmentList(int patientID, Int64 billID, bool showPersian)
        {
            return FBillBLL.GetBillTreatmentList(patientID, billID, showPersian);
        }


    }


}
