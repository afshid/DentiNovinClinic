using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DentiNovin.Common;
using DentiNovin.BusinessLogic;
using DentiNovin.Properties;
using DentiNovin.BaseClasses;

namespace DentiNovin
{
    public partial class PatientTreatmentDetails : MiddleBaseWinForm
    {

        private PatientTreatmentBLL _fPatientTreatmentBLL;
        public PatientTreatmentBLL FPatientTreatmentBLL
        {
            get
            {
                if (_fPatientTreatmentBLL == null)
                    _fPatientTreatmentBLL = new PatientTreatmentBLL();
                return _fPatientTreatmentBLL;
            }
            set
            {
                _fPatientTreatmentBLL = value;
            }
        }

        private RootCanalBLL _fRootCanalBLL;
        public RootCanalBLL FRootCanalBLL
        {
            get
            {
                if (_fRootCanalBLL == null)
                    _fRootCanalBLL = new RootCanalBLL();
                return _fRootCanalBLL;
            }
            set
            {
                _fRootCanalBLL = value;
            }
        }

        decimal _rootLenght = 0;

        Dictionary<string, string> _validRoots = new Dictionary<string, string> { { "Single", "S" }, { "Buccal", "B" },
        { "Mesial", "M" }, { "Distal", "D" }, { "Palatal", "P" }, { "Mesiobuccal", "MB" }, { "Distibuccal", "DB" } };

        Dictionary<string, string> _validSurface = new Dictionary<string, string> { { "M","Mesial"  }, {  "O","Occlusal" },
        {"I","Incisal"  }, {"D", "Distal"  }, {"L" , "Linqual"}, { "B","Buccal"  }, { "F","Facial"  }, {  "5","Class5"} };

        //Dictionary<string, string> _validSurface = new Dictionary<string, string> { { "Mesial", "M" }, { "Occlusal", "O" },
        //{ "Incisal", "I" }, { "Distal", "D" }, { "Linqual", "L" }, { "Buccal", "B" }, { "Facial", "F" }, { "Class5", "5" } };

        Dictionary<string, decimal> _selectRoots = new Dictionary<string, decimal>();
        Dictionary<string, string> _selectSurface = new Dictionary<string, string>();

        private List<Roots> _lRoots;
        public List<Roots> LRoots
        {
            get
            {
                if (_lRoots == null)
                    _lRoots = new List<Roots>();
                return _lRoots;
            }
            set { _lRoots = value; }
        }

        private PatientTreatment _currentPatientTreatment;
        public PatientTreatment CurrentPatientTreatment
        {
            get { return _currentPatientTreatment; }
            set { _currentPatientTreatment = value; }
        }


        public string TratmentStatus { get; set; }

        public string ToothDirectionConverted { get; set; }

        public string DoctorName { get; set; }

        public string VisitDate { get; set; }

        public string SurfaceList { get; set; }

        public string ToothNumberConverted { get; set; }

        private bool isRootTreatment;

        public event EventHandler DetailsChanged;

        public PatientTreatmentDetails()
        {
            InitializeComponent();
        }

        private void PatientTreatmentDetails_Load(object sender, EventArgs e)
        {
            if (CurrentPatientTreatment.Treatment.TreatmentArea == 3)
                isRootTreatment = true;
            else
                isRootTreatment = false;
            InitialForm(true);
            cboRootName.DataSource = new BindingSource(_validRoots, null);
            cboRootName.DisplayMember = "Key";
            cboRootName.ValueMember = "Value";
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            _rootLenght = 0;
            decimal.TryParse(txtRootLenght.Text.Trim(), out _rootLenght);
            if (!_selectRoots.ContainsKey(((System.Collections.Generic.KeyValuePair<string, string>)(cboRootName.SelectedItem)).Value))
                _selectRoots.Add(cboRootName.SelectedValue.ToString(), _rootLenght);
            else
                _selectRoots[cboRootName.SelectedValue.ToString()] = _rootLenght;
            dgvRoots.DataSource = new BindingSource(_selectRoots, null);
            btnAddRoot.Enabled = false;
            txtRootLenght.Text = "";
        }

        private void cboRootName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectRoots.ContainsKey(((System.Collections.Generic.KeyValuePair<string, string>)(cboRootName.SelectedItem)).Value))
                btnAddRoot.Enabled = false;
            else
                if (_selectRoots.Count < 5)
                    btnAddRoot.Enabled = true;
            txtRootLenght.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SelectRootObject()
        {
            _selectRoots.Clear();
            FRootCanalBLL.LRoots = this.LRoots;
            FRootCanalBLL.SelectObject(this.CurrentPatientTreatment.PatientTreatmentID);
            foreach (Roots rts in this.LRoots)
            {
                if (!_selectRoots.ContainsKey(rts.RootName.Trim()))
                    _selectRoots.Add(rts.RootName.Trim(), rts.RootLenght);
            }
            if (_selectRoots.Count > 4)
                btnAddRoot.Enabled = false;
        }

