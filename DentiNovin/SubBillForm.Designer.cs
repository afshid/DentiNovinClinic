namespace DentiClinic
{
    partial class BillDetailsForm
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
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fdpDateOfRegister = new FADatePicker.FADatePicker();
            this.txtFeesPayable = new System.Windows.Forms.TextBox();
            this.txtFeesReceived = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalFees = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBillDetails
            // 
            this.dgvBillDetails.AllowUserToAddRows = false;
            this.dgvBillDetails.AllowUserToDeleteRows = false;
            this.dgvBillDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvBillDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBillDetails.Location = new System.Drawing.Point(0, 130);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.ReadOnly = true;
            this.dgvBillDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvBillDetails.Size = new System.Drawing.Size(603, 177);
            this.dgvBillDetails.TabIndex = 0;
            // 
            // RowNumber
            // 
            this.RowNumber.FillWeight = 30F;
            this.RowNumber.HeaderText = "ردیف";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 99.49239F;
            this.Column1.HeaderText = "تاریخ پرداخت";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 99.49239F;
            this.Column2.HeaderText = "مبلغ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 99.49239F;
            this.Column3.HeaderText = "نوع پرداخت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancle);
            this.groupBox1.Controls.Add(this.btnPay);
            this.groupBox1.Controls.Add(this.cboPayType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fdpDateOfRegister);
            this.groupBox1.Controls.Add(this.txtFeesPayable);
            this.groupBox1.Controls.Add(this.txtFeesReceived);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTotalFees);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCancle
            // 
            this.btnCancle.Enabled = false;
            this.btnCancle.Location = new System.Drawing.Point(7, 95);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 29;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(87, 95);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 28;
            this.btnPay.Text = "پرداخت";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // cboPayType
            // 
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.Items.AddRange(new object[] {
            "نقدی",
            "کارت بانکی",
            "چکی"});
            this.cboPayType.Location = new System.Drawing.Point(187, 54);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.Size = new System.Drawing.Size(101, 21);
            this.cboPayType.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 57);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = " نوع پرداخت:";
            // 
            // fdpDateOfRegister
            // 
            this.fdpDateOfRegister.Location = new System.Drawing.Point(187, 29);
            this.fdpDateOfRegister.Name = "fdpDateOfRegister";
            this.fdpDateOfRegister.Size = new System.Drawing.Size(101, 20);
            this.fdpDateOfRegister.TabIndex = 23;
            this.fdpDateOfRegister.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // txtFeesPayable
            // 
            this.txtFeesPayable.Location = new System.Drawing.Point(407, 54);
            this.txtFeesPayable.Name = "txtFeesPayable";
            this.txtFeesPayable.Size = new System.Drawing.Size(100, 21);
            this.txtFeesPayable.TabIndex = 21;
            // 
            // txtFeesReceived
            // 
            this.txtFeesReceived.Location = new System.Drawing.Point(406, 81);
            this.txtFeesReceived.Name = "txtFeesReceived";
            this.txtFeesReceived.Size = new System.Drawing.Size(101, 21);
            this.txtFeesReceived.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 57);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "مبلغ قابل پرداخت:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(509, 84);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "مبلغ پرداختی :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = " تاریخ پرداخت:";
            // 
            // txtTotalFees
            // 
            this.txtTotalFees.Location = new System.Drawing.Point(408, 28);
            this.txtTotalFees.Name = "txtTotalFees";
            this.txtTotalFees.Size = new System.Drawing.Size(100, 21);
            this.txtTotalFees.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 31);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "هزینه درمان :";
            // 
            // BillDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 307);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBillDetails);
            this.Name = "BillDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillDetailsForm";
            this.Load += new System.EventHandler(this.BillDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPayType;
        private System.Windows.Forms.Label label3;
        private FADatePicker.FADatePicker fdpDateOfRegister;
        private System.Windows.Forms.TextBox txtFeesPayable;
        private System.Windows.Forms.TextBox txtFeesReceived;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancle;
    }
}