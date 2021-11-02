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
using DentiNovin;
using DentiNovin.Properties;
using DentiNovin.Common.DateConvert;

namespace DentiNovin
{
    public partial class TreatmentServiceForm : BaseForm
    {
        TextBox[] surfaceTextBoxIDArr = null;
        TextBox[] surfaceTextBoxCodeArr = null;
        TextBox[] surfaceTextBoxNameArr = null;
        Button[] surfaceButtonArr = null;
        Image imageIcon = DentiNovin.Properties.Resources.TreatmentBarTRed;
        TreatmentServiceSelector aTreatmentServiceSelector;
        private TreatmentBLL _fTreatmentBLL;
        public TreatmentBLL FTreatmentBLL
        {
            get
            {
                if (_fTreatmentBLL == null)
                    _fTreatmentBLL = new TreatmentBLL();
                return _fTreatmentBLL;
            }
            set
            {
                _fTreatmentBLL = value;
            }
        }

        private Treatment _oTreatment;
        public Treatment oTreatment
        {
            get
            {
                if (_oTreatment == null)
                    _oTreatment = new Treatment();
                return _oTreatment;
            }
            set { _oTreatment = value; }
        }
        private bool _showPersianName = true;
        private MultiCodeMode _multiCodeMode;
        private bool _toothLoaded = false;

        public TreatmentServiceForm()
        {
            InitializeComponent();
            _showPersianName = (bool)Settings.Default["ShowPersianName"];
        }

