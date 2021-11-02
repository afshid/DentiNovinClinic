namespace DentiClinic
{
    partial class PatientDossierForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientDossierForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.fdpEndDate = new FADatePicker.FADatePicker();
            this.fdpStartDate = new FADatePicker.FADatePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTreatment = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTreatmentDoctor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTreatmentDate = new System.Windows.Forms.TextBox();
            this.txtToothKind = new System.Windows.Forms.TextBox();
            this.txtTreatment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TeethControl = new DentiClinic.Controls.Teeth();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPatientLastName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSex);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFileNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(554, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(299, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات بیمار  ";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(101, 137);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(122, 21);
            this.txtDoctor.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "پزشک معالج :";
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.Location = new System.Drawing.Point(99, 65);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.Size = new System.Drawing.Size(122, 21);
            this.txtPatientLastName.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "نام خانوادگی :";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(10, 65);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(54, 21);
            this.txtAge.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "سن : ";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(10, 32);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(54, 21);
            this.txtSex.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "جنسیت : ";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(101, 99);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(122, 21);
            this.txtPatientName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "نام :";
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Location = new System.Drawing.Point(167, 32);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(54, 21);
            this.txtFileNumber.TabIndex = 6;
            this.txtFileNumber.TextChanged += new System.EventHandler(this.txtFileNumber_TextChanged);
            this.txtFileNumber.Leave += new System.EventHandler(this.txtFileNumber_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "شماره پرونده : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.fdpEndDate);
            this.groupBox2.Controls.Add(this.fdpStartDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(554, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(300, 101);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "جستجو  ";
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(10, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // fdpEndDate
            // 
            this.fdpEndDate.Location = new System.Drawing.Point(101, 62);
            this.fdpEndDate.Name = "fdpEndDate";
            this.fdpEndDate.Size = new System.Drawing.Size(120, 20);
            this.fdpEndDate.TabIndex = 3;
            this.fdpEndDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // fdpStartDate
            // 
            this.fdpStartDate.Location = new System.Drawing.Point(101, 26);
            this.fdpStartDate.Name = "fdpStartDate";
            this.fdpStartDate.Size = new System.Drawing.Size(120, 20);
            this.fdpStartDate.TabIndex = 2;
            this.fdpStartDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "تا تاریخ : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "از تاریخ : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvTreatment);
            this.groupBox3.Location = new System.Drawing.Point(5, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(848, 261);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // dgvTreatment
            // 
            this.dgvTreatment.AllowUserToAddRows = false;
            this.dgvTreatment.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTreatment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTreatment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTreatment.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTreatment.Location = new System.Drawing.Point(7, 20);
            this.dgvTreatment.Name = "dgvTreatment";
            this.dgvTreatment.ReadOnly = true;
            this.dgvTreatment.Size = new System.Drawing.Size(834, 233);
            this.dgvTreatment.TabIndex = 5;
            this.dgvTreatment.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTreatment_RowHeaderMouseDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTreatmentDoctor);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Controls.Add(this.txtTreatmentDate);
            this.groupBox4.Controls.Add(this.txtToothKind);
            this.groupBox4.Controls.Add(this.txtTreatment);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.TeethControl);
            this.groupBox4.Location = new System.Drawing.Point(5, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(543, 299);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "سوابق درمان ";
            // 
            // txtTreatmentDoctor
            // 
            this.txtTreatmentDoctor.Location = new System.Drawing.Point(20, 186);
            this.txtTreatmentDoctor.Name = "txtTreatmentDoctor";
            this.txtTreatmentDoctor.ReadOnly = true;
            this.txtTreatmentDoctor.Size = new System.Drawing.Size(110, 21);
            this.txtTreatmentDoctor.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(131, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "پزشک معالج :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 213);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(445, 80);
            this.txtDescription.TabIndex = 31;
            // 
            // txtTreatmentDate
            // 
            this.txtTreatmentDate.Location = new System.Drawing.Point(20, 161);
            this.txtTreatmentDate.Name = "txtTreatmentDate";
            this.txtTreatmentDate.ReadOnly = true;
            this.txtTreatmentDate.Size = new System.Drawing.Size(110, 21);
            this.txtTreatmentDate.TabIndex = 30;
            // 
            // txtToothKind
            // 
            this.txtToothKind.Location = new System.Drawing.Point(368, 187);
            this.txtToothKind.Name = "txtToothKind";
            this.txtToothKind.ReadOnly = true;
            this.txtToothKind.Size = new System.Drawing.Size(97, 21);
            this.txtToothKind.TabIndex = 29;
            // 
            // txtTreatment
            // 
            this.txtTreatment.Location = new System.Drawing.Point(236, 161);
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.ReadOnly = true;
            this.txtTreatment.Size = new System.Drawing.Size(229, 21);
            this.txtTreatment.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "تاریخ درمان :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "توضیحات :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "نوع دندان :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "نام درمان : ";
            // 
            // TeethControl
            // 
            this.TeethControl.Location = new System.Drawing.Point(20, 32);
            this.TeethControl.LSelectedTeeth = ((System.Collections.Generic.List<DentiClinic.Controls.cTooth>)(resources.GetObject("TeethControl.LSelectedTeeth")));
            this.TeethControl.Mode = DentiClinic.BaseClasses.ToothMode.Adult;
            this.TeethControl.MultiSelect = false;
            this.TeethControl.Name = "TeethControl";
            this.TeethControl.PreviewMode = false;
            this.TeethControl.SelectMode = DentiClinic.BaseClasses.ToothSelectMode.Separate;
            this.TeethControl.Size = new System.Drawing.Size(445, 117);
            this.TeethControl.TabIndex = 0;
            this.TeethControl.LastSelectedToothChanged += new DentiClinic.BaseClasses.ToothButtonSelectedEventHandler(this.TeethControl_LastSelectedToothChanged);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Patient-TreatmentID";
            this.Column6.HeaderText = "شماره رکورد";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowNumber";
            this.Column1.FillWeight = 35F;
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TreatmentCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.FillWeight = 70F;
            this.Column2.HeaderText = "کد درمان";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PersianName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.FillWeight = 190F;
            this.Column3.HeaderText = "نام درمان";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 195;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "pToothDirection";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.FillWeight = 95F;
            this.Column4.HeaderText = "موقعیت دندان";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 95;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "lToothDirection";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.FillWeight = 85F;
            this.Column5.HeaderText = "شماره دندان";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 85;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "LastName";
            this.Column7.FillWeight = 120F;
            this.Column7.HeaderText = "پزشک معالج";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "visitDate";
            this.Column8.HeaderText = "تاریخ درمان";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 90F;
            this.Column9.HeaderText = "ساعت";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 90;
            // 
            // PatientDossierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 570);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PatientDossierForm";
            this.Text = "PatientDossierForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private FADatePicker.FADatePicker fdpEndDate;
        private FADatePicker.FADatePicker fdpStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private DentiClinic.Controls.Teeth TeethControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTreatmentDate;
        private System.Windows.Forms.TextBox txtToothKind;
        private System.Windows.Forms.TextBox txtTreatment;
        private System.Windows.Forms.DataGridView dgvTreatment;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTreatmentDoctor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}