        private void SelectSurfaceObject()
        {
            _selectSurface.Clear();
            for (int i = 0; i < SurfaceList.Length; i++)
            {
                if (!_selectSurface.ContainsKey(SurfaceList[i].ToString()))
                    _selectSurface.Add(SurfaceList[i].ToString(), _validSurface[SurfaceList[i].ToString()]);
            }
        }

        private void SetObject()
        {
            CurrentPatientTreatment.Description = txtDate.Text;
        }

        public void InitialForm(bool SetValue)
        {
            if (!SetValue)
                return;
            txtTreatmentCode.Text = CurrentPatientTreatment.Treatment.Code;
            if ((bool)Settings.Default["ShowPersianName"])
                txtTreatmentName.Text = CurrentPatientTreatment.Treatment.PersianName;
            else
                txtTreatmentName.Text = CurrentPatientTreatment.Treatment.LatinName;
            txtTreatmentStatus.Text = TratmentStatus;
            txtToothNumber.Text = ToothNumberConverted;
            txtToothDirection.Text = ToothDirectionConverted;
            txtDate.Text = VisitDate;
            txtDoctorName.Text = DoctorName;
            txtDiscription.Text = CurrentPatientTreatment.Description;
            switch (CurrentPatientTreatment.Treatment.TreatmentArea)
            {
                case 3:
                    {
                        dgvRoots.Visible = true;
                        lblRootName.Visible = true;
                        cboRootName.Visible = true;
                        lblRootLengh.Visible = true;
                        txtRootLenght.Visible = true;
                        btnAddRoot.Visible = true;
                        SelectRootObject();
                        if (_selectRoots.Count > 0)
                            dgvRoots.DataSource = new BindingSource(_selectRoots, null);
                        break;
                    }
                case 1:
                    {
                        dgvRoots.Visible = false;
                        dgvSurface.Visible = true;
                        lblSurfaceList.Visible = true;
                        txtToothSurface.Visible = true;
                        txtToothSurface.Text = SurfaceList;
                        SelectSurfaceObject();
                        if (_selectSurface.Count > 0)
                            dgvSurface.DataSource = new BindingSource(_selectSurface, null);
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                this.CurrentPatientTreatment.Description = txtDiscription.Text;

                if (isRootTreatment)
                {
                    LRoots.Clear();
                    foreach (KeyValuePair<string, decimal> kvp in _selectRoots)
                    {
                        Roots aRoots = new Roots();
                        aRoots.PatientTreatmentID = this.CurrentPatientTreatment.PatientTreatmentID;
                        aRoots.RootName = kvp.Key;
                        aRoots.RootLenght = kvp.Value;
                        LRoots.Add(aRoots);
                    }
                }
                try
                {
                    this.CurrentPatientTreatment.RootsTreatment = this.LRoots;
                    FPatientTreatmentBLL.oPatientTreatment = this.CurrentPatientTreatment;
                    FPatientTreatmentBLL.UpdatePatientTreatmentDetails();
                    OnDetailsChanged();
                    MessageBox.Show(".اطلاعات با موفقیت ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1044");
                    MessageBox.Show("بروز خطا در ویرایش درمان مورد نظر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvRoots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var k = _selectRoots.Keys.ElementAt(e.RowIndex);
            var v = _selectRoots.Values.ElementAt(e.RowIndex);
            cboRootName.SelectedValue = k;
            txtRootLenght.Text = v.ToString();
            btnAddRoot.Enabled = true;
        }

        private void dgvRoots_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    contextMenuStrip1.Close();

            //    return;
            //}
            if (e.RowIndex == -1)
                return;
            if (e.Button == MouseButtons.Right)
                this.dgvRoots.Rows[e.RowIndex].Selected = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var k = _selectRoots.Keys.ElementAt(dgvRoots.SelectedRows[0].Index);
            var v = _selectRoots.Values.ElementAt(dgvRoots.SelectedRows[0].Index);
            cboRootName.SelectedValue = k;
            txtRootLenght.Text = v.ToString();
            btnAddRoot.Enabled = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _selectRoots.Remove(_selectRoots.Keys.ElementAt(dgvRoots.SelectedRows[0].Index));
            dgvRoots.DataSource = new BindingSource(_selectRoots, null);
        }

        private void OnDetailsChanged()
        {
            if (DetailsChanged != null)
                DetailsChanged(this, null);
        }

    }
}
