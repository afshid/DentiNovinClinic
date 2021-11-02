namespace DentiClinic
{
    partial class PatientDossierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientDossierForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.fdpEndDate = new FADatePicker.FADatePicker();
            this.fdpStartDate = new FADatePicker.FADatePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.teeth1 = new DentiClinic.Controls.Teeth();
            this.teeth2 = new DentiClinic.Controls.Teeth();
            this.teeth3 = new DentiClinic.Controls.Teeth();
            this.teeth4 = new DentiClinic.Controls.Teeth();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPatientLastName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSex);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFileNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(554, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(299, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات بیمار  ";
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.Location = new System.Drawing.Point(99, 65);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.Size = new System.Drawing.Size(122, 21);
            this.txtPatientLastName.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "نام خانوادگی :";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(10, 65);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(54, 21);
            this.txtAge.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "سن : ";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(10, 32);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(54, 21);
            this.txtSex.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "جنسیت : ";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(101, 99);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(122, 21);
            this.txtPatientName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "نام :";
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Location = new System.Drawing.Point(167, 32);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(54, 21);
            this.txtFileNumber.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "شماره پرونده : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.fdpEndDate);
            this.groupBox2.Controls.Add(this.fdpStartDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(554, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(300, 99);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "جستجو  ";
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(10, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // fdpEndDate
            // 
            this.fdpEndDate.Location = new System.Drawing.Point(101, 62);
            this.fdpEndDate.Name = "fdpEndDate";
            this.fdpEndDate.Size = new System.Drawing.Size(120, 20);
            this.fdpEndDate.TabIndex = 3;
            this.fdpEndDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // fdpStartDate
            // 
            this.fdpStartDate.Location = new System.Drawing.Point(101, 26);
            this.fdpStartDate.Name = "fdpStartDate";
            this.fdpStartDate.Size = new System.Drawing.Size(120, 20);
            this.fdpStartDate.TabIndex = 2;
            this.fdpStartDate.Theme = FADatePicker.ThemeTypes.WindowsXP;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "تا تاریخ : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "از تاریخ : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.teeth4);
            this.groupBox3.Location = new System.Drawing.Point(4, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(540, 233);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سوابق درمان ";
            // 
            // teeth1
            // 
            this.teeth1.Location = new System.Drawing.Point(0, 0);
            this.teeth1.LSelectedTeeth = ((System.Collections.Generic.List<DentiClinic.Controls.cTooth>)(resources.GetObject("teeth1.LSelectedTeeth")));
            this.teeth1.Mode = DentiClinic.BaseClasses.ToothMode.Adult;
            this.teeth1.MultiSelect = false;
            this.teeth1.Name = "teeth1";
            this.teeth1.SelectMode = DentiClinic.BaseClasses.ToothSelectMode.Separate;
            this.teeth1.Size = new System.Drawing.Size(445, 117);
            this.teeth1.TabIndex = 0;
            // 
            // teeth2
            // 
            this.teeth2.Location = new System.Drawing.Point(0, 0);
            this.teeth2.LSelectedTeeth = ((System.Collections.Generic.List<DentiClinic.Controls.cTooth>)(resources.GetObject("teeth2.LSelectedTeeth")));
            this.teeth2.Mode = DentiClinic.BaseClasses.ToothMode.Adult;
            this.teeth2.MultiSelect = false;
            this.teeth2.Name = "teeth2";
            this.teeth2.SelectMode = DentiClinic.BaseClasses.ToothSelectMode.Separate;
            this.teeth2.Size = new System.Drawing.Size(445, 117);
            this.teeth2.TabIndex = 0;
            // 
            // teeth3
            // 
            this.teeth3.Location = new System.Drawing.Point(0, 0);
            this.teeth3.LSelectedTeeth = ((System.Collections.Generic.List<DentiClinic.Controls.cTooth>)(resources.GetObject("teeth3.LSelectedTeeth")));
            this.teeth3.Mode = DentiClinic.BaseClasses.ToothMode.Adult;
            this.teeth3.MultiSelect = false;
            this.teeth3.Name = "teeth3";
            this.teeth3.SelectMode = DentiClinic.BaseClasses.ToothSelectMode.Separate;
            this.teeth3.Size = new System.Drawing.Size(445, 117);
            this.teeth3.TabIndex = 0;
            // 
            // teeth4
            // 
            this.teeth4.Location = new System.Drawing.Point(49, 32);
            this.teeth4.LSelectedTeeth = ((System.Collections.Generic.List<DentiClinic.Controls.cTooth>)(resources.GetObject("teeth4.LSelectedTeeth")));
            this.teeth4.Mode = DentiClinic.BaseClasses.ToothMode.Adult;
            this.teeth4.MultiSelect = false;
            this.teeth4.Name = "teeth4";
            this.teeth4.SelectMode = DentiClinic.BaseClasses.ToothSelectMode.Separate;
            this.teeth4.Size = new System.Drawing.Size(445, 117);
            this.teeth4.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(4, 249);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(850, 313);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "لیست درمانها";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(828, 286);
            this.dataGridView1.TabIndex = 0;
            // 
            // PatientDossierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 570);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PatientDossierForm";
            this.Text = "PatientDossierForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private FADatePicker.FADatePicker fdpEndDate;
        private FADatePicker.FADatePicker fdpStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private DentiClinic.Controls.Teeth teeth1;
        private DentiClinic.Controls.Teeth teeth2;
        private DentiClinic.Controls.Teeth teeth3;
        private DentiClinic.Controls.Teeth teeth4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}