        private void GetTreatmentClassList()
        {
            try
            {
                DataSet aDataSet;
                DataSet bDataSet;
                aDataSet = FTreatmentBLL.GetTreatmentClassList();
                bDataSet = aDataSet.Copy();
                cboTreatmentClass.DataSource = aDataSet.Tables[0];
                cboTreatmentClass.DisplayMember = "LatinName";
                cboTreatmentClass.ValueMember = "TreatmentClassID";

                DataRow aDataRow = bDataSet.Tables[0].NewRow();
                aDataRow[0] = 0;
                aDataRow[3] = "تمامی دسته ها";
                bDataSet.Tables[0].Rows.InsertAt(aDataRow, 0);
                cboTreatmentClassSearch.DataSource = bDataSet.Tables[0];
                cboTreatmentClassSearch.DisplayMember = "LatinName";
                cboTreatmentClassSearch.ValueMember = "TreatmentClassID";
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1070");
                MessageBox.Show("بروز خطا در بارگزاری دسته بندی درمانها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TreatmentServiceForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dgvTreatment.AutoGenerateColumns = false;
            toothSample.IsNotDemo = false;
            toothSample.CurrentTooth = new Tooth(3, 2, ToothRootType.Molar);
            fdpActiveDate.SelectedDateTime = DateTime.Now;
            surfaceTextBoxIDArr = new TextBox[] { txtMultiID1, txtMultiID2, txtMultiID3, txtMultiID4, txtMultiID5 };
            surfaceTextBoxCodeArr = new TextBox[] { txtMultiCode1, txtMultiCode2, txtMultiCode3, txtMultiCode4, txtMultiCode5 };
            surfaceTextBoxNameArr = new TextBox[] { txtMultiCodeName1, txtMultiCodeName2, txtMultiCodeName3, txtMultiCodeName4, txtMultiCodeName5 };
            surfaceButtonArr = new Button[] { btnShowList1, btnShowList2, btnShowList3, btnShowList4, btnShowList5 };
            cboTreatmentArea.DataSource = Enum.GetValues(typeof(TreatmentArea));
            FillcboDrawType();
            FillcboBrushType();
            cpTreatmentColor.AddStandardColors();
            GetTreatmentClassList();
            //GetTreatmentServiceList(ServiceFilterType.ShowAll, PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null), 0);
            //cboBrushType.DataSource = Enum.GetValues(typeof(DrawingBrushType));
            ipIconSelector.ImageList = UtilMethods.CreateImageListFromImage(imageIcon, new Size(27, 27), Color.Magenta);
            ipIconSelector.AddImageItems();
            InitialForm(false);

        }

        private void FillcboDrawType()
        {
            Dictionary<TreatmentDrawType, string> _treatmentDrawTypeList = new Dictionary<TreatmentDrawType, string>();
            foreach (TreatmentDrawType tdt in Enum.GetValues(typeof(TreatmentDrawType)))
            {
                _treatmentDrawTypeList.Add(tdt, UtilMethods.GetEnumDescription(tdt));
            }
            cboDrawType.DataSource = new BindingSource(_treatmentDrawTypeList, null); ;
            cboDrawType.DisplayMember = "Value";
            cboDrawType.ValueMember = "Key";
        }

        private void FillcboTreatmentArea()
        {
            Dictionary<TreatmentArea, string> _treatmentAreaList = new Dictionary<TreatmentArea, string>();
            foreach (TreatmentArea ta in Enum.GetValues(typeof(TreatmentArea)))
            {
                _treatmentAreaList.Add(ta, UtilMethods.GetEnumDescription(ta));
            }
            cboTreatmentArea.DataSource = new BindingSource(_treatmentAreaList, null); ;
            cboTreatmentArea.DisplayMember = "Value";
            cboTreatmentArea.ValueMember = "Key";
        }

        private void FillcboBrushType()
        {
            Dictionary<DrawingBrushType, string> _treatmentBrushTypeList = new Dictionary<DrawingBrushType, string>();
            foreach (DrawingBrushType tbt in Enum.GetValues(typeof(DrawingBrushType)))
            {
                _treatmentBrushTypeList.Add(tbt, UtilMethods.GetEnumDescription(tbt));
            }
            cboBrushType.DataSource = new BindingSource(_treatmentBrushTypeList, null); ;
            cboBrushType.DisplayMember = "Value";
            cboBrushType.ValueMember = "Key";
        }

        private void InitialForm(Boolean SetValue)
        {
            string Code = string.Empty;
            string LatinName = string.Empty;
            string PersianName = string.Empty;
            string AbbreviationName = string.Empty;
            decimal Price = 0;
            bool showInBox = false;
            bool showRootInfoForm = false;
            for (int i = 0; i < 5; i++)
            {
                surfaceTextBoxIDArr[i].Text = string.Empty;
                surfaceTextBoxCodeArr[i].Text = string.Empty;
                surfaceTextBoxNameArr[i].Text = string.Empty;
            }
            if (SetValue)
            {
                Code = oTreatment.Code;
                LatinName = oTreatment.LatinName;
                PersianName = oTreatment.PersianName;
                AbbreviationName = oTreatment.AbbreviationName;
                Price = oTreatment.Price;
                chkToothMissing.Checked = oTreatment.MarkToothMissing;
                cboTreatmentClass.SelectedValue = oTreatment.TreatmentClassID;
                cboTreatmentArea.SelectedItem = (TreatmentArea)oTreatment.TreatmentArea;
                if (oTreatment.TreatmentArea == (int)TreatmentArea.Surface || oTreatment.TreatmentArea == (int)TreatmentArea.Root)
                {
                    try
                    {
                        DataSet aDataSet = GetRelatedTreatmentServiceList(oTreatment.TreatmentServiceID);
                        if (aDataSet.Tables.Count != 0)
                        {
                            for (int i = 0; i < aDataSet.Tables[0].Rows.Count; i++)
                            {
                                surfaceTextBoxIDArr[(byte)aDataSet.Tables[0].Rows[i][5] - 1].Text = aDataSet.Tables[0].Rows[i][1].ToString();
                                surfaceTextBoxCodeArr[(byte)aDataSet.Tables[0].Rows[i][5] - 1].Text = aDataSet.Tables[0].Rows[i][2].ToString();
                                surfaceTextBoxNameArr[(byte)aDataSet.Tables[0].Rows[i][5] - 1].Text = aDataSet.Tables[0].Rows[i][4].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        UtilMethods.LogError(ex, "1071");
                        MessageBox.Show("بروز خطا در بارگزاری لیست درمانها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                cboDrawType.SelectedValue = (TreatmentDrawType)oTreatment.DrawType;
                cboBrushType.SelectedValue = (DrawingBrushType)oTreatment.BrushType;
                for (int i = 0; i < cpTreatmentColor.Items.Count; i++)
                {
                    if (((DentiNovin.Controls.MNMColorPicker.ColorInfo)cpTreatmentColor.Items[i]).Color.ToArgb() == oTreatment.BrushColor)
                    {
                        cpTreatmentColor.SelectedIndex = i;
                        break;
                    }
                }
                ipIconSelector.SelectedIndex = oTreatment.ToolBoxImageIndex;
                showInBox = oTreatment.ShowInToolBox;
                showRootInfoForm = oTreatment.ShowRootInfoForm;
                fdpActiveDate.Text = oTreatment.DateOfRegister;
                aPageMode = PageMode.Mode_edit;
                btnSave.Text = "ویرایش";
                btnCancle.Enabled = true;
            }
            else
            {
                fdpActiveDate.SelectedDateTime = DateTime.Now;
                chkToothMissing.Checked = false;
                cboBrushType.SelectedIndex = 0;
                cboDrawType.SelectedIndex = 0;
                cpTreatmentColor.SelectedIndex = 0;
                ipIconSelector.SelectedIndex = -1;
                aPageMode = PageMode.Mode_new;
                btnSave.Text = "ثبت";
                btnCancle.Enabled = false;
            }

            txtCode.Text = Code;
            txtLatinName.Text = LatinName;
            txtPersianName.Text = PersianName;
            txtAbbreviationName.Text = AbbreviationName;
            txtPrice.Text = Price.ToString();
            chkShowInToolBox.Checked = showInBox;
            chkShowRootInfoForm.Checked = showRootInfoForm;
        }

        private void GetTreatmentServiceList(ServiceFilterType sft, string currentDate, int treatmentClassID)
        {
            try
            {
                DataSet aDataSet;
                aDataSet = FTreatmentBLL.GetTreatmentServiceList(sft, currentDate, treatmentClassID, string.Empty, txtTreatmentNameSearch.Text.Trim(), _showPersianName);
                dgvTreatment.DataSource = aDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                UtilMethods.LogError(ex, "1072");
                MessageBox.Show("بروز خطا در بارگزاری لیست درمانها", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtCode, "کد درمان راوارد کنید");
                txtCode.Focus();
                return;
            }
            if (txtPersianName.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtPersianName, "نام فارسی درمان راوارد کنید");
                txtPersianName.Focus();
                return;
            }
            if (txtLatinName.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(txtLatinName, "نام لاتین درمان راوارد کنید");
                txtLatinName.Focus();
                return;
            }

            if (fdpActiveDate.Text.Trim() == "")
            {
                tabControl1.SelectedTab = tabPage1;
                errorProvider1.SetError(fdpActiveDate, " تاریخ اعمال درمان راوارد کنید");
                fdpActiveDate.Focus();
                return;
            }

            SetTreatmentService();
            FTreatmentBLL.oTreatment = this.oTreatment;

            if (aPageMode == PageMode.Mode_new)
                try
                {
                    FTreatmentBLL.TreatmentServiceInsert();
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1073");
                    MessageBox.Show("بروز خطا در ثبت درمان جدید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            else
                try
                {
                    FTreatmentBLL.TreatmentServiceEdit();
                }
                catch (Exception ex)
                {
                    UtilMethods.LogError(ex, "1074");
                    MessageBox.Show("بروز خطا در ویرایش درمان ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            MessageBox.Show(".عملیات با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GetTreatmentServiceList(ServiceFilterType.ShowAll, PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null), (int)((DataRowView)cboTreatmentClassSearch.SelectedItem).Row.ItemArray[0]);

            InitialForm(false);
        }

        private void SetTreatmentService()
        {
            oTreatment.TreatmentClassID = (int)((DataRowView)cboTreatmentClass.SelectedItem).Row.ItemArray[0];
            oTreatment.Code = txtCode.Text;
            oTreatment.PersianName = txtPersianName.Text;
            oTreatment.LatinName = txtLatinName.Text;
            oTreatment.AbbreviationName = txtAbbreviationName.Text;
            oTreatment.Price = 0;// Convert.ToDecimal(txtPrice.Text);
            oTreatment.TreatmentArea = (int)cboTreatmentArea.SelectedItem;
            //oTreatment.DrawType = (int)cboDrawType.SelectedItem;
            oTreatment.DrawType = (int)((System.Collections.Generic.KeyValuePair<DentiNovin.Common.TreatmentDrawType, string>)(cboDrawType.SelectedItem)).Key;
            oTreatment.BrushType = (int)((System.Collections.Generic.KeyValuePair<DentiNovin.Common.DrawingBrushType, string>)(cboBrushType.SelectedItem)).Key;
            oTreatment.BrushColor = cpTreatmentColor.SelectedValue.ToArgb();
            oTreatment.ShowInToolBox = chkShowInToolBox.Checked;
            oTreatment.MarkToothMissing = chkToothMissing.Checked;
            oTreatment.ShowRootInfoForm = false;
            if (oTreatment.TreatmentArea == (int)TreatmentArea.Root)
            {
                oTreatment.ShowRootInfoForm = chkShowRootInfoForm.Checked;
            }
            oTreatment.ToolBoxImageIndex = (Int16)ipIconSelector.SelectedIndex;
            oTreatment.DateOfRegister = fdpActiveDate.Text;
            oTreatment.RelateCode.Clear();
            if (oTreatment.TreatmentArea != (int)TreatmentArea.Surface && oTreatment.TreatmentArea != (int)TreatmentArea.Root)
                return;
            foreach (TextBox tb in surfaceTextBoxIDArr)
            {
                if (tb.Text.Trim() == "")
                    tb.Text = "0";
                oTreatment.RelateCode.Add(Convert.ToInt32(tb.Text));
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            InitialForm(false);
        }

        private void cboTreatmentArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTreatmentArea.SelectedIndex == 0 || cboTreatmentArea.SelectedIndex == 1)
            chkShowRootInfoForm.Visible = false;
            if (cboTreatmentArea.SelectedIndex == 0)
                _multiCodeMode = MultiCodeMode.MultiplesurfaceCode;
            else
            {
                if (cboTreatmentArea.SelectedIndex == 2)
                {
                    _multiCodeMode = MultiCodeMode.AlternateRootCode;
                    chkShowRootInfoForm.Visible = true;
                }
                else
                    _multiCodeMode = MultiCodeMode.None;
            }

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            label13.Text = "یک سطحی:";
            label14.Text = "دو سطحی:";
            label15.Text = "سه سطحی:";
            label16.Visible = true;
            label17.Visible = true;
            txtMultiCode4.Visible = true;
            txtMultiCode5.Visible = true;
            txtMultiCodeName4.Visible = true;
            txtMultiCodeName5.Visible = true;
            btnShowList4.Visible = true;
            btnShowList5.Visible = true;

            switch (_multiCodeMode)
            {
                case MultiCodeMode.None:
                    groupBox5.Visible = false;
                    break;
                case MultiCodeMode.AlternateRootCode:
                    label13.Text = "قدامی:";
                    label14.Text = "دوپایه:";
                    label15.Text = "آسیاب:";
                    label16.Visible = false;
                    label17.Visible = false;
                    txtMultiCode4.Visible = false;
                    txtMultiCode5.Visible = false;
                    txtMultiCodeName4.Visible = false;
                    txtMultiCodeName5.Visible = false;
                    btnShowList4.Visible = false;
                    btnShowList5.Visible = false;
                    break;
                case MultiCodeMode.MultiplesurfaceCode:
                    break;
                default:
                    break;
            }

        }

        int btnNumber = 0;
        private void btnShowList_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < surfaceButtonArr.Length; i++)
            {
                if ((Button)sender == surfaceButtonArr[i])
                {
                    btnNumber = i;
                    break;
                }
            }
            aTreatmentServiceSelector = new TreatmentServiceSelector();
            aTreatmentServiceSelector.TreatmentSelected += new EventHandler(aTreatmentServiceSelector_TreatmentSelected);
            aTreatmentServiceSelector.TopMost = true;
            aTreatmentServiceSelector.ShowDialog();
        }

        void aTreatmentServiceSelector_TreatmentSelected(object sender, EventArgs e)
        {
            surfaceTextBoxIDArr[btnNumber].Text = aTreatmentServiceSelector.oTreatment.TreatmentServiceID.ToString();
            surfaceTextBoxCodeArr[btnNumber].Text = aTreatmentServiceSelector.oTreatment.Code;
            if(_showPersianName)
                surfaceTextBoxNameArr[btnNumber].Text = aTreatmentServiceSelector.oTreatment.PersianName;
            else
                surfaceTextBoxNameArr[btnNumber].Text = aTreatmentServiceSelector.oTreatment.LatinName;
        }

        private DataSet GetRelatedTreatmentServiceList(int serviceID)
        {
            return FTreatmentBLL.GetRelatedTreatmentServiceList(serviceID);
        }

        private void cboTreatmentClassSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTreatmentServiceList(ServiceFilterType.ShowAll, PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null), (int)((DataRowView)cboTreatmentClassSearch.SelectedItem).Row.ItemArray[0]);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetTreatmentServiceList(ServiceFilterType.ShowAll, PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null), (int)((DataRowView)cboTreatmentClassSearch.SelectedItem).Row.ItemArray[0]);
        }

        private void txtMultiCode1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMultiID1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMultiCodeName1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void txtLatinName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].Culture.EnglishName == "Persian")
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }
        }

