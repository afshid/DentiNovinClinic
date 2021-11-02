namespace DentiClinic
{
    partial class TreatmentForm
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
            this.fdpActiveDate = new FADatePicker.FADatePicker();
            this.dgvTreatment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.cboNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTariffWO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTariffW = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTreatmentCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboTreatmentTitle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fdpActiveDate
            // 
            this.fdpActiveDate.Location = new System.Drawing.Point(29, 25);
            this.fdpActiveDate.Name = "fdpActiveDate";
            this.fdpActiveDate.Size = new System.Drawing.Size(120, 20);
            this.fdpActiveDate.TabIndex = 1;
            this.fdpActiveDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // dgvTreatment
            // 
            this.dgvTreatment.AllowUserToAddRows = false;
            this.dgvTreatment.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTreatment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8});
            this.dgvTreatment.Location = new System.Drawing.Point(2, 227);
            this.dgvTreatment.Name = "dgvTreatment";
            this.dgvTreatment.ReadOnly = true;
            this.dgvTreatment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvTreatment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTreatment.Size = new System.Drawing.Size(504, 359);
            this.dgvTreatment.TabIndex = 3;
            this.dgvTreatment.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTreatment_RowHeaderMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TreatmentID";
            this.Column1.HeaderText = "شماره رکورد";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RowNumber";
            this.Column2.FillWeight = 35F;
            this.Column2.HeaderText = "ردیف";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 35;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TreatmentCode";
            this.Column3.FillWeight = 70F;
            this.Column3.HeaderText = "کد درمان";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PersianName";
            this.Column4.FillWeight = 200F;
            this.Column4.HeaderText = "نام درمان";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ToothProp";
            this.Column5.HeaderText = "مشخصات دندان";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DateOfRegister";
            this.Column8.HeaderText = "تاریخ اعمال";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = ": نام درمان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ": جهت دندان";
            // 
            // cboDirection
            // 
            this.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Items.AddRange(new object[] {
            "بالا - چپ",
            "بالا - راست",
            "پایین - چپ",
            "پایین - راست"});
            this.cboDirection.Location = new System.Drawing.Point(336, 61);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboDirection.Size = new System.Drawing.Size(88, 21);
            this.cboDirection.TabIndex = 10;
            // 
            // cboNumber
            // 
            this.cboNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumber.FormattingEnabled = true;
            this.cboNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cboNumber.Location = new System.Drawing.Point(336, 97);
            this.cboNumber.Name = "cboNumber";
            this.cboNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboNumber.Size = new System.Drawing.Size(88, 21);
            this.cboNumber.TabIndex = 12;
            this.cboNumber.SelectedIndexChanged += new System.EventHandler(this.cboNumber_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = ": شماره دندان";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 136);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "هزینه درمان :";
            // 
            // txtTariffWO
            // 
            this.txtTariffWO.Location = new System.Drawing.Point(336, 133);
            this.txtTariffWO.Name = "txtTariffWO";
            this.txtTariffWO.Size = new System.Drawing.Size(88, 21);
            this.txtTariffWO.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "تعرفه بیمه :";
            // 
            // txtTariffW
            // 
            this.txtTariffW.Location = new System.Drawing.Point(18, 60);
            this.txtTariffW.Name = "txtTariffW";
            this.txtTariffW.Size = new System.Drawing.Size(93, 21);
            this.txtTariffW.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTreatmentCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTariffW);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(9, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(177, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات بیمه ";
            // 
            // txtTreatmentCode
            // 
            this.txtTreatmentCode.Location = new System.Drawing.Point(18, 26);
            this.txtTreatmentCode.Name = "txtTreatmentCode";
            this.txtTreatmentCode.Size = new System.Drawing.Size(93, 21);
            this.txtTreatmentCode.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "کد بیمه :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = ": تاریخ اعمال";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(7, 182);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 19;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(88, 182);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(169, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(451, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = ": جستجو";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(361, 200);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(88, 21);
            this.txtSearch.TabIndex = 22;
            // 
            // cboSearch
            // 
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "انتخاب ...",
            "کد درمان",
            "نام درمان"});
            this.cboSearch.Location = new System.Drawing.Point(267, 200);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboSearch.Size = new System.Drawing.Size(88, 21);
            this.cboSearch.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 62);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(261, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 62);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboTreatmentTitle);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtTariffWO);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cboDirection);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cboNumber);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.fdpActiveDate);
            this.groupBox4.Location = new System.Drawing.Point(4, -4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(501, 180);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // cboTreatmentTitle
            // 
            this.cboTreatmentTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreatmentTitle.FormattingEnabled = true;
            this.cboTreatmentTitle.Location = new System.Drawing.Point(248, 24);
            this.cboTreatmentTitle.Name = "cboTreatmentTitle";
            this.cboTreatmentTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboTreatmentTitle.Size = new System.Drawing.Size(176, 21);
            this.cboTreatmentTitle.TabIndex = 13;
            this.cboTreatmentTitle.SelectedIndexChanged += new System.EventHandler(this.cboTreatmentTitle_SelectedIndexChanged);
            // 
            // TreatmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 587);
            this.Controls.Add(this.cboSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.dgvTreatment);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.Name = "TreatmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreatmentForm";
            this.Load += new System.EventHandler(this.TreatmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FADatePicker.FADatePicker fdpActiveDate;
        private System.Windows.Forms.DataGridView dgvTreatment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.ComboBox cboNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTariffWO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTariffW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboTreatmentTitle;
        private System.Windows.Forms.TextBox txtTreatmentCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}