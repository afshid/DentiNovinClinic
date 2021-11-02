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

namespace DentiNovin
{
    public partial class RootCanalForm : BaseForm
    {
        Dictionary<string, string> _validRoots = new Dictionary<string, string> { { "Single", "S" }, { "Buccal", "B" },
        { "Mesial", "M" }, { "Distal", "D" }, { "Palatal", "P" }, { "Mesiobuccal", "MB" }, { "Distibuccal", "DB" } };

        Dictionary<string, decimal> _selectRoots = new Dictionary<string, decimal>();

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

        private PatientTreatment _currentPatientTreatment;
        public PatientTreatment CurrentPatientTreatment
        {
            get { return _currentPatientTreatment; }
            set { _currentPatientTreatment = value; }
        }

        decimal _rootLenght = 0;
        public event EventHandler RootsSelected;
        public RootCanalForm()
        {
            InitializeComponent();
        }

        private void RootCanalForm_Load(object sender, EventArgs e)
        {
            cboRootName.DataSource = new BindingSource(_validRoots, null);
            cboRootName.DisplayMember = "Key";
            cboRootName.ValueMember = "Value";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            CurrentPatientTreatment.RootsTreatment.Clear();
            foreach (KeyValuePair<string, decimal> kvp in _selectRoots)
            {
                Roots aRoots = new Roots();
                aRoots.PatientTreatmentID = this.CurrentPatientTreatment.PatientTreatmentID;
                aRoots.RootName = kvp.Key;
                aRoots.RootLenght = kvp.Value;
                CurrentPatientTreatment.RootsTreatment.Add(aRoots);
            }
            OnRootsSelected();
            this.Dispose();
        }
        private void OnRootsSelected()
        {
            if (RootsSelected != null)
                RootsSelected(this, null);
        }

        private void dgvRoots_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void cboRootName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectRoots.ContainsKey(((System.Collections.Generic.KeyValuePair<string, string>)(cboRootName.SelectedItem)).Value))
                btnAddRoot.Enabled = false;
            else
                if (_selectRoots.Count < 5)
                    btnAddRoot.Enabled = true;
            txtRootLenght.Focus();
        }
    }
}