        private void txtPersianName_Leave(object sender, EventArgs e)
        {
            UtilMethods.ClearErrorProvider((TextBox)sender, this.errorProvider1, false);
        }

        private void fdpActiveDate_Leave(object sender, EventArgs e)
        {
            if (fdpActiveDate.Text.Trim() != "")
                errorProvider1.Clear();
        }

        private void dgvTreatment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            SetSelectedObject((DataRowView)dgvTreatment.SelectedRows[0].DataBoundItem);
            InitialForm(true);
        }

        private void SetSelectedObject(DataRowView selectedDataRow)
        {
            oTreatment.TreatmentServiceID = (int)selectedDataRow.Row.ItemArray[1];
            oTreatment.TreatmentClassID = (Int16)selectedDataRow.Row.ItemArray[2];
            oTreatment.Code = selectedDataRow.Row.ItemArray[3].ToString();
            oTreatment.PersianName = selectedDataRow.Row.ItemArray[4].ToString();
            oTreatment.LatinName = selectedDataRow.Row.ItemArray[5].ToString();
            oTreatment.AbbreviationName = selectedDataRow.Row.ItemArray[6].ToString();
            oTreatment.Price = (decimal)selectedDataRow.Row.ItemArray[7];
            oTreatment.TreatmentArea = (Int16)selectedDataRow.Row.ItemArray[8];
            oTreatment.DrawType = (Int16)selectedDataRow.Row.ItemArray[9];
            oTreatment.BrushType = (Int16)selectedDataRow.Row.ItemArray[10];
            oTreatment.BrushColor = (int)selectedDataRow.Row.ItemArray[17];
            //oTreatment.AvoirSurfaceCode = (bool)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[11];
            //oTreatment.AvoirSurfaceView = (bool)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[12];
            //oTreatment.Single = (bool)((System.Data.DataRowView)(dgvTreatment.Rows[e.RowIndex].DataBoundItem)).Row.ItemArray[13];
            oTreatment.DateOfRegister = selectedDataRow.Row.ItemArray[11].ToString();
            oTreatment.ShowInToolBox = (bool)selectedDataRow.Row.ItemArray[12];
            oTreatment.ToolBoxImageIndex = (Int16)selectedDataRow.Row.ItemArray[13];
            if (oTreatment.TreatmentArea == (int)TreatmentArea.Root)
                oTreatment.ShowRootInfoForm = (bool)selectedDataRow.Row.ItemArray[18];
            else
                oTreatment.ShowRootInfoForm = false;
            oTreatment.MarkToothMissing = (bool)selectedDataRow.Row.ItemArray[21];
        }

        private void dgvTreatment_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.dgvTreatment.Rows[e.RowIndex].Selected = true;
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvTreatment.SelectedRows.Count <= 0)
                return;
            dgvTreatment_CellDoubleClick(this, new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvTreatment.SelectedRows.Count <= 0)
                return;
            if (MessageBox.Show("رکورد مورد نظر حذف خواهد شد آیا مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {

                    FTreatmentBLL.DeleteObject((int)((DataRowView)dgvTreatment.SelectedRows[0].DataBoundItem).Row.ItemArray[1]);
                    InitialForm(false);
                    GetTreatmentServiceList(ServiceFilterType.ShowAll, PersianDateConverter.ToPersianDate(DateTime.Now).ToString("d", null), (int)((DataRowView)cboTreatmentClassSearch.SelectedItem).Row.ItemArray[0]);

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message == "60090")
                        MessageBox.Show(".به دلیل استفاده از این سرویس در درمان بیمار،امکان حذف وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvTreatment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (dgvTreatment.SelectedRows.Count > 0)
                    tsmiDelete_Click(null, null);
        }

        private void cpTreatmentColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            toothSample.ResetSurfacesView();
            toothSample.MarkToothMissing = chkToothMissing.Checked;

            if (cboDrawType.SelectedIndex != 0)
            {
                cboBrushType.Enabled = true;
                cpTreatmentColor.Enabled = true;
                toothSample.DrawTreatmentSurface((TreatmentDrawType)cboDrawType.SelectedValue, (DrawingBrushType)cboBrushType.SelectedValue, new System.Collections.ArrayList(new[] { 1, 2, 3 }), 2, (Color)cpTreatmentColor.SelectedValue,chkToothMissing.Checked);
            }
            else
            {
                cboBrushType.Enabled = false;
                cpTreatmentColor.Enabled = false;
            }
        }

        private void txtLatinName_Enter(object sender, EventArgs e)
        {
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].Culture.EnglishName == "English (United States)")
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                    //return;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2 && !_toothLoaded)
            {
                _toothLoaded = true;
                cpTreatmentColor_SelectedIndexChanged(null, null);
            }

        }



    }
}
