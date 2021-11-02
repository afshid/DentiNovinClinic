using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.BusinessLogic;
using DentiNovin.Common;
using System.Drawing.Imaging;
using System.IO;
using DentiNovin.Properties;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class PatientForm : MiddleBaseWinForm // BaseForm//
    {
        private bool ImageChange = false;

        private DataSet aDataSet;

        private int _malady;

        private PatientBLL _fPatientBLL;
        public PatientBLL FPatientBLL
        {
            get
            {
                if (_fPatientBLL == null)
                    _fPatientBLL = new PatientBLL();
                return _fPatientBLL;
            }
            set
            {
                _fPatientBLL = value;
            }
        }

        private DoctorBll _fDoctorBLL;
        public DoctorBll FDoctorBLL
        {
            get
            {
                if (_fDoctorBLL == null)
                    _fDoctorBLL = new DoctorBll();
                return _fDoctorBLL;
            }
            set
            {
                _fDoctorBLL = value;
            }
        }
        
        private AssuranceBLL _fAssuranceBLL;
        public AssuranceBLL FAssuranceBLL
        {
            get
            {
                if (_fAssuranceBLL == null)
                    _fAssuranceBLL = new AssuranceBLL();
                return _fAssuranceBLL;
            }
            set
            {
                _fAssuranceBLL = value;
            }
        }

        private Patient _oPatient;
        public Patient oPatient
        {
            get
            {
                if (_oPatient == null)
                    _oPatient = new Patient();
                return _oPatient;
            }
            set { _oPatient = value; }
        }

        public PatientForm()
        {
            InitializeComponent();
        }

        private void chkSurgery_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkSurgery.Checked)
                txtSurgery.Enabled = true;
            else
            {
                txtSurgery.Text = "";
                txtSurgery.Enabled = false;
            }

        }

        private void chkDrug_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkDrug.Checked)
                txtDrug.Enabled = true;
            else
            {
                txtDrug.Enabled = false;
                txtDrug.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFileNumber.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtLastName, "شماره پرونده را وارد کنید");
                txtFileNumber.Focus();
                return;
            }
            if (txtLastName.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtLastName, "نام خانوادگی بیمار را وارد کنید");
                txtLastName.Focus();
                return;
            }
            int _age = 0;
            if (txtAge.Text.Trim() == "" || !int.TryParse(txtAge.Text.Trim(), out _age))
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtAge, "سن بیمار را وارد کنید");
                txtAge.Focus();
                return;
            }
            if (cboDoctor.SelectedIndex == -1)
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(cboDoctor, "پزشک معالج را مشخص کنید");
                cboDoctor.Focus();
                return;
            }

            SetObject();
            try
            {
                SaveInfo();
                MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (TrialException tex)
            {
                MessageBox.Show(tex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                if (aPageMode == PageMode.Mode_new)
                {
                    if (ex.Message == "60080")
                    {
                        MessageBox.Show("شماره پرونده وارد شده تکراریست. لطفآ شماره دیگری انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFileNumber.Focus();
                        txtFileNumber.SelectionStart = 0;
                        txtFileNumber.SelectionLength = txtFileNumber.TextLength;
                        return;
                    }
                    UtilMethods.LogError(ex, "1038");
                    MessageBox.Show("بروز خطا در ثبت اطلاعات بیمار جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (aPageMode == PageMode.Mode_edit)
                {
                    UtilMethods.LogError(ex, "1039");
                    MessageBox.Show("بروز خطا در ویرایش اطلاعات بیمار مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            FillGrid();
            InitialForm(false);
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Dictionary<string, Boolean> DSex = new Dictionary<string, bool>();
            DSex.Add("مرد", true);
            DSex.Add("زن", false);
            cboSex.DataSource = new BindingSource(DSex, null); ;
            cboSex.DisplayMember = "Key";
            cboSex.ValueMember = "Value";
            cboSearch.SelectedIndex = 0;
            try
            {
                GetDoctorList();
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1040");
                MessageBox.Show("بروز خطا در بارگزاری لیست پزشکان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitialForm(false);
            cboSearch.SelectedIndex = 0;
            //FillGrid();
        }

        private void GetDoctorList()
        {
            DataSet aDataSet;//=new DataSet();

            aDataSet = FDoctorBLL.GetDoctorList(true);
            cboDoctor.DataSource = aDataSet.Tables[0];
            cboDoctor.DisplayMember = "LastName";
            cboDoctor.ValueMember = "DoctorID";
        }

        private void SetMaladyCheckBox()
        {
            chkMalady1.Checked = false;
            chkMalady2.Checked = false;
            chkMalady3.Checked = false;
            chkMalady4.Checked = false;
            chkMalady5.Checked = false;
            chkMalady6.Checked = false;
            chkMalady7.Checked = false;
            chkMalady8.Checked = false;

            if (_malady != 0)
            {
                if (_malady % 10 == 8)
                    chkMalady8.Checked = true;
                if (_malady % 100 >= 70)
                    chkMalady7.Checked = true;
                if (_malady % 1000 >= 600)
                    chkMalady6.Checked = true;
                if (_malady % 10000 >= 5000)
                    chkMalady5.Checked = true;
                if (_malady % 100000 >= 40000)
                    chkMalady4.Checked = true;
                if (_malady % 1000000 >= 300000)
                    chkMalady3.Checked = true;
                if (_malady % 10000000 >= 2000000)
                    chkMalady2.Checked = true;
                if (_malady >= 10000000)
                    chkMalady1.Checked = true;
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void chkMalady1_Click(object sender, EventArgs e)
        {
            if (chkMalady1.Checked)
                _malady = _malady + 10000000;
            else
            {
                if (_malady >= 10000000)
                    _malady = _malady - 10000000;
            }
            // //txtDescription.Text = _malady.ToString();
        }

        private void chkMalady2_Click(object sender, EventArgs e)
        {
            if (chkMalady2.Checked)
                _malady = _malady + 2000000;
            else
            {
                if (_malady % 10000000 >= 2000000)
                    _malady = _malady - 2000000;
            }
            //txtDescription.Text = _malady.ToString();
        }

        private void chkMalady3_Click(object sender, EventArgs e)
        {
            if (chkMalady3.Checked)
                _malady = _malady + 300000;
            else
            {
                if (_malady % 1000000 >= 300000)
                    _malady = _malady - 300000;
            }
            //txtDescription.Text = _malady.ToString();

        }

        private void chkMalady4_Click(object sender, EventArgs e)
        {
            if (chkMalady4.Checked)
                _malady = _malady + 40000;
            else
            {
                if (_malady % 100000 >= 40000)
                    _malady = _malady - 40000;
            }
            //txtDescription.Text = _malady.ToString();
        }

        private void chkMalady5_Click(object sender, EventArgs e)
        {
            if (chkMalady5.Checked)
                _malady = _malady + 5000;
            else
            {
                if (_malady % 10000 >= 5000)
                    _malady = _malady - 5000;
            }
            //txtDescription.Text = _malady.ToString();
        }

        private void chkMalady6_Click(object sender, EventArgs e)
        {
            if (chkMalady6.Checked)
                _malady = _malady + 600;
            else
            {
                if (_malady % 1000 >= 600)
                    _malady = _malady - 600;
            }
            //txtDescription.Text = _malady.ToString();
        }

        private void chkMalady7_Click(object sender, EventArgs e)
        {
            if (chkMalady7.Checked)
                _malady = _malady + 70;
            else
            {
                if (_malady % 100 >= 70)
                    _malady = _malady - 70;
            }
            //txtDescription.Text = _malady.ToString();
        }

        private void chkMalady8_Click(object sender, EventArgs e)
        {
            if (chkMalady8.Checked)
                _malady = _malady + 8;
            else
            {
                if (_malady % 10 == 8)
                    _malady = _malady - 8;
            }
            //txtDescription.Text = _malady.ToString();
        }

        public int GetLastFileNumber()
        {
            return FPatientBLL.GetLastFileNumber();
        }

        private byte[] ConvertImageToByteArray(Image imageToConvert, ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public override void SetObject()
        {
            oPatient.Address = txtAddress.Text;
            if (!txtAge.Text.Equals(""))
                oPatient.Age = Convert.ToInt32(txtAge.Text);
            oPatient.Alert = chkAlert.Checked;
            // oPatient.AlertDesc = txtAlert.Text;
            //oPatient.DateOfRegister = Convert.ToDateTime(fdpDateOfRegister.Text);
            oPatient.DateOfRegister = fdpDateOfRegister.Text;
            oPatient.Description = txtDescription.Text;
            oPatient.DoctorID = Convert.ToInt32(((DataRowView)cboDoctor.SelectedItem).Row[0]);
            oPatient.Drug = chkDrug.Checked;
            oPatient.DrugDesc = txtDrug.Text;
            oPatient.FileNumber = Convert.ToInt32(txtFileNumber.Text);
            oPatient.FirstName = txtName.Text;
            oPatient.IdentityNumber = txtIdentityNumber.Text;
            oPatient.NationalCode = txtNationalCode.Text;
            oPatient.LastName = txtLastName.Text;
            oPatient.Malady = _malady;
            oPatient.Portable = txtPortalNumber.Text;
            oPatient.Pregnancy = false;//***********
            oPatient.PregnancyDesc = "";//***************
            oPatient.Profession = txtProfession.Text;
            oPatient.Sex = ((System.Collections.Generic.KeyValuePair<string, Boolean>)cboSex.SelectedItem).Value;
            oPatient.Surgery = chkSurgery.Checked;
            oPatient.SurgeryDesc = txtSurgery.Text;
            oPatient.Telephone = txtPhoneNumber.Text;
            if (ImageChange)
                oPatient.Image = ConvertImageToByteArray(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public override void SaveInfo()
        {
            FPatientBLL.RunType = ((MainForm)this.MdiParent).RunType;
            FPatientBLL.oPatient = this.oPatient;
            if (aPageMode == PageMode.Mode_new)
                SaveObject();
            else
                EditObject();
        }

        public override void SaveObject()
        {
            FPatientBLL.SaveObject();
        }

        public override void EditObject()
        {
            FPatientBLL.EditObject();
        }

        public override void FillGrid()
        {
            int _fileNumber = 0;
            string _patientLastname = string.Empty;

            switch (cboSearch.SelectedIndex)
            {
                case 0:
                    _patientLastname = txtSearch.Text.Trim();
                    break;
                case 1:
                    bool parsed = int.TryParse(txtSearch.Text.Trim(), out _fileNumber);
                    break;
            }
            dgvPatient.AutoGenerateColumns = false;

            try
            {
                aDataSet = FPatientBLL.SelectPatientListByField(_fileNumber, _patientLastname,true);
                dgvPatient.DataSource = aDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1041");
                MessageBox.Show("بروز خطا در بارگزاری لیست بیماران", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void GetObjectList()
        {
            throw new NotImplementedException();
        }

        public override void InitialForm(bool SetValue)
        {
            string FileNumber = string.Empty;
            string LastName = string.Empty;
            string Name = string.Empty;
            string IdentityNumber = string.Empty;
            string NationalCode = string.Empty;
            string Profession = string.Empty;
            string Address = string.Empty;
            string Age = string.Empty;
            string PhoneNumber = string.Empty;
            string PortalNumber = string.Empty;
            bool kSurgery = false;
            string Surgery = string.Empty;
            bool kDrug = false;
            string Drug = string.Empty;
            bool kAlert = false;
            string Alert = string.Empty;
            string Description = string.Empty;
            txtFileNumber.Enabled = true;
            Boolean setEmpty = true;

            if (SetValue)
            {
                setEmpty = false;
                txtFileNumber.Enabled = false;
                FileNumber = oPatient.FileNumber.ToString();
                NationalCode = oPatient.NationalCode;
                LastName = oPatient.LastName;
                Name = oPatient.FirstName;
                IdentityNumber = oPatient.IdentityNumber;
                Profession = oPatient.Profession;
                Address = oPatient.Address;
                Age = oPatient.Age.ToString();
                PhoneNumber = oPatient.Telephone;
                PortalNumber = oPatient.Portable;
                kSurgery = oPatient.Surgery;
                Surgery = oPatient.SurgeryDesc;
                kDrug = oPatient.Drug;
                Drug = oPatient.DrugDesc;
                kAlert = oPatient.Alert;
                //Alert = oPatient.AlertDesc;
                Description = oPatient.Description;
                cboSex.SelectedValue = oPatient.Sex;
                cboDoctor.SelectedValue = oPatient.DoctorID;

                //fdpDateOfRegister.Text = oPatient.DateOfRegister.ToString("d");
                fdpDateOfRegister.Text = oPatient.DateOfRegister;

                _malady = oPatient.Malady;
                if (oPatient.Image != null)
                    pictureBox1.Image = byteArrayToImage(oPatient.Image);
                else
                    pictureBox1.Image = DentiNovin.Properties.Resources.noPerson;

                aPageMode = PageMode.Mode_edit;
                btnSave.Text = "ویرایش";
                btnCancel.Enabled = true;
            }
            else
            {
                _malady = 0;
                cboSex.SelectedIndex = 0;
                if (cboDoctor.Items.Count == 1)
                    cboDoctor.SelectedIndex = 0;
                else
                    cboDoctor.SelectedIndex = -1;
                pictureBox1.Image = global::DentiNovin.Properties.Resources.noPerson;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancel.Enabled = false;
                FileNumber = (GetLastFileNumber() + 1).ToString();
                fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            }

            txtFileNumber.Text = FileNumber;
            txtLastName.Text = LastName;
            txtName.Text = Name;
            txtIdentityNumber.Text = IdentityNumber;
            txtNationalCode.Text = NationalCode;
            txtProfession.Text = Profession;
            txtAddress.Text = Address;
            txtAge.Text = Age;
            txtPhoneNumber.Text = PhoneNumber;
            txtPortalNumber.Text = PortalNumber;
            chkSurgery.Checked = kSurgery;
            txtSurgery.Text = Surgery;
            chkDrug.Checked = kDrug;
            txtDrug.Text = Drug;
            chkAlert.Checked = kAlert;
            // txtAlert.Text = Alert;
            txtDescription.Text = Description;
            SetMaladyCheckBox();

        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dgvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SetSelectedObject((DataRowView)dgvPatient.SelectedRows[0].DataBoundItem);
            try
            {
                FPatientBLL.oPatient = this.oPatient;
                FPatientBLL.GetPatientAssuranceList();
                InitialForm(true);
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1042");
                MessageBox.Show("بروز خطا در دریافت اطلاعات بیمه بیمار مورد نظر ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            oPatient.PatientID = (int)selectedDataRow.Row.ItemArray[1];
            oPatient.Address = selectedDataRow.Row.ItemArray[12].ToString();
            oPatient.Age = (Int16)selectedDataRow.Row.ItemArray[7];
            oPatient.Alert = (bool)selectedDataRow.Row.ItemArray[21];
            //oPatient.AlertDesc = selectedDataRow.Row.ItemArray[23].ToString();
            //oPatient.DateOfRegister = DateTime.Now;
            oPatient.DateOfRegister = DateTime.Now.ToShortDateString();
            if (selectedDataRow.Row.ItemArray[23] != System.DBNull.Value)
                //oPatient.DateOfRegister = Convert.ToDateTime(selectedDataRow.Row.ItemArray[24]);
                oPatient.DateOfRegister = selectedDataRow.Row.ItemArray[23].ToString();
            oPatient.Description = selectedDataRow.Row.ItemArray[20].ToString();
            oPatient.DoctorID = 0;
            if (selectedDataRow.Row.ItemArray[2] != System.DBNull.Value)
                oPatient.DoctorID = (Int16)selectedDataRow.Row.ItemArray[2];
            oPatient.Drug = (bool)selectedDataRow.Row.ItemArray[16];
            oPatient.DrugDesc = selectedDataRow.Row.ItemArray[17].ToString();
            oPatient.FileNumber = (int)selectedDataRow.Row.ItemArray[3];
            oPatient.FirstName = selectedDataRow.Row.ItemArray[4].ToString();
            oPatient.IdentityNumber = selectedDataRow.Row.ItemArray[6].ToString();
            oPatient.NationalCode = selectedDataRow.Row.ItemArray[27].ToString();
            oPatient.LastName = selectedDataRow.Row.ItemArray[5].ToString();
            oPatient.Malady = (int)selectedDataRow.Row.ItemArray[13];
            oPatient.Portable = selectedDataRow.Row.ItemArray[11].ToString();
            oPatient.Pregnancy = (bool)selectedDataRow.Row.ItemArray[18];
            oPatient.PregnancyDesc = selectedDataRow.Row.ItemArray[19].ToString();
            oPatient.Profession = selectedDataRow.Row.ItemArray[9].ToString();
            oPatient.Sex = (bool)selectedDataRow.Row.ItemArray[8];
            oPatient.Surgery = (bool)selectedDataRow.Row.ItemArray[14];
            oPatient.SurgeryDesc = selectedDataRow.Row.ItemArray[15].ToString();
            oPatient.Telephone = selectedDataRow.Row.ItemArray[10].ToString();
            oPatient.Image = null;
            if (selectedDataRow.Row.ItemArray[24] != System.DBNull.Value)
                oPatient.Image = (Byte[])selectedDataRow.Row.ItemArray[24];

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cboSearch_SelectedIndexChanged(null, null);
        }

        private void txtFileNumber_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void cboDoctor_Leave(object sender, EventArgs e)
        {
            if (cboDoctor.SelectedIndex != -1)
                errorProvider1.Clear();
        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, true);
        }

        private void btnAssurance_Click(object sender, EventArgs e)
        {
            PatientAssuranceForm aPatientAssuranceForm = new PatientAssuranceForm();
            aPatientAssuranceForm.oPatient = this.oPatient;
            aPatientAssuranceForm.Owner = this;
            aPatientAssuranceForm.TopMost = true;
            aPatientAssuranceForm.ShowDialog();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count <= 0)
                return;
            dgvPatient_CellDoubleClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("رکورد مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    FPatientBLL.DeleteObject((int)((DataRowView)dgvPatient.SelectedRows[0].DataBoundItem).Row.ItemArray[1]);
                    InitialForm(false);
                    FillGrid();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show("بدلیل وجود نوبت ثبت شده مرتبط با این بیمار امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPatient_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvPatient.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvPatient.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "IMAGE Files|*.jpg;*.jpeg;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap aBitmap = new Bitmap(dlg.FileName);
                pictureBox1.Image = aBitmap;
                ImageChange = true;
            }
        }
    }
}
