namespace DentiNovin
{
    partial class BillReportForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("لیست صورتحساب ها");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trvBillList = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reportViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1013, 614);
            this.splitContainer1.SplitterDistance = 750;
            this.splitContainer1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(750, 614);
            this.reportViewer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.trvBillList);
            this.splitContainer2.Size = new System.Drawing.Size(259, 614);
            this.splitContainer2.SplitterDistance = 54;
            this.splitContainer2.TabIndex = 1;
            // 
            // trvBillList
            // 
            this.trvBillList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvBillList.HideSelection = false;
            this.trvBillList.HotTracking = true;
            this.trvBillList.Location = new System.Drawing.Point(0, 0);
            this.trvBillList.Name = "trvBillList";
            treeNode1.Name = "HeadNode";
            treeNode1.Text = "لیست صورتحساب ها";
            this.trvBillList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvBillList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trvBillList.RightToLeftLayout = true;
            this.trvBillList.Size = new System.Drawing.Size(259, 556);
            this.trvBillList.TabIndex = 0;
            this.trvBillList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvBillList_NodeMouseDoubleClick);
            // 
            // BillReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 614);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BillReportForm";
            this.Load += new System.EventHandler(this.BillReportForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvBillList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}