using System;
namespace DentiNovin
{
    partial class AppointmentForm
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.appointmentControl1 = new DentiNovin.Controls.AppointmentControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.cbxGroup = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnPatientRegister = new System.Windows.Forms.Button();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPatientAppointment = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartShortTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.appointmentControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 38;
            this.splitContainer1.Size = new System.Drawing.Size(963, 741);
            this.splitContainer1.SplitterDistance = 729;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // appointmentControl1
            // 
            this.appointmentControl1.AptStatus = DentiNovin.BaseClasses.AppointmentStatus.Normal;
            this.appointmentControl1.BackColor = System.Drawing.SystemColors.Control;
            this.appointmentControl1.CurrentPatientID = 0;
            this.appointmentControl1.DaysNumber = 0;
            this.appointmentControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appointmentControl1.DSAppointment = null;
            this.appointmentControl1.IsOutOfRange = false;
            this.appointmentControl1.Location = new System.Drawing.Point(0, 0);
            this.appointmentControl1.Name = "appointmentControl1";
            this.appointmentControl1.oGroup = null;
            this.appointmentControl1.Registerable = false;
            this.appointmentControl1.Size = new System.Drawing.Size(729, 741);
            this.appointmentControl1.TabIndex = 9;
            this.appointmentControl1.RegisterClicked += new DentiNovin.BaseClasses.VisitNodeEventHandler(this.appointmentControl1_RegisterClicked);
            this.appointmentControl1.UnRegisterClicked += new DentiNovin.BaseClasses.VisitNodeEventHandler(this.appointmentControl1_UnRegisterClicked);
            this.appointmentControl1.PatientEnterClicked += new DentiNovin.BaseClasses.VisitNodeEventHandler(this.appointmentControl1_PatientEnterClicked);
            this.appointmentControl1.ShowDossierClicked += new DentiNovin.BaseClasses.VisitNodeEventHandler(this.appointmentControl1_ShowDossierClicked);
            this.appointmentControl1.ShowBillClicked += new DentiNovin.BaseClasses.VisitNodeEventHandler(this.appointmentControl1_ShowBillClicked);
            this.appointmentControl1.SelectedDateTimeChanged += new System.EventHandler(this.appointmentControl1_SelectedDateTimeChanged);
            this.appointmentControl1.RefreshRequested += new System.EventHandler(this.appointmentControl1_RefreshRequested);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(233, 741);
            this.splitContainer2.SplitterDistance = 168;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchPatient);
            this.groupBox1.Controls.Add(this.cbxGroup);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Controls.Add(this.btnPatientRegister);
            this.groupBox1.Controls.Add(this.cbxDoctor);
            this.groupBox1.Controls.Add(this.lblDoctor);
            this.groupBox1.Controls.Add(this.txtPatientLastName);
            this.groupBox1.Controls.Add(this.lblLastName);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtFileNumber);
            this.groupBox1.Controls.Add(this.lblFileNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(233, 168);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات بیمار";
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearchPatient.Location = new System.Drawing.Point(6, 20);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(65, 23);
            this.btnSearchPatient.TabIndex = 2;
            this.btnSearchPatient.Text = "...";
            this.btnSearchPatient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnSearchPatient, "جستجوی بیمار");
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // cbxGroup
            // 
            this.cbxGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroup.FormattingEnabled = true;
            this.cbxGroup.Location = new System.Drawing.Point(7, 131);
            this.cbxGroup.Name = "cbxGroup";
            this.cbxGroup.Size = new System.Drawing.Size(148, 21);
            this.cbxGroup.TabIndex = 7;
            this.cbxGroup.SelectedIndexChanged += new System.EventHandler(this.cbxGroup_SelectedIndexChanged);
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(158, 134);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(70, 13);
            this.lblGroup.TabIndex = 9;
            this.lblGroup.Text = "شیفت کاری :";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPatientRegister
            // 
            this.btnPatientRegister.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPatientRegister.Location = new System.Drawing.Point(6, 75);
            this.btnPatientRegister.Name = "btnPatientRegister";
            this.btnPatientRegister.Size = new System.Drawing.Size(65, 23);
            this.btnPatientRegister.TabIndex = 5;
            this.btnPatientRegister.Text = "بیمار جدید";
            this.btnPatientRegister.UseVisualStyleBackColor = true;
            this.btnPatientRegister.Click += new System.EventHandler(this.btnPatientRegister_Click);
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(7, 104);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(148, 21);
            this.cbxDoctor.TabIndex = 6;
            this.cbxDoctor.SelectedIndexChanged += new System.EventHandler(this.cbxDoctor_SelectedIndexChanged);
            // 
            // lblDoctor
            // 
            this.lblDoctor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctor.Location = new System.Drawing.Point(158, 107);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(73, 13);
            this.lblDoctor.TabIndex = 6;
            this.lblDoctor.Text = "پزشک معالج :";
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPatientLastName.Location = new System.Drawing.Point(7, 48);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.Size = new System.Drawing.Size(148, 21);
            this.txtPatientLastName.TabIndex = 3;
            this.txtPatientLastName.Leave += new System.EventHandler(this.txtPatientLastName_Leave);
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Location = new System.Drawing.Point(158, 51);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(72, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "نام خانوادگی :";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPatientName.Location = new System.Drawing.Point(78, 76);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(77, 21);
            this.txtPatientName.TabIndex = 4;
            this.txtPatientName.Leave += new System.EventHandler(this.txtPatientName_Leave);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(158, 79);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(27, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "نام :";
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFileNumber.Location = new System.Drawing.Point(78, 21);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(77, 21);
            this.txtFileNumber.TabIndex = 1;
            this.txtFileNumber.TextChanged += new System.EventHandler(this.txtFileNumber_TextChanged);
            this.txtFileNumber.Leave += new System.EventHandler(this.txtFileNumber_Leave);
            // 
            // lblFileNumber
            // 
            this.lblFileNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFileNumber.AutoSize = true;
            this.lblFileNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblFileNumber.Location = new System.Drawing.Point(158, 23);
            this.lblFileNumber.Name = "lblFileNumber";
            this.lblFileNumber.Size = new System.Drawing.Size(74, 13);
            this.lblFileNumber.TabIndex = 0;
            this.lblFileNumber.Text = "شماره پرونده :";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvPatientAppointment);
            this.splitContainer3.Size = new System.Drawing.Size(233, 572);
            this.splitContainer3.SplitterDistance = 39;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 39);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(164, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 9);
            this.label1.TabIndex = 0;
            this.label1.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gold;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(106, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 9);
            this.label4.TabIndex = 2;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "خارج از نوبت";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "نرمال";
            this.label2.Visible = false;
            // 
            // dgvPatientAppointment
            // 
            this.dgvPatientAppointment.AllowUserToAddRows = false;
            this.dgvPatientAppointment.AllowUserToDeleteRows = false;
            this.dgvPatientAppointment.AllowUserToResizeColumns = false;
            this.dgvPatientAppointment.AllowUserToResizeRows = false;
            this.dgvPatientAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientAppointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientAppointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.VisitDate,
            this.StartShortTime,
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatientAppointment.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatientAppointment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatientAppointment.Location = new System.Drawing.Point(0, 0);
            this.dgvPatientAppointment.Name = "dgvPatientAppointment";
            this.dgvPatientAppointment.ReadOnly = true;
            this.dgvPatientAppointment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPatientAppointment.RowHeadersVisible = false;
            this.dgvPatientAppointment.RowHeadersWidth = 21;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvPatientAppointment.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPatientAppointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientAppointment.Size = new System.Drawing.Size(233, 532);
            this.dgvPatientAppointment.TabIndex = 8;
            this.dgvPatientAppointment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientAppointment_CellDoubleClick);
            this.dgvPatientAppointment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPatientAppointment_CellFormatting);
            // 
            // RowNumber
            // 
            this.RowNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.FillWeight = 50F;
            this.RowNumber.Frozen = true;
            this.RowNumber.HeaderText = "ردیف";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowNumber.Width = 45;
            // 
            // VisitDate
            // 
            this.VisitDate.DataPropertyName = "VisitDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VisitDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.VisitDate.HeaderText = "تاریخ";
            this.VisitDate.Name = "VisitDate";
            this.VisitDate.ReadOnly = true;
            this.VisitDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StartShortTime
            // 
            this.StartShortTime.DataPropertyName = "StartShortTime";
            this.StartShortTime.FillWeight = 85F;
            this.StartShortTime.HeaderText = "ساعت";
            this.StartShortTime.Name = "StartShortTime";
            this.StartShortTime.ReadOnly = true;
            this.StartShortTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StartShortTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StatusName";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 40F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 741);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم نوبت دهی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            this.SizeChanged += new System.EventHandler(this.AppointmentForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientAppointment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.AppointmentControl appointmentControl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvPatientAppointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartShortTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.ComboBox cbxGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button btnPatientRegister;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;


    }
}