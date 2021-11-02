namespace DentiNovin
{
    partial class RootCanalForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddRoot = new System.Windows.Forms.Button();
            this.txtRootLenght = new System.Windows.Forms.TextBox();
            this.lblRootLengh = new System.Windows.Forms.Label();
            this.lblRootName = new System.Windows.Forms.Label();
            this.cboRootName = new System.Windows.Forms.ComboBox();
            this.dgvRoots = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoots)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRoot
            // 
            this.btnAddRoot.Location = new System.Drawing.Point(139, 39);
            this.btnAddRoot.Name = "btnAddRoot";
            this.btnAddRoot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddRoot.Size = new System.Drawing.Size(45, 23);
            this.btnAddRoot.TabIndex = 3;
            this.btnAddRoot.Text = "<<+";
            this.btnAddRoot.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddRoot.UseVisualStyleBackColor = true;
            this.btnAddRoot.Click += new System.EventHandler(this.btnAddRoot_Click);
            // 
            // txtRootLenght
            // 
            this.txtRootLenght.Location = new System.Drawing.Point(188, 40);
            this.txtRootLenght.Name = "txtRootLenght";
            this.txtRootLenght.Size = new System.Drawing.Size(60, 21);
            this.txtRootLenght.TabIndex = 2;
            // 
            // lblRootLengh
            // 
            this.lblRootLengh.AutoSize = true;
            this.lblRootLengh.Location = new System.Drawing.Point(248, 43);
            this.lblRootLengh.Name = "lblRootLengh";
            this.lblRootLengh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRootLengh.Size = new System.Drawing.Size(61, 13);
            this.lblRootLengh.TabIndex = 37;
            this.lblRootLengh.Text = "طول ریشه :";
            // 
            // lblRootName
            // 
            this.lblRootName.AutoSize = true;
            this.lblRootName.Location = new System.Drawing.Point(248, 15);
            this.lblRootName.Name = "lblRootName";
            this.lblRootName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRootName.Size = new System.Drawing.Size(55, 13);
            this.lblRootName.TabIndex = 36;
            this.lblRootName.Text = "نام ریشه :";
            // 
            // cboRootName
            // 
            this.cboRootName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRootName.FormattingEnabled = true;
            this.cboRootName.Items.AddRange(new object[] {
            "Single  (S)",
            "Buccal  (B)",
            "Mesial  (M)",
            "Distal   (D)",
            "Palatal (P)",
            "Mesiobuccal (MB)",
            "Distibuccal   (DB)"});
            this.cboRootName.Location = new System.Drawing.Point(139, 12);
            this.cboRootName.Name = "cboRootName";
            this.cboRootName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboRootName.Size = new System.Drawing.Size(109, 21);
            this.cboRootName.TabIndex = 1;
            this.cboRootName.SelectedIndexChanged += new System.EventHandler(this.cboRootName_SelectedIndexChanged);
            // 
            // dgvRoots
            // 
            this.dgvRoots.AllowUserToAddRows = false;
            this.dgvRoots.AllowUserToDeleteRows = false;
            this.dgvRoots.AllowUserToResizeColumns = false;
            this.dgvRoots.AllowUserToResizeRows = false;
            this.dgvRoots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoots.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoots.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoots.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvRoots.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoots.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRoots.Location = new System.Drawing.Point(5, 11);
            this.dgvRoots.MultiSelect = false;
            this.dgvRoots.Name = "dgvRoots";
            this.dgvRoots.ReadOnly = true;
            this.dgvRoots.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvRoots.RowHeadersVisible = false;
            this.dgvRoots.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRoots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoots.Size = new System.Drawing.Size(131, 112);
            this.dgvRoots.TabIndex = 6;
            this.dgvRoots.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRoots_CellMouseDoubleClick);
            this.dgvRoots.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRoots_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Key";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "ریشه";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Value";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "طول";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(83, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(82, 22);
            this.toolStripMenuItem1.Text = "ویرایش";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(82, 22);
            this.toolStripMenuItem2.Text = "حذف";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "ثبت";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(160, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RootCanalForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 134);
            this.ControlBox = false;
            this.Controls.Add(this.dgvRoots);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboRootName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblRootLengh);
            this.Controls.Add(this.btnAddRoot);
            this.Controls.Add(this.txtRootLenght);
            this.Controls.Add(this.lblRootName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RootCanalForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشخصات ریشه";
            this.Load += new System.EventHandler(this.RootCanalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoots)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRoot;
        private System.Windows.Forms.TextBox txtRootLenght;
        private System.Windows.Forms.Label lblRootLengh;
        private System.Windows.Forms.Label lblRootName;
        private System.Windows.Forms.ComboBox cboRootName;
        private System.Windows.Forms.DataGridView dgvRoots;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}