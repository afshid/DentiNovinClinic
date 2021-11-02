namespace DentiNovin
{
    partial class PrescriptionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvServiceList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKCoeff = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPatientPayment = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.txtServicePrice = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPatientShare = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.fdpActiondate = new FADatePicker.FADatePicker();
            this.fdpReferenceDate = new FADatePicker.FADatePicker();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.txtAssuranceType = new System.Windows.Forms.TextBox();
            this.txtValidityDate = new System.Windows.Forms.TextBox();
            this.txtAssuranceCode = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.chkIsReferenced = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddVisit = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(73, 26);
            this.contextMenuStrip1.Text = "لبالبالبالبا";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(72, 22);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvServiceList);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(5, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 458);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvServiceList
            // 
            this.dgvServiceList.AllowUserToAddRows = false;
            this.dgvServiceList.AllowUserToDeleteRows = false;
            this.dgvServiceList.AllowUserToResizeColumns = false;
            this.dgvServiceList.AllowUserToResizeRows = false;
            this.dgvServiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiceList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvServiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column4});
            this.dgvServiceList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvServiceList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvServiceList.Location = new System.Drawing.Point(3, 243);
            this.dgvServiceList.MultiSelect = false;
            this.dgvServiceList.Name = "dgvServiceList";
            this.dgvServiceList.ReadOnly = true;
            this.dgvServiceList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServiceList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvServiceList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceList.Size = new System.Drawing.Size(825, 212);
            this.dgvServiceList.TabIndex = 12;
            this.dgvServiceList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvServiceList_CellFormatting);
            this.dgvServiceList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServiceList_CellMouseUp);
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
            // Column2
            // 
            this.Column2.DataPropertyName = "ServiceCode";
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "کد خدمت";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ServiceName";
            this.Column3.FillWeight = 200F;
            this.Column3.HeaderText = "نام خدمت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "KPrice";
            this.Column5.FillWeight = 55F;
            this.Column5.HeaderText = "میزان K";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ServicePrice";
            dataGridViewCellStyle2.Format = "#,0;(#,0)";
            dataGridViewCellStyle2.NullValue = "0";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.FillWeight = 67.30414F;
            this.Column6.HeaderText = "تعرفه بیمه";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "PatientShare";
            dataGridViewCellStyle3.Format = "#,0;(#,0)";
            dataGridViewCellStyle3.NullValue = null;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.FillWeight = 67.30414F;
            this.Column7.HeaderText = "سهم بیمار";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ServiceID";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtKCoeff);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboDoctor);
            this.groupBox2.Controls.Add(this.fdpActiondate);
            this.groupBox2.Controls.Add(this.fdpReferenceDate);
            this.groupBox2.Controls.Add(this.txtPageNumber);
            this.groupBox2.Controls.Add(this.txtAssuranceType);
            this.groupBox2.Controls.Add(this.txtValidityDate);
            this.groupBox2.Controls.Add(this.txtAssuranceCode);
            this.groupBox2.Controls.Add(this.txtSex);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Controls.Add(this.chkIsReferenced);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox2.Size = new System.Drawing.Size(818, 195);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // txtKCoeff
            // 
            this.txtKCoeff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKCoeff.BackColor = System.Drawing.Color.Khaki;
            this.txtKCoeff.Location = new System.Drawing.Point(373, 131);
            this.txtKCoeff.Name = "txtKCoeff";
            this.txtKCoeff.ReadOnly = true;
            this.txtKCoeff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKCoeff.Size = new System.Drawing.Size(67, 21);
            this.txtKCoeff.TabIndex = 35;
            this.txtKCoeff.TabStop = false;
            this.txtKCoeff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(446, 134);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "مقدار ضریب K :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPatientPayment);
            this.groupBox3.Controls.Add(this.txtServicePrice);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtPatientShare);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(6, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 104);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // txtPatientPayment
            // 
            this.errorProvider1.SetIconAlignment(this.txtPatientPayment, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtPatientPayment.Location = new System.Drawing.Point(18, 74);
            this.txtPatientPayment.Name = "txtPatientPayment";

            this.txtPatientPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPatientPayment.Size = new System.Drawing.Size(147, 21);
            this.txtPatientPayment.TabIndex = 33;
            this.txtPatientPayment.Text = "0";
            this.txtPatientPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtServicePrice
            // 
            this.txtServicePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServicePrice.BackColor = System.Drawing.Color.Khaki;
            this.txtServicePrice.Location = new System.Drawing.Point(18, 19);
            this.txtServicePrice.Name = "txtServicePrice";
            this.txtServicePrice.ReadOnly = true;
            this.txtServicePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServicePrice.Size = new System.Drawing.Size(147, 21);
            this.txtServicePrice.TabIndex = 32;
            this.txtServicePrice.TabStop = false;
            this.txtServicePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(167, 22);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "تعرفه بیمه :";
            // 
            // txtPatientShare
            // 
            this.txtPatientShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientShare.BackColor = System.Drawing.Color.Khaki;
            this.txtPatientShare.Location = new System.Drawing.Point(18, 46);
            this.txtPatientShare.Name = "txtPatientShare";
            this.txtPatientShare.ReadOnly = true;
            this.txtPatientShare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPatientShare.Size = new System.Drawing.Size(147, 21);
            this.txtPatientShare.TabIndex = 14;
            this.txtPatientShare.TabStop = false;
            this.txtPatientShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(167, 76);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "مبلغ پرداختی بیمار :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(167, 49);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "سهم بیمار :";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(709, 134);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "پزشک معالج :";
            // 
            // cboDoctor
            // 
            this.cboDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(556, 131);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboDoctor.Size = new System.Drawing.Size(147, 21);
            this.cboDoctor.TabIndex = 2;
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // fdpActiondate
            // 
            this.fdpActiondate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fdpActiondate.Location = new System.Drawing.Point(293, 50);
            this.fdpActiondate.Name = "fdpActiondate";
            this.fdpActiondate.Size = new System.Drawing.Size(147, 20);
            this.fdpActiondate.TabIndex = 4;
            this.fdpActiondate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // fdpReferenceDate
            // 
            this.fdpReferenceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fdpReferenceDate.Enabled = false;
            this.fdpReferenceDate.Location = new System.Drawing.Point(96, 50);
            this.fdpReferenceDate.Name = "fdpReferenceDate";
            this.fdpReferenceDate.Size = new System.Drawing.Size(120, 20);
            this.fdpReferenceDate.TabIndex = 6;
            this.fdpReferenceDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            this.fdpReferenceDate.SelectedDateTimeChanged += new System.EventHandler(this.fdpReferenceDate_SelectedDateTimeChanged);
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.txtPageNumber, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtPageNumber.Location = new System.Drawing.Point(373, 23);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPageNumber.Size = new System.Drawing.Size(67, 21);
            this.txtPageNumber.TabIndex = 3;
            this.txtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPageNumber.Leave += new System.EventHandler(this.txtPageNumber_Leave);
            // 
            // txtAssuranceType
            // 
            this.txtAssuranceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssuranceType.BackColor = System.Drawing.Color.Khaki;
            this.txtAssuranceType.Location = new System.Drawing.Point(293, 104);
            this.txtAssuranceType.Name = "txtAssuranceType";
            this.txtAssuranceType.ReadOnly = true;
            this.txtAssuranceType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAssuranceType.Size = new System.Drawing.Size(147, 21);
            this.txtAssuranceType.TabIndex = 11;
            this.txtAssuranceType.TabStop = false;
            // 
            // txtValidityDate
            // 
            this.txtValidityDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValidityDate.BackColor = System.Drawing.Color.Khaki;
            this.txtValidityDate.Location = new System.Drawing.Point(293, 77);
            this.txtValidityDate.Name = "txtValidityDate";
            this.txtValidityDate.ReadOnly = true;
            this.txtValidityDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValidityDate.Size = new System.Drawing.Size(147, 21);
            this.txtValidityDate.TabIndex = 10;
            this.txtValidityDate.TabStop = false;
            // 
            // txtAssuranceCode
            // 
            this.txtAssuranceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssuranceCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtAssuranceCode.Location = new System.Drawing.Point(556, 23);
            this.txtAssuranceCode.Name = "txtAssuranceCode";
            this.txtAssuranceCode.Size = new System.Drawing.Size(147, 21);
            this.txtAssuranceCode.TabIndex = 1;
            this.txtAssuranceCode.TextChanged += new System.EventHandler(this.txtAssuranceNumber_TextChanged);
            this.txtAssuranceCode.Leave += new System.EventHandler(this.txtAssuranceNumber_Leave);
            // 
            // txtSex
            // 
            this.txtSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSex.BackColor = System.Drawing.Color.Khaki;
            this.txtSex.Location = new System.Drawing.Point(650, 104);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSex.Size = new System.Drawing.Size(53, 21);
            this.txtSex.TabIndex = 3;
            this.txtSex.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.Khaki;
            this.txtName.Location = new System.Drawing.Point(556, 77);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(147, 21);
            this.txtName.TabIndex = 2;
            this.txtName.TabStop = false;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.Khaki;
            this.txtLastName.Location = new System.Drawing.Point(556, 50);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastName.Size = new System.Drawing.Size(147, 21);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.TabStop = false;
            // 
            // chkIsReferenced
            // 
            this.chkIsReferenced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsReferenced.AutoSize = true;
            this.chkIsReferenced.Location = new System.Drawing.Point(113, 21);
            this.chkIsReferenced.Name = "chkIsReferenced";
            this.chkIsReferenced.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsReferenced.Size = new System.Drawing.Size(103, 17);
            this.chkIsReferenced.TabIndex = 5;
            this.chkIsReferenced.Text = "نسخه ارجاع شده";
            this.chkIsReferenced.UseVisualStyleBackColor = true;
            this.chkIsReferenced.CheckedChanged += new System.EventHandler(this.chkIsReferenced_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 52);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "تاریخ ارجاع :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(709, 107);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "جنسیت :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 53);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "نام خانوادگی :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(709, 80);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "نام :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 107);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "نوع بیمه :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(709, 26);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره کد بیمه شده :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 53);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "تاریخ انجام خدمت :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 80);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "تاریخ اعتبار دفترچه :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 26);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "شماره صفحه نسخه :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddVisit);
            this.groupBox4.Controls.Add(this.btnAddService);
            this.groupBox4.Location = new System.Drawing.Point(13, 204);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 53);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // btnAddVisit
            // 
            this.btnAddVisit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVisit.Enabled = false;
            this.btnAddVisit.Location = new System.Drawing.Point(7, 12);
            this.btnAddVisit.Name = "btnAddVisit";
            this.btnAddVisit.Size = new System.Drawing.Size(79, 23);
            this.btnAddVisit.TabIndex = 9;
            this.btnAddVisit.Text = "افزودن ویزیت به نسخه";
            this.btnAddVisit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddVisit.UseVisualStyleBackColor = true;
            this.btnAddVisit.Click += new System.EventHandler(this.btnAddVisit_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddService.Enabled = false;
            this.btnAddService.Location = new System.Drawing.Point(89, 12);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(79, 23);
            this.btnAddService.TabIndex = 8;
            this.btnAddService.Text = "افزودن خدمت به نسخه";
            this.btnAddService.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCancle);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Location = new System.Drawing.Point(11, 443);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 47);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(5, 19);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 11;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(83, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ثبت";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RowNumber";
            this.dataGridViewTextBoxColumn1.FillWeight = 25F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ردیف";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 46;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ServiceCode";
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.HeaderText = "کد خدمت";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 278;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ServiceName";
            this.dataGridViewTextBoxColumn3.FillWeight = 130F;
            this.dataGridViewTextBoxColumn3.HeaderText = "نام خدمت";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 241;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ServicePrice";
            dataGridViewCellStyle6.Format = "0";
            dataGridViewCellStyle6.NullValue = "0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.FillWeight = 67.30414F;
            this.dataGridViewTextBoxColumn4.HeaderText = "تعرفه بیمه";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PatientShare";
            dataGridViewCellStyle7.Format = "0";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn5.FillWeight = 67.30414F;
            this.dataGridViewTextBoxColumn5.HeaderText = "سهم بیمار";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ServiceID";
            this.dataGridViewTextBoxColumn6.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // PrescriptionForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت نسخه";
            this.Load += new System.EventHandler(this.PrescriptionForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtServicePrice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboDoctor;
        private FADatePicker.FADatePicker fdpActiondate;
        private System.Windows.Forms.TextBox txtPatientShare;
        private FADatePicker.FADatePicker fdpReferenceDate;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.TextBox txtAssuranceType;
        private System.Windows.Forms.TextBox txtValidityDate;
        private System.Windows.Forms.TextBox txtAssuranceCode;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.CheckBox chkIsReferenced;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.DataGridView dgvServiceList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnAddVisit;
        private System.Windows.Forms.TextBox txtKCoeff;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Controls.MNMCurrencyTextBox txtPatientPayment;

    }
}