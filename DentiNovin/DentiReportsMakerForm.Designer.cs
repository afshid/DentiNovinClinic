namespace DentiNovin
{
    partial class DentiReportsMakerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("گزارشات");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkWithBillID = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.fdpEndRangeDate = new FADatePicker.FADatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.fdpStartRangeDate = new FADatePicker.FADatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvDentiReport = new System.Windows.Forms.DataGridView();
            this.trwReportsList = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDentiReport)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trwReportsList);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 690);
            this.splitContainer1.SplitterDistance = 824;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDentiReport);
            this.splitContainer2.Size = new System.Drawing.Size(824, 690);
            this.splitContainer2.SplitterDistance = 106;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkWithBillID);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.fdpEndRangeDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.fdpStartRangeDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(324, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkWithBillID
            // 
            this.chkWithBillID.AutoSize = true;
            this.chkWithBillID.Location = new System.Drawing.Point(358, 86);
            this.chkWithBillID.Name = "chkWithBillID";
            this.chkWithBillID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkWithBillID.Size = new System.Drawing.Size(120, 17);
            this.chkWithBillID.TabIndex = 23;
            this.chkWithBillID.Text = "به تفکیک صورتحساب";
            this.chkWithBillID.UseVisualStyleBackColor = true;
            this.chkWithBillID.Visible = false;
            this.chkWithBillID.CheckedChanged += new System.EventHandler(this.chkWithBillID_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnSearchPatient);
            this.groupBox4.Controls.Add(this.lblFileNumber);
            this.groupBox4.Controls.Add(this.txtFileNumber);
            this.groupBox4.Controls.Add(this.lblLastName);
            this.groupBox4.Controls.Add(this.txtPatientLastName);
            this.groupBox4.Location = new System.Drawing.Point(240, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(240, 62);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPatient.Location = new System.Drawing.Point(9, 10);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(65, 23);
            this.btnSearchPatient.TabIndex = 16;
            this.btnSearchPatient.Text = "...";
            this.btnSearchPatient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnSearchPatient, "جستجوی بیمار");
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // lblFileNumber
            // 
            this.lblFileNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileNumber.AutoSize = true;
            this.lblFileNumber.Location = new System.Drawing.Point(158, 14);
            this.lblFileNumber.Name = "lblFileNumber";
            this.lblFileNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFileNumber.Size = new System.Drawing.Size(74, 13);
            this.lblFileNumber.TabIndex = 12;
            this.lblFileNumber.Text = "شماره پرونده :";
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNumber.Location = new System.Drawing.Point(80, 11);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFileNumber.Size = new System.Drawing.Size(77, 21);
            this.txtFileNumber.TabIndex = 13;
            this.txtFileNumber.TextChanged += new System.EventHandler(this.txtFileNumber_TextChanged);
            this.txtFileNumber.Leave += new System.EventHandler(this.txtFileNumber_Leave);
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(158, 41);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLastName.Size = new System.Drawing.Size(51, 13);
            this.lblLastName.TabIndex = 14;
            this.lblLastName.Text = "نام بیمار :";
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientLastName.BackColor = System.Drawing.Color.Khaki;
            this.txtPatientLastName.Location = new System.Drawing.Point(9, 38);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.ReadOnly = true;
            this.txtPatientLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPatientLastName.Size = new System.Drawing.Size(148, 21);
            this.txtPatientLastName.TabIndex = 15;
            // 
            // fdpEndRangeDate
            // 
            this.fdpEndRangeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fdpEndRangeDate.Location = new System.Drawing.Point(21, 60);
            this.fdpEndRangeDate.Name = "fdpEndRangeDate";
            this.fdpEndRangeDate.Size = new System.Drawing.Size(120, 20);
            this.fdpEndRangeDate.TabIndex = 22;
            this.fdpEndRangeDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            this.fdpEndRangeDate.ValueChanged += new System.EventHandler(this.fdpEndRangeDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 62);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "تاریخ پایان :";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cbxDoctor);
            this.groupBox5.Controls.Add(this.lblDoctor);
            this.groupBox5.Location = new System.Drawing.Point(240, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(240, 34);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(6, 10);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxDoctor.Size = new System.Drawing.Size(148, 21);
            this.cbxDoctor.TabIndex = 18;
            this.cbxDoctor.SelectedIndexChanged += new System.EventHandler(this.cbxDoctor_SelectedIndexChanged);
            // 
            // lblDoctor
            // 
            this.lblDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(155, 13);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDoctor.Size = new System.Drawing.Size(81, 13);
            this.lblDoctor.TabIndex = 17;
            this.lblDoctor.Text = "نام دندانپزشک :";
            // 
            // fdpStartRangeDate
            // 
            this.fdpStartRangeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fdpStartRangeDate.Location = new System.Drawing.Point(21, 33);
            this.fdpStartRangeDate.Name = "fdpStartRangeDate";
            this.fdpStartRangeDate.Size = new System.Drawing.Size(120, 20);
            this.fdpStartRangeDate.TabIndex = 20;
            this.fdpStartRangeDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            this.fdpStartRangeDate.ValueChanged += new System.EventHandler(this.fdpStartRangeDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 35);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "تاریخ شروع :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Location = new System.Drawing.Point(12, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(67, 60);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackgroundImage = global::DentiNovin.Properties.Resources.print_icon;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(14, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(38, 32);
            this.btnPrint.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnPrint, "نسخه چاپی");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvDentiReport
            // 
            this.dgvDentiReport.AllowUserToAddRows = false;
            this.dgvDentiReport.AllowUserToDeleteRows = false;
            this.dgvDentiReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDentiReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDentiReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDentiReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDentiReport.Location = new System.Drawing.Point(0, 0);
            this.dgvDentiReport.Name = "dgvDentiReport";
            this.dgvDentiReport.ReadOnly = true;
            this.dgvDentiReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvDentiReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDentiReport.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDentiReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDentiReport.Size = new System.Drawing.Size(824, 583);
            this.dgvDentiReport.TabIndex = 0;
            // 
            // trwReportsList
            // 
            this.trwReportsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trwReportsList.HideSelection = false;
            this.trwReportsList.HotTracking = true;
            this.trwReportsList.Location = new System.Drawing.Point(0, 0);
            this.trwReportsList.Name = "trwReportsList";
            treeNode1.Name = "HeadNode";
            treeNode1.Text = "گزارشات";
            this.trwReportsList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trwReportsList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trwReportsList.RightToLeftLayout = true;
            this.trwReportsList.Size = new System.Drawing.Size(181, 690);
            this.trwReportsList.TabIndex = 0;
            this.trwReportsList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trwReportsList_NodeMouseDoubleClick);
            // 
            // DentiReportsMakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 690);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DentiReportsMakerForm";
            this.Text = "گزارشات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DentiReportsMakerForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDentiReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView trwReportsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private FADatePicker.FADatePicker fdpStartRangeDate;
        private System.Windows.Forms.Label label1;
        private FADatePicker.FADatePicker fdpEndRangeDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvDentiReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkWithBillID;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}