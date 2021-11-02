namespace DentiNovin
{
    partial class BillForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPatientTreatment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFeesPayable = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.txtTotalFees = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fdpDateOfRegister = new FADatePicker.FADatePicker();
            this.txtFeesReceived = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPaySystem = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTreatment)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPatientTreatment);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(5, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvPatientTreatment
            // 
            this.dgvPatientTreatment.AllowUserToAddRows = false;
            this.dgvPatientTreatment.AllowUserToDeleteRows = false;
            this.dgvPatientTreatment.AllowUserToResizeColumns = false;
            this.dgvPatientTreatment.AllowUserToResizeRows = false;
            this.dgvPatientTreatment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatientTreatment.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientTreatment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatientTreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.TreatmentName,
            this.Column2,
            this.Column3});
            this.dgvPatientTreatment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPatientTreatment.Location = new System.Drawing.Point(3, 100);
            this.dgvPatientTreatment.Name = "dgvPatientTreatment";
            this.dgvPatientTreatment.ReadOnly = true;
            this.dgvPatientTreatment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientTreatment.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatientTreatment.RowHeadersVisible = false;
            this.dgvPatientTreatment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPatientTreatment.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatientTreatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientTreatment.Size = new System.Drawing.Size(746, 267);
            this.dgvPatientTreatment.TabIndex = 5;
            this.dgvPatientTreatment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientTreatment_CellClick);
            this.dgvPatientTreatment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPatientTreatment_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FalseValue = "0";
            this.Column1.FillWeight = 20F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "";
            this.Column1.IndeterminateValue = "2";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.ThreeState = true;
            this.Column1.TrueValue = "1";
            this.Column1.Width = 38;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RowNumber";
            this.dataGridViewTextBoxColumn1.FillWeight = 14.25747F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ردیف";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BillID";
            this.dataGridViewTextBoxColumn2.FillWeight = 24.80128F;
            this.dataGridViewTextBoxColumn2.HeaderText = "کد حساب";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn3.FillWeight = 52.49985F;
            this.dataGridViewTextBoxColumn3.HeaderText = "کد درمان";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // TreatmentName
            // 
            this.TreatmentName.DataPropertyName = "TreatmentServiceName";
            this.TreatmentName.FillWeight = 70.86079F;
            this.TreatmentName.HeaderText = "نام درمان";
            this.TreatmentName.Name = "TreatmentName";
            this.TreatmentName.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DoctorFullName";
            this.Column2.FillWeight = 35.4304F;
            this.Column2.HeaderText = "پزشک معالچ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "VisitDate";
            this.Column3.FillWeight = 95F;
            this.Column3.HeaderText = "تاریخ تکمیل درمان";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFeesPayable);
            this.groupBox2.Controls.Add(this.txtTotalFees);
            this.groupBox2.Controls.Add(this.txtBillNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.fdpDateOfRegister);
            this.groupBox2.Controls.Add(this.txtFeesReceived);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(130, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(617, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtFeesPayable
            // 
            this.txtFeesPayable.Location = new System.Drawing.Point(222, 49);
            this.txtFeesPayable.Name = "txtFeesPayable";
            this.txtFeesPayable.Size = new System.Drawing.Size(100, 21);
            this.txtFeesPayable.TabIndex = 2;
            this.txtFeesPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFeesPayable.Leave += new System.EventHandler(this.txtFeesPayable_Leave);
            // 
            // txtTotalFees
            // 
            this.txtTotalFees.Location = new System.Drawing.Point(222, 20);
            this.txtTotalFees.Name = "txtTotalFees";
            this.txtTotalFees.Size = new System.Drawing.Size(100, 21);
            this.txtTotalFees.TabIndex = 1;
            this.txtTotalFees.Text = "0";
            this.txtTotalFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalFees.Leave += new System.EventHandler(this.txtTotalFees_Leave);
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.Color.Khaki;
            this.txtBillNo.Location = new System.Drawing.Point(463, 20);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.ReadOnly = true;
            this.txtBillNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBillNo.Size = new System.Drawing.Size(63, 21);
            this.txtBillNo.TabIndex = 100;
            this.txtBillNo.TabStop = false;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "کد صورتحساب :";
            // 
            // fdpDateOfRegister
            // 
            this.fdpDateOfRegister.Location = new System.Drawing.Point(29, 23);
            this.fdpDateOfRegister.Name = "fdpDateOfRegister";
            this.fdpDateOfRegister.Size = new System.Drawing.Size(101, 20);
            this.fdpDateOfRegister.TabIndex = 3;
            this.fdpDateOfRegister.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // txtFeesReceived
            // 
            this.txtFeesReceived.BackColor = System.Drawing.Color.Khaki;
            this.txtFeesReceived.Location = new System.Drawing.Point(29, 49);
            this.txtFeesReceived.Name = "txtFeesReceived";
            this.txtFeesReceived.ReadOnly = true;
            this.txtFeesReceived.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFeesReceived.Size = new System.Drawing.Size(101, 21);
            this.txtFeesReceived.TabIndex = 101;
            this.txtFeesReceived.TabStop = false;
            this.txtFeesReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "هزینه قابل پرداخت:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "مبلغ دریافتی :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = " تاریخ صدور:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "هزینه درمان :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPaySystem);
            this.groupBox4.Location = new System.Drawing.Point(6, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(119, 48);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // btnPaySystem
            // 
            this.btnPaySystem.Enabled = false;
            this.btnPaySystem.Location = new System.Drawing.Point(7, 16);
            this.btnPaySystem.Name = "btnPaySystem";
            this.btnPaySystem.Size = new System.Drawing.Size(105, 23);
            this.btnPaySystem.TabIndex = 4;
            this.btnPaySystem.Text = "سیستم پرداخت";
            this.btnPaySystem.UseVisualStyleBackColor = true;
            this.btnPaySystem.Click += new System.EventHandler(this.btnPaySystem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCancle);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Location = new System.Drawing.Point(17, 355);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(164, 47);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(5, 20);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(83, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "ثبت";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PersianName";
            this.dataGridViewTextBoxColumn4.FillWeight = 70.86079F;
            this.dataGridViewTextBoxColumn4.HeaderText = "نام درمان";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 224;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DoctorFullName";
            this.dataGridViewTextBoxColumn5.FillWeight = 35.4304F;
            this.dataGridViewTextBoxColumn5.HeaderText = "پزشک معالچ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 112;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn6.FillWeight = 95.0498F;
            this.dataGridViewTextBoxColumn6.HeaderText = "هزینه درمان";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "VisitDate";
            this.dataGridViewTextBoxColumn7.FillWeight = 95F;
            this.dataGridViewTextBoxColumn7.HeaderText = "تاریخ تکمیل درمان";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // BillForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم صورتحساب";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTreatment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label4;
        private FADatePicker.FADatePicker fdpDateOfRegister;
        private System.Windows.Forms.TextBox txtFeesReceived;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPaySystem;
        private System.Windows.Forms.DataGridView dgvPatientTreatment;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Controls.MNMCurrencyTextBox txtTotalFees;
        private Controls.MNMCurrencyTextBox txtFeesPayable;

    }
}