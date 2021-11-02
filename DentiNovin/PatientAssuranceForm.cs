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
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class PatientAssuranceForm : BaseForm
    {
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

        private PatientAssurance _oPatientAssurance;
        public PatientAssurance oPatientAssurance
        {
            get
            {
                if (_oPatientAssurance == null)
                    _oPatientAssurance = new PatientAssurance();
                return _oPatientAssurance;
            }
            set { _oPatientAssurance = value; }
        }

        private BindingList<PatientAssurance> _patientAssuranceListShadow;

        private int selectedRowIndex = 0;

        public PatientAssuranceForm()
        {
            InitializeComponent();
        }

        private void PatientAssuranceForm_Load(object sender, EventArgs e)
        {
            GetAssuranceList();
            InitialForm(false);
            dgvPatientAssuranceList.AutoGenerateColumns = false;
            _patientAssuranceListShadow = UtilMethods.CloneList<PatientAssurance>(this.oPatient.PatientAssuranceList);
            dgvPatientAssuranceList.DataSource = _patientAssuranceListShadow;
        }

        private void InitialForm(bool SetValue)
        {
            string AssuranceNumber = string.Empty;
            string DateOfRegister = string.Empty;
            fdpDateOfRegister.SelectedDateTime = DateTime.Now;
            cboAssurance.SelectedIndex = 0;
            cboHandBook.SelectedIndex = 0;
            btnAdd.Text = "افزودن";
            aPageMode = PageMode.Mode_new;
            if (SetValue)
            {
                AssuranceNumber = oPatientAssurance.AssuranceCode;

                cboAssurance.SelectedValue = oPatientAssurance.AssuranceID;
                cboHandBook.SelectedIndex = oPatientAssurance.HandBookID;
                if (oPatientAssurance.HandBookID > 0)
                {
                    fdpDateOfRegister.Text = oPatientAssurance.ValidityDate;
                    fdpDateOfRegister.Enabled = true;
                }
                btnAdd.Text = "ویرایش";
                aPageMode = PageMode.Mode_edit;
            }
            txtAssuranceNumber.Text = AssuranceNumber;
        }

        private void GetAssuranceList()
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FAssuranceBLL.GetAssuranceList(false);
                DataTable aDataTable = new DataTable();
                aDataTable = aDataSet.Tables[0];
                cboAssurance.DataSource = aDataTable;
                cboAssurance.DisplayMember = "AssuranceName";
                cboAssurance.ValueMember = "AssuranceID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1035");
                MessageBox.Show("بروز خطا در بارگزاری لیست بیمه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAssuranceNumber.Text.Trim() == "")
            {
                errorProvider1.SetError(txtAssuranceNumber, "کد بیمه درمانی راوارد کنید");
                txtAssuranceNumber.Focus();
                return;
            }
            setObject();
            if (aPageMode == PageMode.Mode_new)
                _patientAssuranceListShadow.Add((PatientAssurance)oPatientAssurance.Clone());
            else
            {
                _patientAssuranceListShadow.RemoveAt(selectedRowIndex);
                _patientAssuranceListShadow.Add((PatientAssurance)oPatientAssurance.Clone());
            }
            dgvPatientAssuranceList.Refresh();
            InitialForm(false);
        }

        private void setObject()
        {
            oPatientAssurance = null;
            oPatientAssurance.AssuranceCode = txtAssuranceNumber.Text.Trim();
            oPatientAssurance.AssuranceID = Convert.ToInt32(((DataRowView)cboAssurance.SelectedItem).Row[0]);
            oPatientAssurance.AssuranceName = ((DataRowView)cboAssurance.SelectedItem).Row[1].ToString();
            oPatientAssurance.HandBookID = (Int16)cboHandBook.SelectedIndex;
            oPatientAssurance.ValidityDate = fdpDateOfRegister.Text;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.oPatient.PatientAssuranceList.Clear();
            this.oPatient.PatientAssuranceList = _patientAssuranceListShadow;
            this.Dispose();
        }

        private void dgvPatientAssuranceList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvPatientAssuranceList.Rows[e.RowIndex].Selected = true;
                oPatientAssurance = _patientAssuranceListShadow[e.RowIndex];
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("رکورد مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "اخطار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (oPatientAssurance.CountUsed != 0)
                {
                    MessageBox.Show("بدلیل صدور نسخه بیمه با این شماره بیمه امکان حدف وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _patientAssuranceListShadow.Remove(oPatientAssurance);
                dgvPatientAssuranceList.Refresh();
                InitialForm(false);
            }
        }

        private void cboAssurance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboHandBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHandBook.SelectedIndex <= 0)
                fdpDateOfRegister.Enabled = false;
            else
                fdpDateOfRegister.Enabled = true;
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            dgvPatientAssuranceList_CellDoubleClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void dgvPatientAssuranceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            selectedRowIndex = e.RowIndex;
            oPatientAssurance = (PatientAssurance)dgvPatientAssuranceList.Rows[e.RowIndex].DataBoundItem;
            InitialForm(true);
        }

        private void txtAssuranceNumber_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void dgvPatientAssuranceList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            dgvPatientAssuranceList.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }
    }
}
