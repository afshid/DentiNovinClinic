namespace DentiNovin
{
    partial class BillPaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFeesReceived = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.fdpDateOfRegister = new FADatePicker.FADatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFeesPayable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.txtRemainFees = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvBillPaymentList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillPaymentList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.dgvBillPaymentList);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(5, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 304);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFeesReceived);
            this.groupBox1.Controls.Add(this.fdpDateOfRegister);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFeesPayable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPayType);
            this.groupBox1.Controls.Add(this.txtRemainFees);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtFeesReceived
            // 
            this.txtFeesReceived.Location = new System.Drawing.Point(284, 72);
            this.txtFeesReceived.Name = "txtFeesReceived";

            this.txtFeesReceived.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFeesReceived.Size = new System.Drawing.Size(100, 21);
            this.txtFeesReceived.TabIndex = 1;
            this.txtFeesReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFeesReceived.Leave += new System.EventHandler(this.txtFeesReceived_Leave);
            // 
            // fdpDateOfRegister
            // 
            this.fdpDateOfRegister.Location = new System.Drawing.Point(40, 16);
            this.fdpDateOfRegister.Name = "fdpDateOfRegister";
            this.fdpDateOfRegister.Size = new System.Drawing.Size(100, 20);
            this.fdpDateOfRegister.TabIndex = 2;
            this.fdpDateOfRegister.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "تاریخ  پرداخت :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 75);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "مبلغ پرداختی :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 47);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "نوع پرداخت :";
            // 
            // txtFeesPayable
            // 
            this.txtFeesPayable.BackColor = System.Drawing.Color.Khaki;
            this.txtFeesPayable.Location = new System.Drawing.Point(284, 15);
            this.txtFeesPayable.Name = "txtFeesPayable";
            this.txtFeesPayable.ReadOnly = true;
            this.txtFeesPayable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFeesPayable.Size = new System.Drawing.Size(100, 21);
            this.txtFeesPayable.TabIndex = 15;
            this.txtFeesPayable.TabStop = false;
            this.txtFeesPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 47);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "مانده حساب :";
            // 
            // cboPayType
            // 
            this.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.Items.AddRange(new object[] {
            "نقدی",
            "کارت بانکی",
            "چکی"});
            this.cboPayType.Location = new System.Drawing.Point(40, 44);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPayType.Size = new System.Drawing.Size(100, 21);
            this.cboPayType.TabIndex = 3;
            // 
            // txtRemainFees
            // 
            this.txtRemainFees.BackColor = System.Drawing.Color.Khaki;
            this.txtRemainFees.Location = new System.Drawing.Point(284, 44);
            this.txtRemainFees.Name = "txtRemainFees";
            this.txtRemainFees.ReadOnly = true;
            this.txtRemainFees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemainFees.Size = new System.Drawing.Size(100, 21);
            this.txtRemainFees.TabIndex = 4;
            this.txtRemainFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(384, 19);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "هزینه قابل پرداخت:";
            // 
            // dgvBillPaymentList
            // 
            this.dgvBillPaymentList.AllowUserToAddRows = false;
            this.dgvBillPaymentList.AllowUserToDeleteRows = false;
            this.dgvBillPaymentList.AllowUserToResizeColumns = false;
            this.dgvBillPaymentList.AllowUserToResizeRows = false;
            this.dgvBillPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillPaymentList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillPaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBillPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvBillPaymentList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvBillPaymentList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBillPaymentList.Location = new System.Drawing.Point(3, 143);
            this.dgvBillPaymentList.MultiSelect = false;
            this.dgvBillPaymentList.Name = "dgvBillPaymentList";
            this.dgvBillPaymentList.ReadOnly = true;
            this.dgvBillPaymentList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBillPaymentList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBillPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillPaymentList.Size = new System.Drawing.Size(490, 158);
            this.dgvBillPaymentList.TabIndex = 5;
            this.dgvBillPaymentList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBillPaymentList_CellFormatting);
            this.dgvBillPaymentList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBillPaymentList_CellMouseUp);
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
            this.Column2.DataPropertyName = "FeesReceived";
            dataGridViewCellStyle2.Format = "#,0;(#,0)";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.FillWeight = 60F;
            this.Column2.HeaderText = "مبلغ پرداختی";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PayTypeName";
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "نوع پرداخت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DateOfRegister";
            this.Column4.HeaderText = "تاریخ پرداخت";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.tsmiEdit.Enabled = false;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPay);
            this.groupBox2.Location = new System.Drawing.Point(19, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(85, 42);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(5, 15);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "پرداخت";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(5, 19);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCancle);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Location = new System.Drawing.Point(18, 292);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(161, 47);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(82, 19);
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
            // BillPaymentForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 343);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم پرداختها";
            this.Load += new System.EventHandler(this.BillPaymentForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillPaymentList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private FADatePicker.FADatePicker fdpDateOfRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFeesPayable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPayType;
        private System.Windows.Forms.TextBox txtRemainFees;
        private System.Windows.Forms.DataGridView dgvBillPaymentList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private Controls.MNMCurrencyTextBox txtFeesReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;

    }
}