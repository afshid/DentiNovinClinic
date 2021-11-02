namespace DentiNovin
{
    partial class PatientTreatmentDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscription = new System.Windows.Forms.TextBox();
            this.txtTreatmentName = new System.Windows.Forms.TextBox();
            this.txtTreatmentCode = new System.Windows.Forms.TextBox();
            this.txtToothNumber = new System.Windows.Forms.TextBox();
            this.txtToothDirection = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTreatmentStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddRoot = new System.Windows.Forms.Button();
            this.dgvRoots = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRootLenght = new System.Windows.Forms.TextBox();
            this.txtToothSurface = new System.Windows.Forms.TextBox();
            this.lblSurfaceList = new System.Windows.Forms.Label();
            this.cboRootName = new System.Windows.Forms.ComboBox();
            this.lblRootLengh = new System.Windows.Forms.Label();
            this.lblRootName = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSurface = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoots)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurface)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(104, 322);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "تایید";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(26, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 48);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "نام درمان :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 19);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "کد درمان :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 119);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "شماره دندان :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 148);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "جهت دندان :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 19);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "تاریخ درمان :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(562, 193);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "توضیحات :";
            // 
            // txtDiscription
            // 
            this.txtDiscription.Location = new System.Drawing.Point(13, 190);
            this.txtDiscription.Multiline = true;
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscription.Size = new System.Drawing.Size(544, 128);
            this.txtDiscription.TabIndex = 9;
            // 
            // txtTreatmentName
            // 
            this.txtTreatmentName.BackColor = System.Drawing.Color.Khaki;
            this.txtTreatmentName.Location = new System.Drawing.Point(343, 45);
            this.txtTreatmentName.Name = "txtTreatmentName";
            this.txtTreatmentName.ReadOnly = true;
            this.txtTreatmentName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTreatmentName.Size = new System.Drawing.Size(214, 21);
            this.txtTreatmentName.TabIndex = 10;
            this.txtTreatmentName.TabStop = false;
            // 
            // txtTreatmentCode
            // 
            this.txtTreatmentCode.BackColor = System.Drawing.Color.Khaki;
            this.txtTreatmentCode.Location = new System.Drawing.Point(448, 16);
            this.txtTreatmentCode.Name = "txtTreatmentCode";
            this.txtTreatmentCode.ReadOnly = true;
            this.txtTreatmentCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTreatmentCode.Size = new System.Drawing.Size(109, 21);
            this.txtTreatmentCode.TabIndex = 11;
            this.txtTreatmentCode.TabStop = false;
            // 
            // txtToothNumber
            // 
            this.txtToothNumber.BackColor = System.Drawing.Color.Khaki;
            this.txtToothNumber.Location = new System.Drawing.Point(448, 116);
            this.txtToothNumber.Name = "txtToothNumber";
            this.txtToothNumber.ReadOnly = true;
            this.txtToothNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtToothNumber.Size = new System.Drawing.Size(109, 21);
            this.txtToothNumber.TabIndex = 12;
            this.txtToothNumber.TabStop = false;
            // 
            // txtToothDirection
            // 
            this.txtToothDirection.BackColor = System.Drawing.Color.Khaki;
            this.txtToothDirection.Location = new System.Drawing.Point(448, 145);
            this.txtToothDirection.Name = "txtToothDirection";
            this.txtToothDirection.ReadOnly = true;
            this.txtToothDirection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtToothDirection.Size = new System.Drawing.Size(109, 21);
            this.txtToothDirection.TabIndex = 13;
            this.txtToothDirection.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.Khaki;
            this.txtDate.Location = new System.Drawing.Point(154, 16);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDate.Size = new System.Drawing.Size(109, 21);
            this.txtDate.TabIndex = 14;
            this.txtDate.TabStop = false;
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.BackColor = System.Drawing.Color.Khaki;
            this.txtDoctorName.Location = new System.Drawing.Point(154, 45);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.ReadOnly = true;
            this.txtDoctorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDoctorName.Size = new System.Drawing.Size(109, 21);
            this.txtDoctorName.TabIndex = 16;
            this.txtDoctorName.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 48);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "پزشک معالج :";
            // 
            // txtTreatmentStatus
            // 
            this.txtTreatmentStatus.BackColor = System.Drawing.Color.Khaki;
            this.txtTreatmentStatus.Location = new System.Drawing.Point(448, 72);
            this.txtTreatmentStatus.Name = "txtTreatmentStatus";
            this.txtTreatmentStatus.ReadOnly = true;
            this.txtTreatmentStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTreatmentStatus.Size = new System.Drawing.Size(109, 21);
            this.txtTreatmentStatus.TabIndex = 20;
            this.txtTreatmentStatus.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(563, 75);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "وضعیت درمان :";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(21, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 63);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // btnAddRoot
            // 
            this.btnAddRoot.Location = new System.Drawing.Point(154, 99);
            this.btnAddRoot.Name = "btnAddRoot";
            this.btnAddRoot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddRoot.Size = new System.Drawing.Size(45, 23);
            this.btnAddRoot.TabIndex = 30;
            this.btnAddRoot.Text = "<<+";
            this.btnAddRoot.UseVisualStyleBackColor = true;
            this.btnAddRoot.Visible = false;
            this.btnAddRoot.Click += new System.EventHandler(this.btnAddRoot_Click);
            // 
            // dgvRoots
            // 
            this.dgvRoots.AllowUserToAddRows = false;
            this.dgvRoots.AllowUserToDeleteRows = false;
            this.dgvRoots.AllowUserToResizeColumns = false;
            this.dgvRoots.AllowUserToResizeRows = false;
            this.dgvRoots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoots.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRoots.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoots.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRoots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvRoots.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoots.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoots.Location = new System.Drawing.Point(13, 73);
            this.dgvRoots.MultiSelect = false;
            this.dgvRoots.Name = "dgvRoots";
            this.dgvRoots.ReadOnly = true;
            this.dgvRoots.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvRoots.RowHeadersVisible = false;
            this.dgvRoots.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRoots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoots.Size = new System.Drawing.Size(131, 112);
            this.dgvRoots.TabIndex = 29;
            this.dgvRoots.Visible = false;
            this.dgvRoots.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoots_CellDoubleClick);
            this.dgvRoots.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRoots_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.ContextMenuStrip = this.contextMenuStrip1;
            this.Column1.DataPropertyName = "Key";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column1.HeaderText = "ریشه";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // Column2
            // 
            this.Column2.ContextMenuStrip = this.contextMenuStrip1;
            this.Column2.DataPropertyName = "Value";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "طول";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtRootLenght
            // 
            this.txtRootLenght.Location = new System.Drawing.Point(203, 99);
            this.txtRootLenght.Name = "txtRootLenght";
            this.txtRootLenght.Size = new System.Drawing.Size(60, 21);
            this.txtRootLenght.TabIndex = 28;
            this.txtRootLenght.Visible = false;
            // 
            // txtToothSurface
            // 
            this.txtToothSurface.BackColor = System.Drawing.SystemColors.Window;
            this.txtToothSurface.Location = new System.Drawing.Point(154, 73);
            this.txtToothSurface.Name = "txtToothSurface";
            this.txtToothSurface.ReadOnly = true;
            this.txtToothSurface.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtToothSurface.Size = new System.Drawing.Size(109, 21);
            this.txtToothSurface.TabIndex = 26;
            this.txtToothSurface.Visible = false;
            // 
            // lblSurfaceList
            // 
            this.lblSurfaceList.AutoSize = true;
            this.lblSurfaceList.Location = new System.Drawing.Point(264, 77);
            this.lblSurfaceList.Name = "lblSurfaceList";
            this.lblSurfaceList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSurfaceList.Size = new System.Drawing.Size(41, 13);
            this.lblSurfaceList.TabIndex = 25;
            this.lblSurfaceList.Text = "سطح :";
            this.lblSurfaceList.Visible = false;
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
            this.cboRootName.Location = new System.Drawing.Point(154, 73);
            this.cboRootName.Name = "cboRootName";
            this.cboRootName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboRootName.Size = new System.Drawing.Size(109, 21);
            this.cboRootName.TabIndex = 27;
            this.cboRootName.Visible = false;
            this.cboRootName.SelectedIndexChanged += new System.EventHandler(this.cboRootName_SelectedIndexChanged);
            // 
            // lblRootLengh
            // 
            this.lblRootLengh.AutoSize = true;
            this.lblRootLengh.Location = new System.Drawing.Point(263, 104);
            this.lblRootLengh.Name = "lblRootLengh";
            this.lblRootLengh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRootLengh.Size = new System.Drawing.Size(61, 13);
            this.lblRootLengh.TabIndex = 32;
            this.lblRootLengh.Text = "طول ریشه :";
            this.lblRootLengh.Visible = false;
            // 
            // lblRootName
            // 
            this.lblRootName.AutoSize = true;
            this.lblRootName.Location = new System.Drawing.Point(263, 76);
            this.lblRootName.Name = "lblRootName";
            this.lblRootName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRootName.Size = new System.Drawing.Size(55, 13);
            this.lblRootName.TabIndex = 31;
            this.lblRootName.Text = "نام ریشه :";
            this.lblRootName.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Key";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "ریشه";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "طول";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 64;
            // 
            // dgvSurface
            // 
            this.dgvSurface.AllowUserToAddRows = false;
            this.dgvSurface.AllowUserToDeleteRows = false;
            this.dgvSurface.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSurface.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSurface.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSurface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurface.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSurface.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSurface.Location = new System.Drawing.Point(13, 72);
            this.dgvSurface.MultiSelect = false;
            this.dgvSurface.Name = "dgvSurface";
            this.dgvSurface.ReadOnly = true;
            this.dgvSurface.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSurface.RowHeadersVisible = false;
            this.dgvSurface.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSurface.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSurface.Size = new System.Drawing.Size(130, 112);
            this.dgvSurface.TabIndex = 34;
            this.dgvSurface.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Key";
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "کد";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Value";
            this.Column4.FillWeight = 140F;
            this.Column4.HeaderText = "سطح";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.dgvRoots);
            this.groupBox1.Controls.Add(this.btnAddRoot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRootLenght);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtToothSurface);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSurfaceList);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboRootName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblRootLengh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dgvSurface);
            this.groupBox1.Controls.Add(this.txtDiscription);
            this.groupBox1.Controls.Add(this.lblRootName);
            this.groupBox1.Controls.Add(this.txtTreatmentName);
            this.groupBox1.Controls.Add(this.txtTreatmentStatus);
            this.groupBox1.Controls.Add(this.txtTreatmentCode);
            this.groupBox1.Controls.Add(this.txtToothNumber);
            this.groupBox1.Controls.Add(this.txtDoctorName);
            this.groupBox1.Controls.Add(this.txtToothDirection);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 322);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // PatientTreatmentDetails
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 353);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientTreatmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات درمان";
            this.Load += new System.EventHandler(this.PatientTreatmentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoots)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurface)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiscription;
        private System.Windows.Forms.TextBox txtTreatmentName;
        private System.Windows.Forms.TextBox txtTreatmentCode;
        private System.Windows.Forms.TextBox txtToothNumber;
        private System.Windows.Forms.TextBox txtToothDirection;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTreatmentStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddRoot;
        private System.Windows.Forms.DataGridView dgvRoots;
        private System.Windows.Forms.TextBox txtRootLenght;
        private System.Windows.Forms.TextBox txtToothSurface;
        private System.Windows.Forms.Label lblSurfaceList;
        private System.Windows.Forms.ComboBox cboRootName;
        private System.Windows.Forms.Label lblRootLengh;
        private System.Windows.Forms.Label lblRootName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgvSurface;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}