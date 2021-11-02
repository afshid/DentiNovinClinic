namespace DentiNovin
{
    partial class SetupForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("عمومی");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("خدمات درمانی");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("نیروهای مسلح");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("بیمه", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("سیستم پیامک");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("تنظیمات", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxAssuranceDetails1Setup = new System.Windows.Forms.GroupBox();
            this.txtKhVisitPriceSpecialist = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.txtKhVisitPriceGeneral = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtKhOrganPercent = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtKhVisitOrganPercent = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtKhKCoeff = new System.Windows.Forms.TextBox();
            this.txtKhMedCenterCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbxAssuranceDetails2Setup = new System.Windows.Forms.GroupBox();
            this.txtMoVisitPriceSpecialist = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.txtMoVisitPriceGeneral = new DentiNovin.Controls.MNMCurrencyTextBox(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMoOrganPercent = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMoVisitOrganPercent = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMoKCoeff = new System.Windows.Forms.TextBox();
            this.txtMoMedCenterCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbxTreatmentSetup = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbMultiColor = new System.Windows.Forms.RadioButton();
            this.rdbSingleColor = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbShowPersianName = new System.Windows.Forms.RadioButton();
            this.cboToothNumbering = new System.Windows.Forms.ComboBox();
            this.rdbShowLatinName = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbClinic = new System.Windows.Forms.RadioButton();
            this.txtMedCenterName = new System.Windows.Forms.TextBox();
            this.rdbMedCenter = new System.Windows.Forms.RadioButton();
            this.gbxSMSSetup = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSendTime = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemainderSMS = new System.Windows.Forms.TextBox();
            this.chkSendSMS = new System.Windows.Forms.CheckBox();
            this.gbxAssuranceSetup = new System.Windows.Forms.GroupBox();
            this.cboCDDriverName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCopyToCD = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCodingType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtDisketteFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCenterName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxAssuranceDetails1Setup.SuspendLayout();
            this.gbxAssuranceDetails2Setup.SuspendLayout();
            this.gbxTreatmentSetup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbxSMSSetup.SuspendLayout();
            this.gbxAssuranceSetup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbxTreatmentSetup);
            this.splitContainer1.Panel1.Controls.Add(this.gbxAssuranceDetails1Setup);
            this.splitContainer1.Panel1.Controls.Add(this.gbxAssuranceDetails2Setup);
            this.splitContainer1.Panel1.Controls.Add(this.gbxSMSSetup);
            this.splitContainer1.Panel1.Controls.Add(this.gbxAssuranceSetup);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(616, 300);
            this.splitContainer1.SplitterDistance = 419;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbxAssuranceDetails1Setup
            // 
            this.gbxAssuranceDetails1Setup.Controls.Add(this.txtKhVisitPriceSpecialist);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.txtKhVisitPriceGeneral);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label24);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label16);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label23);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label22);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.txtKhOrganPercent);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label15);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.txtKhVisitOrganPercent);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label14);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.txtKhKCoeff);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.txtKhMedCenterCode);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label1);
            this.gbxAssuranceDetails1Setup.Controls.Add(this.label5);
            this.gbxAssuranceDetails1Setup.Location = new System.Drawing.Point(3, 3);
            this.gbxAssuranceDetails1Setup.Name = "gbxAssuranceDetails1Setup";
            this.gbxAssuranceDetails1Setup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxAssuranceDetails1Setup.Size = new System.Drawing.Size(411, 258);
            this.gbxAssuranceDetails1Setup.TabIndex = 28;
            this.gbxAssuranceDetails1Setup.TabStop = false;
            this.gbxAssuranceDetails1Setup.Text = "تنظیمات خدمات درمانی";
            // 
            // txtKhVisitPriceSpecialist
            // 
            this.errorProvider1.SetIconAlignment(this.txtKhVisitPriceSpecialist, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtKhVisitPriceSpecialist.Location = new System.Drawing.Point(192, 103);
            this.txtKhVisitPriceSpecialist.Name = "txtKhVisitPriceSpecialist";
            this.txtKhVisitPriceSpecialist.Size = new System.Drawing.Size(100, 21);
            this.txtKhVisitPriceSpecialist.TabIndex = 30;
            this.txtKhVisitPriceSpecialist.Text = "0";
            this.txtKhVisitPriceSpecialist.Leave += new System.EventHandler(this.txtKhVisitPriceSpecialist_Leave);
            // 
            // txtKhVisitPriceGeneral
            // 
            this.errorProvider1.SetIconAlignment(this.txtKhVisitPriceGeneral, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtKhVisitPriceGeneral.Location = new System.Drawing.Point(192, 76);
            this.txtKhVisitPriceGeneral.Name = "txtKhVisitPriceGeneral";

            this.txtKhVisitPriceGeneral.Size = new System.Drawing.Size(100, 21);
            this.txtKhVisitPriceGeneral.TabIndex = 29;
            this.txtKhVisitPriceGeneral.Text = "0";
            this.txtKhVisitPriceGeneral.Leave += new System.EventHandler(this.txtKhVisitPriceGeneral_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(294, 106);
            this.label24.Name = "label24";
            this.label24.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label24.Size = new System.Drawing.Size(115, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "تعرفه ویزیت(متخصص) :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(294, 79);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "تعرفه ویزیت (عمومی) :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(158, 161);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 24;
            this.label23.Text = "درصد";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(158, 133);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(31, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "درصد";
            // 
            // txtKhOrganPercent
            // 
            this.txtKhOrganPercent.Location = new System.Drawing.Point(192, 157);
            this.txtKhOrganPercent.Name = "txtKhOrganPercent";
            this.txtKhOrganPercent.Size = new System.Drawing.Size(100, 21);
            this.txtKhOrganPercent.TabIndex = 12;
            this.txtKhOrganPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
            this.txtKhOrganPercent.Leave += new System.EventHandler(this.txtKhOrganPercent_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(294, 160);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "سهم بیمه (خدمات) :";
            // 
            // txtKhVisitOrganPercent
            // 
            this.txtKhVisitOrganPercent.Location = new System.Drawing.Point(192, 130);
            this.txtKhVisitOrganPercent.Name = "txtKhVisitOrganPercent";
            this.txtKhVisitOrganPercent.Size = new System.Drawing.Size(100, 21);
            this.txtKhVisitOrganPercent.TabIndex = 10;
            this.txtKhVisitOrganPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
            this.txtKhVisitOrganPercent.Leave += new System.EventHandler(this.txtKhVisitOrganPercent_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(294, 133);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "سهم بیمه (ویزیت) :";
            // 
            // txtKhKCoeff
            // 
            this.txtKhKCoeff.Location = new System.Drawing.Point(192, 48);
            this.txtKhKCoeff.Name = "txtKhKCoeff";
            this.txtKhKCoeff.Size = new System.Drawing.Size(100, 21);
            this.txtKhKCoeff.TabIndex = 0;
            this.txtKhKCoeff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
            this.txtKhKCoeff.Leave += new System.EventHandler(this.txtKhKCoeff_Leave);
            // 
            // txtKhMedCenterCode
            // 
            this.errorProvider1.SetIconAlignment(this.txtKhMedCenterCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtKhMedCenterCode.Location = new System.Drawing.Point(192, 20);
            this.txtKhMedCenterCode.Name = "txtKhMedCenterCode";
            this.txtKhMedCenterCode.Size = new System.Drawing.Size(100, 21);
            this.txtKhMedCenterCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 51);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ضریب بیمه (K) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 23);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "کد مرکز درمانی :";
            // 
            // gbxAssuranceDetails2Setup
            // 
            this.gbxAssuranceDetails2Setup.Controls.Add(this.txtMoVisitPriceSpecialist);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.txtMoVisitPriceGeneral);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label25);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label21);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label20);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label17);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.txtMoOrganPercent);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label18);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.txtMoVisitOrganPercent);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label19);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.txtMoKCoeff);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.txtMoMedCenterCode);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label12);
            this.gbxAssuranceDetails2Setup.Controls.Add(this.label13);
            this.gbxAssuranceDetails2Setup.Location = new System.Drawing.Point(3, 3);
            this.gbxAssuranceDetails2Setup.Name = "gbxAssuranceDetails2Setup";
            this.gbxAssuranceDetails2Setup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxAssuranceDetails2Setup.Size = new System.Drawing.Size(411, 258);
            this.gbxAssuranceDetails2Setup.TabIndex = 29;
            this.gbxAssuranceDetails2Setup.TabStop = false;
            this.gbxAssuranceDetails2Setup.Text = "تنظیمات نیروهای مسلح";
            // 
            // txtMoVisitPriceSpecialist
            // 
            this.txtMoVisitPriceSpecialist.Location = new System.Drawing.Point(192, 103);
            this.txtMoVisitPriceSpecialist.Name = "txtMoVisitPriceSpecialist";

            this.txtMoVisitPriceSpecialist.Size = new System.Drawing.Size(100, 21);
            this.txtMoVisitPriceSpecialist.TabIndex = 28;
            this.txtMoVisitPriceSpecialist.Text = "0";
            this.txtMoVisitPriceSpecialist.Leave += new System.EventHandler(this.txtMoVisitPriceSpecialist_Leave);
            // 
            // txtMoVisitPriceGeneral
            // 
            this.txtMoVisitPriceGeneral.Location = new System.Drawing.Point(192, 76);
            this.txtMoVisitPriceGeneral.Name = "txtMoVisitPriceGeneral";
            this.txtMoVisitPriceGeneral.Size = new System.Drawing.Size(100, 21);
            this.txtMoVisitPriceGeneral.TabIndex = 27;
            this.txtMoVisitPriceGeneral.Text = "0";
            this.txtMoVisitPriceGeneral.Leave += new System.EventHandler(this.txtMoVisitPriceGeneral_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(294, 106);
            this.label25.Name = "label25";
            this.label25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label25.Size = new System.Drawing.Size(115, 13);
            this.label25.TabIndex = 26;
            this.label25.Text = "تعرفه ویزیت(متخصص) :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(158, 161);
            this.label21.Name = "label21";
            this.label21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 23;
            this.label21.Text = "درصد";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(158, 133);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "درصد";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(294, 79);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(115, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "تعرفه ویزیت (عمومی) :";
            // 
            // txtMoOrganPercent
            // 
            this.txtMoOrganPercent.Location = new System.Drawing.Point(192, 157);
            this.txtMoOrganPercent.Name = "txtMoOrganPercent";
            this.txtMoOrganPercent.Size = new System.Drawing.Size(100, 21);
            this.txtMoOrganPercent.TabIndex = 18;
            this.txtMoOrganPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
            this.txtMoOrganPercent.Leave += new System.EventHandler(this.txtMoOrganPercent_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(294, 160);
            this.label18.Name = "label18";
            this.label18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label18.Size = new System.Drawing.Size(104, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "سهم بیمه (خدمات) :";
            // 
            // txtMoVisitOrganPercent
            // 
            this.txtMoVisitOrganPercent.Location = new System.Drawing.Point(192, 130);
            this.txtMoVisitOrganPercent.Name = "txtMoVisitOrganPercent";
            this.txtMoVisitOrganPercent.Size = new System.Drawing.Size(100, 21);
            this.txtMoVisitOrganPercent.TabIndex = 16;
            this.txtMoVisitOrganPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
            this.txtMoVisitOrganPercent.Leave += new System.EventHandler(this.txtMoVisitOrganPercent_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(294, 133);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(99, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "سهم بیمه (ویزیت) :";
            // 
            // txtMoKCoeff
            // 
            this.txtMoKCoeff.Location = new System.Drawing.Point(192, 48);
            this.txtMoKCoeff.Name = "txtMoKCoeff";
            this.txtMoKCoeff.Size = new System.Drawing.Size(100, 21);
            this.txtMoKCoeff.TabIndex = 0;
            this.txtMoKCoeff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_KeyPress);
            this.txtMoKCoeff.Leave += new System.EventHandler(this.txtMoKCoeff_Leave);
            // 
            // txtMoMedCenterCode
            // 
            this.txtMoMedCenterCode.Location = new System.Drawing.Point(192, 20);
            this.txtMoMedCenterCode.Name = "txtMoMedCenterCode";
            this.txtMoMedCenterCode.Size = new System.Drawing.Size(100, 21);
            this.txtMoMedCenterCode.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(294, 51);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "ضریب بیمه (K) :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(294, 23);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "کد مرکز درمانی :";
            // 
            // gbxTreatmentSetup
            // 
            this.gbxTreatmentSetup.Controls.Add(this.groupBox4);
            this.gbxTreatmentSetup.Controls.Add(this.groupBox1);
            this.gbxTreatmentSetup.Controls.Add(this.groupBox3);
            this.gbxTreatmentSetup.Location = new System.Drawing.Point(3, 3);
            this.gbxTreatmentSetup.Name = "gbxTreatmentSetup";
            this.gbxTreatmentSetup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxTreatmentSetup.Size = new System.Drawing.Size(412, 258);
            this.gbxTreatmentSetup.TabIndex = 27;
            this.gbxTreatmentSetup.TabStop = false;
            this.gbxTreatmentSetup.Text = "تنظیمات عمومی";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbMultiColor);
            this.groupBox4.Controls.Add(this.rdbSingleColor);
            this.groupBox4.Location = new System.Drawing.Point(13, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(393, 66);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            // 
            // rdbMultiColor
            // 
            this.rdbMultiColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbMultiColor.Checked = true;
            this.rdbMultiColor.Location = new System.Drawing.Point(221, 39);
            this.rdbMultiColor.Name = "rdbMultiColor";
            this.rdbMultiColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbMultiColor.Size = new System.Drawing.Size(165, 17);
            this.rdbMultiColor.TabIndex = 32;
            this.rdbMultiColor.TabStop = true;
            this.rdbMultiColor.Text = "ترسیم درمانها بصورت چند رنگ";
            this.rdbMultiColor.UseVisualStyleBackColor = true;
            // 
            // rdbSingleColor
            // 
            this.rdbSingleColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSingleColor.Location = new System.Drawing.Point(210, 16);
            this.rdbSingleColor.Name = "rdbSingleColor";
            this.rdbSingleColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbSingleColor.Size = new System.Drawing.Size(176, 17);
            this.rdbSingleColor.TabIndex = 31;
            this.rdbSingleColor.Text = "ترسیم درمانها بصورت تک رنگ";
            this.rdbSingleColor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbShowPersianName);
            this.groupBox1.Controls.Add(this.cboToothNumbering);
            this.groupBox1.Controls.Add(this.rdbShowLatinName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 88);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // rdbShowPersianName
            // 
            this.rdbShowPersianName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbShowPersianName.Checked = true;
            this.rdbShowPersianName.Location = new System.Drawing.Point(221, 37);
            this.rdbShowPersianName.Name = "rdbShowPersianName";
            this.rdbShowPersianName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbShowPersianName.Size = new System.Drawing.Size(165, 17);
            this.rdbShowPersianName.TabIndex = 1;
            this.rdbShowPersianName.TabStop = true;
            this.rdbShowPersianName.Text = "نمایش نام فارسی درمانها";
            this.rdbShowPersianName.UseVisualStyleBackColor = true;
            // 
            // cboToothNumbering
            // 
            this.cboToothNumbering.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToothNumbering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToothNumbering.FormattingEnabled = true;
            this.cboToothNumbering.Location = new System.Drawing.Point(109, 59);
            this.cboToothNumbering.Name = "cboToothNumbering";
            this.cboToothNumbering.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboToothNumbering.Size = new System.Drawing.Size(121, 21);
            this.cboToothNumbering.TabIndex = 2;
            // 
            // rdbShowLatinName
            // 
            this.rdbShowLatinName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbShowLatinName.Location = new System.Drawing.Point(234, 14);
            this.rdbShowLatinName.Name = "rdbShowLatinName";
            this.rdbShowLatinName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbShowLatinName.Size = new System.Drawing.Size(152, 17);
            this.rdbShowLatinName.TabIndex = 0;
            this.rdbShowLatinName.Text = "نمایش نام لاتین درمانها";
            this.rdbShowLatinName.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 62);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "سیستم شماره گذاری دندانها :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCenterName);
            this.groupBox3.Controls.Add(this.rdbClinic);
            this.groupBox3.Controls.Add(this.txtMedCenterName);
            this.groupBox3.Controls.Add(this.rdbMedCenter);
            this.groupBox3.Location = new System.Drawing.Point(13, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 66);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // rdbClinic
            // 
            this.rdbClinic.AutoSize = true;
            this.rdbClinic.Location = new System.Drawing.Point(277, 41);
            this.rdbClinic.Name = "rdbClinic";
            this.rdbClinic.Size = new System.Drawing.Size(109, 17);
            this.rdbClinic.TabIndex = 28;
            this.rdbClinic.Text = "مطب دندانپزشکی";
            this.rdbClinic.UseVisualStyleBackColor = true;
            this.rdbClinic.CheckedChanged += new System.EventHandler(this.rdbClinic_CheckedChanged);
            // 
            // txtMedCenterName
            // 
            this.errorProvider1.SetIconAlignment(this.txtMedCenterName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtMedCenterName.Location = new System.Drawing.Point(30, 17);
            this.txtMedCenterName.Name = "txtMedCenterName";
            this.txtMedCenterName.Size = new System.Drawing.Size(193, 21);
            this.txtMedCenterName.TabIndex = 31;
            this.txtMedCenterName.Leave += new System.EventHandler(this.txtMedCenterName_Leave);
            // 
            // rdbMedCenter
            // 
            this.rdbMedCenter.AutoSize = true;
            this.rdbMedCenter.Location = new System.Drawing.Point(305, 18);
            this.rdbMedCenter.Name = "rdbMedCenter";
            this.rdbMedCenter.Size = new System.Drawing.Size(81, 17);
            this.rdbMedCenter.TabIndex = 27;
            this.rdbMedCenter.Text = "مرکز درمانی";
            this.rdbMedCenter.UseVisualStyleBackColor = true;
            // 
            // gbxSMSSetup
            // 
            this.gbxSMSSetup.Controls.Add(this.label11);
            this.gbxSMSSetup.Controls.Add(this.label9);
            this.gbxSMSSetup.Controls.Add(this.cboSendTime);
            this.gbxSMSSetup.Controls.Add(this.label10);
            this.gbxSMSSetup.Controls.Add(this.txtRemainderSMS);
            this.gbxSMSSetup.Controls.Add(this.chkSendSMS);
            this.gbxSMSSetup.Location = new System.Drawing.Point(4, 2);
            this.gbxSMSSetup.Name = "gbxSMSSetup";
            this.gbxSMSSetup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxSMSSetup.Size = new System.Drawing.Size(412, 259);
            this.gbxSMSSetup.TabIndex = 1;
            this.gbxSMSSetup.TabStop = false;
            this.gbxSMSSetup.Text = "تنظیمات سیستم پیامک";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(349, 64);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "متن پیام :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 44);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "ساعت قبل";
            // 
            // cboSendTime
            // 
            this.cboSendTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSendTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendTime.Enabled = false;
            this.cboSendTime.FormattingEnabled = true;
            this.cboSendTime.Items.AddRange(new object[] {
            "12",
            "24",
            "36",
            "48"});
            this.cboSendTime.Location = new System.Drawing.Point(273, 41);
            this.cboSendTime.Name = "cboSendTime";
            this.cboSendTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboSendTime.Size = new System.Drawing.Size(61, 21);
            this.cboSendTime.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 44);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "زمان ارسال :";
            // 
            // txtRemainderSMS
            // 
            this.txtRemainderSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemainderSMS.Enabled = false;
            this.txtRemainderSMS.Location = new System.Drawing.Point(6, 82);
            this.txtRemainderSMS.Multiline = true;
            this.txtRemainderSMS.Name = "txtRemainderSMS";
            this.txtRemainderSMS.Size = new System.Drawing.Size(392, 58);
            this.txtRemainderSMS.TabIndex = 5;
            // 
            // chkSendSMS
            // 
            this.chkSendSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSendSMS.AutoSize = true;
            this.chkSendSMS.Enabled = false;
            this.chkSendSMS.Location = new System.Drawing.Point(250, 20);
            this.chkSendSMS.Name = "chkSendSMS";
            this.chkSendSMS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSendSMS.Size = new System.Drawing.Size(148, 17);
            this.chkSendSMS.TabIndex = 3;
            this.chkSendSMS.Text = "ارسال پیام کوتاه یادآوری ";
            this.chkSendSMS.UseVisualStyleBackColor = true;
            // 
            // gbxAssuranceSetup
            // 
            this.gbxAssuranceSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAssuranceSetup.Controls.Add(this.cboCDDriverName);
            this.gbxAssuranceSetup.Controls.Add(this.label8);
            this.gbxAssuranceSetup.Controls.Add(this.chkCopyToCD);
            this.gbxAssuranceSetup.Controls.Add(this.label7);
            this.gbxAssuranceSetup.Controls.Add(this.cboCodingType);
            this.gbxAssuranceSetup.Controls.Add(this.label6);
            this.gbxAssuranceSetup.Controls.Add(this.cboFileType);
            this.gbxAssuranceSetup.Controls.Add(this.btnOpenFolder);
            this.gbxAssuranceSetup.Controls.Add(this.txtDisketteFilePath);
            this.gbxAssuranceSetup.Controls.Add(this.label4);
            this.gbxAssuranceSetup.Location = new System.Drawing.Point(3, 3);
            this.gbxAssuranceSetup.Name = "gbxAssuranceSetup";
            this.gbxAssuranceSetup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxAssuranceSetup.Size = new System.Drawing.Size(411, 258);
            this.gbxAssuranceSetup.TabIndex = 23;
            this.gbxAssuranceSetup.TabStop = false;
            this.gbxAssuranceSetup.Text = "تنظیمات بیمه";
            // 
            // cboCDDriverName
            // 
            this.cboCDDriverName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCDDriverName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCDDriverName.FormattingEnabled = true;
            this.cboCDDriverName.Location = new System.Drawing.Point(244, 124);
            this.cboCDDriverName.Name = "cboCDDriverName";
            this.cboCDDriverName.Size = new System.Drawing.Size(61, 21);
            this.cboCDDriverName.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 127);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "درایور CD :";
            // 
            // chkCopyToCD
            // 
            this.chkCopyToCD.AutoSize = true;
            this.chkCopyToCD.Location = new System.Drawing.Point(203, 101);
            this.chkCopyToCD.Name = "chkCopyToCD";
            this.chkCopyToCD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCopyToCD.Size = new System.Drawing.Size(107, 17);
            this.chkCopyToCD.TabIndex = 6;
            this.chkCopyToCD.Text = "ذخیره بر روی CD";
            this.chkCopyToCD.UseVisualStyleBackColor = true;
            this.chkCopyToCD.CheckStateChanged += new System.EventHandler(this.chkCopyToCD_CheckStateChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 50);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "نوع کدینگ :";
            // 
            // cboCodingType
            // 
            this.cboCodingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCodingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodingType.FormattingEnabled = true;
            this.cboCodingType.Items.AddRange(new object[] {
            "ASCII",
            "UTF8"});
            this.cboCodingType.Location = new System.Drawing.Point(245, 47);
            this.cboCodingType.Name = "cboCodingType";
            this.cboCodingType.Size = new System.Drawing.Size(61, 21);
            this.cboCodingType.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 23);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "نوع فایل :";
            // 
            // cboFileType
            // 
            this.cboFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Items.AddRange(new object[] {
            "TEXT",
            "XML"});
            this.cboFileType.Location = new System.Drawing.Point(245, 20);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(61, 21);
            this.cboFileType.TabIndex = 2;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(3, 73);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(38, 23);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "...";
            this.btnOpenFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtDisketteFilePath
            // 
            this.txtDisketteFilePath.BackColor = System.Drawing.Color.Khaki;
            this.txtDisketteFilePath.Location = new System.Drawing.Point(43, 74);
            this.txtDisketteFilePath.Name = "txtDisketteFilePath";
            this.txtDisketteFilePath.ReadOnly = true;
            this.txtDisketteFilePath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDisketteFilePath.Size = new System.Drawing.Size(263, 21);
            this.txtDisketteFilePath.TabIndex = 3;
            this.txtDisketteFilePath.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 77);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "مسیر فایل دیسکت :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(15, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 43);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(5, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(83, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "GeneralNode";
            treeNode1.Text = "عمومی";
            treeNode2.Name = "Assurance1Node";
            treeNode2.Text = "خدمات درمانی";
            treeNode3.Name = "Assurance2Node";
            treeNode3.Text = "نیروهای مسلح";
            treeNode4.Name = "AssuranceNode";
            treeNode4.Text = "بیمه";
            treeNode5.Name = "SMSNode";
            treeNode5.Text = "سیستم پیامک";
            treeNode6.Name = "MainNode";
            treeNode6.Text = "تنظیمات";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.Size = new System.Drawing.Size(193, 300);
            this.treeView1.TabIndex = 0;
            this.treeView1.TabStop = false;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblCenterName
            // 
            this.lblCenterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCenterName.AutoSize = true;
            this.lblCenterName.Location = new System.Drawing.Point(224, 20);
            this.lblCenterName.Name = "lblCenterName";
            this.lblCenterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCenterName.Size = new System.Drawing.Size(51, 13);
            this.lblCenterName.TabIndex = 32;
            this.lblCenterName.Text = "نام مرکز :";
            // 
            // SetupForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 300);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxAssuranceDetails1Setup.ResumeLayout(false);
            this.gbxAssuranceDetails1Setup.PerformLayout();
            this.gbxAssuranceDetails2Setup.ResumeLayout(false);
            this.gbxAssuranceDetails2Setup.PerformLayout();
            this.gbxTreatmentSetup.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbxSMSSetup.ResumeLayout(false);
            this.gbxSMSSetup.PerformLayout();
            this.gbxAssuranceSetup.ResumeLayout(false);
            this.gbxAssuranceSetup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbxTreatmentSetup;
        private System.Windows.Forms.GroupBox gbxAssuranceDetails2Setup;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMoOrganPercent;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMoVisitOrganPercent;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMoKCoeff;
        private System.Windows.Forms.TextBox txtMoMedCenterCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbxAssuranceDetails1Setup;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtKhOrganPercent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtKhVisitOrganPercent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtKhKCoeff;
        private System.Windows.Forms.TextBox txtKhMedCenterCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbxAssuranceSetup;
        private System.Windows.Forms.ComboBox cboCDDriverName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkCopyToCD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCodingType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtDisketteFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbxSMSSetup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboSendTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemainderSMS;
        private System.Windows.Forms.CheckBox chkSendSMS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbClinic;
        private System.Windows.Forms.RadioButton rdbMedCenter;
        private System.Windows.Forms.TextBox txtMedCenterName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbMultiColor;
        private System.Windows.Forms.RadioButton rdbSingleColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbShowPersianName;
        private System.Windows.Forms.ComboBox cboToothNumbering;
        private System.Windows.Forms.RadioButton rdbShowLatinName;
        private System.Windows.Forms.Label label2;
        private Controls.MNMCurrencyTextBox txtKhVisitPriceSpecialist;
        private Controls.MNMCurrencyTextBox txtKhVisitPriceGeneral;
        private Controls.MNMCurrencyTextBox txtMoVisitPriceSpecialist;
        private Controls.MNMCurrencyTextBox txtMoVisitPriceGeneral;
        private System.Windows.Forms.Label lblCenterName;
    }
}