namespace DentiNovin
{
    partial class ServicePickup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAssuranceServiceList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboServiceHeader = new System.Windows.Forms.ComboBox();
            this.txtSeviceCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssuranceName = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssuranceServiceList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAssuranceServiceList
            // 
            this.dgvAssuranceServiceList.AllowUserToAddRows = false;
            this.dgvAssuranceServiceList.AllowUserToDeleteRows = false;
            this.dgvAssuranceServiceList.AllowUserToResizeColumns = false;
            this.dgvAssuranceServiceList.AllowUserToResizeRows = false;
            this.dgvAssuranceServiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssuranceServiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssuranceServiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAssuranceServiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4});
            this.dgvAssuranceServiceList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAssuranceServiceList.Location = new System.Drawing.Point(0, 45);
            this.dgvAssuranceServiceList.Name = "dgvAssuranceServiceList";
            this.dgvAssuranceServiceList.ReadOnly = true;
            this.dgvAssuranceServiceList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAssuranceServiceList.RowHeadersVisible = false;
            this.dgvAssuranceServiceList.RowHeadersWidth = 25;
            this.dgvAssuranceServiceList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAssuranceServiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssuranceServiceList.Size = new System.Drawing.Size(616, 349);
            this.dgvAssuranceServiceList.TabIndex = 4;
            this.dgvAssuranceServiceList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssuranceServiceList_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FillWeight = 35F;
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ServiceCode";
            this.Column2.FillWeight = 65F;
            this.Column2.HeaderText = "کد خدمت";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "HeaderName";
            this.Column5.HeaderText = "گروه خدمت";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DetailsName";
            this.Column3.FillWeight = 150F;
            this.Column3.HeaderText = "شرح خدمت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "AssuranceName";
            this.Column4.FillWeight = 65F;
            this.Column4.HeaderText = "نوع بیمه";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboServiceHeader);
            this.groupBox1.Controls.Add(this.txtSeviceCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServiceName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(106, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(508, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cboServiceHeader
            // 
            this.cboServiceHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServiceHeader.FormattingEnabled = true;
            this.cboServiceHeader.Location = new System.Drawing.Point(195, 16);
            this.cboServiceHeader.Name = "cboServiceHeader";
            this.cboServiceHeader.Size = new System.Drawing.Size(121, 21);
            this.cboServiceHeader.TabIndex = 2;
            this.cboServiceHeader.SelectedIndexChanged += new System.EventHandler(this.cboServiceHeader_SelectedIndexChanged);
            // 
            // txtSeviceCode
            // 
            this.txtSeviceCode.Location = new System.Drawing.Point(381, 16);
            this.txtSeviceCode.Name = "txtSeviceCode";
            this.txtSeviceCode.Size = new System.Drawing.Size(69, 21);
            this.txtSeviceCode.TabIndex = 1;
            this.txtSeviceCode.TextChanged += new System.EventHandler(this.txtSeviceCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 19);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "گروه خدمت :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 19);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "کد خدمت :";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(7, 16);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServiceName.Size = new System.Drawing.Size(121, 21);
            this.txtServiceName.TabIndex = 3;
            this.txtServiceName.TextChanged += new System.EventHandler(this.txtSeviceCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 19);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "شرح خدمت :";
            // 
            // txtAssuranceName
            // 
            this.txtAssuranceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssuranceName.BackColor = System.Drawing.Color.Khaki;
            this.txtAssuranceName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAssuranceName.Location = new System.Drawing.Point(3, 16);
            this.txtAssuranceName.Name = "txtAssuranceName";
            this.txtAssuranceName.ReadOnly = true;
            this.txtAssuranceName.Size = new System.Drawing.Size(100, 21);
            this.txtAssuranceName.TabIndex = 27;
            this.txtAssuranceName.TabStop = false;
            this.txtAssuranceName.TextChanged += new System.EventHandler(this.txtSeviceCode_TextChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RowNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.FillWeight = 35F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ردیف";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ServiceCode";
            this.dataGridViewTextBoxColumn2.FillWeight = 65F;
            this.dataGridViewTextBoxColumn2.HeaderText = "کد خدمت";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 102;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ServiceName";
            this.dataGridViewTextBoxColumn3.FillWeight = 150F;
            this.dataGridViewTextBoxColumn3.HeaderText = "نام خدمت";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 233;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AssuranceName";
            this.dataGridViewTextBoxColumn4.FillWeight = 65F;
            this.dataGridViewTextBoxColumn4.HeaderText = "نوع بیمه";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 101;
            // 
            // ServicePickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(616, 394);
            this.Controls.Add(this.txtAssuranceName);
            this.Controls.Add(this.dgvAssuranceServiceList);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServicePickup";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم جستجو";
            this.Load += new System.EventHandler(this.ServicePickup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssuranceServiceList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssuranceServiceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSeviceCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtAssuranceName;
        private System.Windows.Forms.ComboBox cboServiceHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;

    }
}