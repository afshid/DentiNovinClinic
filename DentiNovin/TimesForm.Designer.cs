using System;
namespace DentiClinic
{
    partial class TimesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxGroup = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnPatientRegister = new System.Windows.Forms.Button();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.dgvPatientTimesWeek = new System.Windows.Forms.DataGridView();
            this.TimesWeekID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartShortTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.visitTable1 = new DentiClinic.Controls.VisitTable();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTimesWeek)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbxGroup);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Controls.Add(this.btnPatientRegister);
            this.groupBox1.Controls.Add(this.cbxDoctor);
            this.groupBox1.Controls.Add(this.lblDoctor);
            this.groupBox1.Controls.Add(this.txtPatientLastName);
            this.groupBox1.Controls.Add(this.lblLastName);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtFileNumber);
            this.groupBox1.Controls.Add(this.lblFileNumber);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(711, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(249, 181);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات بیمار";
            // 
            // cbxGroup
            // 
            this.cbxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroup.FormattingEnabled = true;
            this.cbxGroup.Location = new System.Drawing.Point(23, 139);
            this.cbxGroup.Name = "cbxGroup";
            this.cbxGroup.Size = new System.Drawing.Size(148, 21);
            this.cbxGroup.TabIndex = 10;
            this.cbxGroup.SelectedIndexChanged += new System.EventHandler(this.cbxGroup_SelectedIndexChanged);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(171, 143);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(70, 13);
            this.lblGroup.TabIndex = 9;
            this.lblGroup.Text = "شیفت کاری :";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPatientRegister
            // 
            this.btnPatientRegister.Location = new System.Drawing.Point(23, 83);
            this.btnPatientRegister.Name = "btnPatientRegister";
            this.btnPatientRegister.Size = new System.Drawing.Size(65, 23);
            this.btnPatientRegister.TabIndex = 8;
            this.btnPatientRegister.Text = "بیمار جدید";
            this.btnPatientRegister.UseVisualStyleBackColor = true;
            this.btnPatientRegister.Click += new System.EventHandler(this.btnPatientRegister_Click);
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(23, 112);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(148, 21);
            this.cbxDoctor.TabIndex = 7;
            this.cbxDoctor.SelectedIndexChanged += new System.EventHandler(this.cbxDoctor_SelectedIndexChanged);
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(171, 115);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(73, 13);
            this.lblDoctor.TabIndex = 6;
            this.lblDoctor.Text = "پزشک معالج :";
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.Location = new System.Drawing.Point(23, 56);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.Size = new System.Drawing.Size(148, 21);
            this.txtPatientLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(172, 59);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(72, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "نام خانوادگی :";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(94, 85);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(77, 21);
            this.txtPatientName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(172, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(27, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "نام :";
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Location = new System.Drawing.Point(114, 29);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(57, 21);
            this.txtFileNumber.TabIndex = 1;
            this.txtFileNumber.TextChanged += new System.EventHandler(this.txtFileNumber_TextChanged);
            this.txtFileNumber.Leave += new System.EventHandler(this.txtFileNumber_Leave);
            // 
            // lblFileNumber
            // 
            this.lblFileNumber.AutoSize = true;
            this.lblFileNumber.Location = new System.Drawing.Point(172, 32);
            this.lblFileNumber.Name = "lblFileNumber";
            this.lblFileNumber.Size = new System.Drawing.Size(74, 13);
            this.lblFileNumber.TabIndex = 0;
            this.lblFileNumber.Text = "شماره پرونده :";
            // 
            // dgvPatientTimesWeek
            // 
            this.dgvPatientTimesWeek.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientTimesWeek.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientTimesWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientTimesWeek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimesWeekID,
            this.RowNumber,
            this.VisitDate,
            this.StartShortTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatientTimesWeek.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatientTimesWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatientTimesWeek.Location = new System.Drawing.Point(711, 230);
            this.dgvPatientTimesWeek.Name = "dgvPatientTimesWeek";
            this.dgvPatientTimesWeek.ReadOnly = true;
            this.dgvPatientTimesWeek.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvPatientTimesWeek.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatientTimesWeek.Size = new System.Drawing.Size(249, 516);
            this.dgvPatientTimesWeek.TabIndex = 2;
            // 
            // TimesWeekID
            // 
            this.TimesWeekID.DataPropertyName = "TimesWeekID";
            this.TimesWeekID.HeaderText = "Column1";
            this.TimesWeekID.Name = "TimesWeekID";
            this.TimesWeekID.ReadOnly = true;
            this.TimesWeekID.Visible = false;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "ردیف";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowNumber.Width = 35;
            // 
            // VisitDate
            // 
            this.VisitDate.DataPropertyName = "VisitDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VisitDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.VisitDate.HeaderText = "تاریخ";
            this.VisitDate.Name = "VisitDate";
            this.VisitDate.ReadOnly = true;
            this.VisitDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StartShortTime
            // 
            this.StartShortTime.DataPropertyName = "StartShortTime";
            this.StartShortTime.HeaderText = "ساعت";
            this.StartShortTime.Name = "StartShortTime";
            this.StartShortTime.ReadOnly = true;
            this.StartShortTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StartShortTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartShortTime.Width = 70;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(711, 187);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 36);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 749);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel1.Controls.Add(this.visitTable1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvPatientTimesWeek, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 749);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // visitTable1
            // 
            this.visitTable1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visitTable1.DaysNumber = 0;
            this.visitTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visitTable1.DSTimesWeek = null;
            this.visitTable1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.visitTable1.IsNull = false;
            this.visitTable1.Location = new System.Drawing.Point(3, 3);
            this.visitTable1.Name = "visitTable1";
            this.visitTable1.oGroup = null;
            this.visitTable1.Registerable = false;
            this.visitTable1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.SetRowSpan(this.visitTable1, 3);
            this.visitTable1.SelectedDateTime = new System.DateTime(2012, 2, 18, 1, 56, 4, 990);
            this.visitTable1.Size = new System.Drawing.Size(702, 743);
            this.visitTable1.TabIndex = 0;
            this.visitTable1.Text = "visitTable1";
            this.visitTable1.MonthChanged += new System.EventHandler(this.visitTable1_MonthChanged);
            this.visitTable1.RegisterClicked += new DentiClinic.BaseClasses.VisitTableButtonClickedEventHandler(this.visitTable1_RegisterClicked);
            this.visitTable1.UnRegisterClicked += new DentiClinic.BaseClasses.VisitTableButtonClickedEventHandler(this.visitTable1_UnRegisterClicked);
            this.visitTable1.ShowDossierClicked += new DentiClinic.BaseClasses.VisitTableButtonClickedEventHandler(this.visitTable1_ShowDossierClicked);
            // 
            // TimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 749);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TimesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimesForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TimesForm_Load);
            this.SizeChanged += new System.EventHandler(this.TimesForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientTimesWeek)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DentiClinic.Controls.VisitTable visitTable1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnPatientRegister;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.DataGridView dgvPatientTimesWeek;
        private System.Windows.Forms.ComboBox cbxGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimesWeekID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartShortTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


    }
}