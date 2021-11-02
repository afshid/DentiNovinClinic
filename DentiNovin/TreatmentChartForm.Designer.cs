namespace DentiNovin
{
    partial class TreatmentChartForm
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
            DentiNovin.BusinessLogic.TreatmentBLL treatmentBLL1 = new DentiNovin.BusinessLogic.TreatmentBLL();
            DentiNovin.DataAccess.TreatmentDAL treatmentDAL1 = new DentiNovin.DataAccess.TreatmentDAL();
            DentiNovin.Common.PatientToothType patientToothType1 = new DentiNovin.Common.PatientToothType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreatmentChartForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolBox1 = new Silver.UI.ToolBox();
            this.pbPatientPicture = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTreatmentStatus = new System.Windows.Forms.ComboBox();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cpCompleted = new DentiNovin.Controls.MNMColorPicker();
            this.cpPlanned = new DentiNovin.Controls.MNMColorPicker();
            this.cpConditions = new DentiNovin.Controls.MNMColorPicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowCompleted = new System.Windows.Forms.CheckBox();
            this.chkShowPlanned = new System.Windows.Forms.CheckBox();
            this.chkShowConditions = new System.Windows.Forms.CheckBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.toothChart1 = new DentiNovin.Controls.ToothChart();
            this.lblKinOfList = new System.Windows.Forms.Label();
            this.dgvPatientTreatment = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDecline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatientPicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTreatment)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(981, 642);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pbPatientPicture);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.cpCompleted);
            this.splitContainer2.Panel2.Controls.Add(this.cpPlanned);
            this.splitContainer2.Panel2.Controls.Add(this.cpConditions);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(143, 642);
            this.splitContainer2.SplitterDistance = 240;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            // 
            // toolBox1
            // 
            this.toolBox1.AllowDrop = true;
            this.toolBox1.AllowSwappingByDragDrop = true;
            this.toolBox1.BackColor = System.Drawing.SystemColors.Control;
            this.toolBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBox1.InitialScrollDelay = 500;
            this.toolBox1.ItemBackgroundColor = System.Drawing.Color.Empty;
            this.toolBox1.ItemBorderColor = System.Drawing.Color.Gray;
            this.toolBox1.ItemHeight = 20;
            this.toolBox1.ItemHoverColor = System.Drawing.SystemColors.Control;
            this.toolBox1.ItemHoverTextColor = System.Drawing.SystemColors.ControlText;
            this.toolBox1.ItemNormalColor = System.Drawing.SystemColors.Control;
            this.toolBox1.ItemNormalTextColor = System.Drawing.SystemColors.ControlText;
            this.toolBox1.ItemSelectedColor = System.Drawing.Color.White;
            this.toolBox1.ItemSelectedTextColor = System.Drawing.SystemColors.ControlText;
            this.toolBox1.ItemSpacing = 2;
            this.toolBox1.LargeItemSize = new System.Drawing.Size(64, 64);
            this.toolBox1.LayoutDelay = 10;
            this.toolBox1.Location = new System.Drawing.Point(0, 0);
            this.toolBox1.Name = "toolBox1";
            this.toolBox1.ScrollDelay = 60;
            this.toolBox1.SelectAllTextWhileRenaming = true;
            this.toolBox1.SelectedTabIndex = -1;
            this.toolBox1.ShowOnlyOneItemPerRow = false;
            this.toolBox1.Size = new System.Drawing.Size(143, 240);
            this.toolBox1.SmallItemSize = new System.Drawing.Size(30, 30);
            this.toolBox1.TabHeight = 18;
            this.toolBox1.TabHoverTextColor = System.Drawing.SystemColors.ControlText;
            this.toolBox1.TabIndex = 0;
            this.toolBox1.TabNormalTextColor = System.Drawing.SystemColors.ControlText;
            this.toolBox1.TabSelectedTextColor = System.Drawing.SystemColors.ControlText;
            this.toolBox1.TabSpacing = 1;
            this.toolBox1.UseItemColorInRename = false;
            this.toolBox1.TabSelectionChanged += new Silver.UI.TabSelectionChangedHandler(this.toolBox1_TabSelectionChanged);
            this.toolBox1.TabMouseUp += new Silver.UI.TabMouseEventHandler(this.toolBox1_TabMouseUp);
            this.toolBox1.ItemMouseUp += new Silver.UI.ItemMouseEventHandler(this.toolBox1_ItemMouseUp);
            this.toolBox1.RenameFinished += new Silver.UI.RenameFinishedHandler(this.toolBox1_RenameFinished);
            // 
            // pbPatientPicture
            // 
            this.pbPatientPicture.Image = global::DentiNovin.Properties.Resources.noPerson;
            this.pbPatientPicture.Location = new System.Drawing.Point(14, 238);
            this.pbPatientPicture.Name = "pbPatientPicture";
            this.pbPatientPicture.Size = new System.Drawing.Size(114, 111);
            this.pbPatientPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPatientPicture.TabIndex = 11;
            this.pbPatientPicture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTreatmentStatus);
            this.groupBox2.Controls.Add(this.cboDoctor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(129, 103);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "وضعیت درمان ";
            // 
            // cboTreatmentStatus
            // 
            this.cboTreatmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreatmentStatus.FormattingEnabled = true;
            this.cboTreatmentStatus.Items.AddRange(new object[] {
            "برنامه ریزی",
            "تکمیل شده"});
            this.cboTreatmentStatus.Location = new System.Drawing.Point(8, 21);
            this.cboTreatmentStatus.Name = "cboTreatmentStatus";
            this.cboTreatmentStatus.Size = new System.Drawing.Size(115, 21);
            this.cboTreatmentStatus.TabIndex = 6;
            this.cboTreatmentStatus.SelectedIndexChanged += new System.EventHandler(this.cboTreatmentStatus_SelectedIndexChanged);
            // 
            // cboDoctor
            // 
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(7, 66);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(115, 21);
            this.cboDoctor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "پرشک معالج :";
            // 
            // cpCompleted
            // 
            this.cpCompleted.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cpCompleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cpCompleted.FormattingEnabled = true;
            this.cpCompleted.Location = new System.Drawing.Point(46, 187);
            this.cpCompleted.Name = "cpCompleted";
            this.cpCompleted.SelectedItem = null;
            this.cpCompleted.SelectedValue = System.Drawing.Color.White;
            this.cpCompleted.Size = new System.Drawing.Size(85, 22);
            this.cpCompleted.TabIndex = 8;
            this.cpCompleted.SelectedIndexChanged += new System.EventHandler(this.cpCompleted_SelectedIndexChanged);
            // 
            // cpPlanned
            // 
            this.cpPlanned.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cpPlanned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cpPlanned.FormattingEnabled = true;
            this.cpPlanned.Location = new System.Drawing.Point(46, 160);
            this.cpPlanned.Name = "cpPlanned";
            this.cpPlanned.SelectedItem = null;
            this.cpPlanned.SelectedValue = System.Drawing.Color.White;
            this.cpPlanned.Size = new System.Drawing.Size(85, 22);
            this.cpPlanned.TabIndex = 7;
            this.cpPlanned.SelectedIndexChanged += new System.EventHandler(this.cpPlanned_SelectedIndexChanged);
            // 
            // cpConditions
            // 
            this.cpConditions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cpConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cpConditions.FormattingEnabled = true;
            this.cpConditions.Location = new System.Drawing.Point(46, 133);
            this.cpConditions.Name = "cpConditions";
            this.cpConditions.SelectedItem = null;
            this.cpConditions.SelectedValue = System.Drawing.Color.White;
            this.cpConditions.Size = new System.Drawing.Size(85, 22);
            this.cpConditions.TabIndex = 6;
            this.cpConditions.SelectedIndexChanged += new System.EventHandler(this.cpConditions_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShowCompleted);
            this.groupBox1.Controls.Add(this.chkShowPlanned);
            this.groupBox1.Controls.Add(this.chkShowConditions);
            this.groupBox1.Location = new System.Drawing.Point(5, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(130, 102);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حالت نمایش";
            // 
            // chkShowCompleted
            // 
            this.chkShowCompleted.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowCompleted.Checked = true;
            this.chkShowCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCompleted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkShowCompleted.Location = new System.Drawing.Point(5, 74);
            this.chkShowCompleted.Name = "chkShowCompleted";
            this.chkShowCompleted.Size = new System.Drawing.Size(33, 23);
            this.chkShowCompleted.TabIndex = 8;
            this.chkShowCompleted.Text = "Cm";
            this.chkShowCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkShowCompleted, "تکمیل شده");
            this.chkShowCompleted.UseVisualStyleBackColor = true;
            this.chkShowCompleted.CheckedChanged += new System.EventHandler(this.chkShowCompleted_CheckedChanged);
            // 
            // chkShowPlanned
            // 
            this.chkShowPlanned.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowPlanned.Checked = true;
            this.chkShowPlanned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowPlanned.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkShowPlanned.Location = new System.Drawing.Point(5, 47);
            this.chkShowPlanned.Name = "chkShowPlanned";
            this.chkShowPlanned.Size = new System.Drawing.Size(33, 23);
            this.chkShowPlanned.TabIndex = 7;
            this.chkShowPlanned.Text = "Pl";
            this.chkShowPlanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkShowPlanned, "برنامه ریزی");
            this.chkShowPlanned.UseVisualStyleBackColor = true;
            this.chkShowPlanned.CheckedChanged += new System.EventHandler(this.chkShowPlanned_CheckedChanged);
            // 
            // chkShowConditions
            // 
            this.chkShowConditions.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowConditions.Checked = true;
            this.chkShowConditions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowConditions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.chkShowConditions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShowConditions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkShowConditions.Location = new System.Drawing.Point(5, 20);
            this.chkShowConditions.Name = "chkShowConditions";
            this.chkShowConditions.Size = new System.Drawing.Size(33, 23);
            this.chkShowConditions.TabIndex = 6;
            this.chkShowConditions.Text = "Cn";
            this.chkShowConditions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkShowConditions, "شرایط موجود");
            this.chkShowConditions.UseVisualStyleBackColor = true;
            this.chkShowConditions.CheckedChanged += new System.EventHandler(this.chkShowConditions_CheckedChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.toothChart1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lblKinOfList);
            this.splitContainer3.Panel2.Controls.Add(this.dgvPatientTreatment);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer3.Size = new System.Drawing.Size(837, 642);
            this.splitContainer3.SplitterDistance = 365;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // toothChart1
            // 
            this.toothChart1.AllowContinue = false;
            this.toothChart1.CompletedColor = System.Drawing.Color.Empty;
            this.toothChart1.ConditionsColor = System.Drawing.Color.Empty;
            this.toothChart1.CurrentAppointment = null;
            this.toothChart1.CurrentPatientTreatment = null;
            this.toothChart1.CurrentTreatment = null;
            treatmentDAL1.OAssuranceService = null;
            treatmentDAL1.oTreatment = null;
            treatmentBLL1.BTreatmentDAL = treatmentDAL1;
            treatmentBLL1.OAssuranceService = null;
            treatmentBLL1.oTreatment = null;
            this.toothChart1.FTreatmentBLL = treatmentBLL1;
            this.toothChart1.Location = new System.Drawing.Point(0, 0);
            this.toothChart1.Name = "toothChart1";
            patientToothType1.PatientID = 0;
            patientToothType1.PatientToothTypeID = 0;
            patientToothType1.ToothCode = 0;
            patientToothType1.ToothType = DentiNovin.Common.ToothType.Permanent;
            this.toothChart1.OPatientToothType = patientToothType1;
            this.toothChart1.PatientTreatmentList = ((System.Collections.ArrayList)(resources.GetObject("toothChart1.PatientTreatmentList")));
            this.toothChart1.PermanetToothNumberList = null;
            this.toothChart1.PlannedColor = System.Drawing.Color.Empty;
            this.toothChart1.PrimaryToothNumberList = null;
            this.toothChart1.Size = new System.Drawing.Size(835, 365);
            this.toothChart1.TabIndex = 0;
            this.toothChart1.TActionMode = DentiNovin.Common.ActionMode.None;
            this.toothChart1.ThisPatientToothTypeList = null;
            this.toothChart1.TreatmentStatusSelected = DentiNovin.Common.TreatmentStatus.None;
            this.toothChart1.TreatmentCompleted += new System.EventHandler(this.toothChart1_TreatmentCompleted);
            this.toothChart1.ShowTreatmentsForAllClicked += new System.EventHandler(this.toothChart1_ShowTreatmentsForAllClicked);
            this.toothChart1.ShowTreatmentsForThisClicked += new DentiNovin.BaseClasses.ToothSelectedEventHandlet(this.toothChart1_ShowTreatmentsForThisClicked);
            this.toothChart1.ToothClicked += new System.EventHandler(this.toothChart1_ToothClicked);
            this.toothChart1.ToothTypeChange += new DentiNovin.BaseClasses.ToothTypeChangeEventHandler(this.toothChart1_ToothTypeChange);
            // 
            // lblKinOfList
            // 
            this.lblKinOfList.ForeColor = System.Drawing.Color.Red;
            this.lblKinOfList.Location = new System.Drawing.Point(79, 13);
            this.lblKinOfList.Name = "lblKinOfList";
            this.lblKinOfList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblKinOfList.Size = new System.Drawing.Size(756, 13);
            this.lblKinOfList.TabIndex = 1;
            this.lblKinOfList.Text = "label2";
            // 
            // dgvPatientTreatment
            // 
            this.dgvPatientTreatment.AllowUserToAddRows = false;
            this.dgvPatientTreatment.AllowUserToDeleteRows = false;
            this.dgvPatientTreatment.AllowUserToResizeColumns = false;
            this.dgvPatientTreatment.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPatientTreatment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPatientTreatment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientTreatment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatientTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPatientTreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column11,
            this.Column2,
            this.TreatmentName,
            this.Column4,
            this.Column8,
            this.Column5,
            this.Column3,
            this.Column6,
            this.Column10,
            this.Column7});
            this.dgvPatientTreatment.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPatientTreatment.Location = new System.Drawing.Point(3, 39);
            this.dgvPatientTreatment.MultiSelect = false;
            this.dgvPatientTreatment.Name = "dgvPatientTreatment";
            this.dgvPatientTreatment.ReadOnly = true;
            this.dgvPatientTreatment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientTreatment.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPatientTreatment.RowHeadersWidth = 50;
            this.dgvPatientTreatment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dgvPatientTreatment.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPatientTreatment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPatientTreatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientTreatment.Size = new System.Drawing.Size(832, 252);
            this.dgvPatientTreatment.TabIndex = 0;
            this.dgvPatientTreatment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientTreatment_CellDoubleClick);
            this.dgvPatientTreatment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPatientTreatment_CellFormatting);
            this.dgvPatientTreatment.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatientTreatment_CellMouseUp);
            this.dgvPatientTreatment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPatientTreatment_KeyDown);
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "[Patient-TreatmentID";
            this.Column9.HeaderText = "شماره رکورد";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 6.631022F;
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "VisitDate";
            this.Column11.FillWeight = 12.43317F;
            this.Column11.HeaderText = "تاریخ ";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Code";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.FillWeight = 15F;
            this.Column2.HeaderText = "کد درمان";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Visible = false;
            // 
            // TreatmentName
            // 
            this.TreatmentName.DataPropertyName = "TreatmentServiceName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TreatmentName.DefaultCellStyle = dataGridViewCellStyle5;
            this.TreatmentName.FillWeight = 41.44389F;
            this.TreatmentName.HeaderText = "نام درمان";
            this.TreatmentName.MaxInputLength = 50;
            this.TreatmentName.Name = "TreatmentName";
            this.TreatmentName.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ToothNumberConverted";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.FillWeight = 6.631022F;
            this.Column4.HeaderText = "دندان";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "FaToothDirection";
            this.Column8.FillWeight = 15F;
            this.Column8.HeaderText = "جهت";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SurfaceCodeList";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.FillWeight = 12.43317F;
            this.Column5.HeaderText = "سطح";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Price";
            this.Column3.FillWeight = 12.43317F;
            this.Column3.HeaderText = "هزینه";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "StatusConverted";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column6.FillWeight = 12.43317F;
            this.Column6.HeaderText = "وضعیت";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "DoctorFullName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column10.FillWeight = 12.77697F;
            this.Column10.HeaderText = "معالج";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "RegisterDate";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "D";
            dataGridViewCellStyle10.NullValue = null;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column7.FillWeight = 12.43317F;
            this.Column7.HeaderText = "تاریخ ایجاد";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDecline,
            this.toolStripSeparator1,
            this.tsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(91, 54);
            this.contextMenuStrip1.Text = "لبالبالبالبا";
            // 
            // tsmiDecline
            // 
            this.tsmiDecline.Name = "tsmiDecline";
            this.tsmiDecline.Size = new System.Drawing.Size(90, 22);
            this.tsmiDecline.Text = "رد درمان";
            this.tsmiDecline.Click += new System.EventHandler(this.tsmiDecline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(87, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(90, 22);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(13, -6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(55, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DentiNovin.Properties.Resources.print_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(9, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 32);
            this.button1.TabIndex = 22;
            this.toolTip1.SetToolTip(this.button1, "نسخه چاپی");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // TreatmentChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 642);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TreatmentChartForm";
            this.Text = "فرم ثبت درمان";
            this.Load += new System.EventHandler(this.TreatmentChartForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPatientPicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTreatment)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Silver.UI.ToolBox toolBox1;
        private DentiNovin.Controls.MNMColorPicker cpCompleted;
        private DentiNovin.Controls.MNMColorPicker cpPlanned;
        private DentiNovin.Controls.MNMColorPicker cpConditions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DentiNovin.Controls.ToothChart toothChart1;
        private System.Windows.Forms.DataGridView dgvPatientTreatment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowCompleted;
        private System.Windows.Forms.CheckBox chkShowPlanned;
        private System.Windows.Forms.CheckBox chkShowConditions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDecline;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbPatientPicture;
        //private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ComboBox cboTreatmentStatus;
        private System.Windows.Forms.Label lblKinOfList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
    }
}