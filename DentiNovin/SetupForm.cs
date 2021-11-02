using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using System.IO;
using DentiNovin.Properties;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class SetupForm : BaseForm
    {

        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            HideAllGroupBoxes();
            gbxTreatmentSetup.Visible = true;
            cboToothNumbering.DataSource = Enum.GetValues(typeof(NumberingSystem));

            foreach (DriveInfo DI in DriveInfo.GetDrives())
            {
                if (DI.DriveType == DriveType.CDRom)
                    cboCDDriverName.Items.Add(DI.Name);
            }
            InitialForm();
            treeView1.Nodes[0].ExpandAll();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            HideAllGroupBoxes();
            switch (e.Node.Index)
            {
                case 0:
                    if (e.Node.Level == 2)
                    {
                        gbxAssuranceDetails1Setup.Visible = true;
                    }
                    else
                        gbxTreatmentSetup.Visible = true;
                    break;
                case 1:
                    if (e.Node.Level == 2)
                    {
                        gbxAssuranceDetails2Setup.Visible = true;
                    }
                    else
                        gbxAssuranceSetup.Visible = true;
                    break;
                case 2:
                    gbxSMSSetup.Visible = true;
                    break;
                default:
                    gbxSMSSetup.Visible = true;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdbMedCenter.Checked && txtMedCenterName.Text.Trim() == "")
            {
                HideAllGroupBoxes();
                gbxTreatmentSetup.Visible = true;
                errorProvider1.SetError(txtMedCenterName, "نام مرکز درمانی راوارد کنید");
                txtMedCenterName.Focus();
                return;
            }
            Decimal KhKCoeff = 0;
            if (!Decimal.TryParse(txtKhKCoeff.Text.Trim(), out KhKCoeff))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails1Setup.Visible = true;
                errorProvider1.SetError(txtKhKCoeff, "مقدار ضریب بیمه خدمات درمانی راوارد کنید");
                txtKhKCoeff.Focus();
                return;
            }

            Decimal MoKCoeff = 0;
            if (!Decimal.TryParse(txtMoKCoeff.Text.Trim(), out MoKCoeff))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails2Setup.Visible = true;
                errorProvider1.SetError(txtMoKCoeff, "مقدار ضریب بیمه نیروهای مسلح راوارد کنید");
                txtMoKCoeff.Focus();
                return;
            }

            Decimal KhVisitPriceGeneral = 0;
            if (!Decimal.TryParse(txtKhVisitPriceGeneral.Text.Trim(), out KhVisitPriceGeneral))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails1Setup.Visible = true;
                errorProvider1.SetError(txtKhVisitPriceGeneral, "مقدار تعرفه ویزیت بیمه خدمات درمانی راوارد کنید");
                txtKhVisitPriceGeneral.Focus();
                return;
            }

            Decimal MoVisitPriceGeneral = 0;
            if (!Decimal.TryParse(txtMoVisitPriceGeneral.Text.Trim(), out MoVisitPriceGeneral))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails2Setup.Visible = true;
                errorProvider1.SetError(txtMoVisitPriceGeneral, "مقدار تعرفه ویزیت بیمه نیروهای مسلح راوارد کنید");
                txtMoVisitPriceGeneral.Focus();
                return;
            }

            Decimal KhVisitPriceSpecialist = 0;
            if (!Decimal.TryParse(txtKhVisitPriceSpecialist.Text.Trim(), out KhVisitPriceSpecialist))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails1Setup.Visible = true;
                errorProvider1.SetError(txtKhVisitPriceSpecialist, "مقدار تعرفه ویزیت بیمه خدمات درمانی راوارد کنید");
                txtKhVisitPriceSpecialist.Focus();
                return;
            }

            Decimal MoVisitPriceSpecialist = 0;
            if (!Decimal.TryParse(txtMoVisitPriceSpecialist.Text.Trim(), out MoVisitPriceSpecialist))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails2Setup.Visible = true;
                errorProvider1.SetError(txtMoVisitPriceSpecialist, "مقدار تعرفه ویزیت بیمه نیروهای مسلح راوارد کنید");
                txtMoVisitPriceSpecialist.Focus();
                return;
            }



            int KhVisitOrganPercent = 0;
            if (!int.TryParse(txtKhVisitOrganPercent.Text.Trim(), out KhVisitOrganPercent))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails1Setup.Visible = true;
                errorProvider1.SetError(txtKhVisitOrganPercent, "مقدار سهم بیمه(ویزیت) خدمات درمانی راوارد کنید");
                txtKhVisitOrganPercent.Focus();
                return;
            }

            int MoVisitOrganPercent = 0;
            if (!int.TryParse(txtMoVisitOrganPercent.Text.Trim(), out MoVisitOrganPercent))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails2Setup.Visible = true;
                errorProvider1.SetError(txtMoVisitOrganPercent, "مقدار سهم بیمه(ویزیت) نیروهای مسلح راوارد کنید");
                txtMoVisitOrganPercent.Focus();
                return;
            }

            int KhOrganPercent = 0;
            if (!int.TryParse(txtKhOrganPercent.Text.Trim(), out KhOrganPercent))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails1Setup.Visible = true;
                errorProvider1.SetError(txtKhOrganPercent, "مقدار سهم بیمه(خدمات) خدمات درمانی راوارد کنید");
                txtKhOrganPercent.Focus();
                return;
            }

            int MoOrganPercent = 0;
            if (!int.TryParse(txtMoOrganPercent.Text.Trim(), out MoOrganPercent))
            {
                HideAllGroupBoxes();
                gbxAssuranceDetails2Setup.Visible = true;
                errorProvider1.SetError(txtMoOrganPercent, "مقدار سهم بیمه(خدمات) نیروهای مسلح راوارد کنید");
                txtMoOrganPercent.Focus();
                return;
            }


            if (rdbShowLatinName.Checked)
                Settings.Default["ShowPersianName"] = false;
            else
                Settings.Default["ShowPersianName"] = true;

            Settings.Default["NumberingSystem"] = (int)cboToothNumbering.SelectedItem;
            //Settings.Default["SendSMS"] = chkSendSMS.Checked;
            //Settings.Default["PeriodSMS"] = chkSendSMS.Checked;
            //Settings.Default["SMSText"] = chkSendSMS.Checked;

            Settings.Default["KhKCoeff"] = Convert.ToDecimal(txtKhKCoeff.Text);
            Settings.Default["KhMedCenterCode"] = txtKhMedCenterCode.Text;
            Settings.Default["MoKCoeff"] = Convert.ToDecimal(txtMoKCoeff.Text);
            Settings.Default["MoMedCenterCode"] = txtMoMedCenterCode.Text;
            Settings.Default["IsMedCenter"] = !rdbClinic.Checked;
            if (rdbClinic.Checked)
            {
                Settings.Default["KhMedCenterCode"] = string.Empty;
                Settings.Default["MoMedCenterCode"] = string.Empty;
            }
            Settings.Default["MedCenterName"]=txtMedCenterName.Text;
            Settings.Default["FileType"] = (cboFileType.SelectedIndex == 0) ? true : false;
            Settings.Default["CodingType"] = (cboCodingType.SelectedIndex == 0) ? true : false;
            Settings.Default["CopyToCD"] = chkCopyToCD.Checked;
            Settings.Default["DisketteFilePath"] = txtDisketteFilePath.Text;
            Settings.Default["CDDriverName"] = cboCDDriverName.SelectedItem;

            Settings.Default["KhVisitPriceGeneral"] = Convert.ToDecimal(txtKhVisitPriceGeneral.Text);
            Settings.Default["MoVisitPriceGeneral"] = Convert.ToDecimal(txtMoVisitPriceGeneral.Text);
            Settings.Default["KhVisitPriceSpecialist"] = Convert.ToDecimal(txtKhVisitPriceSpecialist.Text);
            Settings.Default["MoVisitPriceSpecialist"] = Convert.ToDecimal(txtMoVisitPriceSpecialist.Text);

            Settings.Default["KhVisitOrganPercent"] = Convert.ToInt32(txtKhVisitOrganPercent.Text);
            Settings.Default["MoVisitOrganPercent"] = Convert.ToInt32(txtMoVisitOrganPercent.Text);

            Settings.Default["KhOrganPercent"] = Convert.ToInt32(txtKhOrganPercent.Text);
            Settings.Default["MoOrganPercent"] = Convert.ToInt32(txtMoOrganPercent.Text);

            Settings.Default["MultiColorDrawing"] = rdbMultiColor.Checked;

            Settings.Default.Save();
            MessageBox.Show("عملیات با موفقیت اجرا شد");
            this.Close();
        }

        private void InitialForm()
        {
            cboSendTime.SelectedIndex = 0;
            cboFileType.SelectedIndex = 0;
            cboCodingType.SelectedIndex = 0;
            if (cboCDDriverName.Items.Count > 0)
                cboCDDriverName.SelectedIndex = 0;
            string KCoeff = string.Empty;
            //fdpActiveDate.SelectedDateTime = DateTime.Now;

            if ((bool)Settings.Default["ShowPersianName"])
               rdbShowPersianName.Checked = true;
            else
               rdbShowLatinName.Checked = true;
            cboToothNumbering.SelectedItem = (NumberingSystem)Settings.Default["NumberingSystem"];
            chkSendSMS.Checked = (bool)Settings.Default["SendSMS"];
            txtKhKCoeff.Text = Settings.Default["KhKCoeff"].ToString();
            txtKhMedCenterCode.Text = Settings.Default["KhMedCenterCode"].ToString();
            txtMoKCoeff.Text = Settings.Default["MoKCoeff"].ToString();
            txtMoMedCenterCode.Text = Settings.Default["MoMedCenterCode"].ToString();
            rdbClinic.Checked = !(bool)Settings.Default["IsMedCenter"];
            rdbMedCenter.Checked = (bool)Settings.Default["IsMedCenter"];
            cboFileType.SelectedIndex = ((bool)Settings.Default["FileType"] == true) ? 0 : 1;
            cboCodingType.SelectedIndex = ((bool)Settings.Default["CodingType"] == true) ? 0 : 1;
            chkCopyToCD.Checked = (bool)Settings.Default["CopyToCD"];
            txtDisketteFilePath.Text = Settings.Default["DisketteFilePath"].ToString();
            cboCDDriverName.SelectedItem = Settings.Default["CDDriverName"].ToString();
            txtMedCenterName.Text = Settings.Default["MedCenterName"].ToString();
            txtKhVisitPriceGeneral.Text = Settings.Default["KhVisitPriceGeneral"].ToString();
            txtMoVisitPriceGeneral.Text = Settings.Default["MoVisitPriceGeneral"].ToString();
            txtKhVisitPriceSpecialist.Text = Settings.Default["KhVisitPriceSpecialist"].ToString();
            txtMoVisitPriceSpecialist.Text = Settings.Default["MoVisitPriceSpecialist"].ToString();
            txtKhVisitOrganPercent.Text = Settings.Default["KhVisitOrganPercent"].ToString();
            txtMoVisitOrganPercent.Text = Settings.Default["MoVisitOrganPercent"].ToString();
            txtKhOrganPercent.Text = Settings.Default["KhOrganPercent"].ToString();
            txtMoOrganPercent.Text = Settings.Default["MoOrganPercent"].ToString();
            if ((bool)Settings.Default["MultiColorDrawing"])
                rdbMultiColor.Checked = true;
            else
                rdbSingleColor.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string folderName = string.Empty;
            FolderBrowserDialog aFolderBrowserDialog = new FolderBrowserDialog();
            aFolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = aFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = aFolderBrowserDialog.SelectedPath;
            }
            txtDisketteFilePath.Text = folderName;
        }

        private void chkCopyToCD_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkCopyToCD.Checked)
                cboCDDriverName.Enabled = true;
            else
                cboCDDriverName.Enabled = false;
            if (cboCDDriverName.Items.Count < 1)
                chkCopyToCD.Checked = false;
        }

        private void HideAllGroupBoxes()
        {
            gbxAssuranceSetup.Visible = false;
            gbxAssuranceDetails1Setup.Visible = false;
            gbxAssuranceDetails2Setup.Visible = false;
            gbxSMSSetup.Visible = false;
            gbxTreatmentSetup.Visible = false;
        }
        
        private void rdbClinic_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["IsMedCenter"] = !rdbClinic.Checked;
            txtKhMedCenterCode.Enabled = !rdbClinic.Checked;
            txtMoMedCenterCode.Enabled = !rdbClinic.Checked;
            txtMedCenterName.Visible = !rdbClinic.Checked;
            lblCenterName.Visible = !rdbClinic.Checked;
        }

        private void txtMedCenterName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtKhKCoeff_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtMoKCoeff_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtKhVisitPriceGeneral_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtMoVisitPriceGeneral_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtMoVisitPriceSpecialist_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtKhVisitPriceSpecialist_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtKhVisitOrganPercent_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtMoVisitOrganPercent_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtKhOrganPercent_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void txtMoOrganPercent_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                    e.Handled = true;
            }
        }


    }
}
