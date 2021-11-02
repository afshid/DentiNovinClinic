namespace DentiNovin
{
    partial class BillListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtFeesAllPayable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemainFees = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalAllFees = new System.Windows.Forms.TextBox();
            this.txtFeesAllReceived = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBill);
            this.splitContainer1.Size = new System.Drawing.Size(960, 634);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddBill);
            this.groupBox4.Controls.Add(this.btnPrint);
            this.groupBox4.Location = new System.Drawing.Point(10, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 61);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            // 
            // btnAddBill
            // 
            this.btnAddBill.Location = new System.Drawing.Point(50, 17);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(105, 23);
            this.btnAddBill.TabIndex = 3;
            this.btnAddBill.Text = "صورتحساب جدید";
            this.btnAddBill.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddBill.UseVisualStyleBackColor = true;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::DentiNovin.Properties.Resources.print_icon;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(6, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(38, 32);
            this.btnPrint.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnPrint, "نسخه چاپی");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtFeesAllPayable);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtRemainFees);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtTotalAllFees);
            this.groupBox5.Controls.Add(this.txtFeesAllReceived);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(411, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(277, 117);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "اطلاعات کل حساب ";
            // 
            // txtFeesAllPayable
            // 
            this.txtFeesAllPayable.BackColor = System.Drawing.Color.Khaki;
            this.txtFeesAllPayable.Location = new System.Drawing.Point(27, 41);
            this.txtFeesAllPayable.Name = "txtFeesAllPayable";
            this.txtFeesAllPayable.ReadOnly = true;
            this.txtFeesAllPayable.Size = new System.Drawing.Size(133, 21);
            this.txtFeesAllPayable.TabIndex = 26;
            this.txtFeesAllPayable.TabStop = false;
            this.txtFeesAllPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "کل هزینه قابل پرداخت :";
            // 
            // txtRemainFees
            // 
            this.txtRemainFees.BackColor = System.Drawing.Color.Khaki;
            this.txtRemainFees.Location = new System.Drawing.Point(27, 89);
            this.txtRemainFees.Name = "txtRemainFees";
            this.txtRemainFees.ReadOnly = true;
            this.txtRemainFees.Size = new System.Drawing.Size(133, 21);
            this.txtRemainFees.TabIndex = 24;
            this.txtRemainFees.TabStop = false;
            this.txtRemainFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "مانده حساب :";
            // 
            // txtTotalAllFees
            // 
            this.txtTotalAllFees.BackColor = System.Drawing.Color.Khaki;
            this.txtTotalAllFees.Location = new System.Drawing.Point(27, 17);
            this.txtTotalAllFees.Name = "txtTotalAllFees";
            this.txtTotalAllFees.ReadOnly = true;
            this.txtTotalAllFees.Size = new System.Drawing.Size(133, 21);
            this.txtTotalAllFees.TabIndex = 20;
            this.txtTotalAllFees.TabStop = false;
            this.txtTotalAllFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFeesAllReceived
            // 
            this.txtFeesAllReceived.BackColor = System.Drawing.Color.Khaki;
            this.txtFeesAllReceived.Location = new System.Drawing.Point(27, 65);
            this.txtFeesAllReceived.Name = "txtFeesAllReceived";
            this.txtFeesAllReceived.ReadOnly = true;
            this.txtFeesAllReceived.Size = new System.Drawing.Size(133, 21);
            this.txtFeesAllReceived.TabIndex = 22;
            this.txtFeesAllReceived.TabStop = false;
            this.txtFeesAllReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "کل مبلغ دریافتی :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "کل هزینه درمان :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchPatient);
            this.groupBox2.Controls.Add(this.txtFileNumber);
            this.groupBox2.Controls.Add(this.txtFirstName);
            this.groupBox2.Controls.Add(this.txtPatientLastName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(694, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(266, 117);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات بیمار  ";
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Location = new System.Drawing.Point(47, 23);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(65, 23);
            this.btnSearchPatient.TabIndex = 2;
            this.btnSearchPatient.Text = "...";
            this.btnSearchPatient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnSearchPatient, "جستجوی بیمار");
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Location = new System.Drawing.Point(118, 24);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(63, 21);
            this.txtFileNumber.TabIndex = 1;
            this.txtFileNumber.TextChanged += new System.EventHandler(this.txtFileNumber_TextChanged);
            this.txtFileNumber.Leave += new System.EventHandler(this.txtFileNumber_Leave);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Khaki;
            this.txtFirstName.Location = new System.Drawing.Point(47, 78);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(134, 21);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.TabStop = false;
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.BackColor = System.Drawing.Color.Khaki;
            this.txtPatientLastName.Location = new System.Drawing.Point(47, 51);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.ReadOnly = true;
            this.txtPatientLastName.Size = new System.Drawing.Size(134, 21);
            this.txtPatientLastName.TabIndex = 2;
            this.txtPatientLastName.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "نام خانوادگی  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "شماره پرونده :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(183, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "نام بیمار:";
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            this.dgvBill.AllowUserToResizeColumns = false;
            this.dgvBill.AllowUserToResizeRows = false;
            this.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.BillID,
            this.Column3,
            this.Column1,
            this.Fee,
            this.Column2,
            this.Date});
            this.dgvBill.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBill.Location = new System.Drawing.Point(0, 0);
            this.dgvBill.MultiSelect = false;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.ReadOnly = true;
            this.dgvBill.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBill.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBill.Size = new System.Drawing.Size(960, 516);
            this.dgvBill.TabIndex = 5;
            this.dgvBill.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellDoubleClick);
            this.dgvBill.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBill_CellMouseUp);
            this.dgvBill.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvBill_KeyUp);
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.FillWeight = 15F;
            this.RowNumber.HeaderText = "ردیف";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            // 
            // BillID
            // 
            this.BillID.DataPropertyName = "BillID";
            this.BillID.FillWeight = 40F;
            this.BillID.HeaderText = "کد حساب";
            this.BillID.Name = "BillID";
            this.BillID.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TotalFees";
            dataGridViewCellStyle2.Format = "#,0;(#,0)";
            dataGridViewCellStyle2.NullValue = "0";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.FillWeight = 45F;
            this.Column3.HeaderText = "هزینه درمان";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FeesPayable";
            dataGridViewCellStyle3.Format = "#,0;(#,0)";
            dataGridViewCellStyle3.NullValue = "0";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 45F;
            this.Column1.HeaderText = "هزینه قابل پرداخت";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Fee
            // 
            this.Fee.DataPropertyName = "FeesReceived";
            dataGridViewCellStyle4.Format = "#,0;(#,0)";
            dataGridViewCellStyle4.NullValue = "0";
            this.Fee.DefaultCellStyle = dataGridViewCellStyle4;
            this.Fee.FillWeight = 45F;
            this.Fee.HeaderText = "مبلغ دریافتی";
            this.Fee.Name = "Fee";
            this.Fee.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RemainFees";
            dataGridViewCellStyle5.Format = "#,0;(#,0)";
            dataGridViewCellStyle5.NullValue = "0";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.FillWeight = 45F;
            this.Column2.HeaderText = "مانده حساب";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "DateOfRegister";
            this.Date.FillWeight = 40F;
            this.Date.HeaderText = "تاریخ ثبت";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
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
            this.tsmiDelete.Checked = true;
            this.tsmiDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(82, 22);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // BillListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 634);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BillListForm";
            this.Text = "لیست صورتحساب";
            this.Load += new System.EventHandler(this.BillListForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtRemainFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalAllFees;
        private System.Windows.Forms.TextBox txtFeesAllReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtFeesAllPayable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}