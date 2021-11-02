namespace DentiNovin
{
    partial class PrescriptionListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrescriptionListForm));
            this.cboAssurance = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvPrescriptionList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCDCreator = new System.Windows.Forms.Button();
            this.btnReportCreator = new System.Windows.Forms.Button();
            this.btnAddPrescrpition = new System.Windows.Forms.Button();
            this.btnDisketteCreator = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAssurance
            // 
            this.cboAssurance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssurance.FormattingEnabled = true;
            this.cboAssurance.Location = new System.Drawing.Point(8, 14);
            this.cboAssurance.Name = "cboAssurance";
            this.cboAssurance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboAssurance.Size = new System.Drawing.Size(105, 21);
            this.cboAssurance.TabIndex = 4;
            this.cboAssurance.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "ماه :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 17);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "سال :";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(112, 17);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "نوع بیمه : ";
            // 
            // dgvPrescriptionList
            // 
            this.dgvPrescriptionList.AllowUserToAddRows = false;
            this.dgvPrescriptionList.AllowUserToDeleteRows = false;
            this.dgvPrescriptionList.AllowUserToOrderColumns = true;
            this.dgvPrescriptionList.AllowUserToResizeColumns = false;
            this.dgvPrescriptionList.AllowUserToResizeRows = false;
            this.dgvPrescriptionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrescriptionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrescriptionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7});
            this.dgvPrescriptionList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPrescriptionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrescriptionList.Location = new System.Drawing.Point(0, 0);
            this.dgvPrescriptionList.MultiSelect = false;
            this.dgvPrescriptionList.Name = "dgvPrescriptionList";
            this.dgvPrescriptionList.ReadOnly = true;
            this.dgvPrescriptionList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrescriptionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrescriptionList.RowHeadersVisible = false;
            this.dgvPrescriptionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptionList.Size = new System.Drawing.Size(960, 582);
            this.dgvPrescriptionList.TabIndex = 9;
            this.dgvPrescriptionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrescriptionList_CellDoubleClick);
            this.dgvPrescriptionList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrescriptionList_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowNumber";
            this.Column1.FillWeight = 25F;
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "AssuranceCode";
            this.Column3.FillWeight = 70F;
            this.Column3.HeaderText = "کد بیمه";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PatientFullName";
            this.Column2.FillWeight = 150F;
            this.Column2.HeaderText = "نام و نام خانوادگی بیمار";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "AssuranceName";
            this.Column4.FillWeight = 67.30414F;
            this.Column4.HeaderText = "نوع بیمه";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ActionDate";
            this.Column6.FillWeight = 67.30414F;
            this.Column6.HeaderText = "تاریخ نسخه";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DoctorFullName";
            this.Column5.HeaderText = "پزشک معالج";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "PageNumber";
            this.Column7.FillWeight = 67.30414F;
            this.Column7.HeaderText = "شماره صفحه";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.toolStripSeparator1,
            this.tsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(83, 54);
            this.contextMenuStrip1.Text = "لبالبالبالبا";
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(82, 22);
            this.tsmiEdit.Text = "ویرایش";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(79, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(82, 22);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvPrescriptionList);
            this.splitContainer4.Size = new System.Drawing.Size(960, 634);
            this.splitContainer4.SplitterDistance = 51;
            this.splitContainer4.SplitterWidth = 1;
            this.splitContainer4.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCDCreator);
            this.groupBox4.Controls.Add(this.btnReportCreator);
            this.groupBox4.Controls.Add(this.btnAddPrescrpition);
            this.groupBox4.Controls.Add(this.btnDisketteCreator);
            this.groupBox4.Location = new System.Drawing.Point(12, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 61);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            // 
            // btnCDCreator
            // 
            this.btnCDCreator.BackgroundImage = global::DentiNovin.Properties.Resources.cd_icon;
            this.btnCDCreator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCDCreator.Enabled = false;
            this.btnCDCreator.Location = new System.Drawing.Point(46, 11);
            this.btnCDCreator.Name = "btnCDCreator";
            this.btnCDCreator.Size = new System.Drawing.Size(38, 32);
            this.btnCDCreator.TabIndex = 7;
            this.btnCDCreator.UseVisualStyleBackColor = true;
            // 
            // btnReportCreator
            // 
            this.btnReportCreator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReportCreator.BackgroundImage")));
            this.btnReportCreator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReportCreator.Enabled = false;
            this.btnReportCreator.Location = new System.Drawing.Point(86, 11);
            this.btnReportCreator.Name = "btnReportCreator";
            this.btnReportCreator.Size = new System.Drawing.Size(38, 32);
            this.btnReportCreator.TabIndex = 6;
            this.btnReportCreator.UseVisualStyleBackColor = true;
            this.btnReportCreator.Click += new System.EventHandler(this.btnReportCreator_Click);
            // 
            // btnAddPrescrpition
            // 
            this.btnAddPrescrpition.Location = new System.Drawing.Point(137, 17);
            this.btnAddPrescrpition.Name = "btnAddPrescrpition";
            this.btnAddPrescrpition.Size = new System.Drawing.Size(75, 23);
            this.btnAddPrescrpition.TabIndex = 5;
            this.btnAddPrescrpition.Text = "نسخه جدید";
            this.btnAddPrescrpition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddPrescrpition.UseVisualStyleBackColor = true;
            this.btnAddPrescrpition.Click += new System.EventHandler(this.btnAddPrescrpition_Click);
            // 
            // btnDisketteCreator
            // 
            this.btnDisketteCreator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDisketteCreator.Enabled = false;
            this.btnDisketteCreator.Image = global::DentiNovin.Properties.Resources.disk_icon;
            this.btnDisketteCreator.Location = new System.Drawing.Point(6, 11);
            this.btnDisketteCreator.Name = "btnDisketteCreator";
            this.btnDisketteCreator.Size = new System.Drawing.Size(38, 32);
            this.btnDisketteCreator.TabIndex = 8;
            this.btnDisketteCreator.UseVisualStyleBackColor = true;
            this.btnDisketteCreator.Click += new System.EventHandler(this.btnDisketteCreator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboDoctor);
            this.groupBox1.Controls.Add(this.cboAssurance);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(426, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 57);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // cboDoctor
            // 
            this.cboDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(374, 13);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboDoctor.Size = new System.Drawing.Size(106, 21);
            this.cboDoctor.TabIndex = 1;
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"});
            this.cboMonth.Location = new System.Drawing.Point(173, 13);
            this.cboMonth.MaxDropDownItems = 12;
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboMonth.Size = new System.Drawing.Size(76, 21);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(283, 14);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(49, 21);
            this.txtYear.TabIndex = 2;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 17);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "پزشک :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PrescriptionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 634);
            this.Controls.Add(this.splitContainer4);
            this.Name = "PrescriptionListForm";
            this.Text = "لیست نسخ ثبت شده";
            this.Load += new System.EventHandler(this.PrescriptionListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrescriptionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboAssurance;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReportCreator;
        private System.Windows.Forms.Button btnAddPrescrpition;
        private System.Windows.Forms.Button btnDisketteCreator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCDCreator;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}