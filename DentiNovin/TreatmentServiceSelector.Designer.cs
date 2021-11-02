namespace DentiNovin
{
    partial class TreatmentServiceSelector
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTreatmentNameSearch = new System.Windows.Forms.TextBox();
            this.cboTreatmentClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTreatment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTreatmentNameSearch);
            this.groupBox1.Controls.Add(this.cboTreatmentClass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(55, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 17);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "نام درمان :";
            // 
            // txtTreatmentNameSearch
            // 
            this.txtTreatmentNameSearch.AcceptsTab = true;
            this.txtTreatmentNameSearch.Location = new System.Drawing.Point(173, 12);
            this.txtTreatmentNameSearch.Name = "txtTreatmentNameSearch";
            this.txtTreatmentNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTreatmentNameSearch.Size = new System.Drawing.Size(136, 21);
            this.txtTreatmentNameSearch.TabIndex = 1;
            this.txtTreatmentNameSearch.TextChanged += new System.EventHandler(this.txtTreatmentNameSearch_TextChanged);
            // 
            // cboTreatmentClass
            // 
            this.cboTreatmentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreatmentClass.FormattingEnabled = true;
            this.cboTreatmentClass.Location = new System.Drawing.Point(10, 12);
            this.cboTreatmentClass.Name = "cboTreatmentClass";
            this.cboTreatmentClass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboTreatmentClass.Size = new System.Drawing.Size(97, 21);
            this.cboTreatmentClass.TabIndex = 2;
            this.cboTreatmentClass.SelectedIndexChanged += new System.EventHandler(this.cboTreatmentClass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "دسته بندی :";
            // 
            // dgvTreatment
            // 
            this.dgvTreatment.AllowUserToAddRows = false;
            this.dgvTreatment.AllowUserToDeleteRows = false;
            this.dgvTreatment.AllowUserToResizeRows = false;
            this.dgvTreatment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.Column5});
            this.dgvTreatment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTreatment.Location = new System.Drawing.Point(0, 34);
            this.dgvTreatment.Name = "dgvTreatment";
            this.dgvTreatment.ReadOnly = true;
            this.dgvTreatment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvTreatment.RowHeadersVisible = false;
            this.dgvTreatment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTreatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreatment.Size = new System.Drawing.Size(431, 338);
            this.dgvTreatment.TabIndex = 3;
            this.dgvTreatment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTreatment_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TreatmentServiceID";
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
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Code";
            this.Column3.FillWeight = 65F;
            this.Column3.HeaderText = "کد درمان";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TreatmentServiceName";
            this.Column4.FillWeight = 200F;
            this.Column4.HeaderText = "نام درمان";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TreatmentClassLatinName";
            this.Column5.HeaderText = "نوع دسته بندی";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // TreatmentServiceSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 372);
            this.Controls.Add(this.dgvTreatment);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreatmentServiceSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب درمان";
            this.Load += new System.EventHandler(this.TreatmentServiceSelector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTreatment;
        private System.Windows.Forms.ComboBox cboTreatmentClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTreatmentNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}